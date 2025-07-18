using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using UsingViewComponents.Components;
using UsingViewComponents.Models;

namespace UsingViewComponents.Tests
{
    public class SummaryViewComponentTests
    {
        [Fact]
        public void TestSummary()
        {
            var mock = new Mock<ICityRepository>();
            mock.SetupGet(m => m.Cities).Returns(new List<City> {
                new City { Population = 100 },
                new City { Population = 20000 },
                new City { Population = 1000000 },
                new City { Population = 500000 }
            });
            CitySummary viewComponent = new CitySummary(mock.Object);
            ViewViewComponentResult res = viewComponent.Invoke(false) as ViewViewComponentResult;

            Assert.IsType(typeof(CityViewModel), res.ViewData.Model);
            Assert.Equal(4, (res.ViewData.Model as CityViewModel)?.Cities);
            Assert.Equal(1520100, (res.ViewData.Model as CityViewModel)?.Population);
        }
    }
}
