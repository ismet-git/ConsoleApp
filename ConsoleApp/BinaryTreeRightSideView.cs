using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class BinaryTreeRightSideView
    {
        //static void Main()
        //{
        //    BinaryTreeRightSideView t = new BinaryTreeRightSideView();

        //    // 1, 2, 3, null, 5, null, 4
        //    //          1
        //    //         / \
        //    //        2   3
        //    //         \   \
        //    //          5   4 

        //    // right side view: 1, 3, 4
        //    // left side view: 1, 2, 5 (*_*)
        //    Node root = new Node(1);
        //    root.left = new Node(2);
        //    root.left.right = new Node(5);
        //    root.right = new Node(3);
        //    root.right.right = new Node(4);


        //    // another tree
        //    // test left, right, top, bottom views
        //    //           1
        //    //         /    \
        //    //        2      3
        //    //       / \    / \
        //    //      6   5  4   7
        //    // rsv: 1, 3, 7
        //    // lsv: 1, 2, 6
        //    // tv: 6, 2, 1, 3, 7 (I got 1, 2, 3, 6, 7 these are the sides)
        //    // bv: 6, 5, 4, 7
        //    //Node root = new Node(1);       
        //    //root.left = new Node(2);
        //    //root.left.right = new Node(5);
        //    //root.left.left = new Node(6);
        //    //root.right = new Node(3);
        //    //root.right.right = new Node(7);
        //    //root.right.left = new Node(4);

        //    List<int> v = t.rightSideView(root);
        //    //List<int> v = t.leftSideView(root);
        //    //List<int> v = t.topSideView(root);
        //    Console.WriteLine("BinaryTreeRightSideView: ");
        //    v.ForEach(x => Console.Write(x + " "));
        //    Console.ReadKey();
        //}

        private List<int> topSideView(Node root)
        {
            List<int> r = new List<int>();
            if (root == null)
                return r;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            // BFS
            while (q.Count > 0)
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    Node current = q.Dequeue();

                    if (i == 0)
                        r.Add(current.data); // left side view  

                    if (i == size - 1)
                        r.Add(current.data); // right side view

                    if (current.left != null)
                        q.Enqueue(current.left);

                    if (current.right != null)
                        q.Enqueue(current.right);
                }
            }
            return r;
        }

        private List<int> leftSideView(Node root)
        {
            List<int> r = new List<int>();
            if (root == null)
                return r;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            // BFS
            while (q.Count > 0)
            {
                int size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    Node current = q.Dequeue();

                    if (i == 0)
                        r.Add(current.data); // left side view (*_*)

                    if (current.left != null)
                        q.Enqueue(current.left);

                    if (current.right != null)
                        q.Enqueue(current.right);
                }
            }
            return r;
        }

        private List<int> rightSideView(Node root)
        {
            List<int> r = new List<int>();
            if(root == null)
                return r;

            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            // BFS
            while(q.Count > 0)
            {
                int size = q.Count;
                for(int i = 0; i < size; i++)
                {
                    Node current = q.Dequeue();
                    if (i == size - 1)
                        r.Add(current.data); // right side view

                    if (current.left != null)
                        q.Enqueue(current.left);

                    if (current.right != null)
                        q.Enqueue(current.right);
                }
            }
            return r;
        }

        class Node
        {
            public int data;
            public Node left;
            public Node right;
            public Node(int v)
            {
                data = v;
            }
        }



    }
}
