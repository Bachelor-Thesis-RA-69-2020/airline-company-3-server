﻿using AirlineCompany3.Model.Dto;

namespace AirlineCompany3.Service.Interface
{
    public interface IFlightService
    {
        MessageDto create(FlightCreationDto flightDto);
    }
}
