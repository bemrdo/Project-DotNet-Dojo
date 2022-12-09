using System.ComponentModel.DataAnnotations;

namespace Project_DotNet_Dojo.ViewModels
{
    public class Signup
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password and Confirmation Password did not match")]
        public string ConfirmPassword { get; set; }
    }
}
