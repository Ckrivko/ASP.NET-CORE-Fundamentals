using EFAspCore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAspCore.Core.Contracts
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetProductsAsync();

        Task AddProductAsync(ProductFormModel model);

        Task EditProductAsync(int id, ProductFormModel model);

        Task DeleteProductAsync(int id);

        Task<ProductFormModel> GetProductAsync(int id);

       
    
    }
}
