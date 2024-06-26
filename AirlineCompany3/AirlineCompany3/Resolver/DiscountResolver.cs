using AirlineCompany3.Model.Dto;
using AirlineCompany3.Service.Interface;

namespace AirlineCompany3.Resolver
{
    public class DiscountResolver
    {
        public MessageDto CreateDiscount(DiscountCreationDto input, [Service(ServiceKind.Synchronized)] IDiscountService discountService)
        {
            MessageDto Message = discountService.create(input);

            return Message;
        }
    }
}
