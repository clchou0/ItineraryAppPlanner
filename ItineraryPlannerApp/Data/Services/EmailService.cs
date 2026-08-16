using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ItineraryPlannerApp.Data.Services
{
    public class EmailService
    {
        private readonly string _senderEmail;
        private readonly string _appPassword;

        public EmailService(string senderEmail, string appPassword)
        {
            _senderEmail = senderEmail;
            _appPassword = appPassword;
        }

        public async Task SendResetCodeAsync(string receiverEmail, string resetCode)
        {
            using var message = new MailMessage();

            message.From = new MailAddress(_senderEmail);
            message.To.Add(receiverEmail);

            message.Subject = "[Action Required] Verification Code - Travel Planner";

            message.Body = $"Your verification code is: {resetCode}.\n\nPlease enter to reset your password.";

            using var client = new SmtpClient("smtp.gmail.com", 587);

            client.EnableSsl = true;
            client.UseDefaultCredentials = false;

            client.Credentials = new NetworkCredential(_senderEmail, _appPassword);

            await client.SendMailAsync(message);
        }
    }
}
