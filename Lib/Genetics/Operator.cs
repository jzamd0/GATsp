using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Genetics
{
    public static class Operator
    {
        public static double[] OrderCrossover(double[] parent1, double[] parent2, int genotypeSize, int point1, int point2)
        {
            var offspring = new double[genotypeSize];
            var xRange = point2 - point1;

            // copy the bits from the cut from the first parent to the first offspring
            for (var i = point1; i < point2; i++)
            {
                offspring[i] = parent1[i];
            }

            // concat second parent to map from second point to second point circulaly
            var parent2Map = parent2.Concat(parent2).ToArray();
            // get point to stop mapping from second parent map
            var parent2MapPoint2 = genotypeSize + point2;
            // create a list to store the mapped values from second parent
            var offspringMap = new List<double>();
            // get cut from first parent
            var parent1Cut = parent1.ToList().GetRange(point1, xRange).ToArray();

            // search the bits to map from the the second parent, starting from the second point and
            // then to the second point circularly
            for (var i = point2; i < parent2MapPoint2; i++)
            {
                var bit = parent2Map[i];

                // if the bit doesn't exist in the cut, add it to the map
                if (!parent1Cut.Contains(bit))
                {
                    offspringMap.Add(bit);
                }
            }

            // add the mapped bits in order into the offspring, starting from second point to the end
            for (var i = point2; i < genotypeSize; i++)
            {
                offspring[i] = offspringMap[i - point2];
            }
            // add the mapped bits in order into the offspring, starting from start to the first point
            for (var i = 0; i < point1; i++)
            {
                offspring[i] = offspringMap[i + genotypeSize - point2];
            }

            return offspring;
        }

        public static double[] MutateBySwap(double[] individual, int genotypeSize, int? firstSwapPoint = null, int? secondSwapPoint = null)
        {
            var point1 = firstSwapPoint ?? new Random().Next(1, genotypeSize - 1);
            var point2 = secondSwapPoint ?? new Random().Next(point1 + 1, genotypeSize);

            var tempBit = individual[point1];
            individual[point1] = individual[point2];
            individual[point2] = tempBit;

            return individual;
        }
    }
}
