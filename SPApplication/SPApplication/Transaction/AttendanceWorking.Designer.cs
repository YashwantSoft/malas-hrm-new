namespace SPApplication.Transaction
{
    partial class AttendanceWorking
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmSrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttendanceRecordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttendanceRecordMasterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEsslAttendanceLogsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.clmPunchRecords = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLeaveTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLeave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLeaveDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChangeDepartmentFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChangeLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepartmentChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChangeLocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChangeDepartmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRemarksGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLossOfHours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmApprovalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCompleteFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOTApprovalFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOTStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOTRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOTReply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAttendanceStatus = new System.Windows.Forms.ComboBox();
            this.lblHRApproved = new System.Windows.Forms.Label();
            this.lblReject = new System.Windows.Forms.Label();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblInchargeApproved = new System.Windows.Forms.Label();
            this.lblManagerApproved = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpAttendanceDate = new System.Windows.Forms.DateTimePicker();
            this.lblContractorCount = new System.Windows.Forms.Label();
            this.cmbContractor = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.txtSearchEmpCode = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.cbContractor = new System.Windows.Forms.CheckBox();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.cbMissedPunch = new System.Windows.Forms.CheckBox();
            this.rtbStatusCount = new System.Windows.Forms.RichTextBox();
            this.rtbContractorWiseCount = new System.Windows.Forms.RichTextBox();
            this.lblData = new System.Windows.Forms.RichTextBox();
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
            this.lblHeader.Size = new System.Drawing.Size(1306, 30);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "TT DB";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.clmGender,
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
            this.clmPunchRecords,
            this.clmLeaveTypeId,
            this.clmLeave,
            this.clmLeaveDuration,
            this.clmChangeDepartmentFlag,
            this.clmChangeLocation,
            this.clmDepartmentChange,
            this.clmChangeLocationId,
            this.clmChangeDepartmentId,
            this.clmRemarksGrid,
            this.clmNotes,
            this.clmLossOfHours,
            this.clmApprovalStatus,
            this.clmCompleteFlag,
            this.clmOTApprovalFlag,
            this.clmOTStatus,
            this.clmOTRemarks,
            this.clmOTReply});
            this.dataGridView1.Location = new System.Drawing.Point(7, 234);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1286, 480);
            this.dataGridView1.TabIndex = 11309;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
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
            this.clmEmployeeCode.Width = 70;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.HeaderText = "Employee Name";
            this.clmEmployeeName.Name = "clmEmployeeName";
            this.clmEmployeeName.ReadOnly = true;
            this.clmEmployeeName.Width = 180;
            // 
            // clmGender
            // 
            this.clmGender.HeaderText = "Gender";
            this.clmGender.Name = "clmGender";
            this.clmGender.ReadOnly = true;
            this.clmGender.Width = 60;
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
            // clmPunchRecords
            // 
            this.clmPunchRecords.HeaderText = "PunchRecords";
            this.clmPunchRecords.Name = "clmPunchRecords";
            this.clmPunchRecords.ReadOnly = true;
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
            this.clmChangeDepartmentFlag.HeaderText = "Transfer";
            this.clmChangeDepartmentFlag.Name = "clmChangeDepartmentFlag";
            this.clmChangeDepartmentFlag.ReadOnly = true;
            this.clmChangeDepartmentFlag.Visible = false;
            this.clmChangeDepartmentFlag.Width = 80;
            // 
            // clmChangeLocation
            // 
            this.clmChangeLocation.HeaderText = "Change Location";
            this.clmChangeLocation.Name = "clmChangeLocation";
            this.clmChangeLocation.ReadOnly = true;
            this.clmChangeLocation.Width = 80;
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
            // clmChangeLocationId
            // 
            this.clmChangeLocationId.HeaderText = "Change Location Id";
            this.clmChangeLocationId.Name = "clmChangeLocationId";
            this.clmChangeLocationId.ReadOnly = true;
            this.clmChangeLocationId.Visible = false;
            // 
            // clmChangeDepartmentId
            // 
            this.clmChangeDepartmentId.HeaderText = "Change Dept ID";
            this.clmChangeDepartmentId.Name = "clmChangeDepartmentId";
            this.clmChangeDepartmentId.ReadOnly = true;
            this.clmChangeDepartmentId.Visible = false;
            // 
            // clmRemarksGrid
            // 
            this.clmRemarksGrid.HeaderText = "Remarks";
            this.clmRemarksGrid.Name = "clmRemarksGrid";
            this.clmRemarksGrid.ReadOnly = true;
            this.clmRemarksGrid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmRemarksGrid.Width = 80;
            // 
            // clmNotes
            // 
            this.clmNotes.HeaderText = "Reply";
            this.clmNotes.Name = "clmNotes";
            this.clmNotes.ReadOnly = true;
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
            // clmOTApprovalFlag
            // 
            this.clmOTApprovalFlag.HeaderText = "OT Approval Flag";
            this.clmOTApprovalFlag.Name = "clmOTApprovalFlag";
            this.clmOTApprovalFlag.ReadOnly = true;
            this.clmOTApprovalFlag.Visible = false;
            // 
            // clmOTStatus
            // 
            this.clmOTStatus.HeaderText = "OT Status";
            this.clmOTStatus.Name = "clmOTStatus";
            this.clmOTStatus.ReadOnly = true;
            // 
            // clmOTRemarks
            // 
            this.clmOTRemarks.HeaderText = "OTRemarks";
            this.clmOTRemarks.Name = "clmOTRemarks";
            this.clmOTRemarks.ReadOnly = true;
            // 
            // clmOTReply
            // 
            this.clmOTReply.HeaderText = "OTReply";
            this.clmOTReply.Name = "clmOTReply";
            this.clmOTReply.ReadOnly = true;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(8, 35);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(32, 15);
            this.lblFromDate.TabIndex = 11311;
            this.lblFromDate.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(43, 31);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 23);
            this.dtpDate.TabIndex = 11310;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1213, 198);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11315;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(973, 198);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11314;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1133, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11312;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(569, 32);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(69, 15);
            this.lblTotalCount.TabIndex = 11316;
            this.lblTotalCount.Text = "Total Count";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(926, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 11368;
            this.label1.Text = "Attendance Status";
            // 
            // cmbAttendanceStatus
            // 
            this.cmbAttendanceStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAttendanceStatus.FormattingEnabled = true;
            this.cmbAttendanceStatus.Location = new System.Drawing.Point(1033, 169);
            this.cmbAttendanceStatus.Name = "cmbAttendanceStatus";
            this.cmbAttendanceStatus.Size = new System.Drawing.Size(255, 23);
            this.cmbAttendanceStatus.TabIndex = 11369;
            this.cmbAttendanceStatus.SelectionChangeCommitted += new System.EventHandler(this.cmbAttendanceStatus_SelectionChangeCommitted);
            // 
            // lblHRApproved
            // 
            this.lblHRApproved.BackColor = System.Drawing.Color.Aqua;
            this.lblHRApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHRApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHRApproved.Location = new System.Drawing.Point(350, 56);
            this.lblHRApproved.Name = "lblHRApproved";
            this.lblHRApproved.Size = new System.Drawing.Size(115, 20);
            this.lblHRApproved.TabIndex = 11373;
            this.lblHRApproved.Text = "HR Approved";
            this.lblHRApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReject
            // 
            this.lblReject.BackColor = System.Drawing.Color.DarkOrchid;
            this.lblReject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReject.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReject.Location = new System.Drawing.Point(350, 119);
            this.lblReject.Name = "lblReject";
            this.lblReject.Size = new System.Drawing.Size(115, 20);
            this.lblReject.TabIndex = 11372;
            this.lblReject.Text = "Reject";
            this.lblReject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompleted
            // 
            this.lblCompleted.BackColor = System.Drawing.Color.Lime;
            this.lblCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompleted.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleted.Location = new System.Drawing.Point(350, 140);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(115, 20);
            this.lblCompleted.TabIndex = 11371;
            this.lblCompleted.Text = "Completed";
            this.lblCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPending
            // 
            this.lblPending.BackColor = System.Drawing.Color.Yellow;
            this.lblPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPending.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.Location = new System.Drawing.Point(350, 35);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(115, 20);
            this.lblPending.TabIndex = 11370;
            this.lblPending.Text = "Pending";
            this.lblPending.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInchargeApproved
            // 
            this.lblInchargeApproved.BackColor = System.Drawing.Color.HotPink;
            this.lblInchargeApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInchargeApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInchargeApproved.Location = new System.Drawing.Point(350, 77);
            this.lblInchargeApproved.Name = "lblInchargeApproved";
            this.lblInchargeApproved.Size = new System.Drawing.Size(115, 20);
            this.lblInchargeApproved.TabIndex = 11375;
            this.lblInchargeApproved.Text = "Incharge Approved";
            this.lblInchargeApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblManagerApproved
            // 
            this.lblManagerApproved.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblManagerApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManagerApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagerApproved.Location = new System.Drawing.Point(350, 98);
            this.lblManagerApproved.Name = "lblManagerApproved";
            this.lblManagerApproved.Size = new System.Drawing.Size(115, 20);
            this.lblManagerApproved.TabIndex = 11378;
            this.lblManagerApproved.Text = "Manager Approved";
            this.lblManagerApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRemark
            // 
            this.lblRemark.BackColor = System.Drawing.Color.Khaki;
            this.lblRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemark.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(350, 161);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(115, 20);
            this.lblRemark.TabIndex = 11380;
            this.lblRemark.Text = "Remarks";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Red;
            this.lblError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblError.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.Location = new System.Drawing.Point(350, 182);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(115, 20);
            this.lblError.TabIndex = 11379;
            this.lblError.Text = "Error";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(478, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 11382;
            this.label3.Text = "Status Count";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1053, 198);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11383;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 11385;
            this.label2.Text = "Attendance Date";
            // 
            // dtpAttendanceDate
            // 
            this.dtpAttendanceDate.Enabled = false;
            this.dtpAttendanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAttendanceDate.Location = new System.Drawing.Point(244, 32);
            this.dtpAttendanceDate.Name = "dtpAttendanceDate";
            this.dtpAttendanceDate.Size = new System.Drawing.Size(100, 23);
            this.dtpAttendanceDate.TabIndex = 11384;
            // 
            // lblContractorCount
            // 
            this.lblContractorCount.AutoSize = true;
            this.lblContractorCount.Location = new System.Drawing.Point(682, 32);
            this.lblContractorCount.Name = "lblContractorCount";
            this.lblContractorCount.Size = new System.Drawing.Size(138, 15);
            this.lblContractorCount.TabIndex = 11387;
            this.lblContractorCount.Text = "Contractor\'s wise Count";
            this.lblContractorCount.Visible = false;
            // 
            // cmbContractor
            // 
            this.cmbContractor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContractor.FormattingEnabled = true;
            this.cmbContractor.Location = new System.Drawing.Point(1031, 44);
            this.cmbContractor.Name = "cmbContractor";
            this.cmbContractor.Size = new System.Drawing.Size(255, 23);
            this.cmbContractor.TabIndex = 11390;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "All",
            "Working",
            "Resigned"});
            this.cmbStatus.Location = new System.Drawing.Point(1031, 68);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(95, 23);
            this.cmbStatus.TabIndex = 11388;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(1165, 72);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(63, 15);
            this.label51.TabIndex = 11393;
            this.label51.Text = "Emp. Code";
            // 
            // txtSearchEmpCode
            // 
            this.txtSearchEmpCode.Location = new System.Drawing.Point(1230, 68);
            this.txtSearchEmpCode.Name = "txtSearchEmpCode";
            this.txtSearchEmpCode.Size = new System.Drawing.Size(56, 23);
            this.txtSearchEmpCode.TabIndex = 11392;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1133, 97);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 30);
            this.btnSearch.TabIndex = 11394;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearSearch.ForeColor = System.Drawing.Color.White;
            this.btnClearSearch.Location = new System.Drawing.Point(1211, 97);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(75, 30);
            this.btnClearSearch.TabIndex = 11395;
            this.btnClearSearch.Text = "Clear";
            this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // cbContractor
            // 
            this.cbContractor.AutoSize = true;
            this.cbContractor.Location = new System.Drawing.Point(944, 47);
            this.cbContractor.Name = "cbContractor";
            this.cbContractor.Size = new System.Drawing.Size(85, 19);
            this.cbContractor.TabIndex = 11396;
            this.cbContractor.Text = "Contractor";
            this.cbContractor.UseVisualStyleBackColor = true;
            this.cbContractor.CheckedChanged += new System.EventHandler(this.cbContractor_CheckedChanged);
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Location = new System.Drawing.Point(944, 71);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(60, 19);
            this.cbStatus.TabIndex = 11397;
            this.cbStatus.Text = "Status";
            this.cbStatus.UseVisualStyleBackColor = true;
            this.cbStatus.CheckedChanged += new System.EventHandler(this.cbStatus_CheckedChanged);
            // 
            // cbMissedPunch
            // 
            this.cbMissedPunch.AutoSize = true;
            this.cbMissedPunch.Location = new System.Drawing.Point(944, 99);
            this.cbMissedPunch.Name = "cbMissedPunch";
            this.cbMissedPunch.Size = new System.Drawing.Size(105, 19);
            this.cbMissedPunch.TabIndex = 11398;
            this.cbMissedPunch.Text = "Missed In/Out";
            this.cbMissedPunch.UseVisualStyleBackColor = true;
            this.cbMissedPunch.CheckedChanged += new System.EventHandler(this.cbMissedPunch_CheckedChanged);
            // 
            // rtbStatusCount
            // 
            this.rtbStatusCount.Location = new System.Drawing.Point(477, 48);
            this.rtbStatusCount.Name = "rtbStatusCount";
            this.rtbStatusCount.Size = new System.Drawing.Size(182, 180);
            this.rtbStatusCount.TabIndex = 11399;
            this.rtbStatusCount.Text = "";
            this.rtbStatusCount.TextChanged += new System.EventHandler(this.rtbStatusCount_TextChanged);
            // 
            // rtbContractorWiseCount
            // 
            this.rtbContractorWiseCount.Location = new System.Drawing.Point(660, 48);
            this.rtbContractorWiseCount.Name = "rtbContractorWiseCount";
            this.rtbContractorWiseCount.Size = new System.Drawing.Size(260, 180);
            this.rtbContractorWiseCount.TabIndex = 11400;
            this.rtbContractorWiseCount.Text = "";
            this.rtbContractorWiseCount.Visible = false;
            // 
            // lblData
            // 
            this.lblData.Location = new System.Drawing.Point(7, 55);
            this.lblData.Name = "lblData";
            this.lblData.ReadOnly = true;
            this.lblData.Size = new System.Drawing.Size(337, 173);
            this.lblData.TabIndex = 11401;
            this.lblData.Text = "";
            // 
            // AttendanceWorking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1298, 718);
            this.ControlBox = false;
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.rtbContractorWiseCount);
            this.Controls.Add(this.rtbStatusCount);
            this.Controls.Add(this.cbMissedPunch);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbContractor);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.txtSearchEmpCode);
            this.Controls.Add(this.cmbContractor);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblContractorCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpAttendanceDate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblManagerApproved);
            this.Controls.Add(this.lblInchargeApproved);
            this.Controls.Add(this.lblHRApproved);
            this.Controls.Add(this.lblReject);
            this.Controls.Add(this.lblCompleted);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAttendanceStatus);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AttendanceWorking";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AttendanceApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAttendanceStatus;
        private System.Windows.Forms.Label lblHRApproved;
        private System.Windows.Forms.Label lblReject;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblInchargeApproved;
        private System.Windows.Forms.Label lblManagerApproved;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpAttendanceDate;
        private System.Windows.Forms.Label lblContractorCount;
        private System.Windows.Forms.ComboBox cmbContractor;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox txtSearchEmpCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.CheckBox cbContractor;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.CheckBox cbMissedPunch;
        private System.Windows.Forms.RichTextBox rtbStatusCount;
        private System.Windows.Forms.RichTextBox rtbContractorWiseCount;
        private System.Windows.Forms.RichTextBox lblData;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttendanceRecordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttendanceRecordMasterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEsslAttendanceLogsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGender;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPunchRecords;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLeaveTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLeave;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLeaveDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChangeDepartmentFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChangeLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepartmentChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChangeLocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChangeDepartmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRemarksGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLossOfHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApprovalStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCompleteFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOTApprovalFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOTStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOTRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOTReply;
    }
}