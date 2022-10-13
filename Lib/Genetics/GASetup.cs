using Lib.Genetics.Operators;

namespace Lib.Genetics
{
    public class GASetup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double[][] Distances { get; set; }
        public int GenotypeSize { get; set; }
        public int PopulationSize { get; set; }
        public int Generations { get; set; }
        public double CrossoverRate { get; set; }
        public double MutationRate { get; set; }
        public double ElitismRate { get; set; }
        public SelectionType SelectionType { get; set; }
        public CrossoverType CrossoverType { get; set; }
        public MutationType MutationType { get; set; }

        public GASetup()
        {
        }

        public GASetup(string id, string name, double[][] distances, int genotypeSize, int populationSize, int generations, double crossoverRate, double mutationRate, double elitismRate, SelectionType selectionType, CrossoverType crossoverType, MutationType mutationType)
        {
            Id = id;
            Name = name;
            Distances = distances;
            GenotypeSize = genotypeSize;
            PopulationSize = populationSize;
            Generations = generations;
            CrossoverRate = crossoverRate;
            MutationRate = mutationRate;
            ElitismRate = elitismRate;
            SelectionType = selectionType;
            CrossoverType = crossoverType;
            MutationType = mutationType;
        }
    }
}
