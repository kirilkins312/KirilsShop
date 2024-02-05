
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

        List<Car> ICarService.GetFilteredCarList(FilterVM model)
        {
            var brands = _context.CarBrands.ToList();
            var models = _context.CarModels.ToList();
            var bodies = _context.CarBodys.ToList();
            var colors = _context.CarColors.ToList();
            var fuels = _context.CarFuels.ToList();
            var origins = _context.CarOrigins.ToList();
            var yearsOfProduction = _context.CarYOPs.ToList();
            var cars = _context.Car.Include(c => c.Body)
                .Include(c => c.Brand)
                .Include(c => c.Color)
                .Include(c => c.Fuel)
                .Include(c => c.Model)
                .Include(c => c.Origin)
                .Include(c => c.YearOfProduction)
                .Include(c => c.CarGallery).ToList() ;
            









            List<Car> cars1 = new List<Car>();

            if (model.SelectedBrands != null)
            {
                foreach (var categoryId in model.SelectedBrands)
                {
                    var selectedCategory = _context.CarBrands.Find(categoryId);
                    if (selectedCategory != null)
                    {
                        var filteredCars = cars.Where(b => b.BrandId == categoryId).ToList();

                        //Cheking selected categories ids and filtering list
                        foreach (var car in filteredCars)
                        {
                            if (!cars1.Any(c => c.id == car.id))
                            {
                                cars1.Add(car);
                            }
                        }
                    }
                }
                cars = cars1;
               
            }

            if (model.SelectedModels != null)
            {
                foreach (var categoryId in model.SelectedModels)
                {
                    var selectedCategory = _context.CarModels.Find(categoryId);
                    if (selectedCategory != null)
                    {
                        var filteredCars = cars.Where(b => b.ModelId == categoryId).ToList();
                        
                        //Cheking selected categories ids and filtering list
                       foreach (var car in filteredCars)
                        {
                            if (!cars1.Any(c => c.id == car.id))
                            {
                                cars1.Add(car);
                            }
                        }
                    }
                }
                cars = cars1;
                
            }

            if (model.SelectedBodies != null)
            {
                foreach (var categoryId in model.SelectedBodies)
                {
                    var selectedCategory = _context.CarBodys.Find(categoryId);
                    if (selectedCategory != null)
                    {
                        var filteredCars = cars.Where(b => b.BodyId == categoryId).ToList();

                        //Cheking selected categories ids and filtering list
                        foreach (var car in filteredCars)
                        {
                            if (!cars1.Any(c => c.id == car.id))
                            {
                                cars1.Add(car);
                            }
                        }
                    }
                }
                cars = cars1;

            }
            if (model.SelectedColors != null)
            {
                foreach (var categoryId in model.SelectedColors)
                {
                    var selectedCategory = _context.CarColors.Find(categoryId);
                    if (selectedCategory != null)
                    {
                        var filteredCars = cars.Where(b => b.ColorId == categoryId).ToList();

                        //Cheking selected categories ids and filtering list
                        foreach (var car in filteredCars)
                        {
                            if (!cars1.Any(c => c.id == car.id))
                            {
                                cars1.Add(car);
                            }
                        }
                    }
                }
                cars = cars1;

            }
            if (model.SelectedFuels != null)
            {
                foreach (var categoryId in model.SelectedFuels)
                {
                    var selectedCategory = _context.CarFuels.Find(categoryId);
                    if (selectedCategory != null)
                    {
                        var filteredCars = cars.Where(b => b.FuelId == categoryId).ToList();

                        //Cheking selected categories ids and filtering list
                        foreach (var car in filteredCars)
                        {
                            if (!cars1.Any(c => c.id == car.id))
                            {
                                cars1.Add(car);
                            }
                        }
                    }
                }
                cars = cars1;

            }
            if (model.SelectedOrigins != null)
            {
                foreach (var categoryId in model.SelectedOrigins)
                {
                    var selectedCategory = _context.CarOrigins.Find(categoryId);
                    if (selectedCategory != null)
                    {
                        var filteredCars = cars.Where(b => b.OriginId == categoryId).ToList();

                        //Cheking selected categories ids and filtering list
                        foreach (var car in filteredCars)
                        {
                            if (!cars1.Any(c => c.id == car.id))
                            {
                                cars1.Add(car);
                            }
                        }
                    }
                }
                cars = cars1;

            }
            if (model.SelectedYOPs != null)
            {
                foreach (var categoryId in model.SelectedYOPs)
                {
                    var selectedCategory = _context.CarYOPs.Find(categoryId);
                    if (selectedCategory != null)
                    {
                        var filteredCars = cars.Where(b => b.YOPId == categoryId).ToList();

                        //Cheking selected categories ids and filtering list
                        foreach (var car in filteredCars)
                        {
                            if (!cars1.Any(c => c.id == car.id))
                            {
                                cars1.Add(car);
                            }
                        }
                    }
                }
                cars = cars1;

            }

            return cars;

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

            var entity = _context.Car.FirstOrDefault(x => x.id == id);
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
            var data = _context.Car.Include(c => c.Body)
                .Include(c => c.Brand)
                .Include(c => c.Color)
                .Include(c => c.Fuel)
                .Include(c => c.Model)
                .Include(c => c.Origin)
                .Include(c => c.YearOfProduction)
                .Include(c => c.CarGallery).FirstOrDefault(x => x.id == id);
            return data;
        }

        public async Task UpdateAsync(DropdownVM data, int id)
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
