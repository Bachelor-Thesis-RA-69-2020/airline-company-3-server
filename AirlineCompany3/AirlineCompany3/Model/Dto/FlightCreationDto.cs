namespace AirlineCompany3.Model.Dto
{
    public class FlightCreationDto
    {
        public DateTime ScheduledDeparture { get; set; }
        public DateTime ScheduledArrival { get; set; }
        public string BaggageGuidelines { get; set; }
        public float KidsDiscount { get; set; }
        public string StartingPointIata{ get; set; }
        public string EndingPointIata { get; set; }
        public int EconomyCount { get; set; }
        public int EconomyPrice { get; set; }
        public int BusinessCount { get; set; }
        public int BusinessPrice { get; set; }
        public int FirstCount { get; set; }
        public int FirstPrice { get; set; }
    }
}
