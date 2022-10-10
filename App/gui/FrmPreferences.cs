using Lib.Genetics;
using System.Windows.Forms;

namespace App.Gui
{
    public partial class FrmPreferences : Form
    {
        public GAVerboseOptions Verbose { get; set; }

        public FrmPreferences(GAVerboseOptions verbose)
        {
            InitializeComponent();

            Verbose = new GAVerboseOptions(verbose.Enabled, verbose.All, verbose.Generation, verbose.Crossover, verbose.Mutation, verbose.Result);

            _chxVerboseEnabled.Checked = verbose.Enabled;
            _chxVerboseGeneration.Checked = verbose.Generation;
            _chxVerboseCrossover.Checked = verbose.Crossover;
            _chxVerboseMutation.Checked = verbose.Mutation;
            _chxVerboseResult.Checked = verbose.Result;

            UpdateVerboseCheckboxesEnabled();
            UpdateVerboseAllState();
        }

        private void UpdateVerboseCheckboxesEnabled()
        {
            if (Verbose.Enabled)
            {
                _chxVerboseAll.Enabled = true;
                _chxVerboseGeneration.Enabled = true;
                _chxVerboseCrossover.Enabled = true;
                _chxVerboseMutation.Enabled = true;
                _chxVerboseResult.Enabled = true;

            }
            else
            {
                _chxVerboseAll.Enabled = false;
                _chxVerboseGeneration.Enabled = false;
                _chxVerboseCrossover.Enabled = false;
                _chxVerboseMutation.Enabled = false;
                _chxVerboseResult.Enabled = false;
            }
        }

        private void UpdateVerboseAllState()
        {
            if (Verbose.Generation && Verbose.Crossover && Verbose.Mutation && Verbose.Result)
            {
                _chxVerboseAll.CheckState = CheckState.Checked;
                Verbose.All = true;
            }
            else if (Verbose.Generation || Verbose.Crossover || Verbose.Mutation || Verbose.Result)
            {
                _chxVerboseAll.CheckState = CheckState.Indeterminate;
                Verbose.All = false;
            }
            else
            {
                _chxVerboseAll.CheckState = CheckState.Unchecked;
                Verbose.All = false;
            }
        }

        private void _chxVerboseEnabled_Click(object sender, System.EventArgs e)
        {
            Verbose.Enabled = _chxVerboseEnabled.Checked;
            UpdateVerboseCheckboxesEnabled();
        }

        private void _chxVerboseAll_Click(object sender, System.EventArgs e)
        {
            if (_chxVerboseAll.CheckState == CheckState.Checked)
            {
                Verbose.All = true;
                _chxVerboseGeneration.Checked = true;
                Verbose.Generation = true;
                _chxVerboseCrossover.Checked = true;
                Verbose.Crossover = true;
                _chxVerboseMutation.Checked = true;
                Verbose.Mutation = true;
                _chxVerboseResult.Checked = true;
                Verbose.Result = true;
            }
            else if (_chxVerboseAll.CheckState == CheckState.Indeterminate)
            {
                Verbose.All = false;
            }
            else if (_chxVerboseAll.CheckState == CheckState.Unchecked)
            {
                Verbose.All = false;
                _chxVerboseGeneration.Checked = false;
                Verbose.Generation = false;
                _chxVerboseCrossover.Checked = false;
                Verbose.Crossover = false;
                _chxVerboseMutation.Checked = false;
                Verbose.Mutation = false;
                _chxVerboseResult.Checked = false;
                Verbose.Result = false;
            }
        }

        private void _chxVerboseGeneration_Click(object sender, System.EventArgs e)
        {
            Verbose.Generation = _chxVerboseGeneration.Checked;
            UpdateVerboseAllState();
        }

        private void _chxVerboseCrossover_Click(object sender, System.EventArgs e)
        {
            Verbose.Crossover = _chxVerboseCrossover.Checked;
            UpdateVerboseAllState();
        }

        private void _chxVerboseMutation_Click(object sender, System.EventArgs e)
        {
            Verbose.Mutation = _chxVerboseMutation.Checked;
            UpdateVerboseAllState();
        }

        private void _chxVerboseResult_Click(object sender, System.EventArgs e)
        {
            Verbose.Result = _chxVerboseResult.Checked;
            UpdateVerboseAllState();
        }

        private void _btnSave_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        private void _btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
