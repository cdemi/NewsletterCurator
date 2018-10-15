using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsletterCurator.Data;
using NewsletterCurator.HTMLScraper;
using NewsletterCurator.Web.Models;

namespace NewsletterCurator.Web.Controllers
{
    public class NewsitemController : Controller
    {
        private readonly NewsletterCuratorContext newsletterCuratorContext;
        private readonly HTMLScraperService htmlParserService;

        public NewsitemController(NewsletterCuratorContext newsletterCuratorContext, HTMLScraperService htmlParserService)
        {
            this.newsletterCuratorContext = newsletterCuratorContext;
            this.htmlParserService = htmlParserService;
        }

        public async Task<IActionResult> Add(string url)
        {
            var urlMetaData = await htmlParserService.Scrape(url);

            return View(new AddNewsitemViewModel
            {
                URL = urlMetaData.CanonicalURL,
                Categories = newsletterCuratorContext.Categories.Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = s.ID.ToString(), Text = s.Name }).ToList(),
                Title = urlMetaData.Title,
                Images = urlMetaData.Images,
                Summary = urlMetaData.Summary,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNewsitemViewModel addNewsitemViewModel)
        {
            await newsletterCuratorContext.Newsitems.AddAsync(new Newsitem
            {
                CategoryID = addNewsitemViewModel.CategoryID,
                ImageURL = addNewsitemViewModel.ImageURL,
                IsAlreadySent = false,
                Summary = addNewsitemViewModel.Summary,
                Title = addNewsitemViewModel.Title,
                URL = addNewsitemViewModel.URL,
                DateTime = DateTimeOffset.UtcNow
            });

            await newsletterCuratorContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");

        }
    }
}
