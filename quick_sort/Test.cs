using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace quick_sort
{
    class Test
    {
        public static void Time()
        {
            using (StreamWriter stream = new StreamWriter("D:\\c.txt"))
            {
                stream.WriteLine("N; avg_time; avg_comp; avg_q_time; avg_q_comp; min_time; min_comp; min_q_time; min_q_comp");
                for (int N = 10; N <= 150000; N += 5000)
                {
                    Console.WriteLine(N);
                    double avg_time = 0, avg_comp = 0, min_time = 0;
                    int min_comp = 0;
                    double avg_q_time = 0, avg_q_comp = 0, min_q_time = 0;
                    int min_q_comp = 0;

                    for (int i = 0; i < 100; i++)
                    {
                        QuickSort qsort = new QuickSort();

                        Comparer comp1 = new Comparer();
                        Comparer comp2 = new Comparer();


                        int[] arr = new int[N];
                        int[] arr2 = new int[N];

                        Stopwatch sw = new Stopwatch();
                        Stopwatch sw2 = new Stopwatch();

                        Random randNum = new Random();
                        for (int j = 0; j < arr.Length; j++)
                        {
                            arr[j] = randNum.Next(0, N);
                        }
                        Array.Copy(arr, arr2, arr.Length);

                        sw.Start();
                        qsort.QSort(arr, 0, arr.Length - 1, comp1);
                        sw.Stop();

                        sw2.Start();
                        Array.Sort(arr2, comp2);
                        sw2.Stop();

                        if (i == 0 || sw.Elapsed.TotalMilliseconds < min_time)
                            min_time = sw.Elapsed.TotalMilliseconds;
                        if (i == 0 || sw2.Elapsed.TotalMilliseconds < min_q_time)
                            min_q_time = sw2.Elapsed.TotalMilliseconds;

                        if (i == 0 || comp1.Getn() < min_comp)
                            min_comp = comp1.Getn();
                        if (i == 0 || comp2.Getn() < min_q_comp)
                            min_q_comp = comp2.Getn();

                        avg_time = CountMean(avg_time, sw.Elapsed.TotalMilliseconds, i + 1);
                        avg_comp = CountMean(avg_comp, comp1.Getn(), i + 1);

                        avg_q_time = CountMean(avg_q_time, sw2.Elapsed.TotalMilliseconds, i + 1);
                        avg_q_comp = CountMean(avg_q_comp, comp2.Getn(), i + 1);

                    }
                    stream.WriteLine(N + ";" + avg_time + ";" + avg_comp + ";" + avg_q_time + ";" + avg_q_comp + ";" + min_time + ";" + min_comp + ";" + min_q_time + ";" + min_q_comp);
                }
                //stream.WriteLine("{0}", sw.Elapsed.TotalMilliseconds);
            }
        }

        //вычисление среднего по предыдущему шагу
        public static double CountMean(double m, double x, int n)
        {
            return m - (m - x) / (n);
        }
    }
}
