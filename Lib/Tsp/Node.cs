using System.Drawing;

namespace Lib.Tsp
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
            var coord = (Coord != null && !Coord.IsEmpty) ? $" ({Coord.X}, {Coord.Y})" : "";
            return $"{Id}: {Name}{coord}";
        }
    }
}
