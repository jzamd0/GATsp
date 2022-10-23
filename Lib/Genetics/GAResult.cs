using System;
using System.Collections.Generic;

namespace Lib.Genetics
{
    public class GAResult
    {
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }
        public string SetupId { get; set; }
        public int Number { get; set; }
        public Individual Best { get; set; }
        public Individual[] InitialPopulation { get; set; }
        public Individual[] LastPopulation { get; set; }
        public double LastGeneration { get; set; }
        public double LastConvergence { get; set; }
        public bool HasConverged { get; set; }
        public List<double> AverageFitnesses { get; set; }
        public List<double> BestFitnesses { get; set; }
        public List<double> Convergences { get; set; }
        public long Duration { get; set; }
        public List<GAResult> Results { get; set; }

        public GAResult()
        {
            Results = new List<GAResult>();
        }

        public GAResult(Individual best, Individual[] initialPopulation, Individual[] lastPopulation, double lastGeneration, double lastConvergence, bool hasConverged, List<double> averageFitnesses, List<double> bestFitnesses, List<double> convergences, long duration, DateTime created = default, DateTime finished = default, string setupId = null, int number = 0, List<GAResult> results = null)
        {
            Started = created;
            Finished = finished;
            SetupId = setupId;
            Number = number;
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
            Results = (results.IsNullOrEmpty()) ? new List<GAResult>() : results;
        }
    }
}
