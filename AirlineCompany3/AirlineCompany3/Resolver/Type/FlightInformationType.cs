using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Resolver.Type
{
    public class FlightInformationType : ObjectType<FlightInformationDto>
    {
        protected override void Configure(IObjectTypeDescriptor<FlightInformationDto> descriptor)
        {
            descriptor.Field(a => a.SerialNumber).Type<StringType>();
            descriptor.Field(a => a.ScheduledDeparture).Type<DateTimeType>();
            descriptor.Field(a => a.ScheduledArrival).Type<DateTimeType>();
            descriptor.Field(a => a.TravelTime).Type<IntType>();
            descriptor.Field(a => a.BaggageGuidelines).Type<StringType>();
            descriptor.Field(a => a.StartingPointIata).Type<StringType>();
            descriptor.Field(a => a.EndingPointIata).Type<StringType>();
            descriptor.Field(a => a.StartingPointName).Type<StringType>();
            descriptor.Field(a => a.EndingPointName).Type<StringType>();
        }
    }
}
