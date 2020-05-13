using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class TopKFrequentClass
    {

        //static void Main()
        //{
        //    //int[] arr = new int[] { 11, 2, 7, 9, 9, 9, 5, 5, 5, 5 };
        //    int[] arr = new int[] { 9, 9, 9, 5, 5, 5, 5, 11, 2, 7 };
        //    int topK = 2;

        //    List<int> topKList = TopKFrequent(arr, topK);

        //    topKList.ForEach(i => Console.WriteLine(i));
        //    Console.ReadKey();
        //}

        static List<int> TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> countsMap = new Dictionary<int, int>();
            int maxCount = 0;
            foreach (int x in nums)
            {
                int currCount = countsMap.ContainsKey(x) ? countsMap[x] + 1 : 1;
                countsMap[x] = currCount;
                maxCount = currCount > maxCount ? currCount : maxCount;
            }

            // build array (sorted by count) containing a list of elements with a given count
            // array size - max count (so space complexity is O(N) )
            IList<int>[] countsArr = new IList<int>[maxCount + 1];
            foreach (int x in countsMap.Keys)
            {
                int currCount = countsMap[x];
                if (countsArr[currCount] == null) countsArr[currCount] = new List<int>();
                countsArr[currCount].Add(x);
            }

            // work from largest and accumulate result
            List<int> topK = new List<int>();
            for (int i = countsArr.Length - 1; i >= 0 && k > 0; i--)
            {
                if (countsArr[i] != null)
                {
                    foreach (int x in countsArr[i]) topK.Add(x);
                    k -= countsArr[i].Count;
                }
            }
            return topK;
        }

    }
}
