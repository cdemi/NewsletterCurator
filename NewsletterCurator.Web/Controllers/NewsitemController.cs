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
        private readonly HTMLScraperService htmlScraperService;

        public NewsitemController(NewsletterCuratorContext newsletterCuratorContext, HTMLScraperService htmlParserService)
        {
            this.newsletterCuratorContext = newsletterCuratorContext;
            this.htmlScraperService = htmlParserService;
        }

        public async Task<IActionResult> Add(string url)
        {
            var urlMetaData = await htmlScraperService.Scrape(url);

            return View(new AddNewsitemViewModel
            {
                URL = urlMetaData.CanonicalURL,
                Categories = newsletterCuratorContext.Categories.Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = s.ID.ToString(), Text = s.Name }).ToList(),
                Title = urlMetaData.Title,
                Images = urlMetaData.Images,
                Summary = urlMetaData.Summary,
            });
        }
    }
}
