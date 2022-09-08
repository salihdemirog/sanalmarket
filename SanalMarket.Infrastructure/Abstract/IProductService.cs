using SanalMarket.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalMarket.Infrastructure.Abstract
{
    public interface IProductService
    {
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetListByCategory(int categoryId);
        IEnumerable<Product> Search(string expression);
    }
}
