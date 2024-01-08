using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KirilsShop.Models.Order
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int Price{ get; set; }
        public int Amount { get; set; }
        public int CarId{ get; set; }
        [ForeignKey("CarId")]
        public Car Car{ get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order{ get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
