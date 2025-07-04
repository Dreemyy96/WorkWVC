using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanguageFeatures.Controllers
{
	public class HomeController : Controller
	{
		//public ViewResult Index()
		//{
		//	ShoppingCart cart = new ShoppingCart() { Products = Products.GetProducts() };
		//	Products[] productsArray =
		//	{
		//		new Products(){Name="Kayak", Price = 275M},
		//		new Products(){Name="Lifejacket", Price = 48.95M},
		//		new Products(){Name="Soccer ball", Price = 19.50M},
		//		new Products(){Name="Corner flag", Price = 34.95M}
		//	};
		//	decimal totalCart = cart.TotalPrices();
		//	decimal totalArr = productsArray.TotalPrices();
		//	decimal totalFiltArr = productsArray.Filter(p => p?.Name?.Length > 5).TotalPrices();
		//	return View(new string[] { $"Total cart: {totalCart:C2}", $"Total array: {totalArr:C2}", $"Total filtered array: {totalFiltArr:c2}" });
		//}
		public async Task<ViewResult> Index()
		{
			var res = await MyAsyncMethods.GetPageLengthAsync();
			return View(new string[] { $"Length:{res}" });
		}
	}
}
