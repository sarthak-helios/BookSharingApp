using System.ComponentModel.DataAnnotations;

namespace BookSharingApp.DTOs
{
    public class GetOTPDTO
    {
        [EmailAddress,Required]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }

    public class VerifyUserDTO
    {
        public string Email { get; set; } = string.Empty;
        public int ClubId { get; set; }
        public string OTP { get; set; } = string.Empty;
    }
    
    public class ForgotPassDTO
    {
        public string Email { get; set; } = string.Empty;
    }
    public class ResetPassDTO
    {
        public string Email { get; set; } = string.Empty;
        public string OTP { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
