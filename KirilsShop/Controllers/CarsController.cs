using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KirilsShop.Data;
using KirilsShop.Models;
using KirilsShop.Models.Categories;
using System.Net;
using KirilsShop.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using KirilsShop.Models.Categories.ImageCat;
using KirilsShop.Data.Services;
using Microsoft.AspNetCore.Authorization;
using KirilsShop.Data.Static;

namespace KirilsShop.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CarsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICarService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarsController(ICarService service, IWebHostEnvironment webHostEnvironment, AppDbContext context)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;   
            _context = context;
         
        }


        [AllowAnonymous]
        // GET: Cars
        public async Task<IActionResult> Index()
        {

            var cars = await _service.GetAllAsync();
           

            var brands = await _context.CarBrands.ToListAsync();
            var models = await _context.CarModels.ToListAsync();
            var bodies = await _context.CarBodys.ToListAsync();
            var colors = await _context.CarColors.ToListAsync();
            var fuel = await _context.CarFuels.ToListAsync();
            var origins = await _context.CarOrigins.ToListAsync();
            var YOPs = await _context.CarYOPs.ToListAsync();

            var filterVM = new FilterVM()
            {
                BrandList= brands,
                ModelList= models,
                BodyList=bodies,
                ColorList= colors,
                FuelList= fuel,
                OriginList= origins,
                YOPList= YOPs,
                Cars = cars,
                
            };

            if (cars == null || brands == null || models == null|| bodies == null || colors == null||fuel == null || origins== null||YOPs== null )
            {
                return NotFound();
            }

            
            return View(filterVM);

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(FilterVM filterVM)
        {

            var cars = await _service.GetAllAsync();


            var brands = await _service.GetAllObjectsAsync<Brand>();
            var models = await _service.GetAllObjectsAsync<Model>();
            var bodies = await _service.GetAllObjectsAsync<Body>();
            var colors = await _service.GetAllObjectsAsync<Colour>();
            var fuel = await _service.GetAllObjectsAsync<Fuel>();
            var origins = await _service.GetAllObjectsAsync<Origin>();
            var YOPs = await _service.GetAllObjectsAsync<YearOfProduction>();

            if (cars == null || brands == null || models == null || bodies == null || colors == null || fuel == null || origins == null || YOPs == null)
            {
                return NotFound();
            }


            var filteredListCars = _service.GetFilteredCarList(filterVM);
            


            filterVM.BrandList = brands;
            filterVM.ModelList = models;
            filterVM.BodyList= bodies;
            filterVM.ColorList = colors;
            filterVM.FuelList= fuel;
            filterVM.OriginList = origins;
            filterVM.YOPList= YOPs; 
            filterVM.Cars= filteredListCars;

            return View(filterVM);


        }



        public async Task<IActionResult> CreateView()
        {
            return View();
        }

        [AllowAnonymous]

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _service.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            var car = await _service.GetByIdAsync(id);
            var carVM = new CarVM();

            if (car != null)
            {



                carVM.Brand = car.Brand.Name;
                carVM.Model = car.Model.Name;
                carVM.Color = car.Color.Name;
                carVM.YOP = car.YearOfProduction.Name;
                carVM.Price = car.Price;
                carVM.Mileage = car.Mileage;
                carVM.Description = car.Description;
                carVM.Perfomance = car.Performance;
                carVM.VIN = car.VIN;
                carVM.Fuel = car.Fuel.Name;
                carVM.Body = car.Body.Name;
                carVM.Origin = car.Origin.Name;
                carVM.CoverImageUrl = car.CoverImageUrl;
                carVM.Gallery = car.CarGallery.Select(x => new GalleryVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                    URL = x.URL
                }).ToList();

            }
            else { return NotFound(); }


            return View(carVM);
        }

        // GET: Cars/Create
        public async Task<ViewResult> Create()
        {
            var dropDown = new Dropdown()
            {
                CarBrands = await _service.GetAllObjectsAsync<Brand>(),
                CarModels = await _service.GetAllObjectsAsync<Model>(),
                CarYops = await _service.GetAllObjectsAsync<YearOfProduction>(),
                CarBodys = await _service.GetAllObjectsAsync<Body>(),
                CarColor = await _service.GetAllObjectsAsync<Colour>(),
                CarFuel = await _service.GetAllObjectsAsync<Fuel>(),
                CarOrigin = await _service.GetAllObjectsAsync<Origin>(),



            };

            var carDropdown = dropDown;

            ViewBag.CarBrands = new SelectList(carDropdown.CarBrands, "Id", "Name");
            ViewBag.CarModels = new SelectList(carDropdown.CarModels, "Id", "Name");
            ViewBag.CarYops = new SelectList(carDropdown.CarYops, "Id", "Name");
            ViewBag.CarBodys = new SelectList(carDropdown.CarBodys, "Id", "Name");
            ViewBag.CarColor = new SelectList(carDropdown.CarColor, "Id", "Name");
            ViewBag.CarFuel = new SelectList(carDropdown.CarFuel, "Id", "Name");
            ViewBag.CarOrigin = new SelectList(carDropdown.CarOrigin, "Id", "Name");

            var model = new DropdownVM();

            return View(model);
        }
    

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DropdownVM data)
        {
            var dropDown = new Dropdown()
            {
                CarBrands = await _service.GetAllObjectsAsync<Brand>(),
                CarModels = await _service.GetAllObjectsAsync<Model>(),
                CarYops = await _service.GetAllObjectsAsync<YearOfProduction>(),
                CarBodys = await _service.GetAllObjectsAsync<Body>(),
                CarColor = await _service.GetAllObjectsAsync<Colour>(),
                CarFuel = await _service.GetAllObjectsAsync<Fuel>(),
                CarOrigin = await _service.GetAllObjectsAsync<Origin>(),


            };

            var carDropdown = dropDown;

            ViewBag.CarBrands = new SelectList(carDropdown.CarBrands, "Id", "Name");
            ViewBag.CarModels = new SelectList(carDropdown.CarModels, "Id", "Name");
            ViewBag.CarYops = new SelectList(carDropdown.CarYops, "Id", "Name");
            ViewBag.CarBodys = new SelectList(carDropdown.CarBodys, "Id", "Name");
            ViewBag.CarColor = new SelectList(carDropdown.CarColor, "Id", "Name");
            ViewBag.CarFuel = new SelectList(carDropdown.CarFuel, "Id", "Name");
            ViewBag.CarOrigin = new SelectList(carDropdown.CarOrigin, "Id", "Name");

           
            await _service.AddAsync(data);
            

            return RedirectToAction(nameof(Index));
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _service.GetByIdAsync == null)
            {
                return NotFound();
            }
            var dropDown = new Dropdown()
            {
                CarBrands = await _service.GetAllObjectsAsync<Brand>(),
                CarModels = await _service.GetAllObjectsAsync<Model>(),
                CarYops = await _service.GetAllObjectsAsync<YearOfProduction>(),
                CarBodys = await _service.GetAllObjectsAsync<Body>(),
                CarColor = await _service.GetAllObjectsAsync<Colour>(),
                CarFuel = await _service.GetAllObjectsAsync<Fuel>(),
                CarOrigin = await _service.GetAllObjectsAsync<Origin>(),


            };

            var carDropdown = dropDown;

            ViewBag.Brand = new SelectList(carDropdown.CarBrands, "Id", "Name");
            ViewBag.Model = new SelectList(carDropdown.CarModels, "Id", "Name");
            ViewBag.YearOfProduction = new SelectList(carDropdown.CarYops, "Id", "Name");
            ViewBag.Body = new SelectList(carDropdown.CarBodys, "Id", "Name");
            ViewBag.Color = new SelectList(carDropdown.CarColor, "Id", "Name");
            ViewBag.Fuel = new SelectList(carDropdown.CarFuel, "Id", "Name");
            ViewBag.Origin = new SelectList(carDropdown.CarOrigin, "Id", "Name");

            var car = await _service.GetByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            ViewData["BodyId"] = new SelectList(await _service.GetCategoryObjectsAsync<Body>(n => n.Id == car.BodyId), "Id", "Id", car.BodyId);
            ViewData["BrandId"] = new SelectList(await _service.GetCategoryObjectsAsync<Brand>(n => n.Id == car.BrandId), "Id", "Id", car.BrandId);
            ViewData["ColorId"] = new SelectList(await _service.GetCategoryObjectsAsync<Colour>(n => n.Id == car.ColorId), "Id", "Id", car.ColorId);
            ViewData["FuelId"] = new SelectList(await _service.GetCategoryObjectsAsync<Fuel>(n => n.Id == car.FuelId), "Id", "Id", car.FuelId);
            ViewData["ModelId"] = new SelectList(await _service.GetCategoryObjectsAsync<Model>(n => n.Id == car.ModelId), "Id", "Id", car.ModelId);
            ViewData["OriginId"] = new SelectList(await _service.GetCategoryObjectsAsync<Origin>(n => n.Id == car.OriginId), "Id", "Id", car.OriginId);
            ViewData["YOPId"] = new SelectList(await _service.GetCategoryObjectsAsync<YearOfProduction>(n => n.Id == car.YOPId), "Id", "Id", car.YOPId);
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Car car)
        {
            if (id != car.id)
            {
                return NotFound();
            }

            DropdownVM data = new DropdownVM()
            {
                BrandId = car.BrandId,
                ModelId = car.ModelId,
                Description = car.Description,
                YOPId = car.YOPId,
                BodyId = car.BodyId,
                ColorId = car.ColorId,
                FuelId = car.FuelId,
                OriginId = car.OriginId,
                Perfomance = car.Performance,
                Mileage = car.Mileage,
                VIN = car.VIN,
                Price = car.Price,
                CoverImageUrl = car.CoverImageUrl,
            };

            
                try
                {
                    await _service.UpdateAsync(data, id);

                var dropDown = new Dropdown()
                {
                    CarBrands = await _service.GetAllObjectsAsync<Brand>(),
                    CarModels = await _service.GetAllObjectsAsync<Model>(),
                    CarYops = await _service.GetAllObjectsAsync<YearOfProduction>(),
                    CarBodys = await _service.GetAllObjectsAsync<Body>(),
                    CarColor = await _service.GetAllObjectsAsync<Colour>(),
                    CarFuel = await _service.GetAllObjectsAsync<Fuel>(),
                    CarOrigin = await _service.GetAllObjectsAsync<Origin>(),


                };

                var carDropdown = dropDown;

                ViewBag.Brand = new SelectList(carDropdown.CarBrands, "Id", "Name");
                ViewBag.Model = new SelectList(carDropdown.CarModels, "Id", "Name");
                ViewBag.YearOfProduction = new SelectList(carDropdown.CarYops, "Id", "Name");
                ViewBag.Body = new SelectList(carDropdown.CarBodys, "Id", "Name");
                ViewBag.Color = new SelectList(carDropdown.CarColor, "Id", "Name");
                ViewBag.Fuel = new SelectList(carDropdown.CarFuel, "Id", "Name");
                ViewBag.Origin = new SelectList(carDropdown.CarOrigin, "Id", "Name");

                ViewData["BodyId"] = new SelectList(await _service.GetCategoryObjectsAsync<Body>(n => n.Id == car.BodyId), "Id", "Id", car.BodyId);
                ViewData["BrandId"] = new SelectList(await _service.GetCategoryObjectsAsync<Brand>(n => n.Id == car.BrandId), "Id", "Id", car.BrandId);
                ViewData["ColorId"] = new SelectList(await _service.GetCategoryObjectsAsync<Colour>(n => n.Id == car.ColorId), "Id", "Id", car.ColorId);
                ViewData["FuelId"] = new SelectList(await _service.GetCategoryObjectsAsync<Fuel>(n => n.Id == car.FuelId), "Id", "Id", car.FuelId);
                ViewData["ModelId"] = new SelectList(await _service.GetCategoryObjectsAsync<Model>(n => n.Id == car.ModelId), "Id", "Id", car.ModelId);
                ViewData["OriginId"] = new SelectList(await _service.GetCategoryObjectsAsync<Origin>(n => n.Id == car.OriginId), "Id", "Id", car.OriginId);
                ViewData["YOPId"] = new SelectList(await _service.GetCategoryObjectsAsync<YearOfProduction>(n => n.Id == car.YOPId), "Id", "Id", car.YOPId);
                return View(car);



            }
                catch (DbUpdateConcurrencyException)
                {
                    
                    
                }
                return RedirectToAction(nameof(Index));
            

        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _service.GetByIdAsync == null)
            {
                return NotFound();
            }

            var car = await _service.GetByIdAsync(id);
            var carVM = new CarVM();

            if (car != null)
            {
                
                

                    carVM.Brand = car.Brand.Name;
                    carVM.Model = car.Model.Name;
                    carVM.Color = car.Color.Name;
                    carVM.YOP = car.YearOfProduction.Name;
                    carVM.Price = car.Price;
                    carVM.Mileage = car.Mileage;
                    carVM.Description = car.Description;
                    carVM.Perfomance = car.Performance;
                    carVM.VIN = car.VIN;
                    carVM.Fuel = car.Fuel.Name;
                    carVM.Body = car.Body.Name;
                    carVM.Origin = car.Origin.Name;
                    carVM.CoverImageUrl = car.CoverImageUrl;
                    carVM.Gallery = car.CarGallery.Select(x => new GalleryVM()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        URL = x.URL
                    }).ToList();
                
            }
            else { return NotFound(); }
            

            return View(carVM);

        }   
        

            
        
            
        

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service.GetByIdAsync(id) == null)
            {
                return Problem("Entity set 'AppDbContext.Car'  is null.");
            }
            var car = await _service.GetByIdAsync(id);
            if (car != null)
            {
                await _service.DeleteAsync(id);
            }
            
            
            return RedirectToAction(nameof(Index));
        }

      

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
