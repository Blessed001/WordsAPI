using Microsoft.EntityFrameworkCore;
using WordsAPI.Models;

namespace WordsAPI.Data
{
    public class WordContext:DbContext
    {
        public WordContext(DbContextOptions<WordContext> options):base(options)
        {
            
        }

        public DbSet<Word> Words { get; set; }
        public DbSet<Author> Authors { get; set; }   
    }
}