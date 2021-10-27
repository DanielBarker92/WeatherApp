using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Adapters.Interfaces;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;
using WeatherApp.Services.Interfaces.Models;

namespace WeatherApp.Adapters
{
    public class WeatherServiceAdapter : IWeatherServiceAdapter
    {
        private readonly IWeatherService _weatherService;
        private readonly ILogger<WeatherServiceAdapter> _logger;
        private readonly IMapper _mapper;

        public WeatherServiceAdapter(ILogger<WeatherServiceAdapter> logger, IMapper mapper, IWeatherService weatherService)
        {
            _weatherService = weatherService;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        ///     Gets the weather for the given location
        /// </summary>
        /// <param name="location"> Location string to find the current weather for </param>
        /// <returns> Generic weather details </returns>
        public async Task<WeatherDetails> GetWeatherByLocationAsync(string location)
        {
            var response = await _weatherService.GetWeatherByLocationAsync(location);
            return _mapper.Map<WeatherResponse, WeatherDetails>(response);
        }
    }
}
