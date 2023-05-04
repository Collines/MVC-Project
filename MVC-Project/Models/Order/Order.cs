using MVC_Project.Models.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models.Order
{
    public enum OrderStatus
    {
        PendingPayment,
        Failed,
        Processing,
        Completed,
        OnHold,
        Cancelled,
        Refunded
    }
    public enum PaymentMethod
    {
        Paypal
    }
    public class Order
    {
        public int Id { get; set; }

        [ForeignKey("Account")]
        [Required]
        public required int CustomerId { get; set; }

        [ForeignKey("Address")]
        [Required]
        public required int AddressId { get; set; }

        [ForeignKey("Cart")]
        [Required]
        public required int CartId { get; set; }

        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus? OrderStatus { get; set; }

        [DataType(DataType.Currency)]
        public required double TotalPaid { get; set; }

        [EnumDataType(typeof(PaymentMethod))]
        public required PaymentMethod PaymentMethod { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }

        public virtual Invoice? Invoice { get; set; }
        public virtual Address? Address { get; set; }
        public virtual Account? Customer { get; set; }
        public virtual Cart.Cart? Cart { get; set; }
    }
}
