using AirlineCompany3.Model.Domain;
using AirlineCompany3.Repository;
using AirlineCompany3.Repository.Interface;
using AirlineCompany3.Service.Interface;
using AirlineCompany3.Utility;
using AutoMapper;

namespace AirlineCompany3.Service
{
    public class TicketService : ITicketService
    {
        public List<Ticket> GenerateTickets(string flightId, string flightSerialNumber, TicketPricing pricing)
        {
            var economyClassTickets = GenerateClassTickets(flightId, flightSerialNumber, FlightClass.Economy, pricing.EconomyPrice, pricing.EconomyCount);
            var businessClassTickets = GenerateClassTickets(flightId, flightSerialNumber, FlightClass.Business, pricing.BusinessPrice, pricing.BusinessCount);
            var firstClassTickets = GenerateClassTickets(flightId, flightSerialNumber, FlightClass.First, pricing.FirstPrice, pricing.FirstCount);

            var allTickets = new List<Ticket>();
            allTickets.AddRange(economyClassTickets);
            allTickets.AddRange(businessClassTickets);
            allTickets.AddRange(firstClassTickets);

            return allTickets;
        }

        private List<Ticket> GenerateClassTickets(string flightId, string flightCode, FlightClass flightClass, float price, int count)
        {
            var tickets = new List<Ticket>();

            for (int i = 1; i <= count; i++)
            {
                string code = GenerateTicketCode(flightCode, flightClass, i);
                var ticket = new Ticket(code, price, flightClass);
                ticket.FlightId = flightId;
                ticket.Validate();
                tickets.Add(ticket);
            }

            return tickets;
        }

        private string GenerateTicketCode(string flightCode, FlightClass flightClass, int serialNumber)
        {
            string id = $"{flightCode}{flightClass.ToString()}{serialNumber}";

            string hash = Hasher.Hash(id);

            string flightClassLabel = flightClass switch
            {
                FlightClass.Economy => "Economy-",
                FlightClass.Business => "Business-",
                FlightClass.First => "First-",
                _ => throw new ArgumentException("Unknown flight class")
            };

            string code = $"AL3-{flightClassLabel}{hash.Substring(0, 10).ToUpper()}";

            return code;
        }
    }
}
