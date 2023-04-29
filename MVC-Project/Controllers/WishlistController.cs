using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MVC_Project.DTOW;
using MVC_Project.Helpers;
using MVC_Project.Interfaces;
using MVC_Project.Models.Cart;
using MVC_Project.Models.Identity;
using MVC_Project.Models.Wishlist;
using MVC_Project.Repositories;
using shopping.Models;

namespace MVC_Project.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        //public WishlistController( InterfaceWishlistRepository wishlistRepository)                                    
        //                         // ,IRepository<Account> AccRepo)     
        //{
        //    this.wishlistRepository = wishlistRepository;
        //    //this.AccRepo = AccRepo;

        //}
        //public InterfaceWishlistRepository wishlistRepository { get; }
        //public IRepository<Account> AccRepo { get; }

        //public IActionResult Index()
        //{
        //    string accEmail = User.Claims.FirstOrDefault().Value;
        //    //var accountId = AccRepo.GetById();//<----- 
        //    //var wishlists = wishlistRepository.GetAccountWishlist(accountId);
        //    //return View(wishlists);
        //    return View();

        //}
        ////public IActionResult New(int productId)
        ////{
        ////    //var accountId = AccRepo.GetById(); //<------
        ////    var wishlist = new Wishlist
        ////    {
        ////        ProductID = productId,
        ////        //AccountID = accountId  //<-------to be right

        ////    };

        ////    wishlistRepository.Create(wishlist);

        ////    return RedirectToAction(nameof(Index));

        ////}
        //public IActionResult Remove(int id)
        //{
        //    var wishlist = wishlistRepository.GetWishlist(id);
        //    return RedirectToAction(nameof(Index));
        //}

        public WishlistController(AppDBContext context)
        {
            Context = context;
        }

        public AppDBContext Context { get; }

        public IActionResult Index()
        {
            Account? owner = Context.Accounts.FirstOrDefault(A => A.Email == User.Claims.FirstOrDefault().Value);
            Wishlist wishlist = Context.Wishlists.FirstOrDefault(C => C.AccountID == owner.Id);
            return View(wishlist);
        }

        [HttpPost("Wishlist/AddToWishlist/{productId:int}")]
        public IActionResult AddToWishlist(int productId)
        {
            Account? owner = Context.Accounts.FirstOrDefault(A => A.Email == User.Claims.FirstOrDefault().Value);
            Wishlist wishlist = Context.Wishlists.FirstOrDefault(C => C.AccountID == owner.Id);
            Product? product = Context.Products.Find(productId);
            Wishlistitem wishlistitem = null;
            decimal wishTotalPrice = 0;
            if (wishlist != null && product != null)
            {
                bool alreadyExist = false;
                foreach (Wishlistitem ci in wishlist.Wishlistitems)
                {
                    if (ci.ProductId == productId)
                    {
                        wishlistitem = ci;
                        alreadyExist = true;
                    }
                }
                if (!alreadyExist)
                {
                    wishlistitem = new Wishlistitem()
                    {
                        ProductId = product.ProductId,
                        Price = product.price,
                        WishlistId = wishlist.Id,
                    };
                    wishlist.Wishlistitems.Add(wishlistitem);

                }
                Context.SaveChanges();
                var results = new DTOWish
                {
                    Message = $"{product.ProductName} has beed Added to your cart!",
                    WishlistCount = wishlist.Wishlistitems.Count(),
                    ProductId = productId,
                    ProductName = product.ProductName,
                    ImageURI = ImageHandler.GetImageURI(product.Images.FirstOrDefault())
                };
                return Json(results);

            }
            else
            {
                var results = new DTOWish
                {
                    Message = $"Product not found",
                    WishlistCount = wishlist?.Wishlistitems.Count() ?? 0,
                };
                return Json(results);
            }
        }

        [HttpPost("Wishlist/RemoveFromWish/{productId:int}")]
        public IActionResult RemoveFromWish(int productId)
        {
            Account? owner = Context.Accounts.FirstOrDefault(A => A.Email == User.Claims.FirstOrDefault().Value);
            Wishlist wishlist = Context.Wishlists.FirstOrDefault(C => C.AccountID == owner.Id);
            Product? product = Context.Products.Find(productId);
            Wishlistitem wishlistitem = null;
            if (wishlist != null && product != null)
            {
                foreach (Wishlistitem ci in Wishlist.Wishlistitems)
                {
                    if (ci.ProductId == productId)
                        wishlistitem = ci;
                }
                if (wishlistitem != null)
                {
                    Context.Remove(wishlistitem);
                }
                Context.SaveChanges();
                var results = new DTOWish
                {
                    Message = $"{product.ProductName} has beed Removed from your wishlist!",
                    WishlistCount = wishlist.Wishlistitems.Count(),
                };
                return Json(results);

            }
            else
            {
                var results = new DTOWish
                {
                    Message = $"Product not found",
                    WishlistCount = wishlist?.Wishlistitems.Count() ?? 0,
                };
                return Json(results);
            }
        }
    }
}
