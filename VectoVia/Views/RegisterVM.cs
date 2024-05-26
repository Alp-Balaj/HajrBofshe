using System.ComponentModel.DataAnnotations;

namespace vectovia.Views
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "First name is required")]
        public string Emri { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string Mbiemri { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }
    }
}
