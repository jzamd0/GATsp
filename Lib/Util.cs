using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Lib
{
    public static class Util
    {
        public static string CreateShortId()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }

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

        public static double GetDouble(Random rand, double minimum, double maximum)
        {
            return rand.NextDouble() * (maximum - minimum) + minimum;
        }

        public static bool HasEqualSize<T>(this IEnumerable<IEnumerable<T>> table)
        {
            var size = table.Count();
            return table.All(l => l.Count() == size);
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || source.Count() == 0;
        }

        public static T[] Copy<T>(this T[] array)
        {
            return array.Copy(0, array.Length);
        }

        public static T[] Copy<T>(this T[] array, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, index, result, 0, length);
            return result;
        }

        public static T[] Extract<T>(T[] array, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, index, result, 0, length);
            return result;
        }

        public static T[] Fill<T>(T[] array, T value)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
            return array;
        }

        public static T[] Expand<T>(T[] array, int size, int index, T value)
        {
            var result = new T[size];
            result = Fill(result, value);
            Array.Copy(array, 0, result, index, array.Length);
            return result;
        }

        public static int[] Rank<T>(IEnumerable<T> array) where T : IComparable<T>
        {
            return array.Select((i, index) => (i, index)).OrderBy(a => a.i).Select(a => a.index).Distinct().ToArray();
        }

        public static int[] RankDescending<T>(IEnumerable<T> array) where T : IComparable<T>
        {
            return array.Select((i, index) => (i, index)).OrderByDescending(a => a.i).Select(a => a.index).Distinct().ToArray();
        }
    }
}
