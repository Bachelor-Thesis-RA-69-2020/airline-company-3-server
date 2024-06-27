using AirlineCompany3.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace AirlineCompany3.Model.Domain
{
    public class Booking : BaseEntity
    {
        [Required(ErrorMessage = "Validation: Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Validation: Email name is required")]
        [EmailAddress(ErrorMessage = "Validation: Email should be valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Validation: Birth date is required")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Validation: Passport is required")]
        public string Passport { get; set; }

        public Booking() : base()
        {
        }

        public override void Validate()
        {
            base.Validate();

            if (BirthDate > DateTime.Now)
            {
                throw new ArgumentException("Validation: Birth date must be in the past.");
            }
        }
    }
}
