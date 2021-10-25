using System;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Interfaces
{
    public interface IWeatherService
    {
        public Task<WeatherResponse> GetWeatherAsync(string location);
    }
}
