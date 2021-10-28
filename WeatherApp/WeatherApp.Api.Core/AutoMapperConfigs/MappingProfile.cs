using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApp.Api.Models;
using WeatherApp.Services.Interfaces.Models;
using WeatherApp.Api.Core.Extensions;

namespace WeatherApp.Api.Core.AutoMapperConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeatherResponse, WeatherDetails>()
                .ConstructUsing(source => new WeatherDetails(
                    source.Name,
                    source.Weather.FirstOrDefault().Main,
                    source.Weather.FirstOrDefault().Description,
                    source.Main.Pressure,
                    source.Main.Humidity,
                    source.Sys.Sunset.UnixTimeStampToDateTime(),
                    source.Sys.Sunrise.UnixTimeStampToDateTime(),
                    new TemperatureDetails(source.Main.Temp, source.Main.Max, source.Main.Min)
                ));
        }
    }
}
