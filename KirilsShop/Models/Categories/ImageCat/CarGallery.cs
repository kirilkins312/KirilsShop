namespace KirilsShop.Models.Categories.ImageCat
{
    public class CarGallery
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public Car Car { get; set; }
    }
}
