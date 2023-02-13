using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Meteorites.Models
{
    public class MeteoriteViewModel
    {
        [JsonProperty("name")]
        [Required]
        public string name { set; get; } = "";

        [JsonProperty("id")]
        [Key]
        public int id { set; get; }

        [JsonProperty("nametype")]
        public string nametype { set; get; } = "";

        [JsonProperty("recclass")]
        public string recclass { set; get; } = "";

        [JsonProperty("mass")]
        public float? mass { set; get; } = 0;

        [JsonProperty("fall")]
        [Required]
        public string fall { set; get; } = "";

        [JsonProperty("year")]
        public DateTime? year { set; get; }

        [JsonProperty("reclat")]
        public float? reclat { set; get; }

        [JsonProperty("reclong")]
        public float? reclong { set; get; }

        [JsonProperty("geolocation")]
        [NotMapped]
        public Geolocation geolocation { set; get; } = new Geolocation();

        [JsonProperty(":@computed_region_cbhk_fwbd")]
        public int? computed_region_cbhk_fwbd { get; set; }

        [JsonProperty(":@computed_region_nnqa_25f4")]
        public int? computed_region_nnqa_25f4 { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public GeoDB geolocDB { set; get; } = new GeoDB();

    }
}
