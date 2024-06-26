﻿
namespace App.Gui
{
    partial class FrmGASetup
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
            this._lblPopulationSize = new System.Windows.Forms.Label();
            this._lblGenerations = new System.Windows.Forms.Label();
            this._lblCrossoverRate = new System.Windows.Forms.Label();
            this._lblMutationRate = new System.Windows.Forms.Label();
            this._lblElitismRate = new System.Windows.Forms.Label();
            this._tbxPopulationSize = new System.Windows.Forms.TextBox();
            this._tbxGenerations = new System.Windows.Forms.TextBox();
            this._tbxCrossoverRate = new System.Windows.Forms.TextBox();
            this._tbxMutationRate = new System.Windows.Forms.TextBox();
            this._tbxElitismRate = new System.Windows.Forms.TextBox();
            this._lblCrossoverType = new System.Windows.Forms.Label();
            this._cbxCrossoverType = new System.Windows.Forms.ComboBox();
            this._lblMutationType = new System.Windows.Forms.Label();
            this._cbxMutationType = new System.Windows.Forms.ComboBox();
            this._lblSelectionType = new System.Windows.Forms.Label();
            this._cbxSelectionType = new System.Windows.Forms.ComboBox();
            this._lblName = new System.Windows.Forms.Label();
            this._tbxName = new System.Windows.Forms.TextBox();
            this._lblRunTimes = new System.Windows.Forms.Label();
            this._chxMultipleGA = new System.Windows.Forms.CheckBox();
            this._chxParallelGA = new System.Windows.Forms.CheckBox();
            this._tbxRunTimes = new System.Windows.Forms.TextBox();
            this._tablePanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tablePanelMain
            // 
            this._tablePanelMain.AutoSize = true;
            this._tablePanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._tablePanelMain.ColumnCount = 3;
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this._tablePanelMain.Controls.Add(this._lblPopulationSize, 1, 4);
            this._tablePanelMain.Controls.Add(this._lblGenerations, 1, 7);
            this._tablePanelMain.Controls.Add(this._lblCrossoverRate, 1, 10);
            this._tablePanelMain.Controls.Add(this._lblMutationRate, 1, 13);
            this._tablePanelMain.Controls.Add(this._lblElitismRate, 1, 16);
            this._tablePanelMain.Controls.Add(this._tbxPopulationSize, 1, 5);
            this._tablePanelMain.Controls.Add(this._tbxGenerations, 1, 8);
            this._tablePanelMain.Controls.Add(this._tbxCrossoverRate, 1, 11);
            this._tablePanelMain.Controls.Add(this._tbxMutationRate, 1, 14);
            this._tablePanelMain.Controls.Add(this._tbxElitismRate, 1, 17);
            this._tablePanelMain.Controls.Add(this._lblCrossoverType, 1, 22);
            this._tablePanelMain.Controls.Add(this._cbxCrossoverType, 1, 23);
            this._tablePanelMain.Controls.Add(this._lblMutationType, 1, 25);
            this._tablePanelMain.Controls.Add(this._cbxMutationType, 1, 26);
            this._tablePanelMain.Controls.Add(this._lblSelectionType, 1, 19);
            this._tablePanelMain.Controls.Add(this._cbxSelectionType, 1, 20);
            this._tablePanelMain.Controls.Add(this._lblName, 1, 1);
            this._tablePanelMain.Controls.Add(this._tbxName, 1, 2);
            this._tablePanelMain.Controls.Add(this._lblRunTimes, 1, 32);
            this._tablePanelMain.Controls.Add(this._chxMultipleGA, 1, 28);
            this._tablePanelMain.Controls.Add(this._chxParallelGA, 1, 30);
            this._tablePanelMain.Controls.Add(this._tbxRunTimes, 1, 33);
            this._tablePanelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this._tablePanelMain.Location = new System.Drawing.Point(0, 0);
            this._tablePanelMain.Name = "_tablePanelMain";
            this._tablePanelMain.RowCount = 35;
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.Size = new System.Drawing.Size(153, 620);
            this._tablePanelMain.TabIndex = 0;
            // 
            // _lblPopulationSize
            // 
            this._lblPopulationSize.AutoSize = true;
            this._lblPopulationSize.Location = new System.Drawing.Point(8, 64);
            this._lblPopulationSize.Name = "_lblPopulationSize";
            this._lblPopulationSize.Size = new System.Drawing.Size(88, 15);
            this._lblPopulationSize.TabIndex = 0;
            this._lblPopulationSize.Text = "Population Size";
            // 
            // _lblGenerations
            // 
            this._lblGenerations.AutoSize = true;
            this._lblGenerations.Location = new System.Drawing.Point(8, 118);
            this._lblGenerations.Name = "_lblGenerations";
            this._lblGenerations.Size = new System.Drawing.Size(70, 15);
            this._lblGenerations.TabIndex = 1;
            this._lblGenerations.Text = "Generations";
            // 
            // _lblCrossoverRate
            // 
            this._lblCrossoverRate.AutoSize = true;
            this._lblCrossoverRate.Location = new System.Drawing.Point(8, 172);
            this._lblCrossoverRate.Name = "_lblCrossoverRate";
            this._lblCrossoverRate.Size = new System.Drawing.Size(85, 15);
            this._lblCrossoverRate.TabIndex = 2;
            this._lblCrossoverRate.Text = "Crossover Rate";
            // 
            // _lblMutationRate
            // 
            this._lblMutationRate.AutoSize = true;
            this._lblMutationRate.Location = new System.Drawing.Point(8, 226);
            this._lblMutationRate.Name = "_lblMutationRate";
            this._lblMutationRate.Size = new System.Drawing.Size(82, 15);
            this._lblMutationRate.TabIndex = 3;
            this._lblMutationRate.Text = "Mutation Rate";
            // 
            // _lblElitismRate
            // 
            this._lblElitismRate.AutoSize = true;
            this._lblElitismRate.Location = new System.Drawing.Point(8, 280);
            this._lblElitismRate.Name = "_lblElitismRate";
            this._lblElitismRate.Size = new System.Drawing.Size(68, 15);
            this._lblElitismRate.TabIndex = 4;
            this._lblElitismRate.Text = "Elitism Rate";
            // 
            // _tbxPopulationSize
            // 
            this._tbxPopulationSize.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxPopulationSize.Location = new System.Drawing.Point(8, 82);
            this._tbxPopulationSize.Name = "_tbxPopulationSize";
            this._tbxPopulationSize.Size = new System.Drawing.Size(137, 23);
            this._tbxPopulationSize.TabIndex = 5;
            this._tbxPopulationSize.Text = "0";
            // 
            // _tbxGenerations
            // 
            this._tbxGenerations.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxGenerations.Location = new System.Drawing.Point(8, 136);
            this._tbxGenerations.Name = "_tbxGenerations";
            this._tbxGenerations.Size = new System.Drawing.Size(137, 23);
            this._tbxGenerations.TabIndex = 6;
            this._tbxGenerations.Text = "0";
            // 
            // _tbxCrossoverRate
            // 
            this._tbxCrossoverRate.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxCrossoverRate.Location = new System.Drawing.Point(8, 190);
            this._tbxCrossoverRate.Name = "_tbxCrossoverRate";
            this._tbxCrossoverRate.Size = new System.Drawing.Size(137, 23);
            this._tbxCrossoverRate.TabIndex = 7;
            this._tbxCrossoverRate.Text = "0.0";
            this._tbxCrossoverRate.TextChanged += new System.EventHandler(this._tbxCrossoverRate_TextChanged);
            // 
            // _tbxMutationRate
            // 
            this._tbxMutationRate.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxMutationRate.Location = new System.Drawing.Point(8, 244);
            this._tbxMutationRate.Name = "_tbxMutationRate";
            this._tbxMutationRate.Size = new System.Drawing.Size(137, 23);
            this._tbxMutationRate.TabIndex = 8;
            this._tbxMutationRate.Text = "0.0";
            this._tbxMutationRate.TextChanged += new System.EventHandler(this._tbxMutationRate_TextChanged);
            // 
            // _tbxElitismRate
            // 
            this._tbxElitismRate.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxElitismRate.Location = new System.Drawing.Point(8, 298);
            this._tbxElitismRate.Name = "_tbxElitismRate";
            this._tbxElitismRate.Size = new System.Drawing.Size(137, 23);
            this._tbxElitismRate.TabIndex = 9;
            this._tbxElitismRate.Text = "0.0";
            // 
            // _lblCrossoverType
            // 
            this._lblCrossoverType.AutoSize = true;
            this._lblCrossoverType.Location = new System.Drawing.Point(8, 388);
            this._lblCrossoverType.Name = "_lblCrossoverType";
            this._lblCrossoverType.Size = new System.Drawing.Size(86, 15);
            this._lblCrossoverType.TabIndex = 10;
            this._lblCrossoverType.Text = "Crossover Type";
            // 
            // _cbxCrossoverType
            // 
            this._cbxCrossoverType.Dock = System.Windows.Forms.DockStyle.Top;
            this._cbxCrossoverType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxCrossoverType.FormattingEnabled = true;
            this._cbxCrossoverType.Location = new System.Drawing.Point(8, 406);
            this._cbxCrossoverType.Name = "_cbxCrossoverType";
            this._cbxCrossoverType.Size = new System.Drawing.Size(137, 23);
            this._cbxCrossoverType.TabIndex = 15;
            // 
            // _lblMutationType
            // 
            this._lblMutationType.AutoSize = true;
            this._lblMutationType.Location = new System.Drawing.Point(8, 442);
            this._lblMutationType.Name = "_lblMutationType";
            this._lblMutationType.Size = new System.Drawing.Size(83, 15);
            this._lblMutationType.TabIndex = 13;
            this._lblMutationType.Text = "Mutation Type";
            // 
            // _cbxMutationType
            // 
            this._cbxMutationType.Dock = System.Windows.Forms.DockStyle.Top;
            this._cbxMutationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxMutationType.FormattingEnabled = true;
            this._cbxMutationType.Location = new System.Drawing.Point(8, 460);
            this._cbxMutationType.Name = "_cbxMutationType";
            this._cbxMutationType.Size = new System.Drawing.Size(137, 23);
            this._cbxMutationType.TabIndex = 16;
            // 
            // _lblSelectionType
            // 
            this._lblSelectionType.AutoSize = true;
            this._lblSelectionType.Dock = System.Windows.Forms.DockStyle.Left;
            this._lblSelectionType.Location = new System.Drawing.Point(8, 334);
            this._lblSelectionType.Name = "_lblSelectionType";
            this._lblSelectionType.Size = new System.Drawing.Size(82, 15);
            this._lblSelectionType.TabIndex = 15;
            this._lblSelectionType.Text = "Selection Type";
            // 
            // _cbxSelectionType
            // 
            this._cbxSelectionType.Dock = System.Windows.Forms.DockStyle.Top;
            this._cbxSelectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbxSelectionType.FormattingEnabled = true;
            this._cbxSelectionType.Location = new System.Drawing.Point(8, 352);
            this._cbxSelectionType.Name = "_cbxSelectionType";
            this._cbxSelectionType.Size = new System.Drawing.Size(137, 23);
            this._cbxSelectionType.TabIndex = 14;
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(8, 10);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(39, 15);
            this._lblName.TabIndex = 17;
            this._lblName.Text = "Name";
            // 
            // _tbxName
            // 
            this._tbxName.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxName.Location = new System.Drawing.Point(8, 28);
            this._tbxName.Name = "_tbxName";
            this._tbxName.Size = new System.Drawing.Size(137, 23);
            this._tbxName.TabIndex = 4;
            // 
            // _lblRunTimes
            // 
            this._lblRunTimes.AutoSize = true;
            this._lblRunTimes.Location = new System.Drawing.Point(8, 566);
            this._lblRunTimes.Name = "_lblRunTimes";
            this._lblRunTimes.Size = new System.Drawing.Size(62, 15);
            this._lblRunTimes.TabIndex = 19;
            this._lblRunTimes.Text = "Run Times";
            // 
            // _chxMultipleGA
            // 
            this._chxMultipleGA.AutoSize = true;
            this._chxMultipleGA.Location = new System.Drawing.Point(8, 499);
            this._chxMultipleGA.Name = "_chxMultipleGA";
            this._chxMultipleGA.Size = new System.Drawing.Size(137, 19);
            this._chxMultipleGA.TabIndex = 20;
            this._chxMultipleGA.Text = "Enable Multiple Runs";
            this._chxMultipleGA.UseVisualStyleBackColor = true;
            this._chxMultipleGA.CheckedChanged += new System.EventHandler(this._chxMultipleGA_CheckedChanged);
            // 
            // _chxParallelGA
            // 
            this._chxParallelGA.AutoSize = true;
            this._chxParallelGA.Location = new System.Drawing.Point(8, 534);
            this._chxParallelGA.Name = "_chxParallelGA";
            this._chxParallelGA.Size = new System.Drawing.Size(131, 19);
            this._chxParallelGA.TabIndex = 21;
            this._chxParallelGA.Text = "Enable Parallel Runs";
            this._chxParallelGA.UseVisualStyleBackColor = true;
            // 
            // _tbxRunTimes
            // 
            this._tbxRunTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tbxRunTimes.Location = new System.Drawing.Point(8, 584);
            this._tbxRunTimes.Name = "_tbxRunTimes";
            this._tbxRunTimes.Size = new System.Drawing.Size(137, 23);
            this._tbxRunTimes.TabIndex = 22;
            // 
            // FrmGASetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(170, 200);
            this.Controls.Add(this._tablePanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(170, 200);
            this.Name = "FrmGASetup";
            this.Text = "GA Setup";
            this.Load += new System.EventHandler(this.FrmGASetup_Load);
            this._tablePanelMain.ResumeLayout(false);
            this._tablePanelMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel _tablePanelMain;
        private System.Windows.Forms.Label _lblPopulationSize;
        private System.Windows.Forms.Label _lblGenerations;
        private System.Windows.Forms.Label _lblCrossoverRate;
        private System.Windows.Forms.Label _lblMutationRate;
        private System.Windows.Forms.Label _lblElitismRate;
        private System.Windows.Forms.TextBox _tbxPopulationSize;
        private System.Windows.Forms.TextBox _tbxGenerations;
        private System.Windows.Forms.TextBox _tbxCrossoverRate;
        private System.Windows.Forms.TextBox _tbxMutationRate;
        private System.Windows.Forms.TextBox _tbxElitismRate;
        private System.Windows.Forms.Label _lblCrossoverType;
        private System.Windows.Forms.ComboBox _cbxCrossoverType;
        private System.Windows.Forms.Label _lblMutationType;
        private System.Windows.Forms.ComboBox _cbxMutationType;
        private System.Windows.Forms.Label _lblSelectionType;
        private System.Windows.Forms.ComboBox _cbxSelectionType;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.TextBox _tbxName;
        private System.Windows.Forms.Label _lblRunTimes;
        private System.Windows.Forms.CheckBox _chxMultipleGA;
        private System.Windows.Forms.CheckBox _chxParallelGA;
        private System.Windows.Forms.TextBox _tbxRunTimes;
    }
}