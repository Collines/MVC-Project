using System.ComponentModel.DataAnnotations;
<<<<<<< Updated upstream:MVC-Project/Models/Category.cs
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
    
=======

namespace MVC_Project.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        public string CatName { get; set; }
        public List<SubCategory> SubCatList { get; set; }

    }
>>>>>>> Stashed changes:MVC-Project/MVC-Project/Models/Category.cs
}
