using Domain.Model;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace vagbhat.api
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public string UserId { get; set; }
    }
}
