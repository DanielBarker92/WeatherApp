using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherApp.Services.Interfaces.Models
{
    public class MainDetails
    {
        public float Temp { get; set; }
        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }
        [JsonPropertyName("temp_min")]
        public double Min { get; set; }
        [JsonPropertyName("temp_max")]
        public double Max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
}