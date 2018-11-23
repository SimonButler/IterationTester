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

            for (int i = 1; i < 100000000; i = i * 10)
                StartObjTest(i);

            Console.Out.WriteLine("");
            Console.Out.WriteLine("Total Time to run tests:" + overallTimer.Elapsed);
            Console.Out.WriteLine("Tests Complete");
            Console.Read();
        }

        public static void StartObjTest(int iterationsCount)
        {
            Console.Out.WriteLine("#######################################################");
            Console.WriteLine("Tests for Iteration Count: " + iterationsCount);
            Stopwatch iterationTimer = new Stopwatch();
            iterationTimer.Start();
   
            ////More Datatypes to possibly add
            //LinkedList<DataClass> llist1 = new LinkedList<DataClass>();
            //SortedList sl = new SortedList();
            //IEnumerable<DataClass> ienumerable1;
            //Dictionary<IDictionary, DataClass> dictionary1 = new Dictionary<IDictionary, DataClass>();

            ArrayTests.ArrayTestRunner(iterationsCount);
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            ListTests.ListTestRunner(iterationsCount);
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            ArrayListTests.ArrayListTestRunner(iterationsCount);
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            Console.Out.WriteLine("Finished Test for iteration count: " + iterationsCount);
            Console.Out.WriteLine("Duration: " + iterationTimer.ElapsedTicks + "(" + iterationTimer.ElapsedMilliseconds + "ms)");
            Console.Out.WriteLine("#######################################################");
        }

        public static void Disposer()
        {

        }


       

    }
}