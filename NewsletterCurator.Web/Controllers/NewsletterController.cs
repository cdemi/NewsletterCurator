using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsletterCurator.Data;

namespace NewsletterCurator.Web.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly NewsletterCuratorContext newsletterCuratorContext;
        private readonly EmailService.EmailService emailService;

        public NewsletterController(NewsletterCuratorContext newsletterCuratorContext, EmailService.EmailService emailService)
        {
            this.newsletterCuratorContext = newsletterCuratorContext;
            this.emailService = emailService;
        }

        public IActionResult Unsubscribe()
        {
            return View(false);
        }

        [HttpPost]
        public async Task<IActionResult> Unsubscribe(string email)
        {
            var subscriber = newsletterCuratorContext.Subscribers.SingleOrDefault(s => s.Email.Equals(email));

            if (subscriber != null)
            {
                subscriber.DateUnsubscribed = DateTimeOffset.UtcNow;
            }

            await newsletterCuratorContext.SaveChangesAsync();


            return View(true);
        }

        public IActionResult Subscribe()
        {
            return View(false);
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string email)
        {
            var subscriber = newsletterCuratorContext.Subscribers.SingleOrDefault(s => s.Email.Equals(email));

            if (subscriber == null)
            {
                subscriber = new Subscriber
                {
                    ID = Guid.NewGuid(),
                    Email = email,
                    DateSubscribed = DateTimeOffset.UtcNow
                };
                await newsletterCuratorContext.Subscribers.AddAsync(subscriber);
            }
            else
            {
                subscriber.DateUnsubscribed = null;
                subscriber.DateValidated = null;
            }

            await newsletterCuratorContext.SaveChangesAsync();

            await emailService.SendValidationEmailAsync(email, Url.AbsoluteAction("Validate", "Newsletter", new { id = subscriber.ID }));

            return View(true);
        }

        public async Task<IActionResult> Validate(Guid id)
        {
            var subscriber = await newsletterCuratorContext.Subscribers.FindAsync(id);
            subscriber.DateValidated = DateTimeOffset.UtcNow;
            await newsletterCuratorContext.SaveChangesAsync();
            return View();
        }
    }
}
