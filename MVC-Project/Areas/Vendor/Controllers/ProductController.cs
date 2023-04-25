using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Project;
using MVC_Project.Helpers;
using shopping.Models;

namespace MVC_Project.Areas.Vendor.Controllers
{
    [Area("Vendor")]
    public class ProductController : Controller
    {
        private readonly AppDBContext _context;

        public ProductController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Vendor/Product
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Products.Include(p => p.Brand).Include(p => p.SubCategory);
            return View(await appDBContext.ToListAsync());
        }

        // GET: Vendor/Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Vendor/Product/Create
        public IActionResult Create()
        {
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "Id", "Name");
            ViewData["Categories"] = _context.Categories.Include(c=>c.SubCategories).ToList();
            return View();
        }

        // POST: Vendor/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,description,price,Quantity,BrandID,IsAvailable,SubCategoryId,Images")] Product product)
        {
            foreach (var file in Request.Form.Files)
            {
                Image img = ImageHandler.EncodeImage(file);
                _context.Images.Add(img);
                _context.SaveChanges();
                product.Images.Add(img);
            }

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "Id", "Name", product.BrandID);
            ViewData["Categories"] = _context.Categories.Include(c => c.SubCategories).ToList();
            return View(product);
        }

        // GET: Vendor/Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "Id", "Id", product.BrandID);
            ViewData["SubCategoryId"] = new SelectList(_context.Subcategories, "SubCategoryId", "SubCategoryId", product.SubCategoryId);
            return View(product);
        }

        // POST: Vendor/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,description,price,Quantity,BrandID,IsAvailable,SubCategoryId")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "Id", "Id", product.BrandID);
            ViewData["SubCategoryId"] = new SelectList(_context.Subcategories, "SubCategoryId", "SubCategoryId", product.SubCategoryId);
            return View(product);
        }

        // GET: Vendor/Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.SubCategory)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Vendor/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'AppDBContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
