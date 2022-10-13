using Lib;
using Lib.Tsp;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System.Collections.Generic;
using System.Linq;

namespace GASpreadsheets
{
    public class ExcelExporter
    {
        private TableStyles _defaultStyle = TableStyles.Medium2;

        static ExcelExporter()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public void SaveToSpreadsheet(string filename, ExcelData data)
        {
            var templatePath = @".\template\template.xlsx";

            using (var package = new ExcelPackage(templatePath))
            {
                var res = data.Result;
                var setup = data.Setup;
                var graph = data.Graph;

                var headers = graph.Nodes.Select(n => n.Name).ToArray();
                var mappedHeaders = Tsp.MapHeadersToPath(graph.Nodes, res.Best.Values);
                var initialFitnesses = res.InitialPopulation.Select(i => i.Fitness).ToList();
                var lastFitnesses = res.LastPopulation.Select(i => i.Fitness).ToList();

                var wb = package.Workbook;
                wb.Names["Title"].Value = $"Solution {data.Title}";
                //wb.Names["DateCreated"].Value = data.DateCreated;
                //wb.Names["DateFinished"].Value = data.DateFinished;

                wb.Names["BestTour"].Value = string.Join(", ", mappedHeaders);
                wb.Names["BestFitness"].Value = res.Best.Fitness;
                wb.Names["LastGeneration"].Value = res.LastGeneration;
                wb.Names["LastConvergence"].Value = res.LastConvergence;
                wb.Names["Duration"].Value = res.Duration;
                
                wb.Names["GraphName"].Value = graph.Name;
                wb.Names["Nodes"].Value = string.Join(", ", headers);
                wb.Names["NodesCount"].Value = graph.Nodes.Count;

                wb.Names["PopulationSize"].Value = setup.PopulationSize;
                wb.Names["GenotypeSize"].Value = setup.GenotypeSize;
                wb.Names["Generations"].Value = setup.Generations;
                wb.Names["CrossoverRate"].Value = setup.CrossoverRate;
                wb.Names["MutationRate"].Value = setup.MutationRate;
                wb.Names["ElitismRate"].Value = setup.ElitismRate;
                wb.Names["SelectionType"].Value = setup.SelectionType;
                wb.Names["CrossoverType"].Value = setup.CrossoverType;
                wb.Names["MutationType"].Value = setup.MutationType;

                AddDistances(wb.Worksheets["Distances"], headers, setup.Distances);
                AddData(wb.Worksheets["Data"], res.AverageFitnesses, res.BestFitnesses, res.Convergences, initialFitnesses, lastFitnesses);

                package.SaveAs(filename);
            }
        }

        private ExcelTable CreateTable(ExcelWorksheet ws, string name, int firstRow, int firstColumn, int rowRange, string[] headers, TableStyles style = TableStyles.None)
        {
            var range = ws.Cells[firstRow, firstColumn, firstRow + rowRange, firstColumn + headers.Length - 1];
            var table = ws.Tables.Add(range, name);
            table.TableStyle = style;

            // add headers to table
            for (var i = 0; i < headers.Length; i++)
            {
                table.Columns[i].Name = headers[i];
            }

            return table;
        }

        private void AddDistances(ExcelWorksheet ws, string[] headers, double[][] distances)
        {
            var row = 4;
            var dataRow = row + 1;
            var col = 2;
            var table = CreateTable(ws, "Distances", row, col, distances.Length, headers, _defaultStyle);

            // insert data to table
            for (var i = 0; i < distances.Length; i++)
            {
                for (var j = 0; j < distances.Length; j++)
                {
                    ws.Cells[dataRow + i, col + j].Value = distances[i][j];
                }
            }
        }

        private void AddData(ExcelWorksheet ws, List<double> averageFitnesses, List<double> bestFitnesses, List<double> convergences, List<double> initialFitnesses, List<double> lastFitnesses)
        {
            var fitTable = ws.Tables["Fitnesses"];
            var fitStart = ws.Tables["Fitnesses"].Address.Start;

            fitTable.InsertRow(0, averageFitnesses.Count - 1);

            for (var i = 0; i < averageFitnesses.Count; i++)
            {
                ws.Cells[fitStart.Row + 1 + i, fitStart.Column].Value = i;
                ws.Cells[fitStart.Row + 1 + i, fitStart.Column + 1].Value = averageFitnesses[i];
                ws.Cells[fitStart.Row + 1 + i, fitStart.Column + 2].Value = bestFitnesses[i];
                ws.Cells[fitStart.Row + 1 + i, fitStart.Column + 3].Value = convergences[i];
            }

            var popTable = ws.Tables["Population"];
            var popStart = ws.Tables["Population"].Address.Start;

            popTable.InsertRow(0, initialFitnesses.Count - 1);

            for (var i = 0; i < initialFitnesses.Count; i++)
            {
                ws.Cells[popStart.Row + 1 + i, popStart.Column].Value = i;
                ws.Cells[popStart.Row + 1 + i, popStart.Column + 1].Value = initialFitnesses[i];
                ws.Cells[popStart.Row + 1 + i, popStart.Column + 2].Value = lastFitnesses[i];
            }
        }
    }
}
