namespace SPApplication.Transaction
{
    partial class OTApprovalNew
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
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpOTDate = new System.Windows.Forms.DateTimePicker();
            this.lblHeader = new System.Windows.Forms.Label();
            this.cbSelectAllLocation = new System.Windows.Forms.CheckBox();
            this.cbSelectAllDepartment = new System.Windows.Forms.CheckBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmSelectAll = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmSrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOTApprovalFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttendanceRecordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttendanceRecordMasterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEsslAttendanceLogsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepartmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChangeLocationtId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChangeDepartmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.clmOTApprovalFlagAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOTStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOTReply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmChangeDepartmentFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAttendanceStatus = new System.Windows.Forms.ComboBox();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblManagerApproved = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblHRApproved = new System.Windows.Forms.Label();
            this.lblReject = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.lblOverTime = new System.Windows.Forms.Label();
            this.pSave = new System.Windows.Forms.Panel();
            this.cbTransferEmployee = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbUnitNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatusValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(3, 43);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(50, 15);
            this.lblFromDate.TabIndex = 11355;
            this.lblFromDate.Text = "OT Date";
            // 
            // dtpOTDate
            // 
            this.dtpOTDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOTDate.Location = new System.Drawing.Point(55, 39);
            this.dtpOTDate.Name = "dtpOTDate";
            this.dtpOTDate.Size = new System.Drawing.Size(100, 23);
            this.dtpOTDate.TabIndex = 11354;
            this.dtpOTDate.ValueChanged += new System.EventHandler(this.dtpOTDate_ValueChanged);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 1);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1300, 30);
            this.lblHeader.TabIndex = 11356;
            this.lblHeader.Text = "Database";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbSelectAllLocation
            // 
            this.cbSelectAllLocation.AutoSize = true;
            this.cbSelectAllLocation.Location = new System.Drawing.Point(497, 85);
            this.cbSelectAllLocation.Name = "cbSelectAllLocation";
            this.cbSelectAllLocation.Size = new System.Drawing.Size(72, 19);
            this.cbSelectAllLocation.TabIndex = 11380;
            this.cbSelectAllLocation.Text = "Location";
            this.cbSelectAllLocation.UseVisualStyleBackColor = true;
            this.cbSelectAllLocation.Visible = false;
            this.cbSelectAllLocation.CheckedChanged += new System.EventHandler(this.cbSelectAllLocation_CheckedChanged);
            // 
            // cbSelectAllDepartment
            // 
            this.cbSelectAllDepartment.AutoSize = true;
            this.cbSelectAllDepartment.Location = new System.Drawing.Point(588, 85);
            this.cbSelectAllDepartment.Name = "cbSelectAllDepartment";
            this.cbSelectAllDepartment.Size = new System.Drawing.Size(90, 19);
            this.cbSelectAllDepartment.TabIndex = 11379;
            this.cbSelectAllDepartment.Text = "Department";
            this.cbSelectAllDepartment.UseVisualStyleBackColor = true;
            this.cbSelectAllDepartment.Visible = false;
            this.cbSelectAllDepartment.CheckedChanged += new System.EventHandler(this.cbSelectAllDepartment_CheckedChanged);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(608, 39);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(224, 23);
            this.cmbDepartment.TabIndex = 11378;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(275, 39);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(224, 23);
            this.cmbLocation.TabIndex = 11377;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1209, 658);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11383;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1061, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11382;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.clmSelectAll,
            this.clmSrNo,
            this.clmOTApprovalFlag,
            this.clmAttendanceRecordId,
            this.clmAttendanceRecordMasterId,
            this.clmEsslAttendanceLogsId,
            this.clmLocationId,
            this.clmLocation,
            this.clmDepartmentId,
            this.clmDepartment,
            this.clmChangeLocationtId,
            this.clmChangeDepartmentId,
            this.clmEmployeeId,
            this.clmEmployeeCode,
            this.clmEmployeeName,
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
            this.clmOTApprovalFlagAR,
            this.clmOTStatus,
            this.clmRemarks,
            this.clmOTReply,
            this.clmChangeDepartmentFlag});
            this.dataGridView1.Location = new System.Drawing.Point(12, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1274, 515);
            this.dataGridView1.TabIndex = 11381;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            // 
            // clmSelectAll
            // 
            this.clmSelectAll.HeaderText = "";
            this.clmSelectAll.Name = "clmSelectAll";
            this.clmSelectAll.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmSelectAll.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clmSelectAll.Width = 30;
            // 
            // clmSrNo
            // 
            this.clmSrNo.HeaderText = "Sr. No";
            this.clmSrNo.Name = "clmSrNo";
            this.clmSrNo.Width = 30;
            // 
            // clmOTApprovalFlag
            // 
            this.clmOTApprovalFlag.HeaderText = "OTApprovalFlag";
            this.clmOTApprovalFlag.Name = "clmOTApprovalFlag";
            this.clmOTApprovalFlag.Visible = false;
            // 
            // clmAttendanceRecordId
            // 
            this.clmAttendanceRecordId.HeaderText = "AttendanceRecordId";
            this.clmAttendanceRecordId.Name = "clmAttendanceRecordId";
            this.clmAttendanceRecordId.Visible = false;
            // 
            // clmAttendanceRecordMasterId
            // 
            this.clmAttendanceRecordMasterId.HeaderText = "AttendanceRecordMasterId";
            this.clmAttendanceRecordMasterId.Name = "clmAttendanceRecordMasterId";
            this.clmAttendanceRecordMasterId.Visible = false;
            // 
            // clmEsslAttendanceLogsId
            // 
            this.clmEsslAttendanceLogsId.HeaderText = "Essl Attendance Logs Id";
            this.clmEsslAttendanceLogsId.Name = "clmEsslAttendanceLogsId";
            this.clmEsslAttendanceLogsId.Visible = false;
            // 
            // clmLocationId
            // 
            this.clmLocationId.HeaderText = "LocationId";
            this.clmLocationId.Name = "clmLocationId";
            this.clmLocationId.Visible = false;
            // 
            // clmLocation
            // 
            this.clmLocation.HeaderText = "Location";
            this.clmLocation.Name = "clmLocation";
            this.clmLocation.Width = 80;
            // 
            // clmDepartmentId
            // 
            this.clmDepartmentId.HeaderText = "DepartmentId";
            this.clmDepartmentId.Name = "clmDepartmentId";
            this.clmDepartmentId.Visible = false;
            // 
            // clmDepartment
            // 
            this.clmDepartment.HeaderText = "Department";
            this.clmDepartment.Name = "clmDepartment";
            this.clmDepartment.Width = 80;
            // 
            // clmChangeLocationtId
            // 
            this.clmChangeLocationtId.HeaderText = "Transfer Location";
            this.clmChangeLocationtId.Name = "clmChangeLocationtId";
            this.clmChangeLocationtId.ReadOnly = true;
            this.clmChangeLocationtId.Width = 80;
            // 
            // clmChangeDepartmentId
            // 
            this.clmChangeDepartmentId.HeaderText = "Transfer Department";
            this.clmChangeDepartmentId.Name = "clmChangeDepartmentId";
            this.clmChangeDepartmentId.ReadOnly = true;
            this.clmChangeDepartmentId.Width = 80;
            // 
            // clmEmployeeId
            // 
            this.clmEmployeeId.HeaderText = "EmployeeId";
            this.clmEmployeeId.Name = "clmEmployeeId";
            this.clmEmployeeId.Visible = false;
            // 
            // clmEmployeeCode
            // 
            this.clmEmployeeCode.HeaderText = "Emp Code";
            this.clmEmployeeCode.Name = "clmEmployeeCode";
            this.clmEmployeeCode.Width = 70;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.HeaderText = "Employee Name";
            this.clmEmployeeName.Name = "clmEmployeeName";
            this.clmEmployeeName.Width = 220;
            // 
            // clmShiftId
            // 
            this.clmShiftId.HeaderText = "ShifId";
            this.clmShiftId.Name = "clmShiftId";
            this.clmShiftId.Visible = false;
            this.clmShiftId.Width = 50;
            // 
            // clmShiftGroupId
            // 
            this.clmShiftGroupId.HeaderText = "ShiftGroupId";
            this.clmShiftGroupId.Name = "clmShiftGroupId";
            this.clmShiftGroupId.Visible = false;
            // 
            // clmShift
            // 
            this.clmShift.HeaderText = "Shift";
            this.clmShift.Name = "clmShift";
            this.clmShift.Width = 60;
            // 
            // clmShiftDuration
            // 
            this.clmShiftDuration.HeaderText = "Shift Duration";
            this.clmShiftDuration.Name = "clmShiftDuration";
            this.clmShiftDuration.Width = 50;
            // 
            // clmStatus
            // 
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmStatus.Width = 50;
            // 
            // clmInTime
            // 
            this.clmInTime.HeaderText = "In Time";
            this.clmInTime.Name = "clmInTime";
            this.clmInTime.Width = 50;
            // 
            // clmOutTime
            // 
            this.clmOutTime.HeaderText = "Out Time";
            this.clmOutTime.Name = "clmOutTime";
            this.clmOutTime.Width = 50;
            // 
            // clmDuration
            // 
            this.clmDuration.HeaderText = "Dura tion";
            this.clmDuration.Name = "clmDuration";
            this.clmDuration.Width = 50;
            // 
            // clmOverTime
            // 
            this.clmOverTime.HeaderText = "Over Time";
            this.clmOverTime.Name = "clmOverTime";
            this.clmOverTime.Width = 50;
            // 
            // clmTotalDuration
            // 
            this.clmTotalDuration.HeaderText = "Total Duration";
            this.clmTotalDuration.Name = "clmTotalDuration";
            this.clmTotalDuration.Width = 50;
            // 
            // clmOverTimeMin
            // 
            this.clmOverTimeMin.HeaderText = "OT (Mins)";
            this.clmOverTimeMin.Name = "clmOverTimeMin";
            this.clmOverTimeMin.Visible = false;
            this.clmOverTimeMin.Width = 50;
            // 
            // clmLateBy
            // 
            this.clmLateBy.HeaderText = "Late By (In Mins)";
            this.clmLateBy.Name = "clmLateBy";
            this.clmLateBy.Width = 50;
            // 
            // clmEarlyBy
            // 
            this.clmEarlyBy.HeaderText = "Early By (In Mins)";
            this.clmEarlyBy.Name = "clmEarlyBy";
            this.clmEarlyBy.Width = 50;
            // 
            // clmOTApprovalFlagAR
            // 
            this.clmOTApprovalFlagAR.HeaderText = "OTApprovalFlagAR";
            this.clmOTApprovalFlagAR.Name = "clmOTApprovalFlagAR";
            this.clmOTApprovalFlagAR.ReadOnly = true;
            this.clmOTApprovalFlagAR.Visible = false;
            // 
            // clmOTStatus
            // 
            this.clmOTStatus.HeaderText = "OT Status";
            this.clmOTStatus.Name = "clmOTStatus";
            this.clmOTStatus.ReadOnly = true;
            this.clmOTStatus.Width = 60;
            // 
            // clmRemarks
            // 
            this.clmRemarks.HeaderText = "Remarks";
            this.clmRemarks.Name = "clmRemarks";
            this.clmRemarks.ReadOnly = true;
            // 
            // clmOTReply
            // 
            this.clmOTReply.HeaderText = "OT Reply";
            this.clmOTReply.Name = "clmOTReply";
            this.clmOTReply.ReadOnly = true;
            // 
            // clmChangeDepartmentFlag
            // 
            this.clmChangeDepartmentFlag.HeaderText = "Change Flag";
            this.clmChangeDepartmentFlag.Name = "clmChangeDepartmentFlag";
            this.clmChangeDepartmentFlag.ReadOnly = true;
            this.clmChangeDepartmentFlag.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1131, 35);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11385;
            this.btnDelete.Text = "View";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1209, 35);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11384;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(293, 8);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(706, 23);
            this.txtRemarks.TabIndex = 11386;
            this.txtRemarks.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 11387;
            this.label1.Text = "Status";
            // 
            // cmbAttendanceStatus
            // 
            this.cmbAttendanceStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAttendanceStatus.FormattingEnabled = true;
            this.cmbAttendanceStatus.Location = new System.Drawing.Point(46, 8);
            this.cmbAttendanceStatus.Name = "cmbAttendanceStatus";
            this.cmbAttendanceStatus.Size = new System.Drawing.Size(151, 23);
            this.cmbAttendanceStatus.TabIndex = 11388;
            this.cmbAttendanceStatus.SelectionChangeCommitted += new System.EventHandler(this.cmbAttendanceStatus_SelectionChangeCommitted);
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(237, 12);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(54, 15);
            this.lblRemarks.TabIndex = 11389;
            this.lblRemarks.Text = "Remarks";
            this.lblRemarks.Visible = false;
            // 
            // lblManagerApproved
            // 
            this.lblManagerApproved.BackColor = System.Drawing.Color.Lime;
            this.lblManagerApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManagerApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagerApproved.Location = new System.Drawing.Point(419, 630);
            this.lblManagerApproved.Name = "lblManagerApproved";
            this.lblManagerApproved.Size = new System.Drawing.Size(150, 20);
            this.lblManagerApproved.TabIndex = 11396;
            this.lblManagerApproved.Text = "Manager Approved";
            this.lblManagerApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRemark
            // 
            this.lblRemark.BackColor = System.Drawing.Color.Violet;
            this.lblRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemark.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(574, 630);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(150, 20);
            this.lblRemark.TabIndex = 11394;
            this.lblRemark.Text = "Remark";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHRApproved
            // 
            this.lblHRApproved.BackColor = System.Drawing.Color.Aqua;
            this.lblHRApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHRApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHRApproved.Location = new System.Drawing.Point(729, 630);
            this.lblHRApproved.Name = "lblHRApproved";
            this.lblHRApproved.Size = new System.Drawing.Size(150, 20);
            this.lblHRApproved.TabIndex = 11393;
            this.lblHRApproved.Text = "HR Approved";
            this.lblHRApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReject
            // 
            this.lblReject.BackColor = System.Drawing.Color.Tomato;
            this.lblReject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReject.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReject.Location = new System.Drawing.Point(884, 629);
            this.lblReject.Name = "lblReject";
            this.lblReject.Size = new System.Drawing.Size(150, 20);
            this.lblReject.TabIndex = 11392;
            this.lblReject.Text = "Reject";
            this.lblReject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.BackColor = System.Drawing.Color.White;
            this.lblTotalCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCount.Location = new System.Drawing.Point(16, 628);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(150, 20);
            this.lblTotalCount.TabIndex = 11391;
            this.lblTotalCount.Text = "Total Count";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPending
            // 
            this.lblPending.BackColor = System.Drawing.Color.Yellow;
            this.lblPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPending.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.Location = new System.Drawing.Point(264, 630);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(150, 20);
            this.lblPending.TabIndex = 11390;
            this.lblPending.Text = "Pending";
            this.lblPending.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.Location = new System.Drawing.Point(23, 89);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAll.TabIndex = 11397;
            this.cbSelectAll.Text = "Select All";
            this.cbSelectAll.UseVisualStyleBackColor = true;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // lblOverTime
            // 
            this.lblOverTime.BackColor = System.Drawing.Color.Pink;
            this.lblOverTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOverTime.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverTime.Location = new System.Drawing.Point(906, 88);
            this.lblOverTime.Name = "lblOverTime";
            this.lblOverTime.Size = new System.Drawing.Size(242, 20);
            this.lblOverTime.TabIndex = 11398;
            this.lblOverTime.Text = "Total OT";
            // 
            // pSave
            // 
            this.pSave.Controls.Add(this.btnSave);
            this.pSave.Controls.Add(this.txtRemarks);
            this.pSave.Controls.Add(this.cmbAttendanceStatus);
            this.pSave.Controls.Add(this.label1);
            this.pSave.Controls.Add(this.lblRemarks);
            this.pSave.Location = new System.Drawing.Point(12, 655);
            this.pSave.Name = "pSave";
            this.pSave.Size = new System.Drawing.Size(1155, 36);
            this.pSave.TabIndex = 11399;
            this.pSave.Visible = false;
            // 
            // cbTransferEmployee
            // 
            this.cbTransferEmployee.AutoSize = true;
            this.cbTransferEmployee.BackColor = System.Drawing.Color.Coral;
            this.cbTransferEmployee.Location = new System.Drawing.Point(255, 86);
            this.cbTransferEmployee.Name = "cbTransferEmployee";
            this.cbTransferEmployee.Size = new System.Drawing.Size(126, 19);
            this.cbTransferEmployee.TabIndex = 11401;
            this.cbTransferEmployee.Text = "Transfer Employee";
            this.cbTransferEmployee.UseVisualStyleBackColor = false;
            this.cbTransferEmployee.CheckedChanged += new System.EventHandler(this.cbTransferEmployee_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(535, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 11403;
            this.label2.Text = "Department";
            // 
            // lbUnitNumber
            // 
            this.lbUnitNumber.AutoSize = true;
            this.lbUnitNumber.Location = new System.Drawing.Point(186, 43);
            this.lbUnitNumber.Name = "lbUnitNumber";
            this.lbUnitNumber.Size = new System.Drawing.Size(87, 15);
            this.lbUnitNumber.TabIndex = 11402;
            this.lbUnitNumber.Text = "Location Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(852, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 11404;
            this.label3.Text = "Status";
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Location = new System.Drawing.Point(903, 43);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(37, 15);
            this.lblStatusValue.TabIndex = 11405;
            this.lblStatusValue.Text = "Value";
            // 
            // OTApprovalNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1298, 698);
            this.ControlBox = false;
            this.Controls.Add(this.lblStatusValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbUnitNumber);
            this.Controls.Add(this.cbTransferEmployee);
            this.Controls.Add(this.pSave);
            this.Controls.Add(this.lblOverTime);
            this.Controls.Add(this.cbSelectAll);
            this.Controls.Add(this.lblManagerApproved);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblHRApproved);
            this.Controls.Add(this.lblReject);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbSelectAllLocation);
            this.Controls.Add(this.cbSelectAllDepartment);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpOTDate);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "OTApprovalNew";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.OTApprovalNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pSave.ResumeLayout(false);
            this.pSave.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpOTDate;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.CheckBox cbSelectAllLocation;
        private System.Windows.Forms.CheckBox cbSelectAllDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAttendanceStatus;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.Label lblManagerApproved;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblHRApproved;
        private System.Windows.Forms.Label lblReject;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.CheckBox cbSelectAll;
        private System.Windows.Forms.Label lblOverTime;
        private System.Windows.Forms.Panel pSave;
        private System.Windows.Forms.CheckBox cbTransferEmployee;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmSelectAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOTApprovalFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttendanceRecordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttendanceRecordMasterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEsslAttendanceLogsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepartmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChangeLocationtId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChangeDepartmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeName;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOTApprovalFlagAR;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOTStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOTReply;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmChangeDepartmentFlag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbUnitNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatusValue;
    }
}