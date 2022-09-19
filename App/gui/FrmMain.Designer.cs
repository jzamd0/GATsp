﻿
namespace App.Gui
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._pnlMain = new System.Windows.Forms.Panel();
            this._splitMain = new System.Windows.Forms.SplitContainer();
            this._splitTsp = new System.Windows.Forms.SplitContainer();
            this._pnlSetup = new System.Windows.Forms.Panel();
            this._tabControlSetup = new System.Windows.Forms.TabControl();
            this._tabSetup = new System.Windows.Forms.TabPage();
            this._tabNodes = new System.Windows.Forms.TabPage();
            this._dgvNodes = new System.Windows.Forms.DataGridView();
            this._tabEdges = new System.Windows.Forms.TabPage();
            this._dgvEdges = new System.Windows.Forms.DataGridView();
            this._tabCoordinates = new System.Windows.Forms.TabPage();
            this._dgvCoordinates = new System.Windows.Forms.DataGridView();
            this._pnlTsp = new System.Windows.Forms.Panel();
            this._tabControlTsp = new System.Windows.Forms.TabControl();
            this._tabDistances = new System.Windows.Forms.TabPage();
            this._dgvDistances = new System.Windows.Forms.DataGridView();
            this._tabGraph = new System.Windows.Forms.TabPage();
            this._pnlCanvas = new System.Windows.Forms.Panel();
            this._pbxCanvas = new System.Windows.Forms.PictureBox();
            this._pnlResult = new System.Windows.Forms.Panel();
            this._tabControlResults = new System.Windows.Forms.TabControl();
            this._tabSummary = new System.Windows.Forms.TabPage();
            this._dgvSummary = new System.Windows.Forms.DataGridView();
            this._tabPopulation = new System.Windows.Forms.TabPage();
            this._statusMain = new System.Windows.Forms.StatusStrip();
            this._menuStripMain = new System.Windows.Forms.MenuStrip();
            this._menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this._mniOpenTsp = new System.Windows.Forms.ToolStripMenuItem();
            this._mniExportTspSep = new System.Windows.Forms.ToolStripSeparator();
            this._mniExportTsp = new System.Windows.Forms.ToolStripMenuItem();
            this._mniExportTspToDistances = new System.Windows.Forms.ToolStripMenuItem();
            this._mniExportTspToGraph = new System.Windows.Forms.ToolStripMenuItem();
            this._mniExitSep = new System.Windows.Forms.ToolStripSeparator();
            this._mniExit = new System.Windows.Forms.ToolStripMenuItem();
            this._menuView = new System.Windows.Forms.ToolStripMenuItem();
            this._mniViewSetup = new System.Windows.Forms.ToolStripMenuItem();
            this._mniViewResults = new System.Windows.Forms.ToolStripMenuItem();
            this._menuTsp = new System.Windows.Forms.ToolStripMenuItem();
            this._mniSolveTsp = new System.Windows.Forms.ToolStripMenuItem();
            this._menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this._mniAbout = new System.Windows.Forms.ToolStripMenuItem();
            this._pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitMain)).BeginInit();
            this._splitMain.Panel1.SuspendLayout();
            this._splitMain.Panel2.SuspendLayout();
            this._splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitTsp)).BeginInit();
            this._splitTsp.Panel1.SuspendLayout();
            this._splitTsp.Panel2.SuspendLayout();
            this._splitTsp.SuspendLayout();
            this._pnlSetup.SuspendLayout();
            this._tabControlSetup.SuspendLayout();
            this._tabNodes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvNodes)).BeginInit();
            this._tabEdges.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvEdges)).BeginInit();
            this._tabCoordinates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvCoordinates)).BeginInit();
            this._pnlTsp.SuspendLayout();
            this._tabControlTsp.SuspendLayout();
            this._tabDistances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvDistances)).BeginInit();
            this._tabGraph.SuspendLayout();
            this._pnlCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pbxCanvas)).BeginInit();
            this._pnlResult.SuspendLayout();
            this._tabControlResults.SuspendLayout();
            this._tabSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dgvSummary)).BeginInit();
            this._menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pnlMain
            // 
            this._pnlMain.BackColor = System.Drawing.Color.White;
            this._pnlMain.Controls.Add(this._splitMain);
            this._pnlMain.Controls.Add(this._statusMain);
            this._pnlMain.Controls.Add(this._menuStripMain);
            this._pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlMain.Location = new System.Drawing.Point(0, 0);
            this._pnlMain.Name = "_pnlMain";
            this._pnlMain.Size = new System.Drawing.Size(584, 361);
            this._pnlMain.TabIndex = 0;
            // 
            // _splitMain
            // 
            this._splitMain.BackColor = System.Drawing.Color.LightGray;
            this._splitMain.Cursor = System.Windows.Forms.Cursors.HSplit;
            this._splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitMain.Location = new System.Drawing.Point(0, 24);
            this._splitMain.Name = "_splitMain";
            this._splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _splitMain.Panel1
            // 
            this._splitMain.Panel1.Controls.Add(this._splitTsp);
            this._splitMain.Panel1MinSize = 100;
            // 
            // _splitMain.Panel2
            // 
            this._splitMain.Panel2.Controls.Add(this._pnlResult);
            this._splitMain.Panel2MinSize = 100;
            this._splitMain.Size = new System.Drawing.Size(584, 315);
            this._splitMain.SplitterDistance = 200;
            this._splitMain.TabIndex = 1;
            // 
            // _splitTsp
            // 
            this._splitTsp.Cursor = System.Windows.Forms.Cursors.VSplit;
            this._splitTsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitTsp.Location = new System.Drawing.Point(0, 0);
            this._splitTsp.Name = "_splitTsp";
            // 
            // _splitTsp.Panel1
            // 
            this._splitTsp.Panel1.Controls.Add(this._pnlSetup);
            this._splitTsp.Panel1MinSize = 200;
            // 
            // _splitTsp.Panel2
            // 
            this._splitTsp.Panel2.Controls.Add(this._pnlTsp);
            this._splitTsp.Panel2MinSize = 300;
            this._splitTsp.Size = new System.Drawing.Size(584, 200);
            this._splitTsp.SplitterDistance = 250;
            this._splitTsp.TabIndex = 0;
            // 
            // _pnlSetup
            // 
            this._pnlSetup.BackColor = System.Drawing.SystemColors.Control;
            this._pnlSetup.Controls.Add(this._tabControlSetup);
            this._pnlSetup.Cursor = System.Windows.Forms.Cursors.Arrow;
            this._pnlSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlSetup.Location = new System.Drawing.Point(0, 0);
            this._pnlSetup.Name = "_pnlSetup";
            this._pnlSetup.Size = new System.Drawing.Size(250, 200);
            this._pnlSetup.TabIndex = 0;
            this._pnlSetup.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._pnlSetup_MouseDoubleClick);
            // 
            // _tabControlSetup
            // 
            this._tabControlSetup.Controls.Add(this._tabSetup);
            this._tabControlSetup.Controls.Add(this._tabNodes);
            this._tabControlSetup.Controls.Add(this._tabEdges);
            this._tabControlSetup.Controls.Add(this._tabCoordinates);
            this._tabControlSetup.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControlSetup.Location = new System.Drawing.Point(0, 0);
            this._tabControlSetup.Name = "_tabControlSetup";
            this._tabControlSetup.SelectedIndex = 0;
            this._tabControlSetup.Size = new System.Drawing.Size(250, 200);
            this._tabControlSetup.TabIndex = 0;
            // 
            // _tabSetup
            // 
            this._tabSetup.Location = new System.Drawing.Point(4, 24);
            this._tabSetup.Name = "_tabSetup";
            this._tabSetup.Padding = new System.Windows.Forms.Padding(3);
            this._tabSetup.Size = new System.Drawing.Size(242, 172);
            this._tabSetup.TabIndex = 0;
            this._tabSetup.Text = "Setup";
            this._tabSetup.UseVisualStyleBackColor = true;
            // 
            // _tabNodes
            // 
            this._tabNodes.Controls.Add(this._dgvNodes);
            this._tabNodes.Location = new System.Drawing.Point(4, 24);
            this._tabNodes.Name = "_tabNodes";
            this._tabNodes.Padding = new System.Windows.Forms.Padding(3);
            this._tabNodes.Size = new System.Drawing.Size(242, 172);
            this._tabNodes.TabIndex = 2;
            this._tabNodes.Text = "Nodes";
            this._tabNodes.UseVisualStyleBackColor = true;
            // 
            // _dgvNodes
            // 
            this._dgvNodes.AllowUserToAddRows = false;
            this._dgvNodes.AllowUserToDeleteRows = false;
            this._dgvNodes.AllowUserToResizeRows = false;
            this._dgvNodes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvNodes.BackgroundColor = System.Drawing.Color.White;
            this._dgvNodes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dgvNodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvNodes.Location = new System.Drawing.Point(3, 3);
            this._dgvNodes.Name = "_dgvNodes";
            this._dgvNodes.ReadOnly = true;
            this._dgvNodes.RowHeadersVisible = false;
            this._dgvNodes.RowTemplate.Height = 25;
            this._dgvNodes.Size = new System.Drawing.Size(236, 166);
            this._dgvNodes.TabIndex = 0;
            // 
            // _tabEdges
            // 
            this._tabEdges.Controls.Add(this._dgvEdges);
            this._tabEdges.Location = new System.Drawing.Point(4, 24);
            this._tabEdges.Name = "_tabEdges";
            this._tabEdges.Padding = new System.Windows.Forms.Padding(3);
            this._tabEdges.Size = new System.Drawing.Size(242, 172);
            this._tabEdges.TabIndex = 2;
            this._tabEdges.Text = "Edges";
            this._tabEdges.UseVisualStyleBackColor = true;
            // 
            // _dgvEdges
            // 
            this._dgvEdges.AllowUserToAddRows = false;
            this._dgvEdges.AllowUserToDeleteRows = false;
            this._dgvEdges.AllowUserToResizeRows = false;
            this._dgvEdges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvEdges.BackgroundColor = System.Drawing.Color.White;
            this._dgvEdges.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dgvEdges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvEdges.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvEdges.Location = new System.Drawing.Point(3, 3);
            this._dgvEdges.Name = "_dgvEdges";
            this._dgvEdges.ReadOnly = true;
            this._dgvEdges.RowHeadersVisible = false;
            this._dgvEdges.RowTemplate.Height = 25;
            this._dgvEdges.Size = new System.Drawing.Size(236, 166);
            this._dgvEdges.TabIndex = 0;
            // 
            // _tabCoordinates
            // 
            this._tabCoordinates.Controls.Add(this._dgvCoordinates);
            this._tabCoordinates.Location = new System.Drawing.Point(4, 24);
            this._tabCoordinates.Name = "_tabCoordinates";
            this._tabCoordinates.Padding = new System.Windows.Forms.Padding(3);
            this._tabCoordinates.Size = new System.Drawing.Size(242, 172);
            this._tabCoordinates.TabIndex = 1;
            this._tabCoordinates.Text = "Coordinates";
            this._tabCoordinates.UseVisualStyleBackColor = true;
            // 
            // _dgvCoordinates
            // 
            this._dgvCoordinates.AllowUserToAddRows = false;
            this._dgvCoordinates.AllowUserToDeleteRows = false;
            this._dgvCoordinates.AllowUserToResizeRows = false;
            this._dgvCoordinates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvCoordinates.BackgroundColor = System.Drawing.Color.White;
            this._dgvCoordinates.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dgvCoordinates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvCoordinates.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvCoordinates.Location = new System.Drawing.Point(3, 3);
            this._dgvCoordinates.Name = "_dgvCoordinates";
            this._dgvCoordinates.ReadOnly = true;
            this._dgvCoordinates.RowHeadersVisible = false;
            this._dgvCoordinates.RowTemplate.Height = 25;
            this._dgvCoordinates.Size = new System.Drawing.Size(236, 166);
            this._dgvCoordinates.TabIndex = 0;
            // 
            // _pnlTsp
            // 
            this._pnlTsp.BackColor = System.Drawing.SystemColors.Control;
            this._pnlTsp.Controls.Add(this._tabControlTsp);
            this._pnlTsp.Cursor = System.Windows.Forms.Cursors.Arrow;
            this._pnlTsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlTsp.Location = new System.Drawing.Point(0, 0);
            this._pnlTsp.Name = "_pnlTsp";
            this._pnlTsp.Size = new System.Drawing.Size(330, 200);
            this._pnlTsp.TabIndex = 0;
            this._pnlTsp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._pnlTsp_MouseDoubleClick);
            // 
            // _tabControlTsp
            // 
            this._tabControlTsp.Controls.Add(this._tabDistances);
            this._tabControlTsp.Controls.Add(this._tabGraph);
            this._tabControlTsp.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControlTsp.Location = new System.Drawing.Point(0, 0);
            this._tabControlTsp.Name = "_tabControlTsp";
            this._tabControlTsp.SelectedIndex = 0;
            this._tabControlTsp.Size = new System.Drawing.Size(330, 200);
            this._tabControlTsp.TabIndex = 1;
            // 
            // _tabDistances
            // 
            this._tabDistances.Controls.Add(this._dgvDistances);
            this._tabDistances.Location = new System.Drawing.Point(4, 24);
            this._tabDistances.Name = "_tabDistances";
            this._tabDistances.Padding = new System.Windows.Forms.Padding(3);
            this._tabDistances.Size = new System.Drawing.Size(322, 172);
            this._tabDistances.TabIndex = 0;
            this._tabDistances.Text = "Distances";
            this._tabDistances.UseVisualStyleBackColor = true;
            // 
            // _dgvDistances
            // 
            this._dgvDistances.AllowUserToAddRows = false;
            this._dgvDistances.AllowUserToDeleteRows = false;
            this._dgvDistances.AllowUserToResizeRows = false;
            this._dgvDistances.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvDistances.BackgroundColor = System.Drawing.Color.White;
            this._dgvDistances.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dgvDistances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvDistances.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvDistances.Location = new System.Drawing.Point(3, 3);
            this._dgvDistances.Name = "_dgvDistances";
            this._dgvDistances.ReadOnly = true;
            this._dgvDistances.RowHeadersVisible = false;
            this._dgvDistances.RowTemplate.Height = 25;
            this._dgvDistances.Size = new System.Drawing.Size(316, 166);
            this._dgvDistances.TabIndex = 0;
            // 
            // _tabGraph
            // 
            this._tabGraph.Controls.Add(this._pnlCanvas);
            this._tabGraph.Location = new System.Drawing.Point(4, 24);
            this._tabGraph.Name = "_tabGraph";
            this._tabGraph.Padding = new System.Windows.Forms.Padding(3);
            this._tabGraph.Size = new System.Drawing.Size(322, 172);
            this._tabGraph.TabIndex = 1;
            this._tabGraph.Text = "Graph";
            this._tabGraph.UseVisualStyleBackColor = true;
            // 
            // _pnlCanvas
            // 
            this._pnlCanvas.AutoScroll = true;
            this._pnlCanvas.AutoSize = true;
            this._pnlCanvas.Controls.Add(this._pbxCanvas);
            this._pnlCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlCanvas.Location = new System.Drawing.Point(3, 3);
            this._pnlCanvas.Name = "_pnlCanvas";
            this._pnlCanvas.Size = new System.Drawing.Size(316, 166);
            this._pnlCanvas.TabIndex = 1;
            // 
            // _pbxCanvas
            // 
            this._pbxCanvas.BackColor = System.Drawing.Color.White;
            this._pbxCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pbxCanvas.Location = new System.Drawing.Point(0, 0);
            this._pbxCanvas.Name = "_pbxCanvas";
            this._pbxCanvas.Size = new System.Drawing.Size(316, 166);
            this._pbxCanvas.TabIndex = 0;
            this._pbxCanvas.TabStop = false;
            this._pbxCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this._pbxCanvas_Paint);
            // 
            // _pnlResult
            // 
            this._pnlResult.BackColor = System.Drawing.SystemColors.Control;
            this._pnlResult.Controls.Add(this._tabControlResults);
            this._pnlResult.Cursor = System.Windows.Forms.Cursors.Arrow;
            this._pnlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlResult.Location = new System.Drawing.Point(0, 0);
            this._pnlResult.Name = "_pnlResult";
            this._pnlResult.Size = new System.Drawing.Size(584, 111);
            this._pnlResult.TabIndex = 0;
            this._pnlResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._pnlResult_MouseDoubleClick);
            // 
            // _tabControlResults
            // 
            this._tabControlResults.Controls.Add(this._tabSummary);
            this._tabControlResults.Controls.Add(this._tabPopulation);
            this._tabControlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControlResults.Location = new System.Drawing.Point(0, 0);
            this._tabControlResults.Name = "_tabControlResults";
            this._tabControlResults.SelectedIndex = 0;
            this._tabControlResults.Size = new System.Drawing.Size(584, 111);
            this._tabControlResults.TabIndex = 1;
            // 
            // _tabSummary
            // 
            this._tabSummary.Controls.Add(this._dgvSummary);
            this._tabSummary.Location = new System.Drawing.Point(4, 24);
            this._tabSummary.Name = "_tabSummary";
            this._tabSummary.Padding = new System.Windows.Forms.Padding(3);
            this._tabSummary.Size = new System.Drawing.Size(576, 83);
            this._tabSummary.TabIndex = 0;
            this._tabSummary.Text = "Summary";
            this._tabSummary.UseVisualStyleBackColor = true;
            // 
            // _dgvSummary
            // 
            this._dgvSummary.AllowUserToAddRows = false;
            this._dgvSummary.AllowUserToDeleteRows = false;
            this._dgvSummary.AllowUserToResizeRows = false;
            this._dgvSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dgvSummary.BackgroundColor = System.Drawing.Color.White;
            this._dgvSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dgvSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dgvSummary.Location = new System.Drawing.Point(3, 3);
            this._dgvSummary.Name = "_dgvSummary";
            this._dgvSummary.ReadOnly = true;
            this._dgvSummary.RowHeadersVisible = false;
            this._dgvSummary.RowTemplate.Height = 25;
            this._dgvSummary.Size = new System.Drawing.Size(570, 77);
            this._dgvSummary.TabIndex = 0;
            // 
            // _tabPopulation
            // 
            this._tabPopulation.Location = new System.Drawing.Point(4, 24);
            this._tabPopulation.Name = "_tabPopulation";
            this._tabPopulation.Padding = new System.Windows.Forms.Padding(3);
            this._tabPopulation.Size = new System.Drawing.Size(576, 83);
            this._tabPopulation.TabIndex = 1;
            this._tabPopulation.Text = "Population";
            this._tabPopulation.UseVisualStyleBackColor = true;
            // 
            // _statusMain
            // 
            this._statusMain.Location = new System.Drawing.Point(0, 339);
            this._statusMain.Name = "_statusMain";
            this._statusMain.Size = new System.Drawing.Size(584, 22);
            this._statusMain.TabIndex = 0;
            // 
            // _menuStripMain
            // 
            this._menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuFile,
            this._menuView,
            this._menuTsp,
            this._menuHelp});
            this._menuStripMain.Location = new System.Drawing.Point(0, 0);
            this._menuStripMain.Name = "_menuStripMain";
            this._menuStripMain.Size = new System.Drawing.Size(584, 24);
            this._menuStripMain.TabIndex = 0;
            // 
            // _menuFile
            // 
            this._menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mniOpenTsp,
            this._mniExportTspSep,
            this._mniExportTsp,
            this._mniExitSep,
            this._mniExit});
            this._menuFile.Name = "_menuFile";
            this._menuFile.Size = new System.Drawing.Size(37, 20);
            this._menuFile.Text = "File";
            // 
            // _mniOpenTsp
            // 
            this._mniOpenTsp.Name = "_mniOpenTsp";
            this._mniOpenTsp.Size = new System.Drawing.Size(180, 22);
            this._mniOpenTsp.Text = "Open...";
            this._mniOpenTsp.Click += new System.EventHandler(this._mniOpenTsp_Click);
            // 
            // _mniExportTspSep
            // 
            this._mniExportTspSep.Name = "_mniExportTspSep";
            this._mniExportTspSep.Size = new System.Drawing.Size(177, 6);
            // 
            // _mniExportTsp
            // 
            this._mniExportTsp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mniExportTspToDistances,
            this._mniExportTspToGraph});
            this._mniExportTsp.Name = "_mniExportTsp";
            this._mniExportTsp.Size = new System.Drawing.Size(180, 22);
            this._mniExportTsp.Text = "Export";
            // 
            // _mniExportTspToDistances
            // 
            this._mniExportTspToDistances.Name = "_mniExportTspToDistances";
            this._mniExportTspToDistances.Size = new System.Drawing.Size(180, 22);
            this._mniExportTspToDistances.Text = "Distances...";
            this._mniExportTspToDistances.Click += new System.EventHandler(this._mniExportTspToDistances_Click);
            // 
            // _mniExportTspToGraph
            // 
            this._mniExportTspToGraph.Name = "_mniExportTspToGraph";
            this._mniExportTspToGraph.Size = new System.Drawing.Size(180, 22);
            this._mniExportTspToGraph.Text = "Graph...";
            this._mniExportTspToGraph.Click += new System.EventHandler(this._mniExportTspToGraph_Click);
            // 
            // _mniExitSep
            // 
            this._mniExitSep.Name = "_mniExitSep";
            this._mniExitSep.Size = new System.Drawing.Size(177, 6);
            // 
            // _mniExit
            // 
            this._mniExit.Name = "_mniExit";
            this._mniExit.Size = new System.Drawing.Size(180, 22);
            this._mniExit.Text = "Exit";
            this._mniExit.Click += new System.EventHandler(this._mniExit_Click);
            // 
            // _menuView
            // 
            this._menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mniViewSetup,
            this._mniViewResults});
            this._menuView.Name = "_menuView";
            this._menuView.Size = new System.Drawing.Size(44, 20);
            this._menuView.Text = "View";
            // 
            // _mniViewSetup
            // 
            this._mniViewSetup.Name = "_mniViewSetup";
            this._mniViewSetup.Size = new System.Drawing.Size(180, 22);
            this._mniViewSetup.Text = "Setup";
            this._mniViewSetup.Click += new System.EventHandler(this._mniViewSetup_Click);
            // 
            // _mniViewResults
            // 
            this._mniViewResults.Name = "_mniViewResults";
            this._mniViewResults.Size = new System.Drawing.Size(180, 22);
            this._mniViewResults.Text = "Results";
            this._mniViewResults.Click += new System.EventHandler(this._mniViewResults_Click);
            // 
            // _menuTsp
            // 
            this._menuTsp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mniSolveTsp});
            this._menuTsp.Name = "_menuTsp";
            this._menuTsp.Size = new System.Drawing.Size(38, 20);
            this._menuTsp.Text = "TSP";
            // 
            // _mniSolveTsp
            // 
            this._mniSolveTsp.Name = "_mniSolveTsp";
            this._mniSolveTsp.Size = new System.Drawing.Size(180, 22);
            this._mniSolveTsp.Text = "Solve TSP";
            this._mniSolveTsp.Click += new System.EventHandler(this._mniSolveTsp_Click);
            // 
            // _menuHelp
            // 
            this._menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._mniAbout});
            this._menuHelp.Name = "_menuHelp";
            this._menuHelp.Size = new System.Drawing.Size(44, 20);
            this._menuHelp.Text = "Help";
            // 
            // _mniAbout
            // 
            this._mniAbout.Name = "_mniAbout";
            this._mniAbout.Size = new System.Drawing.Size(180, 22);
            this._mniAbout.Text = "About";
            this._mniAbout.Click += new System.EventHandler(this._mniAbout_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this._pnlMain);
            this.MainMenuStrip = this._menuStripMain;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FrmMain";
            this.Text = "TSP GA Solver";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this._pnlMain.ResumeLayout(false);
            this._pnlMain.PerformLayout();
            this._splitMain.Panel1.ResumeLayout(false);
            this._splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitMain)).EndInit();
            this._splitMain.ResumeLayout(false);
            this._splitTsp.Panel1.ResumeLayout(false);
            this._splitTsp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitTsp)).EndInit();
            this._splitTsp.ResumeLayout(false);
            this._pnlSetup.ResumeLayout(false);
            this._tabControlSetup.ResumeLayout(false);
            this._tabNodes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvNodes)).EndInit();
            this._tabEdges.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvEdges)).EndInit();
            this._tabCoordinates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvCoordinates)).EndInit();
            this._pnlTsp.ResumeLayout(false);
            this._tabControlTsp.ResumeLayout(false);
            this._tabDistances.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvDistances)).EndInit();
            this._tabGraph.ResumeLayout(false);
            this._tabGraph.PerformLayout();
            this._pnlCanvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pbxCanvas)).EndInit();
            this._pnlResult.ResumeLayout(false);
            this._tabControlResults.ResumeLayout(false);
            this._tabSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dgvSummary)).EndInit();
            this._menuStripMain.ResumeLayout(false);
            this._menuStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _pnlMain;
        private System.Windows.Forms.SplitContainer _splitTsp;
        private System.Windows.Forms.MenuStrip _menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem _menuFile;
        private System.Windows.Forms.ToolStripMenuItem _mniOpenTsp;
        private System.Windows.Forms.ToolStripSeparator _mniExitSep;
        private System.Windows.Forms.ToolStripMenuItem _mniExit;
        private System.Windows.Forms.ToolStripMenuItem _menuTsp;
        private System.Windows.Forms.SplitContainer _splitMain;
        private System.Windows.Forms.ToolStripMenuItem _mniSolveTsp;
        private System.Windows.Forms.ToolStripMenuItem _menuHelp;
        private System.Windows.Forms.ToolStripMenuItem _mniAbout;
        private System.Windows.Forms.Panel _pnlSetup;
        private System.Windows.Forms.Panel _pnlTsp;
        private System.Windows.Forms.Panel _pnlResult;
        private System.Windows.Forms.StatusStrip _statusMain;
        private System.Windows.Forms.PictureBox _pbxCanvas;
        private System.Windows.Forms.TabControl _tabControlTsp;
        private System.Windows.Forms.TabPage _tabDistances;
        private System.Windows.Forms.DataGridView _dgvDistances;
        private System.Windows.Forms.TabPage _tabGraph;
        private System.Windows.Forms.DataGridView _dgvSummary;
        private System.Windows.Forms.TabControl _tabControlResults;
        private System.Windows.Forms.TabPage _tabSummary;
        private System.Windows.Forms.TabPage _tabPopulation;
        private System.Windows.Forms.TabControl _tabControlSetup;
        private System.Windows.Forms.TabPage _tabSetup;
        private System.Windows.Forms.TabPage _tabEdges;
        private System.Windows.Forms.DataGridView _dgvEdges;
        private System.Windows.Forms.ToolStripMenuItem _menuView;
        private System.Windows.Forms.ToolStripMenuItem _mniViewSetup;
        private System.Windows.Forms.ToolStripMenuItem _mniViewResults;
        private System.Windows.Forms.TabPage _tabNodes;
        private System.Windows.Forms.DataGridView _dgvNodes;
        private System.Windows.Forms.TabPage _tabCoordinates;
        private System.Windows.Forms.DataGridView _dgvCoordinates;
        private System.Windows.Forms.ToolStripMenuItem _mniExportTsp;
        private System.Windows.Forms.ToolStripMenuItem _mniExportTspToDistances;
        private System.Windows.Forms.ToolStripMenuItem _mniExportTspToGraph;
        private System.Windows.Forms.Panel _pnlCanvas;
        private System.Windows.Forms.ToolStripSeparator _mniExportTspSep;
    }
}

