using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService _uptimeService;

        public HomeController(UptimeService uptime)
        {
            _uptimeService = uptime;
        }
        public IActionResult Index()
        {
            return View(new Dictionary<string, string>()
            {
                ["Message"] = "This is the Index action",
                ["Uptime"] = $"{_uptimeService.Uptime}ms"
            });
        }
    }
}
