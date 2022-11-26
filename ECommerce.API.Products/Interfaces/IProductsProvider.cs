using ECommerce.API.Products.Models;

namespace ECommerce.API.Products.Interfaces
{
    public interface IProductsProvider
    {
        Task<(bool IsSuccess, IEnumerable<Product> Products, string ErrorMesssage)> GetProductsAsync();
        Task<(bool IsSuccess, Models.Product? Product, string? ErrorMesssage)> GetProductAsync(int id);
    }
}
