namespace SPApplication.Report
{
    partial class AttendanceSalaryReport
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
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRoll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPresentDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLeavesDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSpecialLeaves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHoliday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHolidayPresent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSalaryDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRegularOvertime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmWOOTHrs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHolidayOTHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalOTHrs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAbsent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCompOffDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCompOffUsed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmWeeklyOff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmWeeklyOffPresent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalWorkableHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHeader = new System.Windows.Forms.Label();
            this.cbSelectAllLocation = new System.Windows.Forms.CheckBox();
            this.cbSelectAllDepartment = new System.Windows.Forms.CheckBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.cbAttendanceDate = new System.Windows.Forms.CheckBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cbRoll = new System.Windows.Forms.CheckBox();
            this.cmbRoll = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cbStatusAll = new System.Windows.Forms.CheckBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(698, 39);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(47, 15);
            this.lblToDate.TabIndex = 11428;
            this.lblToDate.Text = "To Date";
            this.lblToDate.Visible = false;
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(747, 36);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(100, 23);
            this.dtpToDate.TabIndex = 11425;
            this.dtpToDate.Visible = false;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(587, 36);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(100, 23);
            this.dtpFromDate.TabIndex = 11424;
            this.dtpFromDate.Visible = false;
            // 
            // btnReport
            // 
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Location = new System.Drawing.Point(900, 89);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 30);
            this.btnReport.TabIndex = 11421;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnView
            // 
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnView.Location = new System.Drawing.Point(981, 89);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 30);
            this.btnView.TabIndex = 11420;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(1142, 89);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11419;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(1062, 89);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11418;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(522, 40);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(63, 15);
            this.lblFromDate.TabIndex = 11427;
            this.lblFromDate.Text = "From Date";
            this.lblFromDate.Visible = false;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(9, 108);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11423;
            this.lblTotalCount.Text = "Total Count-";
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
            this.clmSpecialLeaves,
            this.clmHoliday,
            this.clmHolidayPresent,
            this.clmSalaryDays,
            this.clmRegularOvertime,
            this.clmWOOTHrs,
            this.clmHolidayOTHours,
            this.clmTotalOTHrs,
            this.clmAbsent,
            this.clmCompOffDays,
            this.clmCompOffUsed,
            this.clmWeeklyOff,
            this.clmWeeklyOffPresent,
            this.clmTotalDays,
            this.clmTotalHours,
            this.clmTotalWorkableHours});
            this.dataGridView1.Location = new System.Drawing.Point(17, 338);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1205, 207);
            this.dataGridView1.TabIndex = 11422;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
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
            // clmSpecialLeaves
            // 
            this.clmSpecialLeaves.HeaderText = "Special Leaves";
            this.clmSpecialLeaves.Name = "clmSpecialLeaves";
            this.clmSpecialLeaves.ReadOnly = true;
            this.clmSpecialLeaves.Width = 80;
            // 
            // clmHoliday
            // 
            this.clmHoliday.HeaderText = "Holiday";
            this.clmHoliday.Name = "clmHoliday";
            this.clmHoliday.ReadOnly = true;
            this.clmHoliday.Width = 80;
            // 
            // clmHolidayPresent
            // 
            this.clmHolidayPresent.HeaderText = "Holiday Present";
            this.clmHolidayPresent.Name = "clmHolidayPresent";
            this.clmHolidayPresent.ReadOnly = true;
            this.clmHolidayPresent.Width = 80;
            // 
            // clmSalaryDays
            // 
            this.clmSalaryDays.HeaderText = "Salary Days";
            this.clmSalaryDays.Name = "clmSalaryDays";
            this.clmSalaryDays.ReadOnly = true;
            this.clmSalaryDays.Width = 80;
            // 
            // clmRegularOvertime
            // 
            this.clmRegularOvertime.HeaderText = "Regular Overtime";
            this.clmRegularOvertime.Name = "clmRegularOvertime";
            this.clmRegularOvertime.ReadOnly = true;
            this.clmRegularOvertime.Width = 80;
            // 
            // clmWOOTHrs
            // 
            this.clmWOOTHrs.HeaderText = "WO OT hrs.";
            this.clmWOOTHrs.Name = "clmWOOTHrs";
            this.clmWOOTHrs.ReadOnly = true;
            this.clmWOOTHrs.Width = 80;
            // 
            // clmHolidayOTHours
            // 
            this.clmHolidayOTHours.HeaderText = "Holiday OT Hours";
            this.clmHolidayOTHours.Name = "clmHolidayOTHours";
            this.clmHolidayOTHours.ReadOnly = true;
            // 
            // clmTotalOTHrs
            // 
            this.clmTotalOTHrs.HeaderText = "Total OT Hrs.";
            this.clmTotalOTHrs.Name = "clmTotalOTHrs";
            this.clmTotalOTHrs.ReadOnly = true;
            this.clmTotalOTHrs.Width = 80;
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
            this.clmCompOffDays.Width = 80;
            // 
            // clmCompOffUsed
            // 
            this.clmCompOffUsed.HeaderText = "Comp Off Used";
            this.clmCompOffUsed.Name = "clmCompOffUsed";
            this.clmCompOffUsed.ReadOnly = true;
            this.clmCompOffUsed.Width = 80;
            // 
            // clmWeeklyOff
            // 
            this.clmWeeklyOff.HeaderText = "Weekly Off";
            this.clmWeeklyOff.Name = "clmWeeklyOff";
            this.clmWeeklyOff.ReadOnly = true;
            this.clmWeeklyOff.Width = 80;
            // 
            // clmWeeklyOffPresent
            // 
            this.clmWeeklyOffPresent.HeaderText = "Weekly Off Present";
            this.clmWeeklyOffPresent.Name = "clmWeeklyOffPresent";
            this.clmWeeklyOffPresent.ReadOnly = true;
            this.clmWeeklyOffPresent.Width = 80;
            // 
            // clmTotalDays
            // 
            this.clmTotalDays.HeaderText = "Total Days";
            this.clmTotalDays.Name = "clmTotalDays";
            this.clmTotalDays.ReadOnly = true;
            this.clmTotalDays.Width = 80;
            // 
            // clmTotalHours
            // 
            this.clmTotalHours.HeaderText = "Total Hours";
            this.clmTotalHours.Name = "clmTotalHours";
            this.clmTotalHours.ReadOnly = true;
            this.clmTotalHours.Width = 80;
            // 
            // clmTotalWorkableHours
            // 
            this.clmTotalWorkableHours.HeaderText = "Total Workable Hours";
            this.clmTotalWorkableHours.Name = "clmTotalWorkableHours";
            this.clmTotalWorkableHours.ReadOnly = true;
            this.clmTotalWorkableHours.Width = 80;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1231, 30);
            this.lblHeader.TabIndex = 11413;
            this.lblHeader.Text = "Database";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbSelectAllLocation
            // 
            this.cbSelectAllLocation.AutoSize = true;
            this.cbSelectAllLocation.Location = new System.Drawing.Point(7, 36);
            this.cbSelectAllLocation.Name = "cbSelectAllLocation";
            this.cbSelectAllLocation.Size = new System.Drawing.Size(72, 19);
            this.cbSelectAllLocation.TabIndex = 11432;
            this.cbSelectAllLocation.Text = "Location";
            this.cbSelectAllLocation.UseVisualStyleBackColor = true;
            this.cbSelectAllLocation.CheckedChanged += new System.EventHandler(this.cbSelectAllLocation_CheckedChanged);
            // 
            // cbSelectAllDepartment
            // 
            this.cbSelectAllDepartment.AutoSize = true;
            this.cbSelectAllDepartment.Location = new System.Drawing.Point(7, 59);
            this.cbSelectAllDepartment.Name = "cbSelectAllDepartment";
            this.cbSelectAllDepartment.Size = new System.Drawing.Size(90, 19);
            this.cbSelectAllDepartment.TabIndex = 11431;
            this.cbSelectAllDepartment.Text = "Department";
            this.cbSelectAllDepartment.UseVisualStyleBackColor = true;
            this.cbSelectAllDepartment.CheckedChanged += new System.EventHandler(this.cbSelectAllDepartment_CheckedChanged);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(105, 58);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(251, 23);
            this.cmbDepartment.TabIndex = 11430;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(105, 34);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(251, 23);
            this.cmbLocation.TabIndex = 11429;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // cbAttendanceDate
            // 
            this.cbAttendanceDate.AutoSize = true;
            this.cbAttendanceDate.Location = new System.Drawing.Point(391, 40);
            this.cbAttendanceDate.Name = "cbAttendanceDate";
            this.cbAttendanceDate.Size = new System.Drawing.Size(115, 19);
            this.cbAttendanceDate.TabIndex = 11439;
            this.cbAttendanceDate.Text = "Attendance Date";
            this.cbAttendanceDate.UseVisualStyleBackColor = true;
            this.cbAttendanceDate.CheckedChanged += new System.EventHandler(this.cbAttendanceDate_CheckedChanged);
            // 
            // cmbYear
            // 
            this.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Items.AddRange(new object[] {
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.cmbYear.Location = new System.Drawing.Point(747, 60);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(100, 23);
            this.cmbYear.TabIndex = 11438;
            this.cmbYear.Visible = false;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(698, 64);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(30, 15);
            this.lblYear.TabIndex = 11437;
            this.lblYear.Text = "Year";
            this.lblYear.Visible = false;
            // 
            // cmbMonth
            // 
            this.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbMonth.Location = new System.Drawing.Point(587, 60);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(100, 23);
            this.cmbMonth.TabIndex = 11436;
            this.cmbMonth.Visible = false;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(522, 63);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(43, 15);
            this.lblMonth.TabIndex = 11435;
            this.lblMonth.Text = "Month";
            this.lblMonth.Visible = false;
            // 
            // cbRoll
            // 
            this.cbRoll.AutoSize = true;
            this.cbRoll.Location = new System.Drawing.Point(900, 36);
            this.cbRoll.Name = "cbRoll";
            this.cbRoll.Size = new System.Drawing.Size(48, 19);
            this.cbRoll.TabIndex = 11441;
            this.cbRoll.Text = "Roll";
            this.cbRoll.UseVisualStyleBackColor = true;
            this.cbRoll.CheckedChanged += new System.EventHandler(this.cbRoll_CheckedChanged);
            // 
            // cmbRoll
            // 
            this.cmbRoll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoll.FormattingEnabled = true;
            this.cmbRoll.Location = new System.Drawing.Point(962, 33);
            this.cmbRoll.Name = "cmbRoll";
            this.cmbRoll.Size = new System.Drawing.Size(255, 23);
            this.cmbRoll.TabIndex = 11440;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "WORKING",
            "RESIGNED"});
            this.cmbStatus.Location = new System.Drawing.Point(962, 59);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(255, 23);
            this.cmbStatus.TabIndex = 11443;
            // 
            // cbStatusAll
            // 
            this.cbStatusAll.AutoSize = true;
            this.cbStatusAll.Location = new System.Drawing.Point(900, 61);
            this.cbStatusAll.Name = "cbStatusAll";
            this.cbStatusAll.Size = new System.Drawing.Size(60, 19);
            this.cbStatusAll.TabIndex = 11444;
            this.cbStatusAll.Text = "Status";
            this.cbStatusAll.UseVisualStyleBackColor = true;
            this.cbStatusAll.CheckedChanged += new System.EventHandler(this.cbStatusAll_CheckedChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(7, 125);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(1215, 568);
            this.dataGridView2.TabIndex = 11445;
            this.dataGridView2.TabStop = false;
            this.dataGridView2.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellDoubleClick);
            // 
            // AttendanceSalaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1230, 698);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.cbStatusAll);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cbRoll);
            this.Controls.Add(this.cmbRoll);
            this.Controls.Add(this.cbAttendanceDate);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.cbSelectAllLocation);
            this.Controls.Add(this.cbSelectAllDepartment);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AttendanceSalaryReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AttendanceSalaryReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.CheckBox cbSelectAllLocation;
        private System.Windows.Forms.CheckBox cbSelectAllDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.CheckBox cbAttendanceDate;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.CheckBox cbRoll;
        private System.Windows.Forms.ComboBox cmbRoll;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.CheckBox cbStatusAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRoll;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPresentDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLeavesDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSpecialLeaves;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHoliday;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHolidayPresent;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSalaryDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRegularOvertime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmWOOTHrs;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHolidayOTHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalOTHrs;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAbsent;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCompOffDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCompOffUsed;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmWeeklyOff;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmWeeklyOffPresent;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalDays;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalWorkableHours;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}