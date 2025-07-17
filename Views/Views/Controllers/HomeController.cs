using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View(new string[] { "Apple", "Orenge", "Pear" });
		}
		public IActionResult List() => View();
	}
}
