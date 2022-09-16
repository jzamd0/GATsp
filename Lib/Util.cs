using System.Collections.Generic;
using System.Linq;

namespace Lib
{
    public static class Util
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || source.Any();
        }
    }
}
