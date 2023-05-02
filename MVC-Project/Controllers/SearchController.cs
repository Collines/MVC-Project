using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Helpers;
using shopping.Models;
using System.Drawing.Printing;

namespace MVC_Project.Controllers
{
    public class SearchController : Controller
    {
        // GET: SearchController
        public AppDBContext Context;
        public SearchController(AppDBContext _context)
        {
            Context = _context;
        }
        public async Task<IActionResult> Index(string search , string sortOrder, int pageNumber = 1)
        {
            Brand B = Context.Brands.FirstOrDefault(x => x.Name == search);
            if (B == null)
            {
                return View( "NoBrandFound");
            }
                var AllProduct = Context.Products
               .Where(x => x.BrandID == B.Id)
                .Include(P => P.Images).Include(P => P.SubCategory).ToList();

            ViewData["CurrentFilter"] = search;

            ViewBag.AllProducts = AllProduct;

            Product P = Context.Products.Include(P => P.Images).Include(P => P.SubCategory).Include(b => b.Brand).FirstOrDefault(Pr => Pr.BrandID == B.Id);

            Image img2 = Context.Images.FirstOrDefault(I => I.ProductId == P.ProductId);
            string imageDataURL = ImageHandler.GetImageURI(img2);

            ViewBag.ProductImage = imageDataURL;
            if (P != null)
            {
                List<string> Images = new();
                foreach (Image img in P.Images)
                {
                    if (img != null)
                        Images.Add(ImageHandler.GetImageURI(img));
                }
                ViewBag.Images = Images;

            }
            if (search == null)
            {
                pageNumber = 1;
            }
            ViewData["CurrentSort"] = sortOrder;
            return View(await PaginatedList<Product>.CreateAsync(Context.Products.AsNoTracking(), pageNumber, 5));
        }

        // GET: SearchController/Details/5
        public ActionResult Details(int Id)
        {
          
            return View();
        }

        // GET: SearchController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SearchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SearchController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SearchController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SearchController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
