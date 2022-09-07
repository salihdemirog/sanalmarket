using SanalMarket.Infrastructure.Entities;

namespace SanalMarket.Web
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; }
        public int? ActiveCategoryId { get; set; }
    }
}