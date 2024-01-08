
using KirilsShop.Models.Categories;
using KirilsShop.Models.Categories.ImageCat;
using KirilsShop.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace KirilsShop.Models
{
    public class Car
    {
        public int id { get; set; }
        [DisplayName("Brand:")]
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }
        [DisplayName("Model:")]
        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public Model Model { get; set; }
        [DisplayName("Year of production:")]
        public int YOPId { get; set; }
        [ForeignKey("YOPId")]
        public YearOfProduction YearOfProduction { get; set; }
        [DisplayName("Color:")]
        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public Colour Color { get; set; }

        [Required(ErrorMessage = "Perfomance is required")]
        [Range(5, 3500, ErrorMessage = "Perfomance must be between 2 and 4 characters")]
        public int Performance { get; set; }
        [Required(ErrorMessage = "Mileage is required")]
        [Range(0, 9999999, ErrorMessage = "Mileage must be between 1 and 7 characters")]
        public int Mileage { get; set; }
        [DisplayName("Fuel type:")]
        public int FuelId { get; set; }
        [ForeignKey("FuelId")]
        public Fuel Fuel { get; set; }
        [DisplayName("Body type:")]
        public int BodyId { get; set; }
        [ForeignKey("BodyId")]
        public Body Body { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(3000, MinimumLength = 300, ErrorMessage = "Description must be between 300 and 3000 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(20000, 99999999, ErrorMessage = "Price must be between 5 and 9 characters")]
        public int Price { get; set; }
        [Required(ErrorMessage = "VIN is required")]
        [StringLength(17, ErrorMessage = "VIN must be 17 characters")]
        public string VIN { get; set; }
        [DisplayName("Car's origin:")]
        public int OriginId { get; set; }
        [ForeignKey("OriginId")]
        public Origin Origin { get; set; }
       
        public string CoverImageUrl { get; set; }

        public ICollection<CarGallery> CarGallery { get; set; }
       

    }
}
