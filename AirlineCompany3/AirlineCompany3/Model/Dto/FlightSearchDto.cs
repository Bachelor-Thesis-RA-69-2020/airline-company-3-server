using AirlineCompany3.Model.Domain;

namespace AirlineCompany3.Model.Dto
{
    public class FlightSearchDto
    {
        public string SerialNumber { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string StartingPointIata { get; set; }
        public string EndingPointIata { get; set; }
        public string FlightClass { get; set; }
        public int PassengerCount { get; set; }
    }
}
