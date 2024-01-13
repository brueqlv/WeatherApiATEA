using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WeatherDataBaseFiller;
using Refit;

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        string connectionString = context.Configuration.GetConnectionString("WeatherDatabase");

        services.AddDbContext<WeatherDBContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        var weatherApi = RestService.For<IWeatherAPI>("https://api.openweathermap.org/data/2.5");
        services.AddSingleton(weatherApi);

        services.AddTransient<WeatherRepository>();
        services.AddTransient<WeatherService>();

        services.AddHostedService<DataInitializationService>();
    });

await builder.RunConsoleAsync();
