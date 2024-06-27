using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Service.Interface
{
    public interface IFlightService
    {
        MessageDto Create(FlightCreationDto flightDto);
        List<FlightDto> Search(FlightSearchDto searchFilter);
    }
}
