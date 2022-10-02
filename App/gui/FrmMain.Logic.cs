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

        private Graph _data { get; set; }
        private double[][] _distances { get; set; }
        private Edge<Node>[] _edges { get; set; }
        private List<Node> _shortestPath { get; set; }
        private GASetup _resultSetup { get; set; }
        private GAResult _result { get; set; }

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
        private int _decimalsToRound { get; set; }

        // canvas options
        private int _pointWidth { get; set; }
        private int _pointHeight { get; set; }
        private Color _nodeColor { get; set; }
        private Color _firstNodeColor { get; set; }
        private Color _nodeTextColor { get; set; }
        private Font _nodeFont { get; set; }
        private Color _lineColor { get; set; }
        private Color _backColor { get; set; }

        private Pen _pen { get; set; }
        private SolidBrush _brush { get; set; }
        private Pen _firstPen { get; set; }
        private SolidBrush _firstBrush { get; set; }
        private SolidBrush _nodeTextBrush { get; set; }
        private Pen _linePen { get; set; }

        private void SetConfiguration()
        {
            _decimalsToRound = 3;

            _pointWidth = 10;
            _pointHeight = 10;
            _nodeColor = Color.DodgerBlue;
            _firstNodeColor = Color.GreenYellow;
            _nodeTextColor = Color.Black;
            _nodeFont = new Font("Arial", 9);
            _lineColor = Color.Black;
            _backColor = Color.White;

            _pen = new Pen(_nodeColor);
            _brush = new SolidBrush(_nodeColor);
            _firstPen = new Pen(_firstNodeColor);
            _firstBrush = new SolidBrush(_firstNodeColor);
            _nodeTextBrush = new SolidBrush(_nodeTextColor);
            _linePen = new Pen(_lineColor);

            _pbxCanvas.BackColor = _backColor;
        }

        private void AddGASetupPanel()
        {
            _frmGASetup = new FrmGASetup();
            _frmGASetup.TopLevel = false;
            _tabSetup.Controls.Add(_frmGASetup);
            _frmGASetup.FormBorderStyle = FormBorderStyle.None;
            _frmGASetup.Dock = DockStyle.Top;
            _frmGASetup.Show();
        }

        #region File
        private void NewProject()
        {
            ClearData();

            _data = new Graph();
            _data.Nodes = new List<Node>();

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
                openDialog.Title = "Open JSON File";
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

                        // deserialize json to tsp data
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true,
                        };
                        var data = (Graph)JsonSerializer.Deserialize(inputData, typeof(Graph), options);

                        var valid = AreNodesValid(data.Nodes);
                        if (!valid.Valid)
                        {
                            PrintTo(valid.Message, true);
                            return;
                        }

                        ClearData();

                        _data = data;
                        if (_data.Nodes.Count > 0)
                        {
                            DisplayNodes();
                        }
                        if (_data.Nodes.Count >= _minNodesToDistances)
                        {
                            GenerateDistances();
                        }

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
                saveDialog.Title = "Save Graph As JSON";
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
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize(_data, typeof(Graph), options);
            File.WriteAllText(fullFileName, json);
        }

        private void ExportProjectToCSV()
        {
            using (var exportDialog = new SaveFileDialog())
            {
                exportDialog.InitialDirectory = _lastLocation;
                exportDialog.Title = "Export To CSV";
                exportDialog.Filter = "CSV (*.csv)|*.csv";
                exportDialog.DefaultExt = "csv";
                exportDialog.AddExtension = true;
                exportDialog.RestoreDirectory = true;

                if (exportDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var res = GetDistances(_data.Nodes);

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

        private void ExportProjectToImage()
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

                        var minX = _data.Nodes.Select(n => n.Coord.X).Min();
                        var minY = _data.Nodes.Select(n => n.Coord.Y).Min();
                        // get furthest x coordinate using the node coordinate with the text width added
                        var maxX = _data.Nodes.Select(n => n.Coord.X + Helper.MeasureString(n.Name, _nodeFont).ToSize().Width).Max();
                        var width = maxX + (_canvasPadding * 2) - minX;
                        var height = _data.Nodes.Select(n => n.Coord.Y).Max() + (_canvasPadding * 2) - minY;

                        var bmap = new Bitmap(width, height);
                        var g = Graphics.FromImage(bmap);

                        g.Clear(_backColor);
                        DrawNodesForImage(g, new Point(minX, minY), _canvasPadding);
                        DrawShortestPathForImage(g, new Point(minX, minY), _canvasPadding);

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
            _mniSolveTsp.Enabled = _data.Nodes.Count >= _minNodesToSolveTsp;
            _mniExportTspToDistances.Enabled = _data.Nodes.Count >= _minNodesToDistances;
            _mniGenerateDistances.Enabled = _data.Nodes.Count >= _minNodesToDistances;
            _mniClearDistances.Enabled = _data.Nodes.Count >= _minNodesToDistances;
            _mniClearNodes.Enabled = _data.Nodes.Count >= _minNodesToGraph;
            _mniExportTspToGraph.Enabled = _data.Nodes.Count >= _minNodesToGraph;
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
            _dgvSummary.DataSource = new DataTable();

            var dtInitialPopulation = new DataTable();
            dtInitialPopulation.Columns.Add("Path", typeof(string));
            dtInitialPopulation.Columns.Add("Fitness", typeof(double));
            _dgvInitialPopulation.DataSource = dtInitialPopulation;

            var dtLastPopulation = new DataTable();
            dtLastPopulation.Columns.Add("Path", typeof(string));
            dtLastPopulation.Columns.Add("Fitness", typeof(double));
            _dgvLastPopulation.DataSource = dtLastPopulation;

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
            _dgvDistances.DataSource = new DataTable();
            ClearResult();

            _data = null;
            _fileTitle = null;
            _fullFileName = null;
            _distances = null;
            _edges = null;
        }

        private void ClearResult()
        {
            _dgvSummary.DataSource = new DataTable();
            ((DataTable)_dgvInitialPopulation.DataSource).Rows.Clear();
            ((DataTable)_dgvLastPopulation.DataSource).Rows.Clear();

            _shortestPath = null;
            _resultSetup = null;
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
            if (_data.Nodes.IsNullOrEmpty())
            {
                _lblNodesCount.Text = "0 node(s)";
            }
            else if (_data.Nodes.Count > 0)
            {
                _lblNodesCount.Text = $"{_data.Nodes.Count} node(s)";
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
            return (_data.Nodes.Count > 0) ? _data.Nodes.Max(n => n.Id) + 1 : 1;
        }

        private void AddNode(Node node)
        {
            // check any node has same coordinates and where distance between both is 0
            if (Helper.HasSameCoordinates(_data.Nodes, node.Coord))
            {
                PrintTo("The node has the same coordinate as another node.", true);
                return;
            }

            _data.Nodes.Add(node);

            ((DataTable)_dgvNodes.DataSource).Rows.Add(node.Id, node.Name);
            ((DataTable)_dgvCoordinates.DataSource).Rows.Add(node.Name, node.Coord.X, node.Coord.Y);

            UpdateApp();
        }

        private void RemoveNode(Node node)
        {
            var index = _data.Nodes.IndexOf(node);
            _data.Nodes.Remove(node);

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
            for (var i = _data.Nodes.Count - 1; i > -1; i--)
            {
                RemoveNode(_data.Nodes[i]);
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

            var res = GetDistances(_data.Nodes);

            _distances = res.Distances;
            _edges = res.Edges;

            DisplayDistances();

            UpdateLabels();
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

            UpdateLabels();
        }
        #endregion

        #region TSP
        private void SolveTsp(GASetup setup)
        {
            ClearResult();

            var started = DateTime.Now;
            var swTotal = new Stopwatch();
            var swGA = new Stopwatch();

            swTotal.Start();
            GenerateDistances();
            setup.Distances = _distances;
            setup.GenotypeSize = _data.Nodes.Count + 1;

            swGA.Start();
            var res = new GA().Solve(setup, false);
            swGA.Stop();

            var shortestPath = Helper.MapToPath(_data.Nodes, res.Best.Values);
            swTotal.Stop();
            var finished = DateTime.Now;

            _shortestPath = shortestPath;
            _resultSetup = setup;
            _result = res;

            DisplaySummary(res, shortestPath, setup.GenotypeSize, started, finished, swGA.ElapsedMilliseconds, swTotal.ElapsedMilliseconds);
            DisplayPopulation();

            UpdateApp();

        }
        #endregion

        private void DisplayNodes()
        {
            // display nodes and coordinates to view
            var dtNodes = (DataTable)_dgvNodes.DataSource;
            var dtCoordinates = (DataTable)_dgvCoordinates.DataSource;

            foreach (var node in _data.Nodes)
            {
                dtNodes.Rows.Add(node.Id, node.Name);
                dtCoordinates.Rows.Add(node.Name, node.Coord.X, node.Coord.Y);
            }
        }

        private void DisplayDistances()
        {
            // display distances and edges to view
            var dtDistances = (DataTable)_dgvDistances.DataSource;
            var headers = _data.Nodes.Select(x => x.Name).ToArray();

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

        private void DisplaySummary(GAResult res, List<Node> shortestPath, int genotypeSize, DateTime started, DateTime finished, long gaDuration, long totalDuration)
        {
            var dtSummary = (DataTable)_dgvSummary.DataSource;
            dtSummary.Columns.Add("Data", typeof(string));
            dtSummary.Columns.Add("Values", typeof(string));
            _dgvSummary.DataSource = dtSummary;

            dtSummary.Rows.Add("Started", started.ToString("yyyy-mm-dd HH:mm:ss"));
            dtSummary.Rows.Add("Finished", finished.ToString("yyyy-mm-dd HH:mm:ss"));
            dtSummary.Rows.Add("Genotype Size", genotypeSize);
            dtSummary.Rows.Add("Best Tour", string.Join(", ", shortestPath.Select(n => n.Name).ToArray()));
            dtSummary.Rows.Add("Best Fitness", Math.Round(res.Best.Fitness, _decimalsToRound));
            dtSummary.Rows.Add("Last Generation", res.LastGeneration);
            dtSummary.Rows.Add("Has Converged", (res.HasConverged) ? "Yes" : "No");
            dtSummary.Rows.Add("Last Convergence (%)", Math.Round(res.LastConvergence, _decimalsToRound));
            dtSummary.Rows.Add("GA Duration (ms)", gaDuration);
            dtSummary.Rows.Add("Total Duration (ms)", totalDuration);
        }

        private void DisplayPopulation()
        {
            var dtInitialPopulation = (DataTable)_dgvInitialPopulation.DataSource;
            foreach (var ind in _result.InitialPopulation)
            {
                dtInitialPopulation.Rows.Add(string.Join(", ", Helper.MapToPath(_data.Nodes, ind.Values).Select(n => n.Name)), Math.Round(ind.Fitness, _decimalsToRound));
            }

            var dtLastPopulation = (DataTable)_dgvLastPopulation.DataSource;
            foreach (var ind in _result.LastPopulation)
            {
                dtLastPopulation.Rows.Add(string.Join(", ", Helper.MapToPath(_data.Nodes, ind.Values).Select(n => n.Name)), Math.Round(ind.Fitness, _decimalsToRound));
            }
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
            if (!_data.Nodes.IsNullOrEmpty())
            {
                // check for the furthest node coordinates to extend the canvas panel to a proper size
                var maxX = _data.Nodes.Select(n => n.Coord.X + Helper.MeasureString(n.Name, _nodeFont).ToSize().Width).Max();
                var maxY = _data.Nodes.Select(n => n.Coord.Y).Max();

                _pnlCanvas.AutoScrollMinSize = new Size(maxX + _canvasPadding, maxY + _canvasPadding);
            }
            else
            {
                _pnlCanvas.MinimumSize = new Size(0, 0);
            }
        }
        #endregion

        #region Drawing
        private void DrawNodes(Graphics graphics)
        {
            if (_data == null || _data.Nodes.IsNullOrEmpty())
            {
                return;
            }

            if (_canOverwriteDraw)
            {
                graphics.Clear(_backColor);
                _canOverwriteDraw = false;
            }

            for (var i = 0; i < _data.Nodes.Count; i++)
            {
                var p = _data.Nodes[i].Coord;
                var header = _data.Nodes[i].Name;

                if (i > 0)
                {
                    graphics.DrawEllipse(_pen, p.X, p.Y, _pointWidth, _pointHeight);
                    graphics.FillEllipse(_brush, p.X, p.Y, _pointWidth, _pointHeight);
                }
                else
                {
                    // draw the first point with another color
                    graphics.DrawEllipse(_firstPen, p.X, p.Y, _pointWidth, _pointHeight);
                    graphics.FillEllipse(_firstBrush, p.X, p.Y, _pointWidth, _pointHeight);
                }

                graphics.DrawString(header, _nodeFont, _nodeTextBrush, p);
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
            for (var i = 0; i < _data.Nodes.Count; i++)
            {
                var coord = _data.Nodes[i].Coord;
                var p = new Point(coord.X - start.X + padding, coord.Y - start.Y + padding);
                var header = _data.Nodes[i].Name;

                if (i > 0)
                {
                    graphics.DrawEllipse(_pen, p.X, p.Y, _pointWidth, _pointHeight);
                    graphics.FillEllipse(_brush, p.X, p.Y, _pointWidth, _pointHeight);
                }
                else
                {
                    // draw the first point with another color
                    graphics.DrawEllipse(_firstPen, p.X, p.Y, _pointWidth, _pointHeight);
                    graphics.FillEllipse(_firstBrush, p.X, p.Y, _pointWidth, _pointHeight);
                }

                graphics.DrawString(header, _nodeFont, _nodeTextBrush, p);
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
