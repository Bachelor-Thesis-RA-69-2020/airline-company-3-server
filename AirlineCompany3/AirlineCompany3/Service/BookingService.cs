using AirlineCompany3.Model.Domain;
using AirlineCompany3.Model.Dto;
using AirlineCompany3.Repository;
using AirlineCompany3.Repository.Interface;
using AirlineCompany3.Service.Interface;
using AirlineCompany3.Utility;
using AutoMapper;
using System.Collections.Generic;

namespace AirlineCompany3.Service
{
    public class BookingService : IBookingService
    {
        private readonly IMapper _mapper;
        private readonly EmailSender _emailSender;
        private readonly IFlightRepository _flightRepository;

        public BookingService(IMapper mapper, EmailSender emailSender, IFlightRepository flightRepository)
        {
            _mapper = mapper;
            _emailSender = emailSender;
            _flightRepository = flightRepository;
        }

        public MessageDto Book(BookingCreationDto bookingDto)
        {
            try
            {
                List<Booking> bookings = _mapper.Map<List<Booking>>(bookingDto);

                Flight flight = _flightRepository.Get(f => f.SerialNumber == bookingDto.FlightSerialNumber, includedProperties: "StartingPoint,EndingPoint,Tickets,Discounts", orElseThrow: true);

                FlightClass flightClass = ValidateClass(bookingDto.FlightClass);

                List<String> ticketCodes = new List<String>();
                foreach (Booking booking in bookings)
                {
                    String ticketCode = BookOne(flight, flightClass, booking);
                    ticketCodes.Add(ticketCode);
                }

                _flightRepository.Update(flight);
                PdfGenerator pdfGenerator = new PdfGenerator();
                byte[] pdf = pdfGenerator.GenerateTicketsPDF(flight, bookingDto.FlightClass, bookings, ticketCodes);

                _emailSender.SendTicketsEmailAsync(bookingDto.Email, pdf);

                return new MessageDto("Booking created.");
            }
            catch (Exception ex)
            {
                return new MessageDto(ex.Message);
            }
        }

        private String BookOne(Flight flight, FlightClass flightClass, Booking booking)
        {
            booking.Validate();

            String ticketCode = flight.BuyTicket(flightClass, booking);

            return ticketCode;
        }

        private FlightClass ValidateClass(String flightClass)
        {
            List<string> validFlightClasses = new List<string>(["Economy", "Business", "First"]);
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

            return flightClassFilter;
        }
    }
}
