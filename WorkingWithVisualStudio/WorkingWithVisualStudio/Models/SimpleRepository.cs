namespace WorkingWithVisualStudio.Models
{
	public class SimpleRepository
	{
		private static SimpleRepository _sharedRepository = new();
		private Dictionary<string, Product> products = new Dictionary<string, Product>();

		public static SimpleRepository SharedRepository => _sharedRepository;

		public SimpleRepository()
		{
			var initialItem = new[]
			{
				new Product{Name="Kayak", Price=275M},
				new Product{Name="Lifejacket", Price=48.95M},
				new Product{Name="Soccer Ball", Price=19.50M},
				new Product{Name = "Corner flag", Price=34.95M}
			};
			foreach (var item in initialItem)
			{
				AddProducts(item);
			}
		}
		public IEnumerable<Product> Products => products.Values;
		public void AddProducts(Product p) => products.Add(p.Name, p);
	}
}
