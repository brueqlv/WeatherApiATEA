using Microsoft.Extensions.Configuration;

namespace WeatherDataBaseFiller
{
    public class WeatherService
    {
        private readonly IWeatherAPI _weatherApi;
        private readonly string _apiKey;

        public WeatherService(IWeatherAPI weatherApi, IConfiguration configuration)
        {
            _weatherApi = weatherApi;
            _apiKey = configuration["WeatherApi:ApiKey"];
        }

        public async Task<WeatherForecast> GetWeatherData(City city)
        {
            try
            {
                WeatherForecast weatherForecast = await _weatherApi.GetWeatherData(city.Latitude, city.Longitude, _apiKey);
                return weatherForecast;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
