using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;
using shopping.Models;
using System.Diagnostics;

namespace MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext _context;

        public HomeController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Subcategory> subcategories = _context.Subcategories.Include(S => S.Products).ThenInclude(P => P.Brand).Include(S => S.Products).ThenInclude(P => P.Images).ToList();

            return View(subcategories);
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
    }
}