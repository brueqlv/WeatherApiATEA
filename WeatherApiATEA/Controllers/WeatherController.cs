using Microsoft.AspNetCore.Mvc;
using WeatherApiATEA.Models;

namespace WeatherAPI.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherDataRetrievalService _weatherDataRetrievalService;

        public WeatherController(WeatherDataRetrievalService weatherDataRetrievalService)
        {
            _weatherDataRetrievalService = weatherDataRetrievalService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("GetMinTemperatures")]
        public IActionResult GetMinTemperatures()
        {
            List<CityWeatherInfo> temperaturesByCity = _weatherDataRetrievalService.GetMinTemperatureByCity();

            return View(temperaturesByCity);
        }

        [HttpGet("GetHighestWindSpeed")]
        public IActionResult GetHighestWindSpeed()
        {
            List<CityWeatherInfo> windSpeedByCity = _weatherDataRetrievalService.GetHighestWindSpeedByCity();

            return View(windSpeedByCity);
        }

        [HttpGet("GetTwoHourTrend/{cityName}")]
        public IActionResult GetTwoHourTrend(string cityName)
        {
            List<CityWeatherInfo> citieWeatherTrend = _weatherDataRetrievalService.GetTwoHourWindSpeedAndTemperatureTrendData(cityName);

            return View(citieWeatherTrend);
        }
    }
}
