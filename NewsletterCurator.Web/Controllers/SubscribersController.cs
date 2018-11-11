using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsletterCurator.Data;

namespace NewsletterCurator.Web.Controllers
{
    public class SubscribersController : Controller
    {
        private readonly NewsletterCuratorContext newsletterCuratorContext;

        public SubscribersController(NewsletterCuratorContext newsletterCuratorContext)
        {
            this.newsletterCuratorContext = newsletterCuratorContext;
        }

        public async Task<IActionResult> Index()
        {
            var subscribers = await newsletterCuratorContext.Subscribers.OrderByDescending(s => new[] { s.DateSubscribed, s.DateUnsubscribed, s.DateValidated }.Max()).ToListAsync();
            return View(subscribers);
        }
    }
}
