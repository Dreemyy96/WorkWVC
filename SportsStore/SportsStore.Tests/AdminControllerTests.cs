using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;

namespace SportsStore.Tests
{
    public class AdminControllerTests
    {
        [Fact]
        public void Index_Contains_All_Products()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p=>p.Products).Returns((new Product[]
            {
                new Product {ProductId = 1, Name = "P1"},
                new Product {ProductId = 2, Name = "P2"},
                new Product {ProductId = 3, Name = "P3"}
            }).AsQueryable());
            AdminController controller = new AdminController(mock.Object);

            Product[] result = GetViewModel<IEnumerable<Product>>(controller.Index()).ToArray();

            Assert.Equal(3, result.Length);
            Assert.Equal("P1", result[0].Name);
            Assert.Equal("P2", result[1].Name);
            Assert.Equal("P3", result[2].Name);
        }
        private T GetViewModel<T>(IActionResult result) where T : class
        {
            return (result as ViewResult)?.ViewData.Model as T;
        }

        [Fact]
        public void Can_Edit_Product()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository> ();
            mock.Setup(p => p.Products).Returns((new Product[]
            {
                new Product {ProductId = 1, Name = "P1" },
                new Product {ProductId = 2, Name = "P2" },
                new Product {ProductId = 3, Name = "P3" }
            }).AsQueryable<Product>());
            AdminController controller = new AdminController(mock.Object);

            Product p1 = GetViewModel<Product>(controller.Edit(1));
            Product p2 = GetViewModel<Product>(controller.Edit(2));
            Product p3 = GetViewModel<Product>(controller.Edit(3));

            Assert.Equal(1, p1.ProductId);
            Assert.Equal(2, p2.ProductId);
            Assert.Equal(3, p3.ProductId);
        }

        [Fact]
        public void Cannot_Edit_Nonexistent_Product()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Products).Returns((new Product[]
            {
                new Product {ProductId = 1, Name = "P1" },
                new Product {ProductId = 2, Name = "P2" },
                new Product {ProductId = 3, Name = "P3" }
            }).AsQueryable<Product>());
            AdminController controller = new AdminController(mock.Object);

            Product p4 = GetViewModel<Product>(controller.Edit(4));

            Assert.Null(p4);
        }

        [Fact]
        public void Can_Save_Valid_Changes()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            Mock<ITempDataDictionary> tempData = new Mock<ITempDataDictionary>();
            AdminController target = new AdminController(mock.Object)
            {
                TempData = tempData.Object
            };
            Product product = new Product { Name = "Test" };

            IActionResult result = target.Edit(product);

            mock.Verify(m => m.SaveProduct(product));
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", (result as RedirectToActionResult).ActionName);
        }

        [Fact]
        public void Cannot_Save_Invalid_Changes()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            AdminController target = new AdminController(mock.Object);
            Product product = new Product { Name = "Test" };
            target.ModelState.AddModelError("error", "error");

            IActionResult result = target.Edit(product);

            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Can_Delete_Valid_Products()
        {
            Product prod = new Product { Name = "Test", ProductId = 2 };
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[]
            {
                new Product { Name = "P1", ProductId = 1 },
                prod,
                new Product{Name = "P3", ProductId = 3}
            }).AsQueryable<Product>());
            AdminController target = new AdminController(mock.Object);

            target.Delete(prod.ProductId);

            mock.Verify(m => m.DeleteProduct(prod.ProductId));
        }
    }
}
