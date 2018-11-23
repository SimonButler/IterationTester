using IterationTester;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using IterationTester.Tests;

namespace TestApp
{
    public class Program
    {

        public static void Main()
        {
            Stopwatch overallTimer = new Stopwatch();
            overallTimer.Start();

            for (int i = 1; i < 10000000; i = i * 10)
                StartObjTest(i);

            Console.Out.WriteLine("");
            Console.Out.WriteLine("Total Time to run tests:" + overallTimer.Elapsed);
            Console.Out.WriteLine("Tests Complete");
            Console.Read();
        }

        public static void StartObjTest(int iterationsCount)
        {
            Console.Out.WriteLine("#######################################################");
            Console.WriteLine("Iterations Count: " + iterationsCount);
            Stopwatch iterationTimer = new Stopwatch();
            iterationTimer.Start();
          
            //Initialise the diffent lists/arrays

            List<DataClass> list1 = new List<DataClass>();
            List<DataClass> list2 = new List<DataClass>();
            List<DataClass> list3 = new List<DataClass>();
            List<DataClass> list4 = new List<DataClass>();
            DataClass[] array1 = new DataClass[iterationsCount];
            DataClass[] array2 = new DataClass[iterationsCount];
            DataClass[] array3 = new DataClass[iterationsCount];
            DataClass[] array4 = new DataClass[iterationsCount];
            ArrayList alist1 = new ArrayList();
            ArrayList alist2 = new ArrayList();
            ArrayList alist3 = new ArrayList();
            ArrayList alist4 = new ArrayList();
            //More Datatypes to possibly add
            LinkedList<DataClass> llist1 = new LinkedList<DataClass>();
            SortedList sl = new SortedList();
            IEnumerable<DataClass> ienumerable1;
            Dictionary<IDictionary, DataClass> dictionary1 = new Dictionary<IDictionary, DataClass>();


            Populator.GenData(iterationsCount,
                array1, array2, array3, array4,
                alist1, alist2, alist3, alist4,
                list1, list2, list3, list4
                );

 

            Console.Out.WriteLine("Starting Test");
            Console.Out.WriteLine("");
            Console.Out.WriteLine("List Tests");
            ArrayTests.ArrayTestRunner(iterationsCount, array1, array2, array3, array4);
            ListTests.ListTestRunner(iterationsCount, list1, list2, list3, list4);
            ArrayListTests.ArrayListTestRunner(iterationsCount, alist1, alist2, alist3, alist4);
            Console.Out.WriteLine("Finished Test for iteration count: " + iterationsCount);
            Console.Out.WriteLine("Duration: " + iterationTimer.ElapsedTicks + "(" + iterationTimer.ElapsedMilliseconds + "ms)");
            Console.Out.WriteLine("#######################################################");


        }

        public static void Disposer()
        {

        }


       

    }
}