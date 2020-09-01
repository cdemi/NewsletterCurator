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
            var categoryNewsItemsViewModels = newsletterCuratorContext.NewsitemsByCategory().Select(c => new CategoryNewsItemsViewModel { Category = c.Key, Newsitems = c.OrderBy(ni=>ni.DateTime).ToList() }).ToList();

            return View(categoryNewsItemsViewModels);
        }
    }
}
