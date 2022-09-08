using SanalMarket.Infrastructure.Abstract;
using SanalMarket.Infrastructure.Models;
using System.Text.Json;

namespace SanalMarket.Web.CartManagement
{
    public class SessionCartService : ICartService
    {
        private readonly ISession _session;
        private List<CartItem> _cart;

        public SessionCartService(IHttpContextAccessor contextAccessor)
        {
            _session = contextAccessor.HttpContext.Session;
            _cart = GetCartSession();
        }

        public decimal TotalPrice => _cart.Sum(t => t.Quantity * t.Product.UnitPrice);

        public int TotalQuantity => _cart.Sum(t => t.Quantity);

        public void Add(CartItem cartItem)
        {
            var addedItem = _cart.SingleOrDefault(t => t.Product.Id == cartItem.Product.Id);

            if (addedItem is null)
                _cart.Add(cartItem);
            else
                addedItem.Quantity += cartItem.Quantity;

            SetCartSession();
        }

        public void Clear()
        {
            _cart.Clear();

            SetCartSession();
        }

        public List<CartItem> GetMyCart()
        {
            return _cart;
        }

        public void Remove(int productId)
        {
            _cart.RemoveAll(t => t.Product.Id == productId);

            SetCartSession();
        }

        private void SetCartSession()
        {
            string cartJsonData = JsonSerializer.Serialize(_cart);
            _session.SetString("cart", cartJsonData);
        }

        private List<CartItem> GetCartSession()
        {
            string? cartJsonData = _session.GetString("cart");

            if (cartJsonData is null)
                return new List<CartItem>();

            return JsonSerializer.Deserialize<List<CartItem>>(cartJsonData);
        }
    }
}
