using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;

        public CartController(IProductRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                ReturnUrl = returnUrl,
                Cart = GetCart()
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId,
                string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            var cart = HttpContext.Session.GetString("Cart");
            Cart res = cart != null ? JsonSerializer.Deserialize<Cart>(cart) : null;
            return res;
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetString("Cart", JsonSerializer.Serialize(cart));
        }
    }
}
