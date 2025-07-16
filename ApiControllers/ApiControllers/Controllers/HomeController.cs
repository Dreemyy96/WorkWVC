using ApiControllers.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiControllers.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;
        public HomeController(IRepository repo)
        {
            _repository = repo;
        }
        public IActionResult Index()
        {
            return View(_repository.Reservations);
        }
        [HttpPost]
        public IActionResult AddReservation(Reservation res)
        {
            _repository.AddReservation(res);
            return RedirectToAction("Index");
        }
    }
}
