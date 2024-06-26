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
        }
    }
}
