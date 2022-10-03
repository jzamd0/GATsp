﻿using Lib.Genetics.Operators;

namespace Lib.Genetics
{
    public class GASetup
    {
        public double[][] Distances { get; set; }
        public int GenotypeSize { get; set; }
        public int PopulationSize { get; set; }
        public int Generations { get; set; }
        public double CrossoverRate { get; set; }
        public double MutationRate { get; set; }
        public double ElitismRate { get; set; }
        public CrossoverType CrossoverType { get; set; }
        public MutationType MutationType { get; set; }

        public GASetup()
        {
        }

        public GASetup(double[][] distances, int genotypeSize, int populationSize, int generations, double crossoverRate, double mutationRate, double elitismRate, CrossoverType crossoverType, MutationType mutationType)
        {
            Distances = distances;
            GenotypeSize = genotypeSize;
            PopulationSize = populationSize;
            Generations = generations;
            CrossoverRate = crossoverRate;
            MutationRate = mutationRate;
            ElitismRate = elitismRate;
            CrossoverType = crossoverType;
            MutationType = mutationType;
        }
    }
}