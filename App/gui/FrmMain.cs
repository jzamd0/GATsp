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

            _canvasPadding = 40;

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

        private void _mniTspProperties_Click(object sender, System.EventArgs e)
        {
            using (var frmProperties = new FrmProperties(_data.Name, _data.Comment))
            {
                var res = frmProperties.ShowDialog();

                if (res == DialogResult.OK)
                {
                    _data.Name = frmProperties.Name;
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

        private void _dgvNodes_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var name = e.FormattedValue.ToString();

            if (name.IsNullOrEmpty())
            {
                _dgvNodes.CancelEdit();
                return;
            }

            var node = _data.Nodes[e.RowIndex];

            if (name == node.Name)
            {
                _dgvNodes.CancelEdit();
                return;
            }
        }

        private void _dgvNodes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var name = _dgvNodes.Rows[e.RowIndex].Cells["Name"].Value.ToString();

            RenameNode(e.RowIndex, name);
        }

        private void _dgvCoordinates_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var x = int.Parse(_dgvCoordinates.Rows[e.RowIndex].Cells["X"].Value.ToString());
            var y = int.Parse(_dgvCoordinates.Rows[e.RowIndex].Cells["Y"].Value.ToString());
            var coord = new Point(x, y);

            MoveNode(e.RowIndex, coord.X, coord.Y);
        }

        private void _dgvCoordinates_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var value = e.FormattedValue.ToString();

            if (e.ColumnIndex != 1 && e.ColumnIndex != 2)
            {
                return;
            }

            if (_dgvCoordinates.Rows[e.RowIndex].IsNewRow)
            {
                return;
            }

            if (value.IsNullOrEmpty())
            {
                _dgvCoordinates.CancelEdit();
                return;
            }

            if (!int.TryParse(value, out _))
            {
                _dgvCoordinates.CancelEdit();
                PrintTo("Please add an integer number for the coordinate.", true);
                return;
            }

            var x = -1;
            var y = -1;

            if (e.ColumnIndex == 1)
            {
                x = int.Parse(value);
                y = int.Parse(_dgvCoordinates.Rows[e.RowIndex].Cells["Y"].Value.ToString());
            }
            else if (e.ColumnIndex == 2)
            {
                x = int.Parse(_dgvCoordinates.Rows[e.RowIndex].Cells["X"].Value.ToString());
                y = int.Parse(value);
            }

            var coord = new Point(x, y);
            var node = _data.Nodes[e.RowIndex];

            if (coord.X < 0 || coord.Y < 0)
            {
                _dgvCoordinates.CancelEdit();
                PrintTo("Please add a positive coordinate.", true);
                return;
            }

            if (coord == node.Coord)
            {
                _dgvCoordinates.CancelEdit();
                return;
            }

            if (HasSameCoordinates(coord))
            {
                _dgvCoordinates.CancelEdit();
                PrintTo("Please add a different coordinate for this node.", true);
                return;
            }
        }
    }
}
