using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Models
{
    /// <summary>
    ///     Generic weather response containing information about the weather
    /// </summary>
    public class WeatherDetails
    {
        /// <summary>
        ///     Location the weather is relevant to
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        ///     Current weather conditions 
        /// </summary>
        public string Weather { get; set; }
        /// <summary>
        ///     Description of the current weather conditions
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        ///     Current temperature of the location
        /// </summary>
        public string Temperature { get; set; }
    }
}
