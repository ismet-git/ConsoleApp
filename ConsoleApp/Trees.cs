using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Trees
    {
        public void test_BinarySearchTree()
        {
            Node tree = new Node(10);
            tree.insert(5);
            tree.insert(15);
            tree.insert(3);
            //tree.insert(7);
            //tree.insert(33);
            //tree.insert(12);

            /**************************
                       10
                     /    \ 
                    5      15
                   / \    /  \
                  3   7  12  33 
             *************************/

            Console.WriteLine("In Order: L P R");
            tree.printInOrder();

            Console.WriteLine("\n\nPre Order: P L R");
            tree.printPreOrder();

            Console.WriteLine("\n\nPost Order: L R P");
            tree.printPostOrder();

            Console.WriteLine("\n\nTree hight: " + tree.treeHight(tree));

            Console.WriteLine("\n\nTree hight process: ");
            tree.treeHightProcess(tree);



        }
        

        public class Node
        {
            Node left, right;
            int data;

            public Node(int value)
            {
                data = value;
            }

            public void insert(int value)
            {
                if (value <= data)
                {
                    if (left == null)
                    {
                        left = new Node(value);
                    }
                    else
                    {
                        left.insert(value);
                    }
                }
                else
                {
                    if (right == null)
                    {
                        right = new Node(value);
                    }
                    else
                    {
                        right.insert(value);
                    }
                }
            }

            public bool find(int value)
            {
                if (value == data) {
                    return true;
                }
                else if (value < data) {
                    if (left == null) {
                        return false;
                    }
                    else {
                        return left.find(value);
                    }
                }
                else {
                    if (right == null) {
                        return false;
                    }
                    else {
                        right.find(value);
                    }
                }
                return false;
            } // find

            public void printInOrder()
            {
                if (left != null)
                {
                    left.printInOrder();
                }
                Console.Write(data + " ");

                if (right != null)
                {
                    right.printInOrder();
                }
            }

            public void printPreOrder()
            {
                Console.Write(data + " ");

                if (left != null)
                {
                    left.printPreOrder();
                }

                if (right != null)
                {
                    right.printPreOrder();
                }
            }

            public void printPostOrder()
            {
                if (left != null)
                {
                    left.printPostOrder();
                }

                if (right != null)
                {
                    right.printPostOrder();
                }

                Console.Write(data + " ");
            }

            public int treeHight(Node root)
            {
                //int h = 0;
                if (root == null)
                    return -1;

                int h = 1 + Math.Max(treeHight(root.left), treeHight(root.right));

                return h;
            }

            public int treeHightProcess(Node root)
            {
                //int h = 0;
                if (root == null)
                {
                    return -1;
                }

                if (root != null)
                    Console.WriteLine("R: " + root.data);

                if (root.left != null)
                Console.WriteLine("L: " + root.left.data);
                if (root.right != null)
                    Console.WriteLine("R: " + root.right.data);

                int h = 1 + Math.Max(treeHight(root.left), treeHight(root.right));

                return h;

            }

        }
    }
}
