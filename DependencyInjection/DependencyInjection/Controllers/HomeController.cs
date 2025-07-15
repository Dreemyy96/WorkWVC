using Microsoft.AspNetCore.Mvc;
using DependencyInjection.Models;
using DependencyInjection.Infrastructure;

namespace DependencyInjection.Controllers
{
	public class HomeController : Controller
	{
		//private ProductTotalizer _productTotalizer;
		private IRepository _repository;
		public HomeController(IRepository repo/*, ProductTotalizer productTotalizer*/)
		{
			_repository = repo;
			//_productTotalizer = productTotalizer;
		}
		public IActionResult Index([FromServices] ProductTotalizer productTotalizer)
		{
			ViewBag.HomeController = _repository.ToString();
			ViewBag.ProductTotalizer = productTotalizer.Repository.ToString();
			ViewBag.Total = productTotalizer.Total;
			return View(_repository.Products);
		}
	}
}
