using AirlineCompany3.Model.Dto;
using AirlineCompany3.Service.Interface;

namespace AirlineCompany3.Resolver
{
    public class BookingResolver
    {
        public MessageDto BookFlight(BookingCreationDto input, [Service(ServiceKind.Synchronized)] IBookingService bookingService)
        {
            MessageDto Message = bookingService.Book(input);

            return Message;
        }
    }
}
