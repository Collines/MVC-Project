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

        [Authorize]
		public IActionResult Dashboard()
		{
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login");
		}

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Account account)
        {
            Account? EmailExist = AccRepo.GetAll()?.Find(A=>A.Email == account.Email);
            if (EmailExist != null)
                ModelState.AddModelError("Email", "Email Already Exists");

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
            return View();
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
                            new Claim(ClaimTypes.Role, account.UserRole.ToString())
		                };

						var claimsIdentity = new ClaimsIdentity(
							claims, CookieAuthenticationDefaults.AuthenticationScheme);
						await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
						return RedirectToAction("Dashboard");
                    }
                    else
                        return View();
                }
                return View();
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
            return RedirectToAction("Login");
        }

    }
}
