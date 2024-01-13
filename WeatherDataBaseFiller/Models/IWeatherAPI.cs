using Refit;

namespace WeatherDataBaseFiller
{
    public interface IWeatherAPI
    {
        [Get("/weather?lat={latitude}&lon={longitude}&appid={apiKey}")]
        Task<WeatherForecast> GetWeatherData(double latitude, double longitude, string apiKey);
    }
}
