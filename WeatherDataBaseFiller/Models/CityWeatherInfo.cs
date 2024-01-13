using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherDataBaseFiller
{
    public class CityWeatherInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Country { get; set; }
        public string City { get; set; }
        public double Temperature { get; set; }
        public double Clouds { get; set; }
        public double WindSpeed { get; set; }
        public DateTime SavedAt { get; set; }

        public CityWeatherInfo(string country, string city, double temperature, double clouds, double windSpeed)
        {
            Country = country;
            City = city;
            Temperature = temperature;
            Clouds = clouds;
            WindSpeed = windSpeed;
            SavedAt = DateTime.Now;
        }
    }
}
