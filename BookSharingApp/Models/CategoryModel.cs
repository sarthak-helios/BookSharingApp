using System.ComponentModel.DataAnnotations;

namespace BookSharingApp.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3), MaxLength(30)]
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; } = String.Empty;
        public bool IsActive { get; set; } = true;
    }
}
