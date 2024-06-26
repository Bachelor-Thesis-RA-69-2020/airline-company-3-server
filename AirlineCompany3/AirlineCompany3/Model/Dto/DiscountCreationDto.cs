using AirlineCompany3.Model.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlineCompany3.Model.Dto
{
    public class DiscountCreationDto
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public float DiscountPercentage { get; set; }
        public string FlightSerialNumber { get; set; }
    }
}
