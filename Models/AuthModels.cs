using System.ComponentModel.DataAnnotations;

namespace RaceDay.MVC.Models
{
    // 1. Used for the Login form
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }

    // 2. Used for the Register form
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "Participant"; // Default to Participant

        public DateTime? DateOfBirth { get; set; }
        public string? Phone { get; set; }

        // Organiser-specific fields
        public string? OrganisationName { get; set; }
        public string? Website { get; set; }

        // Participant-specific fields
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhone { get; set; }
        public string? MedicalConditions { get; set; }
    }

    // 3. Used to catch the response from the API when logging in
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}