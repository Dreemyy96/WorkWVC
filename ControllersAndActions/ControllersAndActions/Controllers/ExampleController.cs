using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Controllers
{
	public class ExampleController : Controller
	{
		//public IActionResult Index()
		//{
		//	ViewBag.Message = "Hello";
		//	ViewBag.Date = DateTime.Now;
		//	return View();
		//}
		//public IActionResult Result() => View((object)"Hello world!");
		//public RedirectResult Redirect() => Redirect("/Example/Index/");
		//public RedirectResult Redirect() => RedirectPermanent("/Example/Index/");

		//public RedirectToRouteResult Redirect() => RedirectToRoute(new { controller = "Example", action = "Index", id = "MyID" });
		//public RedirectToActionResult Redirect() => RedirectToAction(nameof(HomeController), nameof(HomeController.Index));

		//public IActionResult Index() => Json(new[] { "Alice", "Bob", "Joe" });

		//public ObjectResult Index() => Ok(new string[] { "Bob", "Joe", "Alice" });

		//public VirtualFileResult Index() => File("/lib/bootstrap/css/bootstrap.css", "text/css");

		public StatusCodeResult Index() =>NotFound();
    }
}
