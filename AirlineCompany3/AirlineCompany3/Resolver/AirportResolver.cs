using AirlineCompany3.Model.Dto;
using AirlineCompany3.Service.Interface;

namespace AirlineCompany3.Resolver
{
    public class AirportResolver
    {

        public List<AirportDto> GetAirports(string? filter, [Service(ServiceKind.Synchronized)] IAirportService airportService)
        {
            List<AirportDto> airports = airportService.getAll();

            if (string.IsNullOrEmpty(filter))
            {
                airports = airportService.getAll();
            }
            else
            {
                airports = airportService.search(filter);
            }

            return airports;
        }
    }
}
