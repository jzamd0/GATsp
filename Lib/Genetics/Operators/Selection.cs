using System;

namespace Lib.Genetics.Operators
{
    public enum SelectionType
    {
        None,
        Tournament,
    }

    public static class Selection
    {
        public static Individual Tournament(Individual[] population, int populationSize, int genotypeSize, int tournamentSize)
        {
            Random rand = new Random();
            Individual best = null;

            for (var i = 0; i < tournamentSize; i++)
            {
                var index = rand.Next(0, populationSize);
                best = (best == null || population[index].Fitness < best.Fitness) ? population[index] : best;
            }

            return best;
        }
    }
}
