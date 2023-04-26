using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Helpers;
using shopping.Models;

namespace MVC_Project.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(AppDBContext context)
        {
            Context = context;
        }

        public AppDBContext Context { get; }

        public IActionResult Details(int id)
        {
            Product P = Context.Products.Include(P => P.Images).Include(P => P.SubCategory).FirstOrDefault(Pr=>Pr.ProductId==id);
            if(P!=null)
            {
                List<string> Images = new();
                foreach(Image img in P.Images)
                {
                    if (img != null)
                        Images.Add(ImageHandler.GetImageURI(img));
                }
                ViewBag.Images = Images;
            }
            return View(P);
        }
    }
}
