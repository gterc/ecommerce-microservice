using ECommerce.API.Orders.Models;

namespace ECommerce.API.Orders.Interfaces
{
    public interface IOrdersProvider
    {
        Task<(bool IsSuccess, IEnumerable<Models.Order>? Orders, string? ErrorMesssage)> GetOrdersAsync(int customerId);
    }
}
