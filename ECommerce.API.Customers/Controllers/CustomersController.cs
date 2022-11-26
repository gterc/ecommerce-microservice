﻿using ECommerce.API.Customers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Customers.Controllers
{
    [Route("api/[controller]")]
    //produces response
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersProvider customersProvider;
        public CustomersController(ICustomersProvider customerProvider)
        {
            this.customersProvider = customerProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var result = await customersProvider.GetCustomersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Customers);
            }
            return NotFound();
        }

        [HttpGet("{id}") ]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var result = await customersProvider.GetCustomerAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Customer);
            }
            return NotFound();
        }
    }
}
