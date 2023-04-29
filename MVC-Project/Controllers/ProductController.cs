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
            Product P = Context.Products.Include(P => P.Images).Include(P => P.SubCategory).Include(b=>b.Brand).FirstOrDefault(Pr=>Pr.ProductId==id);

            Image img2 = Context.Images.FirstOrDefault(I => I.ProductId == P.ProductId);
            string imageDataURL = ImageHandler.GetImageURI(img2);

            ViewBag.ProductImage = imageDataURL;
            if (P!=null)
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
