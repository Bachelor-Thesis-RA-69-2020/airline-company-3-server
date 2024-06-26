using AirlineCompany3.Model.Domain;
using AirlineCompany3.Model.Dto;
using AutoMapper;

namespace AirlineCompany3.Model.MappingProfile
{
    public class AirportProfile : Profile
    {
        public AirportProfile()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            CreateMap<Airport, AirportDto>();
        }
    }
}
