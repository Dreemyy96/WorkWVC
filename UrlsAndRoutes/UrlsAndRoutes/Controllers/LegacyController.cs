using Microsoft.AspNetCore.Mvc;

namespace UrlsAndRoutes.Controllers
{
	public class LegacyController : Controller
	{
		public IActionResult GetLegacyUrl(string legacyUrl)
		{
			return View((object)legacyUrl);
		}
	}
}
