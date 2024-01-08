
using Humanizer;
using KirilsShop.Models;
using KirilsShop.Models.Categories;
using KirilsShop.Models.Categories.ImageCat;
using KirilsShop.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Linq.Expressions;

namespace KirilsShop.Data.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarService(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        public async Task AddAsync(DropdownVM data)
        {
            if (data.CoverPhoto != null)
            {
                string folder = "Images/cover/";
                data.CoverImageUrl = await UploadImage(folder, data.CoverPhoto);
            }

            if (data.GalleryFiles != null)
            {
                string folder = "Images/gallery/";

                data.Gallery = new List<GalleryVM>();

                foreach (var file in data.GalleryFiles)
                {
                    var gallery = new GalleryVM()
                    {
                        Name = file.FileName,
                        URL = await UploadImage(folder, file)
                    };
                    data.Gallery.Add(gallery);
                }
            }

            var newCar = new Car()
            {
                BrandId = data.BrandId,
                ModelId = data.ModelId,
                Description = data.Description,
                YOPId = data.YOPId,
                BodyId = data.BodyId,
                ColorId = data.ColorId,
                FuelId = data.FuelId,
                CoverImageUrl = data.CoverImageUrl,
                OriginId = data.OriginId,
                Performance = data.Perfomance,
                Mileage = data.Mileage,
                VIN = data.VIN,
                Price = data.Price,
            };

            newCar.CarGallery = new List<CarGallery>();
            foreach (var file in data.Gallery)
            {
                newCar.CarGallery.Add(new CarGallery()
                {
                    Name = file.Name,
                    URL = file.URL,
                });
            }

            await _context.Car.AddAsync(newCar);
            await _context.SaveChangesAsync();


        }

        public async Task DeleteAsync(int id)
        {

            var entity =  _context.Car.FirstOrDefault(x => x.id == id);
            if (entity != null)
            {
                 _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Car>> GetAllAsync()
        {
            var data = await _context.Car.Include(c => c.Body).Include(c => c.Brand).Include(c => c.Color).Include(c => c.Fuel).Include(c => c.Model).Include(c => c.Origin).Include(c => c.YearOfProduction).ToListAsync();
            return data;
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            var data =  _context.Car.Include(c => c.Body)
                .Include(c => c.Brand)
                .Include(c => c.Color)
                .Include(c => c.Fuel)
                .Include(c => c.Model)
                .Include(c => c.Origin)
                .Include(c => c.YearOfProduction)
                .Include(c => c.CarGallery).FirstOrDefault(x => x.id == id);
            return data;
        }

        public async Task UpdateAsync(DropdownVM data,int id)
        {
            var entity = _context.Car.FirstOrDefault(x => x.id == id);
            if (entity != null)
            {
                entity.BrandId = data.BrandId;
                entity.ModelId = data.ModelId;
                entity.Description = data.Description;
                entity.YOPId = data.YOPId;
                entity.BodyId = data.BodyId;
                entity.ColorId = data.ColorId;
                entity.FuelId = data.FuelId;
                entity.CoverImageUrl = data.CoverImageUrl;
                entity.OriginId = data.OriginId;
                entity.Performance = data.Perfomance;
                entity.Mileage = data.Mileage;
                entity.VIN = data.VIN;
                entity.Price = data.Price;
                    
                await _context.SaveChangesAsync();
            }
            
            


        }
        public async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        public async Task<List<T>> GetAllObjectsAsync<T>() where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            return await query.ToListAsync();
        }
        public async Task<List<T>> GetObjectAsync<T>() where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            return await query.ToListAsync();
        }

        public async Task<List<T>> GetCategoryObjectsAsync<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            IQueryable<T> query = _context.Set<T>();
            return await query.Where(predicate).ToListAsync();
        }
      
    }
}
