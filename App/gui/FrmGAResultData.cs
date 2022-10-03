using Lib.Genetics;
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace App.Gui
{
    public partial class FrmGAResultData : Form
    {
        private string _defaultFontName;
        private int _defaultFontSize;
        private Font _defaultFont;

        public FrmGAResultData()
        {
            InitializeComponent();

            _defaultFontName = "Trebuchet MS";
            _defaultFontSize = 9;
            _defaultFont = new Font(_defaultFontName, _defaultFontSize);
        }

        public void DisplayData(GAResult result, int decimalsToRound)
        {
            var FitnessesYAxes = new ICartesianAxis[]
            {
                new Axis
                {
                    TextSize = _defaultFontSize,
                },
                new Axis
                {
                    MinLimit = 0,
                    MaxLimit = 100,
                    Position = LiveChartsCore.Measure.AxisPosition.End,
                    TextSize = _defaultFontSize,
                    Labeler = x => $"{x} %",
                },
            };
            var fitnessesXAxes = new ICartesianAxis[]
            {
                new Axis
                {
                    TextSize = _defaultFontSize,
                }
            };

            _fitnessesChart.TooltipFont = _defaultFont;
            _fitnessesChart.LegendFont = _defaultFont;
            _fitnessesChart.YAxes = FitnessesYAxes;
            _fitnessesChart.XAxes = fitnessesXAxes;
            _fitnessesChart.Name = "Fitnesses";
            _fitnessesChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Bottom;
            _fitnessesChart.LegendOrientation = LiveChartsCore.Measure.LegendOrientation.Horizontal;

            _fitnessesChart.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = result.AverageFitnesses.Select(i => Math.Round(i, decimalsToRound)),
                    Name = "Average Fitness",
                    Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 1 },
                    LineSmoothness = 0,
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null,
                    ScalesYAt = 0,
                },
                new LineSeries<double>
                {
                    Values = result.BestFitnesses.Select(i => Math.Round(i, decimalsToRound)),
                    Name = "Best Fitness",
                    Stroke = new SolidColorPaint(SKColors.Red) { StrokeThickness = 1 },
                    LineSmoothness = 0,
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null,
                    ScalesYAt = 0,
                },
                new LineSeries<double>
                {
                    Values = result.Convergences.Select(i => Math.Round(i, decimalsToRound)),
                    Name = "Convergence",
                    Stroke = new SolidColorPaint(SKColors.Green) { StrokeThickness = 1 },
                    LineSmoothness = 0,
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null,
                    ScalesYAt = 1,
                },
            };

            var populationYAxes = new Axis[]
            {
                new Axis
                {
                    TextSize = _defaultFontSize,
                }
            };
            var populationXAxes = new Axis[]
            {
                new Axis
                {
                    TextSize = _defaultFontSize,
                }
            };

            _populationChart.TooltipFont = _defaultFont;
            _populationChart.LegendFont = _defaultFont;
            _populationChart.YAxes = populationYAxes;
            _populationChart.XAxes = populationXAxes;
            _populationChart.Name = "Population";
            _populationChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Bottom;
            _populationChart.LegendOrientation = LiveChartsCore.Measure.LegendOrientation.Horizontal;

            _populationChart.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = result.InitialPopulation.Select(i => Math.Round(i.Fitness, decimalsToRound)),
                    Name = "Initial Population",
                    Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 1 },
                    LineSmoothness = 0,
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null,
                    ScalesYAt = 0,
                },
                new LineSeries<double>
                {
                    Values = result.LastPopulation.Select(i => Math.Round(i.Fitness, decimalsToRound)),
                    Name = "Last Population",
                    Stroke = new SolidColorPaint(SKColors.Red) { StrokeThickness = 1 },
                    LineSmoothness = 0,
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null,
                    ScalesYAt = 0,
                },
            };

            _chxAverageFitnessVisible.Checked = GetSeries(_fitnessesChart, "Average Fitness").IsVisible;
            _chxBestFitnessVisible.Checked = GetSeries(_fitnessesChart, "Best Fitness").IsVisible;
            _chxConvergenceVisible.Checked = GetSeries(_fitnessesChart, "Convergence").IsVisible;
            _chxInitialPopulationVisible.Checked = GetSeries(_populationChart, "Initial Population").IsVisible;
            _chxLastPopulationVisible.Checked = GetSeries(_populationChart, "Last Population").IsVisible;
        }

        private void _chxAverageFitnessVisible_CheckedChanged(object sender, EventArgs e)
        {
            var visible = _chxAverageFitnessVisible.Checked;
            GetSeries(_fitnessesChart, "Average Fitness").IsVisible = visible;
        }

        private void _chxBestFitnessVisible_CheckedChanged(object sender, EventArgs e)
        {
            var visible = _chxBestFitnessVisible.Checked;
            GetSeries(_fitnessesChart, "Best Fitness").IsVisible = visible;
        }

        private void _chxConvergenceVisible_CheckedChanged(object sender, EventArgs e)
        {
            var visible = _chxConvergenceVisible.Checked;
            GetSeries(_fitnessesChart, "Convergence").IsVisible = visible;
        }

        private static ISeries GetSeries(LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chart, string name)
        {
            return chart.Series.Where(i => i.Name == name).First();
        }

        private void _chxInitialPopulationVisible_CheckedChanged(object sender, EventArgs e)
        {
            var visible = _chxInitialPopulationVisible.Checked;
            GetSeries(_populationChart, "Initial Population").IsVisible = visible;
        }

        private void _chxLastPopulationVisible_CheckedChanged(object sender, EventArgs e)
        {
            var visible = _chxLastPopulationVisible.Checked;
            GetSeries(_populationChart, "Last Population").IsVisible = visible;
        }
    }
}
