using Microsoft.AspNetCore.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			Product myProduct = new()
			{
				ProductId = 1,
				Name = "Kayak",
				Description = "A boat for one person",
				Category = "Watersport",
				Price = 275M
			};
			return View(myProduct);
		}
	}
}
