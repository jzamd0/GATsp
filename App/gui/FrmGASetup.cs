using Lib.Genetics;
using Lib.Genetics.Operators;
using System;
using System.Windows.Forms;

namespace App.Gui
{
    public partial class FrmGASetup : Form
    {
        private string _messageWarningValidNumber { get; set; }
        private string _messageWarningPositiveNumber { get; set; }
        private string _messageWarningRatesInterval { get; set; }

        public FrmGASetup()
        {
            InitializeComponent();

            _messageWarningValidNumber = "Please enter a valid number.";
            _messageWarningPositiveNumber = "Please enter a positive number.";
            _messageWarningRatesInterval = "Rate values must be between 0 and 1.";
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
                new { Text = "None", Value = CrossoverType.None },
                new { Text = "OBX", Value = CrossoverType.OBX },
                new { Text = "PPX", Value = CrossoverType.PPX },
                new { Text = "TPX", Value = CrossoverType.TPX },
            };

            _cbxCrossoverType.DataSource = crossoverItems;

            _cbxMutationType.DisplayMember = "Text";
            _cbxMutationType.ValueMember = "Value";

            var mutationItems = new[] {
                new { Text = "None", Value = MutationType.None },
                new { Text = "Insert", Value = MutationType.Insert },
                new { Text = "Swap", Value = MutationType.Swap },
                new { Text = "Switch", Value = MutationType.Switch },
            };

            _cbxMutationType.DataSource = mutationItems;
        }

        public (bool Valid, GASetup Setup, string Message) GetGASetup()
        {
            if (!int.TryParse(_tbxPopulationSize.Text, out int popSize))
            {
                return (false, null, _messageWarningValidNumber);
            }
            if (!int.TryParse(_tbxGenerations.Text, out int generations))
            {
                return (false, null, _messageWarningValidNumber);
            }
            if (!double.TryParse(_tbxCrossoverRate.Text, out double px))
            {
                return (false, null, _messageWarningValidNumber);
            }
            if (!double.TryParse(_tbxMutationRate.Text, out double pm))
            {
                return (false, null, _messageWarningValidNumber);
            }
            if (!double.TryParse(_tbxElitismRate.Text, out double pe))
            {
                return (false, null, _messageWarningValidNumber);
            }

            // check for negative numbers
            if (popSize < 0 || generations < 0 || px < 0 || pm < 0 || pe < 0)
            {
                return (false, null, _messageWarningPositiveNumber);
            }

            if (popSize < GA.MinPopulationSize)
            {
                return (false, null, $"Population size must be greater than {GA.MinPopulationSize - 1}.");
            }
            if (generations < GA.MinGenerations)
            {
                return (false, null, $"Generations must be greater than {GA.MinGenerations - 1}.");
            }
            if (popSize % 2 != 0)
            {
                return (false, null, "Population size must be even");
            }

            // check for rate interval
            if (!(0 <= px && px <= 1) || !(0 <= pm && pm <= 1) || !(0 <= pe && pe <= 1))
            {
                return (false, null, _messageWarningRatesInterval);
            }

            var setup = new GASetup();
            setup.PopulationSize = popSize;
            setup.Generations = generations;
            setup.CrossoverRate = px;
            setup.MutationRate = pm;
            setup.ElitismRate = pe;
            setup.CrossoverType = (px == 0) ? CrossoverType.None : (CrossoverType)_cbxCrossoverType.SelectedValue;
            setup.MutationType = (pm == 0) ? MutationType.None : (MutationType)_cbxMutationType.SelectedValue;

            return (true, setup, null);
        }
    }
}
