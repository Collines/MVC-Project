using System.ComponentModel.DataAnnotations;

namespace MVC_Project.Helpers.Validators
{
    public class IsUniqueAttribute : ValidationAttribute
    {
        AppDBContext db = new AppDBContext();
        public override bool IsValid(object? value) => value is string Email && !db.Accounts.Any(A=>A.Email==Email);
    }
}
