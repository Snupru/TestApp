using System.Collections.Generic;
using TestApp.Model.Interface;

namespace TestApp.Comparer
{
    public class IntervalComparer : IComparer<IInterval>
    {
        public int Compare(IInterval x, IInterval y)
        {
            if (x.NumberOne < y.NumberOne)
                return -1;

            if (x.NumberOne > y.NumberOne)
                return 1;

            return 0;
        }
    }
}
