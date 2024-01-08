using KirilsShop.Data.Static;
using KirilsShop.Models;
using KirilsShop.Models.Order;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace KirilsShop.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
               _context = context;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var orders = await _context.Orders.Include(n => n.User).Include(n => n.OrderItems).ThenInclude(n => n.Car).ToListAsync();
            return orders;
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Car).ThenInclude(n => n.Brand).Where(n => n.UserId==userId).Include(n => n.User).ToListAsync();
            return orders;
        }

        public async Task StoreOrder(List<ShoppingCartItem> items, string userId, string Emailadress)
        {

            var order = new Order()
            {
                UserId = userId,
                Email = Emailadress
                
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    CarId = item.Car.id,
                    OrderId = order.Id,
                    Price = item.Car.Price
                };
                await _context.OrdersItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
