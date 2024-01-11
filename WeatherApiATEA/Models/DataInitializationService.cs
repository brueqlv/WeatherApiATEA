namespace WeatherApiATEA.Models
{
    public class DataInitializationService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public DataInitializationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
             await InitializeDataAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task InitializeDataAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<WeatherDBContext>();

                var weatherRepository = scope.ServiceProvider.GetRequiredService<WeatherRepository>();
                var data = await weatherRepository.GetCitiesWeatherInformation();

                dbContext.CityWeatherInfos.AddRange(data);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
