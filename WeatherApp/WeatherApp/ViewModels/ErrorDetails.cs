using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Api.Models;

namespace WeatherApp.Models
{
    /// <summary>
    ///     Contains the information related to a location search
    /// </summary>
    public class ErrorDetails
    {
        public string Message { get; }
        public string SearchTerm { get; }

        public ErrorDetails(string message, string searchTerm)
        {
            Message = message;
            SearchTerm = searchTerm;
        }
    }
}
