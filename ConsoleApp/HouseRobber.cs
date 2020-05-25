using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class HouseRobber
    {
        // { 1, 2, 3, 1} (4)
        // cannot rob adjacent house
        //static void Main(string[] args)
        //{
        //    // "12" = A, AB
        //    HouseRobber h = new HouseRobber();
        //    int[] moneyInHouse = { 1, 2, 3, 1 };
        //    int max = h.maxMoneyRobbed(moneyInHouse);

        //    Console.Write("Money in houses: ");
        //    moneyInHouse.ToList().ForEach(m => Console.Write(m + " "));
        //    Console.WriteLine("\nMax money robbed: " + max);
        //    Console.ReadKey();
        //}


        int maxMoneyRobbed(int[] moneyInHouse)
        {
            if (moneyInHouse == null || moneyInHouse.Length == 0)
                return 0;

            if (moneyInHouse.Length == 1) // one house only
                return moneyInHouse[0];

            if (moneyInHouse.Length == 2) // two houses then rob with more money
                return Math.Max(moneyInHouse[0], moneyInHouse[1]);

            // dynamic programming
            // use above cases to formulate the general logic
            int numOfHouses = moneyInHouse.Length;
            int[] dp = new int[numOfHouses];

            dp[0] = moneyInHouse[0]; // money in 1st house
            dp[1] = Math.Max(moneyInHouse[0], moneyInHouse[1]); // { 1, 2, 3, 1 }

            for (int i = 2; i < numOfHouses; i++)
            {
                int currentHouse = moneyInHouse[i];
                int twoHousesBehind = dp[i - 2];
                int previousHouse = dp[i - 1];

                dp[i] = Math.Max(currentHouse + twoHousesBehind, previousHouse);
                //dp[i] = Math.Max(moneyInHouse[i] + dp[i - 2], dp[i - 1]);
            }
           

            return dp[numOfHouses - 1];

        }
    }
}
