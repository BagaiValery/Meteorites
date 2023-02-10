using Newtonsoft.Json;

namespace Meteorites.Models
{
    public class MeteoriteViewModel
    {
        [JsonProperty("name")]
        public string name { set; get; }

        [JsonProperty("id")]
        public int id { set; get; }

        [JsonProperty("nametype")]
        public string nametype { set; get; }

        [JsonProperty("recclass")]
        public string recclass { set; get; }

        [JsonProperty("mass")]
        public float? mass { set; get; } = 0;

        [JsonProperty("fall")]
        public string fall { set; get; }

        [JsonProperty("year")]
        public DateTime? year { set; get; }

        [JsonProperty("reclat")]
        public float? reclat { set; get; }

        [JsonProperty("reclong")]
        public float? reclong { set; get; }

        [JsonProperty("geolocation")]
        public Geolocation geolocation { set; get; }

        [JsonProperty(":@computed_region_cbhk_fwbd")]
        public int? computed_region_cbhk_fwbd { get; set; }

        [JsonProperty(":@computed_region_nnqa_25f4")]
        public int? computed_region_nnqa_25f4 { get; set; }

    }
}
