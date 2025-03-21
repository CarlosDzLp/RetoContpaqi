using Newtonsoft.Json;

namespace RetoContpaqi.Models
{
    public class AddressModel
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("suite")]
        public string Suite { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        [JsonProperty("geo")]
        public GeoModel Geo { get; set; }
    }
}
