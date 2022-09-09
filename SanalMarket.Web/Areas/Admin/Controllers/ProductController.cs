using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SanalMarket.Infrastructure.Abstract;
using SanalMarket.Infrastructure.Entities;

namespace SanalMarket.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
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

        //[Authorize]
        public IActionResult Insert()
        {
            var model = new ProductSaveViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()
            };

            return View("Save", model);
        }

        //[Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Insert(Product product)
        {
            _productService.Insert(product);

            return RedirectToAction("Index");
        }


        public IActionResult Update(int productId)
        {
            var product = _productService.GetById(productId);

            var model = new ProductSaveViewModel
            {
                Product = product,
                Categories = _categoryService.GetAll()
            };

            return View("Save", model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Update(Product product)
        {
            _productService.Update(product);

            return RedirectToAction("Index");
        }
    }
}
