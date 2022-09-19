
namespace App.Gui
{
    partial class FrmProperties
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
            this._pnlMain = new System.Windows.Forms.Panel();
            this._tablePanelMain = new System.Windows.Forms.TableLayoutPanel();
            this._lblName = new System.Windows.Forms.Label();
            this._tbxName = new System.Windows.Forms.TextBox();
            this._lblDescription = new System.Windows.Forms.Label();
            this._tbxDescription = new System.Windows.Forms.TextBox();
            this._tablePanelActions = new System.Windows.Forms.TableLayoutPanel();
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this._pnlMain.SuspendLayout();
            this._tablePanelMain.SuspendLayout();
            this._tablePanelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pnlMain
            // 
            this._pnlMain.Controls.Add(this._tablePanelMain);
            this._pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._pnlMain.Location = new System.Drawing.Point(0, 0);
            this._pnlMain.Name = "_pnlMain";
            this._pnlMain.Size = new System.Drawing.Size(584, 361);
            this._pnlMain.TabIndex = 0;
            // 
            // _tablePanelMain
            // 
            this._tablePanelMain.ColumnCount = 3;
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tablePanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this._tablePanelMain.Controls.Add(this._lblName, 1, 0);
            this._tablePanelMain.Controls.Add(this._lblDescription, 1, 2);
            this._tablePanelMain.Controls.Add(this._tbxDescription, 1, 3);
            this._tablePanelMain.Controls.Add(this._tbxName, 1, 1);
            this._tablePanelMain.Controls.Add(this._tablePanelActions, 1, 4);
            this._tablePanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tablePanelMain.Location = new System.Drawing.Point(0, 0);
            this._tablePanelMain.Name = "_tablePanelMain";
            this._tablePanelMain.RowCount = 5;
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tablePanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this._tablePanelMain.Size = new System.Drawing.Size(584, 361);
            this._tablePanelMain.TabIndex = 0;
            // 
            // _lblName
            // 
            this._lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblName.AutoSize = true;
            this._lblName.Location = new System.Drawing.Point(28, 10);
            this._lblName.Name = "_lblName";
            this._lblName.Size = new System.Drawing.Size(39, 15);
            this._lblName.TabIndex = 0;
            this._lblName.Text = "Name";
            // 
            // _tbxName
            // 
            this._tbxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tbxName.Location = new System.Drawing.Point(28, 28);
            this._tbxName.Name = "_tbxName";
            this._tbxName.Size = new System.Drawing.Size(528, 23);
            this._tbxName.TabIndex = 1;
            // 
            // _lblDescription
            // 
            this._lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._lblDescription.AutoSize = true;
            this._lblDescription.Location = new System.Drawing.Point(28, 64);
            this._lblDescription.Name = "_lblDescription";
            this._lblDescription.Size = new System.Drawing.Size(67, 15);
            this._lblDescription.TabIndex = 2;
            this._lblDescription.Text = "Description";
            // 
            // _tbxDescription
            // 
            this._tbxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tbxDescription.Location = new System.Drawing.Point(28, 82);
            this._tbxDescription.Multiline = true;
            this._tbxDescription.Name = "_tbxDescription";
            this._tbxDescription.Size = new System.Drawing.Size(528, 226);
            this._tbxDescription.TabIndex = 3;
            // 
            // _tablePanelActions
            // 
            this._tablePanelActions.ColumnCount = 3;
            this._tablePanelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tablePanelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tablePanelActions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tablePanelActions.Controls.Add(this._btnSave, 2, 1);
            this._tablePanelActions.Controls.Add(this._btnCancel, 1, 1);
            this._tablePanelActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tablePanelActions.Location = new System.Drawing.Point(28, 314);
            this._tablePanelActions.Name = "_tablePanelActions";
            this._tablePanelActions.RowCount = 3;
            this._tablePanelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tablePanelActions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanelActions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this._tablePanelActions.Size = new System.Drawing.Size(528, 44);
            this._tablePanelActions.TabIndex = 4;
            // 
            // _btnSave
            // 
            this._btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this._btnSave.Location = new System.Drawing.Point(450, 10);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 0;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            // 
            // _btnCancel
            // 
            this._btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
            this._btnCancel.Location = new System.Drawing.Point(369, 10);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 1;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this._pnlMain);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FrmProperties";
            this.Text = "File Properties";
            this._pnlMain.ResumeLayout(false);
            this._tablePanelMain.ResumeLayout(false);
            this._tablePanelMain.PerformLayout();
            this._tablePanelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _pnlMain;
        private System.Windows.Forms.TableLayoutPanel _tablePanelMain;
        private System.Windows.Forms.Label _lblName;
        private System.Windows.Forms.TextBox _tbxName;
        private System.Windows.Forms.Label _lblDescription;
        private System.Windows.Forms.TextBox _tbxDescription;
        private System.Windows.Forms.TableLayoutPanel _tablePanelActions;
        private System.Windows.Forms.Button _btnSave;
        private System.Windows.Forms.Button _btnCancel;
    }
}