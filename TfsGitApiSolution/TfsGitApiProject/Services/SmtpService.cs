using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace TfsGitApiProject.Services
{
    class SmtpService
    {
        public void SendEmail()
        {

            string to = "johnny.chu@videa.tv";
            string from = "ben@contoso.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Using the new SMTP client.";
            message.Body = @"Using this new feature, you can send an e-mail message from an application very easily.";
            SmtpClient client = new SmtpClient("webmail.coxmediagroup.com");
            // Credentials are necessary if the server requires the client 
            // to authenticate before it will send e-mail on the client's behalf.
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", ex.ToString());
            }
        }
    }
}
