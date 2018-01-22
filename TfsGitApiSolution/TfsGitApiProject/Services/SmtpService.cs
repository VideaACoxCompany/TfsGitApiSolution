using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace TfsGitApiProject.Services
{
    public class SmtpService
    {
        public void SendEmail(string body)
        {

            var fromAddress = new MailAddress("johnnyuhc@gmail.com", "Johnny Chu");
            var toAddress = new MailAddress("johnny.chu@videa.tv", "Johnny Chu");

            const string fromPassword = "abcd123";
            const string subject = "Branch Verification";


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
                {

                    Subject = subject,
                    Body = body
                }

            )
            {
                smtp.Send(message);
            }

        }
    }
}
