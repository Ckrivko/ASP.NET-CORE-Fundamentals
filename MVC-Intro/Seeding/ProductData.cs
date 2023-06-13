using MVC_Intro.Models.Products;

namespace MVC_Intro.Seeding
{
    public class ProductData
    {
        public static IEnumerable<ProductViewModel> products =
                new List<ProductViewModel>()
                {
                    new ProductViewModel()
                    {
                        Id=Guid.NewGuid(),
                        Name="Cheese",
                        Price=(decimal)7.00

                    },
                     new ProductViewModel()
                    {
                          Id=Guid.NewGuid(),
                        Name="Ham",
                        Price=(decimal)5.00

                    },
                      new ProductViewModel()
                    {
                           Id=Guid.NewGuid(),
                        Name="Bread",
                         Price=(decimal)2.00

                    }

                };


    }
}
