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
		//[Fact]
		//public void Redirection()
		//{
		//	ExampleController controller = new ExampleController();

		//	//RedirectToRouteResult res = controller.Redirect();

		//	//Assert.False(res.Permanent);
		//	//Assert.Equal("Example", res.RouteValues["controller"]);
		//	//Assert.Equal("Index", res.RouteValues["action"]);
		//	//Assert.Equal("MyID", res.RouteValues["id"]);

		//	RedirectToActionResult res = controller.Redirect();

		//	Assert.False(res.Permanent);
		//	Assert.Equal("Index", res.ActionName);
		//}

		public void JsonActionMethod()
		{
			ExampleController controller = new ExampleController();
			JsonResult res = controller.Index() as JsonResult;
			Assert.Equal(new[] { "Alice", "Bob", "Joe" }, res?.Value);
		}
	}
}
