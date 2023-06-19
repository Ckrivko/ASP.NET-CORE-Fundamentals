using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EFAspCore.Infrastructure.Model
{
    [Comment("Product table")]
    public class Product
    {
        [Comment("Product id")]
        [Key]
        public int Id { get; set; }

        [Comment("Product name")]
        [StringLength(150)]
        [Required]
        public string ProductName { get; set; } = null!;

        [Comment("Product quantity")]
        [Required]
        [Range(1,25600000)]
        public int Quantity { get; set; }

        [Comment("Product price")]      
        public decimal? Price { get; set; }

        public List<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();

    }
}
