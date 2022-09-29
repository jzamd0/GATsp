namespace Lib.Genetics
{
    public class GAResult
    {
        public Individual Best { get; set; }
        public Individual[] InitialPopulation { get; set; }
        public Individual[] LastPopulation { get; set; }
        public double LastGeneration { get; set; }
        public double Convergence { get; set; }
        public bool HasConverged { get; set; }
        public double[] AverageFitnesses { get; set; }
        public double[] BestFitnesses { get; set; }
        public double[] Convergences { get; set; }

        public GAResult()
        {
        }

        public GAResult(Individual best, Individual[] initialPopulation, Individual[] lastPopulation, double lastGeneration, double convergence, bool hasConverged, double[] averageFitnesses, double[] bestFitnesses, double[] convergences)
        {
            Best = best;
            InitialPopulation = initialPopulation;
            LastPopulation = lastPopulation;
            LastGeneration = lastGeneration;
            Convergence = convergence;
            HasConverged = hasConverged;
            AverageFitnesses = averageFitnesses;
            BestFitnesses = bestFitnesses;
            Convergences = convergences;
        }
    }
}
