using DependencyInjection.Controllers;
using DependencyInjection.Infrastructure;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.Tests
{
	public class DITests
	{
		[Fact]
		public void ControllerTest()
		{
			Mock<IRepository> rep = new Mock<IRepository>();
			rep.SetupGet(r=>r.Products).Returns(new List<Product>()
			{
				new Product{Name="Test", Price = 100M}
			});
			HomeController controller = new HomeController(rep.Object, new ProductTotalizer(rep.Object));

			ViewResult res = controller.Index() as ViewResult;

			Assert.Equal(rep.Object.Products, res?.ViewData.Model);
		}
	}
}
