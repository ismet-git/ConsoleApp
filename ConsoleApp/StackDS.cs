using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class StackDS
    {
        public void test_Stack()
        {
            Stack s = new Stack();
            s.push(99);
            s.push(45);
            s.push(7);
            s.displayStack();

            Console.WriteLine("peek: " + s.peek());

            Console.WriteLine("pop: ");
            s.pop();

            Console.WriteLine("peek: " + s.peek());


        }

        public class Stack
        {
            public Node top;

            public void displayStack()
            {
                Node current = top;

                while (current != null)
                {
                    Console.WriteLine(current.data + " ");
                    current = current.next;
                }

            }

            public class Node
            {
                public int data;
                public Node next;
                
                public Node(int data) { this.data = data; }
            } // Node

            public bool isEmpty() {
                return top == null;
            }

            public int peek() {
                return top.data;
            }

            public void push(int data) {
                Node newTop = new Node(data);
                newTop.next = top;
                top = newTop;
            }

            public int pop() {
                int popValue = top.data;
                top = top.next;
                return popValue;
            }
            
        } // Stack


    } // StackDS
}
