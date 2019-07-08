using System.ComponentModel.DataAnnotations;

namespace StockSystem.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}