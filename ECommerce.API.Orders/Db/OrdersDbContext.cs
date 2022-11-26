using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Orders.Db
{
    public class OrdersDbContext : DbContext
    {
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductsDb");
        }*/
        public DbSet<Order> Orders { get; set; }
        public OrdersDbContext(DbContextOptions options): base(options)
        {

        }
    }
}
