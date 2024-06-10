
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApi.Models;
using WeatherApi.Services;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentWeather([FromQuery] string location)
        {
            if (string.IsNullOrEmpty(location))
            {
                return BadRequest("Location is required.");
            }

            var weatherData = await _weatherService.GetCurrentWeatherAsync(location);
            return Ok(weatherData);
        }
    }
}

