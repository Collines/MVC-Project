using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace shopping.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }

        [Display(Name ="Category Name")]
        [Required]
        public required string CategoryName { get; set; }
        public virtual ICollection<Subcategory> SubCategories { get; set; } = new HashSet<Subcategory>();
    }
    
}
