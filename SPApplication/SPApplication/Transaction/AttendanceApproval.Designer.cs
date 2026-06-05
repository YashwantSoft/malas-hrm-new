namespace SPApplication.Transaction
{
    partial class AttendanceApproval
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
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.clmSrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttendanceRecordId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttendanceRecordMasterId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttendanceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShiftId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShift = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOutTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOverTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOTByChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmWorkingTransfer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInchargeRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLeaveApplication = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLateComming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEarlyBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmApprovedFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmApprovalStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHRApproved = new System.Windows.Forms.Label();
            this.lblCancel = new System.Windows.Forms.Label();
            this.lblFinalApproved = new System.Windows.Forms.Label();
            this.lblDepartmentHeadApproved = new System.Windows.Forms.Label();
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
            this.lblHeader.Size = new System.Drawing.Size(1270, 30);
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
            this.clmAttendanceId,
            this.clmEmployeeId,
            this.clmEmployeeName,
            this.clmEmployeeCode,
            this.clmShiftId,
            this.clmShift,
            this.clmInTime,
            this.clmOutTime,
            this.clmDuration,
            this.clmOverTime,
            this.clmTotalDuration,
            this.clmOTByChange,
            this.clmStatus,
            this.clmWorkingTransfer,
            this.clmInchargeRemark,
            this.clmLeaveApplication,
            this.clmLateComming,
            this.clmRemarks,
            this.clmLateBy,
            this.clmEarlyBy,
            this.clmApprovedFlag,
            this.clmApprovalStatus});
            this.dataGridView1.Location = new System.Drawing.Point(7, 131);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(1262, 540);
            this.dataGridView1.TabIndex = 11309;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(392, 39);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(32, 15);
            this.lblFromDate.TabIndex = 11311;
            this.lblFromDate.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(433, 35);
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
            this.btnExit.Location = new System.Drawing.Point(1185, 34);
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
            this.btnDelete.Location = new System.Drawing.Point(1030, 35);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11314;
            this.btnDelete.Text = "Approve";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1108, 34);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11313;
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
            this.btnSave.Location = new System.Drawing.Point(952, 35);
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
            this.lblTotalCount.Location = new System.Drawing.Point(9, 114);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(69, 15);
            this.lblTotalCount.TabIndex = 11316;
            this.lblTotalCount.Text = "Total Count";
            // 
            // lblData
            // 
            this.lblData.BackColor = System.Drawing.Color.White;
            this.lblData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblData.Location = new System.Drawing.Point(5, 31);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(379, 83);
            this.lblData.TabIndex = 11317;
            this.lblData.Text = "Location Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(390, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 11352;
            this.label8.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "DEPARTMENT HEAD APPROVED",
            "FINAL APPROVED",
            "HR APPROVED",
            "CANCEL"});
            this.cmbStatus.Location = new System.Drawing.Point(433, 59);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(361, 23);
            this.cmbStatus.TabIndex = 11353;
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
            // clmAttendanceId
            // 
            this.clmAttendanceId.HeaderText = "AttendanceId";
            this.clmAttendanceId.Name = "clmAttendanceId";
            this.clmAttendanceId.ReadOnly = true;
            this.clmAttendanceId.Visible = false;
            // 
            // clmEmployeeId
            // 
            this.clmEmployeeId.HeaderText = "EmployeeId";
            this.clmEmployeeId.Name = "clmEmployeeId";
            this.clmEmployeeId.ReadOnly = true;
            this.clmEmployeeId.Visible = false;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.HeaderText = "Employee Name";
            this.clmEmployeeName.Name = "clmEmployeeName";
            this.clmEmployeeName.ReadOnly = true;
            this.clmEmployeeName.Width = 200;
            // 
            // clmEmployeeCode
            // 
            this.clmEmployeeCode.HeaderText = "Employee Code";
            this.clmEmployeeCode.Name = "clmEmployeeCode";
            this.clmEmployeeCode.ReadOnly = true;
            this.clmEmployeeCode.Width = 70;
            // 
            // clmShiftId
            // 
            this.clmShiftId.HeaderText = "ShifId";
            this.clmShiftId.Name = "clmShiftId";
            this.clmShiftId.ReadOnly = true;
            this.clmShiftId.Visible = false;
            this.clmShiftId.Width = 50;
            // 
            // clmShift
            // 
            this.clmShift.HeaderText = "Shift";
            this.clmShift.Name = "clmShift";
            this.clmShift.ReadOnly = true;
            this.clmShift.Width = 150;
            // 
            // clmInTime
            // 
            this.clmInTime.HeaderText = "In Time";
            this.clmInTime.Name = "clmInTime";
            this.clmInTime.Width = 70;
            // 
            // clmOutTime
            // 
            this.clmOutTime.HeaderText = "Out Time";
            this.clmOutTime.Name = "clmOutTime";
            this.clmOutTime.Width = 70;
            // 
            // clmDuration
            // 
            this.clmDuration.HeaderText = "Duration";
            this.clmDuration.Name = "clmDuration";
            this.clmDuration.Width = 80;
            // 
            // clmOverTime
            // 
            this.clmOverTime.HeaderText = "OT";
            this.clmOverTime.Name = "clmOverTime";
            this.clmOverTime.Width = 50;
            // 
            // clmTotalDuration
            // 
            this.clmTotalDuration.HeaderText = "Total Duration";
            this.clmTotalDuration.Name = "clmTotalDuration";
            this.clmTotalDuration.Width = 80;
            // 
            // clmOTByChange
            // 
            this.clmOTByChange.HeaderText = "OT By Change";
            this.clmOTByChange.Name = "clmOTByChange";
            this.clmOTByChange.Width = 80;
            // 
            // clmStatus
            // 
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.Width = 80;
            // 
            // clmWorkingTransfer
            // 
            this.clmWorkingTransfer.HeaderText = "Working Transfer";
            this.clmWorkingTransfer.Name = "clmWorkingTransfer";
            // 
            // clmInchargeRemark
            // 
            this.clmInchargeRemark.HeaderText = "Incharge Remark";
            this.clmInchargeRemark.Name = "clmInchargeRemark";
            // 
            // clmLeaveApplication
            // 
            this.clmLeaveApplication.HeaderText = "Leave Application";
            this.clmLeaveApplication.Name = "clmLeaveApplication";
            // 
            // clmLateComming
            // 
            this.clmLateComming.HeaderText = "Late Comming";
            this.clmLateComming.Name = "clmLateComming";
            // 
            // clmRemarks
            // 
            this.clmRemarks.HeaderText = "Remarks";
            this.clmRemarks.Name = "clmRemarks";
            // 
            // clmLateBy
            // 
            this.clmLateBy.HeaderText = "Late By (In Mins)";
            this.clmLateBy.Name = "clmLateBy";
            // 
            // clmEarlyBy
            // 
            this.clmEarlyBy.HeaderText = "Early By (In Mins)";
            this.clmEarlyBy.Name = "clmEarlyBy";
            // 
            // clmApprovedFlag
            // 
            this.clmApprovedFlag.HeaderText = "ApprovedFlag";
            this.clmApprovedFlag.Name = "clmApprovedFlag";
            this.clmApprovedFlag.ReadOnly = true;
            this.clmApprovedFlag.Visible = false;
            // 
            // clmApprovalStatus
            // 
            this.clmApprovalStatus.HeaderText = "Approval Status";
            this.clmApprovalStatus.Name = "clmApprovalStatus";
            this.clmApprovalStatus.ReadOnly = true;
            this.clmApprovalStatus.Visible = false;
            // 
            // lblHRApproved
            // 
            this.lblHRApproved.BackColor = System.Drawing.Color.Aqua;
            this.lblHRApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHRApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHRApproved.Location = new System.Drawing.Point(659, 674);
            this.lblHRApproved.Name = "lblHRApproved";
            this.lblHRApproved.Size = new System.Drawing.Size(200, 20);
            this.lblHRApproved.TabIndex = 11358;
            this.lblHRApproved.Text = "HR APPROVED";
            this.lblHRApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCancel
            // 
            this.lblCancel.BackColor = System.Drawing.Color.Tomato;
            this.lblCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancel.Location = new System.Drawing.Point(865, 674);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(200, 20);
            this.lblCancel.TabIndex = 11357;
            this.lblCancel.Text = "CANCEL";
            this.lblCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFinalApproved
            // 
            this.lblFinalApproved.BackColor = System.Drawing.Color.Lime;
            this.lblFinalApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFinalApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalApproved.Location = new System.Drawing.Point(453, 674);
            this.lblFinalApproved.Name = "lblFinalApproved";
            this.lblFinalApproved.Size = new System.Drawing.Size(200, 20);
            this.lblFinalApproved.TabIndex = 11356;
            this.lblFinalApproved.Text = "FINAL APPROVED";
            this.lblFinalApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDepartmentHeadApproved
            // 
            this.lblDepartmentHeadApproved.BackColor = System.Drawing.Color.Yellow;
            this.lblDepartmentHeadApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDepartmentHeadApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartmentHeadApproved.Location = new System.Drawing.Point(247, 674);
            this.lblDepartmentHeadApproved.Name = "lblDepartmentHeadApproved";
            this.lblDepartmentHeadApproved.Size = new System.Drawing.Size(200, 20);
            this.lblDepartmentHeadApproved.TabIndex = 11355;
            this.lblDepartmentHeadApproved.Text = "DEPARTMENT HEAD APPROVED";
            this.lblDepartmentHeadApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AttendanceApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1266, 698);
            this.ControlBox = false;
            this.Controls.Add(this.lblHRApproved);
            this.Controls.Add(this.lblCancel);
            this.Controls.Add(this.lblFinalApproved);
            this.Controls.Add(this.lblDepartmentHeadApproved);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblData);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AttendanceApproval";
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
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttendanceRecordId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttendanceRecordMasterId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttendanceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShiftId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmShift;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOutTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOverTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOTByChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmWorkingTransfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInchargeRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLeaveApplication;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLateComming;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEarlyBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApprovedFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmApprovalStatus;
        private System.Windows.Forms.Label lblHRApproved;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.Label lblFinalApproved;
        private System.Windows.Forms.Label lblDepartmentHeadApproved;
    }
}