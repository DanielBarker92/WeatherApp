using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WeatherApp.Services.Interfaces.Models
{
    public class MainDetails
    {
        public float Temp { get; set; }

        [JsonProperty("feels_like")]
        public float FeelsLike { get; set; }

        [JsonProperty("temp_min")]
        public float Min { get; set; }

        [JsonProperty("temp_max")]
        public float Max { get; set; }

        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
}