using System;
using System.Collections.Generic;
using System.Text;

namespace quick_sort
{
    class QuickSort
    {

        private int _insert = 10;
        /*private int Partition(int[] arr, int left, int right, Comparer comp)
        {

        }*/

        public void QSort(int[] arr, int left, int right, Comparer comp)
        {

            if (right <= left + _insert)
            {
                InsertSort(arr, left, right, comp);
                return;
            }
            while (right > left + _insert)
            {
                //int j = Partition(arr, left, right, comp);
                int p = arr[left];

                int i = left + 1;
                int lt = left;
                int gt = right;

                while (i <= gt)
                {
                    int cmp = comp.Compare(arr[i], p);

                    if (cmp < 0)
                        Exch(arr, lt++, i++);
                    else if (cmp > 0)
                        Exch(arr, i, gt--);
                    else
                        i++;
                }

                //Exch(arr, left, --lt);

                if (lt - left < right - gt)
                {
                    QSort(arr, left, lt - 1, comp);
                    left = gt + 1;
                }
                else
                {
                    QSort(arr, gt + 1, right, comp);
                    right = lt - 1;
                }
            }
            InsertSort(arr, left, right, comp);
            return;
        }
        public bool IsSorted(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                    return false;
            }
            return true;
        }
        private void Exch(int[] arr, int i, int j)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
        public void InsertSort(int[] arr, int left, int right, Comparer comp)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && comp.Compare(arr[j], key) > 0)
                {
                    Exch(arr, j, j + 1);
                    j--;
                }
                arr[j + 1] = key;
            }
        }

        
    }
}
