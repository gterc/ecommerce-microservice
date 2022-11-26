using ECommerce.API.Orders.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Orders.Controllers
{
    [Route("api/[controller]")]
    //produces response
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersProvider ordersProvider;
        public OrdersController(IOrdersProvider customerProvider)
        {
            this.ordersProvider = customerProvider;
        }

        [HttpGet("{customerId}") ]
        public async Task<IActionResult> GetOrdersAsync(int customerId)
        {
            var result = await ordersProvider.GetOrdersAsync(customerId);
            if (result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }
    }
}
