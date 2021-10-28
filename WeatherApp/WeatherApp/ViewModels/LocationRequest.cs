using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Api.Models;

namespace WeatherApp.Models
{
    /// <summary>
    ///     Contains the information related to a location search
    /// </summary>
    public class LocationRequest
    {
        public string Location { get; set; }

        public WeatherDetails WeatherDetails { get; set; }

        public LocationRequest()
        {
            WeatherDetails = null;
        }
    }
}
