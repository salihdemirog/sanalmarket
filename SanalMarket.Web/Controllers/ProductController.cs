using Microsoft.AspNetCore.Mvc;
using SanalMarket.Infrastructure.Abstract;

namespace SanalMarket.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetAll();

            var model = new ProductIndexViewModel
            {
                Products = products
            };

            return View(model);
        }
    }
}
