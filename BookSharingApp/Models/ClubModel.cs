using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace BookSharingApp.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class ClubModel
    {
        [Key]
        public int Id { get; set; }

        private string _name = string.Empty;

        [Required, Length(2, 30)]
        public string Name
        {
            get => _name;
            set => _name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        public string Logo { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
