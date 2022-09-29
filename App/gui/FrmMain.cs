using Lib.Tsp;
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
            _lastLocation = Application.StartupPath;
            _fullFileName = null;

            _data = new Graph();
            _data.Nodes = new List<Node>();

            _distancesViewMinWidth = 50;
            _edgesViewMinWidth = 50;
            _nodesViewMinWidth = 50;
            _coordinatesViewMinWidth = 50;

            _canvasPadding = 40;

            _minNodesToSolveTsp = 3;
            _minNodesToDistances = 2;
            _minNodesToGraph = 1;

            _canOverwriteDraw = false;

            SetConfiguration();
            SetDataTables();
            AddGASetupPanel();
        }

        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            SetWindowTitle("Untitled");

            _mniExportTspToDistances.Enabled = false;
            _mniExportTspToGraph.Enabled = false;
            _mniViewSetup.Checked = !_splitTsp.Panel1Collapsed;
            _mniViewResults.Checked = !_splitMain.Panel2Collapsed;
            _mniSolveTsp.Enabled = false;
            _mniGenerateDistances.Enabled = false;
            _mniClearDistances.Enabled = false;
            _mniClearNodes.Enabled = false;
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

        private void _mniTspProperties_Click(object sender, System.EventArgs e)
        {
            using (var frmProperties = new FrmProperties(_data.Name, _data.Comment))
            {
                var res = frmProperties.ShowDialog();

                if (res == DialogResult.OK)
                {
                    _data.Name = frmProperties.ProjectName;
                    _data.Comment = frmProperties.Comment;
                }
            }
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
            var collapsed = _mniViewSetup.Checked;
            _splitTsp.Panel2Collapsed = false;
            _splitTsp.Panel1Collapsed = collapsed;
            _mniViewSetup.Checked = !collapsed;
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
            var res = _frmGASetup.GetGASetup();

            if (!res.Valid)
            {
                PrintTo(res.Message);
                return;
            }

            var setup = res.Setup;

            PrintTo($"{setup}", true);
        }

        private void _minGenerateDistances_Click(object sender, System.EventArgs e)
        {
            GenerateDistances();
        }

        private void _mniClearDistances_Click(object sender, System.EventArgs e)
        {
            ClearDistances();
        }

        private void _mniClearNodes_Click(object sender, System.EventArgs e)
        {
            ClearNodes();
        }
        #endregion

        #region Menu Help
        private void _mniAbout_Click(object sender, System.EventArgs e)
        {

        }
        #endregion

        #region Panels
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
        #endregion

        #region Canvas
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
                var id = GetNodeId();
                AddNode(new Node(id, id.ToString(), p));
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (_data.Nodes.Count > 0)
                {
                    var offset = 5;
                    var selection = new Rectangle(e.X - offset, e.Y - offset, offset * 2, offset * 2);
                    var found = _data.Nodes.FirstOrDefault(node => selection.Contains(node.Coord));

                    if (found != null)
                    {
                        RemoveNode(found);
                    }
                }
            }
        }
        #endregion
    }
}