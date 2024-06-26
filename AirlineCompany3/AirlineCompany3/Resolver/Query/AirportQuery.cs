using AirlineCompany3.Resolver.Type;

namespace AirlineCompany3.Resolver.Query
{
    public class AirportQuery : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("airports")
                  .Argument("filter", a => a.Type<StringType>().DefaultValue(null))
                  .ResolveWith<AirportResolver>(r => r.GetAirports(default, default))
                  .Type<ListType<NonNullType<AirportType>>>();
        }
    }
}
