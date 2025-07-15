using Filters.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
	//[HttpsOnly]
	//[Profile]
	//[ViewResultDetails]
	//[RangeException]
	[TypeFilter(typeof(DiagnosticsFilter))]
	[TypeFilter(typeof(TimeFilter))]
    public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View("Message", "This is the Index action on the Home controller");	
		}

		public IActionResult SecondAction()
		{
            return View("Message", "This is the SecondAction action on the Home controller");
        }
		public IActionResult GenerateException(int? id)
		{
			if(id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}else if(id > 10)
			{
				throw new ArgumentOutOfRangeException(nameof(id));
			}
			else
			{
				return View("Message", $"The value is {id}");
			}
		}
	}
}
