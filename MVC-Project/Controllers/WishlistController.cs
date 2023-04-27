using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using MVC_Project.Interfaces;
using MVC_Project.Models.Identity;
using MVC_Project.Repositories;
using shopping.Models;

namespace MVC_Project.Controllers
{
    [Authorize]
    public class WishlistController : Controller
    {
        public WishlistController( InterfaceWishlistRepository wishlistRepository)                                    
                                 // ,IRepository<Account> AccRepo)     
        {
            this.wishlistRepository = wishlistRepository;
            //this.AccRepo = AccRepo;

        }
        public InterfaceWishlistRepository wishlistRepository { get; }
        public IRepository<Account> AccRepo { get; }

        public IActionResult Index()
        {
            string accEmail = User.Claims.FirstOrDefault().Value;
            //var accountId = AccRepo.GetById();//<----- 
            //var wishlists = wishlistRepository.GetAccountWishlist(accountId);
            //return View(wishlists);
            return View();

        }
        //public IActionResult New(int productId)
        //{
        //    //var accountId = AccRepo.GetById(); //<------
        //    var wishlist = new Wishlist
        //    {
        //        ProductID = productId,
        //        //AccountID = accountId  //<-------to be right

        //    };

        //    wishlistRepository.Create(wishlist);

        //    return RedirectToAction(nameof(Index));

        //}
        public IActionResult Remove(int id)
        {
            var wishlist = wishlistRepository.GetWishlist(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
