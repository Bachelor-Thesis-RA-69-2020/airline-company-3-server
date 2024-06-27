using AirlineCompany3.Model.Domain;
using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Service.Interface
{
    public interface IBookingService
    {
        MessageDto Book(BookingCreationDto bookingDto);
    }
}
