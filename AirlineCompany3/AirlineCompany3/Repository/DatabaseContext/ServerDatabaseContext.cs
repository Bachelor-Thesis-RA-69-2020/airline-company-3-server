using AirlineCompany3.Model.Domain;
using Microsoft.EntityFrameworkCore;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

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
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}
