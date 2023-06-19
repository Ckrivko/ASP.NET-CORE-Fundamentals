using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAspCore.Infrastructure.Model
{
    [Comment("Product note table")]
    public class ProductNote
    {
        [Comment("Product note id")]
        [Key]
        public int Id { get; set; }

        [Comment("Product note text")]
        [StringLength(500)]
        [Required]
        public string Note { get; set; } = null!;

        [Comment("product note date")]
        [Required]
        public DateTime NoteDate { get; set; }

        [Comment("Product id")]
        [Required]
        public int ProductId { get; set; }

        [Comment("product")]
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
