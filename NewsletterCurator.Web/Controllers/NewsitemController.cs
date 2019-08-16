using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsletterCurator.Data;
using NewsletterCurator.HTMLScraper;
using NewsletterCurator.Web.Models;
using NewsletterCurator.YouTubeScraper;

namespace NewsletterCurator.Web.Controllers
{
    public class NewsitemController : Controller
    {
        private readonly NewsletterCuratorContext newsletterCuratorContext;
        private readonly HTMLScraperService htmlScraperService;
        private readonly YouTubeMetadataService youTubeMetadataService;

        public NewsitemController(NewsletterCuratorContext newsletterCuratorContext, HTMLScraperService htmlScraperService, YouTubeMetadataService youTubeMetadataService)
        {
            this.newsletterCuratorContext = newsletterCuratorContext;
            this.htmlScraperService = htmlScraperService;
            this.youTubeMetadataService = youTubeMetadataService;
        }

        public async Task<IActionResult> Add(string url)
        {
            Scraper.Contracts.URLMetadata urlMetaData;

            if (url.Replace(".","").Contains("youtube", StringComparison.InvariantCultureIgnoreCase))
                urlMetaData = await youTubeMetadataService.ScrapeMetadataAsync(url);
            else
                urlMetaData = await htmlScraperService.ScrapeMetadataAsync(url);

            return View(new AddNewsitemViewModel
            {
                URL = urlMetaData.CanonicalURL,
                Categories = newsletterCuratorContext.Categories.OrderBy(c => c.Name).ToList(),
                Title = urlMetaData.Title,
                Images = urlMetaData.Images.Distinct().ToList(),
                Summary = urlMetaData.Summary,
                Favicon = urlMetaData.FaviconURL,
                Tags = urlMetaData.Tags
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
                FaviconURL = addNewsitemViewModel.Favicon,
                DateTime = DateTimeOffset.UtcNow,
                Tags = addNewsitemViewModel.Tags?.ToArray()
            });

            await newsletterCuratorContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var newsItem = await newsletterCuratorContext.Newsitems.SingleOrDefaultAsync(n => n.ID.Equals(id));

            if (newsItem != null)
            {
                newsletterCuratorContext.Newsitems.Remove(newsItem);
                await newsletterCuratorContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
