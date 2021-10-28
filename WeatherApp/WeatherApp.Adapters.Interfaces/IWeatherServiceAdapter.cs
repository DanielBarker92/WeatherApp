using System;
using System.Threading.Tasks;
using WeatherApp.Api.Models;

namespace WeatherApp.Adapters.Interfaces
{
    public interface IWeatherServiceAdapter
    {
        public Task<WeatherDetails> GetWeatherByLocationAsync(string location);
    }
}
