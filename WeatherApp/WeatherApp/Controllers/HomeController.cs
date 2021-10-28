using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new LocationRequest());
        }

        [HttpPost]
        public IActionResult Index([FromForm]LocationRequest searchLocation)
        {
            _logger.LogTrace($"Searched location: {searchLocation?.Location}");

            //TODO: complete below (if location searched)
            //var location = searchLocation.Location.AppendCountryCode();

            //TODO: create and call service (Services folder / WeatherApp.Client.Services) to call API.
            //TODO: display results below
            //TODO: handle error response

            return View(searchLocation);
        }
    }
}
