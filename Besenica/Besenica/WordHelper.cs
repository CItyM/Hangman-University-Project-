using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class WordHelper
    {
        public static string NoFirstLast(string str)
        {
            str = str.Remove(str.Length-1, 1);
            str = str.Remove(0, 1);

            return str;
        }

        public static bool IsLeatherExists(string word, string leather, bool isExists,List<int> positions)
        {
            var leathers = new List<string>();
            foreach (var item in word)
            {
                leathers.Add(item.ToString());
            }

            for (int i = 0; i < leathers.Count; i++)
            {
                if (leathers[i]==leather)
                {
                    isExists = true;
                    positions.Add(i);
                }
            }

            return isExists;

        }

        public static List<string> LoadLeathers()
        {
            var leathers = new List<string>();
            for (char letter = 'А'; letter <= 'Я'; letter++)
            {
                leathers.Add(letter.ToString());
            }

            leathers.RemoveAt(27);
            leathers.RemoveAt(28);

            return leathers;
        }
    }
}
