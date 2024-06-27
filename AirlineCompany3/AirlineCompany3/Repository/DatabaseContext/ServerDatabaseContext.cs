using AirlineCompany3.Model.Domain;
using Microsoft.EntityFrameworkCore;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using AirlineCompany3.Model;

namespace AirlineCompany3.Repository.DatabaseContext
{
    public class ServerDatabaseContext : DbContext
    {
        public ServerDatabaseContext(DbContextOptions<ServerDatabaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Flight>()
           .HasOne(f => f.StartingPoint)
           .WithMany()
           .HasForeignKey(f => f.StartingPointId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.EndingPoint)
                .WithMany()
                .HasForeignKey(f => f.EndingPointId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Flight)
                .WithMany(f => f.Tickets)
                .HasForeignKey(t => t.FlightId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Discount>()
                .HasOne(d => d.Flight)
                .WithMany(f => f.Discounts)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Booking)
                .WithOne()
                .HasForeignKey<Ticket>(t => t.BookingId)
                .IsRequired();
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Booking> Booking { get; set; }
    }
}
