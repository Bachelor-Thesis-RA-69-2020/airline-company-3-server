using AirlineCompany3.Model.Domain;
using AirlineCompany3.Model;
using AirlineCompany3.Repository;
using AirlineCompany3.Repository.Interface;
using AirlineCompany3.Service.Interface;
using AutoMapper;
using AirlineCompany3.Model.Dto;

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

        public MessageDto create(DiscountCreationDto discountDto)
        {
            try
            {
                Discount discount = _mapper.Map<Discount>(discountDto);

                Flight flight = _flightRepository.Get(filter: f => f.SerialNumber == discountDto.FlightSerialNumber, includedProperties: "Tickets,Discounts", orElseThrow: true);

                flight.AddDiscount(discount);

                _flightRepository.Update(flight);

                return new MessageDto("Discount created.");
            }
            catch (Exception ex)
            {
                return new MessageDto(ex.Message);
            }
        }
    }
}
