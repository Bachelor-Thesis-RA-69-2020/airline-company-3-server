using AirlineCompany3.Model.Dto;
using AirlineCompany3.Resolver.Type;

namespace AirlineCompany3.Resolver.Mutation
{
    public class BookingMutation
    {
        public static void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("BookFlight")
                  .Argument("input", a => a.Type<NonNullType<BookingType>>())
                  .ResolveWith<BookingResolver>(r => r.BookFlight(default, default))
                  .Type<MessageType>();
        }
    }
}
