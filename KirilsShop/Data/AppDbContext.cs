using KirilsShop.Models.Categories.ImageCat;
using KirilsShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KirilsShop.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Car> Car { get; set; } = default!;
        public DbSet<CarGallery> CarGallery { get; set; } = default!;
        public DbSet<Models.Categories.Model> CarModels { get; set; } = default!;
        public DbSet<Models.Categories.Brand> CarBrands { get; set; } = default!;
        public DbSet<Models.Categories.YearOfProduction> CarYOPs { get; set; } = default!;
        public DbSet<Models.Categories.Origin> CarOrigins { get; set; } = default!;  
        public DbSet<Models.Categories.Fuel> CarFuels { get; set; } = default!;
        public DbSet<Models.Categories.Body> CarBodys { get; set; } = default!;
        public DbSet<Models.Categories.Colour> CarColors { get; set; } = default!;

        /// <summary>
        /// /////////////////Orders
        /// </summary>

        public DbSet<Models.Order.Order> Orders{ get; set; } = default!;
        public DbSet<Models.Order.OrderItem> OrdersItems { get; set; } = default!;
        public DbSet<Models.Order.ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

    }
}
