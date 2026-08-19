using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ItineraryPlannerApp.Data.Services
{
    public class EmailService
    {
        private readonly string smtpEmail = "leejihye2002@gmail.com";
        private readonly string smtpPassword = "qxdnyodzajridspp";

        public async Task SendResetCodeAsync(string receiverEmail, string resetCode)
        {
            using var message = new MailMessage();

            message.From = new MailAddress(smtpEmail);
            message.To.Add(receiverEmail);

            message.Subject = "[Action Required] Verification Code - Travel Planner";

            message.Body = $"Your verification code is: {resetCode}\n\nPlease enter to reset your password.";

            message.IsBodyHtml = true;

            using var smtp = CreateSmtpClient();

            await smtp.SendMailAsync(message);
        }

        public async Task SendPdfAsync(string receiverEmail, string receiverName, Itinerary itinerary, byte[] pdf)
        {
            string bodyExport = $@"
            <html>
            <body style='font-family:Arial, sans-serif; background-color:#f4f4f4; padding:20px;'>

                <div style='background-color:white; padding:25px; border-radius:10px;'>
                    <h2 style='background-color:#f4c542; font-weight:bold;'> Your Itinerary to {itinerary.City?.CityName} </h2>
                    <h4 style='font-weight:bold;'> Hi {receiverName}, </h4>
                    
                    <p> You can find your travel itinerary as pdf file. It in now ready, kindly find the attached document. </p>
                </div>
            </body>
            ";

            using var message = new MailMessage();

            message.From = new MailAddress(smtpEmail);
            message.To.Add(receiverEmail);

            message.Subject = "[Travel Planner] Your Travel Itinerary";
            message.Body = bodyExport;
            message.IsBodyHtml = true;

            using var pdfStream = new MemoryStream(pdf);

            message.Attachments.Add(new Attachment(pdfStream, "Itinerary.pdf", "application/pdf"));

            using var smtp = CreateSmtpClient();
            await smtp.SendMailAsync(message);
        }

        private SmtpClient CreateSmtpClient()
        {
            return new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(smtpEmail, smtpPassword),
                EnableSsl = true
            };
        }
    }
}
