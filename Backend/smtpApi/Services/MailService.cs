using System.Net;
using System.Net.Mail;
using SmtpMailApi.Models;

namespace SmtpMailApi.Services
{
    public class MailService
    {
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = mailRequest.SmtpServer;
            smtp.Port = mailRequest.Port;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = mailRequest.UseSSl;
            smtp.Credentials = new NetworkCredential(mailRequest.Username, mailRequest.Password);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(mailRequest.FromEmail);
            mail.To.Add(new MailAddress(mailRequest.ToEmail));
            mail.Body = mailRequest.Body;
            mail.Subject = mailRequest.Subject;

            await smtp.SendMailAsync(mail);
        }
    }
}
