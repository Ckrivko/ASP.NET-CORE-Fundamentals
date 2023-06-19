using EFAspCore.Core.Contracts;
using EFAspCore.Core.Models;
using EFAspCore.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAspCore.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly WebShopDbContext dbContext;

        public ProductService(WebShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddProductAsync(ProductFormModel model)
        {
            var product = new Product
            {
                ProductName = model.Name,
                Quantity = model.Quantity
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();

        }

        public async Task EditProductAsync(int id, ProductFormModel model)
        {
            var product = dbContext.Products.FirstOrDefault(p => p.Id == id);

            product.ProductName=model.Name;
            product.Quantity = model.Quantity;

            await dbContext.SaveChangesAsync();
        }

        public async  Task<ProductFormModel> GetProductAsync(int id)
        {
            return await dbContext.Products
                .Where(p => p.Id == id)
                .Select(p => new ProductFormModel
                {
                    Name = p.ProductName,
                    Quantity = p.Quantity
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<ProductViewModel>> GetProductsAsync()
        {
            return await dbContext.Products.AsNoTracking()
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.ProductName
                })
                .ToListAsync();
        }

      
    }
}
