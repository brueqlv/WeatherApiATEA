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
                .GroupBy(c => c.City)
                .Select(group => group
                    .OrderBy(c => c.Temperature)
                    .FirstOrDefault())
                .ToList();

            return minTemp;
        }

        public List<CityWeatherInfo> GetHighestWindSpeedByCountry()
        {
            var minTemp = _dbContext.CityWeatherInfos
                .GroupBy(c => c.City)
                .Select(group => group
                    .OrderByDescending(c => c.WindSpeed)
                    .FirstOrDefault())
                .ToList();

            return minTemp;
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
