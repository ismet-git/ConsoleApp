using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Graph
    {
        Dictionary<int, Node> nodeLookup = new Dictionary<int, Node>();
        public class Node
        {
            private int id;
            LinkedList<Node> adjacent = new LinkedList<Node>();
            public Node(int id)
            {
                this.id = id;
            }

            Node getNode(int id) { return new Node(0);  }

            void addedge(int source, int destination) { }

            //public bool hasPathDFS(int source, int destination)
            //{
            //    Node s = getNode(source);
            //    Node d = getNode(destination);
            //    HashSet<int> visited = new HashSet<int>();
            //}
        }
    }
}
