using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Resolver.Type
{
    public class PassengerType : ObjectType<PassengerDto>
    {
        protected override void Configure(IObjectTypeDescriptor<PassengerDto> descriptor)
        {
            descriptor.Field(p => p.Name).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.BirthDate).Type<NonNullType<DateTimeType>>();
            descriptor.Field(p => p.Passport).Type<NonNullType<StringType>>();
        }
    }
}
