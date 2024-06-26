using AirlineCompany3.Model.Domain;
using AirlineCompany3.Service;

namespace AirlineCompany3.Repository.Interface
{
    public interface ITicketService
    {
        List<Ticket> GenerateTickets(String flightId, String flightSerialNumber, TicketPricing pricing);
    }
}
