using System.ComponentModel.DataAnnotations;

namespace GymMe.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z\s]{5,15}$", ErrorMessage = "Username must be between 5 and 15 alphabetic characters with spaces only")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid Email Address")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public required string Gender { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Password must be alphanumeric")]
        [Compare("ConfirmPassword", ErrorMessage = "Password and Confirmation Password must match.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public required string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
