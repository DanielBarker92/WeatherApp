using System.Threading.Tasks;
using WeatherApp.Services.Interfaces;
using WeatherApp.Api.Models;
using WeatherApp.Services.Interfaces.Models;
using Flurl.Http;
using Flurl;

namespace WeatherApp.Services.OpenWeatherMapService
{
    public class OpenWeatherMapService : IWeatherService
    {
        private readonly ApiSettings _apiSettings;
        public OpenWeatherMapService(ApiSettings apiSettings)
            => _apiSettings = apiSettings;

        public async Task<WeatherResponse> GetWeatherByLocationAsync(string location)
        {
            var url = _apiSettings.BaseUrl.AppendPathSegment("weather")
                .SetQueryParams(new 
                { 
                    q = location, 
                    appid = _apiSettings.ApiKey,
                    units = "metric"
                });

            try
            {
                return await url.GetJsonAsync<WeatherResponse>();
            }
            catch (FlurlHttpException ex)
            {
                var error = await ex.GetResponseJsonAsync<ErrorResponse>();
                throw new FlurlHttpException(ex.Call, error.Message, ex.InnerException);
            }
        }
    }
}
