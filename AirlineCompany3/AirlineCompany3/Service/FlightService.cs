using AirlineCompany3.Model.Domain;
using AirlineCompany3.Model.Dto;
using AirlineCompany3.Repository;
using AirlineCompany3.Repository.Interface;
using AirlineCompany3.Service.Interface;
using AirlineCompany3.Utility;
using AutoMapper;

namespace AirlineCompany3.Service
{
    public class FlightService : IFlightService
    {
        private readonly IMapper _mapper;
        private readonly IFlightRepository _flightRepository;
        private readonly IAirportRepository _airportRepository;
        private readonly ITicketService _ticketService;

        public FlightService(IMapper mapper, IFlightRepository flightRepository, IAirportRepository airportRepository, ITicketService ticketService)
        {
            _mapper = mapper;
            _flightRepository = flightRepository;
            _airportRepository = airportRepository;
            _ticketService = ticketService;
        }

        public MessageDto create(FlightCreationDto flightDto)
        {
            try
            {
                Flight flight = _mapper.Map<Flight>(flightDto);

                Airport startingPoint = _airportRepository.Get(filter: a => a.Iata == flightDto.StartingPointIata, orElseThrow: true);
                Airport endingPoint = _airportRepository.Get(filter: a => a.Iata == flightDto.EndingPointIata, orElseThrow: true);
                flight.SetRelation(startingPoint, endingPoint);

                flight.SerialNumber = GenerateSerialNumber(flight);

                TicketPricing pricing = _mapper.Map<TicketPricing>(flightDto);
                List<Ticket> tickets = _ticketService.GenerateTickets(flight.Id, flight.SerialNumber, pricing);
                flight.AddTickets(tickets);

                flight.Validate();
                _flightRepository.Create(flight);

                return new MessageDto("Flight created.");
            }
            catch (Exception ex)
            {
                return new MessageDto(ex.Message);
            }
        }

        private String GenerateSerialNumber(Flight flight)
        {
            String id = flight.ScheduledDeparture.ToString() +
                flight.ScheduledArrival.ToString() +
                flight.StartingPoint.Iata +
                flight.EndingPoint.Iata;

            String hash = Hasher.Hash(id);

            String serialNumber = "AL3-" + hash.Substring(0, 10).ToUpper();

            return serialNumber;
        }
    }
}
