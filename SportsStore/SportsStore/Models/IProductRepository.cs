namespace SportsStore.Models
{
	public interface IProductRepository
	{
        public IQueryable<Product> Products { get; }
        public void SaveProduct(Product product);
        public Product DeleteProduct(int productId);
    }
}
