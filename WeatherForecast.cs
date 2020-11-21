// <copyright file="WeatherForecast.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore
{
    using System;

    /// <summary>
    /// This class models a weather forecast.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the temperature in degress centigrade.
        /// </summary>
        public int TemperatureC { get; set; }

        /// <summary>
        /// Gets the temperature in degrees fahrenheit.
        /// </summary>
        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        public string Summary { get; set; }
    }
}