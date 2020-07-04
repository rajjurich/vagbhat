using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Contracts.ResponseModels;
using vagbhat.api.Extensions;
using System.Text;

namespace vagbhat.api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "sysadmin")]
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //[Authorize(Roles = "admin,sysadmin")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginatedResponse<IQueryable<WeatherForecast>>))]
        public IActionResult Get()
        {

            var rng = new Random();

            var data = Enumerable.Range(1, 50).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                UserId = HttpContext.GetUserName()
            }).AsQueryable().Skip(0).Take(5);

            var paginatedResponse = new PaginatedResponse<IQueryable<WeatherForecast>>(data)
            {
                Draw = 5.ToString(),
                RecordsFiltered = 50.ToString(),
                RecordsTotal = 50.ToString()
            };

            return Ok(paginatedResponse);
        }        
    }
}
