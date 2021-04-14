using System.ComponentModel.DataAnnotations;

namespace WordsAPI.Models
{
    public class Word
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string WordText { get; set; }
        
        [Required]
        public bool isNew { get; set; }

        public int AuthorId { get; set; }

       // public virtual Author Author { get; set; }

    }
}