using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Api.Models;

namespace WeatherApp.Services.WeatherService
{
    public interface IWeatherService
    {
        public Task<WeatherDetails> GetWeatherByLocationAsync(string location);
    }
}
