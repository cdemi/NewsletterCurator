using Microsoft.AspNetCore.Mvc;

namespace NewsletterCurator.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
