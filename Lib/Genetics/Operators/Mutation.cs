using System;

namespace Lib.Genetics.Operators
{
    public enum MutationType
    {
        None,
        Insert,
        Swap,
        Switch,
    }

    public static class Mutation
    {
        public static double[] Insert(double[] values, int genotypeSize, int point1, int point2)
        {
            var offspring = new double[genotypeSize];
            Array.Copy(values, offspring, genotypeSize);

            offspring[point2] = values[point1];

            if (point1 < point2)
            {
                for (var i = point1; i < point2; i++)
                {
                    offspring[i] = values[i + 1];
                }
            }
            else if (point1 > point2)
            {
                for (var i = point2 + 1; i <= point1; i++)
                {
                    offspring[i] = values[i - 1];
                }
            }

            return offspring;
        }

        public static double[] Swap(double[] values, int genotypeSize, int point1, int point2)
        {
            var offspring = new double[genotypeSize];
            Array.Copy(values, offspring, genotypeSize);

            var temp = offspring[point1];
            offspring[point1] = offspring[point2];
            offspring[point2] = temp;

            return offspring;
        }

        public static double[] Switch(double[] values, int genotypeSize, int point1, int point2)
        {
            var offspring = new double[genotypeSize];
            Array.Copy(values, offspring, genotypeSize);

            Array.Reverse(offspring, point1, point2 + 1 - point1);

            return offspring;
        }
    }
}
