using System.Collections.Generic;

namespace Lib.Genetics
{
    public class GAResult
    {
        public Individual Best { get; set; }
        public Individual[] InitialPopulation { get; set; }
        public Individual[] LastPopulation { get; set; }
        public double LastGeneration { get; set; }
        public double LastConvergence { get; set; }
        public bool HasConverged { get; set; }
        public List<double> AverageFitnesses { get; set; }
        public List<double> BestFitnesses { get; set; }
        public List<double> Convergences { get; set; }
        public long Duration { get; internal set; }

        public GAResult()
        {
        }

        public GAResult(Individual best, Individual[] initialPopulation, Individual[] lastPopulation, double lastGeneration, double lastConvergence, bool hasConverged, List<double> averageFitnesses, List<double> bestFitnesses, List<double> convergences, long duration)
        {
            Best = best;
            InitialPopulation = initialPopulation;
            LastPopulation = lastPopulation;
            LastGeneration = lastGeneration;
            LastConvergence = lastConvergence;
            HasConverged = hasConverged;
            AverageFitnesses = averageFitnesses;
            BestFitnesses = bestFitnesses;
            Convergences = convergences;
            Duration = duration;
        }
    }
}
