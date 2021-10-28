using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Api.Models
{
    /// <summary>
    ///     Generic weather response containing information about the weather
    /// </summary>
    public class WeatherDetails
    {
        /// <summary>
        ///     Location the weather is relevant to
        /// </summary>
        public string Location { get; }
        /// <summary>
        ///     Current weather conditions 
        /// </summary>
        public string Weather { get; }
        /// <summary>
        ///     Description of the current weather conditions
        /// </summary>
        public string Description { get; }
        /// <summary>
        ///     Temperature details of the location
        /// </summary>
        public TemperatureDetails Temperature { get; }
        /// <summary>
        ///     Atmospheric pressure in hPa
        /// </summary>
        public int Pressure { get; }
        /// <summary>
        ///     Humidity %
        /// </summary>
        public int Humidity { get; }
        /// <summary>
        ///     Sunrise DateTime
        /// </summary>
        public DateTime Sunrise { get; }
        /// <summary>
        ///     Sunset DateTime
        /// </summary>
        public DateTime Sunset { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="location"></param>
        /// <param name="weather"></param>
        /// <param name="description"></param>
        /// <param name="pressure"></param>
        /// <param name="humidity"></param>
        /// <param name="sunset"></param>
        /// <param name="sunrise"></param>
        /// <param name="currentTemperature"></param>
        /// <param name="maximumTemperature"></param>
        /// <param name="minimumTemperature"></param>
        public WeatherDetails(
            string location, 
            string weather, 
            string description, 
            int pressure, 
            int humidity, 
            DateTime sunset, 
            DateTime sunrise,
            TemperatureDetails temperature)
        {
            Location = location;
            Weather = weather;
            Description = description;
            Pressure = pressure;
            Humidity = humidity;
            Sunset = sunset;
            Sunrise = sunrise;
            Temperature = temperature;
        }
    }
}
