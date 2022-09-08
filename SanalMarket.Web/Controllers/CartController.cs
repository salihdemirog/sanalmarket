using Microsoft.AspNetCore.Mvc;
using SanalMarket.Infrastructure.Abstract;
using SanalMarket.Infrastructure.Models;

namespace SanalMarket.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IProductService _productService;

        public CartController(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCart(int productId)
        {
            var product = _productService.GetById(productId);
            if (product == null)
                return NotFound();

            var cartItem = new CartItem
            {
                Product = product,
                Quantity = 1
            };

            _cartService.Add(cartItem);

            return ViewComponent("CartSummary");
        }

        public IActionResult RemoveFromCart(int productId)
        {
            _cartService.Remove(productId);

            return RedirectToAction("Index", "Product");
        }
    }
}
