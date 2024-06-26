using AirlineCompany3.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlineCompany3.Model.Domain
{
    public class Flight : BaseEntity
    {
        [Required(ErrorMessage = "Validation: Code is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Validation: SerialNumber length must be between 1 and 255 characters")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Validation: ScheduledDeparture time is required")]
        public DateTime ScheduledDeparture { get; set; }

        [Required(ErrorMessage = "Validation: ScheduledArrival time is required")]
        public DateTime ScheduledArrival { get; set; }

        [Required(ErrorMessage = "Validation: Duration in minutes is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Validation: Travel time must be greater than 0")]
        public int TravelTime { get; set; }

        [Required(ErrorMessage = "Validation: Luggage rules are required")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Validation: Baggage guidelines length must be between 1 and 500 characters")]
        public string BaggageGuidelines { get; set; }

        [Required(ErrorMessage = "Validation: Children discount is required")]
        [Range(0.0, 100.0, ErrorMessage = "Validation: Kids discount must be between 0 and 100")]
        public float KidsDiscount { get; set; }

        [Required(ErrorMessage = "Validation: Starting Point ID is required")]
        [ForeignKey("StartingPointId")]
        public string StartingPointId { get; set; }

        [Required(ErrorMessage = "Validation: Ending Point ID is required")]
        [ForeignKey("EndingPointId")]
        public string EndingPointId { get; set; }

        [ForeignKey(nameof(StartingPointId))]
        public Airport StartingPoint { get; set; }

        [ForeignKey(nameof(EndingPointId))]
        public Airport EndingPoint { get; set; }
        public List<Ticket> Tickets { get; set; }

        public Flight() : base()
        {
            Tickets = new List<Ticket>();
        }

        public void SetRelation(Airport startingPoint, Airport endingPoint)
        {
            if (startingPoint.Iata == endingPoint.Iata)
            {
                throw new ArgumentException("Starting Point and Ending Point airports must be different.");
            }

            StartingPointId = startingPoint.Id;
            EndingPointId = endingPoint.Id;
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
        }

        public override void Validate()
        {
            base.Validate();

            DateTime now = DateTime.Now;

            if (ScheduledDeparture <= now && ScheduledArrival <= now)
            {
                throw new ArgumentException("Validation: Scheduled Departure and scheduled arrival times must be in the future.");
            }

            if (ScheduledDeparture >= ScheduledArrival)
            {
                throw new ArgumentException("Validation: Scheduled Departure time must be before scheduled arrival time.");
            }
        }

        public void AddTickets(List<Ticket> tickets)
        {
            foreach (var ticket in tickets)
            {
                ticket.Validate();
            }
            Tickets.AddRange(tickets);
        }

        //public void AddDiscount(Discount discount)
        //{
        //    Discounts.Add(discount);
        //}

        //public string BuyTicket(FlightClass flightClass, Booking booking)
        //{
        //    Ticket ticket = Tickets.Find(t => t.Type == flightClass && !t.IsBought);

        //    if (ticket == null)
        //    {
        //        throw new ArgumentException($"No available {flightClass} tickets.");
        //    }

        //    ticket.Buy(booking);

        //    return ticket.Code;
        //}

        //public float GetTicketPriceByClass(FlightClass flightClass)
        //{
        //    Ticket ticket = Tickets.Find(t => t.Type == flightClass);

        //    return ticket?.Price ?? -100;
        //}

        //public int GetTicketCountByClass(FlightClass flightClass)
        //{
        //    return Tickets.Count(t => (flightClass == null || t.Type == flightClass) && !t.IsBought);
        //}

        //public float GetActiveDiscount()
        //{
        //    Discount discount = Discounts.Find(d => d.IsActive);

        //    return discount?.OffValue ?? 0;
        //}
    }
}