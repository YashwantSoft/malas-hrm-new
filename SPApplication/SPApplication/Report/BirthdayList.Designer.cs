namespace SPApplication.Report
{
    partial class BirthdayList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cbSelectAllLocation = new System.Windows.Forms.CheckBox();
            this.cbSelectAllDepartment = new System.Windows.Forms.CheckBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.cbDateWise = new System.Windows.Forms.CheckBox();
            this.dtpSearchDate = new System.Windows.Forms.DateTimePicker();
            this.gbMonth = new System.Windows.Forms.GroupBox();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.clmSrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeConcat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmpInital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMobileNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPersonalEmailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRoll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDesignation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmJobProfile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDOJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployementType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbMonth.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1231, 30);
            this.lblHeader.TabIndex = 11414;
            this.lblHeader.Text = "Database";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReport
            // 
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Location = new System.Drawing.Point(403, 107);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 30);
            this.btnReport.TabIndex = 11425;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
            // 
            // btnView
            // 
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnView.Location = new System.Drawing.Point(567, 104);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 30);
            this.btnView.TabIndex = 11424;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(728, 104);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11423;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(648, 104);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11422;
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
            this.clmEmployeeId,
            this.clmDOB,
            this.clmEmployeeCode,
            this.clmEmployeeConcat,
            this.clmEmpInital,
            this.clmEmployeeName,
            this.clmGender,
            this.clmAge,
            this.clmMobileNo,
            this.clmPersonalEmailID,
            this.clmLocation,
            this.clmDepartment,
            this.clmRoll,
            this.clmDesignation,
            this.clmJobProfile,
            this.clmDOJ,
            this.clmEmployementType});
            this.dataGridView1.Location = new System.Drawing.Point(12, 140);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1174, 546);
            this.dataGridView1.TabIndex = 11426;
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
            this.cmbYear.Location = new System.Drawing.Point(907, 37);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(100, 23);
            this.cmbYear.TabIndex = 11442;
            this.cmbYear.Visible = false;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(875, 40);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(30, 15);
            this.lblYear.TabIndex = 11441;
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
            this.cmbMonth.Location = new System.Drawing.Point(88, 12);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(100, 23);
            this.cmbMonth.TabIndex = 11440;
            this.cmbMonth.SelectionChangeCommitted += new System.EventHandler(this.cmbMonth_SelectionChangeCommitted);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(7, 16);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(43, 15);
            this.lblMonth.TabIndex = 11439;
            this.lblMonth.Text = "Month";
            // 
            // cbSelectAllLocation
            // 
            this.cbSelectAllLocation.AutoSize = true;
            this.cbSelectAllLocation.Location = new System.Drawing.Point(11, 36);
            this.cbSelectAllLocation.Name = "cbSelectAllLocation";
            this.cbSelectAllLocation.Size = new System.Drawing.Size(72, 19);
            this.cbSelectAllLocation.TabIndex = 11446;
            this.cbSelectAllLocation.Text = "Location";
            this.cbSelectAllLocation.UseVisualStyleBackColor = true;
            this.cbSelectAllLocation.CheckedChanged += new System.EventHandler(this.cbSelectAllLocation_CheckedChanged);
            // 
            // cbSelectAllDepartment
            // 
            this.cbSelectAllDepartment.AutoSize = true;
            this.cbSelectAllDepartment.Location = new System.Drawing.Point(11, 59);
            this.cbSelectAllDepartment.Name = "cbSelectAllDepartment";
            this.cbSelectAllDepartment.Size = new System.Drawing.Size(90, 19);
            this.cbSelectAllDepartment.TabIndex = 11445;
            this.cbSelectAllDepartment.Text = "Department";
            this.cbSelectAllDepartment.UseVisualStyleBackColor = true;
            this.cbSelectAllDepartment.CheckedChanged += new System.EventHandler(this.cbSelectAllDepartment_CheckedChanged);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(109, 58);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(251, 23);
            this.cmbDepartment.TabIndex = 11444;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(109, 34);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(251, 23);
            this.cmbLocation.TabIndex = 11443;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // cbDateWise
            // 
            this.cbDateWise.AutoSize = true;
            this.cbDateWise.Location = new System.Drawing.Point(375, 37);
            this.cbDateWise.Name = "cbDateWise";
            this.cbDateWise.Size = new System.Drawing.Size(82, 19);
            this.cbDateWise.TabIndex = 11449;
            this.cbDateWise.Text = "Date Wise";
            this.cbDateWise.UseVisualStyleBackColor = true;
            this.cbDateWise.CheckedChanged += new System.EventHandler(this.cbDateWise_CheckedChanged);
            // 
            // dtpSearchDate
            // 
            this.dtpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSearchDate.Location = new System.Drawing.Point(463, 34);
            this.dtpSearchDate.Name = "dtpSearchDate";
            this.dtpSearchDate.Size = new System.Drawing.Size(100, 23);
            this.dtpSearchDate.TabIndex = 11447;
            this.dtpSearchDate.Visible = false;
            // 
            // gbMonth
            // 
            this.gbMonth.Controls.Add(this.lblMonth);
            this.gbMonth.Controls.Add(this.cmbMonth);
            this.gbMonth.Location = new System.Drawing.Point(375, 57);
            this.gbMonth.Name = "gbMonth";
            this.gbMonth.Size = new System.Drawing.Size(209, 41);
            this.gbMonth.TabIndex = 11450;
            this.gbMonth.TabStop = false;
            this.gbMonth.Visible = false;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(15, 123);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11451;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // clmSrNo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmSrNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmSrNo.HeaderText = "Sr.No.";
            this.clmSrNo.Name = "clmSrNo";
            this.clmSrNo.ReadOnly = true;
            this.clmSrNo.Width = 40;
            // 
            // clmEmployeeId
            // 
            this.clmEmployeeId.HeaderText = "Employee Id";
            this.clmEmployeeId.Name = "clmEmployeeId";
            this.clmEmployeeId.ReadOnly = true;
            this.clmEmployeeId.Visible = false;
            // 
            // clmDOB
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.clmDOB.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmDOB.HeaderText = "DOB";
            this.clmDOB.Name = "clmDOB";
            this.clmDOB.ReadOnly = true;
            this.clmDOB.Width = 90;
            // 
            // clmEmployeeCode
            // 
            this.clmEmployeeCode.HeaderText = "Employee Code";
            this.clmEmployeeCode.Name = "clmEmployeeCode";
            this.clmEmployeeCode.ReadOnly = true;
            this.clmEmployeeCode.Width = 80;
            // 
            // clmEmployeeConcat
            // 
            this.clmEmployeeConcat.HeaderText = "Employee Name";
            this.clmEmployeeConcat.Name = "clmEmployeeConcat";
            this.clmEmployeeConcat.ReadOnly = true;
            this.clmEmployeeConcat.Width = 250;
            // 
            // clmEmpInital
            // 
            this.clmEmpInital.HeaderText = "EmpInital";
            this.clmEmpInital.Name = "clmEmpInital";
            this.clmEmpInital.ReadOnly = true;
            this.clmEmpInital.Visible = false;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.HeaderText = "Employee Name";
            this.clmEmployeeName.Name = "clmEmployeeName";
            this.clmEmployeeName.ReadOnly = true;
            this.clmEmployeeName.Visible = false;
            this.clmEmployeeName.Width = 250;
            // 
            // clmGender
            // 
            this.clmGender.HeaderText = "Gender";
            this.clmGender.Name = "clmGender";
            this.clmGender.ReadOnly = true;
            this.clmGender.Width = 60;
            // 
            // clmAge
            // 
            this.clmAge.HeaderText = "Age";
            this.clmAge.Name = "clmAge";
            this.clmAge.ReadOnly = true;
            this.clmAge.Width = 40;
            // 
            // clmMobileNo
            // 
            this.clmMobileNo.HeaderText = "Mobile No";
            this.clmMobileNo.Name = "clmMobileNo";
            this.clmMobileNo.ReadOnly = true;
            // 
            // clmPersonalEmailID
            // 
            this.clmPersonalEmailID.HeaderText = "Email Id";
            this.clmPersonalEmailID.Name = "clmPersonalEmailID";
            this.clmPersonalEmailID.ReadOnly = true;
            this.clmPersonalEmailID.Visible = false;
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
            this.clmDepartment.Width = 150;
            // 
            // clmRoll
            // 
            this.clmRoll.HeaderText = "Roll";
            this.clmRoll.Name = "clmRoll";
            this.clmRoll.ReadOnly = true;
            // 
            // clmDesignation
            // 
            this.clmDesignation.HeaderText = "Designation";
            this.clmDesignation.Name = "clmDesignation";
            this.clmDesignation.ReadOnly = true;
            // 
            // clmJobProfile
            // 
            this.clmJobProfile.HeaderText = "Job Profile";
            this.clmJobProfile.Name = "clmJobProfile";
            this.clmJobProfile.ReadOnly = true;
            this.clmJobProfile.Visible = false;
            // 
            // clmDOJ
            // 
            this.clmDOJ.HeaderText = "DOJ";
            this.clmDOJ.Name = "clmDOJ";
            this.clmDOJ.ReadOnly = true;
            this.clmDOJ.Visible = false;
            // 
            // clmEmployementType
            // 
            this.clmEmployementType.HeaderText = "Employement Type";
            this.clmEmployementType.Name = "clmEmployementType";
            this.clmEmployementType.ReadOnly = true;
            this.clmEmployementType.Visible = false;
            // 
            // BirthdayList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 698);
            this.ControlBox = false;
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.gbMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cbDateWise);
            this.Controls.Add(this.dtpSearchDate);
            this.Controls.Add(this.cbSelectAllLocation);
            this.Controls.Add(this.cbSelectAllDepartment);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "BirthdayList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.BirthdayList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbMonth.ResumeLayout(false);
            this.gbMonth.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.CheckBox cbSelectAllLocation;
        private System.Windows.Forms.CheckBox cbSelectAllDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.CheckBox cbDateWise;
        private System.Windows.Forms.DateTimePicker dtpSearchDate;
        private System.Windows.Forms.GroupBox gbMonth;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeConcat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmpInital;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMobileNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPersonalEmailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRoll;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDesignation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmJobProfile;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDOJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployementType;
    }
}