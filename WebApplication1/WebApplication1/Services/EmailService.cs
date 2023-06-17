using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MimeKit;
using MimeKit.Text;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class EmailService
    {
        private IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        public void SendEmail(string To,string body)
        {
            //config["Email:Username"]
            MimeMessage email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config["Email:Username"]));
            email.To.Add(MailboxAddress.Parse(To) );
            email.Subject = "Update Password";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            SmtpClient smtp = new SmtpClient();
            //smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("moeenadlymansour@gmail.com", "encgbocsxipgmcjx");
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        private string GetEmailBody()
        {
            throw new NotImplementedException();
        }
    }
}
