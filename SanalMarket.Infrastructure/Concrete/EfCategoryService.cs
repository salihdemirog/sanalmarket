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
    public class EfCategoryService : ICategoryService
    {
        private readonly NorthwindContext _context;

        public EfCategoryService(NorthwindContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
