using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
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
        /// <summary>
        /// Get Weather List
        /// </summary>

        /// <returns>IEnumerable<WeatherForecast></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        /// <summary>
        /// Get Number + 1
        /// </summary>
        /// <param name="number" example="10">5 Girebilirsin</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /GetNumber
        ///     {
        ///        "number": 5
        ///     }
        ///
        /// </remarks>
        /// <returns>Int</returns>
        /// <response code="200">Sayı Başarılı Bir Şekilde Geldi</response>
        /// <response code="400">Sayfa Bulunamadı</response>  
        /// <example>35</example>
        [HttpGet("{number}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public int GetNumber(int number)
        {
            return number + 1;
        }

    }
}
