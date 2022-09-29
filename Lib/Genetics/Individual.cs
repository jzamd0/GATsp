namespace Lib.Genetics
{
    public class Individual
    {
        public double[] Values { get; set; }
        public double Fitness { get; set; }

        public Individual()
        {
        }

        public Individual(double[] values, double fitness)
        {
            Values = values;
            Fitness = fitness;
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", Values)}], {Fitness}";
        }
    }
}
