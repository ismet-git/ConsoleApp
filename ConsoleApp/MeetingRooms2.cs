using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class MeetingRooms2
    {
        //static void Main(string[] args)
        //{
        //    // Given [[0, 30],[5, 10],[15, 20]],
        //    // return 2.

        //    MeetingRooms2 r = new MeetingRooms2();

        //    Interval[] time = new Interval[]
        //    {
        //        new Interval(0, 30),
        //        new Interval(5, 10),
        //        new Interval(15, 20)
        //    };

        //    int mmr = r.MinMeetingRooms2(time);

        //    Console.Write("Time intervals: ");
        //    time.ToList().ForEach(m => Console.Write(m.start + "-" + m.end + ", "));
        //    Console.WriteLine("\nMinMeetingRooms: " + mmr);
        //    Console.ReadKey();
        //}


        /** Definition for an interval. */
        public class Interval
        {
            public int start;
            public int end;
            public Interval() { start = 0; end = 0; }
            public Interval(int s, int e) { start = s; end = e; }
        }


        public class IntervalComparer : IComparer<Interval>
        {
            public int Compare(Interval a, Interval b)
            {
                return a.start == b.start ? a.end - b.end : a.start - b.start;
            }
        }

        public int MinMeetingRooms2(Interval[] intervals)
        {
            if (intervals == null || intervals.Length == 0) return 0;
            if (intervals.Length < 2) return intervals.Length;

            var starts = new int[intervals.Length];
            var ends = new int[intervals.Length];

            for (int i = 0; i < intervals.Length; i++)
            {
                starts[i] = intervals[i].start;
                ends[i] = intervals[i].end;
            }

            Array.Sort(starts);
            Array.Sort(ends);

            int rooms = 0, j = 0;

            for (int i = 0; i < intervals.Length; i++)
            {
                if (starts[i] < ends[j])
                {
                    rooms++;
                }
                else
                {
                    j++;
                }
            }

            return rooms;
        }

        public int MinMeetingRooms(Interval[] intervals)
        {
            if (intervals == null || intervals.Length == 0) return 0;
            if (intervals.Length == 1) return 1;

            Array.Sort(intervals, new IntervalComparer());

            // the ideal datastructure to solve this a priority queue, however C# doesn't have impletemented it yet
            // so I'll use a sorted list here
            var rooms = new List<int>(intervals.Length);
            var max = 1;

            for (int i = 0; i < intervals.Length; i++)
            {
                if (i == 0)
                {
                    rooms.Add(intervals[0].end);
                }
                else
                {
                    if (intervals[i].start >= rooms[0])
                    {
                        rooms.RemoveAt(0);
                    }

                    int index = rooms.BinarySearch(intervals[i].end);
                    rooms.Insert(index < 0 ? ~index : index, intervals[i].end);
                }

                max = Math.Max(max, rooms.Count);
            }

            return max;
        }
    }
    //public int minMeetingRooms(Interval[] intervals)
    //{
    //    int n = intervals.length;
    //    int[] start = new int[n];
    //    int[] end = new int[n];
    //    for (int i = 0; i < n; i++)
    //    {
    //        start[i] = intervals[i].start;
    //        end[i] = intervals[i].end;
    //    }
    //    Arrays.sort(start);
    //    Arrays.sort(end);
    //    int i = 0, j = 0, res = 0;
    //    while (i < n)
    //    {
    //        if (start[i] < end[j]) i++;
    //        else if (start[i] > end[j]) j++;
    //        else
    //        {
    //            i++;
    //            j++;
    //        }
    //        res = Math.max(res, i - j);
    //    }
    //    return res;
    //}

}

