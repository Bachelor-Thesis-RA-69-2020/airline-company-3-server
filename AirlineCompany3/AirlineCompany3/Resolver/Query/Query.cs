using AirlineCompany3.Resolver.Mutation;
using AirlineCompany3.Resolver.Type;

namespace AirlineCompany3.Resolver.Query
{
    public class Query : HotChocolate.Types.ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            AirportQuery.Configure(descriptor);
        }
    }
}
