namespace SPApplication.Transaction
{
    partial class IndvisualUserAttendanceReport
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmSrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttendanceRecordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttendanceRecordMasterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEsslAttendanceLogsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttendanceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShiftId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShiftGroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShiftDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOutTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOverTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOverTimeMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEarlyBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMissedInPunch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMissedOutPunch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLeaveTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLeave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLeaveDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChangeDepartmentFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChangeLocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChangeLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChangeDepartmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepartmentChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRemarksGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPunchRecords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLossOfHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmApprovalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCompleteFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lbUnitNumber = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEmployeeName = new System.Windows.Forms.ComboBox();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDepartmentName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbStatusCount = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1200, 30);
            this.lblHeader.TabIndex = 22;
            this.lblHeader.Text = "Database";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbToday
            // 
            this.cbToday.AutoSize = true;
            this.cbToday.Location = new System.Drawing.Point(366, 122);
            this.cbToday.Name = "cbToday";
            this.cbToday.Size = new System.Drawing.Size(58, 19);
            this.cbToday.TabIndex = 11304;
            this.cbToday.Text = "Today";
            this.cbToday.UseVisualStyleBackColor = true;
            this.cbToday.CheckedChanged += new System.EventHandler(this.cbToday_CheckedChanged);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(211, 124);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(47, 15);
            this.lblToDate.TabIndex = 11306;
            this.lblToDate.Text = "To Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(260, 121);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(100, 23);
            this.dtpToDate.TabIndex = 11303;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(12, 126);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(63, 15);
            this.lblFromDate.TabIndex = 11305;
            this.lblFromDate.Text = "From Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(107, 120);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(100, 23);
            this.dtpFromDate.TabIndex = 11302;
            // 
            // btnReport
            // 
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Location = new System.Drawing.Point(276, 151);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 30);
            this.btnReport.TabIndex = 11328;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnView
            // 
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnView.Location = new System.Drawing.Point(195, 151);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 30);
            this.btnView.TabIndex = 11327;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Visible = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(436, 151);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11326;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(356, 151);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11325;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.clmSrNo,
            this.clmAttendanceRecordId,
            this.clmAttendanceRecordMasterId,
            this.clmEsslAttendanceLogsId,
            this.clmEmployeeId,
            this.clmEmployeeCode,
            this.clmEmployeeName,
            this.clmAttendanceDate,
            this.clmShiftId,
            this.clmShiftGroupId,
            this.clmShift,
            this.clmShiftDuration,
            this.clmStatus,
            this.clmInTime,
            this.clmOutTime,
            this.clmDuration,
            this.clmOverTime,
            this.clmTotalDuration,
            this.clmOverTimeMin,
            this.clmLateBy,
            this.clmEarlyBy,
            this.clmMissedInPunch,
            this.clmMissedOutPunch,
            this.clmLeaveTypeId,
            this.clmLeave,
            this.clmLeaveDuration,
            this.clmChangeDepartmentFlag,
            this.clmChangeLocationId,
            this.clmChangeLocation,
            this.clmChangeDepartmentId,
            this.clmDepartmentChange,
            this.clmRemarksGrid,
            this.clmPunchRecords,
            this.clmLossOfHours,
            this.clmApprovalStatus,
            this.clmCompleteFlag});
            this.dataGridView1.Location = new System.Drawing.Point(12, 196);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1171, 498);
            this.dataGridView1.TabIndex = 11329;
            // 
            // clmSrNo
            // 
            this.clmSrNo.HeaderText = "Sr. No";
            this.clmSrNo.Name = "clmSrNo";
            this.clmSrNo.ReadOnly = true;
            this.clmSrNo.Width = 30;
            // 
            // clmAttendanceRecordId
            // 
            this.clmAttendanceRecordId.HeaderText = "AttendanceRecordId";
            this.clmAttendanceRecordId.Name = "clmAttendanceRecordId";
            this.clmAttendanceRecordId.ReadOnly = true;
            this.clmAttendanceRecordId.Visible = false;
            // 
            // clmAttendanceRecordMasterId
            // 
            this.clmAttendanceRecordMasterId.HeaderText = "AttendanceRecordMasterId";
            this.clmAttendanceRecordMasterId.Name = "clmAttendanceRecordMasterId";
            this.clmAttendanceRecordMasterId.ReadOnly = true;
            this.clmAttendanceRecordMasterId.Visible = false;
            // 
            // clmEsslAttendanceLogsId
            // 
            this.clmEsslAttendanceLogsId.HeaderText = "Essl Attendance Logs Id";
            this.clmEsslAttendanceLogsId.Name = "clmEsslAttendanceLogsId";
            this.clmEsslAttendanceLogsId.ReadOnly = true;
            this.clmEsslAttendanceLogsId.Visible = false;
            // 
            // clmEmployeeId
            // 
            this.clmEmployeeId.HeaderText = "EmployeeId";
            this.clmEmployeeId.Name = "clmEmployeeId";
            this.clmEmployeeId.ReadOnly = true;
            this.clmEmployeeId.Visible = false;
            // 
            // clmEmployeeCode
            // 
            this.clmEmployeeCode.HeaderText = "Emp Code";
            this.clmEmployeeCode.Name = "clmEmployeeCode";
            this.clmEmployeeCode.ReadOnly = true;
            this.clmEmployeeCode.Visible = false;
            this.clmEmployeeCode.Width = 70;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.HeaderText = "Employee Name";
            this.clmEmployeeName.Name = "clmEmployeeName";
            this.clmEmployeeName.ReadOnly = true;
            this.clmEmployeeName.Visible = false;
            this.clmEmployeeName.Width = 180;
            // 
            // clmAttendanceDate
            // 
            this.clmAttendanceDate.HeaderText = "Date";
            this.clmAttendanceDate.Name = "clmAttendanceDate";
            this.clmAttendanceDate.ReadOnly = true;
            // 
            // clmShiftId
            // 
            this.clmShiftId.HeaderText = "ShifId";
            this.clmShiftId.Name = "clmShiftId";
            this.clmShiftId.ReadOnly = true;
            this.clmShiftId.Visible = false;
            this.clmShiftId.Width = 50;
            // 
            // clmShiftGroupId
            // 
            this.clmShiftGroupId.HeaderText = "ShiftGroupId";
            this.clmShiftGroupId.Name = "clmShiftGroupId";
            this.clmShiftGroupId.ReadOnly = true;
            this.clmShiftGroupId.Visible = false;
            // 
            // clmShift
            // 
            this.clmShift.HeaderText = "Shift";
            this.clmShift.Name = "clmShift";
            this.clmShift.ReadOnly = true;
            // 
            // clmShiftDuration
            // 
            this.clmShiftDuration.HeaderText = "Shift Duration";
            this.clmShiftDuration.Name = "clmShiftDuration";
            this.clmShiftDuration.ReadOnly = true;
            this.clmShiftDuration.Width = 50;
            // 
            // clmStatus
            // 
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
            this.clmStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmStatus.Width = 50;
            // 
            // clmInTime
            // 
            this.clmInTime.HeaderText = "In Time";
            this.clmInTime.Name = "clmInTime";
            this.clmInTime.ReadOnly = true;
            this.clmInTime.Width = 50;
            // 
            // clmOutTime
            // 
            this.clmOutTime.HeaderText = "Out Time";
            this.clmOutTime.Name = "clmOutTime";
            this.clmOutTime.ReadOnly = true;
            this.clmOutTime.Width = 50;
            // 
            // clmDuration
            // 
            this.clmDuration.HeaderText = "Dura tion";
            this.clmDuration.Name = "clmDuration";
            this.clmDuration.ReadOnly = true;
            this.clmDuration.Width = 50;
            // 
            // clmOverTime
            // 
            this.clmOverTime.HeaderText = "Over Time";
            this.clmOverTime.Name = "clmOverTime";
            this.clmOverTime.ReadOnly = true;
            this.clmOverTime.Width = 50;
            // 
            // clmTotalDuration
            // 
            this.clmTotalDuration.HeaderText = "Total Duration";
            this.clmTotalDuration.Name = "clmTotalDuration";
            this.clmTotalDuration.ReadOnly = true;
            this.clmTotalDuration.Width = 50;
            // 
            // clmOverTimeMin
            // 
            this.clmOverTimeMin.HeaderText = "OT (Mins)";
            this.clmOverTimeMin.Name = "clmOverTimeMin";
            this.clmOverTimeMin.ReadOnly = true;
            this.clmOverTimeMin.Visible = false;
            this.clmOverTimeMin.Width = 50;
            // 
            // clmLateBy
            // 
            this.clmLateBy.HeaderText = "Late By (In Mins)";
            this.clmLateBy.Name = "clmLateBy";
            this.clmLateBy.ReadOnly = true;
            this.clmLateBy.Width = 50;
            // 
            // clmEarlyBy
            // 
            this.clmEarlyBy.HeaderText = "Early By (In Mins)";
            this.clmEarlyBy.Name = "clmEarlyBy";
            this.clmEarlyBy.ReadOnly = true;
            this.clmEarlyBy.Width = 50;
            // 
            // clmMissedInPunch
            // 
            this.clmMissedInPunch.HeaderText = "Mis. In Punch";
            this.clmMissedInPunch.Name = "clmMissedInPunch";
            this.clmMissedInPunch.ReadOnly = true;
            this.clmMissedInPunch.Width = 50;
            // 
            // clmMissedOutPunch
            // 
            this.clmMissedOutPunch.HeaderText = "Mis. Out Punch";
            this.clmMissedOutPunch.Name = "clmMissedOutPunch";
            this.clmMissedOutPunch.ReadOnly = true;
            this.clmMissedOutPunch.Width = 50;
            // 
            // clmLeaveTypeId
            // 
            this.clmLeaveTypeId.HeaderText = "LeaveTypeId";
            this.clmLeaveTypeId.Name = "clmLeaveTypeId";
            this.clmLeaveTypeId.ReadOnly = true;
            this.clmLeaveTypeId.Visible = false;
            this.clmLeaveTypeId.Width = 50;
            // 
            // clmLeave
            // 
            this.clmLeave.HeaderText = "Leave";
            this.clmLeave.Name = "clmLeave";
            this.clmLeave.ReadOnly = true;
            this.clmLeave.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmLeave.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmLeave.Width = 50;
            // 
            // clmLeaveDuration
            // 
            this.clmLeaveDuration.HeaderText = "Leave Duration";
            this.clmLeaveDuration.Name = "clmLeaveDuration";
            this.clmLeaveDuration.ReadOnly = true;
            this.clmLeaveDuration.Visible = false;
            this.clmLeaveDuration.Width = 50;
            // 
            // clmChangeDepartmentFlag
            // 
            this.clmChangeDepartmentFlag.HeaderText = "Change Department Flag";
            this.clmChangeDepartmentFlag.Name = "clmChangeDepartmentFlag";
            this.clmChangeDepartmentFlag.ReadOnly = true;
            this.clmChangeDepartmentFlag.Visible = false;
            this.clmChangeDepartmentFlag.Width = 80;
            // 
            // clmChangeLocationId
            // 
            this.clmChangeLocationId.HeaderText = "Change Location Id";
            this.clmChangeLocationId.Name = "clmChangeLocationId";
            this.clmChangeLocationId.ReadOnly = true;
            this.clmChangeLocationId.Visible = false;
            // 
            // clmChangeLocation
            // 
            this.clmChangeLocation.HeaderText = "Change Location";
            this.clmChangeLocation.Name = "clmChangeLocation";
            this.clmChangeLocation.ReadOnly = true;
            this.clmChangeLocation.Width = 80;
            // 
            // clmChangeDepartmentId
            // 
            this.clmChangeDepartmentId.HeaderText = "Change Dept ID";
            this.clmChangeDepartmentId.Name = "clmChangeDepartmentId";
            this.clmChangeDepartmentId.ReadOnly = true;
            this.clmChangeDepartmentId.Visible = false;
            // 
            // clmDepartmentChange
            // 
            this.clmDepartmentChange.HeaderText = "Change Department";
            this.clmDepartmentChange.Name = "clmDepartmentChange";
            this.clmDepartmentChange.ReadOnly = true;
            this.clmDepartmentChange.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmDepartmentChange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmDepartmentChange.Width = 80;
            // 
            // clmRemarksGrid
            // 
            this.clmRemarksGrid.HeaderText = "Remarks";
            this.clmRemarksGrid.Name = "clmRemarksGrid";
            this.clmRemarksGrid.ReadOnly = true;
            this.clmRemarksGrid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmRemarksGrid.Width = 80;
            // 
            // clmPunchRecords
            // 
            this.clmPunchRecords.HeaderText = "PunchRecords";
            this.clmPunchRecords.Name = "clmPunchRecords";
            this.clmPunchRecords.ReadOnly = true;
            // 
            // clmLossOfHours
            // 
            this.clmLossOfHours.HeaderText = "Loss of Hours";
            this.clmLossOfHours.Name = "clmLossOfHours";
            this.clmLossOfHours.ReadOnly = true;
            // 
            // clmApprovalStatus
            // 
            this.clmApprovalStatus.HeaderText = "Approval Status";
            this.clmApprovalStatus.Name = "clmApprovalStatus";
            this.clmApprovalStatus.ReadOnly = true;
            this.clmApprovalStatus.Visible = false;
            // 
            // clmCompleteFlag
            // 
            this.clmCompleteFlag.HeaderText = "Complete Flag";
            this.clmCompleteFlag.Name = "clmCompleteFlag";
            this.clmCompleteFlag.ReadOnly = true;
            this.clmCompleteFlag.Visible = false;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(353, 33);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(422, 23);
            this.cmbDepartment.TabIndex = 11357;
            this.cmbDepartment.SelectionChangeCommitted += new System.EventHandler(this.cmbDepartment_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(280, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 11356;
            this.label8.Text = "Department";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(107, 33);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(167, 23);
            this.cmbLocation.TabIndex = 11355;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // lbUnitNumber
            // 
            this.lbUnitNumber.AutoSize = true;
            this.lbUnitNumber.Location = new System.Drawing.Point(12, 37);
            this.lbUnitNumber.Name = "lbUnitNumber";
            this.lbUnitNumber.Size = new System.Drawing.Size(87, 15);
            this.lbUnitNumber.TabIndex = 11354;
            this.lbUnitNumber.Text = "Location Name";
            // 
            // txtDesignation
            // 
            this.txtDesignation.Location = new System.Drawing.Point(318, 92);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.ReadOnly = true;
            this.txtDesignation.Size = new System.Drawing.Size(195, 23);
            this.txtDesignation.TabIndex = 11352;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(244, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 11353;
            this.label7.Text = "Designation";
            // 
            // cmbEmployeeName
            // 
            this.cmbEmployeeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployeeName.FormattingEnabled = true;
            this.cmbEmployeeName.Location = new System.Drawing.Point(107, 68);
            this.cmbEmployeeName.Name = "cmbEmployeeName";
            this.cmbEmployeeName.Size = new System.Drawing.Size(406, 23);
            this.cmbEmployeeName.TabIndex = 11351;
            this.cmbEmployeeName.SelectionChangeCommitted += new System.EventHandler(this.cmbEmployeeName_SelectionChangeCommitted);
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(107, 92);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.ReadOnly = true;
            this.txtEmployeeCode.Size = new System.Drawing.Size(101, 23);
            this.txtEmployeeCode.TabIndex = 11349;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 11350;
            this.label1.Text = "Employee Code";
            // 
            // lbDepartmentName
            // 
            this.lbDepartmentName.AutoSize = true;
            this.lbDepartmentName.Location = new System.Drawing.Point(12, 72);
            this.lbDepartmentName.Name = "lbDepartmentName";
            this.lbDepartmentName.Size = new System.Drawing.Size(93, 15);
            this.lbDepartmentName.TabIndex = 11348;
            this.lbDepartmentName.Text = "Employee Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(843, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 11384;
            this.label3.Text = "Total Counts";
            // 
            // rtbStatusCount
            // 
            this.rtbStatusCount.Location = new System.Drawing.Point(934, 35);
            this.rtbStatusCount.Name = "rtbStatusCount";
            this.rtbStatusCount.Size = new System.Drawing.Size(249, 155);
            this.rtbStatusCount.TabIndex = 11400;
            this.rtbStatusCount.Text = "";
            // 
            // IndvisualUserAttendanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1199, 698);
            this.ControlBox = false;
            this.Controls.Add(this.rtbStatusCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lbUnitNumber);
            this.Controls.Add(this.txtDesignation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbEmployeeName);
            this.Controls.Add(this.txtEmployeeCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDepartmentName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cbToday);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IndvisualUserAttendanceReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.UserAttendance_Load);
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lbUnitNumber;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttendanceRecordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttendanceRecordMasterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEsslAttendanceLogsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttendanceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShiftId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShiftGroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShift;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShiftDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOutTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOverTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOverTimeMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEarlyBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMissedInPunch;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMissedOutPunch;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLeaveTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLeave;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLeaveDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChangeDepartmentFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChangeLocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChangeLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChangeDepartmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepartmentChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRemarksGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPunchRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLossOfHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApprovalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCompleteFlag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbStatusCount;
    }
}