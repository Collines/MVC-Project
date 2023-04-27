using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models.Identity
{
    public class Phone
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^(([0-9]*)|(([0-9]*)\\.([0-9]*)))$", ErrorMessage = "Phone should be a number")]
        public required string Number { get; set; }

        [ForeignKey("Account")]
        [Required]
        public int AccountId { get; set; }
        public virtual Account? Account { get; set; }
    }
}
