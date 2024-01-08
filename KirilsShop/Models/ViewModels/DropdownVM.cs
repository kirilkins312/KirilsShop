using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KirilsShop.Models.ViewModels
{
    public class DropdownVM
    {
        public int id { get; set; }
        
        public int BrandId { get; set; }
        [DisplayName("Brand:")]
        public string Brand { get; set; }
        

        public int ModelId { get; set; }
        [DisplayName("Model:")]
        public string Model { get; set; }

        
        public int YOPId { get; set; }
        [DisplayName("Year of production:")]
        public string YOP { get; set; }

        

        public int ColorId { get; set; }
        [DisplayName("Color:")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Perfomance is required")]
        [Range(5, 3500, ErrorMessage = "Perfomance must be between 2 and 4 characters")]

        public int Perfomance { get; set; }
        [Required(ErrorMessage = "Mileage is required")]
        [Range(0, 9999999, ErrorMessage = "Mileage must be between 1 and 7 characters")]

        public int Mileage { get; set; }

        
        public int FuelId { get; set; }
        [DisplayName("Fuel type:")]
        public string Fuel { get; set; }


        
        public int BodyId { get; set; }
        [DisplayName("Body type:")]
        public string Body { get; set; }


        [Required(ErrorMessage = "Description is required")]
        [StringLength(3000, MinimumLength = 300, ErrorMessage = "Description must be between 300 and 3000 characters")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(20000, 99999999, ErrorMessage = "Price must be between 5 and 9 characters")]
        public int Price { get; set; }
        [Required(ErrorMessage = "VIN is required")]
        [StringLength(17, MinimumLength =16, ErrorMessage = "VIN must be 17 characters")]
        public string VIN { get; set; }

        
        public int OriginId { get; set; }
        [DisplayName(@"Car's origin:")]
        public string Origin { get; set; }
    
        [Display(Name = "Choose the gallery images of your car")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryVM> Gallery { get; set; }


        [Display(Name = "Choose the cover photo of your car")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }
       
    }
}
