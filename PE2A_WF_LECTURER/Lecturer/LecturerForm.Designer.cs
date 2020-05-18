namespace PE2A_WF_Lecturer
{
    partial class LecturerForm
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
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScriptCodes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubmitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EvaluateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Close = new System.Windows.Forms.DataGridViewImageColumn();
            this.gbSubmitedFiles = new System.Windows.Forms.GroupBox();
            this.menuAction = new System.Windows.Forms.MenuStrip();
            this.publishPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.lbTime = new System.Windows.Forms.Label();
            this.cbDuplicatedCode = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.gbSubmitedFiles.SuspendLayout();
            this.menuAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStudent
            // 
            this.dgvStudent.AllowUserToAddRows = false;
            this.dgvStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudent.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.StudentCode,
            this.StudentName,
            this.ScriptCodes,
            this.Status,
            this.TotalPoint,
            this.SubmitTime,
            this.EvaluateTime,
            this.Result,
            this.Error,
            this.Close});
            this.dgvStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudent.Location = new System.Drawing.Point(8, 56);
            this.dgvStudent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.RowHeadersWidth = 62;
            this.dgvStudent.RowTemplate.Height = 28;
            this.dgvStudent.Size = new System.Drawing.Size(1358, 655);
            this.dgvStudent.TabIndex = 0;
            this.dgvStudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellContentClick);
            this.dgvStudent.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellDoubleClick);
            // 
            // No
            // 
            this.No.HeaderText = "NO";
            this.No.MinimumWidth = 8;
            this.No.Name = "No";
            // 
            // StudentCode
            // 
            this.StudentCode.HeaderText = "Student Code";
            this.StudentCode.MinimumWidth = 8;
            this.StudentCode.Name = "StudentCode";
            // 
            // StudentName
            // 
            this.StudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StudentName.HeaderText = "Student Name";
            this.StudentName.MinimumWidth = 8;
            this.StudentName.Name = "StudentName";
            this.StudentName.Width = 183;
            // 
            // ScriptCodes
            // 
            this.ScriptCodes.HeaderText = "Script Code";
            this.ScriptCodes.MinimumWidth = 8;
            this.ScriptCodes.Name = "ScriptCodes";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            // 
            // TotalPoint
            // 
            this.TotalPoint.HeaderText = "Total Point";
            this.TotalPoint.MinimumWidth = 8;
            this.TotalPoint.Name = "TotalPoint";
            // 
            // SubmitTime
            // 
            this.SubmitTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SubmitTime.HeaderText = "Submit Time";
            this.SubmitTime.MinimumWidth = 8;
            this.SubmitTime.Name = "SubmitTime";
            this.SubmitTime.Width = 167;
            // 
            // EvaluateTime
            // 
            this.EvaluateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EvaluateTime.HeaderText = "Evaluate Time";
            this.EvaluateTime.MinimumWidth = 8;
            this.EvaluateTime.Name = "EvaluateTime";
            this.EvaluateTime.Width = 183;
            // 
            // Result
            // 
            this.Result.HeaderText = "Result";
            this.Result.MinimumWidth = 8;
            this.Result.Name = "Result";
            // 
            // Error
            // 
            this.Error.HeaderText = "Error";
            this.Error.MinimumWidth = 8;
            this.Error.Name = "Error";
            // 
            // Close
            // 
            this.Close.HeaderText = "Action";
            this.Close.MinimumWidth = 8;
            this.Close.Name = "Close";
            this.Close.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Close.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gbSubmitedFiles
            // 
            this.gbSubmitedFiles.Controls.Add(this.dgvStudent);
            this.gbSubmitedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSubmitedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSubmitedFiles.Location = new System.Drawing.Point(0, 33);
            this.gbSubmitedFiles.Margin = new System.Windows.Forms.Padding(0);
            this.gbSubmitedFiles.Name = "gbSubmitedFiles";
            this.gbSubmitedFiles.Padding = new System.Windows.Forms.Padding(8, 31, 4, 5);
            this.gbSubmitedFiles.Size = new System.Drawing.Size(1370, 716);
            this.gbSubmitedFiles.TabIndex = 2;
            this.gbSubmitedFiles.TabStop = false;
            // 
            // menuAction
            // 
            this.menuAction.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuAction.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.publishPointToolStripMenuItem,
            this.printReportToolStripMenuItem,
            this.startToolStripMenuItem1});
            this.menuAction.Location = new System.Drawing.Point(0, 0);
            this.menuAction.Name = "menuAction";
            this.menuAction.Size = new System.Drawing.Size(1370, 33);
            this.menuAction.TabIndex = 3;
            this.menuAction.Text = "menuStrip1";
            // 
            // publishPointToolStripMenuItem
            // 
            this.publishPointToolStripMenuItem.Image = global::PE2A_WF_Lecturer.Properties.Resources.icShare;
            this.publishPointToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.publishPointToolStripMenuItem.Name = "publishPointToolStripMenuItem";
            this.publishPointToolStripMenuItem.Size = new System.Drawing.Size(144, 29);
            this.publishPointToolStripMenuItem.Text = "Publish Point";
            this.publishPointToolStripMenuItem.Click += new System.EventHandler(this.publishPointMenu_Click);
            // 
            // printReportToolStripMenuItem
            // 
            this.printReportToolStripMenuItem.Image = global::PE2A_WF_Lecturer.Properties.Resources.icPrint;
            this.printReportToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.printReportToolStripMenuItem.Name = "printReportToolStripMenuItem";
            this.printReportToolStripMenuItem.Size = new System.Drawing.Size(134, 29);
            this.printReportToolStripMenuItem.Text = "Print Report";
            this.printReportToolStripMenuItem.Click += new System.EventHandler(this.printReportToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem1
            // 
            this.startToolStripMenuItem1.Name = "startToolStripMenuItem1";
            this.startToolStripMenuItem1.Size = new System.Drawing.Size(64, 29);
            this.startToolStripMenuItem1.Text = "Start";
            this.startToolStripMenuItem1.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(365, 5);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(211, 26);
            this.txtTime.TabIndex = 4;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.BackColor = System.Drawing.SystemColors.Control;
            this.lbTime.Location = new System.Drawing.Point(582, 11);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(65, 20);
            this.lbTime.TabIndex = 5;
            this.lbTime.Text = "Minutes";
            // 
            // cbDuplicatedCode
            // 
            this.cbDuplicatedCode.AutoSize = true;
            this.cbDuplicatedCode.Checked = true;
            this.cbDuplicatedCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDuplicatedCode.Location = new System.Drawing.Point(691, 7);
            this.cbDuplicatedCode.Name = "cbDuplicatedCode";
            this.cbDuplicatedCode.Size = new System.Drawing.Size(202, 24);
            this.cbDuplicatedCode.TabIndex = 7;
            this.cbDuplicatedCode.Text = "Check Duplicated Code";
            this.cbDuplicatedCode.UseVisualStyleBackColor = true;
            // 
            // LecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.cbDuplicatedCode);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.gbSubmitedFiles);
            this.Controls.Add(this.menuAction);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "LecturerForm";
            this.Text = "LECTURER FORM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LecturerForm_FormClosing);
            this.Load += new System.EventHandler(this.LecturerForm_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.gbSubmitedFiles.ResumeLayout(false);
            this.menuAction.ResumeLayout(false);
            this.menuAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.GroupBox gbSubmitedFiles;
        private System.Windows.Forms.MenuStrip menuAction;
        private System.Windows.Forms.ToolStripMenuItem publishPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printReportToolStripMenuItem;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScriptCodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubmitTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EvaluateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error;
        private System.Windows.Forms.DataGridViewImageColumn Close;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem1;
        private System.Windows.Forms.CheckBox cbDuplicatedCode;
    }
}