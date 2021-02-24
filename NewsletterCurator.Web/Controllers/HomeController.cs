using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsletterCurator.Data;
using NewsletterCurator.Web.Models;

namespace NewsletterCurator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsletterCuratorContext newsletterCuratorContext;

        public HomeController(NewsletterCuratorContext newsletterCuratorContext)
        {
            this.newsletterCuratorContext = newsletterCuratorContext;
        }

        public IActionResult Index()
        {
            var categoryNewsItemsViewModels = newsletterCuratorContext.NewsitemsByCategory().Select(c => new CategoryNewsItemsViewModel { Category = c.Key, Newsitems = c.OrderBy(ni => ni.DateTime).ToList() }).ToList();

            return View(new HomeView { CategoryNewsItems = categoryNewsItemsViewModels, Settings = newsletterCuratorContext.Settings.ToList() });
        }

        public async Task<IActionResult> UpdateSetting(string key, string value)
        {
            var setting = await newsletterCuratorContext.Settings.SingleOrDefaultAsync(s => s.Key.Equals(key));
            setting.Value = value;
            await newsletterCuratorContext.SaveChangesAsync();

            return Ok();
        }
    }
}
