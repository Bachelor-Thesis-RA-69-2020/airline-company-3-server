using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Resolver.Type
{
    public class FlightSearchType : InputObjectType<FlightSearchDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<FlightSearchDto> descriptor)
        {
            descriptor.Field(a => a.SerialNumber).Type<StringType>();
            descriptor.Field(a => a.From).Type<DateTimeType>();
            descriptor.Field(a => a.To).Type<DateTimeType>();
            descriptor.Field(a => a.StartingPointIata).Type<StringType>();
            descriptor.Field(a => a.EndingPointIata).Type<StringType>();
            descriptor.Field(a => a.FlightClass).Type<StringType>();
            descriptor.Field(a => a.PassengerCount).Type<IntType>();
        }
    }
}
