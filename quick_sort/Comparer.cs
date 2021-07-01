using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace quick_sort
{
    class Comparer : IComparer<int>
    {
        int _n = 0;

        public int Getn()
        {
            return _n;
        }
        public int Compare(int x, int y)
        {
            _n++;
            if (x > y)
                return 1;
            else if (x < y)
                return -1;
            else
                return 0;
        }
    }
}
