using AutoMapper;
using ECommerce.API.Orders.Db;
using ECommerce.API.Orders.Interfaces;
using ECommerce.API.Orders.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Orders.Providers
{
    public class OrdersProvider : IOrdersProvider
    {
        private readonly OrdersDbContext dbContext;
        private readonly ILogger<OrdersProvider> logger;
        private readonly IMapper mapper;
        public OrdersProvider(OrdersDbContext dbContext, ILogger<OrdersProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            if (!dbContext.Orders.Any())
            {
                var orderItem_1 = new Db.OrderItem
                {
                    Id = 1,
                    OrderId = 1,
                    ProductId = 1,
                    UnitPrice = (decimal)20.00,
                    Quantity = 5,
                };

                var order_1 = new Db.Order()
                {
                    Id = 1,
                    CustomerId = 1,
                    OrderDate = DateTime.Today,
                    Total = (decimal)100.00,
                    Items = new List<Db.OrderItem>() 
                    {
                        new Db.OrderItem
                        {
                            Id = 1,
                            OrderId = 1,
                            ProductId = 1,
                            UnitPrice = (decimal)20.00,
                            Quantity = 5,
                        },
                        new Db.OrderItem
                        {
                            Id = 2,
                            OrderId = 1,
                            ProductId = 2,
                            UnitPrice = (decimal)50.00,
                            Quantity = 2,
                        }
                    }

                };
                dbContext.Orders.Add(order_1);
                dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Order>? Orders, string? ErrorMesssage)> GetOrdersAsync(int customerId)
        {
            try
            {
                var orders = await dbContext.Orders.Where(o => o.CustomerId == customerId).ToListAsync();
                if (orders != null && orders.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Order>, IEnumerable<Models.Order>>(orders);
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
