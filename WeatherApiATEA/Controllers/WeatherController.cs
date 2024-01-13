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
            List<CityWeatherInfo> citiesWeather = _weatherDataRetrievalService.GetMinTemperatureByCountry();

            return View(citiesWeather);
        }

        [HttpGet("GetHighestWindSpeed")]
        public IActionResult GetHighestWindSpeed()
        {
            List<CityWeatherInfo> citiesWeather = _weatherDataRetrievalService.GetHighestWindSpeedByCountry();

            return View(citiesWeather);
        }

        [HttpGet("GetTwoHourTrend/{cityName}")]
        public IActionResult GetTwoHourTrend(string cityName)
        {
            List<CityWeatherInfo> citiesWeather = _weatherDataRetrievalService.GetTwoHourTrendData(cityName);

            return View(citiesWeather);
        }
    }
}
