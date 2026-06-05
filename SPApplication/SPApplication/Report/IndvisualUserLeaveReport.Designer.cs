namespace SPApplication.Report
{
    partial class IndvisualUserLeaveReport
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
            this.btnReport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cbToday = new System.Windows.Forms.CheckBox();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbSelectAllLeaveType = new System.Windows.Forms.CheckBox();
            this.cbSelectAllStatus = new System.Windows.Forms.CheckBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbRevertLeave = new System.Windows.Forms.CheckBox();
            this.cmbLeaveType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbLeaveRecords = new System.Windows.Forms.RichTextBox();
            this.lblDue = new System.Windows.Forms.Label();
            this.lblExpired = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblManagerApproved = new System.Windows.Forms.Label();
            this.lblHRApproved = new System.Windows.Forms.Label();
            this.lblReject = new System.Windows.Forms.Label();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.cbCompOffUsedList = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1199, 30);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "TT DB";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(313, 33);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(286, 23);
            this.cmbDepartment.TabIndex = 11357;
            this.cmbDepartment.SelectionChangeCommitted += new System.EventHandler(this.cmbDepartment_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(240, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 11356;
            this.label8.Text = "Department";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(102, 33);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(133, 23);
            this.cmbLocation.TabIndex = 11355;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // lbUnitNumber
            // 
            this.lbUnitNumber.AutoSize = true;
            this.lbUnitNumber.Location = new System.Drawing.Point(7, 37);
            this.lbUnitNumber.Name = "lbUnitNumber";
            this.lbUnitNumber.Size = new System.Drawing.Size(87, 15);
            this.lbUnitNumber.TabIndex = 11354;
            this.lbUnitNumber.Text = "Location Name";
            // 
            // txtDesignation
            // 
            this.txtDesignation.Location = new System.Drawing.Point(313, 86);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.ReadOnly = true;
            this.txtDesignation.Size = new System.Drawing.Size(195, 23);
            this.txtDesignation.TabIndex = 11352;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(239, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 11353;
            this.label7.Text = "Designation";
            // 
            // cmbEmployeeName
            // 
            this.cmbEmployeeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployeeName.FormattingEnabled = true;
            this.cmbEmployeeName.Location = new System.Drawing.Point(102, 62);
            this.cmbEmployeeName.Name = "cmbEmployeeName";
            this.cmbEmployeeName.Size = new System.Drawing.Size(497, 23);
            this.cmbEmployeeName.TabIndex = 11351;
            this.cmbEmployeeName.SelectionChangeCommitted += new System.EventHandler(this.cmbEmployeeName_SelectionChangeCommitted);
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(102, 86);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.ReadOnly = true;
            this.txtEmployeeCode.Size = new System.Drawing.Size(101, 23);
            this.txtEmployeeCode.TabIndex = 11349;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 11350;
            this.label1.Text = "Employee Code";
            // 
            // lbDepartmentName
            // 
            this.lbDepartmentName.AutoSize = true;
            this.lbDepartmentName.Location = new System.Drawing.Point(7, 66);
            this.lbDepartmentName.Name = "lbDepartmentName";
            this.lbDepartmentName.Size = new System.Drawing.Size(93, 15);
            this.lbDepartmentName.TabIndex = 11348;
            this.lbDepartmentName.Text = "Employee Name";
            // 
            // btnReport
            // 
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Location = new System.Drawing.Point(522, 215);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 30);
            this.btnReport.TabIndex = 11366;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnView
            // 
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnView.Location = new System.Drawing.Point(441, 215);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 30);
            this.btnView.TabIndex = 11365;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Visible = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(682, 215);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11364;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(602, 215);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11363;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cbToday
            // 
            this.cbToday.AutoSize = true;
            this.cbToday.Location = new System.Drawing.Point(524, 117);
            this.cbToday.Name = "cbToday";
            this.cbToday.Size = new System.Drawing.Size(58, 19);
            this.cbToday.TabIndex = 11360;
            this.cbToday.Text = "Today";
            this.cbToday.UseVisualStyleBackColor = true;
            this.cbToday.CheckedChanged += new System.EventHandler(this.cbToday_CheckedChanged);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(239, 119);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(47, 15);
            this.lblToDate.TabIndex = 11362;
            this.lblToDate.Text = "To Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(313, 115);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(195, 23);
            this.dtpToDate.TabIndex = 11359;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(7, 119);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(63, 15);
            this.lblFromDate.TabIndex = 11361;
            this.lblFromDate.Text = "From Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(102, 114);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(100, 23);
            this.dtpFromDate.TabIndex = 11358;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(12, 233);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11368;
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
            this.dataGridView1.Location = new System.Drawing.Point(10, 251);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1177, 420);
            this.dataGridView1.TabIndex = 11367;
            // 
            // cbSelectAllLeaveType
            // 
            this.cbSelectAllLeaveType.AutoSize = true;
            this.cbSelectAllLeaveType.Location = new System.Drawing.Point(523, 142);
            this.cbSelectAllLeaveType.Name = "cbSelectAllLeaveType";
            this.cbSelectAllLeaveType.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAllLeaveType.TabIndex = 11375;
            this.cbSelectAllLeaveType.Text = "Select All";
            this.cbSelectAllLeaveType.UseVisualStyleBackColor = true;
            this.cbSelectAllLeaveType.CheckedChanged += new System.EventHandler(this.cbSelectAllLeaveType_CheckedChanged);
            // 
            // cbSelectAllStatus
            // 
            this.cbSelectAllStatus.AutoSize = true;
            this.cbSelectAllStatus.Location = new System.Drawing.Point(523, 167);
            this.cbSelectAllStatus.Name = "cbSelectAllStatus";
            this.cbSelectAllStatus.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAllStatus.TabIndex = 11374;
            this.cbSelectAllStatus.Text = "Select All";
            this.cbSelectAllStatus.UseVisualStyleBackColor = true;
            this.cbSelectAllStatus.CheckedChanged += new System.EventHandler(this.cbSelectAllStatus_CheckedChanged);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(102, 163);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(406, 23);
            this.cmbStatus.TabIndex = 11373;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 11372;
            this.label5.Text = "Status";
            // 
            // cbRevertLeave
            // 
            this.cbRevertLeave.AutoSize = true;
            this.cbRevertLeave.Location = new System.Drawing.Point(103, 188);
            this.cbRevertLeave.Name = "cbRevertLeave";
            this.cbRevertLeave.Size = new System.Drawing.Size(93, 19);
            this.cbRevertLeave.TabIndex = 11371;
            this.cbRevertLeave.Text = "Revert Leave";
            this.cbRevertLeave.UseVisualStyleBackColor = true;
            // 
            // cmbLeaveType
            // 
            this.cmbLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeaveType.FormattingEnabled = true;
            this.cmbLeaveType.Location = new System.Drawing.Point(102, 139);
            this.cmbLeaveType.Name = "cmbLeaveType";
            this.cmbLeaveType.Size = new System.Drawing.Size(406, 23);
            this.cmbLeaveType.TabIndex = 11370;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 11369;
            this.label2.Text = "Leave Type";
            // 
            // rtbLeaveRecords
            // 
            this.rtbLeaveRecords.BackColor = System.Drawing.Color.FloralWhite;
            this.rtbLeaveRecords.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLeaveRecords.Location = new System.Drawing.Point(880, 35);
            this.rtbLeaveRecords.Name = "rtbLeaveRecords";
            this.rtbLeaveRecords.Size = new System.Drawing.Size(306, 210);
            this.rtbLeaveRecords.TabIndex = 11381;
            this.rtbLeaveRecords.Text = "";
            // 
            // lblDue
            // 
            this.lblDue.BackColor = System.Drawing.Color.HotPink;
            this.lblDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDue.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDue.Location = new System.Drawing.Point(886, 674);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(100, 20);
            this.lblDue.TabIndex = 11427;
            this.lblDue.Text = "Due";
            this.lblDue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpired
            // 
            this.lblExpired.BackColor = System.Drawing.Color.Red;
            this.lblExpired.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExpired.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpired.Location = new System.Drawing.Point(1017, 674);
            this.lblExpired.Name = "lblExpired";
            this.lblExpired.Size = new System.Drawing.Size(100, 20);
            this.lblExpired.TabIndex = 11426;
            this.lblExpired.Text = "Expired";
            this.lblExpired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRemark
            // 
            this.lblRemark.BackColor = System.Drawing.Color.Khaki;
            this.lblRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemark.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(624, 674);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(100, 20);
            this.lblRemark.TabIndex = 11425;
            this.lblRemark.Text = "Remarks";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblManagerApproved
            // 
            this.lblManagerApproved.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblManagerApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManagerApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagerApproved.Location = new System.Drawing.Point(231, 674);
            this.lblManagerApproved.Name = "lblManagerApproved";
            this.lblManagerApproved.Size = new System.Drawing.Size(100, 20);
            this.lblManagerApproved.TabIndex = 11424;
            this.lblManagerApproved.Text = "Manager Approved";
            this.lblManagerApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHRApproved
            // 
            this.lblHRApproved.BackColor = System.Drawing.Color.Aqua;
            this.lblHRApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHRApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHRApproved.Location = new System.Drawing.Point(362, 674);
            this.lblHRApproved.Name = "lblHRApproved";
            this.lblHRApproved.Size = new System.Drawing.Size(100, 20);
            this.lblHRApproved.TabIndex = 11423;
            this.lblHRApproved.Text = "HR Approved";
            this.lblHRApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReject
            // 
            this.lblReject.BackColor = System.Drawing.Color.DarkOrchid;
            this.lblReject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReject.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReject.Location = new System.Drawing.Point(493, 674);
            this.lblReject.Name = "lblReject";
            this.lblReject.Size = new System.Drawing.Size(100, 20);
            this.lblReject.TabIndex = 11422;
            this.lblReject.Text = "Reject";
            this.lblReject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompleted
            // 
            this.lblCompleted.BackColor = System.Drawing.Color.Lime;
            this.lblCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompleted.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleted.Location = new System.Drawing.Point(755, 674);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(100, 20);
            this.lblCompleted.TabIndex = 11421;
            this.lblCompleted.Text = "Completed";
            this.lblCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPending
            // 
            this.lblPending.BackColor = System.Drawing.Color.Yellow;
            this.lblPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPending.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.Location = new System.Drawing.Point(100, 674);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(100, 20);
            this.lblPending.TabIndex = 11420;
            this.lblPending.Text = "Pending";
            this.lblPending.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbCompOffUsedList
            // 
            this.cbCompOffUsedList.AutoSize = true;
            this.cbCompOffUsedList.Location = new System.Drawing.Point(271, 222);
            this.cbCompOffUsedList.Name = "cbCompOffUsedList";
            this.cbCompOffUsedList.Size = new System.Drawing.Size(129, 19);
            this.cbCompOffUsedList.TabIndex = 11428;
            this.cbCompOffUsedList.Text = "Comp Off Used List";
            this.cbCompOffUsedList.UseVisualStyleBackColor = true;
            // 
            // IndvisualUserLeaveReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 698);
            this.ControlBox = false;
            this.Controls.Add(this.cbCompOffUsedList);
            this.Controls.Add(this.lblDue);
            this.Controls.Add(this.lblExpired);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblManagerApproved);
            this.Controls.Add(this.lblHRApproved);
            this.Controls.Add(this.lblReject);
            this.Controls.Add(this.lblCompleted);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.rtbLeaveRecords);
            this.Controls.Add(this.cbSelectAllLeaveType);
            this.Controls.Add(this.cbSelectAllStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbRevertLeave);
            this.Controls.Add(this.cmbLeaveType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotalCount);
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
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IndvisualUserLeaveReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LeaveReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
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
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox cbToday;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox cbSelectAllLeaveType;
        private System.Windows.Forms.CheckBox cbSelectAllStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbRevertLeave;
        private System.Windows.Forms.ComboBox cmbLeaveType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbLeaveRecords;
        private System.Windows.Forms.Label lblDue;
        private System.Windows.Forms.Label lblExpired;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblManagerApproved;
        private System.Windows.Forms.Label lblHRApproved;
        private System.Windows.Forms.Label lblReject;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.CheckBox cbCompOffUsedList;
    }
}