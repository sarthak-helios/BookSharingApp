using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookSharingApp.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Profile { get; set; } = "default.jpg";
        public string Name { get; set; } = string.Empty;
        [Required, Phone]
        public string Mobile { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
        public bool MFA { get; set; } = true;
        public bool IsActive { get; set; } = true;
        [Range(-100, 10000)]
        public int Points { get; set; } = 0;
        public DateTime? LastLogIn { get; set; } = DateTime.UtcNow;
        public string? ResetToken { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
