using AutoMapper;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Adapters;
using WeatherApp.Adapters.Interfaces;
using WeatherApp.Api.Core.AutoMapperConfig;
using WeatherApp.Services.Interfaces;
using WeatherApp.Services.OpenWeatherMapService;

[assembly: FunctionsStartup(typeof(WeatherApp.Api.Startup))]

namespace WeatherApp.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IWeatherService, OpenWeatherMapService>();
            builder.Services.AddSingleton<IWeatherServiceAdapter, WeatherServiceAdapter>();

            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

            builder.Services.AddHttpClient("OpenWeatherMapV2.5", client =>
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
            });
        }
    }
}
