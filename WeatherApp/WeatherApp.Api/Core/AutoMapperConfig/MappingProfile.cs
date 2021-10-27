using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces.Models;

namespace WeatherApp.Api.Core.AutoMapperConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WeatherResponse, WeatherDetails>()
                .ForMember(
                    dest => dest.Weather,
                    opt => opt.MapFrom(src => src.Weather.FirstOrDefault().Main))
                .ForMember(
                    dest => dest.Description,
                    opt => opt.MapFrom(src => src.Weather.FirstOrDefault().Description))
                .ForMember(
                    dest => dest.Location,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.Temperature,
                    opt => opt.MapFrom(src => Convert.ToString(src.Main.Temp)));
        }
    }
}
