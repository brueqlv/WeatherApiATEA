using Microsoft.EntityFrameworkCore;

namespace WeatherDataBaseFiller
{
    public class WeatherDBContext : DbContext
    {
        public DbSet<CityWeatherInfo> CityWeatherInfos { get; set; }

        public WeatherDBContext(DbContextOptions<WeatherDBContext> options) : base(options)
        {
            Database.Migrate();
        }
    }
}
