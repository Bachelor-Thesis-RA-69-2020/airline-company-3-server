﻿using AirlineCompany3.Model.Domain;
using AirlineCompany3.Model.Dto;
using AutoMapper;

namespace AirlineCompany3.Model.MappingProfile
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            CreateMap<DiscountCreationDto, Discount>();
        }
    }
}