
namespace App.Gui
{
    partial class FrmGAResultData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tablePanelMain = new System.Windows.Forms.TableLayoutPanel();
            this._populationChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            this._pnlPopulation = new System.Windows.Forms.Panel();
            this._lblPopulation = new System.Windows.Forms.Label();
            this._fitnessesChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            this._pnlFitnesses = new System.Windows.Forms.Panel();
            this._lblFitnesses = new System.Windows.Forms.Label();
            this._flowPanelFitnessesVisible = new System.Windows.Forms.FlowLayoutPanel();
            this._chxAverageFitnessVisible = new System.Windows.Forms.CheckBox();
            this._chxBestFitnessVisible = new System.Windows.Forms.CheckBox();
            this._chxConvergenceVisible = new System.Windows.Forms.CheckBox();
            this._flowPanelPopulationVisible = new System.Windows.Forms.FlowLayoutPanel();
            this._chxInitialPopulationVisible = new System.Windows.Forms.CheckBox();
            this._chxLastPopulationVisible = new System.Windows.Forms.CheckBox();
            this._tablePanelMain.SuspendLayout();
            this._pnlPopulation.SuspendLayout();
            this._pnlFitnesses.SuspendLayout();
            this._flowPanelFitnessesVisible.SuspendLayout();
            this._flowPanelPopulationVisible.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tablePanelMain
            // 
            this._tablePanelMain.AutoSize = true;
            this._tablePanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._tablePanelMain.ColumnCount = 3;
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this._tablePanelMain.Controls.Add(this._populationChart, 1, 6);
            this._tablePanelMain.Controls.Add(this._pnlPopulation, 1, 5);
            this._tablePanelMain.Controls.Add(this._fitnessesChart, 1, 2);
            this._tablePanelMain.Controls.Add(this._pnlFitnesses, 1, 1);
            this._tablePanelMain.Controls.Add(this._flowPanelFitnessesVisible, 1, 3);
            this._tablePanelMain.Controls.Add(this._flowPanelPopulationVisible, 1, 7);
            this._tablePanelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this._tablePanelMain.Location = new System.Drawing.Point(0, 0);
            this._tablePanelMain.Margin = new System.Windows.Forms.Padding(0);
            this._tablePanelMain.Name = "_tablePanelMain";
            this._tablePanelMain.RowCount = 9;
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this._tablePanelMain.Size = new System.Drawing.Size(283, 760);
            this._tablePanelMain.TabIndex = 0;
            // 
            // _populationChart
            // 
            this._populationChart.Dock = System.Windows.Forms.DockStyle.Top;
            this._populationChart.Location = new System.Drawing.Point(15, 420);
            this._populationChart.Margin = new System.Windows.Forms.Padding(0);
            this._populationChart.Name = "_populationChart";
            this._populationChart.Size = new System.Drawing.Size(253, 300);
            this._populationChart.TabIndex = 3;
            // 
            // _pnlPopulation
            // 
            this._pnlPopulation.BackColor = System.Drawing.Color.LightGray;
            this._pnlPopulation.Controls.Add(this._lblPopulation);
            this._pnlPopulation.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlPopulation.Location = new System.Drawing.Point(15, 400);
            this._pnlPopulation.Margin = new System.Windows.Forms.Padding(0);
            this._pnlPopulation.Name = "_pnlPopulation";
            this._pnlPopulation.Size = new System.Drawing.Size(253, 20);
            this._pnlPopulation.TabIndex = 2;
            // 
            // _lblPopulation
            // 
            this._lblPopulation.AutoSize = true;
            this._lblPopulation.Dock = System.Windows.Forms.DockStyle.Left;
            this._lblPopulation.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._lblPopulation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this._lblPopulation.Location = new System.Drawing.Point(0, 0);
            this._lblPopulation.Name = "_lblPopulation";
            this._lblPopulation.Size = new System.Drawing.Size(66, 18);
            this._lblPopulation.TabIndex = 0;
            this._lblPopulation.Text = "Population";
            // 
            // _fitnessesChart
            // 
            this._fitnessesChart.Dock = System.Windows.Forms.DockStyle.Top;
            this._fitnessesChart.Location = new System.Drawing.Point(15, 35);
            this._fitnessesChart.Margin = new System.Windows.Forms.Padding(0);
            this._fitnessesChart.Name = "_fitnessesChart";
            this._fitnessesChart.Size = new System.Drawing.Size(253, 300);
            this._fitnessesChart.TabIndex = 1;
            // 
            // _pnlFitnesses
            // 
            this._pnlFitnesses.BackColor = System.Drawing.Color.LightGray;
            this._pnlFitnesses.Controls.Add(this._lblFitnesses);
            this._pnlFitnesses.Dock = System.Windows.Forms.DockStyle.Top;
            this._pnlFitnesses.Location = new System.Drawing.Point(15, 15);
            this._pnlFitnesses.Margin = new System.Windows.Forms.Padding(0);
            this._pnlFitnesses.Name = "_pnlFitnesses";
            this._pnlFitnesses.Size = new System.Drawing.Size(253, 20);
            this._pnlFitnesses.TabIndex = 1;
            // 
            // _lblFitnesses
            // 
            this._lblFitnesses.AutoSize = true;
            this._lblFitnesses.Dock = System.Windows.Forms.DockStyle.Left;
            this._lblFitnesses.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this._lblFitnesses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this._lblFitnesses.Location = new System.Drawing.Point(0, 0);
            this._lblFitnesses.Name = "_lblFitnesses";
            this._lblFitnesses.Size = new System.Drawing.Size(58, 18);
            this._lblFitnesses.TabIndex = 0;
            this._lblFitnesses.Text = "Fitnesses";
            // 
            // _flowPanelFitnessesVisible
            // 
            this._flowPanelFitnessesVisible.AutoSize = true;
            this._flowPanelFitnessesVisible.Controls.Add(this._chxAverageFitnessVisible);
            this._flowPanelFitnessesVisible.Controls.Add(this._chxBestFitnessVisible);
            this._flowPanelFitnessesVisible.Controls.Add(this._chxConvergenceVisible);
            this._flowPanelFitnessesVisible.Dock = System.Windows.Forms.DockStyle.Top;
            this._flowPanelFitnessesVisible.Location = new System.Drawing.Point(15, 335);
            this._flowPanelFitnessesVisible.Margin = new System.Windows.Forms.Padding(0);
            this._flowPanelFitnessesVisible.Name = "_flowPanelFitnessesVisible";
            this._flowPanelFitnessesVisible.Size = new System.Drawing.Size(253, 50);
            this._flowPanelFitnessesVisible.TabIndex = 5;
            // 
            // _chxAverageFitnessVisible
            // 
            this._chxAverageFitnessVisible.AutoSize = true;
            this._chxAverageFitnessVisible.Location = new System.Drawing.Point(3, 3);
            this._chxAverageFitnessVisible.Name = "_chxAverageFitnessVisible";
            this._chxAverageFitnessVisible.Size = new System.Drawing.Size(108, 19);
            this._chxAverageFitnessVisible.TabIndex = 0;
            this._chxAverageFitnessVisible.Text = "Average FItness";
            this._chxAverageFitnessVisible.UseVisualStyleBackColor = true;
            this._chxAverageFitnessVisible.CheckedChanged += new System.EventHandler(this._chxAverageFitnessVisible_CheckedChanged);
            // 
            // _chxBestFitnessVisible
            // 
            this._chxBestFitnessVisible.AutoSize = true;
            this._chxBestFitnessVisible.Location = new System.Drawing.Point(117, 3);
            this._chxBestFitnessVisible.Name = "_chxBestFitnessVisible";
            this._chxBestFitnessVisible.Size = new System.Drawing.Size(87, 19);
            this._chxBestFitnessVisible.TabIndex = 1;
            this._chxBestFitnessVisible.Text = "Best Fitness";
            this._chxBestFitnessVisible.UseVisualStyleBackColor = true;
            this._chxBestFitnessVisible.CheckedChanged += new System.EventHandler(this._chxBestFitnessVisible_CheckedChanged);
            // 
            // _chxConvergenceVisible
            // 
            this._chxConvergenceVisible.AutoSize = true;
            this._chxConvergenceVisible.Location = new System.Drawing.Point(3, 28);
            this._chxConvergenceVisible.Name = "_chxConvergenceVisible";
            this._chxConvergenceVisible.Size = new System.Drawing.Size(96, 19);
            this._chxConvergenceVisible.TabIndex = 2;
            this._chxConvergenceVisible.Text = "Convergence";
            this._chxConvergenceVisible.UseVisualStyleBackColor = true;
            this._chxConvergenceVisible.CheckedChanged += new System.EventHandler(this._chxConvergenceVisible_CheckedChanged);
            // 
            // _flowPanelPopulationVisible
            // 
            this._flowPanelPopulationVisible.AutoSize = true;
            this._flowPanelPopulationVisible.Controls.Add(this._chxInitialPopulationVisible);
            this._flowPanelPopulationVisible.Controls.Add(this._chxLastPopulationVisible);
            this._flowPanelPopulationVisible.Dock = System.Windows.Forms.DockStyle.Top;
            this._flowPanelPopulationVisible.Location = new System.Drawing.Point(15, 720);
            this._flowPanelPopulationVisible.Margin = new System.Windows.Forms.Padding(0);
            this._flowPanelPopulationVisible.Name = "_flowPanelPopulationVisible";
            this._flowPanelPopulationVisible.Size = new System.Drawing.Size(253, 25);
            this._flowPanelPopulationVisible.TabIndex = 6;
            // 
            // _chxInitialPopulationVisible
            // 
            this._chxInitialPopulationVisible.AutoSize = true;
            this._chxInitialPopulationVisible.Location = new System.Drawing.Point(3, 3);
            this._chxInitialPopulationVisible.Name = "_chxInitialPopulationVisible";
            this._chxInitialPopulationVisible.Size = new System.Drawing.Size(116, 19);
            this._chxInitialPopulationVisible.TabIndex = 0;
            this._chxInitialPopulationVisible.Text = "Initial Population";
            this._chxInitialPopulationVisible.UseVisualStyleBackColor = true;
            this._chxInitialPopulationVisible.CheckedChanged += new System.EventHandler(this._chxInitialPopulationVisible_CheckedChanged);
            // 
            // _chxLastPopulationVisible
            // 
            this._chxLastPopulationVisible.AutoSize = true;
            this._chxLastPopulationVisible.Location = new System.Drawing.Point(125, 3);
            this._chxLastPopulationVisible.Name = "_chxLastPopulationVisible";
            this._chxLastPopulationVisible.Size = new System.Drawing.Size(108, 19);
            this._chxLastPopulationVisible.TabIndex = 1;
            this._chxLastPopulationVisible.Text = "Last Population";
            this._chxLastPopulationVisible.UseVisualStyleBackColor = true;
            this._chxLastPopulationVisible.CheckedChanged += new System.EventHandler(this._chxLastPopulationVisible_CheckedChanged);
            // 
            // FrmGAResultData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this._tablePanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "FrmGAResultData";
            this._tablePanelMain.ResumeLayout(false);
            this._tablePanelMain.PerformLayout();
            this._pnlPopulation.ResumeLayout(false);
            this._pnlPopulation.PerformLayout();
            this._pnlFitnesses.ResumeLayout(false);
            this._pnlFitnesses.PerformLayout();
            this._flowPanelFitnessesVisible.ResumeLayout(false);
            this._flowPanelFitnessesVisible.PerformLayout();
            this._flowPanelPopulationVisible.ResumeLayout(false);
            this._flowPanelPopulationVisible.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tablePanelMain;
        private System.Windows.Forms.Panel _pnlFitnesses;
        private System.Windows.Forms.Label _lblFitnesses;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart _fitnessesChart;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart _populationChart;
        private System.Windows.Forms.Panel _pnlPopulation;
        private System.Windows.Forms.Label _lblPopulation;
        private System.Windows.Forms.CheckBox _chxLastPopulationVisible;
        private System.Windows.Forms.CheckBox _chxInitialPopulationVisible;
        private System.Windows.Forms.FlowLayoutPanel _flowPanelFitnessesVisible;
        private System.Windows.Forms.CheckBox _chxAverageFitnessVisible;
        private System.Windows.Forms.CheckBox _chxBestFitnessVisible;
        private System.Windows.Forms.CheckBox _chxConvergenceVisible;
        private System.Windows.Forms.FlowLayoutPanel _flowPanelPopulationVisible;
    }
}