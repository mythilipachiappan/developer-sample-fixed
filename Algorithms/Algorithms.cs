using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        public static int GetFactorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Negative numbers are not allowed.");

            int result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static string FormatSeparators(params string[] items)
        {
            if (items == null || items.Length == 0)
                return string.Empty;

            if (items.Length == 1)
                return items[0];

            if (items.Length == 2)
                return $"{items[0]} and {items[1]}";

            return string.Join(", ", items.Take(items.Length - 1)) + " and " + items.Last();
        }
    }
}