using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository _repository;
        public AdminController(IProductRepository productRepository)
        {
            _repository = productRepository;
        }
        public IActionResult Index()
        {
            return View(_repository.Products);
        }
        public IActionResult Edit(int productId)
        {
            return View(_repository.Products.FirstOrDefault(p=>p.ProductId == productId));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                _repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public IActionResult Create() => View("Edit", new Product());

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product product = _repository.DeleteProduct(productId);
            if(product != null)
            {
                TempData["message"] = $"{product.Name} was deleted";
            }
            return RedirectToAction("Index");
        }
    }
}
