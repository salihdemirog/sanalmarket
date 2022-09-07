using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SanalMarket.Infrastructure.Abstract;

namespace SanalMarket.Web.ViewComponents
{
    //[ViewComponent(Name ="category-list")]
    public class CategoryListViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryListViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<ViewViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllAsync();

            var model = new CategoryListViewModel
            {
                Categories = categories
            };

            return View(model);
        }
    }
}
