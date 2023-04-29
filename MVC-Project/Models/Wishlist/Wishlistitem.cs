using System.ComponentModel.DataAnnotations.Schema;
using shopping.Models;


namespace MVC_Project.Models.Wishlist
{
    public class Wishlistitem
    {
        public Wishlistitem()
        {

        }
        public int Id { get; set; }
        public required decimal Price { get; set; }
        [ForeignKey("Product")]

        public required int ProductId { get; set; }
        [ForeignKey("Wishlist")]

        public required int WishlistId { get; set; }
        public virtual Wishlist? Wishlist { get; set; }

        private Product _Product;
    }
}
