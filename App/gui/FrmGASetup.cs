using Lib;
using Lib.Genetics;
using Lib.Genetics.Operators;
using System;
using System.Windows.Forms;

namespace App.Gui
{
    public partial class FrmGASetup : Form
    {
        private static readonly string _defaultSetupName = "default";

        private static readonly string _messageWarningValidNumber = "Please enter a valid number.";
        private static readonly string _messageWarningRatesInterval = "Rate values must be between 0 and 1.";

        public FrmGASetup()
        {
            InitializeComponent();
        }

        private void FrmGASetup_Load(object sender, EventArgs e)
        {
            SetComboBoxes();

            _tbxName.Text = _defaultSetupName;
            _tbxPopulationSize.Text = $"{GA.MinPopulationSize}";
            _tbxGenerations.Text = $"{GA.MinGenerations}";

            _chxParallelGA.Enabled = false;
            _tbxRunTimes.Enabled = false;

            ChangeCrossoverTypeStatus();
            ChangeMutationTypeStatus();
        }

        private void SetComboBoxes()
        {
            _cbxSelectionType.DisplayMember = "Text";
            _cbxSelectionType.ValueMember = "Value";

            var selectionItems = new[] {
                new { Text = "None", Value = SelectionType.None },
                new { Text = "Tournament", Value = SelectionType.Tournament },
            };

            _cbxSelectionType.DataSource = selectionItems;

            _cbxCrossoverType.DisplayMember = "Text";
            _cbxCrossoverType.ValueMember = "Value";

            var crossoverItems = new[] {
                new { Text = "None", Value = CrossoverType.None },
                new { Text = "OBX", Value = CrossoverType.OBX },
                new { Text = "PPX", Value = CrossoverType.PPX },
                new { Text = "TPX", Value = CrossoverType.TPX },
                new { Text = "OSX", Value = CrossoverType.OSX },
                new { Text = "OBX2", Value = CrossoverType.OBX2 },
            };

            _cbxCrossoverType.DataSource = crossoverItems;

            _cbxMutationType.DisplayMember = "Text";
            _cbxMutationType.ValueMember = "Value";

            var mutationItems = new[] {
                new { Text = "None", Value = MutationType.None },
                new { Text = "Insert", Value = MutationType.Insert },
                new { Text = "Swap", Value = MutationType.Swap },
                new { Text = "Switch", Value = MutationType.Switch },
                new { Text = "SwitchByMask", Value = MutationType.SwitchByMask },
            };

            _cbxMutationType.DataSource = mutationItems;
        }

        public void SetGASetup(GASetup setup)
        {
            _tbxName.Text = setup.Name;
            _tbxPopulationSize.Text = setup.PopulationSize.ToString();
            _tbxGenerations.Text = setup.Generations.ToString();
            _tbxCrossoverRate.Text = setup.CrossoverRate.ToString();
            _tbxMutationRate.Text = setup.MutationRate.ToString();
            _tbxElitismRate.Text = setup.ElitismRate.ToString();
            _cbxSelectionType.SelectedValue = setup.SelectionType;
            _cbxCrossoverType.SelectedValue = setup.CrossoverType;
            _cbxMutationType.SelectedValue = setup.MutationType;
            _chxMultipleGA.Checked = setup.Multiple;
            _chxParallelGA.Checked = setup.Parallel;
            _tbxRunTimes.Text = setup.RunTimes.ToString();
        }

        public (bool Valid, string Message) ValidateGASetup()
        {
            if (!int.TryParse(_tbxPopulationSize.Text, out int popSize))
            {
                return (false, _messageWarningValidNumber);
            }
            if (!int.TryParse(_tbxGenerations.Text, out int generations))
            {
                return (false, _messageWarningValidNumber);
            }
            if (!double.TryParse(_tbxCrossoverRate.Text, out double px))
            {
                return (false, _messageWarningValidNumber);
            }
            if (!double.TryParse(_tbxMutationRate.Text, out double pm))
            {
                return (false, _messageWarningValidNumber);
            }
            if (!double.TryParse(_tbxElitismRate.Text, out double pe))
            {
                return (false, _messageWarningValidNumber);
            }
            if (!double.TryParse(_tbxRunTimes.Text, out double runTimes))
            {
                return (false, _messageWarningValidNumber);
            }

            if (popSize < GA.MinPopulationSize)
            {
                return (false, $"Population size must be greater than {GA.MinPopulationSize - 1}.");
            }
            if (generations < GA.MinGenerations)
            {
                return (false, $"Generations must be greater than {GA.MinGenerations - 1}.");
            }
            if (popSize % 2 != 0)
            {
                return (false, "Population size must be even");
            }
            if (runTimes < GA.MinMultipleRuns)
            {
                return (false, $"Number of runs must be greather than {GA.MinMultipleRuns - 1}.");
            }

            // check for rate interval
            if (!(0 <= px && px <= 1) || !(0 <= pm && pm <= 1) || !(0 <= pe && pe <= 1))
            {
                return (false, _messageWarningRatesInterval);
            }

            return (true, null);
        }

        public GASetup GetGASetup()
        {
            var setup = new GASetup
            {
                Name = (_tbxName.Text.IsNullOrEmpty()) ? _defaultSetupName : _tbxName.Text,
                PopulationSize = int.Parse(_tbxPopulationSize.Text),
                Generations = int.Parse(_tbxGenerations.Text),
                CrossoverRate = double.Parse(_tbxCrossoverRate.Text),
                MutationRate = double.Parse(_tbxMutationRate.Text),
                ElitismRate = double.Parse(_tbxElitismRate.Text),
                SelectionType = (SelectionType)_cbxSelectionType.SelectedValue,
                Multiple = _chxMultipleGA.Checked,
            };

            setup.CrossoverType = (setup.CrossoverRate == 0) ? CrossoverType.None : (CrossoverType)_cbxCrossoverType.SelectedValue;
            setup.MutationType = (setup.MutationRate == 0) ? MutationType.None : (MutationType)_cbxMutationType.SelectedValue;
            if (setup.Multiple)
            {
                setup.Parallel = _chxParallelGA.Checked;
                setup.RunTimes = int.Parse(_tbxRunTimes.Text);
            }

            return setup;
        }

        public void ClearGASetup()
        {
            _tbxName.Text = _defaultSetupName;
            _tbxPopulationSize.Text = GA.MinPopulationSize.ToString();
            _tbxGenerations.Text = GA.MinGenerations.ToString();
            _tbxCrossoverRate.Text = "0.0";
            _tbxMutationRate.Text = "0.0";
            _tbxElitismRate.Text = "0.0";
            _cbxSelectionType.SelectedIndex = 0;
            _cbxCrossoverType.SelectedIndex = 0;
            _cbxMutationType.SelectedIndex = 0;
            _chxMultipleGA.Checked = false;
            _chxParallelGA.Checked = false;
            _tbxRunTimes.Text = GA.MinMultipleRuns.ToString();
        }

        private void _tbxCrossoverRate_TextChanged(object sender, EventArgs e)
        {
            ChangeCrossoverTypeStatus();
        }

        private void _tbxMutationRate_TextChanged(object sender, EventArgs e)
        {
            ChangeMutationTypeStatus();
        }

        private void ChangeCrossoverTypeStatus()
        {
            var valid = double.TryParse(_tbxCrossoverRate.Text, out var crossoverRate);
            _cbxCrossoverType.Enabled = valid && crossoverRate > 0;
        }

        private void ChangeMutationTypeStatus()
        {
            var valid = double.TryParse(_tbxMutationRate.Text, out var mutationRate);
            _cbxMutationType.Enabled = valid && mutationRate > 0;
        }

        private void _chxMultipleGA_CheckedChanged(object sender, EventArgs e)
        {
            _chxParallelGA.Enabled = _chxMultipleGA.Checked;
            _tbxRunTimes.Enabled = _chxMultipleGA.Checked;

        }
    }
}
