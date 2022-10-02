using Lib.Genetics.Operators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Genetics
{
    public class GA
    {
        public static readonly int MinGenerations = 0;
        public static readonly int MinPopulationSize = 4;
        public static readonly int MinGenotypeSize = 4;
        public static readonly int MinNodes = 2;

        protected int TourStart { get; set; }
        protected int TourEnd { get; set; }
        protected int TourRange { get; set; }

        public GAResult Solve(GASetup setup, bool verbose = false)
        {
            if (setup.Generations < MinGenerations)
            {
                throw new ArgumentOutOfRangeException($"Generations must be greater than {MinGenerations - 1}.", nameof(setup.Generations));
            }
            if (setup.PopulationSize < MinPopulationSize)
            {
                throw new ArgumentOutOfRangeException($"Population size must be greater than {MinPopulationSize - 1}.", nameof(setup.PopulationSize));
            }
            if (setup.PopulationSize % 2 != 0)
            {
                throw new ArgumentException($"Population must be even.", nameof(setup.PopulationSize));
            }
            if (setup.GenotypeSize < MinGenotypeSize)
            {
                throw new ArgumentOutOfRangeException($"Genotype size must be greater than {MinGenotypeSize - 1}.", nameof(setup.GenotypeSize));
            }
            if (setup.Distances.IsNullOrEmpty())
            {
                throw new ArgumentNullException($"Distances cannot be null or empty", nameof(setup.Distances));
            }

            TourStart = 1;
            TourEnd = setup.GenotypeSize - 1;
            TourRange = TourEnd - TourStart;

            int generation = 0;

            Individual[] initialPopulation = new Individual[setup.PopulationSize];
            Individual[] newPopulation = null;

            Individual best = null;
            double convergence = 0.0;
            bool hasConverged = false;
            List<double> averageFitnesses = new List<double>();
            List<double> bestFitnesses = new List<double>();
            List<double> convergences = new List<double>();

            var population = InitializePopulation(setup.PopulationSize, setup.GenotypeSize);
            population = GenerateInitialPopulation(population, setup.PopulationSize, setup.GenotypeSize);

            Array.Copy(population, initialPopulation, population.Length);
            initialPopulation = GenerateFitness(initialPopulation, setup.Distances, setup.PopulationSize, setup.GenotypeSize);

            while (true)
            {
                population = GenerateFitness(population, setup.Distances, setup.PopulationSize, setup.GenotypeSize);
                best = GetBestIndividual(population, setup.PopulationSize, setup.GenotypeSize);

                // get average and best fitness
                averageFitnesses.Add(GetAverageFitness(population));
                bestFitnesses.Add(best.Fitness);

                // get convergence for best individual from population
                convergence = GetPopulationConvergence(population, setup.PopulationSize, best);
                convergences.Add(convergence);

                Util.Print($"Generation:                {generation}.", verbose);
                Util.Print($"Average fitness:           {averageFitnesses.Last()}", verbose);
                Util.Print($"Best fitness:              {bestFitnesses.Last()}", verbose);
                Util.Print($"Convergence for best ind.: {convergence} %", verbose);
                Util.Print("---", verbose);

                // stop algorithm when all individuals from the population are the same
                hasConverged = HasPopulationConverged(population);
                if (hasConverged)
                {
                    Util.Print($"Population has converged at generation {generation}.", verbose);
                    Util.Print(null, verbose);
                    break;
                }

                if (generation == setup.Generations)
                {
                    Util.Print($"Algorithm has reached {setup.Generations} generation(s).", verbose);
                    break;
                }

                newPopulation = SelectPopulation(population, setup.PopulationSize, setup.GenotypeSize);
                if (setup.CrossoverRate > 0 && setup.CrossoverType != CrossoverType.None)
                {
                    newPopulation = CrossoverPopulation(newPopulation, setup.PopulationSize, setup.GenotypeSize, setup.CrossoverRate, setup.CrossoverType);
                }
                if (setup.MutationRate > 0 && setup.MutationType != MutationType.None)
                {
                    newPopulation = MutatePopulation(newPopulation, setup.PopulationSize, setup.GenotypeSize, setup.MutationRate, setup.MutationType);
                }
                if (setup.ElitismRate > 0)
                {
                    newPopulation = ReplacePopulationWithElite(newPopulation, setup.PopulationSize, population, setup.ElitismRate);
                }
                population = CopyPopulation(newPopulation, setup.PopulationSize);

                generation += 1;
            }

            TourStart = default(int);
            TourEnd = default(int);
            TourRange = default(int);

            var result = new GAResult();
            result.Best = best;
            result.InitialPopulation = initialPopulation;
            result.LastPopulation = population;
            result.LastGeneration = generation;
            result.LastConvergence = convergence;
            result.HasConverged = hasConverged;
            result.AverageFitnesses = averageFitnesses;
            result.BestFitnesses = bestFitnesses;
            result.Convergences = convergences;

            return result;
        }

        protected Individual[] InitializePopulation(int populationSize, int genotypeSize)
        {
            var population = new Individual[populationSize];

            for (var i = 0; i < populationSize; i++)
            {
                var values = Enumerable.Range(0, TourEnd).Select(x => (double)x).ToArray();
                values = Util.Expand(values, genotypeSize, 0, 0);
                population[i] = new Individual(values, 0);
            }

            return population;
        }

        protected Individual[] GenerateInitialPopulation(Individual[] population, int populationSize, int genotypeSize)
        {
            var rand = new Random();

            for (var i = 0; i < populationSize; i++)
            {
                for (var j = 1; j < TourEnd; j++)
                {
                    var temp = population[i].Values[j];
                    var pos = rand.Next(1, TourEnd);
                    population[i].Values[j] = population[i].Values[pos];
                    population[i].Values[pos] = temp;
                }
            }

            return population;
        }

        protected Individual[] GenerateFitness(Individual[] population, double[][] distances, int populationSize, int genotypeSize)
        {
            for (var i = 0; i < populationSize; i++)
            {
                population[i].Fitness = GetFitness(population[i].Values, distances, genotypeSize);
            }

            return population;
        }

        protected double GetFitness(double[] values, double[][] distances, int genotypeSize)
        {
            double fitness = 0;

            for (var j = 0; j < TourEnd; j++)
            {
                var start = (int)values[j];
                var end = (int)values[j + 1];
                fitness += distances[start][end];
            }

            return fitness;
        }

        protected double GetAverageFitness(Individual[] population)
        {
            return population.Average(i => i.Fitness);
        }

        protected Individual GetBestIndividual(Individual[] population, int populationSize, int genotypeSize)
        {
            var best = population[0];

            for (var i = 0; i < populationSize; i++)
            {
                best = (population[i].Fitness < best.Fitness) ? population[i] : best;
            }

            return best;
        }

        protected Individual[] SelectPopulation(Individual[] population, int populationSize, int genotypeSize)
        {
            var rand = new Random();
            var selop = new Selection();
            var selectedPopulation = new Individual[populationSize];
            var tournamentSize = 2;

            for (var i = 0; i < populationSize; i++)
            {
                var best = selop.Tournament(population, populationSize, tournamentSize, rand);
                selectedPopulation[i] = best;
            }

            return selectedPopulation;
        }

        protected Individual[] CrossoverPopulation(Individual[] population, int populationSize, int genotypeSize, double crossoverRate, CrossoverType xopType)
        {
            var rand = new Random();
            var xop = new Crossover();
            var crossoverPopulation = new Individual[populationSize];
            var range = 1;

            for (var i = 0; i < populationSize; i += 2)
            {
                if (rand.NextDouble() <= crossoverRate)
                {
                    var parent1 = Util.Extract(population[i].Values, TourStart, TourRange);
                    var parent2 = Util.Extract(population[i + 1].Values, TourStart, TourRange);

                    var offspring1 = new double[TourRange];
                    var offspring2 = new double[TourRange];

                    if (xopType == CrossoverType.OBX)
                    {
                        var mask = Enumerable.Repeat(0, TourRange).Select(n => rand.Next(0, 2)).ToArray();

                        offspring1 = xop.OBX(parent1, parent2, TourRange, mask);
                        offspring2 = xop.OBX(parent2, parent1, TourRange, mask);
                    }
                    else if (xopType == CrossoverType.PPX)
                    {
                        var mask = Enumerable.Repeat(0, TourRange).Select(n => rand.Next(0, 2)).ToArray();

                        offspring1 = xop.PPX(parent1, parent2, TourRange, mask);
                        offspring2 = xop.PPX(parent2, parent1, TourRange, mask);
                    }
                    else if (xopType == CrossoverType.TPX)
                    {
                        var point1 = rand.Next(0, TourEnd - 1 - range);
                        var point2 = rand.Next(point1 + 1 + range, TourEnd);

                        offspring1 = xop.TPX(parent1, parent2, TourRange, point1, point2);
                        offspring2 = xop.TPX(parent2, parent1, TourRange, point1, point2);
                    }

                    offspring1 = Util.Expand(offspring1, genotypeSize, TourStart, 0);
                    offspring2 = Util.Expand(offspring2, genotypeSize, TourStart, 0);

                    crossoverPopulation[i] = new Individual(offspring1, 0);
                    crossoverPopulation[i + 1] = new Individual(offspring2, 0);
                }
                else
                {
                    crossoverPopulation[i] = population[i];
                    crossoverPopulation[i + 1] = population[i + 1];
                }
            }

            return crossoverPopulation;
        }

        protected Individual[] MutatePopulation(Individual[] population, int populationSize, int genotypeSize, double mutationRate, MutationType mutopType)
        {
            var rand = new Random();
            var mutop = new Mutation();
            var mutatedPopulation = new Individual[populationSize];

            for (var i = 0; i < populationSize; i++)
            {
                if (rand.NextDouble() <= mutationRate)
                {
                    var point1 = rand.Next(1, TourEnd - 1);
                    var point2 = rand.Next(point1 + 1, TourEnd);

                    if (mutopType == MutationType.Insert)
                    {
                        var values = mutop.Insert(population[i].Values, genotypeSize, point1, point2);
                        mutatedPopulation[i] = new Individual(values, 0);
                    }
                    else if (mutopType == MutationType.Swap)
                    {
                        var values = mutop.Swap(population[i].Values, genotypeSize, point1, point2);
                        mutatedPopulation[i] = new Individual(values, 0);
                    }
                    else if (mutopType == MutationType.Switch)
                    {
                        var values = mutop.Switch(population[i].Values, genotypeSize, point1, point2);
                        mutatedPopulation[i] = new Individual(values, 0);
                    }
                }
                else
                {
                    mutatedPopulation[i] = population[i];
                }
            }

            return mutatedPopulation;
        }

        protected Individual[] ReplacePopulationWithElite(Individual[] population, int populationSize, Individual[] originalPopulation, double elitismRate)
        {
            var rand = new Random();
            var replacedPopulation = new Individual[populationSize];
            var rankedPopulation = Util.Rank(originalPopulation.Select(i => i.Fitness));
            var i = 0;
            var ie = 0;

            while (i < populationSize && ie < rankedPopulation.Length)
            {
                if (rand.NextDouble() <= elitismRate)
                {
                    var elite = originalPopulation[rankedPopulation[ie]];
                    replacedPopulation[i] = new Individual(elite.Values.Copy(), elite.Fitness);
                    ie += 1;
                }
                else
                {
                    replacedPopulation[i] = population[i];
                }
                i += 1;
            }

            return replacedPopulation;
        }

        protected Individual[] CopyPopulation(Individual[] population, int populationSize)
        {
            var copiedPopulation = new Individual[populationSize];

            for (var i = 0; i < populationSize; i++)
            {
                copiedPopulation[i] = new Individual(population[i].Values.Copy(), population[i].Fitness);
            }

            return copiedPopulation;
        }

        protected bool HasPopulationConverged(Individual[] population)
        {
            return population.All(i => i.Fitness == population[0].Fitness);
        }

        protected double GetPopulationConvergence(Individual[] population, int populationSize, Individual individual)
        {
            return (double)(population.Count(i => i.Fitness == individual.Fitness) * 100) / populationSize;
        }
    }

}
