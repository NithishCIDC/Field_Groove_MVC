using Field_Groove.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Field_Groove.Application.Services
{
    public class EmailSender : IEmailSender
    {
        public Task EmailSendAsync(string email, string subject, string message)
        {
            string mail = "2k20cse055@kiot.ac.in";
            string password = "2k20cse055";

            var client = new SmtpClient("smtp.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, password)
            };

            return client.SendMailAsync(new MailMessage(from: mail,to: email,subject,message));
        }
    }
}
