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
                ViewBag.Orders = DB.Orders.IgnoreQueryFilters().Include(O=>O.Cart).ThenInclude(c=>c.CartItems).ThenInclude(ci=>ci.Product).ThenInclude(P=>P.Images).Where(o => o.CustomerId.ToString() == User.FindFirst("AccountId").Value).OrderByDescending(o=>o.Id).ToList();
                return View(DB.Accounts.Include(A => A.Addresses).FirstOrDefault(A => A.Id.ToString() == User.Claims.FirstOrDefault().Value));
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

        [Authorize]
		public async Task<IActionResult> UpdateAccount(Account account,string CurrentPassword, string NewPassword, string ConfirmNewPassword)
        {
            if(account.Id.ToString() == User.FindFirst("AccountId").Value)
            {
                var acc = DB.Accounts.Find(account.Id);
                if (acc != null)
                {
                    acc.Firstname = account.Firstname??acc.Firstname;
                    acc.Lastname = account.Lastname ?? acc.Lastname;
                    if (!String.IsNullOrEmpty(CurrentPassword))
                    {
                        if (PasswordHandler.VerifyPassword(CurrentPassword, acc.Password, Convert.FromHexString(acc.HashSalt)))
                        {
                            if (!String.IsNullOrEmpty(NewPassword) && NewPassword == ConfirmNewPassword)
                            {
                                acc.Password = PasswordHandler.Hash(NewPassword, out byte[] Salt);
                                acc.HashSalt = Convert.ToHexString(Salt);
                            }

                        }
                        else
                        {
							ModelState.AddModelError("CurrentPassword", "Password is wrong");
                            //RedirectToAction("Dashboard");
						}
                    }
                    DB.SaveChanges();
					return RedirectToAction("Dashboard");
				}
			}
            return RedirectToAction("Dashboard");
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
                {
                    ModelState.AddModelError("Email", "Incorrect Credentials");
                    ModelState.AddModelError("Password", "Incorrect Credentials");
					return View();
				}
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
            var Acc = DB.Accounts.Include(a=>a.Addresses).FirstOrDefault(A => A.Id.ToString() == User.Claims.FirstOrDefault().Value);
            Address add = new Address
            {
                Addr = address,
                AppartmentSuite = appartmentSuite,
                TownCity = townCity,
                State = State,
                Zipcode = Zipcode
            };
            if (Acc.Addresses.Count == 0)
                add.IsDefault = true;
            Acc.Addresses.Add(add);
            DB.SaveChanges();
            return Json(new
            {
                Success = true,
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
		public async Task<IActionResult> EditAddress(int id,string address, string appartmentSuite, string townCity, string State, string Zipcode)
		{
			var Acc = DB.Accounts.Include(a=>a.Addresses).FirstOrDefault(A => A.Id.ToString() == User.Claims.FirstOrDefault().Value);
            if(Acc!=null && Acc.HasAddress(id))
            {
                var EditedAddress = DB.Addresses.FirstOrDefault(a => a.Id == id && a.AccountId == Acc.Id);
                EditedAddress.Addr = address ?? EditedAddress.Addr;
                EditedAddress.AppartmentSuite = appartmentSuite ?? EditedAddress.AppartmentSuite;
                EditedAddress.TownCity = townCity ?? EditedAddress.TownCity;
                EditedAddress.State = State ?? EditedAddress.State;
                EditedAddress.Zipcode = Zipcode ?? EditedAddress.Zipcode;

				DB.SaveChanges();
				return Json(new
				{
					Success = true,
					Message = "Edit successfully"
				});
			}
			return Json(new
			{
				Success = false,
				Message = "Not found"
			});
		}


		[Authorize]
		public async Task<IActionResult> DeleteAddress(int id)
		{
			var Acc = DB.Accounts.Include(a => a.Addresses).FirstOrDefault(A => A.Id.ToString() == User.Claims.FirstOrDefault().Value);
			if (Acc != null && Acc.HasAddress(id))
			{
                Address address = DB.Addresses.Find(id);
                DB.Addresses.Remove(address);
				DB.SaveChanges();
				return Json(new
				{
					Success = true,
					Message = "Deleted successfully"
				});
			}
			return Json(new
			{
				Success = false,
				Message = "Not found"
			});
		}


		[Authorize]
        public async Task<IActionResult> SetDefaultAddress(int id)
        {
            Account? account = DB.Accounts.Include(a => a.Addresses).FirstOrDefault(A => A.Id.ToString() == User.Claims.FirstOrDefault().Value);
            Address defaultAddress = account.Addresses.Where(a => a.IsDefault == true).Select(a=>a).FirstOrDefault();
            if (account.HasAddress(id) && defaultAddress != null)
            {
                Address? address = DB.Addresses.Find(id);
                defaultAddress.IsDefault = false;
                address.IsDefault = true;
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
