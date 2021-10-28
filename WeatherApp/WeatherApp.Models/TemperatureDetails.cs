using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Api.Models
{
    public class TemperatureDetails
    {
        /// <summary>
        ///     Current temperature in degrees celcius
        /// </summary>
        public float Current { get; }
        /// <summary>
        ///     Maximum temperature in degrees celcius
        /// </summary>
        public float Maximum { get; }
        /// <summary>
        ///     Minimum temperature in degrees celcius
        /// </summary>
        public float Minimum { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <param name="max"></param>
        /// <param name="min"></param>
        public TemperatureDetails(float current, float maximum, float minimum)
        {
            Current = current;
            Maximum = maximum;
            Minimum = minimum;
        }
    }
}
