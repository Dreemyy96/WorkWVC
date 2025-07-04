using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Controllers
{
	public class HomeController : Controller
	{
		public IRepository Repository { get; set; } = SimpleRepository.SharedRepository;
        public IActionResult Index()
		{
			return View(Repository.Products);
		}

		[HttpGet]
		public IActionResult AddProduct() => View();

		[HttpPost]
		public IActionResult AddProduct(Product p)
		{
			Repository.AddProducts(p);
			return RedirectToAction("Index");
		}
	}
}
