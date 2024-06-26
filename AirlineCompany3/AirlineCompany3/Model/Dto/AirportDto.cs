namespace AirlineCompany3.Model.Dto
{
    public class AirportDto
    {
        public string Name { get; set; }
        public string Iata { get; set; }
        public float LatitudeDegrees { get; set; }
        public float LongitudeDegrees { get; set; }
        public float ElevationMeters { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Municipality { get; set; }
    }
}
