using Lib.Genetics;
using Lib.Genetics.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace App.Gui
{
    public partial class FrmMultipleSetups : Form
    {
        public List<GASetup> Setups { get; set; }

        public FrmMultipleSetups()
        {
            InitializeComponent();
        }

        public List<GASetup> GetMultipleSetups()
        {
            var setups = new List<GASetup>();

            // get texts and slice them to create list of parameters
            var tPops = _tbxPopulations.Text.Split(',').Select(t => t.Trim()).ToList();
            var tGens = _tbxGenerations.Text.Split(',').Select(t => t.Trim()).ToList();
            var tCRs = _tbxCrossoverRates.Text.Split(',').Select(t => t.Trim()).ToList();
            var tMRs = _tbxMutationRates.Text.Split(',').Select(t => t.Trim()).ToList();
            var tERs = _tbxElitismRates.Text.Split(',').Select(t => t.Trim()).ToList();
            var tCOps = _tbxCrossoverOperators.Text.Split(',').Select(t => t.Trim()).ToList();
            var tMOps = _tbxMutationOperators.Text.Split(',').Select(t => t.Trim()).ToList();

            var multiple = _chxMutliple.Checked;
            var parallel = _chxParallel.Checked;
            var rTimes = int.Parse(_tbxRunTimes.Text);

            var pops = tPops.Select(t => int.Parse(t)).ToList();
            var gens = tGens.Select(t => int.Parse(t)).ToList();
            var cRs = tCRs.Select(t => double.Parse(t)).ToList();
            var mRs = tMRs.Select(t => double.Parse(t)).ToList();
            var eRs = tERs.Select(t => double.Parse(t)).ToList();
            var cOps = tCOps.Select(t => (CrossoverType)Enum.Parse(typeof(CrossoverType), t)).ToList();
            var mOps = tMOps.Select(t => (MutationType)Enum.Parse(typeof(MutationType), t)).ToList();

            foreach (var pop in pops)
            {
                foreach (var gen in gens)
                {
                    foreach (var cOp in cOps)
                    {
                        foreach (var cR in cRs)
                        {
                            foreach (var mOp in mOps)
                            {
                                foreach (var mR in mRs)
                                {
                                    foreach (var eR in eRs)
                                    {
                                        var setup = new GASetup
                                        (
                                            name: $"{pop}, {gen}, {cOp}, {cR}, {mOp}, {mR}",
                                            populationSize: pop,
                                            genotypeSize: 0,
                                            generations: gen,
                                            crossoverRate: cR,
                                            mutationRate: mR,
                                            elitismRate: eR,
                                            selectionType: SelectionType.Tournament,
                                            crossoverType: cOp,
                                            mutationType: mOp,
                                            multiple: multiple,
                                            parallel: parallel,
                                            runTimes: rTimes
                                        );

                                        setups.Add(setup);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return setups;
        }

        private void _btnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                Setups = GetMultipleSetups();
                Close();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is FormatException)
            {
                MessageBox.Show("Something went wrong. Make sure the values are separated by comma and are valid. Also, make sure all of the fields have at least one value. Run times has only one value");
            }
        }
        private void _btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
