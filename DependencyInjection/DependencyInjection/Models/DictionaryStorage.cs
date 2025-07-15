
namespace DependencyInjection.Models
{
	public class DictionaryStorage : IModelStorage
	{
		private Dictionary<string, Product> _products = new Dictionary<string, Product>();
		public Product this[string key] { get => _products[key]; set => _products[key] = value; }

		public IEnumerable<Product> Items => _products.Values;

		public bool ContainsKey(string key)
		{
			return _products.ContainsKey(key);
		}

		public void RemoveItem(string key)
		{
			_products.Remove(key);
		}
	}
}
