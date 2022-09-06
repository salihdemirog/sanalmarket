using SanalMarket.Infrastructure.Abstract;
using SanalMarket.Infrastructure.Contexts;
using SanalMarket.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalMarket.Infrastructure.Concrete
{
    public class EfProductService : IProductService
    {
        private readonly NorthwindContext _context;
        public EfProductService(NorthwindContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetListByCategory(int categoryId)
        {
            return _context.Products.Where(t => t.CategoryId == categoryId).ToList();
        }

        public IEnumerable<Product> Search(string expression)
        {
            return _context.Products.Where(t => t.Name.Contains(expression)).ToList();
        }
    }
}
