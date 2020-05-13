using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{

    class SolutionZ
    {

        /*
         
            Array Index & Element Equality
            The naive solution is to iterate over all the values in the input array and return an index i for which the condition arr[i] == i is met. 
            This takes a linear, O(N), time complexity.

            To do better, we should recognize that the sequence of i (array indices) and the sequence of arr[i] (array values) are both 
            strictly monotonically increasing sequences. If we subtract i from both sides of the equation arr[i] = i we get arr[i] - i = 0.

            While we can use this to define another array diffArr where diffArr[i] = arr[i] - i and perform a Binary Search for 0 in diffArr
            , it’s unnecessary. Instead, we can simply modify the binary search condition to arr[i] - i == 0 (instead of the condition diffArr[i] == 0).

            So why is it important for the search condition to form a monotonically increasing sequence?

            It’s important because otherwise there is no guarantee that the resulting sequence is sorted and binary search works only on sorted sequences. 
            Recall that if an array consists of monotonically increasing values, then it’s sorted by definition (in an ascending order).

            To make sure we found the first element that satisfies arr[i] - i == 0, 
            if in the binary search process we find an element that satisfies arr[i] - i == 0, 
            we proceed to check if its the first element in the array, or that the element before it does not satisfy the condition. 
            If not - we continue with the binary search, since this is not the first element that satisfies the condition.

            Time Complexity: O(log(N)) since we use a binary search where the input size is reduced in half on each step. 
            Calculating arr[i] - i as the condition instead of arr[i] is done in constant time and has no impact on the asymptotic time complexity.

            Space Complexity: it’s O(1) since we’re only a constant amount of memory (i.e. the variables start and end).

         */


        public static int IndexEqualsValueSearch(int[] arr)
        {
            //// your code goes here
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i] == i)
            //    {
            //        return i;
            //    }
            //}
            //return -1;

            int start = 0;
            int end = arr.Length - 1;
            int i = 0;

            while (start <= end)
            {
                i = ((start + end) / 2);
                if (arr[i] - i < 0)
                {
                    start = i + 1;
                }
                else if ((arr[i] - i == 0) && ((i == 0) || (arr[i - 1] - (i - 1) < 0))) {
                    return i;
                }
                else
                {
                    end = i - 1;
                }
            }

            return -1;

        }

        //static void Main(string[] args)
        //{

        //    int[] arr = new int[] { -8, 0, 2, 5 };
        //    int i = IndexEqualsValueSearch(arr);
        //    Console.WriteLine(i);

        //}
    }
}

/*
    Another Question: 
    Anonymous Love Letter
        L can be written by characters from N, if and only if every character in L is included in N at least by the same number of occurrences. 
        To determine that, we should count the number of occurrences for each character in L and determine if we have all of them, 
        at least at the same quantity in N. A good approach to do this is using a hash table. The hash key would be the character, 
        and the hash value would be the number of occurrences counted so far.

        Since all characters are ascii we can avoid the hash table and use a simple array of 256 integers, that we’ll name charMap. 
        Every index in charMap will hold the number of occurrences of the character represented by its ascii code. Since N is most likely much longer than L, 
        we start with counting the number of character occurrences in it first. That way, we’ll be able to stop processing N once we find all of L's characters in it, and reduce computational costs.

        After counting all character occurrences in L, we scan N and for each character, reduce its count on charMap if it is larger than 0. 
        If all counts in charMap are zero at some point, we return true. Otherwise, if we are done scanning N and at least one count is not 0, we return false.
        
        Pseudocode:

        function isLoveLetterReproducible(L, M):
           charMap = []
           charCount = 0

           for i from 0 to L.length:
              charCode = int(L.charAt(i)) 
              if (charMap[charCode] == 0):
                 charCount++
              charMap[charCode]++

           for i from 0 to N.length:
              charCode = int(N.charAt(i))
              if (charMap[charCode] > 0):
                 charMap[charCode]--
                 if (charMap[charCode] == 0):
                    charCount--
              if (charCount == 0):
                 return true

           return false
        Time Complexity: In the worst case we scan all of L and N linearly. 
                For each character we execute a constant number of operations. 
                Therefore, if m and n are the lengths of L and N, the runtime complexity is linear O(n+m).

        Space Complexity: Using the variable charCode is only to make the pseudocode above clearer and can be avoided (by using the value directly). 
                Other than that, since we use an array of constant size (256) and a constant number of variable, the space complexity is O(1).

 */


