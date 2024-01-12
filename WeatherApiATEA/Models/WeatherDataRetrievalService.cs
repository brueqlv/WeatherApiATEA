namespace WeatherApiATEA.Models
{
    public class WeatherDataRetrievalService
    {
        private readonly WeatherDBContext _dbContext;

        public WeatherDataRetrievalService(WeatherDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CityWeatherInfo> GetCityWeatherInfo()
        {
            return _dbContext.CityWeatherInfos.ToList();
        }

        public List<CityWeatherInfo> GetMinTemperatureByCountry()
        {
            var minTemp = _dbContext.CityWeatherInfos
                .Where(c => c.Temperature == _dbContext.CityWeatherInfos
                    .Where(inner => inner.Country == c.Country)
                    .Min(inner => inner.Temperature))
                .GroupBy(c => c.Country)
                .Select(group => group.OrderByDescending(c => c.SavedAt).First())
                .ToList();

            return minTemp;
        }

        public List<CityWeatherInfo> GetHighestWindSpeedByCountry()
        {
            var highestWindSpeed = _dbContext.CityWeatherInfos
                .Where(c => c.WindSpeed == _dbContext.CityWeatherInfos
                    .Where(inner => inner.Country == c.Country)
                    .Max(inner => inner.WindSpeed))
                .GroupBy(c => c.Country)
                .Select(group => group.OrderByDescending(c => c.SavedAt).First())
                .ToList();

            return highestWindSpeed;
        }

        public List<CityWeatherInfo> GetTwoHourTrendData(string cityName)
        {
            var twoHoursAgo = DateTime.UtcNow.AddHours(-2);

            var trendData = _dbContext.CityWeatherInfos
                .Where(c => c.City == cityName && c.SavedAt >= twoHoursAgo)
                .OrderBy(c => c.SavedAt)
                .ToList();

            return trendData;
        }
    }
}
