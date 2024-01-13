using Newtonsoft.Json;

namespace WeatherDataBaseFiller
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}
