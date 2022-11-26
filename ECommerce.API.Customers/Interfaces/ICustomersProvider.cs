using ECommerce.API.Customers.Models;

namespace ECommerce.API.Customers.Interfaces
{
    public interface ICustomersProvider
    {
        Task<(bool IsSuccess, IEnumerable<Models.Customer> Customers, string ErrorMesssage)> GetCustomersAsync();
        Task<(bool IsSuccess, Models.Customer? Customer, string? ErrorMesssage)> GetCustomerAsync(int id);
    }
}
