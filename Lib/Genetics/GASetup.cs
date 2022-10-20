using Lib.Genetics.Operators;

namespace Lib.Genetics
{
    public class GASetup
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int GenotypeSize { get; set; }
        public int PopulationSize { get; set; }
        public int Generations { get; set; }
        public double CrossoverRate { get; set; }
        public double MutationRate { get; set; }
        public double ElitismRate { get; set; }
        public SelectionType SelectionType { get; set; }
        public CrossoverType CrossoverType { get; set; }
        public MutationType MutationType { get; set; }
        public bool Multiple { get; set; }
        public bool Parallel { get; set; }
        public int RunTimes { get; set; }

        public GASetup()
        {
            Id = Util.CreateShortId();
        }

        public GASetup(string name, int genotypeSize, int populationSize, int generations, double crossoverRate, double mutationRate, double elitismRate, SelectionType selectionType, CrossoverType crossoverType, MutationType mutationType, bool multiple = false, bool parallel = false, int runTimes = 0)
        {
            Id = Util.CreateShortId();
            Name = name;
            GenotypeSize = genotypeSize;
            PopulationSize = populationSize;
            Generations = generations;
            CrossoverRate = crossoverRate;
            MutationRate = mutationRate;
            ElitismRate = elitismRate;
            SelectionType = selectionType;
            CrossoverType = crossoverType;
            MutationType = mutationType;
            Multiple = multiple;
            Parallel = parallel;
            RunTimes = runTimes;
        }
    }
}
