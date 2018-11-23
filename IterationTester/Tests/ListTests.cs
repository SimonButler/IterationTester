using IterationTester.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace IterationTester.Tests
{
    class ListTests
    {
        public static void ListTestRunner(int iterationCount, List<DataClass> list1, List<DataClass> list2, List<DataClass> list3, List<DataClass> list4)
        {
            long forList = ForListTest(list1, (list1.Count / 2));
            long forEachList = ForEachListTest(list2, (list2.Count/ 2));
            long LinqList = LinqListTest(list3, (list3.Count / 2));
            long PLinqList = PLinqListTest(list4, (list4.Count / 2));
            using (var db = new iterationDbContext())
            {
                db.Results.Add(new IterationResult
                {
                    IterationCount = iterationCount,
                    DataType = "List",
                    IterationType = "for",
                    Ticks = forList
                });
                db.Results.Add(new IterationResult
                {
                    IterationCount = iterationCount,
                    DataType = "List",
                    IterationType = "forEach",
                    Ticks = forEachList
                });
                db.Results.Add(new IterationResult
                {
                    IterationCount = iterationCount,
                    DataType = "List",
                    IterationType = "linq",
                    Ticks = LinqList
                });
                db.Results.Add(new IterationResult
                {
                    IterationCount = iterationCount,
                    DataType = "List",
                    IterationType = "plinq",
                    Ticks = PLinqList
                });
                db.SaveChanges();
            }
        }

        public static long PLinqListTest(List<DataClass> items, int idToCheck)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            bool exists = items.AsParallel().Select(e => e.id == idToCheck).FirstOrDefault();
            s.Stop();
            return s.ElapsedTicks;

        }
        public static long LinqListTest(List<DataClass> items, int idToCheck)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            bool exists = items.Exists(e => e.id == idToCheck);
            s.Stop();
            return s.ElapsedTicks;

        }
        public static long ForEachListTest(List<DataClass> items, int idToCheck)
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
        public static long ForListTest(List<DataClass> items, int idToCheck)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == idToCheck)
                    break;
            }
            s.Stop();
            return s.ElapsedTicks;
        }

    }
}
