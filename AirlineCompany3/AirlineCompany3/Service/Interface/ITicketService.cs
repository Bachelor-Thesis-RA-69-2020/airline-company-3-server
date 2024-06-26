using AirlineCompany3.Model.Domain;

namespace AirlineCompany3.Service.Interface
{
    public interface ITicketService
    {
        List<Ticket> GenerateTickets(FlightService flight, TicketPricing pricing);
    }
}
