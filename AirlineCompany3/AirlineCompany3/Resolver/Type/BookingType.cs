using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Resolver.Type
{
    public class BookingType : InputObjectType<BookingCreationDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<BookingCreationDto> descriptor)
        {
            descriptor.Name("Booking");
            descriptor.Field(f => f.FlightSerialNumber).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.FlightClass).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.Email).Type<NonNullType<StringType>>();
            descriptor.Field(f => f.Passengers).Type<NonNullType<ListType<PassengerType>>>();
        }
    }
}
