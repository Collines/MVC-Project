using Microsoft.EntityFrameworkCore;
using MVC_Project.Models.Identity;
using MVC_Project.Models.Wishlist;


namespace MVC_Project.Repositories
{
    public class WishlistRepository : InterfaceWishlistRepository
    {

        public WishlistRepository(AppDBContext DB)
        {
            this.DB = DB;
        }
        public AppDBContext DB { get; }


        public void Create(Wishlist wishlist)
        {
           // throw new NotImplementedException();

            DB.Wishlists.Add(wishlist);
            DB.SaveChanges();
        }

        public Wishlist? GetAccountWishlist(int AccountId)
        {
            // throw new NotImplementedException();

            //return DB.Wishlists.Include(e=>e.Product).Where(e=>e.AccountID.Equals(AccountId)).ToList();

            //Account LoggedAccount = DB.Accounts.FirstOrDefault(a => a.Email == User.Email);
            return DB.Wishlists.FirstOrDefault(w => w.AccountID == AccountId);

        }

        public Wishlist GetWishlist(int Id)
        {
            // throw new NotImplementedException();

            return DB.Wishlists.FirstOrDefault(e => e.Id == Id);
           
        }

        public void Remove(Wishlist wishlist)
        {
           // throw new NotImplementedException();

            DB.Wishlists.Remove(wishlist);
            DB.SaveChanges();

        }
    }
}
