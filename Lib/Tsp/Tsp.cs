using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Tsp
{
    public static class Tsp
    {
        public static List<Node> MapNodesToPath(List<Node> nodes, double[] values)
        {
            var path = new List<Node>();

            for (var i = 0; i < values.Length; i++)
            {
                path.Add(nodes[(int)values[i]]);
            }

            return path;
        }

        public static List<string> MapHeadersToPath(List<Node> nodes, double[] values)
        {
            var headers = new List<string>();

            for (var i = 0; i < values.Length; i++)
            {
                headers.Add(nodes[(int)values[i]].Name);
            }

            return headers;
        }
    }
}
