using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.VinFast.Data;
using Web.VinFast.Models;

namespace Web.VinFast.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarCategoriesController : BaseController
    {
        private readonly VinFastDbContext _context;

        public CarCategoriesController(VinFastDbContext context)
        {
            _context = context;
        }

        // GET: Admin/CarCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarCategory.ToListAsync());
        }

        // GET: Admin/CarCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CarCategory == null)
            {
                return NotFound();
            }

            var carCategory = await _context.CarCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carCategory == null)
            {
                return NotFound();
            }

            return View(carCategory);
        }

        // GET: Admin/CarCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/CarCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedDate")] CarCategory carCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carCategory);
        }

        // GET: Admin/CarCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CarCategory == null)
            {
                return NotFound();
            }

            var carCategory = await _context.CarCategory.FindAsync(id);
            if (carCategory == null)
            {
                return NotFound();
            }
            return View(carCategory);
        }

        // POST: Admin/CarCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedDate")] CarCategory carCategory)
        {
            if (id != carCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarCategoryExists(carCategory.Id))
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
            return View(carCategory);
        }

        // GET: Admin/CarCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CarCategory == null)
            {
                return NotFound();
            }

            var carCategory = await _context.CarCategory
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carCategory == null)
            {
                return NotFound();
            }

            return View(carCategory);
        }

        // POST: Admin/CarCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CarCategory == null)
            {
                return Problem("Entity set 'VinFastDbContext.CarCategory'  is null.");
            }
            var carCategory = await _context.CarCategory.FindAsync(id);
            if (carCategory != null)
            {
                _context.CarCategory.Remove(carCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarCategoryExists(int id)
        {
            return _context.CarCategory.Any(e => e.Id == id);
        }
    }
}
