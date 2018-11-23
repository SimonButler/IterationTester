using IterationTester.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace IterationTester.Tests
{
    public class ArrayTests
    {
        public static void ArrayTestRunner(int iterationCount)
        {
            Console.Out.WriteLine("Running Array Test for Iteration");

            DataClass[] array1 = new DataClass[iterationCount];
            DataClass[] array2 = new DataClass[iterationCount];
            DataClass[] array3 = new DataClass[iterationCount];
            DataClass[] array4 = new DataClass[iterationCount];
            GenArrayData(iterationCount, array1, array2, array3, array4);

            long forArray = ForArrayTest(array1, (array1.Length / 2));
            long forEachArray = ForEachArrayTest(array2, (array2.Length / 2));
            long LinqArray = LinqArrayTest(array3, (array3.Length / 2));
            long PLinqArray = PLinqArrayTest(array4, (array4.Length / 2));
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

        public static void GenArrayData(
          int iterationsCount,
          DataClass[] array1, DataClass[] array2, DataClass[] array3, DataClass[] array4
          )
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                array1[i] = new DataClass(i, "Array1" + i, "Array1" + i, DateTime.Today.Ticks, Guid.NewGuid());
            }
            for (int i = 0; i < iterationsCount; i++)
            {
                array2[i] = new DataClass(i, "Array2" + i, "Array2" + i, DateTime.Today.Ticks, Guid.NewGuid());
            }
            for (int i = 0; i < iterationsCount; i++)
            {
                array3[i] = new DataClass(i, "Array3" + i, "Array3" + i, DateTime.Today.Ticks, Guid.NewGuid());
            }
            for (int i = 0; i < iterationsCount; i++)
            {
                array4[i] = new DataClass(i, "Array4" + i, "Array4" + i, DateTime.Today.Ticks, Guid.NewGuid());
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
