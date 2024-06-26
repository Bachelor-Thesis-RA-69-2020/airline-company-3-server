using AirlineCompany3.Model.Domain;
using AirlineCompany3.Model.Dto;
using AirlineCompany3.Repository.Interface;
using AirlineCompany3.Service.Interface;
using AutoMapper;
using System.Linq.Expressions;

namespace AirlineCompany3.Service
{
    public class AirportService : IAirportService
    {
        private readonly IMapper _mapper;
        private readonly IAirportRepository _airportRepository;

        public AirportService(IMapper mapper, IAirportRepository airportRepository) {
            _mapper = mapper;
            _airportRepository = airportRepository;
        }

        public List<AirportDto> getAll()
        {
            List<Airport> airports = _airportRepository.GetAll();

            List<AirportDto> airportDtos = _mapper.Map<List<AirportDto>>(airports);

            return airportDtos;
        }
        public List<AirportDto> search(String filter)
        {
            Expression<Func<Airport, bool>> searchFilter = a => a.Name.ToLower().Contains(filter.ToLower()) || a.Iata.ToLower().Contains(filter.ToLower());
            List<Airport> airports = _airportRepository.GetAll(filter: searchFilter);

            List<AirportDto> airportDtos = _mapper.Map<List<AirportDto>>(airports);

            return airportDtos;
        }
    }
}
