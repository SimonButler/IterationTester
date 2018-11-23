using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using IterationTester.Models;

namespace IterationTester.Tests
{
    class ArrayListTests
    {
        public static void ArrayListTestRunner(int iterationCount)
        {
            Console.Out.WriteLine("Running ArrayList Test for Iteration");

            ArrayList alist1 = new ArrayList();
            ArrayList alist2 = new ArrayList();
            ArrayList alist3 = new ArrayList();
            ArrayList alist4 = new ArrayList();
            GenArrayListData(iterationCount, alist1, alist2, alist3, alist4);



            long forArrayList = ForArrayListTest(alist1, (alist1.Count / 2));
            long forEachArrayList = ForEachArrayListTest(alist2, (alist2.Count / 2));
            long LinqArrayList = LinqArrayListTest(alist3, (alist3.Count / 2));
            long PLinqArrayList = PLinqArrayListTest(alist4, (alist4.Count / 2));
            using (var db = new iterationDbContext())
            {
                db.Results.Add(new IterationResult
                {
                    IterationCount = iterationCount,
                    DataType = "ArrayList",
                    IterationType = "for",
                    Ticks = forArrayList
                });
                db.Results.Add(new IterationResult
                {
                    IterationCount = iterationCount,
                    DataType = "ArrayList",
                    IterationType = "forEach",
                    Ticks = forEachArrayList
                });
                db.Results.Add(new IterationResult
                {
                    IterationCount = iterationCount,
                    DataType = "ArrayList",
                    IterationType = "linq",
                    Ticks = LinqArrayList
                });
                db.Results.Add(new IterationResult
                {
                    IterationCount = iterationCount,
                    DataType = "ArrayList",
                    IterationType = "plinq",
                    Ticks = PLinqArrayList
                });
                db.SaveChanges();
            }
        }

        public static void GenArrayListData(
          int iterationsCount,
          ArrayList alist1, ArrayList alist2, ArrayList alist3, ArrayList alist4
          )
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                alist1.Add(new DataClass(i, "alist1" + i, "alist1" + i, DateTime.Today.Ticks, Guid.NewGuid()));
            }
            for (int i = 0; i < iterationsCount; i++)
            {
                alist2.Add(new DataClass(i, "alist2" + i, "alist2" + i, DateTime.Today.Ticks, Guid.NewGuid()));
            }
            for (int i = 0; i < iterationsCount; i++)
            {
                alist3.Add(new DataClass(i, "alist3" + i, "alist3" + i, DateTime.Today.Ticks, Guid.NewGuid()));
            }
            for (int i = 0; i < iterationsCount; i++)
            {
                alist4.Add(new DataClass(i, "alist4" + i, "alist4" + i, DateTime.Today.Ticks, Guid.NewGuid()));
            }

        }

        public static long ForEachArrayListTest(ArrayList items, int idToCheck)
        {
            Stopwatch s = new Stopwatch();
            s.Start();

            foreach (DataClass item in items)
            {
                if (item.id == idToCheck)
                    break;
            }
            s.Stop();
            return s.ElapsedTicks;
        }
        public static long LinqArrayListTest(ArrayList items, int idToCheck)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            var i = from DataClass a in items where a.id == idToCheck select a.id;
            s.Stop();
            return s.ElapsedTicks;
        }
        public static long PLinqArrayListTest(ArrayList items, int idToCheck)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            var i = items.AsParallel().Cast<DataClass>().Select(e => e.id == idToCheck).FirstOrDefault();
            s.Stop();
            return s.ElapsedTicks;

        }
        public static long ForArrayListTest(ArrayList items, int idToCheck)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            DataClass temp;
            for (int i = 0; i < items.Count; i++)
            {
                temp = (DataClass)items[i];
                if (temp.id == idToCheck)
                    break;
            }
            s.Stop();
            return s.ElapsedTicks;
        }


    }
}
