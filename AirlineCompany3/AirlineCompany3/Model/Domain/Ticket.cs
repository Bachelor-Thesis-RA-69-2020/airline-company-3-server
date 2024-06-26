using AirlineCompany3.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace AirlineCompany3.Model.Domain
{
    public class Ticket : BaseEntity
    {
        [Required(ErrorMessage = "Validation: Ticket code is required")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Validation: Ticket price is required")]
        [Range(0, float.MaxValue, ErrorMessage = "Validation: Ticket price must be greater than or equal to 0")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Validation: Ticket type is required")]
        public FlightClass Type { get; set; }

        public bool IsBought { get; set; }

        //public Booking Booking { get; set; }

        public Ticket() : base() 
        {
        }

        public Ticket(string code, float price, FlightClass type) : base()
        {
            Code = code;
            Price = price;
            Type = type;
            IsBought = false;
        }
        

        //public void Buy(Booking booking)
        //{
        //    IsBought = true;
        //    Booking = booking;
        //}
    }

    public enum FlightClass
    {
        Economy,
        Business,
        First
    }
}
