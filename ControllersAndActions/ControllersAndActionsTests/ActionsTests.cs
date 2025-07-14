using ControllersAndActions.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllersAndActionsTests
{
	public class ActionsTests
	{
		[Fact]
		public void ViewSelected()
		{
			HomeController controller = new HomeController();

			IActionResult result = controller.RecieveForm("Adam", "London");

			Assert.Equal("Result", ((ViewResult)result).ViewName);
		}

		[Fact]
		public void ModelObjectType()
		{
			ExampleController controller = new ExampleController();
			ViewResult result = (ViewResult)controller.Index();

			Assert.IsType<string>(result.ViewData["Message"]);
			Assert.Equal("Hello", result.ViewData["Message"]);
			Assert.IsType<System.DateTime>(result.ViewData["Data"]);
		}
	}
}
