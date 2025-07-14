using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
	[Route("app/[controller]/actions/[action]/{id:int?}")]
	public class CustomerController : Controller
	{
		//[Route("myroute")]
		//[Route("[controller]/MyAction")]
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
