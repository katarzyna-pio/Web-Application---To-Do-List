using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeatherApi.Services;
using WeatherApi.Models;

namespace WeatherApi.Controllers
{
    public class WeatherViewComponent : ViewComponent
    {
        private readonly WeatherService _weatherService;

        public WeatherViewComponent(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string location = "Warsaw")
        {
            var weatherData = await _weatherService.GetCurrentWeatherAsync(location);
            return View(weatherData);
        }
    }
}
