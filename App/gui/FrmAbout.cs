using System;
using System.Windows.Forms;

namespace App.Gui
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            Text = "About TSP GA Solver";
            _lblDescription.Text = @"
Solve a TSP problem using a genetic algorithm.
            
Create a graph in the Graph tab.
Specify setup parameters for GA in the Setup tab.
Generate a TSP solution with given setup.";
        }

        private void _btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
