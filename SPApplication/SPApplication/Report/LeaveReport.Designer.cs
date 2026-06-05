namespace SPApplication.Report
{
    partial class LeaveReport
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
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lbUnitNumber = new System.Windows.Forms.Label();
            this.gbEmployee = new System.Windows.Forms.GroupBox();
            this.gbSearchEmployee = new System.Windows.Forms.GroupBox();
            this.txtSearchEmployeeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchEmployeeCode = new System.Windows.Forms.TextBox();
            this.lbEmployee = new System.Windows.Forms.ListBox();
            this.cbSelectAllEmployee = new System.Windows.Forms.CheckBox();
            this.rtbEmployeeDetails = new System.Windows.Forms.RichTextBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLeaveType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEmployee = new System.Windows.Forms.CheckBox();
            this.cbRevertLeave = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSelectAllStatus = new System.Windows.Forms.CheckBox();
            this.cbToday = new System.Windows.Forms.CheckBox();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.cbSelectAllLeaveType = new System.Windows.Forms.CheckBox();
            this.gbLocationDepartment = new System.Windows.Forms.GroupBox();
            this.cbSelectAllContractor = new System.Windows.Forms.CheckBox();
            this.cmbContractor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbEmployee.SuspendLayout();
            this.gbSearchEmployee.SuspendLayout();
            this.gbLocationDepartment.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Blue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1255, 30);
            this.lblHeader.TabIndex = 11193;
            this.lblHeader.Text = "Asset Dashboard";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(110, 16);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(302, 23);
            this.cmbLocation.TabIndex = 11333;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // lbUnitNumber
            // 
            this.lbUnitNumber.AutoSize = true;
            this.lbUnitNumber.Location = new System.Drawing.Point(3, 20);
            this.lbUnitNumber.Name = "lbUnitNumber";
            this.lbUnitNumber.Size = new System.Drawing.Size(87, 15);
            this.lbUnitNumber.TabIndex = 11332;
            this.lbUnitNumber.Text = "Location Name";
            // 
            // gbEmployee
            // 
            this.gbEmployee.Controls.Add(this.gbSearchEmployee);
            this.gbEmployee.Enabled = false;
            this.gbEmployee.Location = new System.Drawing.Point(147, 48);
            this.gbEmployee.Name = "gbEmployee";
            this.gbEmployee.Size = new System.Drawing.Size(412, 224);
            this.gbEmployee.TabIndex = 11334;
            this.gbEmployee.TabStop = false;
            this.gbEmployee.Text = "Employee Filter";
            // 
            // gbSearchEmployee
            // 
            this.gbSearchEmployee.Controls.Add(this.txtSearchEmployeeName);
            this.gbSearchEmployee.Controls.Add(this.label4);
            this.gbSearchEmployee.Controls.Add(this.label3);
            this.gbSearchEmployee.Controls.Add(this.txtSearchEmployeeCode);
            this.gbSearchEmployee.Controls.Add(this.lbEmployee);
            this.gbSearchEmployee.Controls.Add(this.cbSelectAllEmployee);
            this.gbSearchEmployee.Controls.Add(this.rtbEmployeeDetails);
            this.gbSearchEmployee.Location = new System.Drawing.Point(6, 18);
            this.gbSearchEmployee.Name = "gbSearchEmployee";
            this.gbSearchEmployee.Size = new System.Drawing.Size(398, 201);
            this.gbSearchEmployee.TabIndex = 11306;
            this.gbSearchEmployee.TabStop = false;
            this.gbSearchEmployee.Text = "Search Employee";
            // 
            // txtSearchEmployeeName
            // 
            this.txtSearchEmployeeName.Location = new System.Drawing.Point(43, 17);
            this.txtSearchEmployeeName.Name = "txtSearchEmployeeName";
            this.txtSearchEmployeeName.Size = new System.Drawing.Size(128, 23);
            this.txtSearchEmployeeName.TabIndex = 0;
            this.txtSearchEmployeeName.TextChanged += new System.EventHandler(this.txtSearchEmployeeName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 11313;
            this.label4.Text = "Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 11311;
            this.label3.Text = "Name";
            // 
            // txtSearchEmployeeCode
            // 
            this.txtSearchEmployeeCode.Location = new System.Drawing.Point(306, 17);
            this.txtSearchEmployeeCode.Name = "txtSearchEmployeeCode";
            this.txtSearchEmployeeCode.Size = new System.Drawing.Size(85, 23);
            this.txtSearchEmployeeCode.TabIndex = 11312;
            this.txtSearchEmployeeCode.TextChanged += new System.EventHandler(this.txtSearchEmployeeCode_TextChanged);
            this.txtSearchEmployeeCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchEmployeeCode_KeyPress);
            // 
            // lbEmployee
            // 
            this.lbEmployee.FormattingEnabled = true;
            this.lbEmployee.ItemHeight = 15;
            this.lbEmployee.Location = new System.Drawing.Point(43, 43);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(348, 154);
            this.lbEmployee.TabIndex = 1;
            this.lbEmployee.Click += new System.EventHandler(this.lbEmployee_Click);
            this.lbEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbEmployee_KeyDown);
            // 
            // cbSelectAllEmployee
            // 
            this.cbSelectAllEmployee.AutoSize = true;
            this.cbSelectAllEmployee.Location = new System.Drawing.Point(188, 18);
            this.cbSelectAllEmployee.Name = "cbSelectAllEmployee";
            this.cbSelectAllEmployee.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAllEmployee.TabIndex = 11305;
            this.cbSelectAllEmployee.Text = "Select All";
            this.cbSelectAllEmployee.UseVisualStyleBackColor = true;
            // 
            // rtbEmployeeDetails
            // 
            this.rtbEmployeeDetails.Location = new System.Drawing.Point(43, 41);
            this.rtbEmployeeDetails.Name = "rtbEmployeeDetails";
            this.rtbEmployeeDetails.Size = new System.Drawing.Size(348, 156);
            this.rtbEmployeeDetails.TabIndex = 11314;
            this.rtbEmployeeDetails.Text = "";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(110, 40);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(302, 23);
            this.cmbDepartment.TabIndex = 11336;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 11335;
            this.label1.Text = "Department Name";
            // 
            // cmbLeaveType
            // 
            this.cmbLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeaveType.FormattingEnabled = true;
            this.cmbLeaveType.Location = new System.Drawing.Point(709, 197);
            this.cmbLeaveType.Name = "cmbLeaveType";
            this.cmbLeaveType.Size = new System.Drawing.Size(302, 23);
            this.cmbLeaveType.TabIndex = 11338;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(602, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 11337;
            this.label2.Text = "Type";
            // 
            // cbEmployee
            // 
            this.cbEmployee.AutoSize = true;
            this.cbEmployee.Location = new System.Drawing.Point(479, 35);
            this.cbEmployee.Name = "cbEmployee";
            this.cbEmployee.Size = new System.Drawing.Size(78, 19);
            this.cbEmployee.TabIndex = 11316;
            this.cbEmployee.Text = "Employee";
            this.cbEmployee.UseVisualStyleBackColor = true;
            this.cbEmployee.CheckedChanged += new System.EventHandler(this.cbEmployee_CheckedChanged);
            // 
            // cbRevertLeave
            // 
            this.cbRevertLeave.AutoSize = true;
            this.cbRevertLeave.Location = new System.Drawing.Point(710, 246);
            this.cbRevertLeave.Name = "cbRevertLeave";
            this.cbRevertLeave.Size = new System.Drawing.Size(93, 19);
            this.cbRevertLeave.TabIndex = 11339;
            this.cbRevertLeave.Text = "Revert Leave";
            this.cbRevertLeave.UseVisualStyleBackColor = true;
            this.cbRevertLeave.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Location = new System.Drawing.Point(442, 290);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11343;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(575, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11342;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(736, 290);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11341;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(656, 290);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11340;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(709, 221);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(302, 23);
            this.cmbStatus.TabIndex = 11345;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(602, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 11344;
            this.label5.Text = "Status";
            // 
            // cbSelectAllStatus
            // 
            this.cbSelectAllStatus.AutoSize = true;
            this.cbSelectAllStatus.Location = new System.Drawing.Point(1017, 224);
            this.cbSelectAllStatus.Name = "cbSelectAllStatus";
            this.cbSelectAllStatus.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAllStatus.TabIndex = 11346;
            this.cbSelectAllStatus.Text = "Select All";
            this.cbSelectAllStatus.UseVisualStyleBackColor = true;
            this.cbSelectAllStatus.CheckedChanged += new System.EventHandler(this.cbSelectAllStatus_CheckedChanged);
            // 
            // cbToday
            // 
            this.cbToday.AutoSize = true;
            this.cbToday.Location = new System.Drawing.Point(1019, 62);
            this.cbToday.Name = "cbToday";
            this.cbToday.Size = new System.Drawing.Size(58, 19);
            this.cbToday.TabIndex = 11349;
            this.cbToday.Text = "Today";
            this.cbToday.UseVisualStyleBackColor = true;
            this.cbToday.CheckedChanged += new System.EventHandler(this.cbToday_CheckedChanged);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(864, 63);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(47, 15);
            this.lblToDate.TabIndex = 11351;
            this.lblToDate.Text = "To Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(913, 60);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(100, 23);
            this.dtpToDate.TabIndex = 11348;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(605, 63);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(63, 15);
            this.lblFromDate.TabIndex = 11350;
            this.lblFromDate.Text = "From Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(711, 60);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(100, 23);
            this.dtpFromDate.TabIndex = 11347;
            // 
            // cbSelectAllLeaveType
            // 
            this.cbSelectAllLeaveType.AutoSize = true;
            this.cbSelectAllLeaveType.Location = new System.Drawing.Point(1017, 199);
            this.cbSelectAllLeaveType.Name = "cbSelectAllLeaveType";
            this.cbSelectAllLeaveType.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAllLeaveType.TabIndex = 11352;
            this.cbSelectAllLeaveType.Text = "Select All";
            this.cbSelectAllLeaveType.UseVisualStyleBackColor = true;
            this.cbSelectAllLeaveType.CheckedChanged += new System.EventHandler(this.cbSelectAllLeaveType_CheckedChanged);
            // 
            // gbLocationDepartment
            // 
            this.gbLocationDepartment.Controls.Add(this.cmbDepartment);
            this.gbLocationDepartment.Controls.Add(this.lbUnitNumber);
            this.gbLocationDepartment.Controls.Add(this.cmbLocation);
            this.gbLocationDepartment.Controls.Add(this.label1);
            this.gbLocationDepartment.Location = new System.Drawing.Point(600, 86);
            this.gbLocationDepartment.Name = "gbLocationDepartment";
            this.gbLocationDepartment.Size = new System.Drawing.Size(433, 72);
            this.gbLocationDepartment.TabIndex = 11353;
            this.gbLocationDepartment.TabStop = false;
            this.gbLocationDepartment.Text = "Location and Department";
            // 
            // cbSelectAllContractor
            // 
            this.cbSelectAllContractor.AutoSize = true;
            this.cbSelectAllContractor.Location = new System.Drawing.Point(1017, 175);
            this.cbSelectAllContractor.Name = "cbSelectAllContractor";
            this.cbSelectAllContractor.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAllContractor.TabIndex = 11356;
            this.cbSelectAllContractor.Text = "Select All";
            this.cbSelectAllContractor.UseVisualStyleBackColor = true;
            this.cbSelectAllContractor.CheckedChanged += new System.EventHandler(this.cbSelectAllContractor_CheckedChanged);
            // 
            // cmbContractor
            // 
            this.cmbContractor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContractor.FormattingEnabled = true;
            this.cmbContractor.Location = new System.Drawing.Point(709, 173);
            this.cmbContractor.Name = "cmbContractor";
            this.cmbContractor.Size = new System.Drawing.Size(302, 23);
            this.cmbContractor.TabIndex = 11355;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(602, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 15);
            this.label6.TabIndex = 11354;
            this.label6.Text = "Contractor";
            // 
            // LeaveReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1253, 327);
            this.ControlBox = false;
            this.Controls.Add(this.cbSelectAllContractor);
            this.Controls.Add(this.cmbContractor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.gbLocationDepartment);
            this.Controls.Add(this.cbSelectAllLeaveType);
            this.Controls.Add(this.cbToday);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.cbSelectAllStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cbRevertLeave);
            this.Controls.Add(this.cbEmployee);
            this.Controls.Add(this.cmbLeaveType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbEmployee);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LeaveReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LeaveDashboardReport_Load);
            this.gbEmployee.ResumeLayout(false);
            this.gbSearchEmployee.ResumeLayout(false);
            this.gbSearchEmployee.PerformLayout();
            this.gbLocationDepartment.ResumeLayout(false);
            this.gbLocationDepartment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lbUnitNumber;
        private System.Windows.Forms.GroupBox gbEmployee;
        private System.Windows.Forms.GroupBox gbSearchEmployee;
        private System.Windows.Forms.TextBox txtSearchEmployeeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchEmployeeCode;
        private System.Windows.Forms.ListBox lbEmployee;
        private System.Windows.Forms.CheckBox cbSelectAllEmployee;
        private System.Windows.Forms.RichTextBox rtbEmployeeDetails;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLeaveType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbEmployee;
        private System.Windows.Forms.CheckBox cbRevertLeave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbSelectAllStatus;
        private System.Windows.Forms.CheckBox cbToday;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.CheckBox cbSelectAllLeaveType;
        private System.Windows.Forms.GroupBox gbLocationDepartment;
        private System.Windows.Forms.CheckBox cbSelectAllContractor;
        private System.Windows.Forms.ComboBox cmbContractor;
        private System.Windows.Forms.Label label6;
    }
}