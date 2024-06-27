using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Resolver.Type
{
    public class FlightType : ObjectType<FlightDto>
    {
        protected override void Configure(IObjectTypeDescriptor<FlightDto> descriptor)
        {
            descriptor.Field(f => f.FlightInformation).Type<FlightInformationType>();
            descriptor.Field(a => a.FlightPrice).Type<FlightPriceType>();
        }
    }
}
