using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        public string CatName { get; set; }
        public List<SubCategory> SubCatList { get; set; }

    }
}
