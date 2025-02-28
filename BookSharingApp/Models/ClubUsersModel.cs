using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookSharingApp.Models
{
    [Index(nameof(ClubId), nameof(UserId), IsUnique = true)]
    public class ClubUsersModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Id))]
        public int ClubId { get; set; }
        public ClubModel? Club { get; set; }
        public int UserId { get; set; }
        public UserModel? User { get; set; }
        public bool IsActive { get; set; } = true;
        [AllowedValues("admin", "clubadmin", "user")]
        public string Role { get; set; } = "user";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
