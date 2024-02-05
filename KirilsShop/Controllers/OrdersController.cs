using KirilsShop.Data;
using KirilsShop.Data.Services;
using KirilsShop.Models;
using KirilsShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace KirilsShop.Controllers
{
    public class OrdersController : Controller
    {
        
        private readonly ICarService _carService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _orderSerivce;

        public OrdersController(ICarService carService, ShoppingCart shoppingCart, IOrdersService orderSerivce)
        {
            _shoppingCart = shoppingCart;
            _carService = carService;
            _orderSerivce = orderSerivce;
        }

       

        //public IActionResult Index()
        //{
        //    var items =  _shoppingCart.GetShoppingCartItems();
           

        //    return View(items);
        //}

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                shoppingCart = _shoppingCart,
                shoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemsToCart(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("AuthenticationError");
            }
            else
            {
                var item = await _carService.GetByIdAsync(id);

                if (item != null)
                {
                    _shoppingCart.AddItemToCard(item);
                }
                return RedirectToAction(nameof(ShoppingCart));
            }
            
        }

        public async Task<IActionResult> RemoveItemFromCart(int id)
        {
            var items =  _shoppingCart.GetShoppingCartItems();
            var entity = await _carService.GetByIdAsync(id);

            if (items != null)
            {
                  _shoppingCart.RemoveItemFromCart(entity);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }


        public async Task<IActionResult> OrdersList()
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _orderSerivce.GetOrdersByUserIdAsync(userId, userRole);
            
            if (User.IsInRole("Admin"))
            {
                orders = await _orderSerivce.GetOrdersAsync();
                return View(orders);
            }
                
           
            return View(orders);


        }

        public async Task <IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string Emailadress = User.FindFirstValue(ClaimTypes.Email);

            await _orderSerivce.StoreOrder(items, userId, Emailadress);
            await _shoppingCart.ClearShoppingCartAsync();   
            return View("OrderCompleted");
        }



    }
}
