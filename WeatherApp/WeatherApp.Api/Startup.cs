using AutoMapper;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Adapters;
using WeatherApp.Adapters.Interfaces;
using WeatherApp.Api.Core.AutoMapperConfig;
using WeatherApp.Api.Models;
using WeatherApp.Services.Interfaces;
using WeatherApp.Services.OpenWeatherMapService;

[assembly: FunctionsStartup(typeof(WeatherApp.Api.Startup))]

namespace WeatherApp.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var apiSettings = new ApiSettings(
                apiKey: Environment.GetEnvironmentVariable("WeatherApi.OpenWeatherMap.ApiKey"),
                baseUrl: new Uri(Environment.GetEnvironmentVariable("WeatherApi.OpenWeatherMap.BaseUrl"))
            );

            builder.Services.AddSingleton<ApiSettings>(apiSettings);
            builder.Services.AddSingleton<IWeatherService, OpenWeatherMapService>();
            builder.Services.AddSingleton<IWeatherServiceAdapter, WeatherServiceAdapter>();

            builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

            builder.Services.AddLogging();
        }
    }
}
