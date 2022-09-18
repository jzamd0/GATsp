using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Lib
{
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Point Coord { get; set; }

        public Node()
        {
        }

        public Node(int id, string name, Point coord)
        {
            Id = id;
            Name = name;
            Coord = coord;
        }

        public override string ToString()
        {
            var coord = $" ({Coord.X}, {Coord.Y})";
            return $"{Id}: {Name}{coord}";
        }
    }

    public class Edge<T>
    {
        public T Before { get; set; }
        public T Next { get; set; }
        public double? Distance { get; set; }

        public Edge()
        {
        }

        public Edge(T before, T next, double? distance)
        {
            Before = before;
            Next = next;
            Distance = distance;
        }

        public override string ToString()
        {
            return $"({Before}, {Next}: {Distance})";
        }
    }

    public class TspData
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public List<Node> Nodes { get; set; }

        public TspData()
        {
        }

        public TspData(string name, string comment, List<Node> nodes)
        {
            Name = name;
            Comment = comment;
            Nodes = nodes ?? new List<Node>();
        }

        public override string ToString()
        {
            return $"{Name}: {Comment}, [{string.Join(", ", Nodes.Select(x => $"({x})"))}]";
        }
    }

    public class Tsp
    {
    }
}
