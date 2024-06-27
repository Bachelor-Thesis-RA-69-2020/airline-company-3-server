using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Resolver.Type
{
    public class FlightPriceType : ObjectType<FlightPriceDto>
    {
        protected override void Configure(IObjectTypeDescriptor<FlightPriceDto> descriptor)
        {
            descriptor.Field(a => a.EconomyCount).Type<IntType>();
            descriptor.Field(a => a.EconomyPrice).Type<FloatType>();
            descriptor.Field(a => a.BusinessCount).Type<IntType>();
            descriptor.Field(a => a.BusinessPrice).Type<FloatType>();
            descriptor.Field(a => a.FirstCount).Type<IntType>();
            descriptor.Field(a => a.FirstPrice).Type<FloatType>();
            descriptor.Field(a => a.KidsDiscountPercentage).Type<FloatType>();
            descriptor.Field(a => a.DiscountPercentage).Type<FloatType>();
        }
    }
}
