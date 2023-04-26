using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace shopping.Models
{
    public class Subcategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        [Required]
        public required string SubCategoryName { get; set; }
        [Required]
        public required int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
