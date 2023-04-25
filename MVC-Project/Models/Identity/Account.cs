using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC_Project.Helpers.Validators;

namespace MVC_Project.Models.Identity
{
    public enum Role
    {
        Customer,
        Vendor,
        Administrator
    }
    public class Account
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        [Display(Name ="First Name")]
        public string Firstname { get; set; }

        [MaxLength(30)]
        [Required]
        [Display(Name = "Last Name")]

        public string Lastname { get; set; }

        [MaxLength(50)]
        [Required]
        [DataType(DataType.EmailAddress)]
        [IsUnique(ErrorMessage ="This Email already exist")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password should match")]
        [NotMapped]
        [Display(Name="Confirm Password")]
        public string ConfirmPassowrd { get; set; }

        [HiddenInput]
        public string? HashSalt { get; set; }

        //[DataType(DataType.Upload)]
        //public byte[] ProfileImage { get; set; }

        public bool isActive { get; set; } = true;

        [Required]
        [EnumDataType(enumType:typeof(Role))]
        public Role UserRole { get; set; } = Role.Customer;
    }
}
