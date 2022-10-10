
namespace App.Gui
{
    partial class FrmAbout
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
            this._lblName = new System.Windows.Forms.Label();
            this._lblAuthorDate = new System.Windows.Forms.Label();
            this._btnClose = new System.Windows.Forms.Button();
            this._lblDescription = new System.Windows.Forms.Label();
            this._tablePanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tablePanelMain
            // 
            this._tablePanelMain.ColumnCount = 4;
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.Controls.Add(this._lblName, 1, 1);
            this._tablePanelMain.Controls.Add(this._lblAuthorDate, 1, 3);
            this._tablePanelMain.Controls.Add(this._btnClose, 2, 7);
            this._tablePanelMain.Controls.Add(this._lblDescription, 1, 5);
            this._tablePanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tablePanelMain.Location = new System.Drawing.Point(0, 0);
            this._tablePanelMain.Name = "_tablePanelMain";
            this._tablePanelMain.RowCount = 9;
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this._tablePanelMain.Size = new System.Drawing.Size(384, 261);
            this._tablePanelMain.TabIndex = 0;
            // 
            // _lblName
            // 
            this._lblName.AutoSize = true;
            this._tablePanelMain.SetColumnSpan(this._lblName, 2);
            this._lblName.Location = new System.Drawing.Point(13, 10);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(80, 15);
            this._lblName.TabIndex = 1;
            this._lblName.Text = "TSP GA Solver";
            // 
            // _lblAuthorDate
            // 
            this._lblAuthorDate.AutoSize = true;
            this._tablePanelMain.SetColumnSpan(this._lblAuthorDate, 2);
            this._lblAuthorDate.Location = new System.Drawing.Point(13, 40);
            this._lblAuthorDate.Name = "_lblAuthorDate";
            this._lblAuthorDate.Size = new System.Drawing.Size(31, 15);
            this._lblAuthorDate.TabIndex = 2;
            this._lblAuthorDate.Text = "2022";
            // 
            // _btnClose
            // 
            this._btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this._btnClose.Location = new System.Drawing.Point(299, 228);
            this._btnClose.Margin = new System.Windows.Forms.Padding(0);
            this._btnClose.Name = "_btnClose";
            this._btnClose.Size = new System.Drawing.Size(75, 23);
            this._btnClose.TabIndex = 0;
            this._btnClose.Text = "Close";
            this._btnClose.UseVisualStyleBackColor = true;
            this._btnClose.Click += new System.EventHandler(this._btnClose_Click);
            // 
            // _lblDescription
            // 
            this._tablePanelMain.SetColumnSpan(this._lblDescription, 2);
            this._lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this._lblDescription.Location = new System.Drawing.Point(13, 70);
            this._lblDescription.Name = "_lblDescription";
            this._lblDescription.Size = new System.Drawing.Size(358, 143);
            this._lblDescription.TabIndex = 3;
            // 
            // FrmAbout
            // 
            this.AcceptButton = this._btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this._tablePanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "FrmAbout";
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            this._tablePanelMain.ResumeLayout(false);
            this._tablePanelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tablePanelMain;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.Label _lblAuthorDate;
        private System.Windows.Forms.Label _lblDescription;
        private System.Windows.Forms.Button _btnClose;
    }
}