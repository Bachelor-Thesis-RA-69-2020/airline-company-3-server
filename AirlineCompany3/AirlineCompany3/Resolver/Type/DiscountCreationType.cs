using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Resolver.Type
{
    public class DiscountCreationType : InputObjectType<DiscountCreationDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<DiscountCreationDto> descriptor)
        {
            descriptor.Name("Discount");
            descriptor.Field(f => f.From).Type<NonNullType<DateTimeType>>();
            descriptor.Field(f => f.To).Type<NonNullType<DateTimeType>>();
            descriptor.Field(f => f.DiscountPercentage).Type<NonNullType<FloatType>>();
            descriptor.Field(f => f.FlightSerialNumber).Type<NonNullType<StringType>>();
        }
    }
}
