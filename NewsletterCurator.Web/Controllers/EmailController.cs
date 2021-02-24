using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewsletterCurator.Data;
using NewsletterCurator.HTMLScraper;
using NewsletterCurator.Web.Models;
using Newtonsoft.Json;

namespace NewsletterCurator.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly NewsletterCuratorContext newsletterCuratorContext;
        private readonly HTMLScraperService htmlScraperService;
        private readonly EmailService.EmailService emailService;
        private readonly IConfiguration configuration;
        private readonly IHttpClientFactory clientFactory;

        public EmailController(NewsletterCuratorContext newsletterCuratorContext, HTMLScraperService htmlScraperService, EmailService.EmailService emailService, IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            this.newsletterCuratorContext = newsletterCuratorContext;
            this.htmlScraperService = htmlScraperService;
            this.emailService = emailService;
            this.configuration = configuration;
            this.clientFactory = clientFactory;
        }

        public async Task<IActionResult> Send()
        {
            var emailSrc = await htmlScraperService.ScrapeAsync(new Uri(Url.AbsoluteAction("Preview", "Email", new { isWeb = false })));
            var webSrc = await htmlScraperService.ScrapeAsync(new Uri(Url.AbsoluteAction("Preview", "Email", new { isWeb = true })));

            var newsletterFilename = $"{DateTimeOffset.UtcNow.ToString("yyyy-MM-dd")}.html";

            var hashTags = (newsletterCuratorContext.NewsitemsByCategory().SelectMany(n => n.Key.HashTags).ToList());

            await addToGitHubArchive(webSrc, newsletterFilename);

            await emailService.SendAsync(emailSrc, await newsletterCuratorContext.Subscribers.Where(s => s.DateUnsubscribed == null && s.DateValidated != null).Select(s => s.Email).ToListAsync());

            newsletterCuratorContext.Newsitems.RemoveRange(newsletterCuratorContext.Newsitems);
            await newsletterCuratorContext.SaveChangesAsync();

            return RedirectToAction("Share", new { newsletterUrl = $"https://newsletters.cdemi.io/archives/{newsletterFilename}", hashTags });
        }

        public IActionResult Share(string newsletterUrl, string[] hashTags)
        {
            return View(new ShareUrlModel { URL = HttpUtility.UrlEncode(newsletterUrl), HashTags = hashTags });
        }

        private async Task<HttpResponseMessage> addToGitHubArchive(string source, string newsletterFilename)
        {
            var client = clientFactory.CreateClient("github");

            var request = new HttpRequestMessage(HttpMethod.Put, $"/repos/{configuration.GetValue<string>("GitHub:Username")}/{configuration.GetValue<string>("GitHub:ArchiveRepo")}/contents/archives/{newsletterFilename}")
            {
                Content = new StringContent(JsonConvert.SerializeObject(new
                {
                    message = $"Added newsletter for {DateTimeOffset.UtcNow.ToString("D", CultureInfo.CreateSpecificCulture("en-US"))}",
                    content = Convert.ToBase64String(Encoding.UTF8.GetBytes(source)),
                }), Encoding.UTF8, "application/json")
            };
            var response = await client.SendAsync(request);
            return response;
        }

        public IActionResult Preview(bool isWeb)
        {
            var categoryNewsItemsViewModels = newsletterCuratorContext.NewsitemsByCategory().Select(c => new CategoryNewsItemsViewModel { Category = c.Key, Newsitems = c.OrderBy(ni=>ni.DateTime).ToList() }).ToList();

            return View(new PreviewModel { Newsitems = categoryNewsItemsViewModels, CoverPicture = newsletterCuratorContext.Settings.SingleOrDefault(k=>k.Key.Equals("CoverPicture")).Value, IsWeb = isWeb });
        }
    }
}
