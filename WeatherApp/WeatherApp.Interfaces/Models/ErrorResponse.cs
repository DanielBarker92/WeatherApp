using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Services.Interfaces.Models
{
    public class ErrorResponse
    {
        public string Cod { get; set; }
        public string Message { get; set; }
    }
}
