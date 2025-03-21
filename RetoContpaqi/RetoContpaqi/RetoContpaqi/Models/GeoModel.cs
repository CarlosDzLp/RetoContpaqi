using Newtonsoft.Json;

namespace RetoContpaqi.Models
{
    public class GeoModel
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
}
