using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Controllers
{
	public class ExampleController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.Message = "Hello";
			ViewBag.Date = DateTime.Now;
			return View();
		}
		public IActionResult Result() => View((object)"Hello world!");
	}
}
