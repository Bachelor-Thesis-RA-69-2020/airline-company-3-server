using AirlineCompany3.Resolver.Type;

namespace AirlineCompany3.Resolver.Mutation
{
    public class FlightMutation
    {
        public static void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("CreateFlight")
                  .Argument("input", a => a.Type<NonNullType<FlightCreationType>>())
                  .ResolveWith<FlightResolver>(r => r.CreateFlight(default, default))
                  .Type<MessageType>();
        }
    }
}
