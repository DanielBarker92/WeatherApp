using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Api.Models;

namespace WeatherApp.Services.WeatherService
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<WeatherService> _logger;
        public WeatherService(IHttpClientFactory httpClientFactory, ILogger<WeatherService> logger)
        {
            _httpClient = httpClientFactory.CreateClient("BglWeatherService");
            _logger = _logger;
        }
        public async Task<WeatherDetails> GetWeatherByLocationAsync(string location)
        {
            var response = await _httpClient.GetAsync($"weather?location={location}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<ErrorDetails>(content);
                throw new HttpRequestException(error.Message);
            }

            return JsonConvert.DeserializeObject<WeatherDetails>(content);
        }
    }
}
