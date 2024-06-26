namespace AirlineCompany3.Model.Domain
{
    public class TicketPricing
    {
        public int EconomyCount { get; set; }
        public float EconomyPrice { get; set; }
        public int BusinessCount { get; set; }
        public float BusinessPrice { get; set; }
        public int FirstCount { get; set; }
        public float FirstPrice { get; set; }

        public TicketPricing()
        {

        }
    }
}
