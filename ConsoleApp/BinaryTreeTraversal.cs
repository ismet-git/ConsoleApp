using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class BinaryTreeTraversal
    {
        static void Main()
        {
            BinaryTreeTraversal t = new BinaryTreeTraversal();
            //    1
            //     \
            //      2
            //     /
            //    3
            // post-order: 3, 2, 1
            //TreeNode root = new TreeNode(1);
            //root.right = new TreeNode(2);
            //root.right.left = new TreeNode(3);

            //    1
            //   / \
            //  0   2
            //     / \
            //    3   4
            // post-order: 0, 3, 4, 2, 1
            TreeNode root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.left = new TreeNode(0);
            root.right.left = new TreeNode(3);
            root.right.right = new TreeNode(4);

            List<int> po = t.PostorderTraversal(root);
            Console.WriteLine($"Postorder Traversal: ");
            po.ForEach(x => Console.Write(x + " "));
            Console.WriteLine($"");
            Console.ReadKey();
        }

        // iterative approach
        public List<int> PostorderTraversal(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            List<int> result = new List<int>();
            for (TreeNode lastNode = null, peek; root != null || stack.Count != 0;)
                if (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                else if ((peek = stack.Peek()).right != null && peek.right != lastNode)
                    root = peek.right;
                else
                {
                    result.Add(peek.val);
                    lastNode = stack.Pop();
                }
            return result;
        }

        // simpler version using pre-order traversal and reversing the result upon return.
        public List<int> PostorderTraversal2(TreeNode root)
        {
            var result = new List<int>();

            if (root == null) return result;

            var stack = new Stack<TreeNode>();
            stack.Push(root);

            while (stack.Any())
            {
                var cur = stack.Pop();
                result.Add(cur.val);

                if (cur.left != null)
                {
                    stack.Push(cur.left);
                }

                if (cur.right != null)
                {
                    stack.Push(cur.right);
                }
            }

            result.Reverse();

            return result;
        }


        public List<int> PostorderTraversal3(TreeNode root) //Recursive 
        {
            List<int> res = new List<int>();
            Recursive(root, res);
            return res;
        }

        public void Recursive(TreeNode node, List<int> res)
        {
            if (node == null) return;
            Recursive(node.left, res);
            Recursive(node.right, res);
            res.Add(node.val);
        }

        public List<int> PostorderTraversal4(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            Stack<int> res = new Stack<int>();
            if (root != null) stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                res.Push(node.val);
                if (node.left != null) stack.Push(node.left);
                if (node.right != null) stack.Push(node.right);
            }
            return res.ToList();
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int v)
            {
                val = v;
            }
        }

    }
}
