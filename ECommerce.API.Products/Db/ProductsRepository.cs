namespace ECommerce.API.Products.Db
{
    public class ProductsRepository : IProductsRepository
    {
        public ProductsRepository()
        {
           /* using(var context = new ProductsDbContext())
            {
                var products = new List<Product>
                {
                    new Product { Id = 1, Name = "Something"}
                };
            }*/
        }
        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
            
        }
    }
}
