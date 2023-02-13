using System.ComponentModel.DataAnnotations;

namespace Meteorites.Models
{
    public class GeoDB
    {
        [Key]
        public int Id { get; set; }
        public string type { set; get; } = string.Empty;
        public float coordinateX { set; get; } = 0;
        public float coordinateY { set; get; } = 0;
    }
}
