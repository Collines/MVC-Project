using System.ComponentModel.DataAnnotations;
<<<<<<< Updated upstream:MVC-Project/Models/SubCategory.cs
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
=======

namespace MVC_Project.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCatId { get; set; }
        public string SubCatName { get; set; }

        public List<Product> PrdList { get; set; }
>>>>>>> Stashed changes:MVC-Project/MVC-Project/Models/SubCategory.cs
    }
}
