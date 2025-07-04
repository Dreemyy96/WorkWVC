using System.Collections;

namespace LanguageFeatures.Models
{
	public class ShoppingCart : IEnumerable<Products>
	{
        public IEnumerable<Products?>? Products { get; set; }

		public IEnumerator<Products> GetEnumerator()
		{
			return Products.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)Products).GetEnumerator();
		}
	}
}
