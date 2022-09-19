using Lib;
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
        private string _programTitle;
        private string _fileTitle;
        private string _lastLocation;

        private TspData _data;
        private double[][] _distances;
        private Edge<Node>[] _edges;
        private List<Node> _shortestPath;

        private int _distancesMinWidth;
        private int _edgesMinWidth;
        private int _nodesMinWidth;
        private int _coordinatesMinWidth;

        private bool _canOverwriteDraw;

        private int _canvasPadding;

        private int _decimalsToRound;

        private int _pointWidth;
        private int _pointHeight;
        private Color _nodeColor;
        private Color _firstNodeColor;
        private Color _nodeTextColor;
        private Font _nodeFont;
        private Color _lineColor;
        private Color _backColor;

        private Pen _pen;
        private SolidBrush _brush;
        private Pen _firstPen;
        private SolidBrush _firstBrush;
        private SolidBrush _nodeTextBrush;
        private Pen _linePen;

        private void SetConfiguration()
        {
            _decimalsToRound = 5;

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
                        var data = (TspData)JsonSerializer.Deserialize(inputData, typeof(TspData), options);

                        var valid = AreNodesValid(data.Nodes);
                        if (!valid.Valid)
                        {
                            PrintTo(valid.Message, true);
                            return;
                        }

                        var res = GetDistances(data.Nodes);

                        ClearData();

                        _data = data;
                        _distances = res.Distances;
                        _edges = res.Edges;

                        LoadNodes();
                        LoadDistances();

                        _fileTitle = fileName;
                        _lastLocation = fullFileName;
                        SetWindowTitle();
                        EnableOrDisableMenuItems();

                        UpdateCanvas();
                    }
                    catch (Exception ex) when (ex is IOException || ex is JsonException || ex is FormatException)
                    {
                        PrintTo(ex.Message, true);
                    }
                }
            }
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
                        var fullFileName = exportDialog.FileName;
                        var values = ConvertToCsv(_distances);
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
                        var maxX = _data.Nodes.Select(n => n.Coord.X + MeasureString(n.Name, _nodeFont).ToSize().Width).Max();
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

        public static SizeF MeasureString(string s, Font font)
        {
            SizeF result;

            using (var image = new Bitmap(1, 1))
            {
                using (var g = Graphics.FromImage(image))
                {
                    result = g.MeasureString(s, font);
                }
            }

            return result;
        }

        private string[] ConvertToCsv(double[][] matrix)
        {
            var n = matrix.Length;
            var s = new string[n];

            for (var i = 0; i < n; i++)
            {
                s[i] = $"{string.Join(",", matrix[i].Select(n => Math.Round(n, 3)).ToArray())}";
            }

            return s;
        }

        private void SetWindowTitle()
        {
            Text = $"{_fileTitle} - {_programTitle}";
        }

        private void LoadDataTables()
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

            SetColumnWidth(_dgvEdges, _edgesMinWidth);
            SetColumnWidth(_dgvNodes, _nodesMinWidth);
            SetColumnWidth(_dgvCoordinates, _coordinatesMinWidth);
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

            _data = null;
            _fileTitle = null;
            _distances = null;
            _edges = null;
        }

        private (bool Valid, string Message) AreNodesValid(List<Node> nodes)
        {
            if (nodes.IsNullOrEmpty())
            {
                return (false, "File does not contain any nodes. Add nodes to the file before opening.");
            }

            // check for nodes with smae coordinates
            for (var i = 0; i < nodes.Count - 1; i++)
            {
                if (nodes[i].Coord.X < 0 || nodes[i].Coord.Y < 0)
                {
                    return (false, "File contains a node with negative coordinates. Change the coordinates for this node.");
                }

                for (var j = i + 1; j < nodes.Count; j++)
                {
                    if (GetDistance(nodes[i].Coord, nodes[j].Coord, _decimalsToRound) == 0)
                    {
                        return (false, "File contains a node with the same coordinates as another node. Change the coordinates for this node.");
                    }
                }
            }

            return (true, null);
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
                        GetDistance(nodes[before].Coord, nodes[next].Coord, _decimalsToRound)
                    );
                    edges.Add(edge);
                }
            }

            for (var row = 0; row < nodes.Count; row++)
            {
                var distance = new double[nodes.Count];
                for (var column = 0; column < nodes.Count; column++)
                {
                    distance[column] = (row != column) ? GetDistance(nodes[row].Coord, nodes[column].Coord, _decimalsToRound) : 0;
                }
                distances[row] = distance;
            }

            return (distances, edges.ToArray());
        }

        private void LoadNodes()
        {
            var dtNodes = (DataTable)_dgvNodes.DataSource;
            var dtCoordinates = (DataTable)_dgvCoordinates.DataSource;

            if (_data.Nodes.Count > 0)
            {
                foreach (var node in _data.Nodes)
                {
                    dtNodes.Rows.Add(node.Id, node.Name);
                    dtCoordinates.Rows.Add(node.Name, node.Coord.X, node.Coord.Y);
                }

            }
        }

        private void LoadDistances()
        {
            var dtDistances = (DataTable)_dgvDistances.DataSource;
            var headers = _data.Nodes.Select(x => x.Name).ToArray();

            // create columns for distances view
            for (var i = 0; i < headers.Length; i++)
            {
                dtDistances.Columns.Add(headers[i], typeof(double));
                _dgvDistances.Columns[i].MinimumWidth = _distancesMinWidth;
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

        private double GetDistance(Point a, Point b, int decimals)
        {
            var res = Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
            var rounded = Math.Round(res, decimals);
            return rounded;
        }

        private void PrintTo(string message, bool? debug = false)
        {
            MessageBox.Show(message, _programTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Debug.WriteLine(message);
        }

        private void SetMinimumSizeCanvas()
        {
            if (!_data.Nodes.IsNullOrEmpty())
            {
                // check for the furthest node coordinates to extend the canvas panel to a proper size
                var maxX = _data.Nodes.Select(n => n.Coord.X + MeasureString(n.Name, _nodeFont).ToSize().Width).Max();
                var maxY = _data.Nodes.Select(n => n.Coord.Y).Max();

                _pnlCanvas.AutoScrollMinSize = new Size(maxX + _canvasPadding, maxY + _canvasPadding);
            }
            else
            {
                _pnlCanvas.MinimumSize = new Size(0, 0);
            }
        }

        private void UpdateCanvas()
        {
            SetMinimumSizeCanvas();
            _canOverwriteDraw = true;
            _pbxCanvas.Invalidate();
        }

        private void EnableOrDisableMenuItems()
        {
            var minNodesToSolveTsp = 4;
            var minNodesToDistances = 2;
            var minNodesToGraph = 1;

            _mniSolveTsp.Enabled = _data.Nodes.Count >= minNodesToSolveTsp;
            _mniExportTspToDistances.Enabled = _data.Nodes.Count >= minNodesToDistances;
            _mniExportTspToGraph.Enabled = _data.Nodes.Count >= minNodesToGraph;
        }

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
                var pBefore = _data.Nodes[i].Coord;
                var pNext = _data.Nodes[i + 1].Coord;

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
                var pBefore = new Point(coordBefore.X - start.X, coordBefore.Y - start.Y + padding);
                var pNext = new Point(coordNext.X - start.X, coordNext.Y - start.Y);

                graphics.DrawLine(_linePen, pBefore, pNext);
            }
        }
    }
}
