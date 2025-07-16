using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    public class GlobalController : Controller
    {
        public IActionResult Index()
        {
            return View("Message", "This is the global controller");
        }
    }
}
