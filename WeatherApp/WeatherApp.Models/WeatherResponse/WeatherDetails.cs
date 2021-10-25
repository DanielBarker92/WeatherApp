using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class WeatherDetails
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}