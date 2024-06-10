using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApi.Models;

namespace WeatherApi.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "b77b457cf16fe9ef6d717626efa9a34f";

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherData> GetCurrentWeatherAsync(string location)
        {
            var url = $"https://api.openweathermap.org/data/2.5/weather?q={location}&appid={_apiKey}&units=metric";

            var response = await _httpClient.GetStringAsync(url);
            var data = JsonConvert.DeserializeObject<WeatherApiResponse>(response);

            return new WeatherData
            {
                Location = data.Name,
                Temperature = data.Main.Temp,
                Condition = data.Weather[0].Description
            };
        }

        private class WeatherApiResponse
        {
            public string Name { get; set; }
            public MainData Main { get; set; }
            public WeatherData[] Weather { get; set; }

            public class MainData
            {
                public float Temp { get; set; }
            }

            public class WeatherData
            {
                public string Description { get; set; }
            }
        }
    }
}
