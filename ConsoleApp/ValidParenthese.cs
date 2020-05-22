using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class ValidParenthese
    {

        //static void Main(string[] args)
        //{

        //    string s = "{(}}";  // "()[]{}"
        //    bool b = IsValid3(s);
        //    Console.WriteLine(b);

        //    Console.ReadKey();

        //}

        static bool IsValid3(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (var c in s.ToCharArray())
                if (c == '(') stack.Push(')');
                else if (c == '[') stack.Push(']');
                else if (c == '{') stack.Push('}');
                else if (stack.Count == 0 || stack.Pop() != c)
                    return false;

            return stack.Count == 0;
        }

        static bool IsValid2(string s)
        {
            // faster based on LeetCode
            Stack<char> stack = new Stack<char>();

            foreach (var c in s)
            {
                if (c == '(' || c == '{' || c == '[') { stack.Push(c); }
                else if (c == ')' && stack.Count > 0 && stack.Peek() == '(') { stack.Pop(); }
                else if (c == ']' && stack.Count > 0 && stack.Peek() == '[') { stack.Pop(); }
                else if (c == '}' && stack.Count > 0 && stack.Peek() == '{') { stack.Pop(); }
                else { return false; } 
            }

            return stack.Count == 0;
        }

        static bool IsValid(string s)
        {

            Stack<char> stack = new Stack<char>();

            foreach (var curr in s)
            {
                switch (curr)
                {
                    case '(':
                        stack.Push(')');
                        break;
                    case '[':
                        stack.Push(']');
                        break;
                    case '{':
                        stack.Push('}');
                        break;
                    case '}':
                    case ']':
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != curr)
                            return false;
                        break;

                }
            }

            return stack.Count == 0;
        }
    }
}
