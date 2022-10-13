using System.Collections.Generic;
using System.Linq;

namespace Lib.Tsp
{
    public class Graph
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public List<Node> Nodes { get; set; }

        public Graph()
        {
            Nodes = new List<Node>();
        }

        public Graph(string name, string comment, List<Node> nodes)
        {
            Name = name;
            Comment = comment;
            Nodes = nodes;
        }

        public override string ToString()
        {
            return $"{Name}: {Comment}, [{string.Join(", ", Nodes.Select(x => $"({x})"))}]";
        }
    }
}
