﻿namespace LanguageFeatures.Models
{
	public class Products
	{
		public Products(bool stock = true) => InStock = stock;

		public string? Name { get; set; }
		public string? Category { get; set; } = "Watersport";
		public decimal? Price { get; set; }
		public Products? Related { get; set; }
		public bool InStock { get; }
		public static Products?[] GetProducts()
		{
			Products kayak = new Products() { Name = "Kayak", Category = "Water Craft", Price = 275M };
			Products lifejacket = new Products(false) { Name = "jifejacket", Price = 48.95M };
			kayak.Related = lifejacket;
			return new Products?[] { kayak, lifejacket, null };
		}
	}
}
