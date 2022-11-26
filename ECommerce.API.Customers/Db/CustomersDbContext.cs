using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Customers.Db
{
    public class CustomersDbContext : DbContext
    {
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductsDb");
        }*/
        public DbSet<Customer> Customers { get; set; }
        public CustomersDbContext(DbContextOptions options): base(options)
        {

        }
    }
}
