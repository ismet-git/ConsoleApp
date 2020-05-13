using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class BirthDeath
    {

        public void test_getPopulationPeakYear()
        {
            Person[] people = new Person[]
            {
                new Person() { BirthYear = 2000, DeathYear = 2001 },
                new Person() { BirthYear = 2001, DeathYear = 2002 }
            };

            int x = getPopulationPeakYear(people);
            
        }

        public int getPopulationPeakYear(Person[] people)
        {
            int firstBirth = getMinBirth(people);
            int lastBirth = getMaxBirth(people);

            int[] deltas = getDeltas(people, firstBirth, lastBirth);
            int peakYearOffset = getMaxRunningSumIndex(deltas);

            return peakYearOffset + firstBirth;
            //return 0;
        }

        private int[] getDeltas(Person[] people, int firstBirth, int lastBirth)
        {
            int[] deltas = new int[lastBirth - firstBirth + 1];

            foreach(Person p in people)
            {
                addDelta(deltas, p.BirthYear - firstBirth, 1);
                addDelta(deltas, p.DeathYear + 1 - firstBirth, -1);
            }

            return deltas;
        }

        private void addDelta(int[] deltas, int yearOffset, int value)
        {
            if (yearOffset < deltas.Length) {
                deltas[yearOffset] = deltas[yearOffset] + value;
            }
            
        }

        private int getMaxRunningSumIndex(int[] deltas)
        {
            //int maxSum = deltas.Max();
            //int maxSumIndex =  Array.IndexOf(deltas, maxSum);
            //return maxSumIndex;

            int runningSum = 0;
            int maxRunningSum = 0;
            int yearOfPeak = 0;

            for(int year = 0; year < deltas.Length; year++)
            {
                runningSum += deltas[year];
                if(runningSum > maxRunningSum)
                {
                    maxRunningSum = runningSum;
                    yearOfPeak = year;
                }                
            }
            return yearOfPeak;
        }

        private int getMaxBirth(Person[] people)
        {
            return people.Max(x => x.BirthYear);
        }

        private int getMinBirth(Person[] people)
        {
            return people.Min(x => x.BirthYear);
        }
    }

    public class Person
    {
        public int BirthYear { get; set; }
        public int DeathYear { get; set; }
    }
}
