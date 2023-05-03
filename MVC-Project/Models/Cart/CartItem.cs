using shopping.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models.Cart
{
    public class CartItem
    {
        public int Id { get; set; }

        public required int Quantity { get; set; }

        [DataType(DataType.Currency)]
        public required double Price { get; set; }

        [DataType(DataType.Currency)]
        public double DiscountedPrice { get; set; }

        [DataType(DataType.Currency)]
        public double PriceAfterDiscount { get; set; }

        [ForeignKey("Product")]
        public required int ProductId { get; set; }

        [DefaultValue(0.00)]
        [Range(0.00, 100.00)]
        public double Discount { get; set; }

        [ForeignKey("Cart")]
        public required int CartId { get; set; }

        public string ProductSKU { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}