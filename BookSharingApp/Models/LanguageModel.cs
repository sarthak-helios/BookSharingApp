using System.ComponentModel.DataAnnotations;

namespace BookSharingApp.Models
{
    public class LanguageModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
