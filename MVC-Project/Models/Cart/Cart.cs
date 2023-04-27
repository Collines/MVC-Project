using MVC_Project.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models.Cart
{
    public class Cart
    {
        public int Id { get; set; }

        [ForeignKey("Account")]
        public required int AccountId { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public virtual Account? Account { get; set; }
        public virtual Address? Address { get; set; }
        public DateTime CreatedDate { get; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
