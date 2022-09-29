using System;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Genetics.Operators
{
    public enum CrossoverType
    {
        None,
        OX,
    }

    public class Crossover
    {
        public Crossover()
        {
        }

        public double[] OX(double[] parent1, double[] parent2, int genotypeSize, int point1, int point2)
        {
            var offspring = new double[genotypeSize];
            var crossoverRange = point2 - point1;

            // copy the bits from the cut from the first parent to the first offspring
            for (var i = point1; i < point2; i++)
            {
                offspring[i] = parent1[i];
            }

            // concat second parent to map from second point to second point again
            var parent2Map = Util.Extract(parent2.Concat(parent2).ToArray(), point2, genotypeSize);
            // get point to stop mapping from second parent map
            // create a list to store the mapped values from second parent
            var offspringMap = new List<double>();
            // get cut from first parent
            var parent1Cut = Util.Extract(parent1, point1, crossoverRange);

            // search the bits to map from the  second parent
            for (var i = 0; i < parent2Map.Length; i++)
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
    }
}
