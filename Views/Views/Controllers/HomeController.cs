using Microsoft.AspNetCore.Mvc;

namespace Views.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.Message = "Hello world";
			ViewBag.Time = DateTime.Now.ToString("HH:mm:ss");
			return View("DebugData");
		}
		public IActionResult List() => View();
	}
}
