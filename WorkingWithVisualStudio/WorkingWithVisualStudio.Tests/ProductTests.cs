using WorkingWithVisualStudio.Models;
namespace WorkingWithVisualStudio.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductName()
        {
            var prod = new Product() { Name = "Test", Price = 100M };

            prod.Name = "New Name";

            Assert.Equal("New Name", prod.Name);
        }

        [Fact]
        public void CanChangeProductPrice()
        {
            var prod = new Product() { Name = "Test", Price = 100M };

            prod.Price = 200M;

            Assert.Equal(200M, prod.Price);
        }
    }
}
