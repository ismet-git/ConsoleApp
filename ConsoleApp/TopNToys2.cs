using System;
using System.Collections.Generic;
using System.Linq;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class TopNToys2
    {

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Top N Toyes");
    
        //    Console.WriteLine(
        //        topToys(7   // numToys 
        //                , 2     // topToys 
        //                , new String[] { "elmo", "elsa", "legos", "drone", "tablet", "warcraft", "elantra" } // toysNames
        //                , 9     // numQuotes  (num of reviews)
        //                , new String[] {
        //                           "Elmo is the hottest of the season! Elmo will be on every kid's wishlist!",
        //                          "The new Elmo dolls are super high quality",
        //                          "Expect the Elsa dolls to be very popular this year, Elsa!",
        //                          "Elsa and Elmo are the toys I'll be buying for my kids, Elsa is good",
        //                          "For parents of older kids, look into buying them a drone",
        //                          "Warcraft is slowly rising in popularity ahead of the holiday season",
        //                          "Warcraft is the best",
        //                          "Warcraft is the best",
        //                          "Warcraft is the best",
        //                } // Qoutes (reviews)
        //            )
        //        );
        //    Console.ReadKey();
        //}

        private static string topToys(int numToys
            , int topKToys
            , string[] toysNames
            , int numReviews
            , string[] reviews)
        {
            var dicToysNamesCount = new Dictionary<string, int>();

            foreach(string name in toysNames)
            {
                dicToysNamesCount.Add(name, 0);
            }

            foreach (string toyName in toysNames)
            {
                foreach(string r in reviews)
                {
                    if(r.ToLower().Contains(toyName))
                    {
                        dicToysNamesCount[toyName]++;  
                    }

                }
            }

            var result = dicToysNamesCount.GroupBy(n => n.Value)
                // Order by the frequency 
                .OrderByDescending(g => g.Count())
                 .ThenBy(g => g.Key)
                .Select(k => new { word = k.Key, count = k.Count() })
                .Take(topKToys).ToList();

            // get top N toys names
            var l1 = dicToysNamesCount.OrderByDescending(x => x.Value);
            var l2 = l1.Take(topKToys);
            var l3 = l2.OrderBy(x => x.Key); // alphabatical order should be conditional if key(toy name) count is equal 


            List<string> l4 = l3.Select(x => x.Key).ToList();

            var l5 = string.Join(", ", l4.ToArray());

            return "";
        }
    }

}
