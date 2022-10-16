using Lib;
using Lib.Genetics;
using Lib.Tsp;
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

            _project = new GAProject();

            _distancesViewMinWidth = 50;
            _edgesViewMinWidth = 50;
            _nodesViewMinWidth = 50;
            _coordinatesViewMinWidth = 50;

            _canvasPadding = 40;

            _minNodesToSolveTsp = GA.MinGenotypeSize - 1;
            _minNodesToDistances = _minNodesToSolveTsp;
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
            _mniSolveGA.Enabled = false;
            _mniClearGAResult.Enabled = false;
            _mniGenerateDistances.Enabled = false;
            _mniClearDistances.Enabled = false;
            _mniClearNodes.Enabled = false;

            _dgvPopulations.Visible = false;
            _dgvSummary.Visible = false;
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
            using (var frmProperties = new FrmProperties(_project.Name, _project.Comment))
            {
                var res = frmProperties.ShowDialog();

                if (res == DialogResult.OK)
                {
                    _project.Name = frmProperties.ProjectName;
                    _project.Comment = frmProperties.Comment;
                }
            }
        }

        private void _mniPreferences_Click(object sender, System.EventArgs e)
        {
            using (var frmPreferences = new FrmPreferences(_verbose))
            {
                var res = frmPreferences.ShowDialog();

                if (res == DialogResult.OK)
                {
                    _verbose = frmPreferences.Verbose;
                }
            }
        }

        private void _mniExportTspToDistances_Click(object sender, System.EventArgs e)
        {
            ExportDistancesToCsv();
        }

        private void _mniExportTspToGraph_Click(object sender, System.EventArgs e)
        {
            ExportGraphToImage();
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

        #region Menu GA
        private void _mniSolveGA_Click(object sender, System.EventArgs e)
        {
            var valid = _frmGASetup.ValidateGASetup();

            if (!valid.Valid)
            {
                PrintTo(valid.Message);
                return;
            }

            var setup = _frmGASetup.GetGASetup();
            SolveGA(setup);
        }

        private void _mniClearGASetup_Click(object sender, System.EventArgs e)
        {
            ClearSetup();

            UpdateApp();
        }

        private void _mniClearGAResult_Click(object sender, System.EventArgs e)
        {
            ClearResult();

            UpdateApp();
        }
        #endregion

        #region Menu TSP
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
            using (var frmAbout = new FrmAbout())
            {
                var res = frmAbout.ShowDialog();
            }
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
            ClearCanvas(e.Graphics);
            DrawShortestPath(e.Graphics);
            DrawNodes(e.Graphics);
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
                if (_graph.Nodes.Count > 0)
                {
                    var offset = 5;
                    var selection = new Rectangle(e.X - offset, e.Y - offset, offset * 2, offset * 2);
                    var found = _graph.Nodes.FirstOrDefault(node => selection.Contains(node.Coord));

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