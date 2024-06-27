using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using System.Globalization;
using AirlineCompany3.Utility;
using AirlineCompany3.Models.Domain;
using AirlineCompany3.Model.Domain;
using iText.Kernel.Exceptions;

namespace AirlineCompany3.Utility
{
    public class PdfGenerator
    {
        public byte[] GenerateTicketsPDF(Flight flight, string flightClass, List<Booking> bookings, List<string> ticketCodes)
        {
            string templatesPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Resources", "Templates", "ticketPDFTemplate.html");
            Console.WriteLine("\n\n\n" + templatesPath + "\n\n\n");

            HtmlTemplate htmlTemplate = new HtmlTemplate(templatesPath);

            string dateFormat = "dd.MM.yyyy. HH:mm";

            string formattedDepartureTime = flight.ScheduledDeparture.ToString(dateFormat);
            string formattedArrivalTime = flight.ScheduledArrival.ToString(dateFormat);

            htmlTemplate.SetBaseValue("originIATA", flight.StartingPoint.Iata.ToUpper());
            htmlTemplate.SetBaseValue("destinationIATA", flight.EndingPoint.Iata.ToUpper());
            htmlTemplate.SetBaseValue("origin", flight.StartingPoint.Name);
            htmlTemplate.SetBaseValue("destination", flight.EndingPoint.Name);
            htmlTemplate.SetBaseValue("departure", formattedDepartureTime);
            htmlTemplate.SetBaseValue("arrival", formattedArrivalTime);
            htmlTemplate.SetBaseValue("flightNumber", flight.SerialNumber);
            htmlTemplate.SetBaseValue("flightClass", flightClass);

            try
            {
                using (MemoryStream baos = new MemoryStream())
                {
                    baos.Position = 0;
                    using (PdfWriter writer = new PdfWriter(baos))
                    {
                        using (PdfDocument pdfDoc = new PdfDocument(writer))
                        {
                            PdfMerger merger = new PdfMerger(pdfDoc);

                            for (int i = 0; i < bookings.Count; i++)
                            {
                                htmlTemplate.Reset();

                                string ticketCode = ticketCodes[i];
                                Booking booking = bookings[i];

                                dateFormat = "dd.MM.yyyy.";
                                string formattedBirthDate = booking.BirthDate.ToString(dateFormat);

                                htmlTemplate.SetValue("ticketCode", ticketCode);
                                htmlTemplate.SetValue("name", booking.Name);
                                htmlTemplate.SetValue("dateOfBirth", formattedBirthDate);
                                htmlTemplate.SetValue("passportNumber", booking.Passport);

                                string htmlContent = htmlTemplate.GetHtml();

                                using (MemoryStream tempBaos = new MemoryStream())
                                {
                                    HtmlConverter.ConvertToPdf(htmlContent, tempBaos);

                                    using (PdfDocument tempDoc = new PdfDocument(new PdfReader(new MemoryStream(tempBaos.ToArray()))))
                                    {
                                        merger.Merge(tempDoc, 1, tempDoc.GetNumberOfPages());
                                    }
                                }
                            }
                        }

                        return baos.ToArray();
                    }
                }
            }
            catch (PdfException ex)
            {
                Console.Error.WriteLine($"PDF generation error: {ex.Message}");
                Console.Error.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error: {ex.Message}");
                Console.Error.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;
            }
        }
    }
}
