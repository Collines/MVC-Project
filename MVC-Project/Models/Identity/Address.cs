using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models.Identity
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Addr { get; set; }

        [MaxLength(5)]
        [RegularExpression("^(([0-9]*)|(([0-9]*)\\.([0-9]*)))$",ErrorMessage ="Appartment/Suite should be a number")]
        public string? AppartmentSuite { get; set; }

        [Required]
        [MaxLength(50)]
        public required string TownCity { get; set; }

        [Required]
        [MaxLength(50)]
        public required string State { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression("^(([0-9]*)|(([0-9]*)\\.([0-9]*)))$", ErrorMessage = "Zipcode should be a number")]
        public required string Zipcode { get; set; }

        [ForeignKey("Account")]
        [Required]
        public int AccountId { get; set; }
        public virtual Account? Account { get; set; }
    }
}
