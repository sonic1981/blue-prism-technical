using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishWords.Graph.Imple
{
    public class GraphFactory : IGraphFactory
    {
        public ConcurrentDictionary<string, List<string>> BuildGraph(IEnumerable<string> words)
        {
            ConcurrentDictionary<string, List<string>> returnVal = new ConcurrentDictionary<string, List<string>>();
            Parallel.ForEach(words, word => {
                returnVal.TryAdd(word, findRelated(word, words).ToList());
            });


            return returnVal;
        }

        public bool IsOneCharacterDifferent(string str1, string str2)
        {
            //ignore duplicates
            if (str1 == str2)
                return false;
            int stringLengthDifference = str1.Length - str2.Length;
            //throw too large length difference first
            if (stringLengthDifference > 1 || stringLengthDifference < -1)
                return false;

            char[] char1 = str1.ToCharArray();
            char[] char2 = str2.ToCharArray();

            int differenceCount = 0;
            for (int cPos = 0; cPos < char1.Length && cPos < char2.Length; cPos++)
            {
                if (char1[cPos] != char2[cPos])
                    differenceCount++;

                if (differenceCount > 1)
                    return false;

            }

            if (stringLengthDifference == 0)
                return differenceCount == 1;
            else
                return differenceCount == 0;
            

        }

        private IEnumerable<string> findRelated(string word, IEnumerable<string> words)
        {
            foreach(string w in words)
            {
                if (IsOneCharacterDifferent(w, word))
                    yield return w;
            }
        }
    }
}
