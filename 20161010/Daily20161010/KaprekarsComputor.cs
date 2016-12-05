using System;
using System.Linq;

namespace Daily20161010
{
    public static class KaprekarsComputor
    {
        public static char GetMaximalDigitFromFourDigitNumber(int number)
        {
            var digitsDescending = GetDigitsInDescendingOrder(number);
            return digitsDescending.First();
        }

        public static string GetDigitsInDescendingOrder(int number)
        {
            var digitsDescending =
                number.ToString("D4").ToCharArray().OrderByDescending(x => x).Where(char.IsDigit);
            return string.Join("", digitsDescending);
        }

        public static string GetDigitsInAscendingOrder(int number)
        {
            var t = GetDigitsInDescendingOrder(number).Reverse();
            return string.Join("", t);
        }

        public static bool HasAtLeastTwoDifferentDigits(int number)
        {
            return number.ToString("D4").Distinct().Count() >= 2;
        }

        public static int CountIterations(int number)
        {
            var workingNumber = number;
            var prev = -1;

            var iterations = 0;

            while (prev != workingNumber)
            {
                var ascending = GetDigitsInAscendingOrder(workingNumber);
                var descending = GetDigitsInDescendingOrder(workingNumber);
                prev = workingNumber;
                workingNumber = int.Parse(descending) - int.Parse(ascending);
                iterations++;
            }

            return iterations - 1;
        }

    }
}