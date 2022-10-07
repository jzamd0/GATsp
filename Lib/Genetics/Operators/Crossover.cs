using System;
using System.Linq;

namespace Lib.Genetics.Operators
{
    public enum CrossoverType
    {
        None,
        OBX,
        PPX,
        TPX,
    }

    public class Crossover
    {
        public Crossover()
        {
        }

        public double[] PPX(double[] parent1, double[] parent2, int genotypeSize, int[] mask)
        {
            var offspring = new double[genotypeSize];
            // index for parents 1 and 2
            var i1 = 0;
            var i2 = 0;

            for (var i = 0; i < genotypeSize; i++)
            {
                if (mask[i] == 1)
                {
                    while (offspring.Contains(parent1[i1]))
                    {
                        i1 += 1;
                    }
                    offspring[i] = parent1[i1];
                    i1 += 1;
                }
                else if (mask[i] == 0)
                {
                    while (offspring.Contains(parent2[i2]))
                    {
                        i2 += 1;
                    }
                    offspring[i] = parent2[i2];
                    i2 += 1;
                }
            }

            return offspring;
        }

        public double[] OBX(double[] parent1, double[] parent2, int genotypeSize, int[] mask)
        {
            var offspring = new double[genotypeSize];
            var i2 = 0;

            for (var i = 0; i < genotypeSize; i++)
            {
                if (mask[i] == 1)
                {
                    offspring[i] = parent1[i];
                }
            }

            for (var i = 0; i < genotypeSize; i++)
            {
                if (mask[i] == 0)
                {
                    while (offspring.Contains(parent2[i2]))
                    {
                        i2 += 1;
                    }
                    offspring[i] = parent2[i2];
                    i2 += 1;
                }
            }

            return offspring;
        }

        public double[] TPX(double[] parent1, double[] parent2, int genotypeSize, int point1, int point2)
        {
            var offspring = new double[genotypeSize];
            var i2 = 0;

            for (var i = 0; i < genotypeSize; i++)
            {
                if (point1 < i && i < point2)
                {
                    continue;
                }
                offspring[i] = parent1[i];
            }

            for (var i = point1 + 1; i < point2; i++)
            {
                while (offspring.Contains(parent2[i2]))
                {
                    i2 += 1;
                }
                offspring[i] = parent2[i2];
                i2 += 1;
            }

            return offspring;
        }
    }
}
