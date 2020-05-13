using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class HeapHackerRankEditorial
    {
        // Map to maintain the index of values in the heap.
        Dictionary<int, int> value_index = new Dictionary<int, int>();
        int[] heap = new int[500002];
        int heap_size = 0;

        void insert_val(int val)
        {
            if (heap_size == 0)
            {
                heap[++heap_size] = val;
                value_index[val] = heap_size;
                return;
            }
            heap[++heap_size] = val;
            value_index[val] = heap_size;
            int iter = heap_size;
            while (iter > 1)
            {
                if (heap[iter] < heap[iter / 2])
                {
                    value_index[heap[iter]] = iter / 2;
                    value_index[heap[iter / 2]] = iter;
                    int temp = heap[iter];
                    heap[iter] = heap[iter / 2];
                    heap[iter / 2] = temp;
                    iter /= 2;
                }
                else
                    break;
            }
        }

        void delete_val(int val)
        {
            int index = value_index[val];
            value_index[val] = 0;
            value_index[heap[heap_size]] = index;
            heap[index] = heap[heap_size--];
            while (true)
            {
                int left_child = 2 * index, right_child = 2 * index + 1; ;
                if (left_child <= heap_size)
                {
                    if (right_child <= heap_size)
                    {
                        if (heap[index] > heap[left_child] || heap[index] > heap[right_child])
                        {
                            int swap_index = (heap[left_child] < heap[right_child]) ? left_child : right_child;
                            value_index[heap[swap_index]] = index; ;
                            value_index[heap[index]] = swap_index; ;
                            int temp = heap[index];
                            heap[index] = heap[swap_index];
                            heap[swap_index] = temp;
                            index = swap_index;
                        }
                        else
                            break;
                    }
                    else
                    {
                        if (heap[index] > heap[left_child])
                        {
                            value_index[heap[left_child]] = index;
                            value_index[heap[index]] = left_child;
                            int temp = heap[index];
                            heap[index] = heap[left_child];
                            heap[left_child] = temp;
                            index = left_child;
                        }
                        else
                            break;
                    }
                }
                else
                    break;
            }
        }

        public void test_HeapHackerRankEditorial()
        {
            int queries = Convert.ToInt32(Console.ReadLine());
            
            while (queries-- > 0)
            {
                int type, val;
                type = Convert.ToInt32(Console.ReadLine());

                if (type == 1) // insert
                {
                    val = Convert.ToInt32(Console.ReadLine()); 
                    insert_val(val);
                }
                else if (type == 2) // delete
                {
                    val = Convert.ToInt32(Console.ReadLine()); 
                    delete_val(val);
                }
                else
                {
                    //cout << heap[1] << endl;
                    Console.WriteLine(heap[1]);
                }
            }
            
        }
    }
}
