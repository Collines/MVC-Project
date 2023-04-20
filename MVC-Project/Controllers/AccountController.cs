using Microsoft.AspNetCore.Mvc;
using MVC_Project.Helpers;
using MVC_Project.Interfaces;
using MVC_Project.Models.Identity;

namespace MVC_Project.Controllers
{
    public class AccountController : Controller
    {

        public AccountController(IRepository<Account> AccRepo)
        {
            this.AccRepo = AccRepo;
        }

        public IRepository<Account> AccRepo { get; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Account account)
        {
            if(ModelState.IsValid)
            {
                account.Password = PasswordHandler.Hash(account.Password, out byte[] Salt);
                account.HashSalt = Convert.ToHexString(Salt);
                AccRepo.Insert(account);
                ViewBag.Msg = $"{account.Email} Created Successfully!";
                ViewBag.Type = "alert-success d-block";
                return View("Index");
            }
            ViewBag.Msg = "Account is not Created!";
            ViewBag.Type = "alert-danger d-block";
            return View("Index");
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            using(AppDBContext DB = new AppDBContext())
            {   
                Account? account = DB.Accounts.FirstOrDefault(A => A.Email == email);
                if (account != null)
                {
                    if (PasswordHandler.VerifyPassword(password, account.Password, Convert.FromHexString(account.HashSalt)))
                    {
                        ViewBag.Msg = $"{account.Email} Login Successfully!";
                        ViewBag.Type = "alert-success d-block";
                        return View("Index");
                    }
                    else
                    {
                        ViewBag.Msg = $"{account.Email} Login Failed!";
                        ViewBag.Type = "alert-danger d-block";
                        return View("Index");
                    }
                }
                ViewBag.Msg = "Login Failed!";
                ViewBag.Type = "alert-danger d-block";
                return View("Index");
            }
        }

    }
}
