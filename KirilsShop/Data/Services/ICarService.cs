
using KirilsShop.Models;
using KirilsShop.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace KirilsShop.Data.Services
{
    public interface ICarService
    {



        Task<List<Car>> GetAllAsync();
        Task<string> UploadImage(string folderPath, IFormFile file);
        Task AddAsync(DropdownVM data);
        Task UpdateAsync(DropdownVM data, int id);
        Task<Car> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        List<Car> GetFilteredCarList(FilterVM model);
        Task<List<T>> GetAllObjectsAsync<T>() where T : class;
        Task<List<T>> GetCategoryObjectsAsync<T>(Expression<Func<T, bool>> predicate) where T : class;
       



    }
}
