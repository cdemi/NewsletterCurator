using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NewsletterCurator.Data;
using NewsletterCurator.HTMLScraper;
using NewsletterCurator.Web.Models;

namespace NewsletterCurator.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly NewsletterCuratorContext newsletterCuratorContext;
        private readonly HTMLScraperService htmlScraperService;
        private readonly EmailService.EmailService emailService;
        private readonly IConfiguration configuration;

        public EmailController(NewsletterCuratorContext newsletterCuratorContext, HTMLScraperService htmlScraperService, EmailService.EmailService emailService, IConfiguration configuration)
        {
            this.newsletterCuratorContext = newsletterCuratorContext;
            this.htmlScraperService = htmlScraperService;
            this.emailService = emailService;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Send()
        {
            var src = await htmlScraperService.ScrapeAsync(Url.AbsoluteAction("Preview", "Email"));

            await emailService.SendAsync(src, await newsletterCuratorContext.Subscribers.Where(s => s.DateUnsubscribed == null && s.DateValidated != null).Select(s => s.Email).ToListAsync());

            newsletterCuratorContext.Newsitems.RemoveRange(newsletterCuratorContext.Newsitems);
            await newsletterCuratorContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Preview()
        {
            var categoryNewsItemsViewModels = await newsletterCuratorContext.NewsitemsByCategory().Select(c => new CategoryNewsItemsViewModel { Category = c.Key, Newsitems = c.ToList() }).ToListAsync();

            return View(categoryNewsItemsViewModels);
        }
    }
}
