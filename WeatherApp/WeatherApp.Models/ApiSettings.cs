using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Api.Models
{
    public class ApiSettings
    {
        public string ApiKey { get; }
        public Uri BaseUrl { get; }

        public ApiSettings(string apiKey, Uri baseUrl)
        {
            ApiKey = apiKey;
            BaseUrl = baseUrl;
        }
    }
}
