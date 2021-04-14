using System.ComponentModel.DataAnnotations;

namespace WordsAPI.DTOs
{
    public class UpDateWordDTO
    {
        [Required]
        public string WordText { get; set; }
        
        [Required]
        public bool isNew { get; set; }
    }
}