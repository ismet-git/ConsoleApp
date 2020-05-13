using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Fibonacci
    {

        // f(n) = f(n-1) + f(n-2);
        // 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, ...
        // 1, 2, 3, 4, 5, 6, 07, 08, 09, ...
        // 3 = 2 + 1
        // 5 = 3 + 2
        // 8 = 5 + 3

        public Int64 getFibValueRecursivelyWithMemo(int n, Int64[] memo)
        {

            if (n <= 0)
                return 0;
            else if (n == 1)
                return 1;
            else if (memo[n] == 0)
            {
                memo[n] = getFibValueRecursivelyWithMemo(n - 1, memo) + getFibValueRecursivelyWithMemo(n - 2, memo);
            }
            return memo[n];
        }

        public Int64 getFibValueRecursively(int n)
        {

            Int64 r = 0;
            Int64[] arr = new Int64[n];

            if (n == 0)
            {
                //Console.WriteLine($"Fibonacci of {n} is {r}");
                return 0;
            }

            if (n == 1 || n == 2)
            {
                r = 1;
                //Console.WriteLine($"Fibonacci of {n} is {r}");
                return 1;
            }
            
            r = getFibValueRecursively(n - 2) + getFibValueRecursively(n - 1);

            //Console.WriteLine($"Fibonacci of {n} is {r}");
            return r;

        }

        public void getFibNValue(Int64 n)
        {
            Int64 f = 1;
            Int64 a = 1;
            Int64 b = 1;

            if (n > 2)
            {
                for (int i = 3; i <= n; i++)
                {
                    f = a + b;
                    a = b;
                    b = f;
                }
            }

            Console.WriteLine($"Fibonacci valu of {n} = {f}");
           
        }

        public void printFibSequence(int n)
        {
            Int64 f = 1;
            Int64 a = 1;
            Int64 b = 1;

            Console.WriteLine($"Fibonacci sequence of {n}: ");

            if(n == 1)
            {
                Console.Write("1 ");
            }

            if (n == 2)
            {
                Console.Write("1 1");
            }

            if (n > 2)
            {
                Console.Write("1 1 ");
                for (int i = 3; i <= n; i++)
                {
                    f = a + b;
                    a = b;
                    b = f;
                    Console.Write($"{f} ");
                }
            }



        }
    }
}
