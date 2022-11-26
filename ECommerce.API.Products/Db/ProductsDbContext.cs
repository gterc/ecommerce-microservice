using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Products.Db
{
    public class ProductsDbContext : DbContext
    {
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ProductsDb");
        }*/
        public DbSet<Product> Products { get; set; }
        public ProductsDbContext(DbContextOptions options): base(options)
        {

        }
    }
}
