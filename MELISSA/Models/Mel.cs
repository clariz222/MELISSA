using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MELISSA.Models
{
    public class Mel
    {
        public int ID { get; set; }
        [StringLength (60,MinimumLength = 3)]
        [Required]
        [Display(Name = "Name of Product")]
        public string NameofProduct { get; set; } = String.Empty;
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Brand { get; set; } = string.Empty;
       [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        [Range(1,100)]
        public int Quantity { get; set; }

        [Range(1, 99999)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2")]
        public decimal Price { get; set; }  
    }
}
