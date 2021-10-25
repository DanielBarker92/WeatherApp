using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherApp.Models
{
    public class WindDetails
    {
        public float Speed { get; set; }
        public int Deg { get; set; }
    }
}