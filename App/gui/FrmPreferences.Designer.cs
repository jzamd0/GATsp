
namespace App.Gui
{
    partial class FrmPreferences
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
            this._pnlPreferences = new System.Windows.Forms.Panel();
            this._tablePanelPreferences = new System.Windows.Forms.TableLayoutPanel();
            this._lblVerbose = new System.Windows.Forms.Label();
            this._chxVerboseEnabled = new System.Windows.Forms.CheckBox();
            this._chxVerboseGeneration = new System.Windows.Forms.CheckBox();
            this._chxVerboseCrossover = new System.Windows.Forms.CheckBox();
            this._chxVerboseMutation = new System.Windows.Forms.CheckBox();
            this._chxVerboseResult = new System.Windows.Forms.CheckBox();
            this._chxVerboseAll = new System.Windows.Forms.CheckBox();
            this._tablePanelMain.SuspendLayout();
            this._tablePanelActions.SuspendLayout();
            this._pnlPreferences.SuspendLayout();
            this._tablePanelPreferences.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tablePanelMain
            // 
            this._tablePanelMain.ColumnCount = 3;
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.Controls.Add(this._tablePanelActions, 1, 3);
            this._tablePanelMain.Controls.Add(this._pnlPreferences, 1, 1);
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
            this._tablePanelMain.Size = new System.Drawing.Size(264, 261);
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
            this._tablePanelActions.Location = new System.Drawing.Point(99, 228);
            this._tablePanelActions.Margin = new System.Windows.Forms.Padding(0);
            this._tablePanelActions.Name = "_tablePanelActions";
            this._tablePanelActions.RowCount = 1;
            this._tablePanelActions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelActions.Size = new System.Drawing.Size(155, 23);
            this._tablePanelActions.TabIndex = 0;
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            this._btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnSave.Location = new System.Drawing.Point(80, 0);
            this._btnSave.Margin = new System.Windows.Forms.Padding(0);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 1;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
            // 
            // _pnlPreferences
            // 
            this._pnlPreferences.AutoScroll = true;
            this._pnlPreferences.Controls.Add(this._tablePanelPreferences);
            this._pnlPreferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlPreferences.Location = new System.Drawing.Point(10, 10);
            this._pnlPreferences.Margin = new System.Windows.Forms.Padding(0);
            this._pnlPreferences.Name = "_pnlPreferences";
            this._pnlPreferences.Size = new System.Drawing.Size(244, 208);
            this._pnlPreferences.TabIndex = 1;
            // 
            // _tablePanelPreferences
            // 
            this._tablePanelPreferences.AutoSize = true;
            this._tablePanelPreferences.ColumnCount = 1;
            this._tablePanelPreferences.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tablePanelPreferences.Controls.Add(this._lblVerbose, 0, 0);
            this._tablePanelPreferences.Controls.Add(this._chxVerboseEnabled, 0, 2);
            this._tablePanelPreferences.Controls.Add(this._chxVerboseGeneration, 0, 4);
            this._tablePanelPreferences.Controls.Add(this._chxVerboseCrossover, 0, 5);
            this._tablePanelPreferences.Controls.Add(this._chxVerboseMutation, 0, 6);
            this._tablePanelPreferences.Controls.Add(this._chxVerboseResult, 0, 7);
            this._tablePanelPreferences.Controls.Add(this._chxVerboseAll, 0, 3);
            this._tablePanelPreferences.Dock = System.Windows.Forms.DockStyle.Top;
            this._tablePanelPreferences.Location = new System.Drawing.Point(0, 0);
            this._tablePanelPreferences.Name = "_tablePanelPreferences";
            this._tablePanelPreferences.RowCount = 8;
            this._tablePanelPreferences.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelPreferences.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this._tablePanelPreferences.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelPreferences.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelPreferences.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelPreferences.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelPreferences.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelPreferences.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelPreferences.Size = new System.Drawing.Size(244, 170);
            this._tablePanelPreferences.TabIndex = 0;
            // 
            // _lblVerbose
            // 
            this._lblVerbose.AutoSize = true;
            this._lblVerbose.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this._lblVerbose.Location = new System.Drawing.Point(3, 0);
            this._lblVerbose.Name = "_lblVerbose";
            this._lblVerbose.Size = new System.Drawing.Size(52, 15);
            this._lblVerbose.TabIndex = 3;
            this._lblVerbose.Text = "Verbose";
            // 
            // _chxVerboseEnabled
            // 
            this._chxVerboseEnabled.AutoSize = true;
            this._chxVerboseEnabled.Location = new System.Drawing.Point(3, 23);
            this._chxVerboseEnabled.Name = "_chxVerboseEnabled";
            this._chxVerboseEnabled.Size = new System.Drawing.Size(205, 19);
            this._chxVerboseEnabled.TabIndex = 4;
            this._chxVerboseEnabled.Text = "Enable verbose output on console";
            this._chxVerboseEnabled.UseVisualStyleBackColor = true;
            this._chxVerboseEnabled.Click += new System.EventHandler(this._chxVerboseEnabled_Click);
            // 
            // _chxVerboseGeneration
            // 
            this._chxVerboseGeneration.AutoSize = true;
            this._chxVerboseGeneration.Location = new System.Drawing.Point(3, 73);
            this._chxVerboseGeneration.Name = "_chxVerboseGeneration";
            this._chxVerboseGeneration.Size = new System.Drawing.Size(182, 19);
            this._chxVerboseGeneration.TabIndex = 5;
            this._chxVerboseGeneration.Text = "Enable verbose on generation";
            this._chxVerboseGeneration.UseVisualStyleBackColor = true;
            this._chxVerboseGeneration.Click += new System.EventHandler(this._chxVerboseGeneration_Click);
            // 
            // _chxVerboseCrossover
            // 
            this._chxVerboseCrossover.AutoSize = true;
            this._chxVerboseCrossover.Location = new System.Drawing.Point(3, 98);
            this._chxVerboseCrossover.Name = "_chxVerboseCrossover";
            this._chxVerboseCrossover.Size = new System.Drawing.Size(175, 19);
            this._chxVerboseCrossover.TabIndex = 7;
            this._chxVerboseCrossover.Text = "Enable verbose on crossover";
            this._chxVerboseCrossover.UseVisualStyleBackColor = true;
            this._chxVerboseCrossover.Click += new System.EventHandler(this._chxVerboseCrossover_Click);
            // 
            // _chxVerboseMutation
            // 
            this._chxVerboseMutation.AutoSize = true;
            this._chxVerboseMutation.Location = new System.Drawing.Point(3, 123);
            this._chxVerboseMutation.Name = "_chxVerboseMutation";
            this._chxVerboseMutation.Size = new System.Drawing.Size(174, 19);
            this._chxVerboseMutation.TabIndex = 8;
            this._chxVerboseMutation.Text = "Enable verbose on mutation";
            this._chxVerboseMutation.UseVisualStyleBackColor = true;
            this._chxVerboseMutation.Click += new System.EventHandler(this._chxVerboseMutation_Click);
            // 
            // _chxVerboseResult
            // 
            this._chxVerboseResult.AutoSize = true;
            this._chxVerboseResult.Dock = System.Windows.Forms.DockStyle.Left;
            this._chxVerboseResult.Location = new System.Drawing.Point(3, 148);
            this._chxVerboseResult.Name = "_chxVerboseResult";
            this._chxVerboseResult.Size = new System.Drawing.Size(154, 19);
            this._chxVerboseResult.TabIndex = 9;
            this._chxVerboseResult.Text = "Enable verbose on result";
            this._chxVerboseResult.UseVisualStyleBackColor = true;
            this._chxVerboseResult.Click += new System.EventHandler(this._chxVerboseResult_Click);
            // 
            // _chxVerboseAll
            // 
            this._chxVerboseAll.AutoSize = true;
            this._chxVerboseAll.Dock = System.Windows.Forms.DockStyle.Left;
            this._chxVerboseAll.Location = new System.Drawing.Point(3, 48);
            this._chxVerboseAll.Name = "_chxVerboseAll";
            this._chxVerboseAll.Size = new System.Drawing.Size(159, 19);
            this._chxVerboseAll.TabIndex = 10;
            this._chxVerboseAll.Text = "Enable all verbose output";
            this._chxVerboseAll.ThreeState = true;
            this._chxVerboseAll.UseVisualStyleBackColor = true;
            this._chxVerboseAll.Click += new System.EventHandler(this._chxVerboseAll_Click);
            // 
            // FrmPreferences
            // 
            this.AcceptButton = this._btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(264, 261);
            this.Controls.Add(this._tablePanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(280, 300);
            this.Name = "FrmPreferences";
            this.Text = "Preferences";
            this._tablePanelMain.ResumeLayout(false);
            this._tablePanelMain.PerformLayout();
            this._tablePanelActions.ResumeLayout(false);
            this._pnlPreferences.ResumeLayout(false);
            this._pnlPreferences.PerformLayout();
            this._tablePanelPreferences.ResumeLayout(false);
            this._tablePanelPreferences.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tablePanelMain;
        private System.Windows.Forms.TableLayoutPanel _tablePanelActions;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Panel _pnlPreferences;
        private System.Windows.Forms.TableLayoutPanel _tablePanelPreferences;
        private System.Windows.Forms.Label _lblVerbose;
        private System.Windows.Forms.CheckBox _chxVerboseEnabled;
        private System.Windows.Forms.CheckBox _chxVerboseGeneration;
        private System.Windows.Forms.CheckBox _chxVerboseCrossover;
        private System.Windows.Forms.CheckBox _chxVerboseMutation;
        private System.Windows.Forms.CheckBox _chxVerboseResult;
        private System.Windows.Forms.CheckBox _chxVerboseAll;
    }
}