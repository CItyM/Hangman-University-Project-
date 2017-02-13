using System;
using System.Collections.Generic;
using System.Linq;
using Hangman.Database;

namespace Hangman
{
    public class CRUDOperations
    {
        private  HangmanDB mDB;
        public CRUDOperations()
        {
            mDB = new HangmanDB();
        }

        public List<string> GetWordsNameByCategory(long categID)
        {
            var words = mDB.Words.Where(w => w.CategoryID == categID).Select(w => w.WordName).ToList();

            return words;
        }
      
        public string GetRandomWord(long categID)
        {
            var words = GetWordsNameByCategory(categID);
            var wordsCount = words.Count;
            var random = new Random();
            var randomNum = random.Next(0, wordsCount);
            var word = words[randomNum];

            return word;
        }

        public List<Word> GetWordsByCategory(long categID)
        {
            var words = mDB.Words.Where(w => w.CategoryID == categID).Select(w => w).ToList();

            return words;
        }

        public List<string> GetCategoryNames()
        {
            var categories = mDB.Categories.Select(c => c.CategoryName).OrderBy(c => c).ToList();

            return categories;
        }

        public long GetCategoryIDs(string categName)
        {
            var id = mDB.Categories.Where(c => c.CategoryName == categName).Select(c => c.ID).ToList();

            return id[0];
        }
    }
}
