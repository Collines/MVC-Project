using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Helpers;
using shopping.Models;
using System.Collections.Specialized;
using System.Web;

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

        // GET: SubcategoryController/Details/5
        public IActionResult Details(int id)
        {
            List<int> brandIdsList = new();

            string queryString = Request.QueryString.ToString();
            if (queryString.Length > 0)
            {
                NameValueCollection queryParameters = HttpUtility.ParseQueryString(queryString);
                if (queryParameters.Count > 0)
                {
                    string? brandIds = queryParameters["brand"];
                    if (brandIds != null && brandIds.Length > 0)
                    {
                        string[] brandIdsArray = brandIds.Split(',');
                        foreach (var brandId in brandIdsArray)
                        {
                            brandIdsList.Add(int.Parse(brandId));
                        }
                    }
                }
            }

            Subcategory s = context.Subcategories.FirstOrDefault(s => s.SubCategoryId == id);
            var AllProduct = context.Products.Where(c => c.SubCategoryId == id).Include(p => p.Brand).Include(i => i.Images).ToList();

            List<Brand?> brands = AllProduct.Select(p => p.Brand).Distinct().ToList() ?? new();
            ViewBag.Brands = brands;
            ViewBag.BrandIdsList = brandIdsList;

            if (brandIdsList.Count > 0)
            {
                AllProduct = AllProduct.Where(p => brandIdsList.Contains(p.BrandID)).ToList();
            }

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
            return View();
        }
    }
}
