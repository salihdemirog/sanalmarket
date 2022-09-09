using SanalMarket.Infrastructure.Entities;

namespace SanalMarket.Web.Areas.Admin
{
    public class ProductSaveViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Categories { get; internal set; }
    }
}