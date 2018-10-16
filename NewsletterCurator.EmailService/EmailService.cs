using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NewsletterCurator.EmailService
{
    public class EmailService
    {
        private readonly SmtpClient smtpClient;
        private readonly string unsubscribeEmail;

        public EmailService(SmtpClient smtpClient, string unsubscribeEmail)
        {
            this.smtpClient = smtpClient;
            this.unsubscribeEmail = unsubscribeEmail;
        }

        public async Task SendAsync(string html, List<string> bcc)
        {
            var mail = new MailMessage()
            {
                From = new MailAddress("curated@newsletters.cdemi.io", "cdemi's Curated Newsletter"),
                Subject = $"{DateTime.Now.ToString("dd MMMM yyyy")} - cdemi's Curated Newsletter",
                Body = html,
                IsBodyHtml = true
            };
            foreach (var address in bcc)
            {
                mail.Bcc.Add(address);
            }
            mail.Headers.Add("List-Unsubscribe", $"<mailto:{unsubscribeEmail}?subject=unsubscribe>");
            await smtpClient.SendMailAsync(mail);
        }

        public async Task SendValidationEmailAsync(string email, string validationURL)
        {
            var mail = new MailMessage(new MailAddress("curated@newsletters.cdemi.io", "cdemi's Curated Newsletter"), new MailAddress(email))
            {
                Subject = $"Validate your Email",
                Body = $"<h1>Welcome to cdemi's Curated Newsletter!</h1><br/><br/>Please validate your email by clicking this link: <a href='{validationURL}'>{validationURL}</a>",
                IsBodyHtml = true
            };
            mail.Headers.Add("List-Unsubscribe", $"<mailto:{unsubscribeEmail}?subject=unsubscribe>");
            await smtpClient.SendMailAsync(mail);
        }
    }
}
