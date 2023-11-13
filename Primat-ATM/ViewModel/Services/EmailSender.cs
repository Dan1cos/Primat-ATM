using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Primat_ATM.ViewModel.Services
{
    public static class EmailSender
    {
        public static void SendEmail(string emailTo, string subjectMsg, string bodyMsg)
        {
            MailAddress fromAddress = new MailAddress("primatatm.app@gmail.com");
            MailAddress toAddress = new MailAddress(emailTo);
            const string fromPassword = "mbaj gitt hdke wrrp";
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
