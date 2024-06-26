using AirlineCompany3.Model.Dto;
using AirlineCompany3.Service.Interface;

namespace AirlineCompany3.Resolver
{
    public class FlightResolver
    {
        public MessageDto CreateFlight(FlightCreationDto input, [Service(ServiceKind.Synchronized)] IFlightService flightService)
        {
            MessageDto Message = flightService.create(input);

            return Message;
        }
    }
}
