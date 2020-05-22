using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class LabelPartition
    {
        //static void Main(string[] args)
        //{

        //    string s = "ababcbacadefegdehijhklij";   //
        //    List<int> b = PartitionLabels(s);
        //    b.ForEach(x => Console.Write(x + " " ));       
        //    Console.ReadKey();

        //}

        private static List<int> PartitionLabels(string s)
        {
            List<int> partitionLengths = new List<int>();
            int[] lastIndexes = new int[26];

            for(int i = 0; i < s.Length; i++)
            {
                lastIndexes[s[i] - (int)'a'] = i;
            }

            int f = 0; // index of first letter occurrence
            int n = 0;  // index next letter occurrence 
            int end = 0; // last letter occurenece 
            while(f < s.Length)
            {
                end = lastIndexes[s[f] - (int)'a'];
                n = f;

                while(n != end)
                {
                    int nextLetterLastIndex = lastIndexes[s[n++] - (int)'a'];
                    end = Math.Max(end, nextLetterLastIndex);
                }

                 partitionLengths.Add( n - f + 1);
                f = n + 1;

            }

            return partitionLengths;
            
        }
    }
}
