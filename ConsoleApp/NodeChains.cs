using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{

    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }
    class NodeChains
    {

        //static void Main()
        //{
        //    Console.WriteLine("Node Chains started:...");
        //    Console.WriteLine("3 --> 5 --> 7");

        //    Node f = new Node { Value = 3 };
        //    Node m = new Node { Value = 5 };
        //    f.Next = m;
        //    Node l = new Node { Value = 7 };
        //    m.Next = l;

        //    PrintList(f);

        //} // Main

        private static void PrintList(Node f)
        {
            while(f != null)
            {
                Console.WriteLine(string.Format("Node value: {0}, Name: {1} ", f.Value,  f.GetType().GetHashCode()) );
                f = f.Next;
            }
        }
    }
}
