using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TestApp.Service.Interface;
using TestApp.Model.Interface;
using TestApp.Model;
using TestApp.Comparer;

namespace TestApp.Service
{
    public class IntervalService : IIntervalService
    {
        private string pattern = @"^(\[[0-9]*,[0-9]*\])+$";

        //Überprüft anhand einer Regex ob der eingegebene String korrekt ist.
        public bool CheckInput(string input)
        {
            Regex regEx = new Regex(pattern);

            if (!string.IsNullOrEmpty(input) && !regEx.IsMatch(input))
            {
                return true;
            }

            return false;
        }

        //Gibt eine gefilterte Liste zurück.
        //Bei Fehler wird eine leere Liste zurückgegeben.
        public IEnumerable<IInterval> GetListOfIntervals(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new List<IInterval>();

            var tmpStr = input.Replace("][", ";").Replace("[", "").Replace("]", "");
            var splitStr = tmpStr.Split(';');

            var listOfIntervals = splitStr.Select(_ => new Interval(_)).ToList();

            if (listOfIntervals.Any(x => x.NumberOne > x.NumberTwo))
                return new List<IInterval>();

            return CheckIntervalListAfterOverlap(listOfIntervals);
        }

        //Diese Methode überprüft die Intervall-Liste auf Überlappungen und passt sie ggf. an
        private IEnumerable<IInterval> CheckIntervalListAfterOverlap(List<Interval> intervals)
        {
            var newIntervalList = new List<Interval>();
            intervals.Sort(new IntervalComparer());

            for (var i = intervals.Count - 1; i >= 0; i--)
            {
                var entry = intervals[i];
                var entryFound = false;

                var min = entry.NumberOne;
                var max = entry.NumberTwo;
                var listToRemove = new List<Interval>();

                foreach (var listEntry in intervals)
                {
                    if (listEntry == entry)
                        continue;

                    if (listEntry.NumberOne < min && min < listEntry.NumberTwo)
                    {
                        min = listEntry.NumberOne;
                        entryFound = true;
                        listToRemove.Add(listEntry);
                    }

                    if (listEntry.NumberTwo > max && max < listEntry.NumberOne)
                    {
                        max = listEntry.NumberTwo;
                        entryFound = true;
                        listToRemove.Add(listEntry);
                    }
                }

                if (!entryFound)
                {
                    if (!newIntervalList.Any(x => x.NumberOne < min && x.NumberTwo > max))
                        newIntervalList.Add(entry);
                    intervals.Remove(entry);
                }
                else
                {
                    foreach (var tmp in listToRemove)
                    {
                        if (intervals.Contains(tmp))
                        {
                            intervals.Remove(tmp);
                            i--;
                        }
                    }

                    intervals.Remove(entry);
                    newIntervalList.Add(new Interval(min, max));
                }
            }

            return newIntervalList;
        }
    }
}
