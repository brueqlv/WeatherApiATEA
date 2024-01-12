using Microsoft.AspNetCore.Mvc;
using Moq;
using WeatherAPI.Controllers;
using WeatherApiATEA.Models;

namespace WeatherApiTest
{
    public class Tests
    {
        public WeatherService _weatherService;
        private HttpClient _httpClient;
        private WeatherRepository _weatherRepository;
        private WeatherController _weatherController;
        private WeatherDBContext _dbContext;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
            _weatherService = new WeatherService(_httpClient);
            _weatherRepository = new WeatherRepository(_weatherService);
 //           _weatherController = new WeatherController(_weatherRepository);
        }

        [Test]
        public async Task GetWeatherData_Should_Return_Weather_Information_About_Valmiera()
        {
            var result = await _weatherService.GetWeatherData(new City("Valmiera", 57.5411, 25.4275));

            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(WeatherForecast), result);

            Assert.That(result.Name, Is.EqualTo("Valmiera"));
            Assert.That(result.Coord.Lat, Is.EqualTo(57.5411));
            Assert.That(result.Coord.Lon, Is.EqualTo(25.4275));
        }

        [Test]
        public async Task GetCitiesWeatherInformation_Should_Return_Weather_Information_For_10_Cities()
        {
            var result = await _weatherRepository.GetCitiesWeatherInformation();

            Assert.IsNotNull(result);
            Assert.IsInstanceOf(typeof(List<CityWeatherInfo>), result);

            Assert.IsTrue(result.Count == 10);
        }

        [Test]
        public async Task Index_Should_Return_View_With_CitiesWeather()
        {
  //          var result = await _weatherController.Index(); //Tests nav pabeigts
        }

    }
}