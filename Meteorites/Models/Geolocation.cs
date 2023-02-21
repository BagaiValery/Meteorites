using System.ComponentModel.DataAnnotations;

namespace Meteorites.Models
{
    public class Geolocation
    {
        public int Id { get; set; }
        public string type { set; get; } = string.Empty;
        public float[] coordinates { set; get; } = { 0, 0};
    }
}
