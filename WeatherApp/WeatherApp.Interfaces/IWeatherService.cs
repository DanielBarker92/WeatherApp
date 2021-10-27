using System;
using System.Threading.Tasks;
using WeatherApp.Services.Interfaces.Models;

namespace WeatherApp.Services.Interfaces
{
    public interface IWeatherService
    {
        /// <summary>
        ///     Implementation for getting the weather from a specific weather providing service
        /// </summary>
        /// <param name="location"> Location string to find the current weather for </param>
        /// <returns> Weather response from the weather providing service </returns>
        public Task<WeatherResponse> GetWeatherByLocationAsync(string location);
    }
}
