using Microsoft.EntityFrameworkCore.Infrastructure;
using MVC_Project.Models.Identity;
using shopping.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models.Cart
{
    //public enum ShippingStatus
    //{
    //    Pending,
    //    AssignedToShipper,
    //    Shipped,
    //    OutForDelivery,
    //    Delivered
    //}
    public class CartItem
    {
        public CartItem()
        {
            
        }
        private Product _Product;
        private CartItem(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        private ILazyLoader LazyLoader { get; set; }
        public int Id { get; set; }

        public required int Quantity { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public required decimal Price { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal DiscountedPrice { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal PriceAfterDiscount { get; set; }

        [ForeignKey("Product")]
        public required int ProductId { get; set; }

        [Range(0, 1)]
        public float Discount { get; set; } = 0;

        [ForeignKey("Cart")]
        public required int CartId { get; set; }
        //public virtual Product Product { get; set; }
        public Product Product
        {
            get => LazyLoader.Load(this, ref _Product);
            set => _Product = value;
        }

        public virtual Cart? Cart { get; set; }


    }
}
