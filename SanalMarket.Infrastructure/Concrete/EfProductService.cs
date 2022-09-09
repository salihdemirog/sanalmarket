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

        public void Delete(int id)
        {
            var product = GetById(id);

            _context.Products.Remove(product);

            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _context.Products.SingleOrDefault(t => t.Id == id);
        }

        public IEnumerable<Product> GetListByCategory(int categoryId)
        {
            return _context.Products.Where(t => t.CategoryId == categoryId).ToList();
        }

        public Product Insert(Product product)
        {
            _context.Products.Add(product);

            _context.SaveChanges();

            return product;
        }

        public IEnumerable<Product> Search(string expression)
        {
            return _context.Products.Where(t => t.Name.Contains(expression)).ToList();
        }

        public void Update(Product product)
        {
            var entry = _context.Entry(product);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
