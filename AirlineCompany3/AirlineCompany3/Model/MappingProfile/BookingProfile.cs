using AirlineCompany3.Model.Domain;
using AirlineCompany3.Model.Dto;
using AutoMapper;

namespace AirlineCompany3.Model.MappingProfile
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            CreateMap<BookingCreationDto, List<Booking>>()
                .ConvertUsing((src, dest, context) =>
                {
                    var bookings = new List<Booking>();
                    foreach (var passenger in src.Passengers)
                    {
                        var booking = new Booking();
                        booking.Name = passenger.Name;
                        booking.BirthDate = passenger.BirthDate;
                        booking.Passport = passenger.Passport;
                        booking.Email = src.Email;

                        bookings.Add(booking);
                    }
                    return bookings;
                });
        }
    }
}
