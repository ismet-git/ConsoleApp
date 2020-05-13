using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class QueueDS
    {
        public void testQueue()
        {
            Queue myq = new Queue();
            myq.add(5);
            myq.add(42);
            myq.add(99);
            myq.displayQueue();

            Console.WriteLine("\nmyq.peek() " + myq.peek());

            myq.remove();
            Console.WriteLine("\nremoved fifo ");
            Console.WriteLine("\n");
            myq.displayQueue();


        }

        

        public class Queue
        {
            public void displayQueue()
            {
                if (head != null)
                {
                    Node current = head;

                    while(current !=null)
                    {
                        Console.Write(current.data + " ");
                        current = current.next;
                    }

                }
            }

            private class Node
            {
                public int data;
                public Node next;                

                public Node (int data)
                {
                    this.data = data;
                }
            }

            // class Queue properties 
            private Node head;
            private Node tail;

             public bool isEmpty()
            {
                return head == null; 
            }

            public int peek() {
                return head.data;
            }

            public void add(int data) {
                Node node = new Node(data);    
                if (tail != null)
                {
                    tail.next = node;
                }

                tail = node;

                if (head == null)
                {
                    head = node;
                }
            }

            public int remove() {
                int data = head.data;
                head = head.next;

                if (head == null)
                {
                    tail = null;
                }
                return data;
            }

        } // Queue


        
        
    }
}
