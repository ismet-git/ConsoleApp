using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class AlienDictionary
    {


        //static void Main(string[] args)
        //{
        //    AlienDictionary ad = new AlienDictionary();

        //    // "hello", "leetcode", "hlabcdefgijkmnopqrstuvwxyz"
        //    //  ["word","world","row"], order = "worldabcefghijkmnpqstuvxyz"
        //    // words = ["apple","app"], order = "abcdefghijklmnopqrstuvwxyz"

        //    string[] words = { "app", "apple" };
        //    string order = "abcdefghijklmnopqrstuvwxyz";

        //    bool b = ad.IsAlienSorted(words, order);
        //    Console.WriteLine("[{0}]", string.Join(", ", words));
        //    Console.WriteLine("order: " + order);
        //    Console.WriteLine("IsAlienSorted: " + b);
        //    Console.ReadKey();
        //}


        /*
   public bool IsAlienSorted(string[] words, string order) {
       var idx = order
           .Select((x, i) => new { val = x, idx = i })
           .ToDictionary(x => x.val, x => x.idx);

       var sorted = words.OrderBy(
           x => string.Join(string.Empty, x.Select(y => (char)('a' + idx[y]))))
           .ToArray();
       return words.Zip(sorted, (a, b) => a == b).All(x => x);
   }
   */

        /*
        public bool IsAlienSorted(string[] words, string order) {

            Dictionary<char, int> dic = new Dictionary<char,int>();
            for(int i = 0; i < order.Length; i++)
                dic.Add(order[i], i);

            for(int j = 0; j < words.Length - 1; j++)
            {
                if(!VerifyWordOrder(words[j], words[j + 1], dic))
                    return false;
            }

            return true;
        }

        private bool VerifyWordOrder(string word1, string word2, Dictionary<char, int> dic)
        {
            int length = Math.Min(word1.Length, word2.Length);
            for(int i = 0; i < length; i++)
            {
                if(dic[word1[i]] < dic[word2[i]])
                    return true;
                else if(dic[word1[i]] == dic[word2[i]])
                    continue;
                else
                    return false;
            }

            return word1.Length < word2.Length;
        }
        */

        public bool IsAlienSorted(string[] words, string order)
        {
            int[] index = new int[26];
            for (int i = 0; i < order.Length; i++)
            {
                index[order[i] - 'a'] = i;
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                string word1 = words[i];
                string word2 = words[i + 1];

                int minLen = word1.Length > word2.Length ? word2.Length : word1.Length;

                for (int j = 0; j < minLen; j++)
                {

                    if (index[word1[j] - 'a'] < index[word2[j] - 'a'])
                    {
                        break;
                    }
                    else if (index[word2[j] - 'a'] < index[word1[j] - 'a'])
                    {
                        return false;
                    }
                    else if (j == minLen - 1 && word1.Length > word2.Length)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}
