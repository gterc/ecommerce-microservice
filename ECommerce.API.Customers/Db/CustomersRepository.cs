namespace ECommerce.API.Customers.Db
{
    public class CustomersRepository : ICustomersRepository
    {
        public CustomersRepository()
        {
           /* using(var context = new ProductsDbContext())
            {
                var products = new List<Product>
                {
                    new Product { Id = 1, Name = "Something"}
                };
            }*/
        }
        public List<Customer> GetProducts()
        {
            throw new NotImplementedException();
            
        }
    }
}
