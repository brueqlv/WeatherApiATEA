using Newtonsoft.Json;

namespace WeatherApiATEA.Models
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiKey = "b3206742686996c3984dbe608072d263";
        }

        public async Task<WeatherForecast> GetWeatherData(City city)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat={city.Latitude}&lon={city.Longitude}&appid={_apiKey}&units=metric");
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var weatherForecast = JsonConvert.DeserializeObject<WeatherForecast>(responseContent);
                return weatherForecast;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
