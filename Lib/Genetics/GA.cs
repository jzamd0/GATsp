using Lib.Genetics.Operators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Genetics
{
    public class GA
    {
        public static readonly int GenerationsLimit = 0;
        public static readonly int PopulationSizeLimit = 3;
        public static readonly int GenotypeSizeLimit = 4;
        public static readonly int NodesLimit = 2;

        protected int TourStart { get; set; }
        protected int TourEnd { get; set; }
        protected int TourRange { get; set; }

        public GAResult Solve(GASetup setup, bool verbose = false)
        {
            if (setup.Generations < GenerationsLimit)
            {
                throw new ArgumentOutOfRangeException($"Generations must be greater than {GenerationsLimit - 1}.", nameof(setup.Generations));
            }
            if (setup.PopulationSize < PopulationSizeLimit)
            {
                throw new ArgumentOutOfRangeException($"Population size must be greater than {PopulationSizeLimit - 1}.", nameof(setup.PopulationSize));
            }
            if (setup.GenotypeSize < GenotypeSizeLimit)
            {
                throw new ArgumentOutOfRangeException($"Genotype size must be greater than {GenotypeSizeLimit - 1}.", nameof(setup.GenotypeSize));
            }
            if (setup.Distances.IsNullOrEmpty())
            {
                throw new ArgumentNullException($"Distances cannot be null or empty", nameof(setup.Distances));
            }

            TourStart = 1;
            TourEnd = setup.GenotypeSize - 1;
            TourRange = TourEnd - TourStart;

            int generation = 0;
            int selectedPopulationSize = setup.PopulationSize;
            int crossoverPopulationSize = (int)Math.Floor(setup.PopulationSize * setup.CrossoverRate);
            int elitePopulationSize = (int)Math.Floor(setup.PopulationSize * setup.ElitismRate);

            Individual[] initialPopulation = new Individual[setup.PopulationSize];
            Individual[] crossoverPopulation = null;
            Individual[] elitePopulation = null;

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

                Util.Print($"Generation of algorithm is {generation}.", verbose);
                // get convergence for best individual from population
                convergence = GetPopulationConvergence(population, setup.PopulationSize, best);
                convergences.Add(convergence);
                Util.Print($"Convergence is about {convergence} % for best individual with {best.Fitness}.", verbose);
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

                var selectedPopulation = SelectPopulation(population, setup.PopulationSize, setup.GenotypeSize, selectedPopulationSize);
                if (setup.CrossoverRate > 0 && setup.CrossoverType != CrossoverType.None)
                {
                    crossoverPopulation = CrossoverPopulation(selectedPopulation, selectedPopulationSize, setup.GenotypeSize, crossoverPopulationSize, setup.CrossoverType);
                }
                if (setup.CrossoverRate > 0 && setup.MutationRate > 0 && setup.MutationType != MutationType.None)
                {
                    crossoverPopulation = MutatePopulation(crossoverPopulation, crossoverPopulationSize, setup.GenotypeSize, setup.MutationRate, setup.MutationType);
                }
                if (setup.ElitismRate > 0)
                {
                    elitePopulation = GetElitePopulation(population, setup.PopulationSize, elitePopulationSize);
                }
                if (!crossoverPopulation.IsNullOrEmpty() || !elitePopulation.IsNullOrEmpty())
                {
                    population = MigratePopulation(population, setup.PopulationSize, crossoverPopulation, elitePopulation);
                }

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
            result.AverageFitnesses = averageFitnesses.ToArray();
            result.BestFitnesses = bestFitnesses.ToArray();
            result.Convergences = convergences.ToArray();

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

        protected Individual[] SelectPopulation(Individual[] population, int populationSize, int genotypeSize, int selectedPopulationSize)
        {
            var selectedPopulation = new Individual[selectedPopulationSize];
            var tournamentSize = 2;

            for (var i = 0; i < selectedPopulationSize; i++)
            {
                var best = Selection.Tournament(population, populationSize, genotypeSize, tournamentSize);
                selectedPopulation[i] = best;
            }

            return selectedPopulation;
        }

        protected Individual[] CrossoverPopulation(Individual[] population, int populationSize, int genotypeSize, int crossoverPopulationSize, CrossoverType xopType)
        {
            var rand = new Random();
            var xop = new Crossover();
            var populationEvenSize = (crossoverPopulationSize % 2 == 0) ? crossoverPopulationSize : crossoverPopulationSize + 1;
            var crossoverPopulation = new List<Individual>();

            while (crossoverPopulation.Count < populationEvenSize)
            {
                var parent1 = Util.Extract(population[rand.Next(0, populationSize)].Values, TourStart, TourRange);
                var parent2 = Util.Extract(population[rand.Next(0, populationSize)].Values, TourStart, TourRange);

                var values1 = new double[TourRange];
                var values2 = new double[TourRange];

                if (xopType == CrossoverType.OX)
                {
                    var point1 = rand.Next(0, TourEnd - 1);
                    var point2 = rand.Next(point1 + 1, TourEnd);

                    values1 = xop.OX(parent1, parent2, TourRange, point1, point2);
                    values2 = xop.OX(parent2, parent1, TourRange, point1, point2);
                }

                values1 = Util.Expand(values1, genotypeSize, TourStart, 0);
                values2 = Util.Expand(values2, genotypeSize, TourStart, 0);

                crossoverPopulation.Add(new Individual(values1, 0));
                crossoverPopulation.Add(new Individual(values2, 0));
            }

            // if the size of the population is odd, return all individuals except the last one
            return (populationSize % 2 == 0) ? crossoverPopulation.ToArray() : Util.Extract(crossoverPopulation.ToArray(), 0, crossoverPopulationSize);
        }

        protected Individual[] MutatePopulation(Individual[] population, int populationSize, int genotypeSize, double mutationRate, MutationType mutopType)
        {
            var rand = new Random();
            var mutop = new Mutation();
            var mutatedPopulation = new Individual[populationSize];

            for (var i = 0; i < populationSize; i++)
            {
                if (rand.NextDouble() < mutationRate)
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

        protected Individual[] GetElitePopulation(Individual[] population, int populationSize, int elitePopulationSize)
        {
            return population
                .GroupBy(i => i.Fitness)
                .Select(g => g.First())
                .OrderBy(i => i.Fitness)
                .Take(elitePopulationSize)
                .ToArray();
        }

        protected Individual[] MigratePopulation(Individual[] population, int populationSize, params Individual[][] populations)
        {
            var individuals = new List<Individual>();
            var counter = 0;

            foreach (var p in populations)
            {
                InsertPopulation(populationSize, individuals, p, ref counter);
            }
            InsertPopulation(populationSize, individuals, population, ref counter, true);

            return individuals.ToArray();
        }

        protected void InsertPopulation(int populationSize, List<Individual> individuals, Individual[] population, ref int counter, bool random = false)
        {
            var rand = new Random();

            if (!population.IsNullOrEmpty())
            {
                for (var i = 0; i < population.Length; i++)
                {
                    if (counter == populationSize)
                    {
                        break;
                    }

                    if (!random)
                    {
                        individuals.Add(population[i]);
                    }
                    else
                    {
                        var index = rand.Next(0, population.Length);
                        individuals.Add(population[index]);
                    }
                    counter += 1;
                }
            }
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
