using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class StockMaxProfit
    {
        //static void Main(string[] args)
        //{
        //    StockMaxProfit s = new StockMaxProfit();
        //    int[] prices = new int[] { 7, 1, 5, 3, 6, 4 }; // 7, 1, 5, 3, 6, 4  // 7, 6, 4, 3, 1 
        //    int m = s.stockMaxProfit(prices);
        //    int t = s.stockTotalProfit(prices);
        //    Console.WriteLine("Max profit: " + m);
        //    Console.WriteLine("Total profit: " + t);
        //    Console.ReadKey();
        //}

        public int stockMaxProfit(int[] stockPrices)
        {
            int minPrice = int.MaxValue;
            int maxProfit = 0;

            for (int d = 0; d < stockPrices.Length; d++)
            {

                if (stockPrices[d] < minPrice) {
                    minPrice = stockPrices[d];
                }
                else {
                    maxProfit = Math.Max(maxProfit, stockPrices[d] - minPrice);
                }
            }
            return maxProfit;
        }

        public int stockTotalProfit(int[] stockPrices)
        {
            int totalProfit = 0;

            for (int d = 0; d < stockPrices.Length - 1; d++)
            {
                if (stockPrices[d+1] > stockPrices[d])
                {
                    totalProfit += stockPrices[d + 1] - stockPrices[d];
                }               
            }
            return totalProfit;
        }
    }
}
