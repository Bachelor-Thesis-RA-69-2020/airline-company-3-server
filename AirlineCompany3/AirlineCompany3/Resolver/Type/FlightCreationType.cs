using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Resolver.Type
{
    public class FlightCreationType : InputObjectType<FlightCreationDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<FlightCreationDto> descriptor)
        {
            descriptor.Name("Flight");
            descriptor.Field(f => f.ScheduledDeparture).Type<NonNullType<DateTimeType>>();
            descriptor.Field(f => f.ScheduledArrival).Type<NonNullType<DateTimeType>>();
            descriptor.Field(f => f.BaggageGuidelines).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.KidsDiscount).Type<NonNullType<FloatType>>();
            descriptor.Field(f => f.StartingPointIata).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.EndingPointIata).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.EconomyCount).Type<NonNullType<IntType>>();
            descriptor.Field(f => f.EconomyPrice).Type<NonNullType<IntType>>();
            descriptor.Field(f => f.BusinessCount).Type<NonNullType<IntType>>();
            descriptor.Field(f => f.BusinessPrice).Type<NonNullType<IntType>>();
            descriptor.Field(f => f.FirstCount).Type<NonNullType<IntType>>();
            descriptor.Field(f => f.FirstPrice).Type<NonNullType<IntType>>();
        }
    }
}
