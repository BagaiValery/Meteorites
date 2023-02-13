using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Meteorites.Models
{
    public class MeteorDB
    {
        public string name { set; get; } = "";

        public int id { set; get; }

       
        public string nametype { set; get; } = "";

     
        public string recclass { set; get; } = "";

       
        public float? mass { set; get; } = 0;

       
        public string fall { set; get; } = "";

        
        public DateTime? year { set; get; }

        
        public float? reclat { set; get; }

       
        public float? reclong { set; get; }


        //public Geolocation geolocation { set; get; } = new Geolocation();
        public GeoDB geolocation { set; get; } = new GeoDB();

       
        public int? computed_region_cbhk_fwbd { get; set; }

        
        public int? computed_region_nnqa_25f4 { get; set; }
    }
}
