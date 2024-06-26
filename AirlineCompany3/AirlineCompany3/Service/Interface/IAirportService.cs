using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Service.Interface
{
    public interface IAirportService
    {
        List<AirportDto> getAll();
        List<AirportDto> search(String filter);
    }
}
