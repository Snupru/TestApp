using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using TestApp.Service.Interface;
using TestApp.Model.Interface;
using TestApp.Model;

namespace TestApp.Service
{
    public class IntervalService : IIntervalService
    {
        private string pattern = @"^(\[[0-9]*,[0-9]*\])+$";

        public bool CheckInput(string input)
        {
            Regex regEx = new Regex(pattern);

            if (!string.IsNullOrEmpty(input) && !regEx.IsMatch(input))
            {
                return true;
            }

            return false;
        }

        public IEnumerable<IInterval> GetListOfIntervals(string input)
        {
            var tmpStr = input.Replace("][", ";").Replace("[", "").Replace("]", "");
            var splitStr = tmpStr.Split(';');

            var listOfIntervals = splitStr.Select(_ => new Interval(_)).ToList();

            if (listOfIntervals.Any(x => x.NumberOne > x.NumberTwo))
                return new List<IInterval>();

            return CheckIntervalListAfterOverlap(listOfIntervals);
        }

        private IEnumerable<IInterval> CheckIntervalListAfterOverlap(List<Interval> intervals)
        {
            var newIntervalList = new List<Interval>();
            for (var i = intervals.Count - 1; i >= 0; i--)
            {
                var entry = intervals[i];
                var entryFound = false;

                var min = entry.NumberOne;
                var max = entry.NumberTwo;

                foreach (var listEntry in intervals)
                {
                    if (listEntry == entry)
                        continue;

                    if (listEntry.NumberOne < min && min < listEntry.NumberTwo)
                    {

                    }

                    if (listEntry.NumberTwo > max && max < listEntry.NumberOne)
                    {

                    }
                }

                if (!entryFound)
                {
                    newIntervalList.Add(entry);
                    intervals.Remove(entry);
                }
                else
                    intervals.Remove(entry);
            }

            return newIntervalList;
        }
    }
}
