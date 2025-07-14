using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View("Result", new Result()
			{
				Controller = nameof(HomeController),
				Action = nameof(Index)
			});
		}
		public IActionResult CustomVariable(string id)
		{
			Result result = new Result()
			{
				Controller = nameof(HomeController),
				Action = nameof(CustomVariable)
			};
			result.Data["id"] = id ?? "<no value>";
			//result.Data["catchall"] = RouteData.Values["catchall"];
			result.Data["Url"] = Url.Action("CustomVariable", "Home", new { id = 100 });
			return View("Result", result);
		}
	}
}
