using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Services.Interfaces;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces.Models;

namespace WeatherApp.Services.OpenWeatherMapService
{
    public class OpenWeatherMapService : IWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiKey;
        public OpenWeatherMapService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _apiKey = Environment.GetEnvironmentVariable("WeatherApi.OpenWeatherMap.ApiKey");
        }

        public async Task<WeatherResponse> GetWeatherByLocationAsync(string location)
        {
            var client = _httpClientFactory.CreateClient("OpenWeatherMapV2.5");
            var request = new HttpRequestMessage(HttpMethod.Get, $"weather?q={location}&appid={_apiKey}");

            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var weatherDetails = JsonConvert.DeserializeObject<WeatherResponse>(content);
                return weatherDetails;
            }

            var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(content);
            throw new HttpRequestException(errorResponse.Message);
        }
    }
}
