using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shopping.Models;

namespace MVC_Project.Controllers
{
    public class WishlistController : Controller
    {
        private readonly AppDBContext _context;

        public WishlistController(AppDBContext context)
        {
            _context = context;
        }


        [Authorize]
        public async Task<IActionResult> Index()
        {
            var claimsPrincipal = User;
            var userIdClaim = claimsPrincipal.FindFirst("AccountId");
            var userId = userIdClaim?.Value;

            var wishlistItems = await _context.Wishlists
                .Include(w => w.Product)
                .ThenInclude(p => p.Images)
                .Where(w => w.AccountID.ToString() == userId)
                .ToListAsync();

            return View(wishlistItems);
        }


        [Authorize]
        public async Task<IActionResult> AddToWishlist(int id)
        {
            var claimsPrincipal = User;
            var userIdClaim = claimsPrincipal.FindFirst("AccountId");
            var userId = userIdClaim?.Value;

            var wishlist = _context.Wishlists.FirstOrDefault(w => w.ProductID == id && w.AccountID.ToString() == userId);

            if (wishlist == null)
            {
                var wishlistItem = new Wishlist
                {
                    AccountID = int.Parse(userId),
                    ProductID = id
                };

                _context.Add(wishlistItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


        [Authorize]
        public async Task<IActionResult> RemoveFromWishlist(int id)
        {
            var wishlistItem = await _context.Wishlists.FirstOrDefaultAsync(w => w.ProductID == id && w.AccountID.ToString() == User.FindFirst("AccountId").Value);
            if (wishlistItem == null)
            {
                return NotFound();
            }

            _context.Wishlists.Remove(wishlistItem);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
