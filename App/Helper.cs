﻿using Lib;
using Lib.Tsp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace App
{
    public static class Helper
    {
        public static bool HasSameCoordinates(List<Point> points, Point p)
        {
            return points.Any(pa => Util.GetDistance(pa, p) == 0);
        }

        public static bool HasSameCoordinates(List<Node> nodes, Point p)
        {
            return nodes.Any(n => Util.GetDistance(n.Coord, p) == 0);
        }

        public static List<Node> MapToPath(List<Node> nodes, double[] values)
        {
            var path = new List<Node>();

            for (var i = 0; i < values.Length; i++)
            {
                path.Add(nodes[(int)values[i]]);
            }

            return path;
        }

        public static bool HasDuplicateId(List<Node> nodes)
        {
            return nodes.GroupBy(x => x.Id).Any(g => g.Count() > 1);
        }

        public static bool HasDuplicateName(List<Node> nodes)
        {
            return nodes.GroupBy(x => x.Name).Any(g => g.Count() > 1);
        }

        public static SizeF MeasureString(string s, Font font)
        {
            SizeF result;

            using (var image = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(image))
                {
                    result = g.MeasureString(s, font);
                }
            }

            return result;
        }

        public static string[] ConvertToCsv(double[][] matrix)
        {
            var n = matrix.Length;
            var s = new string[n];

            for (var i = 0; i < n; i++)
            {
                s[i] = $"{string.Join(",", matrix[i].Select(n => Math.Round(n, 3)).ToArray())}";
            }

            return s;
        }
    }
}
