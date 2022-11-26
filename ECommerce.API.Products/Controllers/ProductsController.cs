using ECommerce.API.Products.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Products.Controllers
{
    [Route("api/[controller]")]
    //produces response
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsProvider productsProvider;
        public ProductsController(IProductsProvider productProvider)
        {
            this.productsProvider = productProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await productsProvider.GetProductsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Products);
            }
            return NotFound();
        }

        [HttpGet("{id}") ]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await productsProvider.GetProductAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Product);
            }
            return NotFound();
        }
    }
}
