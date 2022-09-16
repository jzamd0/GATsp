using Lib;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace App.Gui
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            _isFirstTime = true;

            _lastLocation = Application.StartupPath;

            _distances = new List<List<double>>();
            _points = new List<Point>();
            _headers = new List<string>();
            _edges = new List<Edge<string>>();
        }

        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            _splitMain.Panel2Collapsed = true;
            _splitMain.Visible = false;

            _menuView.Enabled = false;
            _menuTsp.Enabled = false;
            _mniSolveTsp.Enabled = false;
            _mniGenerateDistances.Enabled = false;
            _mniClearDistances.Enabled = false;
            _menuGraph.Enabled = false;
            _mniClearGraph.Enabled = false;

            _mniSaveTsp.Enabled = false;
            _mniSaveTspAs.Enabled = false;

            _tabControlSetup.TabPages.Remove(_tabCoordinates);
            _tabControlTsp.TabPages.Remove(_tabGraph);

            // TEMP: Disable Grpah elements.
            _mniNewTspGraph.Enabled = false;
            _mniOpenTspGraph.Enabled = false;
        }

        #region Menu File
        private void _mniNewTspGraph_Click(object sender, System.EventArgs e)
        {
        }

        private void _mniNewTspMatrix_Click(object sender, System.EventArgs e)
        {
            NewProject();
        }

        private void _mniOpenTspGraph_Click(object sender, System.EventArgs e)
        {
        }

        private void _mniOpenTspMatrix_Click(object sender, System.EventArgs e)
        {
            OpenProject();
        }

        private void _mniSaveTsp_Click(object sender, System.EventArgs e)
        {

        }

        private void _mniSaveTspAs_Click(object sender, System.EventArgs e)
        {

        }

        private void _mniExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Menu Edit
        private void _mniPreferences_Click(object sender, System.EventArgs e)
        {

        }
        #endregion

        #region Menu View
        private void _mniViewSetup_Click(object sender, System.EventArgs e)
        {
            var visible = _mniViewSetup.Checked;
            _mniViewSetup.Checked = !visible;
            _splitTsp.Panel1Collapsed = visible;
        }

        private void _mniViewResults_Click(object sender, System.EventArgs e)
        {
            var visible = _mniViewResults.Checked;
            _mniViewResults.Checked = !visible;
            _splitMain.Panel2Collapsed = visible;
        }
        #endregion

        #region Menu TSP
        private void _mniSolveTsp_Click(object sender, System.EventArgs e)
        {

        }

        private void _mniGenerateDistances_Click(object sender, System.EventArgs e)
        {

        }

        private void _mniClearDistances_Click(object sender, System.EventArgs e)
        {

        }
        #endregion

        #region Graph
        private void _mniClearGraph_Click(object sender, System.EventArgs e)
        {

        }
        #endregion

        #region Help
        private void _mniAbout_Click(object sender, System.EventArgs e)
        {

        }
        #endregion
    }
}
