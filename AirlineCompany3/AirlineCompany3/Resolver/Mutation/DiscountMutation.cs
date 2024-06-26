﻿using AirlineCompany3.Resolver.Type;

namespace AirlineCompany3.Resolver.Mutation
{
    public class DiscountMutation
    {
        public static void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Field("CreateDiscount")
                  .Argument("input", a => a.Type<NonNullType<DiscountCreationType>>())
                  .ResolveWith<DiscountResolver>(r => r.CreateDiscount(default, default))
                  .Type<MessageType>();
        }
    }
}
