using KirilsShop.Data.Static;
using KirilsShop.Models;
using KirilsShop.Models.Order;

namespace KirilsShop.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrder(List<ShoppingCartItem> items, string userId, string Emailadress);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId, string userRole);
        Task<List<Order>> GetOrdersAsync();
    }
}
