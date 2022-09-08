using SanalMarket.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanalMarket.Infrastructure.Abstract
{
    public interface ICartService
    {
        void Add(CartItem cartItem);

        void Remove(int productId);

        void Clear();

        List<CartItem> GetMyCart();

        public decimal TotalPrice { get; }

        public int TotalQuantity { get; }
    }
}
