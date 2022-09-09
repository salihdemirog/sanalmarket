using SanalMarket.Infrastructure.Entities;

namespace SanalMarket.Web.Areas.Admin
{
    public class ProductIndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}