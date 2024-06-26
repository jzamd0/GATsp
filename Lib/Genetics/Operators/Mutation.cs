﻿using System;
using System.Linq;

namespace Lib.Genetics.Operators
{
    public enum MutationType
    {
        None,
        Insert,
        Swap,
        Switch,
        SwitchByMask,
        InsertByMask,
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

        public static double[] Switch(double[] values, int genotypeSize, int point1)
        {
            var offspring = new double[genotypeSize];
            Array.Copy(values, offspring, genotypeSize);

            var point2 = point1 + 1;
            var temp = offspring[point1];
            offspring[point1] = offspring[point2];
            offspring[point2] = temp;

            return offspring;
        }

        public static double[] SwitchByMask(double[] values, int genotypeSize, int[] mask)
        {
            var offspring = new double[genotypeSize];
            Array.Copy(values, offspring, genotypeSize);

            for (var i = 1; i < genotypeSize; i++)
            {
                if (mask[i] == 1)
                {
                    var temp = offspring[i - 1];
                    offspring[i - 1] = offspring[i];
                    offspring[i] = temp;
                }
            }

            return offspring;
        }

        public static double[] InsertByMask(double[] values, int genotypeSize, int[] mask)
        {
            var offspring = values.ToList();

            for (var i = 1; i < genotypeSize; i++)
            {
                if (mask[i] != -1)
                {
                    var temp = offspring[i];
                    offspring.Remove(temp);
                    offspring.Insert(mask[i], temp);
                }
            }

            return offspring.ToArray();
        }

        public static double[] Swap(double[] values, int genotypeSize, int point1, int point2)
        {
            var offspring = new double[genotypeSize];
            Array.Copy(values, offspring, genotypeSize);

            Array.Reverse(offspring, point1, point2 + 1 - point1);

            return offspring;
        }
    }
}
