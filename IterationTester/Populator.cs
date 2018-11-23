using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace IterationTester
{
    public class Populator
    {
        public static void GenData(
            int iterationsCount,
            DataClass[] array1, DataClass[] array2, DataClass[] array3, DataClass[] array4,
            ArrayList alist1, ArrayList alist2, ArrayList alist3, ArrayList alist4,
            List<DataClass> list1, List<DataClass> list2, List<DataClass> list3, List<DataClass> list4
            )
        {
            Console.WriteLine("Generating Data");
            Stopwatch dataGenTimer = new Stopwatch();
            dataGenTimer.Start();
            GenArrayData(iterationsCount, array1, array2, array3, array4);
            GenArrayListData(iterationsCount, alist1, alist2, alist3, alist4);
            GenListData(iterationsCount, list1, list2, list3, list4);
            dataGenTimer.Stop();
            Console.Out.WriteLine("Data Generation completed in: "+dataGenTimer.Elapsed);
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

    }
}
