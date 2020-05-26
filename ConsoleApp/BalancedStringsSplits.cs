using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class BalancedStringsSplits
    {
        //static void Main()
        //{
        //    BalancedStringsSplits b = new BalancedStringsSplits();
        //    string s = "RR"; // RL, LR, RRRLLL
        //    int m = b.balancedStringSplit(s);
        //    Console.WriteLine("max amount of splitted balanced strings: " + m);
        //    Console.ReadKey();
        //}

        int balancedStringSplit(string s)
        {
            int balancedCount = 0;
            int count = 0;

            for (int i=0; i < s.Length; i++)
            {
                if (s[i] == 'R')
                    count++;
                else
                    count--;

                if (count == 0)
                    balancedCount++;
            }

            return balancedCount;
        }
    }
}
