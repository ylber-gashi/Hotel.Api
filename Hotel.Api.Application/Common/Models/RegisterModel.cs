using Hotel.Api.Domain.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Api.Application.Common.Models
{
    public class RegisterModel
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }
    }
}
