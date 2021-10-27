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
            return View(searchLocation);
        }
    }
}
