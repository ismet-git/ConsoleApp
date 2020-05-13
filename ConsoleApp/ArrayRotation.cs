using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ArrayRotation
    {
        public void test_ArrayLeftRotation()
        {
            int[] a = { 1, 2, 3, 4, 5 };
            int numberOfRotations = 1;

            //int[] r = ArrayLeftRotation(a, numberOfRotations);
            int[] r = ArrayRightRotation(a, numberOfRotations);

            Array.ForEach(r, x => Console.Write(x + " "));
        }

        public int[] ArrayLeftRotation2(int[] a, int numOfRotations)
        {
            int d = numOfRotations;
            int n = a.Length;
            int[] temp = new int[n];
            int ti = 0;
            for (int i = d; i < (n + d); i++)
            {
                temp[ti++] = a[i % n];            
            }
            return temp;
        }

        public int[] ArrayLeftRotation(int[] a, int numOfRotations)
        {
            int d = numOfRotations;
            int n = a.Length;
            int[] r = new int[n];
            for (int i = 0; i < n; ++i)
            {
                int index = (i + d) % n;
                r[i] = a[index];
            }
            return r;
        }

        public int[] ArrayRightRotation(int[] a, int numOfRotations)
        {
            int d = numOfRotations;
            int n = a.Length;
            int[] temp = new int[n];
            int ti = 0;
            for (int i = n-d; i > -1; i--)
            {
                int index = i % n;
                temp[ti++] = a[index];
            }
            return temp;
        }

    }
}
