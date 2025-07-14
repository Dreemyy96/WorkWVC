using Microsoft.AspNetCore.Mvc;

namespace ControllersAndActions.Controllers
{
	public class DerivedController : Controller
	{
		public IActionResult Index()
		{
			return View("Result", $"This is a derived controller");
		}
		public IActionResult Headers()
		{
			return View("DictionaryResult", Request.Headers.ToDictionary(kvp=>kvp.Key, kvp=> kvp.Value.First()));
		}
	}
}
