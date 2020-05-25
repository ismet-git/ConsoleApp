using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class DecodeWays
    {
        //static void Main(string[] args)
        //{
        //    // "12" = A, AB
        //    DecodeWays w = new DecodeWays();
        //    string s = "213"; // 2213 (5), 2277 (2) // 226 (3) // 213 = 2, 1, 3, 21, 13, 
        //    int m = w.NumDecodings2(s);
        //    Console.WriteLine("String : " + s);
        //    Console.WriteLine("Decode Ways: " + m);
        //    Console.ReadKey();
        //}

        public int NumDecodings(string s)
        {
            if (s.Length == 0 || s[0] == '0') return 0;
            // dp = dynamic programing: 
            // dp stores the number of ways to decode the digit string 
            int[] dp = new int[s.Length + 1];
            dp[0] = 1;
            dp[1] = s[0] == '0' ? 0 : 1;

            for (int i = 2; i <= s.Length; i++)
            {
                int oneDigit = Convert.ToInt32(s.Substring(i - 1, 1));
                int twoDigit = Convert.ToInt32(s.Substring(i - 2, 2));

                if (oneDigit >= 1)
                    dp[i] += dp[i - 1];

                if (twoDigit >= 10 && twoDigit <= 26)
                    dp[i] += dp[i - 2];
            }

            return dp[s.Length];
        }

        public int NumDecodings2(string s)
        {
            if (s.Length == 0 || s[0] == '0') return 0;

            int[] dp = new int[s.Length + 1];
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == '0')
                {
                    if (s[i - 1] != '1' && s[i - 1] != '2') return 0;
                    dp[i + 1] = dp[i - 1];
                }
                else if (s[i - 1] == '1' || (s[i - 1] == '2' && s[i] - '0' <= 6))
                {
                    dp[i + 1] = dp[i] + dp[i - 1];
                }
                else
                {
                    dp[i + 1] = dp[i];
                }
            }

            return dp[s.Length];
        }



    }
}
