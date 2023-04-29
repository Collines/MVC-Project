using MVC_Project.Models.Wishlist;

namespace MVC_Project.Repositories
{
    public interface InterfaceWishlistRepository
    {
        Wishlist GetWishlist(int Id);
        void Create(Wishlist wishlist);
        Wishlist GetAccountWishlist(int AccountId);

        void Remove(Wishlist wishlist);
    }
}
