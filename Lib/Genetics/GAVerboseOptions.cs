namespace Lib.Genetics
{
    public class GAVerboseOptions
    {
        public bool Enabled { get; set; }
        public bool All { get; set; }
        public bool Generation { get; set; }
        public bool Crossover { get; set; }
        public bool Mutation { get; set; }

        public GAVerboseOptions()
        {
        }

        public GAVerboseOptions(bool enabled, bool all, bool generation, bool crossover, bool mutation)
        {
            Enabled = enabled;
            All = all;
            Generation = generation;
            Crossover = crossover;
            Mutation = mutation;
        }
    }
}
