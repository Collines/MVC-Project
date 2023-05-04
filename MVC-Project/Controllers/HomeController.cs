using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;
using System.Diagnostics;

namespace MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDBContext _context;
        public HomeController(ILogger<HomeController> logger, AppDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //var all_cate = _context.Categories.Include(x => x.SubCategories).ToList();
            //return View(all_cate);
            return View();
        }

        public IActionResult Forbidden()
        {
            return View("Forbidden");
        }

        public IActionResult Notfound()
        {
            return View("NotFound");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //[HttpPost]
        public async Task<IActionResult> SearchResult(string term)
        {
            ViewData["getproduct"] = term  ;
            var produ_query = _context.Products
                .Include(P => P.SubCategory).AsNoTracking()
                .Where(p => p.ProductName.Contains(term)).ToListAsync();
              ViewData["products"] = await produ_query;
           


           var  subcat = _context.Subcategories.Include(p=>p.Products)
               .ToList();
            //ViewBag.students = students;
           


            return View("SearchResult", subcat);
        }
   
    }
}