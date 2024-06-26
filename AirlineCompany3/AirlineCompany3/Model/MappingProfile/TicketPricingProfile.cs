using AirlineCompany3.Model.Domain;
using AirlineCompany3.Model.Dto;
using AutoMapper;

namespace AirlineCompany3.Model.MappingProfile
{
    public class TicketPricingProfile : Profile
    {
        public TicketPricingProfile()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            CreateMap<FlightCreationDto, TicketPricing>();
        }
    }
}
