using Microsoft.EntityFrameworkCore.Infrastructure;
using MVC_Project.Models.Identity;
using shopping.Models;
using System.ComponentModel;
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
        //public CartItem()
        //{

        //}
        //private Product _Product;
        //private CartItem(ILazyLoader lazyLoader)
        //{
        //    LazyLoader = lazyLoader;
        //}
        //private ILazyLoader LazyLoader { get; set; }
        public int Id { get; set; }

        public required int Quantity { get; set; }

        [DataType(DataType.Currency)]
        //[Column(TypeName = "money")]
        public required double Price { get; set; }

        [DataType(DataType.Currency)]
        //[Column(TypeName = "money")]
        public double DiscountedPrice { get; set; }

        [DataType(DataType.Currency)]
        //[Column(TypeName = "money")]
        public double PriceAfterDiscount { get; set; }

        [ForeignKey("Product")]
        public required int ProductId { get; set; }

        [DefaultValue(0.00)]
        [Range(0.00,100.00)]
        public double Discount { get; set; }

        [ForeignKey("Cart")]
        public required int CartId { get; set; }

        public string ProductSKU { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Cart? Cart { get; set; }
        //public Product Product
        //{
        //    get => LazyLoader.Load(this, ref _Product);
        //    set => _Product = value;
        //}

    }
}