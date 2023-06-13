namespace MVC_Intro.Models.Products
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

    }
}
