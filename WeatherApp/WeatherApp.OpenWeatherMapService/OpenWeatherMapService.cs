using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Services.Interfaces;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces.Models;
using Flurl.Http;
using Flurl;

namespace WeatherApp.Services.OpenWeatherMapService
{
    public class OpenWeatherMapService : IWeatherService
    {
        private readonly string _apiKey;
        private readonly Uri _baseUrl;
        public OpenWeatherMapService()
        {
            _apiKey = Environment.GetEnvironmentVariable("WeatherApi.OpenWeatherMap.ApiKey");
            _baseUrl = new Uri(Environment.GetEnvironmentVariable("WeatherApi.OpenWeatherMap.BaseUrl"));
        }

        public async Task<WeatherResponse> GetWeatherByLocationAsync(string location)
        {
            var url = _baseUrl.AppendPathSegment("weather").SetQueryParams(new { q = location, appid = _apiKey });

            try
            {
                var test = await url.GetJsonAsync();

                return await url.GetJsonAsync<WeatherResponse>();
            }
            catch (FlurlHttpException ex)
            {
                var error = await ex.GetResponseJsonAsync<ErrorResponse>();
                var res = $"Error returned from {ex.Call.Request.Url}: {error.Message}";
                throw new HttpRequestException(error.Message);
            }
        }
    }
}
