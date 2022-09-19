using Lib;
using System.Collections.Generic;
using System.Windows.Forms;

namespace App.Gui
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            _programTitle = "TSP GA Solver";
            _lastLocation = Application.StartupPath;

            _data = new TspData();
            _data.Nodes = new List<Node>();

            _distancesMinWidth = 50;
            _edgesMinWidth = 50;
            _nodesMinWidth = 50;
            _coordinatesMinWidth = 50;

            _canOverwriteDraw = false;

            _canvasPadding = 40;

            SetConfiguration();
            LoadDataTables();
        }

        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            Text = $"Untitled - {_programTitle}";

            _mniExportTspToDistances.Enabled = false;
            _mniExportTspToGraph.Enabled = false;
            _mniViewSetup.Checked = !_splitTsp.Panel1Collapsed;
            _mniViewResults.Checked = !_splitMain.Panel2Collapsed;
            _mniSolveTsp.Enabled = false;
        }

        #region Menu File
        private void _mniOpenTsp_Click(object sender, System.EventArgs e)
        {
            OpenProject();
        }

        private void _mniExportTspToDistances_Click(object sender, System.EventArgs e)
        {
            ExportProjectToCSV();
        }

        private void _mniExportTspToGraph_Click(object sender, System.EventArgs e)
        {
            ExportProjectToImage();
        }

        private void _mniExit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Menu View
        private void _mniViewSetup_Click(object sender, System.EventArgs e)
        {
            var sollapsed = _mniViewSetup.Checked;
            _splitTsp.Panel2Collapsed = false;
            _splitTsp.Panel1Collapsed = sollapsed;
            _mniViewSetup.Checked = !sollapsed;
        }

        private void _mniViewResults_Click(object sender, System.EventArgs e)
        {
            var collapsed = _mniViewResults.Checked;
            _splitMain.Panel1Collapsed = false;
            _splitMain.Panel2Collapsed = collapsed;
            _mniViewResults.Checked = !collapsed;
        }
        #endregion

        #region Menu TSP
        private void _mniSolveTsp_Click(object sender, System.EventArgs e)
        {

        }
        #endregion

        #region Help
        private void _mniAbout_Click(object sender, System.EventArgs e)
        {

        }
        #endregion

        private void _pnlSetup_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _splitTsp.Panel2Collapsed = !_splitTsp.Panel2Collapsed;
            _mniViewSetup.Checked = !_splitTsp.Panel1Collapsed;
        }

        private void _pnlResult_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _splitMain.Panel1Collapsed = !_splitMain.Panel1Collapsed;
            _mniViewResults.Checked = !_splitMain.Panel2Collapsed;
        }

        private void _pnlTsp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _splitTsp.Panel1Collapsed = !_splitTsp.Panel1Collapsed;
            _mniViewSetup.Checked = !_splitTsp.Panel1Collapsed;
        }

        private void _pbxCanvas_Paint(object sender, PaintEventArgs e)
        {
            DrawNodes(e.Graphics);
            DrawShortestPath(e.Graphics);
        }
    }
}
