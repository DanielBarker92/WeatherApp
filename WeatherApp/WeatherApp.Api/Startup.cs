using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Interfaces;
using WeatherApp.OpenWeatherMapService;

[assembly: FunctionsStartup(typeof(WeatherApp.Api.Startup))]

namespace WeatherApp.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<IWeatherService, OpenWeatherMapWeatherService>();

            builder.Services.AddHttpClient("OpenWeatherMapV2.5", client =>
            {
                client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
            });
        }
    }
}
