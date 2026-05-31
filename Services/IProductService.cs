using OnlineShoppingStore.Dtos;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Services
{
    public interface IProductService
    {
        
            Task<Product> AddProductAsync(ProductDto dto);
            Task<bool> UpdateProductAsync(int id, ProductDto dto);
            Task<bool> DeleteProductAsync(int id);
            Task<Product?> GetProductByIdAsync(int id);
            Task<IEnumerable<Product>> GetAllProductsAsync();
        
    }
}
