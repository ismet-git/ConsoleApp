using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Code
    {
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello world !");

        //    var x = topNCompetitors(5, 2,
        //            new List<string> { "comp1", "comp2", "comp3" },
        //            3,
        //            new List<string> { "comp1 is best", "comp1 is gd", "comp3 is excellent" }
        //        );

        //}

        static List<string> topNCompetitors(int numCompetitors,
                                    int topNCompetitors,
                                    List<string> competitors,
                                    int numReviews, List<string> reviews)
        {
            var topN = new SortedList<string, int>();
            var lst = new List<string>();
            foreach(string c in competitors)
            {
                var f = reviews.FindAll(x => x.Contains(c));
                if (f.Count > 0)
                    topN.Add(c, f.Count);
            }

            //var sl = topN.Keys;

            //for (int i = 0; i < topNCompetitors; i++)
            //{
            //    lst.Add(topN[i].k);
            //}
            List<string> ls = topN.Keys.ToList<string>();
            return lst;
            

            //return new List<string>();
        }

    }
}
