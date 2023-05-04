using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Project;
using shopping.Models;

namespace MVC_Project.Areas.Vendor.Controllers
{
    [Area("Vendor")]
    [Authorize(Roles = "Vendor")]
    public class SubcategoryController : Controller
    {
        private readonly AppDBContext _context;

        public SubcategoryController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Vendor/Subcategory
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Subcategories.Include(s => s.Category);
            return View(await appDBContext.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Index(string term)
        {


            return
            View(await _context.Subcategories.Include(s => s.Category)
            .Where(p => p.SubCategoryName.Contains(term))
            .ToListAsync());

        }


        // GET: Vendor/Subcategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subcategories == null)
            {
                return NotFound();
            }

            var subcategory = await _context.Subcategories
                .Include(s => s.Category)
                .Include(s=>s.Products)
                .FirstOrDefaultAsync(m => m.SubCategoryId == id);
            if (subcategory == null)
            {
                return NotFound();
            }

            return View(subcategory);
        }

        // GET: Vendor/Subcategory/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Vendor/Subcategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubCategoryId,SubCategoryName,CategoryId")] Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subcategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", subcategory.CategoryId);
            return View(subcategory);
        }

        // GET: Vendor/Subcategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subcategories == null)
            {
                return NotFound();
            }

            var subcategory = await _context.Subcategories.Include(s=>s.Category).FirstOrDefaultAsync(c=>c.SubCategoryId==id);
            if (subcategory == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories,"CategoryId","CategoryName");
            return View(subcategory);
        }

        // POST: Vendor/Subcategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubCategoryId,SubCategoryName,CategoryId")] Subcategory subcategory)
        {
            if (id != subcategory.SubCategoryId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subcategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubcategoryExists(subcategory.SubCategoryId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", subcategory.CategoryId);
            return View(subcategory);
        }

        // GET: Vendor/Subcategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subcategories == null)
            {
                return NotFound();
            }

            var subcategory = await _context.Subcategories
                .Include(s => s.Category)
                .FirstOrDefaultAsync(m => m.SubCategoryId == id);
            if (subcategory == null)
            {
                return NotFound();
            }

            return View(subcategory);
        }

        // POST: Vendor/Subcategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subcategories == null)
            {
                return Problem("Entity set 'AppDBContext.Subcategories'  is null.");
            }
            var subcategory = await _context.Subcategories.FindAsync(id);
            if (subcategory != null)
            {
                _context.Subcategories.Remove(subcategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubcategoryExists(int id)
        {
          return (_context.Subcategories?.Any(e => e.SubCategoryId == id)).GetValueOrDefault();
        }
    }
}
