namespace SPApplication.Transaction
{
    partial class OTApproval
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmSrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttendanceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOTApprovalFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttendanceRecordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttendanceRecordMasterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEsslAttendanceLogsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepartmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAttendanceStatus = new System.Windows.Forms.ComboBox();
            this.lblOverTime = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.cbSelectAllDepartment = new System.Windows.Forms.CheckBox();
            this.cbSelectAllLocation = new System.Windows.Forms.CheckBox();
            this.txtNaration = new System.Windows.Forms.TextBox();
            this.lblNaration = new System.Windows.Forms.Label();
            this.lblManagerApprovedCount = new System.Windows.Forms.Label();
            this.lblPendingCount = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.clmAttendanceDate,
            this.clmOTApprovalFlag,
            this.clmAttendanceRecordId,
            this.clmAttendanceRecordMasterId,
            this.clmEsslAttendanceLogsId,
            this.clmLocationId,
            this.clmLocation,
            this.clmDepartmentId,
            this.clmDepartment,
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
            this.clmEarlyBy});
            this.dataGridView1.Location = new System.Drawing.Point(5, 171);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1281, 499);
            this.dataGridView1.TabIndex = 11310;
            // 
            // clmSrNo
            // 
            this.clmSrNo.HeaderText = "Sr. No";
            this.clmSrNo.Name = "clmSrNo";
            this.clmSrNo.ReadOnly = true;
            this.clmSrNo.Width = 30;
            // 
            // clmAttendanceDate
            // 
            this.clmAttendanceDate.HeaderText = "Date";
            this.clmAttendanceDate.Name = "clmAttendanceDate";
            this.clmAttendanceDate.ReadOnly = true;
            this.clmAttendanceDate.Width = 80;
            // 
            // clmOTApprovalFlag
            // 
            this.clmOTApprovalFlag.HeaderText = "OTApprovalFlag";
            this.clmOTApprovalFlag.Name = "clmOTApprovalFlag";
            this.clmOTApprovalFlag.ReadOnly = true;
            this.clmOTApprovalFlag.Visible = false;
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
            // clmLocationId
            // 
            this.clmLocationId.HeaderText = "LocationId";
            this.clmLocationId.Name = "clmLocationId";
            this.clmLocationId.ReadOnly = true;
            this.clmLocationId.Visible = false;
            // 
            // clmLocation
            // 
            this.clmLocation.HeaderText = "Location";
            this.clmLocation.Name = "clmLocation";
            this.clmLocation.ReadOnly = true;
            // 
            // clmDepartmentId
            // 
            this.clmDepartmentId.HeaderText = "DepartmentId";
            this.clmDepartmentId.Name = "clmDepartmentId";
            this.clmDepartmentId.ReadOnly = true;
            this.clmDepartmentId.Visible = false;
            // 
            // clmDepartment
            // 
            this.clmDepartment.HeaderText = "Department";
            this.clmDepartment.Name = "clmDepartment";
            this.clmDepartment.ReadOnly = true;
            this.clmDepartment.Width = 150;
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
            this.clmEmployeeName.Width = 250;
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
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1210, 138);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11314;
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
            this.btnDelete.Location = new System.Drawing.Point(184, 110);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11313;
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
            this.btnClear.Location = new System.Drawing.Point(262, 110);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11312;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1129, 138);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11311;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1300, 30);
            this.lblHeader.TabIndex = 11315;
            this.lblHeader.Text = "Database";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(113, 82);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(224, 23);
            this.cmbDepartment.TabIndex = 11351;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(113, 58);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(224, 23);
            this.cmbLocation.TabIndex = 11349;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(9, 37);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(63, 15);
            this.lblFromDate.TabIndex = 11353;
            this.lblFromDate.Text = "From Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(74, 33);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(100, 23);
            this.dtpFromDate.TabIndex = 11352;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(761, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 11370;
            this.label1.Text = "Attendance Status";
            // 
            // cmbAttendanceStatus
            // 
            this.cmbAttendanceStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAttendanceStatus.FormattingEnabled = true;
            this.cmbAttendanceStatus.Location = new System.Drawing.Point(868, 32);
            this.cmbAttendanceStatus.Name = "cmbAttendanceStatus";
            this.cmbAttendanceStatus.Size = new System.Drawing.Size(417, 23);
            this.cmbAttendanceStatus.TabIndex = 11371;
            this.cmbAttendanceStatus.SelectionChangeCommitted += new System.EventHandler(this.cmbAttendanceStatus_SelectionChangeCommitted);
            // 
            // lblOverTime
            // 
            this.lblOverTime.BackColor = System.Drawing.Color.Cyan;
            this.lblOverTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOverTime.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverTime.Location = new System.Drawing.Point(686, 138);
            this.lblOverTime.Name = "lblOverTime";
            this.lblOverTime.Size = new System.Drawing.Size(255, 27);
            this.lblOverTime.TabIndex = 11373;
            this.lblOverTime.Text = "Total OT";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(9, 154);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11374;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // cbSelectAllDepartment
            // 
            this.cbSelectAllDepartment.AutoSize = true;
            this.cbSelectAllDepartment.Location = new System.Drawing.Point(15, 84);
            this.cbSelectAllDepartment.Name = "cbSelectAllDepartment";
            this.cbSelectAllDepartment.Size = new System.Drawing.Size(90, 19);
            this.cbSelectAllDepartment.TabIndex = 11375;
            this.cbSelectAllDepartment.Text = "Department";
            this.cbSelectAllDepartment.UseVisualStyleBackColor = true;
            this.cbSelectAllDepartment.CheckedChanged += new System.EventHandler(this.cbSelectAllDepartment_CheckedChanged);
            // 
            // cbSelectAllLocation
            // 
            this.cbSelectAllLocation.AutoSize = true;
            this.cbSelectAllLocation.Location = new System.Drawing.Point(15, 60);
            this.cbSelectAllLocation.Name = "cbSelectAllLocation";
            this.cbSelectAllLocation.Size = new System.Drawing.Size(72, 19);
            this.cbSelectAllLocation.TabIndex = 11376;
            this.cbSelectAllLocation.Text = "Location";
            this.cbSelectAllLocation.UseVisualStyleBackColor = true;
            this.cbSelectAllLocation.CheckedChanged += new System.EventHandler(this.cbSelectAllLocation_CheckedChanged);
            // 
            // txtNaration
            // 
            this.txtNaration.Location = new System.Drawing.Point(868, 57);
            this.txtNaration.Multiline = true;
            this.txtNaration.Name = "txtNaration";
            this.txtNaration.Size = new System.Drawing.Size(417, 75);
            this.txtNaration.TabIndex = 11377;
            this.txtNaration.Visible = false;
            // 
            // lblNaration
            // 
            this.lblNaration.AutoSize = true;
            this.lblNaration.Location = new System.Drawing.Point(761, 60);
            this.lblNaration.Name = "lblNaration";
            this.lblNaration.Size = new System.Drawing.Size(55, 15);
            this.lblNaration.TabIndex = 11378;
            this.lblNaration.Text = "Naration";
            this.lblNaration.Visible = false;
            // 
            // lblManagerApprovedCount
            // 
            this.lblManagerApprovedCount.AutoSize = true;
            this.lblManagerApprovedCount.BackColor = System.Drawing.Color.Lime;
            this.lblManagerApprovedCount.Location = new System.Drawing.Point(156, 154);
            this.lblManagerApprovedCount.Name = "lblManagerApprovedCount";
            this.lblManagerApprovedCount.Size = new System.Drawing.Size(146, 15);
            this.lblManagerApprovedCount.TabIndex = 11379;
            this.lblManagerApprovedCount.Text = "Manager Approved Count";
            // 
            // lblPendingCount
            // 
            this.lblPendingCount.AutoSize = true;
            this.lblPendingCount.Location = new System.Drawing.Point(383, 153);
            this.lblPendingCount.Name = "lblPendingCount";
            this.lblPendingCount.Size = new System.Drawing.Size(86, 15);
            this.lblPendingCount.TabIndex = 11380;
            this.lblPendingCount.Text = "Pending Count";
            // 
            // lblData
            // 
            this.lblData.Location = new System.Drawing.Point(397, 32);
            this.lblData.Name = "lblData";
            this.lblData.ReadOnly = true;
            this.lblData.Size = new System.Drawing.Size(337, 103);
            this.lblData.TabIndex = 11402;
            this.lblData.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 11404;
            this.label2.Text = "To Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(237, 33);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(100, 23);
            this.dtpToDate.TabIndex = 11403;
            // 
            // OTApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1298, 698);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblPendingCount);
            this.Controls.Add(this.lblManagerApprovedCount);
            this.Controls.Add(this.lblNaration);
            this.Controls.Add(this.txtNaration);
            this.Controls.Add(this.cbSelectAllLocation);
            this.Controls.Add(this.cbSelectAllDepartment);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.lblOverTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAttendanceStatus);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OTApproval";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.OTApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAttendanceStatus;
        private System.Windows.Forms.Label lblOverTime;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.CheckBox cbSelectAllDepartment;
        private System.Windows.Forms.CheckBox cbSelectAllLocation;
        private System.Windows.Forms.TextBox txtNaration;
        private System.Windows.Forms.Label lblNaration;
        private System.Windows.Forms.Label lblManagerApprovedCount;
        private System.Windows.Forms.Label lblPendingCount;
        private System.Windows.Forms.RichTextBox lblData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttendanceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOTApprovalFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttendanceRecordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttendanceRecordMasterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEsslAttendanceLogsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepartmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepartment;
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
    }
}