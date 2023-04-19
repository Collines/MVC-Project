using OnlineShopping.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace shopping.Models
{
    public class Product
    {
       [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        //public string description { get; set; }
        //public float price { get; set; }
        //public float Quantity { get; set; }
        //public float ? Discount { get; set; }
        //public float Rate { get; set; }
        //List<string> Images { get; set; }   
        //public Brand brand { get; set; }
        //public string color { get; set; }
        //public bool IsHotDeal { get; set; }
        //public bool IsFeatured { get; set; }
        //public bool IsTrend { get; set; }
        //public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public int ? SubCategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual Subcategory SubCategory { get; set; }
    }
}
