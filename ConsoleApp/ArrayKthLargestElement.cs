using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class ArrayKthLargestElement
    {
        static void Main()
        {
            ArrayKthLargestElement l = new ArrayKthLargestElement();
            int[] arr = new int[] {3, 2, 1, 5, 6, 4 };
            int k = 2;
            int kth = l.findKthLargest(arr, k);
            arr.ToList().ForEach(x => Console.Write(x + " "));
            Console.WriteLine($"\nArray {k}th Largest Element: {kth}");            
            Console.ReadKey();
        }

        int findKthLargest(int[] arr, int k)
        {
            Array.Sort(arr);
            return arr[arr.Length - k];
        }
    }
}
