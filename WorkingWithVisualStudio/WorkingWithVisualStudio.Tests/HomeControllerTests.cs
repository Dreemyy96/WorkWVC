using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; set; }

            public void AddProducts(Product p)
            {

            }
        }
        [Theory]
        //[InlineData(275, 48.95, 19.50, 24.95)]
        //[InlineData(5, 48.95, 19.50, 24.95)]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsComplete(Product[] products)
        {
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository() {Products = products};

            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

        class ModeleCompleteFakeRepositoryUnder50 : IRepository
        {
            public IEnumerable<Product> Products => new Product[]
            {
                new Product (){ Name = "P1", Price = 5M},
                new Product (){ Name = "P2", Price = 48.95M},
                new Product (){ Name = "P3", Price = 19.50M},
                new Product (){ Name = "P4", Price = 34.95M},
            };

            public void AddProducts(Product p)
            {

            }
        }
        [Fact]
        public void IndexActionModelIsCompletePricesUnder50()
        {
            var controller = new HomeController();
            controller.Repository = new ModeleCompleteFakeRepositoryUnder50();

            var model = (controller.Index() as ViewResult)?.ViewData?.Model as IEnumerable<Product>;

            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}
