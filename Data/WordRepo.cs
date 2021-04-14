using System;
using System.Collections.Generic;
using System.Linq;
using WordsAPI.Models;

namespace WordsAPI.Data
{
    public class WordRepo : IWordRepo
    {
        private readonly WordContext _context;
        public WordRepo(WordContext context)
        {
            _context = context;
        }

        public void CreateWord(Word word)
        {
            if (word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            _context.Words.Add(word);
        }

        public void DeleteWord(Word word)
        {
            if(word == null)
            {
                throw new ArgumentNullException(nameof(word));
            }

            _context.Words.Remove(word);
        }

        public IEnumerable<Word> GetAll()
        {
            var words = _context.Words.ToList();

            return words;
        }

        public Word GetWordById(int id)
        {
            var word = _context.Words.FirstOrDefault(w => w.Id == id);

            return word;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpDateWord(Word word)
        {
            //TODO
        }

    }
}