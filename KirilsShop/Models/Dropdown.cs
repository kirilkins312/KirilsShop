using KirilsShop.Models.Categories;
using System.Drawing;

namespace KirilsShop.Models
{
    public class Dropdown
    {
        public Dropdown()
        {
            CarModels = new List<Model>();
            CarBrands = new List<Brand>();
            CarColor = new List<Colour>();
            CarBodys = new List<Body>();
            CarYops = new List<YearOfProduction>();   
            CarOrigin = new List<Origin>();
            CarFuel = new List<Fuel>();

        }

        public List<Model> CarModels { get; set; }
        public List<Brand> CarBrands { get; set; }
        public List<Colour> CarColor { get; set; }
        public List<Body> CarBodys { get; set; }
        public List<YearOfProduction> CarYops { get; set; }
        public List<Origin> CarOrigin { get; set; }
        public List<Fuel> CarFuel { get; set; }

    }
}
