using Cities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cities.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        public HomeController(IRepository rep)
        {
            _repository = rep;
        }
        public IActionResult Index()
        {
            return View(_repository.Cities);
        }
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(City city)
        {
            _repository.AddCity(city);
            return RedirectToAction(nameof(Index));
        }
    }
}
