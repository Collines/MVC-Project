using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Models
{
    public class Product
    {
        [Key]
        public int PrdId { get; set; }
        public string PrdName { get; set; }
        public string Description { get; set; }
        public float Rate { get; set; }
        public float Price { get; set; }
        public float Size { get; set; }
        public string ImgUrl { get; set; }


    }
}
