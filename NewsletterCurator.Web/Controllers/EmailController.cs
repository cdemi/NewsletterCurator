using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsletterCurator.Data;
using NewsletterCurator.HTMLScraper;
using NewsletterCurator.Web.Models;

namespace NewsletterCurator.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly NewsletterCuratorContext newsletterCuratorContext;
        private readonly HTMLScraperService htmlScraperService;

        public EmailController(NewsletterCuratorContext newsletterCuratorContext, HTMLScraperService htmlScraperService)
        {
            this.newsletterCuratorContext = newsletterCuratorContext;
            this.htmlScraperService = htmlScraperService;
        }

        public async Task<IActionResult> Send()
        {
            var src = await htmlScraperService.Scrape(Url.AbsoluteAction("Preview", "Email"));
            return new ContentResult()
            {
                Content = src,
                ContentType = "text/html",
            };
        }

        public async Task<IActionResult> Preview()
        {
            var categoryNewsItemsViewModels = await newsletterCuratorContext.NewsitemsByCategory().Select(c => new CategoryNewsItemsViewModel { Category = c.Key, Newsitems = c.ToList() }).ToListAsync();

            return View(categoryNewsItemsViewModels);
        }
    }
}
