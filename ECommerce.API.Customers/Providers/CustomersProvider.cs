using AutoMapper;
using ECommerce.API.Customers.Db;
using ECommerce.API.Customers.Interfaces;
using ECommerce.API.Customers.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Customers.Providers
{
    public class CustomersProvider : ICustomersProvider
    {
        private readonly CustomersDbContext dbContext;
        private readonly ILogger<CustomersProvider> logger;
        private readonly IMapper mapper;
        public CustomersProvider(CustomersDbContext dbContext, ILogger<CustomersProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Customers.Any())
            {
                dbContext.Customers.Add(new Db.Customer() { Id = 1, Name = "John", Address = " 123 Main St" });
                dbContext.Customers.Add(new Db.Customer() { Id = 2, Name = "Michael", Address = " 123 Main St" });
                dbContext.Customers.Add(new Db.Customer() { Id = 3, Name = "William", Address = " 123 Main St" });
                dbContext.Customers.Add(new Db.Customer() { Id = 4, Name = "Justin", Address = " 123 Main St" });
                //dbContext.Customers.Add(new Db.Product() { Id = 5, Name = "Keyboard", Price = 20, Inventory = 100 });
                dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Customer>? Customers, string? ErrorMesssage)> GetCustomersAsync()
        {
            try
            {
                var products = await dbContext.Customers.ToListAsync();
                if(products != null && products.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Customer>, IEnumerable<Models.Customer>>(products);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }catch(Exception ex)
            {
                logger?.LogError(ex.Message);
                return(false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Models.Customer? Customer, string? ErrorMesssage)> GetCustomerAsync(int id)
        {
            try
            {
                var product = await dbContext.Customers.FirstOrDefaultAsync(i => i.Id == id);
                if (product != null)
                {
                    var result = mapper.Map<Db.Customer, Models.Customer>(product);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.Message);
                return (false, null, ex.Message);
            }
        }
    }
}
