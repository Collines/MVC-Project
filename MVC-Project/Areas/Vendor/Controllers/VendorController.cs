using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Areas.Vendor.Controllers
{
    [Area("Vendor")]
    [Authorize(Roles ="Vendor")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
