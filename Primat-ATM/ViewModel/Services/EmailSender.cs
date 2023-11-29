using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Primat_ATM.Repository;

namespace Primat_ATM.ViewModel.Services
{
    public static class EmailSender
    {
        public static void SendEmail(string emailTo, string subjectMsg, string bodyMsg)
        {
            var root = new DirectoryInfo(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
            var path = Path.Combine(root, ".env");
            DotEnv.Load(path);
            string emailFrom = Environment.GetEnvironmentVariable("EMAIL");
            MailAddress fromAddress = new MailAddress(emailFrom);
            MailAddress toAddress = new MailAddress(emailTo);
            string fromPassword = Environment.GetEnvironmentVariable("EMAIL_PASSWORD");
            string subject = subjectMsg;
            string body = bodyMsg;

            using (SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            })

            using (MailMessage mailMessage = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            smtp.Send(mailMessage);
        }
    }
}
