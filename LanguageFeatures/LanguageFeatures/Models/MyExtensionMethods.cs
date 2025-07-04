namespace LanguageFeatures.Models
{
	public static class MyExtensionMethods
	{
		public static decimal TotalPrices(this IEnumerable<Products> products)
		{
			decimal totalPrice = 0;
			foreach(Products? p in products)
			{
				totalPrice += p?.Price ?? 0;
			}
			return totalPrice;
		}
		public static IEnumerable<Products> FilterByPrice(this IEnumerable<Products> products, decimal minPrice)
		{
			foreach(Products? p in products)
			{
				if(p?.Price>minPrice)
					yield return p;
			}
		}
		public static IEnumerable<Products> Filter(this IEnumerable<Products> products, Predicate<Products> pr)
		{
			foreach(Products? p in products)
			{
				if (pr(p))
				{
					yield return p;
				}
			}
		}
	}
}
