
namespace DependencyInjection.Models
{
    public class MemoryRepository : IRepository
    {
        private IModelStorage _storage;
        private string guid = System.Guid.NewGuid().ToString();
        public MemoryRepository(IModelStorage storage)
        {
            _storage = storage;

            new List<Product>()
            {
                new Product{Name= "Kayak", Price = 275M},
                new Product{Name = "Lifejacket", Price = 48.95M},
                new Product{Name = "Soccer ball", Price = 19.50M}
            }.ForEach(p => AddProduct(p));
        }

        public Product this[string name] => _storage[name];

        public IEnumerable<Product> Products => _storage.Items;

        public void AddProduct(Product product)
        {
            _storage[product.Name] = product;
        }

        public void Delete(Product product)
        {
            _storage.RemoveItem(product.Name);
        }
		public override string ToString()
		{
            return guid;
		}
	}
}
