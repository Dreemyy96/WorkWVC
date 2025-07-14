using ControllersAndActions.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ControllersAndActions.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View("SimpleForm");
		}
		//public IActionResult RecieveForm()
		//{
		//	var name = Request.Form["name"];
		//	var city = Request.Form["city"];
		//	return View("Result", $"{name} lives in {city}");
		//}

		//public IActionResult RecieveForm(string name, string city) => View("Result", $"{name} lives in {city}");

		//public IActionResult RecieveForm(string name, string city)
		//{
		//	return new CustomHtmlResult { Content = $"{name} lives in {city}" };
		//}

		public IActionResult RecieveForm(string name, string city) => View("Result", $"{name} lives in {city}");
	}
}
