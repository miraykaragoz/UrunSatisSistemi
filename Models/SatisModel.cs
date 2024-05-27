using System.ComponentModel.DataAnnotations;

namespace UrunSatisSistemi.Models
{
    public class Satis
    {
        [Required]
        public int  SelectedProduct { get; set; }

        [Required]
        public int  Quantity { get; set; }

        [Required]
        public int Payment { get; set; }

        [Required]
        public double Change { get; set; }
    }
}
