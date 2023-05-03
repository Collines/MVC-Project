using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project.Models.Identity
{
    public enum Role
    {
        Customer,
        Vendor,
        Shipper,
        Administrator
    }
    public class Account
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        [Display(Name = "First Name")]
        public required string Firstname { get; set; }

        [MaxLength(30)]
        [Required]
        [Display(Name = "Last Name")]

        public required string Lastname { get; set; }

        [MaxLength(50)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password should match")]
        [NotMapped]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassowrd { get; set; }

        [HiddenInput]
        public string? HashSalt { get; set; }

        public virtual ICollection<Phone> PhoneNumbers { get; set; } = new List<Phone>();
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

        public bool IsActive { get; set; } = true;

        [Required]
        [EnumDataType(enumType: typeof(Role))]
        public Role UserRole { get; set; } = Role.Customer;

        public bool HasAddress(int addressId)
        {
            foreach (Address address in Addresses)
            {
                if (address.Id == addressId)
                    return true;
            }
            return false;
        }

        public int SelectedAddress()
        {
            foreach(Address a in Addresses)
            {
                if(a.IsDefault==true)
                    return a.Id;
            }
            return -1;
        }
    }
}
