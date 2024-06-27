using AirlineCompany3.Resolver.Type;

namespace AirlineCompany3.Resolver.Query
{
    public class FlightQuery
    {
        public static void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("GetFlights")
                  .Argument("filter", a => a.Type<FlightSearchType>().DefaultValue(null))
                  .ResolveWith<FlightResolver>(r => r.GetFlights(default, default))
                  .Type<ListType<NonNullType<AirportType>>>();
        }
    }
}
