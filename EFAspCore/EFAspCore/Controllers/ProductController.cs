using EFAspCore.Core.Contracts;
using EFAspCore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFAspCore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService _productService)
        {
            productService = _productService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await productService.GetProductsAsync();

            return View("All", model);
        }

        public IActionResult Add()
        {
            var model = new ProductFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await productService.AddProductAsync(model);

            return RedirectToAction(nameof(Index));
        
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model= await productService.GetProductAsync(id);
            return View(model);

        }
       
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            await  productService.EditProductAsync(id, model);

            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        { 
        await productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
