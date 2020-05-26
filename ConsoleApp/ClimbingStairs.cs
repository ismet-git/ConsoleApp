using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class ClimbingStairs
    {

        //static void Main()
        //{
        //    ClimbingStairs c = new ClimbingStairs();
        //    int ways = c.climbStairs(44);
        //    Console.WriteLine("ways: " + ways);
        //    Console.ReadKey();
        //}

        public int climbStairs(int nSteps)
        {
            int[] dp = new int[nSteps + 1];
            dp[0] = 1;
            dp[1] = 1;

            for(int i = 2; i <= nSteps; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[nSteps];

        }
    }
}
