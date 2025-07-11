using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
	public class CustomerController : Controller
	{
		public IActionResult Index()
		{
			return View("Result", new Result()
			{
				Controller = nameof(CustomerController),
				Action = nameof(Index)
			});
		}
		public IActionResult List()
		{
			return View("Result", new Result()
			{
				Controller = nameof(CustomerController),
				Action = nameof(List)
			});
		}
	}
}
