using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.OpenWeatherMapService
{
    public class OpenWeatherMapWeatherService : IWeatherService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiKey;
        public OpenWeatherMapWeatherService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _apiKey = Environment.GetEnvironmentVariable("WeatherApi.OpenWeatherMap.ApiKey");
        }

        public async Task<WeatherResponse> GetWeatherAsync(string location)
        {
            var client = _httpClientFactory.CreateClient("OpenWeatherMapV2.5");
            var request = new HttpRequestMessage(HttpMethod.Get, $"weather?q={location}&appid={_apiKey}");

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var weatherDetails = JsonConvert.DeserializeObject<WeatherResponse>(content);
                return weatherDetails;
            }

            throw new Exception("its broke");
        }
    }
}
