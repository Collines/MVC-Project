using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Helpers;
using shopping.Models;
using System.Drawing.Printing;

namespace MVC_Project.Controllers
{
    public class SubcategoryController : Controller
    {
        // GET: SubcategoryController
        public AppDBContext context;
        public SubcategoryController(AppDBContext _context)
        {
            context = _context;

        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: SubcategoryController/Details/5
        public async Task<IActionResult> Details (int id , int pageNumber = 1 )
        {
            Subcategory s = context.Subcategories.FirstOrDefault(s => s.SubCategoryId == id);
            var AllProduct = context.Products.Where(c => c.SubCategoryId == id).Include(p => p.Brand).Include(i => i.Images).ToList();                 
            
            Product P = context.Products.Include(P => P.Images).Include(P => P.SubCategory).Include(b => b.Brand).FirstOrDefault(Pr => Pr.SubCategoryId == id);

            Image img2 = context.Images.FirstOrDefault(I => I.ProductId == P.ProductId);
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
            ViewBag.sub = s;
            ViewBag.AllProducts = AllProduct;
            //return View(s);
            return View(await PaginatedList<Product>.CreateAsync(context.Products.AsNoTracking(), pageNumber , 5));
        }

        // GET: SubcategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubcategoryController/Create
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

        // GET: SubcategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubcategoryController/Edit/5
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

        // GET: SubcategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubcategoryController/Delete/5
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
