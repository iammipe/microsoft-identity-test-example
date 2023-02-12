using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Infrastructure.EmailProvider
{
    public class EmailSender : IEmailSender
    {
        public void Send(string to, string subject, string html)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("mail@outlook.com"));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };
            
            using var smtp = new SmtpClient();
            smtp.Connect("smtp-mail.outlook.com", 587);
            smtp.Authenticate("mail@outlook.com", "Pass!123");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}