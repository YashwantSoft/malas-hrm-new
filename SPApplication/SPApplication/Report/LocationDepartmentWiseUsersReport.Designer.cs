namespace SPApplication.Report
{
    partial class LocationDepartmentWiseUsersReport
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
            this.btnReport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.cbSelectAllLocation = new System.Windows.Forms.CheckBox();
            this.cbSelectAllDepartment = new System.Windows.Forms.CheckBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRoll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPresentDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLeavesDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHoliday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSalaryDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRegularOvertime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmWOOTHrs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalOTHrs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAbsent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCompOffDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCompOffUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmWeeklyOff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmWeeklyOffPresent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalWorkableHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Location = new System.Drawing.Point(981, 35);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 30);
            this.btnReport.TabIndex = 11412;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(1141, 35);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11411;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(1061, 35);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11410;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1231, 30);
            this.lblHeader.TabIndex = 11413;
            this.lblHeader.Text = "Database";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbSelectAllLocation
            // 
            this.cbSelectAllLocation.AutoSize = true;
            this.cbSelectAllLocation.Location = new System.Drawing.Point(11, 42);
            this.cbSelectAllLocation.Name = "cbSelectAllLocation";
            this.cbSelectAllLocation.Size = new System.Drawing.Size(72, 19);
            this.cbSelectAllLocation.TabIndex = 11457;
            this.cbSelectAllLocation.Text = "Location";
            this.cbSelectAllLocation.UseVisualStyleBackColor = true;
            // 
            // cbSelectAllDepartment
            // 
            this.cbSelectAllDepartment.AutoSize = true;
            this.cbSelectAllDepartment.Location = new System.Drawing.Point(339, 42);
            this.cbSelectAllDepartment.Name = "cbSelectAllDepartment";
            this.cbSelectAllDepartment.Size = new System.Drawing.Size(90, 19);
            this.cbSelectAllDepartment.TabIndex = 11456;
            this.cbSelectAllDepartment.Text = "Department";
            this.cbSelectAllDepartment.UseVisualStyleBackColor = true;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(431, 40);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(224, 23);
            this.cmbDepartment.TabIndex = 11455;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(85, 40);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(224, 23);
            this.cmbLocation.TabIndex = 11454;
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
            this.clmLocation,
            this.clmDepartment,
            this.clmRoll,
            this.clmEmployeeId,
            this.clmEmployeeCode,
            this.clmEmployeeName,
            this.clmPresentDays,
            this.clmLeavesDays,
            this.clmHoliday,
            this.clmSalaryDays,
            this.clmRegularOvertime,
            this.clmWOOTHrs,
            this.clmTotalOTHrs,
            this.clmAbsent,
            this.clmCompOffDays,
            this.clmCompOffUsed,
            this.clmWeeklyOff,
            this.clmWeeklyOffPresent,
            this.clmTotalDays,
            this.clmTotalHours,
            this.clmTotalWorkableHours});
            this.dataGridView1.Location = new System.Drawing.Point(11, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1205, 398);
            this.dataGridView1.TabIndex = 11458;
            // 
            // clmLocation
            // 
            this.clmLocation.HeaderText = "Location";
            this.clmLocation.Name = "clmLocation";
            this.clmLocation.ReadOnly = true;
            // 
            // clmDepartment
            // 
            this.clmDepartment.HeaderText = "Department";
            this.clmDepartment.Name = "clmDepartment";
            this.clmDepartment.ReadOnly = true;
            // 
            // clmRoll
            // 
            this.clmRoll.HeaderText = "Roll";
            this.clmRoll.Name = "clmRoll";
            this.clmRoll.ReadOnly = true;
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
            this.clmEmployeeCode.Width = 80;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.HeaderText = "Employee Name";
            this.clmEmployeeName.Name = "clmEmployeeName";
            this.clmEmployeeName.ReadOnly = true;
            this.clmEmployeeName.Width = 250;
            // 
            // clmPresentDays
            // 
            this.clmPresentDays.HeaderText = "Present Days";
            this.clmPresentDays.Name = "clmPresentDays";
            this.clmPresentDays.ReadOnly = true;
            this.clmPresentDays.Width = 80;
            // 
            // clmLeavesDays
            // 
            this.clmLeavesDays.HeaderText = "Leaves Days";
            this.clmLeavesDays.Name = "clmLeavesDays";
            this.clmLeavesDays.ReadOnly = true;
            this.clmLeavesDays.Width = 80;
            // 
            // clmHoliday
            // 
            this.clmHoliday.HeaderText = "Holiday";
            this.clmHoliday.Name = "clmHoliday";
            this.clmHoliday.ReadOnly = true;
            this.clmHoliday.Width = 80;
            // 
            // clmSalaryDays
            // 
            this.clmSalaryDays.HeaderText = "Salary Days";
            this.clmSalaryDays.Name = "clmSalaryDays";
            this.clmSalaryDays.ReadOnly = true;
            // 
            // clmRegularOvertime
            // 
            this.clmRegularOvertime.HeaderText = "Regular Overtime";
            this.clmRegularOvertime.Name = "clmRegularOvertime";
            this.clmRegularOvertime.ReadOnly = true;
            // 
            // clmWOOTHrs
            // 
            this.clmWOOTHrs.HeaderText = "WO OT hrs.";
            this.clmWOOTHrs.Name = "clmWOOTHrs";
            this.clmWOOTHrs.ReadOnly = true;
            // 
            // clmTotalOTHrs
            // 
            this.clmTotalOTHrs.HeaderText = "Total OT Hrs.";
            this.clmTotalOTHrs.Name = "clmTotalOTHrs";
            this.clmTotalOTHrs.ReadOnly = true;
            // 
            // clmAbsent
            // 
            this.clmAbsent.HeaderText = "Absent";
            this.clmAbsent.Name = "clmAbsent";
            this.clmAbsent.ReadOnly = true;
            this.clmAbsent.Width = 80;
            // 
            // clmCompOffDays
            // 
            this.clmCompOffDays.HeaderText = "Comp Off Days";
            this.clmCompOffDays.Name = "clmCompOffDays";
            this.clmCompOffDays.ReadOnly = true;
            this.clmCompOffDays.Width = 90;
            // 
            // clmCompOffUsed
            // 
            this.clmCompOffUsed.HeaderText = "Comp Off Used";
            this.clmCompOffUsed.Name = "clmCompOffUsed";
            this.clmCompOffUsed.ReadOnly = true;
            // 
            // clmWeeklyOff
            // 
            this.clmWeeklyOff.HeaderText = "Weekly Off";
            this.clmWeeklyOff.Name = "clmWeeklyOff";
            this.clmWeeklyOff.ReadOnly = true;
            // 
            // clmWeeklyOffPresent
            // 
            this.clmWeeklyOffPresent.HeaderText = "Weekly Off Present";
            this.clmWeeklyOffPresent.Name = "clmWeeklyOffPresent";
            this.clmWeeklyOffPresent.ReadOnly = true;
            // 
            // clmTotalDays
            // 
            this.clmTotalDays.HeaderText = "Total Days";
            this.clmTotalDays.Name = "clmTotalDays";
            this.clmTotalDays.ReadOnly = true;
            this.clmTotalDays.Width = 90;
            // 
            // clmTotalHours
            // 
            this.clmTotalHours.HeaderText = "Total Hours";
            this.clmTotalHours.Name = "clmTotalHours";
            this.clmTotalHours.ReadOnly = true;
            this.clmTotalHours.Width = 90;
            // 
            // clmTotalWorkableHours
            // 
            this.clmTotalWorkableHours.HeaderText = "Total Workable Hours";
            this.clmTotalWorkableHours.Name = "clmTotalWorkableHours";
            this.clmTotalWorkableHours.ReadOnly = true;
            this.clmTotalWorkableHours.Width = 80;
            // 
            // LocationDepartmentWiseUsersReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1231, 519);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbSelectAllLocation);
            this.Controls.Add(this.cbSelectAllDepartment);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "LocationDepartmentWiseUsersReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LocationDepartmentWiseUsersReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.CheckBox cbSelectAllLocation;
        private System.Windows.Forms.CheckBox cbSelectAllDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRoll;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPresentDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLeavesDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHoliday;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSalaryDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRegularOvertime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmWOOTHrs;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalOTHrs;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAbsent;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCompOffDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCompOffUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmWeeklyOff;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmWeeklyOffPresent;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalWorkableHours;
    }
}