using Lib;
using Lib.Genetics;
using Lib.Tsp;
using System;
using System.Data;
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
            _solvedFromSetups = false;

            SetConfiguration();
            SetDataTables();
            AddGASetupPanel();
        }

        private void FrmMain_Load(object sender, System.EventArgs e)
        {
            SetWindowTitle("Untitled");

            _mniExportTspToDistances.Enabled = false;
            _mniExportTspToGraph.Enabled = false;
            _mniExportResultsToJson.Enabled = false;
            _mniViewSetup.Checked = !_splitTsp.Panel1Collapsed;
            _mniViewResults.Checked = !_splitMain.Panel2Collapsed;
            _mniSolveGA.Enabled = false;
            _mniSolveGASetups.Enabled = false;
            _mniClearGAResult.Enabled = false;
            _mniGenerateDistances.Enabled = false;
            _mniClearDistances.Enabled = false;
            _mniClearNodes.Enabled = false;
            _mniExportResultsSetupsToCsv.Enabled = false;
            _mniExportTimesSetupsToCsv.Enabled = false;

            _dgvPopulations.Visible = false;
            _dgvResults.Visible = false;
            _dgvFitnesses.Visible = false;
            _dgvSummary.Visible = false;
            _dgvResultsSetups.Visible = false;
            _dgvTimesSetups.Visible = false;
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

        private void _mniExportResultsToJson_Click(object sender, System.EventArgs e)
        {
            ExportResultsToJson();
        }

        private void _mniExportResultsSetupsToCsv_Click(object sender, EventArgs e)
        {
            ExportResultsSetupsToCsv();
        }

        private void _mniExportTimesSetupsToCsv_Click(object sender, EventArgs e)
        {
            ExportTimesSetupsCsv();
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

        private void _mniSolveGASetups_Click(object sender, System.EventArgs e)
        {
            using (var frmMultipleSetups = new FrmMultipleSetups())
            {
                var res = frmMultipleSetups.ShowDialog();
                var setups = frmMultipleSetups.Setups;

                if (setups != null)
                {
                    ClearResult();

                    GenerateDistances();

                    setups.ForEach(s =>
                    {
                        s.GenotypeSize = _distances.Length + 1;
                    });

                    var confirm = MessageBox.Show($"{setups.Count} setup(s) are going to be processed. Do you want to continue?", "TSP GA Solver", MessageBoxButtons.YesNo);
                    if (confirm != DialogResult.Yes)
                    {
                        return;
                    }

                    var results = new GA().SolveMultipleSetups(setups, _distances, _verbose.Enabled);

                    var times = setups.First().RunTimes;
                    var dtRS = new DataTable();
                    var dtRT = new DataTable();

                    var cols = new DataColumn[]
                    {
                        new DataColumn("Number", typeof(int)),
                        new DataColumn("Population", typeof(int)),
                        new DataColumn("Generation", typeof(int)),
                        new DataColumn("Crossover Rate", typeof(double)),
                        new DataColumn("Mutation Rate", typeof(double)),
                        new DataColumn("Elitism Rate", typeof(double)),
                        new DataColumn("Crossover Op", typeof(string)),
                        new DataColumn("Mutation Op", typeof(string)),
                    };

                    foreach (var col in cols)
                    {
                        dtRS.Columns.Add(col.ColumnName, col.DataType);
                        dtRT.Columns.Add(col.ColumnName, col.DataType);
                    }

                    for (var i = 0; i < times; i++)
                    {
                        dtRS.Columns.Add("R " + i.ToString(), typeof(double));
                        dtRT.Columns.Add("R " + i.ToString(), typeof(long));
                    }

                    dtRS.Columns.Add("Average", typeof(double));
                    dtRS.Columns.Add("Best", typeof(double));
                    dtRT.Columns.Add("Average", typeof(long));
                    dtRT.Columns.Add("Total", typeof(long));

                    for (var i = 0; i < results.Results.Count; i++)
                    {
                        // result from setups
                        var result = results.Results[i];
                        var selSetup = setups.Where(s => s.Id == result.SetupId).FirstOrDefault();

                        var dr = dtRS.NewRow();
                        dr["Number"] = i;
                        dr["Population"] = selSetup.PopulationSize;
                        dr["Generation"] = selSetup.Generations;
                        dr["Crossover Rate"] = selSetup.CrossoverRate;
                        dr["Mutation Rate"] = selSetup.MutationRate;
                        dr["Elitism Rate"] = selSetup.ElitismRate;
                        dr["Crossover Op"] = selSetup.CrossoverType;
                        dr["Mutation Op"] = selSetup.MutationType;

                        for (var j = 0; j < times; j++)
                        {
                            dr["R " + j.ToString()] = Math.Round(result.Results[j].Best.Fitness, _decimalsToRound);
                        }

                        dr["Average"] = Math.Round(result.BestFitnesses[0], _decimalsToRound);
                        dr["Best"] = Math.Round(result.Best.Fitness, _decimalsToRound);
                        dtRS.Rows.Add(dr);

                        var drT = dtRT.NewRow();
                        drT["Number"] = i;
                        drT["Population"] = selSetup.PopulationSize;
                        drT["Generation"] = selSetup.Generations;
                        drT["Crossover Rate"] = selSetup.CrossoverRate;
                        drT["Mutation Rate"] = selSetup.MutationRate;
                        drT["Elitism Rate"] = selSetup.ElitismRate;
                        drT["Crossover Op"] = selSetup.CrossoverType;
                        drT["Mutation Op"] = selSetup.MutationType;

                        for (var j = 0; j < times; j++)
                        {
                            drT["R " + j.ToString()] = result.Results[j].Duration;
                        }

                        drT["Average"] = result.Results.Average(i => i.Duration);
                        drT["Total"] = result.Duration;
                        dtRT.Rows.Add(drT);
                    }

                    // set shortest path
                    _shortestPath = Helper.MapToPath(_graph.Nodes, results.Best.Values);

                    var dtSummary = (DataTable)_dgvSummary.DataSource;

                    dtSummary.Rows.Add("Started", results.Started.ToString("yyyy-MM-dd HH:mm:ss"));
                    dtSummary.Rows.Add("Finished", results.Finished.ToString("yyyy-MM-dd HH:mm:ss"));
                    dtSummary.Rows.Add("Setups", setups.Count);
                    dtSummary.Rows.Add("Best Tour", string.Join(", ", _shortestPath.Select(n => n.Name).ToArray()));
                    dtSummary.Rows.Add("Best Fitness", Math.Round(results.Best.Fitness, _decimalsToRound));
                    dtSummary.Rows.Add("Number", results.Number);
                    dtSummary.Rows.Add("Duration (ms)", results.Duration);

                    _dgvResultsSetups.DataSource = dtRS;
                    _dgvTimesSetups.DataSource = dtRT;

                    _dgvResultsSetups.Visible = true;
                    _dgvTimesSetups.Visible = true;
                    _dgvSummary.Visible = true;

                    _result = results;
                    _setups = setups;
                    _solvedFromSetups = true;

                    UpdateApp();
                }
            }
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

        private void _dgvNodes_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue == null || e.FormattedValue.ToString().IsNullOrEmpty())
            {
                e.Cancel = true;
                return;
            }
        }

        private void _dgvNodes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var id = int.Parse(_dgvNodes.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            var name = _dgvNodes.Rows[e.RowIndex].Cells["Name"].Value.ToString();

            if (_graph.Nodes.Find(n => n.Id == id).Name != name)
            {
                RenameNode(id, name);
            }
        }
    }
}