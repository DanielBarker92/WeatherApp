using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WeatherApp.Interfaces;

namespace WeatherApp.Api2
{
    public class CurrentWeatherHandler
    {
        private readonly IWeatherService _weatherService;

        public CurrentWeatherHandler(IWeatherService weatherService)
            => _weatherService = weatherService;

        [FunctionName("CurrentWeatherHandler")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "weather")] HttpRequest req,
            ILogger log)
        {
            var location = Convert.ToString(req.Query["location"]);
            var weatherResponse = await _weatherService.GetWeatherAsync(location);
            return new OkObjectResult(weatherResponse);
        }
    }
}
