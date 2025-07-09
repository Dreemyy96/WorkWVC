using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository _repository;
        public NavigationMenuViewComponent(IProductRepository rep)
        {
            _repository = rep;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
    }
}
