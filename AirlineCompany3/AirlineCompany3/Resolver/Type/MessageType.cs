using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Resolver.Type
{
    public class MessageType : ObjectType<MessageDto>
    {
        protected override void Configure(IObjectTypeDescriptor<MessageDto> descriptor)
        {
            descriptor.Field(m => m.Message).Type<StringType>();
        }
    }
}
