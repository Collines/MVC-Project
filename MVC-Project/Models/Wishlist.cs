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
        public required int AccountID { get; set; }

        [ForeignKey("Product")]
        [Required]
        public required int ProductID { get; set; }
        public virtual Account? Account { get; set; }
        public virtual Product? Product { get; set; }
    }
}
