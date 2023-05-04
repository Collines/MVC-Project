<<<<<<< Updated upstream:MVC-Project/Models/Product.cs
﻿using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

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
        public required string description { get; set; }

        [Required]
        [Range(0, float.MaxValue)]
        [DataType(DataType.Currency)]
        public required float price { get; set; }

        [Range(1,int.MaxValue)]
        [Required]
        [RegularExpression("([1-9][0-9]*)")]
        public required int Quantity { get; set; }
        //public float ? Discount { get; set; }
        //public float Rate { get; set; }
        //List<string> Images { get; set; }   
        [Required]
        public ICollection<Image> Images { get; set; } = new HashSet<Image>();

        [Required]
        [ForeignKey("Brand")]
        public required int BrandID { get; set; }
        //public string color { get; set; }
        //public bool IsHotDeal { get; set; }
        //public bool IsFeatured { get; set; }
        //public bool IsTrend { get; set; }
        public bool IsAvailable { get; set; }
/*        [Required]
        [ForeignKey("Category")]

        public int CategoryId { get; set; }*/
        [Required]
        [ForeignKey("SubCategory")]

        public required int SubCategoryId { get; set; }
        public virtual Brand? Brand { get; set; }
        public virtual Subcategory? SubCategory { get; set; }
        //public virtual Category? Category { get; set; }
=======
﻿using System.ComponentModel.DataAnnotations;

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


>>>>>>> Stashed changes:MVC-Project/MVC-Project/Models/Product.cs
    }
}
