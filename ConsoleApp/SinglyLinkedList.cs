using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class SinglyLinkedList
    {

        public class LinkedListNode<T>
        {
            public T Value { get; set; }

            public LinkedListNode(T value)
            {
                Value = value;
            }

            public LinkedListNode<T> Next { get; set; }
        }

        public class LinkedList<T> : ICollection<T>
        {
            public LinkedListNode<T> Head { get; private set; }
            public LinkedListNode<T> Tail { get; private set; }

            public void AddFirst(T value)
            {
                AddFirst(new LinkedListNode<T>(value));
            }

            public void AddFirst(LinkedListNode<T> node)
            {
                LinkedListNode<T> temp = Head;
                Head = node; // head always points to new added node
                Head.Next = temp;

                Count++;
                if(Count == 1)
                {
                    Head = Tail;
                }
            }

            public void AddLast(T value)
            {
                AddLast(new LinkedListNode<T>(value));
            }

            public void AddLast(LinkedListNode<T> node)
            {
                if(Count == 0)
                {
                    Head = node;
                }
                else
                {
                    Tail.Next = node;
                }

                Tail = node;
                Count++;

            }

            public int Count
            {
                get;
                private set;
            }

            public void RemoveFirst()
            {
                if(Count != 0)
                {
                    Head = Head.Next;
                    Count--;

                    if(Count == 0)
                    {
                        Tail = null;
                    }
                }
                
            }

            public void RemoveLast()
            {
                if(Count != 0)
                {
                    if(Count ==1)
                    {
                        Head = null;
                        Tail = null;
                    }
                    else
                    {
                        LinkedListNode<T> current = Head;
                        while(current.Next != Tail)
                        {
                            current = current.Next;
                        }
                        current.Next = null;
                        Tail = current;
                    }
                    Count--;
                }
            }

            public bool IsReadOnly {
                get { return false; }
            }

            public void Add(T item)
            {
                AddFirst(item);
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(T item)
            {
                LinkedListNode<T> current = Head;
                while(current != null)
                {
                    if(current.Value.Equals(item))
                    {
                        return true;
                    }
                    current = current.Next;
                }
                return false;
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                LinkedListNode<T> current = Head;

                while(current != null)
                {
                    array[arrayIndex++] = current.Value;
                    current = current.Next;
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public bool Remove(T item)
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}
