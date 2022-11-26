namespace ECommerce.API.Products.Db
{
    public interface IProductsRepository
    {
        public List<Product> GetProducts();
    }
}
