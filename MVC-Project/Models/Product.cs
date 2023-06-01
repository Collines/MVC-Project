using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace shopping.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public required string ProductName { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public required double Price { get; set; }

        [Range(1, int.MaxValue)]
        [Required]
        [RegularExpression("^(([1-9]*)|(([1-9]*)))$")]
        public required int Quantity { get; set; }

        [Range(0, 100)]
        [RegularExpression("^(([.0-9]*)|(([0-9]*)))$")]
        [DefaultValue(0.00)]
        public double Discount { get; set; }

        [RegularExpression("^(([.0-9]*)|(([0-9]*)))$")]
        [DefaultValue(0.00)]
        public double Rate { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();

        [Required]
        [ForeignKey("Brand")]
        public required int BrandID { get; set; }

        [HiddenInput]
        [Editable(false)]
        public string? SKU { get; set; }
        //public string color { get; set; }
        //public bool IsHotDeal { get; set; }
        //public bool IsFeatured { get; set; }
        //public bool IsTrend { get; set; }
        public bool IsAvailable { get; set; }

        [Required]
        [ForeignKey("SubCategory")]

        public required int SubCategoryId { get; set; }

        public virtual Brand? Brand { get; set; }

        public virtual Subcategory? SubCategory { get; set; }

        public Image? GetMainImage()
        {
            if (Images.Count == 0) return null;
            return Images.FirstOrDefault();
        }

        public double PriceAfterDiscount() => Price * (1 - Discount / 100);
        public double DiscountedAmount() => Price * (Discount / 100);
        public bool IsInStock() => Quantity > 0;
    }
}
