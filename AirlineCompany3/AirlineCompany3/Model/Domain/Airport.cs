using AirlineCompany3.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace AirlineCompany3.Model.Domain
{
    public class Airport : BaseEntity
    {
        [Required(ErrorMessage = "Validation: Airport name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Validation: IATA code is required")]
        public string Iata { get; set; }

        [Required(ErrorMessage = "Validation: Latitude is required")]
        [Range(-90, 90, ErrorMessage = "Validation: Latitude must be between -90 and 90")]
        public float LatitudeDegrees { get; set; }

        [Required(ErrorMessage = "Validation: Longitude is required")]
        [Range(-180, 180, ErrorMessage = "Validation: Longitude must be between -180 and 180")]
        public float LongitudeDegrees { get; set; }

        [Required(ErrorMessage = "Validation: Elevation is required")]
        public float ElevationMeters { get; set; }

        [Required(ErrorMessage = "Validation: Continent is required")]
        public string Continent { get; set; }

        [Required(ErrorMessage = "Validation: Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Validation: Region is required")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Validation: Municipality is required")]
        public string Municipality { get; set; }

        public Airport() : base()
        {
        }

        public Airport(string name, string iata, float latitudeDegrees, float longitudeDegrees, float elevationMeters, string continent, string country, string region, string municipality)
        {
            Name = name;
            Iata = iata;
            LatitudeDegrees = latitudeDegrees;
            LongitudeDegrees = longitudeDegrees;
            ElevationMeters = elevationMeters;
            Continent = continent;
            Country = country;
            Region = region;
            Municipality = municipality;
        }
    }
}
