using Microsoft.AspNetCore.Mvc;

namespace MVC_Project.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
