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
            Database.EnsureCreated();
            Initialize();
        }

        public DbSet<Airport> Airports { get; set; }

        private void Initialize()
        {
            if (!Airports.Any())
            {
                LoadAirportsDataFromCsv();
            }
        }

        private void LoadAirportsDataFromCsv()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string path = "C:/Users/Marko/Documents/GitHub/airline-company-3-server/AirlineCompany3/AirlineCompany3/Resources/Data/airports.csv";
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {

                var records = csv.GetRecords<dynamic>().ToList();

                var airports = new List<Airport>();
                foreach (var record in records)
                {
                    if ("large_airport".Equals(record.type, StringComparison.OrdinalIgnoreCase) && ValidateRow(record))
                    {
                        Airport airport = new Airport
                        {
                            Name = record.name,
                            Iata = record.iata_code.ToLower(),
                            LatitudeDegrees = float.Parse(record.latitude_deg),
                            LongitudeDegrees = float.Parse(record.longitude_deg),
                            ElevationMeters = float.Parse(record.elevation_ft),
                            Continent = record.continent,
                            Country = record.iso_country,
                            Region = record.iso_region,
                            Municipality = record.municipality
                        };
                        airport.Validate();

                        airports.Add(airport);
                    }
                }

                Airports.AddRange(airports);
                SaveChanges();
            }
        }

        private bool ValidateRow(dynamic record)
        {
            return !string.IsNullOrEmpty(record.name)
                && !string.IsNullOrEmpty(record.iata_code)
                && !string.IsNullOrEmpty(record.latitude_deg)
                && !string.IsNullOrEmpty(record.longitude_deg)
                && !string.IsNullOrEmpty(record.elevation_ft)
                && !string.IsNullOrEmpty(record.continent)
                && !string.IsNullOrEmpty(record.iso_country)
                && !string.IsNullOrEmpty(record.iso_region)
                && !string.IsNullOrEmpty(record.municipality);
        }
    }
}
