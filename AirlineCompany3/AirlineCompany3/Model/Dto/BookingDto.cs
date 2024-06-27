namespace AirlineCompany3.Model.Dto
{
    public class BookingDto
    {
        public string FlightSerialNumber { get; set; }
        public string FlightClass { get; set; }
        public string Email { get; set; }

        public List<PassengerDto> Passengers { get; set; }
    }
}
