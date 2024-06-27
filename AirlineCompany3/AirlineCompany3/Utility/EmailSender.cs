using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AirlineCompany3.Utility
{
    public class EmailSender
    {
        private readonly SmtpClient _smtpClient;
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;

            _smtpClient = new SmtpClient
            {
                Host = _configuration["Smtp:Host"],
                Port = int.Parse(_configuration["Smtp:Port"]),
                Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"]),
                EnableSsl = true,
                Timeout = 100000
            };
        }

        public async Task SendTicketsEmailAsync(string to, byte[] pdf)
        {
            string title = "Ticket purchase confirmation";
            string htmlContent = "";

            string templatesPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Templates");
            string imagesPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Images");

            string templateFilePath = System.IO.Path.Combine(templatesPath, "bookingEmailTemplate.html");
            try
            {
                htmlContent = ReadHtmlTemplate(templateFilePath);
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine($"Error reading file: {ex.Message}");
                Console.Error.WriteLine($"Stack trace: {ex.StackTrace}");
            }

            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.To.Add(to);
                mailMessage.Subject = title;
                mailMessage.From = new MailAddress(_configuration["Smtp:Username"], "Zenith Airlines");
                mailMessage.IsBodyHtml = true;

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(htmlContent, null, "text/html");

                string logoPath = System.IO.Path.Combine(imagesPath, "logo.png");
                LinkedResource logo = new LinkedResource(logoPath, "image/png");
                logo.ContentId = "logo.png";
                htmlView.LinkedResources.Add(logo);

                Attachment pdfAttachment = new Attachment(new MemoryStream(pdf), "tickets.pdf", "application/pdf");
                mailMessage.Attachments.Add(pdfAttachment);

                mailMessage.AlternateViews.Add(htmlView);

                try
                {
                    _smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error sending email: {ex.Message}");
                    Console.Error.WriteLine($"Stack trace: {ex.StackTrace}");
                }
            }
        }

        private string ReadHtmlTemplate(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
