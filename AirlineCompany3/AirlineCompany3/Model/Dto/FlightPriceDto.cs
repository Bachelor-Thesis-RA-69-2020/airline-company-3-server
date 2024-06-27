namespace AirlineCompany3.Model.Dto
{
    public class FlightPriceDto
    {
        public int EconomyCount { get; set; }
        public float EconomyPrice { get; set; }
        public int BusinessCount { get; set; }
        public float BusinessPrice { get; set; }
        public int FirstCount { get; set; }
        public float FirstPrice { get; set; }
        public float KidsDiscountPercentage { get; set; }
        public float DiscountPercentage { get; set; }

        public FlightPriceDto(int economyCount, float economyPrice, int businessCount, float businessPrice, int firstCount, float firstPrice, float kidsDiscountPercentage, float discountPercentage)
        {
            EconomyCount = economyCount;
            EconomyPrice = economyPrice;
            BusinessCount = businessCount;
            BusinessPrice = businessPrice;
            FirstCount = firstCount;
            FirstPrice = firstPrice;
            KidsDiscountPercentage = kidsDiscountPercentage;
            DiscountPercentage = discountPercentage;
        }
    }
}
