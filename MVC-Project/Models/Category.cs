using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace shopping.Models
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Subcategory> SubCategories { get; set; } = new HashSet<Subcategory>();
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
    
}
