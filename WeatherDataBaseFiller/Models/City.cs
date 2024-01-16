namespace WeatherDataBaseFiller
{
    public class City
    {
        public string Name { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set;}

        public City(string name, double latitude, double longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
