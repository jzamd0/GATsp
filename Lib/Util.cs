using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Lib
{
    public static class Util
    {
        public static double GetDistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        public static double GetDistance(Point a, Point b, int decimals)
        {
            var res = Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
            var rounded = Math.Round(res, decimals);
            return rounded;
        }

        public static bool HasEqualSize<T>(this IEnumerable<IEnumerable<T>> table)
        {
            var size = table.Count();

            return table.All(l => l.Count() == size);
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any() || source.Count() == 0;
        }
    }
}
