using Lib.Genetics;
using Lib.Tsp;

namespace Lib
{
    public class GAProject
    {
        public string Name { get; set; }
        public string Comment { get; set; }
        public Graph Graph { get; set; }
        public GASetup Setup { get; set; }

        public GAProject()
        {
            Graph = new Graph();
        }

        public GAProject(string name, string comment, Graph graph, GASetup setup)
        {
            Name = name;
            Comment = comment;
            Graph = graph;
            Setup = setup;
        }
    }
}