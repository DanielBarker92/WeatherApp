using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherApp.Services.Interfaces.Models
{
    public class CoordDetails
    {
        public float Lon { get; set; }
        public float Lat { get; set; }
    }
}