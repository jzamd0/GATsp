namespace Lib.Tsp
{
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
}
