using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class LinkedLists
    {
        public Node head;

        public void test_LinkedLists()
        {
            LinkedLists ll = new LinkedLists();
            //ll.prepend(122);
            ll.append(41);

            ll.displayLinkedList();

        }

        public void displayLinkedList()
        {            
            if (head == null) { 
                Console.WriteLine("Empty linked list");
                return;
            }

            Node current = head;

            while (current != null)
            {
                Console.Write(current.data + " ");
                current = current.next;
            }
        }
        public void deleteWithValue(int data)
        {
            if (head == null) return;

            if (head.data == data)
            {
                head = head.next;
                return;
            }

            Node current = head;

            while (current.next != null)
            {
                if (current.next.data == data)
                {
                    current.next = current.next.next;
                    return;
                }
                current = current.next;
            }
        }

        public void prepend(int data)
        {
            Node newHead = new Node(data);
            newHead.next = head;
            head = newHead;
        }

        public void append(int data)
        {
            Node current = head;

            if (head == null)
            {
                head = new Node(data);
                return;
            }

            while (current.next != null)
            {
                current = current.next;
            }

            current.next = new Node(data);

        }

        public class Node
        {
            public Node next;
            public int data;

            public Node(int data)
            {
                this.data = data;
            }
        }

    }
}
