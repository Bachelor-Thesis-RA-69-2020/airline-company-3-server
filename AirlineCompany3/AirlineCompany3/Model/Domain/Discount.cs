using AirlineCompany3.Model.Domain;
using AirlineCompany3.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompany3.Model
{
    public class Discount : BaseEntity
    {
        [Required(ErrorMessage = "Validation: From must be a future date or present")]
        public DateTime From { get; set; }

        [Required(ErrorMessage = "Validation: To must be a future date")]
        public DateTime To { get; set; }

        [Required(ErrorMessage = "Validation: Discount value is required")]
        [Range(0.0, 100.0, ErrorMessage = "Validation: Discount value must be between 0.0 and 100.0")]
        public float DiscountPercentage { get; set; }

        [Required(ErrorMessage = "Validation: Flight ID is required")]
        public string FlightId { get; set; }

        [ForeignKey(nameof(FlightId))]
        public Flight Flight { get; set; }

        public Discount() : base()
        {
        }

        public override void Validate()
        {
            base.Validate();

            DateTime now = DateTime.Now;

            if (From <= now && To <= now)
            {
                throw new ArgumentException("Validation: From and To times must be in the future.");
            }

            if (From > To)
            {
                throw new ArgumentException("Validation: From time must be before To time.");
            }
        }

        public bool IsActive()
        {
            DateTime currentDate = DateTime.Now;
            return From < currentDate && To > currentDate;
        }
    }
}
