using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVC_Intro.Models.Products;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using static MVC_Intro.Seeding.ProductData;

namespace MVC_Intro.Controllers
{
    public class ProductController : Controller
    {
                     
        public IActionResult All(string keyword)
        {
            if (String.IsNullOrWhiteSpace(keyword))
            { 
             return View(products);
            }
            IEnumerable<ProductViewModel> productsAfterSearch = products
               .Where(p => p.Name.ToLower().Contains(keyword.ToLower()))
               .ToArray();

            return View(productsAfterSearch);
           
        }

        [Route("/Product/Details/{id?}")]
        public IActionResult ById(string id)
        { 
        ProductViewModel? product= products
                .FirstOrDefault(p=>p.Id.ToString().Equals(id));

            if (product == null)
            {
                return this.RedirectToAction("All");
            }
            return this.View(product);
        }

        public IActionResult AllAsJson()
        {

            //string jsonText = JsonConvert.SerializeObject(products, Formatting.Indented);

            //return Json(jsonText);

            return Json(products,new JsonSerializerOptions()
                {
                WriteIndented = true
            });
        }

        public IActionResult AllAsText() 
        {
            var sb = new StringBuilder();
            var counter = 1;

            foreach (var product in products)
            {
                sb.AppendLine($"{counter}. Product name: {product.Name} - product price: {product.Price}");
            }
            return Content(sb.ToString().Trim());
        }

        public IActionResult DownloadProductsInfo()
        {
            var sb = new StringBuilder();
            var counter = 1;

            foreach (var product in products)
            {
                sb.AppendLine($"{counter}. Product name: {product.Name} - product price: {product.Price}");
                sb.AppendLine("----------------------------");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt"); //inline is to read without downloading
            return File(Encoding.UTF8.GetBytes(sb.ToString().Trim()), "text/plain");

        }
    }
}
