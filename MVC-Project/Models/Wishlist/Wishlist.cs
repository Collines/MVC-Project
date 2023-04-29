using Microsoft.Build.Framework;
using MVC_Project.Models.Identity;
using shopping.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models.Wishlist
{
    public class Wishlist
    {
        private ICollection<Wishlistitem> _Wishlistitems;
        public Wishlist()
        {

        }


        public int Id { get; set; }

        [ForeignKey("Account")]
        [Required]
        public required int AccountID { get; set; }

        public virtual Account? Account { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
