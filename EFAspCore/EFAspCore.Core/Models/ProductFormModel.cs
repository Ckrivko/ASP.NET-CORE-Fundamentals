using System.ComponentModel.DataAnnotations;

namespace EFAspCore.Core.Models
{
    public class ProductFormModel
    {

        [Range(typeof(int), minimum: "1", maximum: "2456")]
        public int Quantity { get; set; }
        public string Name { get; set; }

    }
}
