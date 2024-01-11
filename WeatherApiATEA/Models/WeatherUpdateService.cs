using System.Data.Entity.Migrations.Model;

namespace WeatherApiATEA.Models
{
    public class WeatherUpdateService : BackgroundService
    {

        private readonly WeatherRepository _weatherRepository;
        private readonly WeatherDBContext _dbContext;

        public WeatherUpdateService(WeatherRepository weatherRepository, WeatherDBContext dbContext)
        {
            _weatherRepository = weatherRepository;
            _dbContext = dbContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                var citiesWeather = await _weatherRepository.GetCitiesWeatherInformation();

                UpdateDatabase(citiesWeather);

                await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken);
            }
        }

        public void UpdateDatabase(List<CityWeatherInfo> citiesWeather)
        {
            _dbContext.CityWeatherInfos.AddRange(citiesWeather);
            _dbContext.SaveChanges();
        }
    }
}
