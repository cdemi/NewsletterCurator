using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsletterCurator.Data;
using NewsletterCurator.HTMLParser;
using NewsletterCurator.Web.Models;

namespace NewsletterCurator.Web.Controllers
{
    public class NewsitemController : Controller
    {
        private readonly NewsletterCuratorContext newsletterCuratorContext;
        private readonly HTMLParserService htmlParserService;

        public NewsitemController(NewsletterCuratorContext newsletterCuratorContext, HTMLParserService htmlParserService)
        {
            this.newsletterCuratorContext = newsletterCuratorContext;
            this.htmlParserService = htmlParserService;
        }

        public async Task<IActionResult> Add(string url)
        {
            var urlMetaData = await htmlParserService.Parse(url);

            return View(new AddNewsitemViewModel
            {
                URL = url,
                Categories = newsletterCuratorContext.Categories.Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = s.ID.ToString(), Text = s.Name }).ToList(),
                Title = urlMetaData.Title,
                Images = urlMetaData.Images,
                Summary = urlMetaData.Summary
            });
        }
    }
}
