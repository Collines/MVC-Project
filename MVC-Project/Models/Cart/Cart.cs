using MVC_Project.Models.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models.Cart
{
    public class Cart
    {
        //private ICollection<CartItem> _cartItems;
        //public Cart()
        //{
            
        //}

        //private Cart(ILazyLoader lazyLoader)
        //{
        //    LazyLoader = lazyLoader;
        //}
        //private ILazyLoader LazyLoader { get; set; }
        public int Id { get; set; }

        [ForeignKey("Account")]
        public required int AccountId { get; set; }   
        
        [ForeignKey("Address")]
        public required int AddressId { get; set; }

        public double TotalPrice { get; set; }

        public double DiscountedPrice { get; set; }

        //public ICollection<CartItem> CartItems
        //{
        //    get => LazyLoader.Load(this, ref _cartItems);
        //    set => _cartItems = value;
        //}
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public virtual Account? Account { get; set; }
        public virtual Address? Address { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;

        public double GetTotalPrice()
        {
            double total = 0;
            if(CartItems.Count>0)
            {
                foreach (var item in CartItems)
                    total += item.PriceAfterDiscount * item.Quantity;
            }
            return total;
        }

        public double GetDiscountedPrice()
        {
            double total = 0;
            if (CartItems.Count > 0)
            {
                foreach (var item in CartItems)
                    total += item.DiscountedPrice * item.Quantity;
            }
            return total;
        }
    }
}
