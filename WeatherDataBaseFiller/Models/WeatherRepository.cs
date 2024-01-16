namespace WeatherDataBaseFiller
{
    public class WeatherRepository
    {
        readonly WeatherService _weatherService;

        public WeatherRepository(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        private readonly List<City> _cities = new List<City>
        {
            new City("Valmiera", 57.5411, 25.4275),
            new City("Rīga", 57, 24.0833),
            new City("Tallinn", 59.437, 24.7535),
            new City("Valga", 57.7778, 26.0473),
            new City("Jasna", 54.0035, 19.3053),
            new City("Bled", 46.3692, 14.1136),
            new City("Krakow", 50.0833, 19.9167),
            new City("Paris", 46.0762, 11.4668),
            new City("London", 51.5085, -0.1257),
            new City("Antalya Province", 36.7741, 30.7178),
        };

        private readonly List<CityWeatherInfo> _citiesWeather = new List<CityWeatherInfo>();

        public async Task<List<CityWeatherInfo>> GetCitiesWeatherInformation()
        {
            foreach (City city in _cities)
            {
                var cityWeatherInfo = await _weatherService.GetWeatherData(city);

                string countryName = cityWeatherInfo.Sys.Country;
                string cityName = city.Name;
                double temp = GetCelciusFromKelvin(cityWeatherInfo.Main.Temp);
                double clouds = cityWeatherInfo.Clouds.All;
                double windSpeed = cityWeatherInfo.Wind.Speed;

                _citiesWeather.Add(new CityWeatherInfo(countryName, cityName, temp, clouds, windSpeed));
            }

            return _citiesWeather;
        }

        private static double GetCelciusFromKelvin(double kelvin)
        {
            return Math.Round(kelvin - 273.15, 2);
        }
    }
}
