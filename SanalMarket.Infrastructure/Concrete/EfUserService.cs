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
    public class EfUserService : IUserService
    {
        private readonly NorthwindContext _context;
        public EfUserService(NorthwindContext context)
        {
            _context = context;
        }

        public User Login(string mail, string password)
        {
            return _context.Users.SingleOrDefault(t => t.Mail == mail && t.Password == password);
        }
    }
}
