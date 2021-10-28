using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using WeatherApp.Api.Models;
using System.IO;
using WeatherApp.Adapters.Interfaces;
using WeatherApp.Services.Interfaces;
using AutoMapper;
using Flurl.Http;
using WeatherApp.Services.Interfaces.Models;

namespace WeatherApp.Api
{
    public class CurrentWeatherHandler
    {
        private readonly IWeatherService _weatherService;
        private readonly IWeatherServiceAdapter _weatherServiceAdapter;

        public CurrentWeatherHandler(IWeatherService weatherService, IWeatherServiceAdapter weatherServiceAdapter)
        {
            _weatherService = weatherService;
            _weatherServiceAdapter = weatherServiceAdapter;
        }

        [FunctionName("CurrentWeatherHandler")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "weather")] HttpRequest req,
            ILogger log)
        {
            req.Query.TryGetValue("location", out var location);

            if (string.IsNullOrWhiteSpace(location))
            {
                log.LogWarning($"Location parameter was missing from request");
                return new BadRequestObjectResult("Mandatory 'location' querystring parameter is missing.");
            }

            try
            {
                var weatherDetails = await _weatherServiceAdapter.GetWeatherByLocationAsync(location);
                return new OkObjectResult(weatherDetails);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(new ErrorDetails() { Message = e.Message });
            }
        }
    }
}
