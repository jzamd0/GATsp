namespace Lib.Genetics
{
    public class GASetup
    {
        public int PopulationSize { get; set; }
        public int Generations { get; set; }
        public double CrossoverRate { get; set; }
        public double MutationRate { get; set; }
        public double ElitismRate { get; set; }
        public string CrossoverType { get; set; }
        public string MutationType { get; set; }

        public GASetup()
        {
        }

        public GASetup(int populationSize, int generations, double crossoverRate, double mutationRate, double elitismRate, string crossoverType, string mutationType)
        {
            PopulationSize = populationSize;
            Generations = generations;
            CrossoverRate = crossoverRate;
            MutationRate = mutationRate;
            ElitismRate = elitismRate;
            CrossoverType = crossoverType;
            MutationType = mutationType;
        }

        public override string ToString()
        {
            return $"{PopulationSize}, {Generations}, {CrossoverRate}, {MutationRate}, {ElitismRate}, {CrossoverType}, {MutationType}";
        }
    }
}
