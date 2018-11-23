using IterationTester.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace IterationTester.Tests
{
    public class ArrayTests
    {
        public static void ArrayTestRunner(int iterationCount, DataClass[] item1, DataClass[] item2, DataClass[] item3, DataClass[] item4)
        {
            long forArray = ForArrayTest(item1, (item1.Length / 2));
            long forEachArray = ForEachArrayTest(item2, (item3.Length / 2));
            long LinqArray = LinqArrayTest(item3, (item3.Length / 2));
            long PLinqArray = PLinqArrayTest(item4, (item4.Length / 2));
            using (var db = new iterationDbContext())
            {
                db.Results.Add(new IterationResult
                {
                    IterationCount = iterationCount,
                    DataType = "array",
                    IterationType = "for",
                    Ticks = forArray
                });
                db.Results.Add(new IterationResult
                {
                    IterationCount = iterationCount,
                    DataType = "array",
                    IterationType = "forEach",
                    Ticks = forEachArray
                });
                db.Results.Add(new IterationResult
                {
                    IterationCount = iterationCount,
                    DataType = "array",
                    IterationType = "linq",
                    Ticks = LinqArray
                });
                db.Results.Add(new IterationResult
                {
                    IterationCount = iterationCount,
                    DataType = "array",
                    IterationType = "plinq",
                    Ticks = PLinqArray
                });
                db.SaveChanges();
            }
        }

        public static long ForArrayTest(DataClass[] items, int idToCheck)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].id == idToCheck)
                    break;
            }
            s.Stop();
            return s.ElapsedTicks;
        }

        public static long LinqArrayTest(DataClass[] items, int idToCheck)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            var i = items.Select(e => e.id == idToCheck).FirstOrDefault();
            s.Stop();
            return s.ElapsedTicks;
        }

        public static long PLinqArrayTest(DataClass[] items, int idToCheck)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            var i = items.AsParallel().Select(e => e.id == idToCheck);
            s.Stop();
            return s.ElapsedTicks;
        }

        public static long ForEachArrayTest(DataClass[] items, int idToCheck)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            foreach (var item in items)
            {
                if (item.id == idToCheck)
                    break;
            }
            s.Stop();
            return s.ElapsedTicks;
        }
    }
}
