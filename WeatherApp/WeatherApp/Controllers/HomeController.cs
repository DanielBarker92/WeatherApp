using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApp.Models;
using WeatherApp.Extensions;
using WeatherApp.Services.WeatherService;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherService _weatherService;

        public HomeController(IWeatherService weatherService, ILogger<HomeController> logger)
        {
            _weatherService = weatherService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new LocationRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm]LocationRequest searchLocation)
        {
            _logger.LogTrace($"Searched location: {searchLocation?.Location}");

            if (string.IsNullOrWhiteSpace(searchLocation.Location))
                return View("Error", new ErrorDetails("No search term entered", ""));
                
            var location = searchLocation.Location.AppendGbCountryCodeIfNotExists();

            try
            {
                var weatherDetails = await _weatherService.GetWeatherByLocationAsync(location);
                return View(new LocationRequest(location, weatherDetails));
            }
            catch (Exception e)
            {
                return View("Error", new ErrorDetails(e.Message, searchLocation.Location));
            }
        }
    }
}
