using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCatId { get; set; }
        public string SubCatName { get; set; }

        public List<Product> PrdList { get; set; }
    }
}
