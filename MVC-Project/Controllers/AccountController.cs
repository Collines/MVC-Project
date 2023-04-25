using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC_Project.Helpers;
using MVC_Project.Interfaces;
using MVC_Project.Models.Identity;
using System.Security.Claims;

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
            if(User.Identity.IsAuthenticated)
            {
                return View("Dashboard");
            }
            return View();
        }
        [Authorize]
		public IActionResult Dashboard()
		{
			return View();
		}

		[HttpPost]
        public async Task<IActionResult> Register(Account account)
        {
            if(ModelState.IsValid)
            {
                account.Password = PasswordHandler.Hash(account.Password, out byte[] Salt);
                account.HashSalt = Convert.ToHexString(Salt);
                AccRepo.Insert(account);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, account.Email),
                    new Claim(ClaimTypes.Name, $"{account.Firstname} {account.Lastname}"),
                    new Claim("Password", account.Password),
                    new Claim(ClaimTypes.Role, account.UserRole.ToString()),
                };
                var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Dashboard");
            }
            ViewBag.Msg = "Account is not Created!";
            ViewBag.Type = "alert-danger d-block";
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            using(AppDBContext DB = new AppDBContext())
            {   
                Account? account = DB.Accounts.FirstOrDefault(A => A.Email == email);
                if (account != null)
                {
                    if (PasswordHandler.VerifyPassword(password, account.Password, Convert.FromHexString(account.HashSalt)))
                    {
						var claims = new List<Claim>
		                {
			                new Claim(ClaimTypes.Email, email),
                            new Claim(ClaimTypes.Name, $"{account.Firstname} {account.Lastname}"),
                            new Claim("Password", password),
		                };

						var claimsIdentity = new ClaimsIdentity(
							claims, CookieAuthenticationDefaults.AuthenticationScheme);
						await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
						return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        ViewBag.Msg = "Wrong Credentials!";
                        ViewBag.Type = "alert-danger d-block";
                        return View("Index");
                    }
                }
                ViewBag.Msg = "Login Failed!";
                ViewBag.Type = "alert-danger d-block";
                return View("Index");
            }
        }

        [HttpGet]

        public async Task<IActionResult> Logout()
        {
            if(User.Identity.IsAuthenticated)
            {
				await HttpContext.SignOutAsync(
		            CookieAuthenticationDefaults.AuthenticationScheme);
			}
            return View("Index");
        }

    }
}
