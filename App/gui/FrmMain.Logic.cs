using Lib;
using Lib.Genetics;
using Lib.Tsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace App.Gui
{
    public partial class FrmMain
    {
        private FrmGASetup _frmGASetup { get; set; }

        private string _programTitle { get; set; }
        private string _fileTitle { get; set; }
        private string _lastLocation { get; set; }
        private string _fullFileName { get; set; }

        private GAProject _project { get; set; }
        private Graph _graph
        {
            get => _project.Graph;
            set => _project.Graph = value;
        }
        private GASetup _setup
        {
            get => _project.Setup;
            set => _project.Setup = value;
        }
        private GAResult _result { get; set; }
        private double[][] _distances { get; set; }
        private Edge<Node>[] _edges { get; set; }
        private List<Node> _shortestPath { get; set; }

        private int _distancesViewMinWidth { get; set; }
        private int _edgesViewMinWidth { get; set; }
        private int _nodesViewMinWidth { get; set; }
        private int _coordinatesViewMinWidth { get; set; }

        private int _canvasPadding { get; set; }

        // constraints
        public int _minNodesToSolveTsp { get; set; }
        public int _minNodesToDistances { get; set; }
        public int _minNodesToGraph { get; set; }

        // program flags
        private bool _canOverwriteDraw { get; set; }

        // program options
        private GAVerboseOptions _verbose { get; set; }
        private int _decimalsToRound { get; set; }
        private CanvasOptions _canvas { get; set; }

        private Pen _pen { get; set; }
        private SolidBrush _brush { get; set; }
        private Pen _firstPen { get; set; }
        private SolidBrush _firstBrush { get; set; }
        private SolidBrush _nodeTextBrush { get; set; }
        private Pen _linePen { get; set; }

        private void SetConfiguration()
        {
            _verbose = new GAVerboseOptions(false, false, false, false, false);
            _decimalsToRound = 3;

            _canvas = new CanvasOptions();
            _canvas.PointWidth = 10;
            _canvas.PointHeight = 10;
            _canvas.NodeColor = Color.DodgerBlue;
            _canvas.FirstNodeColor = Color.GreenYellow;
            _canvas.NodeTextColor = Color.Black;
            _canvas.NodeFont = new Font("Arial", 9);
            _canvas.LineColor = Color.Black;
            _canvas.BackColor = Color.White;

            _pen = new Pen(_canvas.NodeColor);
            _brush = new SolidBrush(_canvas.NodeColor);
            _firstPen = new Pen(_canvas.FirstNodeColor);
            _firstBrush = new SolidBrush(_canvas.FirstNodeColor);
            _nodeTextBrush = new SolidBrush(_canvas.NodeTextColor);
            _linePen = new Pen(_canvas.LineColor);

            _pbxCanvas.BackColor = _canvas.BackColor;
        }

        private void AddGASetupPanel()
        {
            _frmGASetup = new FrmGASetup();
            _frmGASetup.TopLevel = false;
            _tabSetup.Controls.Add(_frmGASetup);
            _frmGASetup.FormBorderStyle = FormBorderStyle.None;
            _frmGASetup.Dock = DockStyle.Fill;
            _frmGASetup.Show();
        }

        #region File
        private void NewProject()
        {
            ClearData();

            _project = new GAProject();

            _fullFileName = null;
            SetWindowTitle("Untitled");

            UpdateApp();
        }

        private void OpenProject()
        {
            string filePath;
            string fullFileName;
            string fileName;
            string inputData;

            using (var openDialog = new OpenFileDialog())
            {
                openDialog.InitialDirectory = _lastLocation;
                openDialog.Title = "Open Project";
                openDialog.Filter = "JSON (*.json)|*.json";
                openDialog.FilterIndex = 1;
                openDialog.RestoreDirectory = true;

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        fullFileName = openDialog.FileName;
                        filePath = Path.GetFullPath(openDialog.FileName);
                        fileName = openDialog.SafeFileName;
                        inputData = File.ReadAllText(fullFileName);

                        if (inputData.IsNullOrEmpty())
                        {
                            PrintTo("File is empty. Please open a JSON file that is not empty.", true);
                            return;
                        }

                        // deserialize json to project data
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                        };
                        var project = (GAProject)JsonSerializer.Deserialize(inputData, typeof(GAProject), options);

                        var valid = AreNodesValid(project.Graph.Nodes);
                        if (!valid.Valid)
                        {
                            PrintTo(valid.Message, true);
                            return;
                        }

                        ClearData();

                        _project = project;

                        LoadProject();

                        _fullFileName = fullFileName;
                        _lastLocation = filePath;
                        SetWindowTitle(fileName);

                        UpdateApp();
                    }
                    catch (Exception ex) when (ex is IOException || ex is JsonException || ex is FormatException)
                    {
                        PrintTo(ex.Message, true);
                    }
                }
            }
        }

        private void LoadProject()
        {
            if (_graph.Nodes.Count > 0)
            {
                DisplayNodes();
            }
            if (_graph.Nodes.Count >= _minNodesToDistances)
            {
                GenerateDistances();
            }
            if (_setup != null)
            {
                DisplaySetup();
            }
        }

        private void SaveProject()
        {
            if (File.Exists(_fullFileName))
            {
                WriteProject(_fullFileName);
            }
            else
            {
                SaveProjectAs();
            }
        }

        private void SaveProjectAs()
        {
            string filePath;
            string fullFileName;
            string fileName;

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.InitialDirectory = _lastLocation;
                saveDialog.Title = "Save Project";
                saveDialog.Filter = "JSON (*.json)|*.json";
                saveDialog.DefaultExt = "json";
                saveDialog.AddExtension = true;
                saveDialog.RestoreDirectory = true;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        fullFileName = saveDialog.FileName;
                        filePath = Path.GetFullPath(saveDialog.FileName);
                        fileName = Path.GetFileName(fullFileName);

                        WriteProject(fullFileName);

                        _fullFileName = fullFileName;
                        _lastLocation = filePath;
                        SetWindowTitle(fileName);

                        UpdateApp();
                    }
                    catch (Exception ex) when (ex is IOException || ex is JsonException || ex is FormatException)
                    {
                        PrintTo(ex.Message, true);
                    }
                }
            }
        }

        private void WriteProject(string fullFileName)
        {
            var res = _frmGASetup.ValidateGASetup();
            if (res.Valid)
            {
                _setup = _frmGASetup.GetGASetup();
                _setup.GenotypeSize = _graph.Nodes.Count + 1;
            }
            else
            {
                PrintTo("Invalid setup parameters will not be saved. Please try entering valid data for the setup.\n" + res.Message);
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize(_project, typeof(GAProject), options);
            File.WriteAllText(fullFileName, json);
        }

        private void ExportDistancesToCsv()
        {
            using (var exportDialog = new SaveFileDialog())
            {
                exportDialog.InitialDirectory = _lastLocation;
                exportDialog.Title = "Export Distances To CSV";
                exportDialog.Filter = "CSV (*.csv)|*.csv";
                exportDialog.DefaultExt = "csv";
                exportDialog.AddExtension = true;
                exportDialog.RestoreDirectory = true;

                if (exportDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var res = GetDistances(_graph.Nodes);

                        var fullFileName = exportDialog.FileName;
                        var values = Helper.ConvertToCsv(res.Distances);
                        File.WriteAllLines(fullFileName, values);
                    }
                    catch (Exception ex) when (ex is IOException)
                    {
                        PrintTo(ex.Message, true);
                    }
                }
            }
        }

        private void ExportGraphToImage()
        {
            using (var exportDialog = new SaveFileDialog())
            {
                exportDialog.InitialDirectory = _lastLocation;
                exportDialog.Title = "Export To Image";
                exportDialog.Filter = "PNG (*.png)|*.png";
                exportDialog.RestoreDirectory = true;

                if (exportDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var fullFileName = exportDialog.FileName;

                        var minX = _graph.Nodes.Select(n => n.Coord.X).Min();
                        var minY = _graph.Nodes.Select(n => n.Coord.Y).Min();
                        // get furthest x coordinate using the node coordinate with the text width added
                        var maxX = _graph.Nodes.Select(n => n.Coord.X + Helper.MeasureString(n.Name, _canvas.NodeFont).ToSize().Width).Max();
                        var width = maxX + (_canvasPadding * 2) - minX;
                        var height = _graph.Nodes.Select(n => n.Coord.Y).Max() + (_canvasPadding * 2) - minY;

                        var bmap = new Bitmap(width, height);
                        var g = Graphics.FromImage(bmap);

                        g.Clear(_canvas.BackColor);
                        DrawShortestPathForImage(g, new Point(minX, minY), _canvasPadding);
                        DrawNodesForImage(g, new Point(minX, minY), _canvasPadding);

                        bmap.Save(fullFileName, ImageFormat.Png);
                        g.Dispose();
                    }
                    catch (Exception ex) when (ex is IOException)
                    {
                        PrintTo(ex.Message, true);
                    }
                }
            }
        }
        #endregion

        private void SetWindowTitle(string file)
        {
            _fileTitle = file;
            Text = $"{_fileTitle} - {_programTitle}";
        }

        private void EnableOrDisableMenuItems()
        {
            _mniSolveGA.Enabled = _graph.Nodes.Count >= _minNodesToSolveTsp;

            _mniExportTspToDistances.Enabled = _graph.Nodes.Count >= _minNodesToDistances;
            _mniGenerateDistances.Enabled = _graph.Nodes.Count >= _minNodesToDistances;
            _mniClearDistances.Enabled = !_distances.IsNullOrEmpty();
            _mniClearNodes.Enabled = !_graph.Nodes.IsNullOrEmpty();
            _mniClearGAResult.Enabled = _result != null;
            _mniExportTspToGraph.Enabled = _graph.Nodes.Count >= _minNodesToGraph;
        }

        private void SetDataTables()
        {
            var dtNodes = new DataTable();
            dtNodes.Columns.Add("Id", typeof(string));
            dtNodes.Columns.Add("Name", typeof(string));
            _dgvNodes.DataSource = dtNodes;

            var dtEdges = new DataTable();
            dtEdges.Columns.Add("From", typeof(string));
            dtEdges.Columns.Add("To", typeof(string));
            dtEdges.Columns.Add("Distance", typeof(double));
            _dgvEdges.DataSource = dtEdges;

            var dtCoordinates = new DataTable();
            dtCoordinates.Columns.Add("Node", typeof(string));
            dtCoordinates.Columns.Add("X", typeof(int));
            dtCoordinates.Columns.Add("Y", typeof(int));
            _dgvCoordinates.DataSource = dtCoordinates;

            _dgvDistances.DataSource = new DataTable();

            var dtSummary = new DataTable();
            dtSummary.Columns.Add("Data", typeof(string));
            dtSummary.Columns.Add("Values", typeof(string));
            _dgvSummary.DataSource = dtSummary;

            var dtResults = new DataTable();
            dtResults.Columns.Add("No.", typeof(int));
            dtResults.Columns.Add("Best Tour", typeof(string));
            dtResults.Columns.Add("Best Fitness", typeof(double));
            dtResults.Columns.Add("Last Generation", typeof(int));
            dtResults.Columns.Add("Has Converged", typeof(string));
            dtResults.Columns.Add("Last Convergence (%)", typeof(double));
            dtResults.Columns.Add("Duration (ms)", typeof(long));
            _dgvResults.DataSource = dtResults;

            var dtPopulations = new DataTable();
            dtPopulations.Columns.Add("No.", typeof(int));
            dtPopulations.Columns.Add("First Tour", typeof(string));
            dtPopulations.Columns.Add("First Fitness", typeof(double));
            dtPopulations.Columns.Add("Last Tour", typeof(string));
            dtPopulations.Columns.Add("Last Fitness", typeof(double));
            _dgvPopulations.DataSource = dtPopulations;

            var dtFitnesses = new DataTable();
            dtFitnesses.Columns.Add("Generation", typeof(int));
            dtFitnesses.Columns.Add("Avg. Fit.", typeof(double));
            dtFitnesses.Columns.Add("Best Fit.", typeof(double));
            dtFitnesses.Columns.Add("Convergence (%)", typeof(double));
            _dgvFitnesses.DataSource = dtFitnesses;

            SetColumnWidth(_dgvEdges, _edgesViewMinWidth);
            SetColumnWidth(_dgvNodes, _nodesViewMinWidth);
            SetColumnWidth(_dgvCoordinates, _coordinatesViewMinWidth);
        }

        private void SetColumnWidth(DataGridView dgv, int width)
        {
            for (var i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].MinimumWidth = width;
            }
        }

        private void ClearData()
        {
            ((DataTable)_dgvNodes.DataSource).Rows.Clear();
            ((DataTable)_dgvEdges.DataSource).Rows.Clear();
            ((DataTable)_dgvCoordinates.DataSource).Rows.Clear();
            ((DataTable)_dgvDistances.DataSource).Rows.Clear();
            ClearSetup();
            ClearResult();

            _project = null;
            _fileTitle = null;
            _fullFileName = null;
            _distances = null;
            _edges = null;
        }

        private void ClearSetup()
        {
            _frmGASetup.ClearGASetup();

            _setup = null;
        }

        private void ClearResult()
        {
            ((DataTable)_dgvSummary.DataSource).Rows.Clear();
            ((DataTable)_dgvPopulations.DataSource).Rows.Clear();
            _dgvSummary.Visible = false;
            _dgvResults.Visible = false;
            _dgvPopulations.Visible = false;
            _dgvFitnesses.Visible = false;

            _shortestPath = null;
            _result = null;
        }

        private void UpdateApp()
        {
            UpdateLabels();
            EnableOrDisableMenuItems();
            UpdateCanvas();
        }

        private void UpdateLabels()
        {
            // update node count label
            if (_graph.Nodes.IsNullOrEmpty())
            {
                _lblNodesCount.Text = "0 node(s)";
            }
            else if (_graph.Nodes.Count > 0)
            {
                _lblNodesCount.Text = $"{_graph.Nodes.Count} node(s)";
            }

            if (_edges.IsNullOrEmpty())
            {
                _lblEdgesCount.Text = "0 edge(s)";
            }
            else if (_edges.Length > 0)
            {
                _lblEdgesCount.Text = $"{_edges.Length} edge(s)";
            }
        }

        #region Nodes
        private int GetNodeId()
        {
            return (_graph.Nodes.Count > 0) ? _graph.Nodes.Max(n => n.Id) + 1 : 1;
        }

        private void AddNode(Node node)
        {
            // check any node has same coordinates and where distance between both is 0
            if (Helper.HasSameCoordinates(_graph.Nodes, node.Coord))
            {
                PrintTo("The node has the same coordinate as another node.", true);
                return;
            }

            _graph.Nodes.Add(node);

            ((DataTable)_dgvNodes.DataSource).Rows.Add(node.Id, node.Name);
            ((DataTable)_dgvCoordinates.DataSource).Rows.Add(node.Name, node.Coord.X, node.Coord.Y);

            UpdateApp();
        }

        private void RemoveNode(Node node)
        {
            var index = _graph.Nodes.IndexOf(node);
            _graph.Nodes.Remove(node);

            ((DataTable)_dgvNodes.DataSource).Rows.RemoveAt(index);
            ((DataTable)_dgvCoordinates.DataSource).Rows.RemoveAt(index);
            // remove shortest path only if a node from the path is removed
            if (!_shortestPath.IsNullOrEmpty() && _shortestPath.Contains(node))
            {
                _shortestPath = null;
            }

            UpdateApp();
        }

        private void ClearNodes()
        {
            for (var i = _graph.Nodes.Count - 1; i > -1; i--)
            {
                RemoveNode(_graph.Nodes[i]);
            }
        }

        private (bool Valid, string Message) AreNodesValid(List<Node> nodes)
        {
            // check for empty list
            if (nodes == null)
            {
                return (false, "File does not contain a list for nodes. Create a list to add nodes.");
            }

            // check for duplicate ids
            if (Helper.HasDuplicateId(nodes))
            {
                return (false, "Some nodes contain duplicate IDs. Change the IDs for thoese nodes");
            }

            // check for dupblicate names
            if (Helper.HasDuplicateName(nodes))
            {
                return (false, "Some nodes contain duplicate names. Change the names for thoese nodes");

            }

            for (var i = 0; i < nodes.Count; i++)
            {
                // check for blank name for node
                if (nodes[i].Name.IsNullOrEmpty())
                {
                    return (false, "A node has a blank name. Add a name for the node");
                }

                // check for nodes with coordinates with negative values
                if (nodes[i].Coord.X < 0 || nodes[i].Coord.Y < 0)
                {
                    return (false, "File contains a node with negative coordinates. Change the coordinates for this node.");
                }

                // check for missing coordinates
                if (nodes[i].Coord == null || nodes[i].Coord.IsEmpty)
                {
                    return (false, "A node has missing coordinates. Add coordinates to the node.");
                }
            }

            // check for nodes with smae coordinates
            for (var i = 0; i < nodes.Count - 1; i++)
            {
                for (var j = i + 1; j < nodes.Count; j++)
                {
                    if (Util.GetDistance(nodes[i].Coord, nodes[j].Coord, _decimalsToRound) == 0)
                    {
                        return (false, "File contains a node with the same coordinates as another node. Change the coordinates for this node.");
                    }
                }
            }

            return (true, null);
        }
        #endregion

        #region Distances
        private void GenerateDistances()
        {
            ClearDistances();

            var res = GetDistances(_graph.Nodes);

            _distances = res.Distances;
            _edges = res.Edges;

            DisplayDistances();

            UpdateApp();
        }

        private (double[][] Distances, Edge<Node>[] Edges) GetDistances(List<Node> nodes)
        {
            var distances = new double[nodes.Count][];
            var edges = new List<Edge<Node>>();

            for (var before = 0; before < nodes.Count - 1; before++)
            {
                for (var next = before + 1; next < nodes.Count; next++)
                {
                    var edge = new Edge<Node>(
                        nodes[before],
                        nodes[next],
                        Util.GetDistance(nodes[before].Coord, nodes[next].Coord, _decimalsToRound)
                    );
                    edges.Add(edge);
                }
            }

            for (var row = 0; row < nodes.Count; row++)
            {
                var distance = new double[nodes.Count];
                for (var column = 0; column < nodes.Count; column++)
                {
                    distance[column] = (row != column) ? Util.GetDistance(nodes[row].Coord, nodes[column].Coord, _decimalsToRound) : 0;
                }
                distances[row] = distance;
            }

            return (distances, edges.ToArray());
        }

        private void ClearDistances()
        {
            ((DataTable)_dgvEdges.DataSource).Rows.Clear();
            _dgvDistances.DataSource = new DataTable();

            _distances = null;
            _edges = null;

            UpdateApp();
        }
        #endregion

        #region GA
        private void SolveGA(GASetup setup)
        {
            ClearResult();

            var started = DateTime.Now;
            var swTotal = new Stopwatch();

            swTotal.Start();
            GenerateDistances();
            setup.GenotypeSize = _graph.Nodes.Count + 1;

            GAResult res;
            if (setup.Multiple)
            {
                res = new GA().SolveMultiple(setup, _distances, _verbose.Enabled);
            }
            else
            {
                res = new GA().SolveMeasured(setup, _distances, _verbose);
            }
            swTotal.Stop();
            var finished = DateTime.Now;

            _setup = setup;
            _result = res;
            _shortestPath = Helper.MapToPath(_graph.Nodes, _result.Best.Values);

            if (setup.Multiple)
            {
                DisplaySummaryMultiple(started, finished, swTotal.ElapsedMilliseconds);
                DisplayResults();
            }
            else
            {
                DisplaySummary(started, finished, swTotal.ElapsedMilliseconds);
                DisplayPopulation();
                DisplayFitnesses();
            }

            UpdateApp();
        }
        #endregion

        private void DisplayNodes()
        {
            // display nodes and coordinates to view
            var dtNodes = (DataTable)_dgvNodes.DataSource;
            var dtCoordinates = (DataTable)_dgvCoordinates.DataSource;

            foreach (var node in _graph.Nodes)
            {
                dtNodes.Rows.Add(node.Id, node.Name);
                dtCoordinates.Rows.Add(node.Name, node.Coord.X, node.Coord.Y);
            }
        }

        private void DisplayDistances()
        {
            // display distances and edges to view
            var dtDistances = (DataTable)_dgvDistances.DataSource;
            var headers = _graph.Nodes.Select(x => x.Name).ToArray();

            // create columns for distances view
            for (var i = 0; i < headers.Length; i++)
            {
                dtDistances.Columns.Add(headers[i], typeof(double));
                _dgvDistances.Columns[i].MinimumWidth = _distancesViewMinWidth;
                _dgvDistances.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (var row in _distances)
            {
                var dr = dtDistances.NewRow();
                for (var i = 0; i < row.Length; i++)
                {
                    dr[i] = row[i];
                }
                dtDistances.Rows.Add(dr);
            }

            var dtEdges = (DataTable)_dgvEdges.DataSource;

            foreach (var edge in _edges)
            {
                dtEdges.Rows.Add(edge.Before.Name, edge.Next.Name, edge.Distance);
            }
        }

        private void DisplaySetup()
        {
            _frmGASetup.SetGASetup(_setup);
        }

        private void DisplaySummary(DateTime started, DateTime finished, long totalDuration)
        {
            var dtSummary = (DataTable)_dgvSummary.DataSource;

            dtSummary.Rows.Add("Setup", _setup.Name);
            dtSummary.Rows.Add("Started", started.ToString("yyyy-mm-dd HH:mm:ss"));
            dtSummary.Rows.Add("Finished", finished.ToString("yyyy-mm-dd HH:mm:ss"));
            dtSummary.Rows.Add("Best Tour", string.Join(", ", _shortestPath.Select(n => n.Name).ToArray()));
            dtSummary.Rows.Add("Best Fitness", Math.Round(_result.Best.Fitness, _decimalsToRound));
            dtSummary.Rows.Add("Last Generation", _result.LastGeneration);
            dtSummary.Rows.Add("Has Converged", (_result.HasConverged) ? "Yes" : "No");
            dtSummary.Rows.Add("Last Convergence (%)", Math.Round(_result.LastConvergence, _decimalsToRound));
            dtSummary.Rows.Add("GA Duration (ms)", _result.Duration);
            dtSummary.Rows.Add("Total Duration (ms)", totalDuration);

            _dgvSummary.Visible = true;
        }

        private void DisplayResults()
        {
            var dtResults = (DataTable)_dgvResults.DataSource;
            for (var i = 0; i < _result.Results.Count; i++)
            {
                var number = _result.Results[i].Number;
                var bestTour = string.Join(", ", Helper.MapToPath(_graph.Nodes, _result.Results[i].Best.Values).Select(n => n.Name));
                var bestFitness = Math.Round(_result.Results[i].Best.Fitness, _decimalsToRound);
                var lastGeneration = _result.Results[i].LastGeneration;
                var hasConverged = (_result.Results[i].HasConverged) ? "Yes" : "No";
                var lastConvergence = _result.Results[i].LastConvergence;
                var duration = _result.Results[i].Duration;
                dtResults.Rows.Add(number, bestTour, bestFitness, lastGeneration, hasConverged, lastConvergence, duration);
            }

            _dgvResults.Visible = true;
        }

        private void DisplaySummaryMultiple(DateTime started, DateTime finished, long totalDuration)
        {
            var dtSummary = (DataTable)_dgvSummary.DataSource;

            dtSummary.Rows.Add("Setup", _setup.Name);
            dtSummary.Rows.Add("Started", started.ToString("yyyy-mm-dd HH:mm:ss"));
            dtSummary.Rows.Add("Finished", finished.ToString("yyyy-mm-dd HH:mm:ss"));
            dtSummary.Rows.Add("Results", _result.Results.Count);
            dtSummary.Rows.Add("Result with Best Fitness", _result.Number);
            dtSummary.Rows.Add("Best Tour", string.Join(", ", _shortestPath.Select(n => n.Name).ToArray()));
            dtSummary.Rows.Add("Best Fitness", Math.Round(_result.Best.Fitness, _decimalsToRound));
            dtSummary.Rows.Add("Average Best Fitness", Math.Round(_result.BestFitnesses[0], _decimalsToRound));
            dtSummary.Rows.Add("GA Duration (ms)", _result.Duration);
            dtSummary.Rows.Add("Total Duration (ms)", totalDuration);

            _dgvSummary.Visible = true;
        }

        private void DisplayPopulation()
        {
            var dtPopulations = (DataTable)_dgvPopulations.DataSource;
            for (var i = 0; i < _result.LastGeneration; i++)
            {
                var firstTour = string.Join(", ", _result.InitialPopulation[i].Values);
                var firstFit = Math.Round(_result.InitialPopulation[i].Fitness, _decimalsToRound);
                var lastTour = string.Join(", ", _result.LastPopulation[i].Values);
                var lastFit = Math.Round(_result.LastPopulation[i].Fitness, _decimalsToRound);
                dtPopulations.Rows.Add(i, firstTour, firstFit, lastTour, lastFit);
            }

            _dgvPopulations.Visible = true;
        }

        private void DisplayFitnesses()
        {
            var dtFitnesses = (DataTable)_dgvFitnesses.DataSource;
            for (var i = 0; i < _result.LastGeneration; i++)
            {
                var generation = i;
                var avgFit = Math.Round(_result.AverageFitnesses[i], _decimalsToRound);
                var bestFit = Math.Round(_result.BestFitnesses[i], _decimalsToRound);
                var convergence = Math.Round(_result.Convergences[i], _decimalsToRound);
                dtFitnesses.Rows.Add(generation, avgFit, bestFit, convergence);
            }

            _dgvFitnesses.Visible = true;
        }

        private void PrintTo(string message, bool? debug = false)
        {
            MessageBox.Show(message, _programTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Debug.WriteLine(message);
        }

        #region Canvas
        private void UpdateCanvas()
        {
            SetMinimumSizeCanvas();
            _canOverwriteDraw = true;
            _pbxCanvas.Invalidate();
        }

        private void SetMinimumSizeCanvas()
        {
            if (!_graph.Nodes.IsNullOrEmpty())
            {
                // check for the furthest node coordinates to extend the canvas panel to a proper size
                var maxX = _graph.Nodes.Select(n => n.Coord.X + Helper.MeasureString(n.Name, _canvas.NodeFont).ToSize().Width).Max();
                var maxY = _graph.Nodes.Select(n => n.Coord.Y).Max();

                _pnlCanvas.AutoScrollMinSize = new Size(maxX + _canvasPadding, maxY + _canvasPadding);
            }
            else
            {
                _pnlCanvas.MinimumSize = new Size(0, 0);
            }
        }
        #endregion

        #region Drawing
        private void ClearCanvas(Graphics graphics)
        {
            if (_canOverwriteDraw)
            {
                graphics.Clear(_canvas.BackColor);
                _canOverwriteDraw = false;
            }
        }

        private void DrawNodes(Graphics graphics)
        {
            if (_graph == null || _graph.Nodes.IsNullOrEmpty())
            {
                return;
            }

            for (var i = 0; i < _graph.Nodes.Count; i++)
            {
                var p = _graph.Nodes[i].Coord;
                var header = _graph.Nodes[i].Name;

                if (i > 0)
                {
                    graphics.DrawEllipse(_pen, p.X, p.Y, _canvas.PointWidth, _canvas.PointHeight);
                    graphics.FillEllipse(_brush, p.X, p.Y, _canvas.PointWidth, _canvas.PointHeight);
                }
                else
                {
                    // draw the first point with another color
                    graphics.DrawEllipse(_firstPen, p.X, p.Y, _canvas.PointWidth, _canvas.PointHeight);
                    graphics.FillEllipse(_firstBrush, p.X, p.Y, _canvas.PointWidth, _canvas.PointHeight);
                }

                graphics.DrawString(header, _canvas.NodeFont, _nodeTextBrush, p);
            }
        }

        private void DrawShortestPath(Graphics graphics)
        {
            if (_shortestPath.IsNullOrEmpty())
            {
                return;
            }

            for (var i = 0; i < _shortestPath.Count - 1; i++)
            {
                // get points to and draw them
                var pBefore = _shortestPath[i].Coord;
                var pNext = _shortestPath[i + 1].Coord;

                graphics.DrawLine(_linePen, pBefore, pNext);
            }
        }

        private void DrawNodesForImage(Graphics graphics, Point start, int padding)
        {
            for (var i = 0; i < _graph.Nodes.Count; i++)
            {
                var coord = _graph.Nodes[i].Coord;
                var p = new Point(coord.X - start.X + padding, coord.Y - start.Y + padding);
                var header = _graph.Nodes[i].Name;

                if (i > 0)
                {
                    graphics.DrawEllipse(_pen, p.X, p.Y, _canvas.PointWidth, _canvas.PointHeight);
                    graphics.FillEllipse(_brush, p.X, p.Y, _canvas.PointWidth, _canvas.PointHeight);
                }
                else
                {
                    // draw the first point with another color
                    graphics.DrawEllipse(_firstPen, p.X, p.Y, _canvas.PointWidth, _canvas.PointHeight);
                    graphics.FillEllipse(_firstBrush, p.X, p.Y, _canvas.PointWidth, _canvas.PointHeight);
                }

                graphics.DrawString(header, _canvas.NodeFont, _nodeTextBrush, p);
            }
        }

        private void DrawShortestPathForImage(Graphics graphics, Point start, int padding)
        {
            if (_shortestPath.IsNullOrEmpty())
            {
                return;
            }

            for (var i = 0; i < _shortestPath.Count - 1; i++)
            {
                // get points to and draw them
                var coordBefore = _shortestPath[i].Coord;
                var coordNext = _shortestPath[i + 1].Coord;
                var pBefore = new Point(coordBefore.X - start.X + padding, coordBefore.Y - start.Y + padding);
                var pNext = new Point(coordNext.X - start.X + padding, coordNext.Y - start.Y + padding);

                graphics.DrawLine(_linePen, pBefore, pNext);
            }
        }
        #endregion
    }
}
