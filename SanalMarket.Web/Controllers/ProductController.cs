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

        public IActionResult Index(int? categoryId)
        {
            var products = categoryId.HasValue
                ? _productService.GetListByCategory(categoryId.Value)
                : _productService.GetAll();

            var model = new ProductIndexViewModel
            {
                Products = products
            };

            return View(model);
        }

        public IActionResult Search([FromQuery]string q)
        {
            var model = new ProductIndexViewModel
            {
                Products = _productService.Search(q),
            };

            ViewData["SearchExp"] = q;
            //ViewBag.SearchExp = q;

            //TempData["SearchExp"] = q;

            return View("Index", model);
        }
    }
}
