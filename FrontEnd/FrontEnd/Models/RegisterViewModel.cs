using System;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public enum UserRole
    {
        User = 0,
        Owner = 1
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "ID number is required")]
        [Display(Name = "National ID")]
        public string IDNumber { get; set; }

        // Optional for now since we don't have file upload
        public string IDPhoto { get; set; }

        // Optional for now since we don't have file upload
        public string PersonPhoto { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public UserRole Role { get; set; } = UserRole.User;
    }
}