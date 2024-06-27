using AirlineCompany3.Resolver.Type;

namespace AirlineCompany3.Resolver.Mutation
{
    public class Mutation : HotChocolate.Types.ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            DiscountMutation.Configure(descriptor);
            FlightMutation.Configure(descriptor);
        }
    }
}
