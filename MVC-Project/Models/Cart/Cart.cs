using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using MVC_Project.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models.Cart
{
    public class Cart
    {
        private ICollection<CartItem> _cartItems;
        public Cart()
        {
            
        }

        private Cart(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        private ILazyLoader LazyLoader { get; set; }
        public int Id { get; set; }

        [ForeignKey("Account")]
        public required int AccountId { get; set; }

        public ICollection<CartItem> CartItems
        {
            get => LazyLoader.Load(this, ref _cartItems);
            set => _cartItems = value;
        }
        //public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public virtual Account? Account { get; set; }
        public virtual Address? Address { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
