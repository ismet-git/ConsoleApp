using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{

    class Solution
    {
        // created this ti work in HackrRank
        static int capacity = 10;
        static int size = 0;
        static int[] items = new int[capacity];


        //static void Main(String[] args)
        //{
        //    /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */

        //    add(4);
        //    add(9);
        //    printHeap();
        //}


        static void printHeap()
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(items[i] + " ");
            }
        }
        static int getLeftChildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        static int getRightChildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        static int getParentIndex(int childIndex) { return (childIndex - 1) / 2; }

        static bool hasLeftChild(int index) { return getLeftChildIndex(index) < size; }
        static bool hasRightChild(int index) { return getRightChildIndex(index) < size; }
        static bool hasParent(int index) { return getParentIndex(index) >= 0; }

        static int leftChild(int index) { return items[getLeftChildIndex(index)]; }
        static int rightChild(int index) { return items[getRightChildIndex(index)]; }
        static int parent(int index) { return items[getParentIndex(index)]; }

        static void swap(int indexOne, int indexTwo)
        {
            int tmp = items[indexOne];
            items[indexOne] = items[indexTwo];
            items[indexTwo] = tmp;
        }

        static void ensureExtraCapacity()
        {
            if (size == capacity)
            {
                Array.Copy(items, items, capacity * 2);
                capacity = capacity * 2;
            }
        }

        static int peek()
        {
            if (size == 0) throw new Exception("Empty array");
            return items[0];
        }

        static int poll()
        {
            if (size == 0) throw new Exception("Empty array");
            int item = items[0];
            items[0] = items[size - 1];
            size--;
            heapifyDown();
            return item;
        }

        static void add(int item)
        {
            ensureExtraCapacity();
            items[size] = item;
            size++;
            heapifyUp();
        }

        static void heapifyUp()
        {
            int index = size - 1;

            while (hasParent(index) && parent(index) > items[index])
            {
                swap(getParentIndex(index), index);
                index = getParentIndex(index);
            }
        }

        static void heapifyDown()
        {
            int index = 0;

            while (hasLeftChild(index))
            {
                int smallerChildIndex = getLeftChildIndex(index);

                if (hasRightChild(index) && rightChild(index) < leftChild(index))
                {
                    smallerChildIndex = getRightChildIndex(index);
                }

                if (items[index] < items[smallerChildIndex])
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
