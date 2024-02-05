using KirilsShop.Models.Categories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace KirilsShop.Models.ViewModels
{
    public class FilterVM
    {

        
        public List<int>? SelectedBrands { get; set; }
        public List<Brand>? BrandList{ get; set; }
        public List<int>? SelectedModels { get; set; }
        public List<Model>? ModelList { get; set; }
        public List<int>? SelectedBodies { get; set; }
        public List<Body>? BodyList { get; set; }
        public List<int>? SelectedFuels { get; set; }
        public List<Fuel>? FuelList { get; set; }
        public List<int>? SelectedColors { get; set; }
        public List<Colour>? ColorList { get; set; }
        public List<int>? SelectedOrigins { get; set; }
        public List<Origin>? OriginList { get; set; }
        public List<int>? SelectedYOPs { get; set; }
        public List<YearOfProduction>? YOPList{ get; set; }
        public List<Car>? Cars { get; set; }
        public List<Car>? FilteredCars { get; set; }
    }
}
    