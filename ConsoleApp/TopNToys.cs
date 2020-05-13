using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class TopNToys
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
        //                          "elantra is the best",
        //                          "elantra is the best",
        //                          "elantra is the best",
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
            var resultSet = new Dictionary<string, int>();

            for (int i = 0; i < numToys; i++)
            {
                foreach (var item in reviews)
                {
                    if (item.ToLower().Contains(toysNames[i].ToLower()))
                    {
                        if (resultSet.TryGetValue(toysNames[i], out int value))
                        {
                            resultSet[toysNames[i]]++;
                        }
                        else
                        {
                            resultSet.Add(toysNames[i], 1);
                        }
                    }
                }
            }

            resultSet = resultSet.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);


            List<string> lst = resultSet.Take(topKToys).Select(x => x.Key).ToList();

            return string.Join(", ", lst.ToArray());
        }
    }

}
