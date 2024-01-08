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
    public class ColoursController : Controller
    {
        private readonly AppDbContext _context;

        public ColoursController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Colours
        public async Task<IActionResult> Index()
        {
              return _context.CarColors != null ? 
                          View(await _context.CarColors.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.CarColors'  is null.");
        }

        // GET: Colours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarColors == null)
            {
                return NotFound();
            }

            var colour = await _context.CarColors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colour == null)
            {
                return NotFound();
            }

            return View(colour);
        }

        // GET: Colours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Colour colour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colour);
        }

        // GET: Colours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarColors == null)
            {
                return NotFound();
            }

            var colour = await _context.CarColors.FindAsync(id);
            if (colour == null)
            {
                return NotFound();
            }
            return View(colour);
        }

        // POST: Colours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Colour colour)
        {
            if (id != colour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColourExists(colour.Id))
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
            return View(colour);
        }

        // GET: Colours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarColors == null)
            {
                return NotFound();
            }

            var colour = await _context.CarColors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colour == null)
            {
                return NotFound();
            }

            return View(colour);
        }

        // POST: Colours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarColors == null)
            {
                return Problem("Entity set 'AppDbContext.CarColors'  is null.");
            }
            var colour = await _context.CarColors.FindAsync(id);
            if (colour != null)
            {
                _context.CarColors.Remove(colour);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColourExists(int id)
        {
          return (_context.CarColors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
