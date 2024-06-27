using AirlineCompany3.Model.Domain;
using AirlineCompany3.Model.Dto;
using AutoMapper;

namespace AirlineCompany3.Model.MappingProfile
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            CreateMap<FlightCreationDto, Flight>()
                .ForMember(dest => dest.TravelTime, opt => opt.MapFrom(src => (int)(src.ScheduledArrival - src.ScheduledDeparture).TotalMinutes));

            CreateMap<Flight, FlightDto>()
                .ForMember(dest => dest.FlightInformation, opt => opt.MapFrom(src => new FlightInformationDto(
                    src.SerialNumber,
                    src.ScheduledDeparture,
                    src.ScheduledArrival,
                    src.TravelTime,
                    src.BaggageGuidelines,
                    src.StartingPoint.Iata,
                    src.EndingPoint.Iata,
                    src.StartingPoint.Name,
                    src.EndingPoint.Name)))
                .ForMember(dest => dest.FlightPrice, opt => opt.MapFrom(src => new FlightPriceDto(
                    src.GetTicketCountByClass(FlightClass.Economy),
                    src.GetTicketPriceByClass(FlightClass.Economy),
                    src.GetTicketCountByClass(FlightClass.Business),
                    src.GetTicketPriceByClass(FlightClass.Business),
                    src.GetTicketCountByClass(FlightClass.First),
                    src.GetTicketPriceByClass(FlightClass.First),
                    src.KidsDiscount,
                    src.GetActiveDiscount())));
        }
    }
}
