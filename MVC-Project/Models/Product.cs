using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MVC_Project.Models.Cart;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;

namespace shopping.Models
{
    public class Product
    {
        private ICollection<Image> images;
        public Product()
        {
            
        }
        private Product(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }
        private ILazyLoader LazyLoader { get; set; }

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
        [Column(TypeName = "money")]
        public required decimal price { get; set; }

        [Range(1,int.MaxValue)]
        [Required]
        [RegularExpression("([1-9][0-9]*)")]
        public required int Quantity { get; set; }
        //public float ? Discount { get; set; }
        //public float Rate { get; set; }
        //List<string> Images { get; set; }   
        [Required]
        //public virtual ICollection<Image> Images { get; set; } = new HashSet<Image>();
        public ICollection<Image> Images
        {
            get => LazyLoader.Load(this, ref images);
            set => images = value;
        }

        [Required]
        [ForeignKey("Brand")]
        public required int BrandID { get; set; }

        [HiddenInput]
        [Editable(false)]
        public string? SKU { get; set; }
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
    }
}
