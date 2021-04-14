using System.Collections.Generic;
using WordsAPI.Models;

namespace WordsAPI.Data
{
    public interface IWordRepo
    {
         IEnumerable<Word> GetAll();

         Word GetWordById(int id);

         void CreateWord(Word word);
         void UpDateWord(Word word);
         void DeleteWord(Word word);
         bool SaveChanges();
    }
}