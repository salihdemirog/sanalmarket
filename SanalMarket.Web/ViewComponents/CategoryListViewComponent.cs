using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Primitives;
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

            int? activeCategoryId = null;
            var hasQuery = HttpContext.Request.Query.TryGetValue("categoryId", out StringValues values);
            if (hasQuery)
                activeCategoryId = int.Parse(values);

            var model = new CategoryListViewModel
            {
                Categories = categories,
                ActiveCategoryId = activeCategoryId
            };

            return View(model);
        }
    }
}
