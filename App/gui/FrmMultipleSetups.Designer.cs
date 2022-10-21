
namespace App.Gui
{
    partial class FrmMultipleSetups
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
            this._tablePanelActions = new System.Windows.Forms.TableLayoutPanel();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._tbxRunTimes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._tbxPopulations = new System.Windows.Forms.TextBox();
            this._tbxGenerations = new System.Windows.Forms.TextBox();
            this._tbxCrossoverRates = new System.Windows.Forms.TextBox();
            this._tbxMutationRates = new System.Windows.Forms.TextBox();
            this._tbxElitismRates = new System.Windows.Forms.TextBox();
            this._tbxCrossoverOperators = new System.Windows.Forms.TextBox();
            this._tbxMutationOperators = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._chxMutliple = new System.Windows.Forms.CheckBox();
            this._chxParallel = new System.Windows.Forms.CheckBox();
            this._tablePanelMain.SuspendLayout();
            this._tablePanelActions.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tablePanelMain
            // 
            this._tablePanelMain.ColumnCount = 3;
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.Controls.Add(this._tablePanelActions, 1, 3);
            this._tablePanelMain.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this._tablePanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tablePanelMain.Location = new System.Drawing.Point(0, 0);
            this._tablePanelMain.Margin = new System.Windows.Forms.Padding(0);
            this._tablePanelMain.Name = "_tablePanelMain";
            this._tablePanelMain.RowCount = 5;
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.Size = new System.Drawing.Size(374, 331);
            this._tablePanelMain.TabIndex = 0;
            // 
            // _tablePanelActions
            // 
            this._tablePanelActions.AutoSize = true;
            this._tablePanelActions.ColumnCount = 3;
            this._tablePanelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tablePanelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this._tablePanelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tablePanelActions.Controls.Add(this._btnCancel, 0, 0);
            this._tablePanelActions.Controls.Add(this._btnSave, 2, 0);
            this._tablePanelActions.Dock = System.Windows.Forms.DockStyle.Right;
            this._tablePanelActions.Location = new System.Drawing.Point(209, 298);
            this._tablePanelActions.Margin = new System.Windows.Forms.Padding(0);
            this._tablePanelActions.Name = "_tablePanelActions";
            this._tablePanelActions.RowCount = 1;
            this._tablePanelActions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelActions.Size = new System.Drawing.Size(155, 23);
            this._tablePanelActions.TabIndex = 0;
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(0, 0);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 0;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(80, 0);
            this._btnSave.Margin = new System.Windows.Forms.Padding(0);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 1;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this._tbxRunTimes, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this._tbxPopulations, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._tbxGenerations, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this._tbxCrossoverRates, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this._tbxMutationRates, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this._tbxElitismRates, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this._tbxCrossoverOperators, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this._tbxMutationOperators, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this._chxMutliple, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this._chxParallel, 2, 12);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(348, 266);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // _tbxRunTimes
            // 
            this._tbxRunTimes.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxRunTimes.Location = new System.Drawing.Point(184, 195);
            this._tbxRunTimes.Name = "_tbxRunTimes";
            this._tbxRunTimes.Size = new System.Drawing.Size(161, 23);
            this._tbxRunTimes.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Populations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Generations";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Crossover Rates";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mutation Rates";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Elitism Rates";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(184, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Crossover Operators";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(184, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Mutation Operators";
            // 
            // _tbxPopulations
            // 
            this._tbxPopulations.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxPopulations.Location = new System.Drawing.Point(3, 18);
            this._tbxPopulations.Name = "_tbxPopulations";
            this._tbxPopulations.Size = new System.Drawing.Size(160, 23);
            this._tbxPopulations.TabIndex = 7;
            // 
            // _tbxGenerations
            // 
            this._tbxGenerations.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxGenerations.Location = new System.Drawing.Point(3, 77);
            this._tbxGenerations.Name = "_tbxGenerations";
            this._tbxGenerations.Size = new System.Drawing.Size(160, 23);
            this._tbxGenerations.TabIndex = 8;
            // 
            // _tbxCrossoverRates
            // 
            this._tbxCrossoverRates.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxCrossoverRates.Location = new System.Drawing.Point(3, 136);
            this._tbxCrossoverRates.Name = "_tbxCrossoverRates";
            this._tbxCrossoverRates.Size = new System.Drawing.Size(160, 23);
            this._tbxCrossoverRates.TabIndex = 9;
            // 
            // _tbxMutationRates
            // 
            this._tbxMutationRates.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxMutationRates.Location = new System.Drawing.Point(3, 195);
            this._tbxMutationRates.Name = "_tbxMutationRates";
            this._tbxMutationRates.Size = new System.Drawing.Size(160, 23);
            this._tbxMutationRates.TabIndex = 10;
            // 
            // _tbxElitismRates
            // 
            this._tbxElitismRates.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxElitismRates.Location = new System.Drawing.Point(184, 18);
            this._tbxElitismRates.Name = "_tbxElitismRates";
            this._tbxElitismRates.Size = new System.Drawing.Size(161, 23);
            this._tbxElitismRates.TabIndex = 11;
            // 
            // _tbxCrossoverOperators
            // 
            this._tbxCrossoverOperators.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxCrossoverOperators.Location = new System.Drawing.Point(184, 77);
            this._tbxCrossoverOperators.Name = "_tbxCrossoverOperators";
            this._tbxCrossoverOperators.Size = new System.Drawing.Size(161, 23);
            this._tbxCrossoverOperators.TabIndex = 12;
            // 
            // _tbxMutationOperators
            // 
            this._tbxMutationOperators.Dock = System.Windows.Forms.DockStyle.Top;
            this._tbxMutationOperators.Location = new System.Drawing.Point(184, 136);
            this._tbxMutationOperators.Name = "_tbxMutationOperators";
            this._tbxMutationOperators.Size = new System.Drawing.Size(161, 23);
            this._tbxMutationOperators.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(184, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Run Times";
            // 
            // _chxMutliple
            // 
            this._chxMutliple.AutoSize = true;
            this._chxMutliple.Location = new System.Drawing.Point(3, 239);
            this._chxMutliple.Name = "_chxMutliple";
            this._chxMutliple.Size = new System.Drawing.Size(70, 19);
            this._chxMutliple.TabIndex = 16;
            this._chxMutliple.Text = "Multiple";
            this._chxMutliple.UseVisualStyleBackColor = true;
            // 
            // _chxParallel
            // 
            this._chxParallel.AutoSize = true;
            this._chxParallel.Location = new System.Drawing.Point(184, 239);
            this._chxParallel.Name = "_chxParallel";
            this._chxParallel.Size = new System.Drawing.Size(64, 19);
            this._chxParallel.TabIndex = 17;
            this._chxParallel.Text = "Parallel";
            this._chxParallel.UseVisualStyleBackColor = true;
            // 
            // FrmMultipleSetups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 331);
            this.Controls.Add(this._tablePanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(280, 300);
            this.Name = "FrmMultipleSetups";
            this.Text = "GA With Multiple Setups";
            this._tablePanelMain.ResumeLayout(false);
            this._tablePanelMain.PerformLayout();
            this._tablePanelActions.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tablePanelMain;
        private System.Windows.Forms.TableLayoutPanel _tablePanelActions;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _tbxPopulations;
        private System.Windows.Forms.TextBox _tbxGenerations;
        private System.Windows.Forms.TextBox _tbxCrossoverRates;
        private System.Windows.Forms.TextBox _tbxMutationRates;
        private System.Windows.Forms.TextBox _tbxElitismRates;
        private System.Windows.Forms.TextBox _tbxCrossoverOperators;
        private System.Windows.Forms.TextBox _tbxMutationOperators;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox _tbxRunTimes;
        private System.Windows.Forms.CheckBox _chxMutliple;
        private System.Windows.Forms.CheckBox _chxParallel;
    }
}