using System.ComponentModel.DataAnnotations;

namespace WordsAPI.DTOs
{
    public class CreateWordDTO
    {
        [Required]
        public string WordText { get; set; }
        
        [Required]
        public bool isNew { get; set; }
    }
}