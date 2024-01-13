using Newtonsoft.Json;

namespace WeatherApiATEA.Models
{
    public class Clouds
    {
        [JsonProperty("all")]
        public long All { get; set; }
    }
}
