using Lib;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App.Gui
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            _programTitle = "TSP GA Solver";
            _filePath = null;
            _lastLocation = Application.StartupPath;

            _data = new TspData();
            _data.Nodes = new List<Node>();

            _distancesMinWidth = 50;
            _edgesMinWidth = 50;
            _nodesMinWidth = 50;
            _coordinatesMinWidth = 50;

            _hasModified = false;
            _canSolveTsp = false;
            _canGetDistances = false;
            _canOverwriteDraw = false;

            SetConfiguration();
            LoadDataTables();
        }

        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            Text = $"Untitled - {_programTitle}";

            _mniViewSetup.Checked = !_splitTsp.Panel1Collapsed;
            _mniViewResults.Checked = !_splitMain.Panel2Collapsed;
            _mniSolveTsp.Enabled = false;
            _mniGenerateDistances.Enabled = false;
            _mniClearDistances.Enabled = false;
            _mniClearGraph.Enabled = false;
        }

        #region Menu File
        private void _mniNewTsp_Click(object sender, System.EventArgs e)
        {
            NewProject();
        }

        private void _mniOpenTsp_Click(object sender, System.EventArgs e)
        {
            OpenProject();
        }

        private void _mniSaveTsp_Click(object sender, System.EventArgs e)
        {
            SaveProject();
        }

        private void _mniSaveTspAs_Click(object sender, System.EventArgs e)
        {
            SaveProjectAs();
        }

        private void _mniExportTspToDistances_Click(object sender, System.EventArgs e)
        {

        }

        private void _mniExportTspToGraph_Click(object sender, System.EventArgs e)
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

        private void _mniGenerateDistances_Click(object sender, System.EventArgs e)
        {
            var res = GetDistances(_data.Nodes);

            ClearDistances();

            _distances = res.Distances;
            _edges = res.Edges;

            LoadDistances();
        }

        private void _mniClearDistances_Click(object sender, System.EventArgs e)
        {
            ClearDistances();
        }
        #endregion

        #region Graph
        private void _mniClearGraph_Click(object sender, System.EventArgs e)
        {
            ClearDistances();
            ClearNodes();
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

        private void _pbxCanvas_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var p = new Point(e.X, e.Y);
                var id = (_data.Nodes.Count > 0) ? _data.Nodes.Last().Id + 1 : 0;
                AddNode(new Node(id, id.ToString(), p));
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (_data.Nodes.Count > 0)
                {
                    var lim = 5;
                    var rect = new Rectangle(e.X - lim, e.Y - lim, lim * 2, lim * 2);
                    var found = _data.Nodes.FirstOrDefault(node => rect.Contains(node.Coord));

                    if (found != null)
                    {
                        RemoveNode(found);
                    }
                }
            }
        }
    }
}
