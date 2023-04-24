using Microsoft.Build.Framework;
using MVC_Project.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace shopping.Models
{
    public class Wishlist
    {
        public int Id { get; set; }

        [ForeignKey("Account")]
        [Required]

        public int AccountID { get; set; }

        [ForeignKey("Product")]
        [Required]
        public int ProductID { get; set; }
        public virtual Account? Account { get; set; }
        public virtual Product? Product { get; set; }
    }
}
