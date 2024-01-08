using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KirilsShop.Data;
using KirilsShop.Models.Categories;

namespace KirilsShop.Controllers
{
    public class OriginsController : Controller
    {
        private readonly AppDbContext _context;

        public OriginsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Origins
        public async Task<IActionResult> Index()
        {
              return _context.CarOrigins != null ? 
                          View(await _context.CarOrigins.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.CarOrigins'  is null.");
        }

        // GET: Origins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarOrigins == null)
            {
                return NotFound();
            }

            var origin = await _context.CarOrigins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (origin == null)
            {
                return NotFound();
            }

            return View(origin);
        }

        // GET: Origins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Origins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Origin origin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(origin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(origin);
        }

        // GET: Origins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarOrigins == null)
            {
                return NotFound();
            }

            var origin = await _context.CarOrigins.FindAsync(id);
            if (origin == null)
            {
                return NotFound();
            }
            return View(origin);
        }

        // POST: Origins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Origin origin)
        {
            if (id != origin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(origin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OriginExists(origin.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(origin);
        }

        // GET: Origins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarOrigins == null)
            {
                return NotFound();
            }

            var origin = await _context.CarOrigins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (origin == null)
            {
                return NotFound();
            }

            return View(origin);
        }

        // POST: Origins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarOrigins == null)
            {
                return Problem("Entity set 'AppDbContext.CarOrigins'  is null.");
            }
            var origin = await _context.CarOrigins.FindAsync(id);
            if (origin != null)
            {
                _context.CarOrigins.Remove(origin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OriginExists(int id)
        {
          return (_context.CarOrigins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
