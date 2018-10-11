using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NewsletterCurator.Data;

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
            return View(newsletterCuratorContext.Categories.ToList());
        }
    }
}
