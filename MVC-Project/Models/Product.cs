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
        public required double Price { get; set; }

        [Range(1, int.MaxValue)]
        [Required]
        [RegularExpression("([1-9][0-9]*)")]
        public required int Quantity { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        [ForeignKey("Brand")]
        public required int BrandID { get; set; }

        [Required]
        [ForeignKey("SubCategory")]

        public required int SubCategoryId { get; set; }

        public virtual Brand? Brand { get; set; }

        public virtual Subcategory? SubCategory { get; set; }

        public ICollection<Image> Images { get; set; } = new HashSet<Image>();

        public Image? GetMainImage()
        {
            if (Images.Count == 0) return null;
            return Images.FirstOrDefault();
        }
    }
}
