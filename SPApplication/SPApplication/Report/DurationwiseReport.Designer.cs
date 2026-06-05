namespace SPApplication
{
    partial class DurationwiseReport
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.cbToday = new System.Windows.Forms.CheckBox();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lbUnitNumber = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPresentDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLeavesDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCompOffDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSalaryDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAbsent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOverTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.tlpAttendance = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1200, 30);
            this.lblHeader.TabIndex = 24;
            this.lblHeader.Text = "Database";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbToday
            // 
            this.cbToday.AutoSize = true;
            this.cbToday.Location = new System.Drawing.Point(724, 36);
            this.cbToday.Name = "cbToday";
            this.cbToday.Size = new System.Drawing.Size(58, 19);
            this.cbToday.TabIndex = 11423;
            this.cbToday.Text = "Today";
            this.cbToday.UseVisualStyleBackColor = true;
            this.cbToday.CheckedChanged += new System.EventHandler(this.cbToday_CheckedChanged);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(569, 39);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(47, 15);
            this.lblToDate.TabIndex = 11425;
            this.lblToDate.Text = "To Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(618, 35);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(100, 23);
            this.dtpToDate.TabIndex = 11422;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(376, 41);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(63, 15);
            this.lblFromDate.TabIndex = 11424;
            this.lblFromDate.Text = "From Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(465, 35);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(100, 23);
            this.dtpFromDate.TabIndex = 11421;
            // 
            // btnReport
            // 
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Location = new System.Drawing.Point(481, 112);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 30);
            this.btnReport.TabIndex = 11420;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnView
            // 
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnView.Location = new System.Drawing.Point(1091, 59);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 30);
            this.btnView.TabIndex = 11419;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(642, 112);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11418;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(562, 112);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11417;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(465, 83);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(321, 23);
            this.cmbDepartment.TabIndex = 11416;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(376, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 11415;
            this.label8.Text = "Department";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(465, 59);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(321, 23);
            this.cmbLocation.TabIndex = 11414;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // lbUnitNumber
            // 
            this.lbUnitNumber.AutoSize = true;
            this.lbUnitNumber.Location = new System.Drawing.Point(376, 63);
            this.lbUnitNumber.Name = "lbUnitNumber";
            this.lbUnitNumber.Size = new System.Drawing.Size(87, 15);
            this.lbUnitNumber.TabIndex = 11413;
            this.lbUnitNumber.Text = "Location Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmEmployeeId,
            this.clmEmployeeCode,
            this.clmEmployeeName,
            this.clmPresentDays,
            this.clmLeavesDays,
            this.clmCompOffDays,
            this.clmSalaryDays,
            this.clmAbsent,
            this.clmOverTime});
            this.dataGridView1.Location = new System.Drawing.Point(19, 201);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1074, 126);
            this.dataGridView1.TabIndex = 11426;
            // 
            // clmEmployeeId
            // 
            this.clmEmployeeId.HeaderText = "Employee Id";
            this.clmEmployeeId.Name = "clmEmployeeId";
            this.clmEmployeeId.ReadOnly = true;
            this.clmEmployeeId.Visible = false;
            // 
            // clmEmployeeCode
            // 
            this.clmEmployeeCode.HeaderText = "Employee Code";
            this.clmEmployeeCode.Name = "clmEmployeeCode";
            this.clmEmployeeCode.ReadOnly = true;
            this.clmEmployeeCode.Width = 120;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.HeaderText = "Employee Name";
            this.clmEmployeeName.Name = "clmEmployeeName";
            this.clmEmployeeName.ReadOnly = true;
            this.clmEmployeeName.Width = 200;
            // 
            // clmPresentDays
            // 
            this.clmPresentDays.HeaderText = "Present Days";
            this.clmPresentDays.Name = "clmPresentDays";
            this.clmPresentDays.ReadOnly = true;
            this.clmPresentDays.Width = 120;
            // 
            // clmLeavesDays
            // 
            this.clmLeavesDays.HeaderText = "Leaves Days";
            this.clmLeavesDays.Name = "clmLeavesDays";
            this.clmLeavesDays.ReadOnly = true;
            this.clmLeavesDays.Width = 120;
            // 
            // clmCompOffDays
            // 
            this.clmCompOffDays.HeaderText = "Comp Off Days";
            this.clmCompOffDays.Name = "clmCompOffDays";
            this.clmCompOffDays.ReadOnly = true;
            this.clmCompOffDays.Width = 120;
            // 
            // clmSalaryDays
            // 
            this.clmSalaryDays.HeaderText = "Salary Days";
            this.clmSalaryDays.Name = "clmSalaryDays";
            this.clmSalaryDays.ReadOnly = true;
            this.clmSalaryDays.Width = 120;
            // 
            // clmAbsent
            // 
            this.clmAbsent.HeaderText = "Absent";
            this.clmAbsent.Name = "clmAbsent";
            this.clmAbsent.ReadOnly = true;
            this.clmAbsent.Width = 120;
            // 
            // clmOverTime
            // 
            this.clmOverTime.HeaderText = "Over Time (in Hours)";
            this.clmOverTime.Name = "clmOverTime";
            this.clmOverTime.ReadOnly = true;
            this.clmOverTime.Width = 150;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(16, 131);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11427;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // tlpAttendance
            // 
            this.tlpAttendance.ColumnCount = 2;
            this.tlpAttendance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAttendance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAttendance.Location = new System.Drawing.Point(346, 396);
            this.tlpAttendance.Name = "tlpAttendance";
            this.tlpAttendance.RowCount = 2;
            this.tlpAttendance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAttendance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpAttendance.Size = new System.Drawing.Size(200, 100);
            this.tlpAttendance.TabIndex = 11428;
            // 
            // DurationwiseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 698);
            this.ControlBox = false;
            this.Controls.Add(this.tlpAttendance);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbToday);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lbUnitNumber);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DurationwiseReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DurationwiseReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.CheckBox cbToday;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lbUnitNumber;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPresentDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLeavesDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCompOffDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSalaryDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAbsent;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOverTime;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.TableLayoutPanel tlpAttendance;
    }
}