using AirlineCompany3.Model.Domain;
using AirlineCompany3.Model.Dto;
using AirlineCompany3.Repository;
using AirlineCompany3.Repository.Interface;
using AirlineCompany3.Service.Interface;
using AirlineCompany3.Utility;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;

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

        public MessageDto Create(FlightCreationDto flightDto)
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

        public List<FlightDto> Search(FlightSearchDto searchFilter)
        {
            List<Flight> flights = _flightRepository.GetAll(includedProperties: "StartingPoint,EndingPoint,Tickets,Discounts");

            if (flights.IsNullOrEmpty())
            {
                return new List<FlightDto>();
            }

            if(searchFilter != null)
            {
                flights = SearchBySerialNumber(flights, searchFilter.SerialNumber);
                flights = SearchByDateRange(flights, searchFilter.From, searchFilter.To);
                flights = SearchByRelation(flights, searchFilter.StartingPointIata, searchFilter.EndingPointIata);
                flights = SearchByPassengerInformation(flights, searchFilter.FlightClass, searchFilter.PassengerCount);
            }

            List<FlightDto> flightDtos = _mapper.Map<List<FlightDto>>(flights);

            return flightDtos;
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

        private List<Flight> SearchBySerialNumber(List<Flight> flights, string serialNumber)
        {
            if (serialNumber != null)
            {
                flights = flights.Where(f => f.SerialNumber == serialNumber).ToList();
            }

            return flights;
        }

        private List<Flight> SearchByDateRange(List<Flight> flights, DateTime from, DateTime to)
        {
            if (from != null && to != null && from.CompareTo(to) > 0)
            {
                throw new ArgumentException("Validation: From date must be before To date.");
            }

            flights = SearchByFrom(flights, from);
            flights = SearchByTo(flights, to);

            return flights;
        }

        private List<Flight> SearchByRelation(List<Flight> flights, String startingPoint, String endingPoint)
        {
            if (!startingPoint.IsNullOrEmpty() && !endingPoint.IsNullOrEmpty() && startingPoint == endingPoint)
            {
                throw new ArgumentException("Validation: startingPoint and endingPoint cannot be the same.");
            }

            if (!startingPoint.IsNullOrEmpty())
            {
                _airportRepository.Get(a => a.Iata == startingPoint, orElseThrow: true);
            }

            if (!endingPoint.IsNullOrEmpty())
            {
                _airportRepository.Get(a => a.Iata == endingPoint, orElseThrow: true);
            }

            flights = SearchByStartingPoint(flights, startingPoint);
            flights = SearchByArrivalAirport(flights, endingPoint);
            return flights;
        }

        private List<Flight> SearchByPassengerInformation(List<Flight> flights, String flightClass, int passengerCount)
        {
            if (passengerCount == null || passengerCount == 0)
            {
                passengerCount = 1;
            }

            if (passengerCount < 1)
            {
                throw new ArgumentException("Validation: Passenger count must be 1 or more.");
            }

            List<String> validFlightClasses = new List<string>();
            validFlightClasses.AddRange(["Economy", "Business", "First"]);
            if (flightClass != null && !validFlightClasses.Contains(flightClass))
            {
                throw new ArgumentException("Validation: Invalid flight class. Must be one of: Economy, Business, First.");
            }

            FlightClass flightClassFilter = Model.Domain.FlightClass.Economy;

            if (flightClass != null && flightClass == "Economy")
            {
                flightClassFilter = Model.Domain.FlightClass.Economy;
            }
            else if (flightClass != null && flightClass == "Business")
            {
                flightClassFilter = Model.Domain.FlightClass.Business;
            }
            else if (flightClass != null && flightClass == "First")
            {
                flightClassFilter = Model.Domain.FlightClass.First;
            }

            flights = flights.Where(f => f.GetTicketCountByClass(flightClassFilter) >= passengerCount).ToList();
            return flights;
        }

        private List<Flight> SearchByFrom(List<Flight> flights, DateTime from)
        {
            if (from != null && from != DateTime.MinValue)
            {
                flights = flights.Where(f => f.ScheduledDeparture.CompareTo(from) > 0).ToList();
            }
            return flights;
        }

        private List<Flight> SearchByTo(List<Flight> flights, DateTime to)
        {
            if (to != null && to != DateTime.MinValue) 
            { 
                flights = flights.Where(f => f.ScheduledDeparture.CompareTo(to) < 0).ToList();
            }
            return flights;
        }

        private List<Flight> SearchByStartingPoint(List<Flight> flights, String startingPoint)
        {
            if (!startingPoint.IsNullOrEmpty())
            {

                flights = flights.Where(f => f.StartingPoint.Iata == startingPoint).ToList();
            }
            return flights;
        }

        private List<Flight> SearchByArrivalAirport(List<Flight> flights, String endingPoint)
        {
            if (!endingPoint.IsNullOrEmpty())
            {

                flights = flights.Where(f => f.EndingPoint.Iata == endingPoint).ToList();
            }
            return flights;
        }
    }
}
