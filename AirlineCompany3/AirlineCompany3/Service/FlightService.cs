using AirlineCompany3.Repository;
using AirlineCompany3.Repository.Interface;
using AirlineCompany3.Service.Interface;
using AutoMapper;

namespace AirlineCompany3.Service
{
    public class FlightService : IFlightService
    {
        private readonly IMapper _mapper;
        private readonly IFlightRepository _flightRepository;

        public FlightService(IMapper mapper, IFlightRepository flightRepository)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
        }
    }
}
