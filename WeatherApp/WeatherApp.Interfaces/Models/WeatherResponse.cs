using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherApp.Services.Interfaces.Models
{
    public class WeatherResponse
    {
        public CoordDetails Coord { get; set; }
        public IEnumerable<WeatherResponseDetails> Weather { get; set; }
        public string Base { get; set; }
        public MainDetails Main { get; set; }
        public int Visibility { get; set; }
        public WindDetails Wind { get; set; }
        public CloudDetails Clouds { get; set; }
        public int Dt { get; set; }
        public SysDetails Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }
}