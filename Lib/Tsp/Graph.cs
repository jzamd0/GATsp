using System.Collections.Generic;
using System.Linq;

namespace Lib.Tsp
{
    public class Graph
    {
        public List<Node> Nodes { get; set; }

        public Graph()
        {
            Nodes = new List<Node>();
        }

        public Graph(List<Node> nodes)
        {
            Nodes = nodes;
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", Nodes.Select(x => $"({x})"))}]";
        }
    }
}
