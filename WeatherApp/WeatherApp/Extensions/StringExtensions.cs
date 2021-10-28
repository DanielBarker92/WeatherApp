using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WeatherApp.Extensions
{
    public static class StringExtensions
    {
        public static string AppendGbCountryCodeIfNotExists(this string location)
        {
            var pattern = ", ?[a-zA-Z]{2}$";
            var regex = new Regex(pattern);

            if (regex.IsMatch(location))
                return location;

            return location + ", GB";
        }
    }
}