using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Anagram
    {
        static void Main(string[] args)
        {

            string s = "moon";
            string t = "nnoo";
            bool b = isAnagram2(s, t);
            Console.WriteLine(b);

            Console.ReadKey();

        }

        // 
        static bool isAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            int[] counter = new int[26];
            for(int i=0; i < s.Length; i++)
            {
                counter[s[i] - (int)'a']++;
                counter[t[i] - (int)'a']--;
            }

            for(int i=0; i < counter.Length; i++)
            {
                if (counter[i] != 0)
                    return false;
            }

            return true;
        }

        static bool isAnagram2(string a, string b)
        {
            if (a.Length != b.Length) return false;
            List<char> list1 = a.ToList();
            List<char> list2 = b.ToList();
            for (int i = 0; i < a.Length; i++)
            {
                // try to remove list 1 item from list 2
                // if didn't find any thing to remove. so they are not anagram
                if (!list2.Remove(list1[i])) return false;
            }
            return true; // loop finished successfully. they are anagram
        }
    }
}
