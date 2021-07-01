using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace quick_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int Min = 0;
            int Max = 1000000;

            Stopwatch sw = new Stopwatch();
            Stopwatch sw2 = new Stopwatch();

            QuickSort qsort = new QuickSort();
            Comparer comp1 = new Comparer();
            Comparer comp2 = new Comparer();

            int[] arr = new int[1000000];
            int[] arr2 = new int[arr.Length];

            Random randNum = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = randNum.Next(Min, Max);
            }

            Array.Copy(arr, arr2, arr.Length);
            

            //Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            //Console.WriteLine("arr2 = [{0}]", string.Join(", ", arr2));

            
            sw.Start();
            qsort.QSort(arr, 0, arr.Length - 1, comp1);
            sw.Stop();
            //Console.WriteLine("[{0}]", string.Join(", ", arr));

            sw2.Start();
            Array.Sort(arr2, comp2);
            sw2.Stop();

             
            //Test.Time();


            //Console.WriteLine("arr2 = [{0}]", string.Join(", ", arr2));
            Console.WriteLine(" Is sorted = {0}", qsort.IsSorted(arr).ToString());
            Console.WriteLine(" Number of compare = {0}, time = {1}\n Standard QuickSort compare = {2}, time = {3}", comp1.Getn(), sw.Elapsed.TotalMilliseconds, comp2.Getn(), sw2.Elapsed.TotalMilliseconds);
        }

    }
}
