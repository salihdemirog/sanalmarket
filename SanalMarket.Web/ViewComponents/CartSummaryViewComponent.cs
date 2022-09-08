using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SanalMarket.Infrastructure.Abstract;

namespace SanalMarket.Web.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly ICartService _cartService;

        public CartSummaryViewComponent(ICartService cartService)
        {
            _cartService = cartService;
        }

        public ViewViewComponentResult Invoke()
        {
            var model = new CartSummaryViewModel
            {
                TotalQuantity=_cartService.TotalQuantity,
                TotalPrice=_cartService.TotalPrice
            };

            return View(model);
        }
    }
}
