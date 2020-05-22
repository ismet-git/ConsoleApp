using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp
{
    class AA_Program
    {
        delegate int dlgt(int a, int b);
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello world ! \n\r");

        //    //ArrayRotation ar = new ArrayRotation();
        //    //ar.test_ArrayLeftRotation();

        //    //LinkedLists l = new LinkedLists();
        //    //    l.test_LinkedLists();

        //    //QueueDS myQ = new QueueDS();
        //    //myQ.testQueue();

        //    //StackDS s = new StackDS();
        //    //s.test_Stack();

        //    string s1 = "abc";
        //    string s2 = "cba";
        //    string s3 = string.Concat(s1.OrderBy(c => c));
        //    string s4 = string.Concat(s2.OrderBy(c => c));
        //    if(s3 == s4)
        //    {
        //        Console.WriteLine("match");
        //    }



        //    Console.ReadKey();

        //} // main

        private static void Operators()
        {
            Console.WriteLine(1);
            Console.WriteLine(1 << 1);
            Console.WriteLine(1 >> 1);
            Console.WriteLine(~1);
            Console.WriteLine(1 ^ 1);
            Console.WriteLine(0 ^ 0);
            Console.WriteLine(1 ^ 0);
            Console.WriteLine(0 ^ 1);
        }

        private static void MaxLetterHeight()
        {
            int[] h = { 1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            string word = "abc";
            int maxLetterHeight = word.Max(c => h[(int)c - (int)'a']);
            int wordSize = word.Length;
            int area = maxLetterHeight * wordSize;
            //int area =  word.Max(c => h[(int)c - 97]) * word.Length;

            Console.WriteLine("a ascii = " + (int)'a');
            Console.WriteLine("z ascii = " + (int)'z');

            Console.WriteLine("A ascii = " + (int)'A');
            Console.WriteLine("Z ascii = " + (int)'Z');
        }

        private static void SumOfLongNumbers()
        {
            long[] ar = { 1000000001, 1000000002, 1000000003, 1000000004, 1000000005 };
            //long sum = ar.Aggregate<long>((hd, tl) => hd + tl); ;

            long sumOfNumbers = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                sumOfNumbers += ar[i];
            }

            Console.WriteLine("\nSum: " + sumOfNumbers);
        }

        private static void TestFibonacci()
        {
            Fibonacci fib = new Fibonacci();
            //fib.getFibNValue(4);
            //fib.printFibSequence(10);

            DateTime t = DateTime.Now;
            Console.WriteLine(t);

            //Int64 r = fib.getFibValueRecursively(40);
            int n = 5000;
            Int64 r = fib.getFibValueRecursivelyWithMemo(n, new long[n + 1]);

            Console.WriteLine(r);

            TimeSpan t2 = DateTime.Now.Subtract(t);
            Console.WriteLine("\n" + DateTime.Now);
            Console.WriteLine("\nTime span: " + t2.TotalSeconds);
        }

        private static void RefDemo()
        {
            Compound x = new Compound();
            int i = x.NumberOfTimesMixed;
            x.Mix(ref i);
            x.NumberOfTimesMixed = i;
            //x.Mix(ref x.NumberOfTimesMixed);
            Console.WriteLine(x.NumberOfTimesMixed);
        }

        public class Compound
        {
            public int NumberOfTimesMixed { get; set; }

            public void Mix(ref int counter, params Compound[] components)
            {
                counter = counter + 6;
            }
        }

        private static void MyDelegetAndEvent()
        {
            // -https://www.intertech.com/Blog/c-sharp-tutorial-understanding-c-events/
            Adder a = new Adder();
            dlgt d = new dlgt(a.Add);
            //a.OnMyEvent += new Adder.dgEventRaiser(myEevntHandler);
            a.OnMyEvent += myEevntHandler;

            Console.WriteLine("x: " + d(5, 5));
        }

        private static void myEevntHandler() // (object o, MyTEventArgs e)
        {
            Console.WriteLine("method myEevntHandler()");
            //Console.WriteLine("MyTEventArgs Total: " + e.Total);
        }

        public class Adder
        {
            //public delegate void dgEventRaiser();
            //public event dgEventRaiser OnMyEvent;
            //public event EventHandler<MyTEventArgs> OnMyEvent;

            public event Action OnMyEvent;

            delegate int dg(int x, int y);

            public int Add(int a, int b)
            {
                int sum = a + b;
                int r = sum % 5;
                if ( (r == 0) && OnMyEvent != null)
                {
                    OnMyEvent();
                    //OnMyEvent(this, new MyTEventArgs(sum));
                    Console.WriteLine("Raised OnMyEvent()");
                }
                return sum;
            }
        }

        public class MyTEventArgs : EventArgs
        {
            public MyTEventArgs(int i)
            {
                Total = i;
            }

            public int Total { get; set; }
        }

        public static string multiplyStrings(string num1, string num2)
        {
            // was in Main function
            //string n1 = "123456789";
            //string n2 = "987654321";

            //string result = multiplyStrings(n1, n2);
            //Console.WriteLine("result: " + result);

            double n1 = 0;
            double n2 = 0;
          
            int p1 = num1.Length - 1;
            int p2 = num2.Length - 1;

            foreach (char d in num1)
            {                
                n1 = n1 + (d -'0') * (int)Math.Pow(10, p1);
                p1--;
            }
            
            foreach (char d in num2)
            {
                n2 = n2 + (d - '0') * (int)Math.Pow(10, p2);
                p2--;
            }

            double r = n1 * n2;

            return r.ToString();

        }

        private static void Anagrams()
        {
            var input = new List<string> { "cat", "act", "dog", "door", "odor" };

            var anagramsGroups = GroupAnagrams(input);

            foreach (var ag in anagramsGroups)
            {
                Console.WriteLine(string.Join(" ", ag.Value));
            }
        }

        public static Dictionary<string, List<string>> GroupAnagrams(List<string> words) 
        {
            Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();

            foreach(string w in words)
            {
                string sw = SortWord(w);
                if(groups.ContainsKey(sw))
                {
                    groups[sw].Add(w); // add the word (value) in the sorted group (key)
                }
                else
                {
                    groups.Add(sw, new List<string> { w });
                }
            }

            return groups;

        }

        private static string SortWord(string w)
        {
            char[] c = w.ToCharArray();
            Array.Sort(c);
            return new string(c);
        }

        private static void MaxSumOfHourglass()
        {
            int[][] arr = new int[6][];

            //arr[0] = new int[] { 1, 1, 1, 0, 0, 0 };
            //arr[1] = new int[] { 0, 1, 0, 0, 0, 0 };
            //arr[2] = new int[] { 1, 1, 1, 0, 0, 0 };
            //arr[3] = new int[] { 0, 0, 2, 4, 4, 0 };
            //arr[4] = new int[] { 0, 0, 0, 2, 0, 0 };
            //arr[5] = new int[] { 0, 0, 1, 2, 4, 0 };

            arr[0] = new int[] { 0, -4, -6, 0, -7, -6 };
            arr[1] = new int[] { -1, -2, -6, -8, -3, -1 };
            arr[2] = new int[] { -8, -4, -2, -8, -8, -6 };
            arr[3] = new int[] { -3, -1, -2, -5, -7, -4 };
            arr[4] = new int[] { -3, -5, -3, -6, -6, -6 };
            arr[5] = new int[] { -3, -6, 0, -8, -6, -7 };

            int sum = 0;
            int maxSum = -999999;

            for (int r = 0; r < arr.Length - 2; r++)
            {
                Console.WriteLine("row: " + r);
                for (int c = 0; c < arr[0].Length - 2; c++)
                {
                    Console.Write(arr[r][c] + " ");
                    sum = sum
                        + arr[r][c] + arr[r][c + 1] + arr[r][c + 2]
                        + arr[r + 1][c + 1]
                        + arr[r + 2][c] + arr[r + 2][c + 1] + arr[r + 2][c + 2];

                    Console.WriteLine("sum: " + sum);

                    if (sum >= maxSum)
                    {
                        maxSum = sum;
                    }
                    sum = 0;
                }
                Console.WriteLine("Hour glass maxSum: " + maxSum);
            }

            Console.WriteLine("maxSum: " + maxSum);
        }

        public static int minDiff(List<int> arr)
        {
            // the absolute difference is minimum if numbers are sorted 
            arr.Sort();
            int sum = 0;

            for (int i=0; i < arr.Count()-1; i++)
            {
                sum = sum + Math.Abs(arr[i] - arr[i + 1]);
            }

            return sum;

        }

        private static void HashSetMethod()
        {
            HashSet<int> odd = new HashSet<int>();

            // Inserting elements in HashSet 
            for (int i = 0; i < 5; i++)
            {
                odd.Add(2 * i + 1);
                //odd.Add(1);
            }

            // Displaying the elements in the HashSet 
            foreach (int i in odd)
            {
                Console.WriteLine(i);
            }
        }
    }
}
