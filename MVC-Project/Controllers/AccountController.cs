using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Project.Helpers;
using MVC_Project.Interfaces;
using MVC_Project.Models.Identity;
using System.Security.Claims;
using System.Text;

namespace MVC_Project.Controllers
{
    public class AccountController : Controller
    {

        public AccountController(IRepository<Account> AccRepo, AppDBContext db)
        {
            this.AccRepo = AccRepo;
            DB = db;
        }

        public IRepository<Account> AccRepo { get; }
        public AppDBContext DB { get; }

        [Authorize]
        public IActionResult Dashboard()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(DB.Accounts.Include(A => A.Addresses).FirstOrDefault(A => A.Email == User.Claims.FirstOrDefault().Value));
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
            Account? EmailExist = AccRepo.GetAll()?.Find(A => A.Email == account.Email);
            if (EmailExist != null)
                ModelState.AddModelError("Email", "Email Already Exists");

            if (ModelState.IsValid)
            {
                account.Password = PasswordHandler.Hash(account.Password, out byte[] Salt);
                account.HashSalt = Convert.ToHexString(Salt);

                DB.Accounts.Add(account);
                await DB.SaveChangesAsync();

                var accountId = account.Id;

                var claims = new List<Claim>
                {
                    new Claim("AccountId", accountId.ToString()),
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
            Account? account = DB.Accounts.FirstOrDefault(A => A.Email == email);
            if (account != null)
            {
                if (PasswordHandler.VerifyPassword(password, account.Password, Convert.FromHexString(account.HashSalt)))
                {
                    var claims = new List<Claim>
                        {
                            new Claim("AccountId", account.Id.ToString()),
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

        [HttpGet]

        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
            }
            return RedirectToAction("Login");
        }

        [Authorize]
        public async Task<IActionResult> AddAddress(string address, string appartmentSuite, string townCity, string State, string Zipcode)
        {
            var x = Request;
            var Acc = DB.Accounts.FirstOrDefault(A => A.Email == User.Claims.FirstOrDefault().Value);
            Address add = new Address
            {
                Addr = address,
                AppartmentSuite = appartmentSuite,
                TownCity = townCity,
                State = State,
                Zipcode = Zipcode
            };
            Acc.Addresses.Add(add);
            DB.SaveChanges();
            return Json(new
            {
                Success = false,
                Message = "Added successfully",
                addedadd = new
                {
                    Addr = add.Addr,
                    AppartmentSuite = add.AppartmentSuite,
                    TownCity = add.TownCity,
                    State = add.State,
                    Zipcode = add.Zipcode
                }
            });
        }
        [Authorize]
        public async Task<IActionResult> SetDefaultAddress(int id)
        {
            Account? account = DB.Accounts.Include(a => a.Addresses).FirstOrDefault(A => A.Email == User.Claims.FirstOrDefault().Value);
            if (account.HasAddress(id))
            {
                account.SelectedAddressId = id;
                DB.SaveChanges();
                return Json(new
                {
                    Success = true,
                    Message = "Address Set to default",
                });
            }
            return Json(new
            {
                Success = false,
                Message = "Invalid",
            });
        }

        [AllowAnonymous]
        public IActionResult FacebookLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("FacebookCallback", "Account") };
            return Challenge(properties, "Facebook");
        }

        [AllowAnonymous]
        public async Task<IActionResult> FacebookCallback()
        {
            var result = await HttpContext.AuthenticateAsync("Facebook");
            if (result?.Succeeded != true)
            {
                return RedirectToAction("Login");
            }

            // Get Facebook user's profile data
            var accessToken = result.Properties.GetTokenValue("access_token");
            var userEmail = result.Principal.FindFirst(ClaimTypes.Email)?.Value;
            var firstName = result.Principal.FindFirst(ClaimTypes.GivenName)?.Value;
            var lastName = result.Principal.FindFirst(ClaimTypes.Surname)?.Value;

            // Add Facebook user to your database (example using Entity Framework Core)
            var user = await DB.Accounts.FirstOrDefaultAsync(u => u.Email == userEmail);
            if (user == null)
            {
                user = new Account
                {
                    Firstname = firstName,
                    Lastname = lastName,
                    Email = userEmail,
                    Password = GenerateRandomPassword(8)
                };
                user.Password = PasswordHandler.Hash(user.Password, out byte[] Salt);
                user.HashSalt = Convert.ToHexString(Salt);

                DB.Accounts.Add(user);
                await DB.SaveChangesAsync();
            }
            var accountId = user.Id;

            // Sign in the user
            var claims = new List<Claim>
            {
                new Claim("AccountId", accountId.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, $"{user.Firstname} {user.Lastname}"),
                new Claim("Password", user.Password),
                new Claim(ClaimTypes.Role, user.UserRole.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return RedirectToAction("Dashboard");
        }

        private static string GenerateRandomPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*";
            var random = new Random();
            var password = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                password.Append(validChars[random.Next(0, validChars.Length)]);
            }

            return password.ToString();
        }
    }
}
