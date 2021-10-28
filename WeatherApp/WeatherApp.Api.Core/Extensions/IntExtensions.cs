using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Api.Core.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        ///     Takes a given unix timestamp and converts to DateTime type
        /// </summary>
        /// <param name="unixTimeStamp"> unix timestamp </param>
        /// <returns> DateTime value of given unix timestamp </returns>
        public static DateTime UnixTimeStampToDateTime(this int unixTimeStamp)
        {
            //TODO: UNIT TEST
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
    }
}
