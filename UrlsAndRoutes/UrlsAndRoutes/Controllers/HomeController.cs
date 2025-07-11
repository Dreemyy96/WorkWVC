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
	}
}
