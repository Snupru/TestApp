using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Model.Interface;

namespace TestApp.Model
{
    public class Interval : IInterval
    {
        public int NumberOne { get; }
        public int NumberTwo { get; }

        public Interval(string interval)
        {
            var splitString = interval.Split(',');
            if (splitString.Length != 2)
                return;

            int tmpValue;
            if (int.TryParse(splitString[0], out tmpValue))
                NumberOne = tmpValue;

            if (int.TryParse(splitString[1], out tmpValue))
                NumberTwo = tmpValue;
        }

        public Interval(int one, int two)
        {
            NumberOne = one;
            NumberTwo = two;
        }

        public string GetIntervalAsString()
        {
            return "[" + NumberOne + "," + NumberTwo + "]";
        }
    }
}
