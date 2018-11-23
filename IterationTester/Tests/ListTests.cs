using IterationTester.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace IterationTester.Tests
{
    class ListTests
    {
        public static void ListTestRunner(int iterationCount)
        {
            Console.Out.WriteLine("Running List Test for Iteration");
            List<DataClass> list1 = new List<DataClass>();
            List<DataClass> list2 = new List<DataClass>();
            List<DataClass> list3 = new List<DataClass>();
            List<DataClass> list4 = new List<DataClass>();
            GenListData(iterationCount, list1, list2, list3, list4);

            long forList = ForListTest(list1, (list1.Count / 2));
            long forEachList = ForEachListTest(list2, (list2.Count / 2));
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

        public static void GenListData(
    int iterationsCount,
    List<DataClass> list1, List<DataClass> list2, List<DataClass> list3, List<DataClass> list4
    )
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                list1.Add(new DataClass(i, "list1" + i, "list1" + i, DateTime.Today.Ticks, Guid.NewGuid()));
            }
            for (int i = 0; i < iterationsCount; i++)
            {
                list2.Add(new DataClass(i, "list2" + i, "list2" + i, DateTime.Today.Ticks, Guid.NewGuid()));
            }
            for (int i = 0; i < iterationsCount; i++)
            {
                list3.Add(new DataClass(i, "list3" + i, "list3" + i, DateTime.Today.Ticks, Guid.NewGuid()));
            }
            for (int i = 0; i < iterationsCount; i++)
            {
                list4.Add(new DataClass(i, "list4" + i, "list4" + i, DateTime.Today.Ticks, Guid.NewGuid()));
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
