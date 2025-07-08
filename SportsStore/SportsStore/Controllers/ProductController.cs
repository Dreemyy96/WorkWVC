using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
	public class ProductController : Controller
	{
		private IProductRepository _repository;
		public int PageSize = 4;
        public ProductController(IProductRepository repo)
        {
            _repository = repo;
        }
        public IActionResult List(int productPage = 1)
		{
			return View(new ProductsListViewModel
			{
				Products = _repository.Products.OrderBy(p => p.ProductId).Skip((productPage - 1) * PageSize).Take(PageSize),
				PagingInfo = new PagingInfo { CurrentPage = productPage, ItemsPerPage = PageSize, TotalItems = _repository.Products.Count() }
			});
		}
	}
}
