using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Api.Models
{
    /// <summary>
    ///     Error object to be returned to the calling client
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        ///     Message of the error
        /// </summary>
        public string Message { get; set; }
    }
}
