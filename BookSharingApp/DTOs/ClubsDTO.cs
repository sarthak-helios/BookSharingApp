using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BookSharingApp.DTOs
{
    public class AddClubsDTO 
    {
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => _name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        public string Logo { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }

    public class ClubDropDown
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
