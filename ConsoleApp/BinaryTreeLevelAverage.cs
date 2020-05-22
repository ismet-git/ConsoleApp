using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class BinaryTreeLevelAverage
    {
        // input: 4
        //       / \
        //      7   9
        //     / \   \
        //    10  2   6
        //         \
        //          6
        //          /
        //         2
        //
        // ouput: [4, 8, 6, 6, 2]

        //static void Main()
        //{
        //    Node node = new Node(4);
        //    node = new Node(4);
        //    node.Left = new Node(7);
        //    node.Right = new Node(9);
        //    node.Left.Left = new Node(10);
        //    node.Left.Right = new Node(2);
        //    node.Right.Right = new Node(6);
        //    node.Left.Right.Right = new Node(6);
        //    node.Left.Right.Right.Left = new Node(2);

        //    BinaryTreeLevelAverage tree = new BinaryTreeLevelAverage();
        //    //List<int> rDFS = tree.avgByLevel(node);
        //    //List<int> rDFS = tree.avgByLevel2(node);
        //    //List<int> r = avgByLevel(node); // if mthod is static 
        //    //rDFS.ForEach(i => Console.Write(i + " "));

        //    //List<int> rBFS = tree.avgByBFS(node);
        //    //rBFS.ForEach(i => Console.Write(i + " "));

        //    List<int> rDFS2 = tree.avgByDepth2(node);
        //    rDFS2.ForEach(i => Console.Write(i + " "));

        //    Console.ReadKey();

        //} // main

        public class Node
        {
            public int data;
            public Node Left, Right;
            public Node(int data)
            {
                this.data = data;
            }
        }

        public List<int> avgByBFS(Node root)
        {
            List<int> result = new List<int>();
            if (root == null) 
                return new List<int>();

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            int sum = 0;
            while(q.Count > 0)
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    Node node = q.Dequeue();
                    sum += node.data;

                    if(node.Left != null)
                    {
                        q.Enqueue(node.Left);
                    }

                    if(node.Right != null)
                    {
                        q.Enqueue(node.Right);
                    }
                }
                result.Add(sum / size);
                sum = 0;
            }

            return result;
        }

        public List<int> avgByLevel(Node node)
        {
            Dictionary<int, List<int>> data = new Dictionary<int, List<int>>();
            List<int> result = new List<int>();

            collectLevelData(node, data, 0);

            List<int> nums = new List<int>();
            int avg = 0;

            foreach(List<int> i in data.Values)
            {
                if(i.Count() > 0)
                avg = i.Sum() / i.Count();
                result.Add(avg);
            }
                        
            return result;
        }

        public void collectLevelData(Node node, Dictionary<int, List<int>> levelData, int depth = 0)
        {
            // this is DFS 
            if (node == null)
                return;

            if (!levelData.ContainsKey(depth))
            {
                levelData[depth] = new List<int>();
            }
            
           levelData[depth].Add(node.data);          

            collectLevelData(node.Left, levelData, depth + 1);
            collectLevelData(node.Right, levelData, depth + 1);

            //Console.WriteLine("Tree hieght: " + depth);
        }

        // 
        // print each level data:
        

        // method to view each level (visiual method for me)
        public List<int> avgByLevel2(Node node)
        {
            Dictionary<int, List<int>> data = new Dictionary<int, List<int>>();
            List<int> result = new List<int>();

            collectLevelData(node, data, 0);

            List<int> nums = new List<int>();
            int avg = 0;

            foreach (var i in data)
            {
                //if (i.Count() > 0)
                //    avg = i.Sum() / i.Count();
                //result.Add(avg);

                int d = i.Key;
                Console.Write("Level: " + d + ": ");
                i.Value.ForEach(x => Console.Write($"{x}, "));
                Console.WriteLine("\n-----------");
            }

            return result;
        }

        // DFS store sum and count of each level :

        public void collect2(Node node, Dictionary<int, (int leveSum, int count)> data, int depth)
        {
            // save sum and count in tuple at each level/height
            // method collect saves all the tree in hash map (i.e. data dictionary)
            // so collect2 reduces space complexity
            // 

            if (node == null)
                return;

            if (!data.ContainsKey(depth))
            {
                data[depth] = (node.data, 1);
            }
            else
            {
                var t = data[depth];
                t.leveSum = t.leveSum + node.data;
                t.count++;
                data[depth] = t;
            }

            collect2(node.Left, data, depth + 1);
            collect2(node.Right, data, depth + 1);
        }

        public List<int> avgByDepth2(Node node)
        {
            // input: 4
            //       / \
            //      7   9
            //     / \   \
            //    10  2   6
            //         \
            //          6
            //          /
            //         2
            //
            // ouput: [4, 8, 6, 6, 2]

            Dictionary<int, (int leveSum, int count)> data = new Dictionary<int, (int leveSum, int count)>();
            collect2(node, data, 0);
            List<int> result = new List<int>();

            int avg = 0;

            foreach (var i in data)
            {
                var nums = i.Value;

                if (nums.count > 0)
                {
                    avg = nums.leveSum / nums.count;
                }
                result.Add(avg);
            }

            return result;
        }

    }
}
