using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Helpers;
using shopping.Models;

namespace MVC_Project.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryController(AppDBContext context)
        {
            Context = context;
        }
        public AppDBContext Context { get; }
        public IActionResult Categores(int id)
        {

  


                 Product P = Context.Products.Include(P => P.Images)
                .Include(P => P.SubCategory).FirstOrDefault();


            ViewData["product"] =
            Context.Products
          .Include(P => P.SubCategory).Where(p => p.SubCategoryId == id);

            //if (P != null)
            //{
            //    List<string> Images = new();
            //    foreach (Image img in P.Select(p=>p.Images).ToList())
            //    {
            //        if (img != null)
            //            Images.Add(ImageHandler.GetImageURI(img));
            //    }
            //    ViewBag.Images = Images;
            //}
            return View(P);
        }
    }
}
