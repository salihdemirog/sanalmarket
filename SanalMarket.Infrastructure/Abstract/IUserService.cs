using SanalMarket.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalMarket.Infrastructure.Abstract
{
    public interface IUserService
    {
        User Login(string mail, string password);
    }
}
