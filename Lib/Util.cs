using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public static class Util
    {
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
