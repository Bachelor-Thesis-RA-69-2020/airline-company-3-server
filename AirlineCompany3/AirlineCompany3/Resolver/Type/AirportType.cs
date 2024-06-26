using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Resolver.Type
{
    public class AirportType : ObjectType<AirportDto>
    {
        protected override void Configure(IObjectTypeDescriptor<AirportDto> descriptor)
        {
            descriptor.Field(a => a.Name).Type<StringType>();
            descriptor.Field(a => a.Iata).Type<StringType>();
            descriptor.Field(a => a.LatitudeDegrees).Type<FloatType>();
            descriptor.Field(a => a.LongitudeDegrees).Type<FloatType>();
            descriptor.Field(a => a.ElevationMeters).Type<FloatType>();
            descriptor.Field(a => a.Continent).Type<StringType>();
            descriptor.Field(a => a.Country).Type<StringType>();
            descriptor.Field(a => a.Region).Type<StringType>();
            descriptor.Field(a => a.Municipality).Type<StringType>();
        }
    }
}
