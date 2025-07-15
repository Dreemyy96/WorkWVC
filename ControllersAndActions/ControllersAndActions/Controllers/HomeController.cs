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
		[HttpPost]
		public IActionResult RecieveForm(string name, string city) 
		{
			TempData["name"] = name;
			TempData["city"] = city;
			return RedirectToAction(nameof(Data));
        } 

		public IActionResult Data()
		{
			string name = TempData["name"] as string;
			string city = TempData["city"] as string;
            return View("Result", $"{name} lives in {city}");
        }
	}
}
