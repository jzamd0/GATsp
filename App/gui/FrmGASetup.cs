using Lib.Genetics;
using System;
using System.Windows.Forms;

namespace App.Gui
{
    public partial class FrmGASetup : Form
    {
        public string MessageWarningValidNumber { get; private set; }
        public string MessageWarningPositiveNumber { get; private set; }
        public string MessageWarningRatesInterval { get; private set; }
        public string MessageWarningRatesDistribution { get; private set; }

        public FrmGASetup()
        {
            InitializeComponent();

            MessageWarningValidNumber = "Please enter a valid number.";
            MessageWarningPositiveNumber = "Please enter a positive number.";
            MessageWarningRatesInterval = "Rates should be between 0 and 1.";
            MessageWarningRatesDistribution = "Rates for crossover and elitism should sum no more than 1.";
        }

        private void FrmGASetup_Load(object sender, EventArgs e)
        {
            SetComboBoxes();
        }

        private void SetComboBoxes()
        {
            _cbxCrossoverType.DisplayMember = "Text";
            _cbxCrossoverType.ValueMember = "Value";

            var crossoverItems = new[] {
                new { Text = "None", Value = string.Empty },
                new { Text = "OX", Value = "1" },
            };

            _cbxCrossoverType.DataSource = crossoverItems;

            _cbxMutationType.DisplayMember = "Text";
            _cbxMutationType.ValueMember = "Value";

            var mutationItems = new[] {
                new { Text = "None", Value = string.Empty },
                new { Text = "Insert", Value = "1" },
                new { Text = "Swap", Value = "2" },
                new { Text = "Switch", Value = "3" },
            };

            _cbxMutationType.DataSource = mutationItems;
        }

        public (bool Valid, GASetup Setup, string Message) GetGASetup()
        {
            if (!int.TryParse(_tbxPopulationSize.Text, out int popSize))
            {
                return (false, null, MessageWarningValidNumber);
            }
            if (!int.TryParse(_tbxGenerations.Text, out int generations))
            {
                return (false, null, MessageWarningValidNumber);
            }
            if (!double.TryParse(_tbxCrossoverRate.Text, out double px))
            {
                return (false, null, MessageWarningValidNumber);
            }
            if (!double.TryParse(_tbxMutationRate.Text, out double pm))
            {
                return (false, null, MessageWarningValidNumber);
            }
            if (!double.TryParse(_tbxElitismRate.Text, out double pe))
            {
                return (false, null, MessageWarningValidNumber);
            }

            // check for negative numbers
            if (popSize < 0 || generations < 0 || px < 0 || pm < 0 || pe < 0)
            {
                return (false, null, MessageWarningPositiveNumber);
            }

            // check for rate interval
            if (!(0 <= px && px <= 1) || !(0 <= pm && pm <= 1) || !(0 <= pe && pe <= 1))
            {
                return (false, null, MessageWarningRatesInterval);
            }

            // check for distribution of rates
            if (px + pe > 1)
            {
                return (false, null, MessageWarningRatesDistribution);
            }

            var setup = new GASetup();
            setup.PopulationSize = popSize;
            setup.Generations = generations;
            setup.CrossoverRate = px;
            setup.MutationRate = pm;
            setup.ElitismRate = pe;
            setup.CrossoverType = (px == 0) ? string.Empty : _cbxCrossoverType.SelectedValue.ToString();
            setup.MutationType = (pm == 0) ? string.Empty : _cbxMutationType.SelectedValue.ToString();

            return (true, setup, null);
        }
    }
}
