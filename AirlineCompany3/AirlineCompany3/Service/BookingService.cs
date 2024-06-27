using AirlineCompany3.Repository.Interface;
using AutoMapper;

namespace AirlineCompany3.Service
{
    public class BookingService
    {
        private readonly IMapper _mapper;
        private readonly IFlightRepository _flightRepository;

        public BookingService(IMapper mapper, IFlightRepository flightRepository)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
        }
    }
}
