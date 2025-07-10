using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository _repository;
        private Cart _cart;

        public CartController(IProductRepository repo, Cart cart)
        {
            _repository = repo;
            _cart = cart;
        }

        public IActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                ReturnUrl = returnUrl,
                Cart = _cart
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product? product = _repository.Products
                .FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                _cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId,
                string returnUrl)
        {
            Product? product = _repository.Products
                .FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                _cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
