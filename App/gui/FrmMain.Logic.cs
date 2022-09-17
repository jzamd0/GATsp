using Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace App.Gui
{
    public partial class FrmMain
    {
        private bool _isFirstTime;

        private string _programTitle;
        private string _fileTitle;
        private string _lastLocation;

        private List<List<double>> _distances;
        private List<Point> _points;
        private List<string> _headers;
        private List<Edge<string>> _edges;

        private int _distancesMinWidth;
        private int _edgesMinWidth;

        private void NewProject()
        {
            RunFirstTime();
            ClearProgram();

            SetWindowTitle("Untitled");
        }

        private void OpenProject()
        {
            string filePath;
            string[][] inputData;

            List<List<double>> distances;
            List<string> headers;
            List<Edge<string>> edges;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = _lastLocation;
                openFileDialog.Filter = "CSV (*.csv)|*.csv";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filePath = openFileDialog.FileName;
                        inputData = File.ReadLines(filePath).Select(x => x.Split(',')).ToArray();

                        if (inputData.IsNullOrEmpty())
                        {
                            Debug.WriteLine("File is empty");
                            RunFirstTime();
                            ClearProgram();

                            _lastLocation = filePath;
                            SetWindowTitle(openFileDialog.SafeFileName);

                            return;
                        }
                        if (!inputData.HasEqualSize())
                        {
                            Debug.WriteLine("Matrix doesn't have equal size");

                            return;
                        }

                        distances = GetMatrix(inputData);

                        if (!IsMatrixValid(distances))
                        {
                            Debug.WriteLine("Matrix has negative values");

                            return;
                        }

                        headers = GetHeaders(distances);
                        edges = GetEdges(distances, headers);

                        RunFirstTime();
                        ClearProgram();

                        _lastLocation = filePath;
                        _distances = distances;
                        _headers = headers;
                        _edges = edges;

                        ShowDistances(_headers);

                        var dtDistances = (DataTable)_dgvDistances.DataSource;
                        foreach (var row in _distances)
                        {
                            var dr = dtDistances.NewRow();
                            for (var i = 0; i < row.Count; i++)
                            {
                                dr[i] = row[i];
                            }
                            dtDistances.Rows.Add(dr);
                        }

                        var dtNodes = (DataTable)_dgvNodes.DataSource;
                        foreach (var header in _headers)
                        {
                            dtNodes.Rows.Add(header);
                        }

                        var dtEdges = (DataTable)_dgvEdges.DataSource;
                        foreach (var edge in _edges)
                        {
                            dtEdges.Rows.Add(edge.Before, edge.Next, edge.Distance);
                        }

                        _lastLocation = filePath;
                        SetWindowTitle(openFileDialog.SafeFileName);
                    }
                    catch (Exception ex) when (ex is IOException || ex is FormatException || ex is IndexOutOfRangeException)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                }
            }
        }

        private void SetWindowTitle(string fileName)
        {
            _fileTitle = fileName;
            Text = $"{_fileTitle} - {_programTitle}";
        }

        private void RunFirstTime()
        {
            if (_isFirstTime)
            {
                LoadFirstTime();
                ShowFirstTime();

                _isFirstTime = false;
            }
        }

        private void LoadFirstTime()
        {
            // enable elements for the first time creating or opening a project
            _splitMain.Visible = true;

            _menuView.Enabled = true;
            _mniViewSetup.Checked = true;
            _menuTsp.Enabled = true;

            _mniSaveTsp.Enabled = true;
            _mniSaveTspAs.Enabled = true;
        }

        private void ShowDistances(List<string> headers)
        {
            var dtDistances = (DataTable)_dgvDistances.DataSource;

            for (var i = 0; i < headers.Count; i++)
            {
                dtDistances.Columns.Add(headers[i]);
                _dgvDistances.Columns[i].MinimumWidth = _distancesMinWidth;
                _dgvDistances.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void ShowFirstTime()
        {
            var dtNodes = new DataTable();
            dtNodes.Columns.Add("Node", typeof(string));
            _dgvNodes.DataSource = dtNodes;

            var dtEdges = new DataTable();
            dtEdges.Columns.Add("From", typeof(string));
            dtEdges.Columns.Add("To", typeof(string));
            dtEdges.Columns.Add("Distance", typeof(double));
            _dgvEdges.DataSource = dtEdges;

            _dgvDistances.DataSource = new DataTable();

            for (var i = 0; i < _dgvEdges.Columns.Count; i++)
            {
                _dgvEdges.Columns[i].MinimumWidth = _edgesMinWidth;
            }
        }

        private void ClearProgram()
        {
            ((DataTable)_dgvNodes.DataSource).Rows.Clear();
            ((DataTable)_dgvEdges.DataSource).Rows.Clear();
            _dgvDistances.DataSource = new DataTable();

            _headers.Clear();
            _edges.Clear();
            _distances.Clear();
        }

        private List<List<double>> GetMatrix(string[][] array)
        {
            var rowLength = array.Length;
            var columnLength = array[0].Length;
            var matrix = new List<List<double>>();

            for (var i = 0; i < rowLength; i++)
            {
                var row = new List<double>();
                for (var j = 0; j < columnLength; j++)
                {
                    row.Add(double.Parse(array[i][j]));
                }
                matrix.Add(row);
            }

            return matrix;
        }

        private List<string> GetHeaders<T>(IEnumerable<T> list)
        {
            var headers = new List<string>();

            for (var i = 0; i < list.Count(); i++)
            {
                headers.Add(i.ToString());
            }

            return headers;
        }

        private List<Edge<string>> GetEdges(List<List<double>> distances, List<string> headers)
        {
            var edges = new List<Edge<string>>();

            for (var start = 0; start < distances.Count - 1; start++)
            {
                for (var end = start + 1; end < distances[start].Count; end++)
                {
                    if (distances[start][end] > 0)
                    {
                        edges.Add(new Edge<string>(headers[start], headers[end], distances[start][end]));
                    }
                }
            }

            return edges;
        }

        private bool IsMatrixValid(List<List<double>> matrix)
        {
            return matrix.All(d => d.All(n => n >= 0));
        }
    }
}
