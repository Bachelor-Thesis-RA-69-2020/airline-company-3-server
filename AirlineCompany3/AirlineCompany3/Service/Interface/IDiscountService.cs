using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Service.Interface
{
    public interface IDiscountService
    {
        MessageDto create(DiscountCreationDto discountDto);
    }
}
