namespace PE2A_WF_Lecturer
{
    partial class ImportScriptForm
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
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvScriptFiles = new System.Windows.Forms.DataGridView();
            this.dgvHeaderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHeaderPracticaExamCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHeaderSubjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScriptFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // ImportTemplateToolStripMenuItem
            // 
            this.ImportTemplateToolStripMenuItem.Name = "ImportTemplateToolStripMenuItem";
            this.ImportTemplateToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.dgvScriptFiles);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(16, 12, 16, 18);
            this.panel2.Size = new System.Drawing.Size(1078, 771);
            this.panel2.TabIndex = 1;
            // 
            // dgvScriptFiles
            // 
            this.dgvScriptFiles.AllowUserToAddRows = false;
            this.dgvScriptFiles.AllowUserToDeleteRows = false;
            this.dgvScriptFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvScriptFiles.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvScriptFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScriptFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvHeaderNo,
            this.dgvHeaderPracticaExamCode,
            this.dgvHeaderSubjectCode,
            this.date,
            this.status,
            this.Action});
            this.dgvScriptFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScriptFiles.GridColor = System.Drawing.SystemColors.Control;
            this.dgvScriptFiles.Location = new System.Drawing.Point(16, 12);
            this.dgvScriptFiles.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgvScriptFiles.Name = "dgvScriptFiles";
            this.dgvScriptFiles.ReadOnly = true;
            this.dgvScriptFiles.RowHeadersWidth = 62;
            this.dgvScriptFiles.RowTemplate.Height = 24;
            this.dgvScriptFiles.Size = new System.Drawing.Size(1046, 741);
            this.dgvScriptFiles.TabIndex = 0;
            this.dgvScriptFiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScriptFiles_CellClick);
            // 
            // dgvHeaderNo
            // 
            this.dgvHeaderNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvHeaderNo.HeaderText = "No";
            this.dgvHeaderNo.MinimumWidth = 60;
            this.dgvHeaderNo.Name = "dgvHeaderNo";
            this.dgvHeaderNo.ReadOnly = true;
            this.dgvHeaderNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvHeaderNo.Width = 60;
            // 
            // dgvHeaderPracticaExamCode
            // 
            this.dgvHeaderPracticaExamCode.HeaderText = "Practical Exam Code";
            this.dgvHeaderPracticaExamCode.MinimumWidth = 8;
            this.dgvHeaderPracticaExamCode.Name = "dgvHeaderPracticaExamCode";
            this.dgvHeaderPracticaExamCode.ReadOnly = true;
            this.dgvHeaderPracticaExamCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dgvHeaderSubjectCode
            // 
            this.dgvHeaderSubjectCode.HeaderText = "Subject Code";
            this.dgvHeaderSubjectCode.MinimumWidth = 8;
            this.dgvHeaderSubjectCode.Name = "dgvHeaderSubjectCode";
            this.dgvHeaderSubjectCode.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "Date";
            this.date.MinimumWidth = 8;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.MinimumWidth = 8;
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.MinimumWidth = 8;
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ImportScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 771);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "ImportScriptForm";
            this.Text = "Import Script";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportScriptForm_FormClosing);
            this.Load += new System.EventHandler(this.ImportScriptForm_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScriptFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportTemplateToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvScriptFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHeaderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHeaderPracticaExamCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHeaderSubjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewButtonColumn Action;
    }
}