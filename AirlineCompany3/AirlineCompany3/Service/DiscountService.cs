using AirlineCompany3.Repository.Interface;
using AirlineCompany3.Service.Interface;
using AutoMapper;

namespace AirlineCompany3.Service
{
    public class DiscountService : IDiscountService
    {
        private readonly IMapper _mapper;
        private readonly IFlightRepository _flightRepository;

        public DiscountService(IMapper mapper, IFlightRepository flightRepository)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
        }
    }
}
