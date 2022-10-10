using Lib.Genetics;
using Lib.Genetics.Operators;
using NUnit.Framework;
using System;

namespace GATest
{
    public class SelectionTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TournamentTest()
        {
            var rand = new Random(99519289);

            var population = new Individual[]
            {
                new Individual(new double[] { 1, 2 }, 143),
                new Individual(new double[] { 1, 3 }, 174),
                new Individual(new double[] { 1, 4 }, 87),
                new Individual(new double[] { 1, 5 }, 98),

            };
            var expected = new Individual[]
            {
                population[2],
                population[2],
                population[3],
                population[2],
            };
            var populationSize = expected.Length;
            var tournamentSize = 2;

            var actual = new Individual[populationSize];
            for (var i = 0; i < populationSize; i++)
            {
                var best = Selection.Tournament(population, populationSize, tournamentSize, rand);
                actual[i] = best;

                Assert.AreEqual(expected[i].Values, actual[i].Values);
                Assert.AreEqual(expected[i].Fitness, actual[i].Fitness);
            }
        }
    }
}
