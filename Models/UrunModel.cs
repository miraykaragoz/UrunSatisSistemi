using System.ComponentModel.DataAnnotations;

namespace UrunSatisSistemi.Models
{
    public class Urun
    {
        [Required]
        public int Id{ get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Currency {  get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public string Img { get; set; }
    }
}
