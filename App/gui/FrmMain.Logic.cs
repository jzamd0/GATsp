﻿using Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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

        private int _distancesMinWidth;
        private int _edgesMinWidth;
        private int _nodesMinWidth;

        private void NewProject()
        {
            ClearData();

            _data = new TspData();
            _fileTitle = "Untitled";
            SetWindowTitle();
        }

        private void OpenProject()
        {
            string filePath;
            string fileName;
            string inputData;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = _lastLocation;
                openFileDialog.Filter = "JSON (*.json)|*.json";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        filePath = openFileDialog.FileName;
                        fileName = openFileDialog.SafeFileName;
                        inputData = File.ReadAllText(filePath);

                        if (inputData.IsNullOrEmpty())
                        {
                            ClearData();

                            _lastLocation = filePath;
                            _fileTitle = fileName;
                            SetWindowTitle();

                            return;
                        }

                        // deserialize json to tsp data
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };
                        var data = (TspData)JsonSerializer.Deserialize(inputData, typeof(TspData), options);
                        var res = GetDistances(data.Nodes);

                        ClearData();

                        _data = data;
                        _distances = res.Distances;
                        _edges = res.Edges;

                        SetDistancesColumns(_data.Nodes.Select(x => x.Name).ToArray());

                        var dtDistances = (DataTable)_dgvDistances.DataSource;
                        foreach (var row in _distances)
                        {
                            var dr = dtDistances.NewRow();
                            for (var i = 0; i < row.Length; i++)
                            {
                                dr[i] = row[i];
                            }
                            dtDistances.Rows.Add(dr);
                        }

                        var dtNodes = (DataTable)_dgvNodes.DataSource;
                        foreach (var node in _data.Nodes)
                        {
                            dtNodes.Rows.Add(node.Id, node.Name);
                        }

                        var dtEdges = (DataTable)_dgvEdges.DataSource;
                        foreach (var edge in _edges)
                        {
                            dtEdges.Rows.Add(edge.Before.Name, edge.Next.Name, edge.Distance);
                        }

                        _lastLocation = filePath;
                        _fileTitle = fileName;
                        SetWindowTitle();
                    }
                    catch (Exception ex) when (ex is IOException)
                    {
                        PrintTo(ex.Message, true);
                    }
                }
            }
        }

        private void SetWindowTitle()
        {
            Text = $"{_fileTitle} - {_programTitle}";
        }

        private void SetDistancesColumns(string[] headers)
        {
            var dtDistances = (DataTable)_dgvDistances.DataSource;

            for (var i = 0; i < headers.Length; i++)
            {
                dtDistances.Columns.Add(headers[i]);
                _dgvDistances.Columns[i].MinimumWidth = _distancesMinWidth;
                _dgvDistances.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
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

            _dgvDistances.DataSource = new DataTable();

            SetColumnWidth(_dgvEdges, _edgesMinWidth);
            SetColumnWidth(_dgvNodes, _nodesMinWidth);
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
            _dgvDistances.DataSource = new DataTable();

            _data = null;
            _fileTitle = null;
            _distances = null;
            _edges = null;
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
                        GetDistance(nodes[before], nodes[next])
                    );
                    edges.Add(edge);
                }
            }

            for (var row = 0; row < nodes.Count; row++)
            {
                var distance = new double[nodes.Count];
                for (var column = 0; column < nodes.Count; column++)
                {
                    distance[column] = (row != column) ? GetDistance(nodes[row], nodes[column]) : 0;
                }
                distances[row] = distance;
            }

            return (distances, edges.ToArray());
        }

        private float GetDistance(Node a, Node b)
        {
            return (float)Math.Sqrt(Math.Pow(a.Coord.X - b.Coord.X, 2) + Math.Pow(a.Coord.Y - b.Coord.Y, 2));
        }

        private void PrintTo(string message, bool? debug = false)
        {
            MessageBox.Show(message);
            Debug.WriteLine(message);
        }
    }
}
