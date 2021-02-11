using TestApp.Model.Interface;

namespace TestApp.Model
{
    //Datenhalter
    public class Interval : IInterval
    {
        public int NumberOne { get; }
        public int NumberTwo { get; }

        public Interval(string interval)
        {
            if (string.IsNullOrEmpty(interval))
                return;

            var splitString = interval.Split(',');
            if (splitString.Length != 2)
                return;

            int tmpValue;
            if (int.TryParse(splitString[0], out tmpValue))
                NumberOne = tmpValue;

            if (int.TryParse(splitString[1], out tmpValue))
                NumberTwo = tmpValue;
        }

        public Interval(int firstNumber, int secondNumber)
        {
            NumberOne = firstNumber;
            NumberTwo = secondNumber;
        }

        public string GetIntervalAsString()
        {
            return "[" + NumberOne + "," + NumberTwo + "]";
        }
    }
}
