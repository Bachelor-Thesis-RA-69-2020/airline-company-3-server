namespace AirlineCompany3.Model.Dto
{
    public class FlightInformationDto
    {
        public string SerialNumber { get; set; }
        public DateTime ScheduledDeparture { get; set; }
        public DateTime ScheduledArrival { get; set; }
        public int TravelTime { get; set; }
        public string BaggageGuidelines { get; set; }
        public string StartingPointIata { get; set; }
        public string EndingPointIata { get; set; }
        public string StartingPointName { get; set; }
        public string EndingPointName { get; set; }

        public FlightInformationDto(string serialNumber, DateTime scheduledDeparture, DateTime scheduledArrival, int travelTime, string baggageGuidelines, string startingPointIata, string endingPointIata, string startingPointName, string endingPointName)
        {
            SerialNumber = serialNumber;
            ScheduledDeparture = scheduledDeparture;
            ScheduledArrival = scheduledArrival;
            TravelTime = travelTime;
            BaggageGuidelines = baggageGuidelines;
            StartingPointIata = startingPointIata;
            EndingPointIata = endingPointIata;
            StartingPointName = startingPointName;
            EndingPointName = endingPointName;
        }
    }
}
