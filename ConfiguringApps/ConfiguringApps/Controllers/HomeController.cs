using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService _uptimeService;
        private ILogger<HomeController> _logger;

        public HomeController(UptimeService uptime, ILogger<HomeController> logger)
        {
            _uptimeService = uptime;
            _logger = logger;
        }
        public IActionResult Index(bool throwException = false)
        {
            _logger.LogInformation($"Handled {Request.Path} at uptime {_uptimeService.Uptime}");
            if(throwException)
            {
                throw new NullReferenceException();
            }
            return View(new Dictionary<string, string>()
            {
                ["Message"] = "This is the Index action",
                ["Uptime"] = $"{_uptimeService.Uptime}ms"
            });
        }

        public IActionResult Error() => View(nameof(Index), new Dictionary<string, string>
        {
            ["Message"] = "This is the Error action"
        });
    }
}
