using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherApp.Services.Interfaces.Models
{
    public class SysDetails
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }
}