using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class HeapMin
    {
        public int capacity { get; set; }
        public int size { get; set; }

        int[] items;

        public HeapMin()
        {
            capacity = 10;
            size = 0;
            items = new int[capacity];
            
        }


        public void testHeap()
        {
            HeapMin h = new HeapMin();
            h.add(25);
            h.add(20);
            h.add(10);
            h.add(17);
            h.add(15);
             

            Console.WriteLine("heap size: " + h.size);
            Console.WriteLine("heap peek: " + h.peek());

            Console.WriteLine("\npoll: " + h.poll());
          
            Console.WriteLine("\nheap size: " + h.size);
            Console.WriteLine("heap peek: " + h.peek());

            Console.WriteLine("\nheap items: ");
            h.printHeap();




        }

        public void printHeap()
        {
            for(int i = 0; i < size; i++)
            {
                Console.WriteLine(items[i]+ " ");
            }
        }

        public int getLeftChildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        public int getRightChildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        public int getParentIndex(int childIndex) { return (childIndex - 1) / 2; }

        public bool hasLeftChild(int index) { return getLeftChildIndex(index) < size; }
        public bool hasRightChild(int index) { return getRightChildIndex(index) < size; }
        public bool hasParent(int index) { return getParentIndex(index) >= 0; }

        public int leftChild(int index) { return items[getLeftChildIndex(index)]; }
        public int rightChild(int index) { return items[getRightChildIndex(index)]; }
        public int parent(int index) { return items[getParentIndex(index)]; }

        public void swap(int indexOne, int indexTwo)
        {
            int tmp = items[indexOne];
            items[indexOne] = items[indexTwo];
            items[indexTwo] = tmp;
        }

        public void ensureExtraCapacity()
        {
            if (size == capacity)
            {
                Array.Copy(items, items, capacity * 2);
                capacity = capacity * 2;
            }
        }

        public int peek()
        {
            if (size == 0) throw new Exception("Empty array");
            return items[0];
        }

        public int poll()
        {
            if (size == 0) throw new Exception("Empty array");
            int item = items[0];
            items[0] = items[size - 1];
            size--;
            heapifyDown();
            return item;
        }

        public void add(int item)
        {
            ensureExtraCapacity();
            items[size] = item;
            size++;
            heapifyUp();
        }

        public void heapifyUp()
        {
            int index = size - 1;

            while (hasParent(index) && parent(index) > items[index])
            {
                swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }

        public void heapifyDown()
        {
            int index = 0;

            while (hasLeftChild(index))
            {
                int smallerChildIndex = getLeftChildIndex(index);

                if(hasRightChild(index) && rightChild(index) < leftChild(index))
                {
                    smallerChildIndex = getRightChildIndex(index);
                }

                if(items[index] < items[smallerChildIndex])
                {
                    break;
                }
                else
                {
                    swap(index, smallerChildIndex);
                }

                index = smallerChildIndex;
            }
        }
    }
}
