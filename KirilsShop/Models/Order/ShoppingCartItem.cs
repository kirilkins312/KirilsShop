using System.ComponentModel.DataAnnotations;

namespace KirilsShop.Models.Order
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Car Car { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
