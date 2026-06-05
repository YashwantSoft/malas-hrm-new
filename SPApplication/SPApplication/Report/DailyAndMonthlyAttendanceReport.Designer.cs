namespace SPApplication.Report
{
    partial class DailyAndMonthlyAttendanceReport
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
            this.clbStatus = new System.Windows.Forms.CheckedListBox();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.cbSelectAllStatus = new System.Windows.Forms.CheckBox();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.clbDepartment = new System.Windows.Forms.CheckedListBox();
            this.cbSelectAllDepartment = new System.Windows.Forms.CheckBox();
            this.gbSearchEmployee = new System.Windows.Forms.GroupBox();
            this.txtSearchEmployeeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchEmployeeCode = new System.Windows.Forms.TextBox();
            this.lbEmployee = new System.Windows.Forms.ListBox();
            this.rtbEmployeeDetails = new System.Windows.Forms.RichTextBox();
            this.gbLocationAndDepartment = new System.Windows.Forms.GroupBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.gbDepartment = new System.Windows.Forms.GroupBox();
            this.lbUnitNumber = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.cmbReportName = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.cbContractor = new System.Windows.Forms.CheckBox();
            this.gbContractor = new System.Windows.Forms.GroupBox();
            this.clbContractor = new System.Windows.Forms.CheckedListBox();
            this.cbSelectAllContractor = new System.Windows.Forms.CheckBox();
            this.cmbDatePeriodType = new System.Windows.Forms.ComboBox();
            this.lblDatePeriodType = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbStatusEmployee = new System.Windows.Forms.ComboBox();
            this.lblStatusEmployee = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDatePeriodType = new System.Windows.Forms.GroupBox();
            this.gbMonthYear = new System.Windows.Forms.GroupBox();
            this.gbStatus.SuspendLayout();
            this.gbSearchEmployee.SuspendLayout();
            this.gbLocationAndDepartment.SuspendLayout();
            this.gbDepartment.SuspendLayout();
            this.gbContractor.SuspendLayout();
            this.gbDatePeriodType.SuspendLayout();
            this.gbMonthYear.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Blue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1255, 30);
            this.lblHeader.TabIndex = 11192;
            this.lblHeader.Text = "Asset Dashboard";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbToday
            // 
            this.cbToday.AutoSize = true;
            this.cbToday.Location = new System.Drawing.Point(329, 16);
            this.cbToday.Name = "cbToday";
            this.cbToday.Size = new System.Drawing.Size(58, 19);
            this.cbToday.TabIndex = 11299;
            this.cbToday.Text = "Today";
            this.cbToday.UseVisualStyleBackColor = true;
            this.cbToday.CheckedChanged += new System.EventHandler(this.cbToday_CheckedChanged);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(175, 17);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(47, 15);
            this.lblToDate.TabIndex = 11301;
            this.lblToDate.Text = "To Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(224, 14);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(100, 23);
            this.dtpToDate.TabIndex = 11298;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(6, 17);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(63, 15);
            this.lblFromDate.TabIndex = 11300;
            this.lblFromDate.Text = "From Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(71, 13);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(100, 23);
            this.dtpFromDate.TabIndex = 11297;
            // 
            // clbStatus
            // 
            this.clbStatus.FormattingEnabled = true;
            this.clbStatus.Location = new System.Drawing.Point(8, 37);
            this.clbStatus.Name = "clbStatus";
            this.clbStatus.Size = new System.Drawing.Size(386, 238);
            this.clbStatus.TabIndex = 11302;
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Location = new System.Drawing.Point(799, 163);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(60, 19);
            this.cbStatus.TabIndex = 11303;
            this.cbStatus.Text = "Status";
            this.cbStatus.UseVisualStyleBackColor = true;
            this.cbStatus.Visible = false;
            this.cbStatus.CheckedChanged += new System.EventHandler(this.cbStatus_CheckedChanged);
            // 
            // cbSelectAllStatus
            // 
            this.cbSelectAllStatus.AutoSize = true;
            this.cbSelectAllStatus.Location = new System.Drawing.Point(11, 16);
            this.cbSelectAllStatus.Name = "cbSelectAllStatus";
            this.cbSelectAllStatus.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAllStatus.TabIndex = 11304;
            this.cbSelectAllStatus.Text = "Select All";
            this.cbSelectAllStatus.UseVisualStyleBackColor = true;
            this.cbSelectAllStatus.CheckedChanged += new System.EventHandler(this.cbSelectAllStatus_CheckedChanged);
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.clbStatus);
            this.gbStatus.Controls.Add(this.cbSelectAllStatus);
            this.gbStatus.Enabled = false;
            this.gbStatus.Location = new System.Drawing.Point(462, 176);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(400, 293);
            this.gbStatus.TabIndex = 11308;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status Filter";
            this.gbStatus.Visible = false;
            // 
            // clbDepartment
            // 
            this.clbDepartment.FormattingEnabled = true;
            this.clbDepartment.Location = new System.Drawing.Point(8, 39);
            this.clbDepartment.Name = "clbDepartment";
            this.clbDepartment.Size = new System.Drawing.Size(374, 202);
            this.clbDepartment.TabIndex = 11302;
            // 
            // cbSelectAllDepartment
            // 
            this.cbSelectAllDepartment.AutoSize = true;
            this.cbSelectAllDepartment.Location = new System.Drawing.Point(11, 18);
            this.cbSelectAllDepartment.Name = "cbSelectAllDepartment";
            this.cbSelectAllDepartment.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAllDepartment.TabIndex = 11304;
            this.cbSelectAllDepartment.Text = "Select All";
            this.cbSelectAllDepartment.UseVisualStyleBackColor = true;
            this.cbSelectAllDepartment.CheckedChanged += new System.EventHandler(this.cbSelectAllDepartment_CheckedChanged);
            // 
            // gbSearchEmployee
            // 
            this.gbSearchEmployee.Controls.Add(this.txtSearchEmployeeName);
            this.gbSearchEmployee.Controls.Add(this.label4);
            this.gbSearchEmployee.Controls.Add(this.label3);
            this.gbSearchEmployee.Controls.Add(this.txtSearchEmployeeCode);
            this.gbSearchEmployee.Controls.Add(this.lbEmployee);
            this.gbSearchEmployee.Controls.Add(this.rtbEmployeeDetails);
            this.gbSearchEmployee.Location = new System.Drawing.Point(29, 175);
            this.gbSearchEmployee.Name = "gbSearchEmployee";
            this.gbSearchEmployee.Size = new System.Drawing.Size(398, 224);
            this.gbSearchEmployee.TabIndex = 11306;
            this.gbSearchEmployee.TabStop = false;
            this.gbSearchEmployee.Text = "Search Employee";
            this.gbSearchEmployee.Visible = false;
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
            this.txtSearchEmployeeCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchEmployeeCode_KeyDown);
            // 
            // lbEmployee
            // 
            this.lbEmployee.FormattingEnabled = true;
            this.lbEmployee.ItemHeight = 15;
            this.lbEmployee.Location = new System.Drawing.Point(43, 43);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(348, 169);
            this.lbEmployee.TabIndex = 1;
            this.lbEmployee.Click += new System.EventHandler(this.lbEmployee_Click);
            this.lbEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbEmployee_KeyDown);
            // 
            // rtbEmployeeDetails
            // 
            this.rtbEmployeeDetails.Location = new System.Drawing.Point(43, 41);
            this.rtbEmployeeDetails.Name = "rtbEmployeeDetails";
            this.rtbEmployeeDetails.Size = new System.Drawing.Size(348, 156);
            this.rtbEmployeeDetails.TabIndex = 11314;
            this.rtbEmployeeDetails.Text = "";
            // 
            // gbLocationAndDepartment
            // 
            this.gbLocationAndDepartment.Controls.Add(this.cmbLocation);
            this.gbLocationAndDepartment.Controls.Add(this.gbDepartment);
            this.gbLocationAndDepartment.Controls.Add(this.lbUnitNumber);
            this.gbLocationAndDepartment.Location = new System.Drawing.Point(29, 175);
            this.gbLocationAndDepartment.Name = "gbLocationAndDepartment";
            this.gbLocationAndDepartment.Size = new System.Drawing.Size(402, 294);
            this.gbLocationAndDepartment.TabIndex = 11334;
            this.gbLocationAndDepartment.TabStop = false;
            this.gbLocationAndDepartment.Text = "Location And Department";
            this.gbLocationAndDepartment.Visible = false;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(107, 19);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(271, 23);
            this.cmbLocation.TabIndex = 11331;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // gbDepartment
            // 
            this.gbDepartment.Controls.Add(this.clbDepartment);
            this.gbDepartment.Controls.Add(this.cbSelectAllDepartment);
            this.gbDepartment.Location = new System.Drawing.Point(8, 43);
            this.gbDepartment.Name = "gbDepartment";
            this.gbDepartment.Size = new System.Drawing.Size(388, 245);
            this.gbDepartment.TabIndex = 11309;
            this.gbDepartment.TabStop = false;
            this.gbDepartment.Text = "Department";
            // 
            // lbUnitNumber
            // 
            this.lbUnitNumber.AutoSize = true;
            this.lbUnitNumber.Location = new System.Drawing.Point(18, 23);
            this.lbUnitNumber.Name = "lbUnitNumber";
            this.lbUnitNumber.Size = new System.Drawing.Size(87, 15);
            this.lbUnitNumber.TabIndex = 11330;
            this.lbUnitNumber.Text = "Location Name";
            // 
            // btnView
            // 
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnView.Location = new System.Drawing.Point(589, 544);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 30);
            this.btnView.TabIndex = 11313;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Visible = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(669, 508);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11312;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(589, 508);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11311;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // cmbReportName
            // 
            this.cmbReportName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportName.FormattingEnabled = true;
            this.cmbReportName.Location = new System.Drawing.Point(88, 33);
            this.cmbReportName.Name = "cmbReportName";
            this.cmbReportName.Size = new System.Drawing.Size(330, 23);
            this.cmbReportName.TabIndex = 11317;
            this.cmbReportName.SelectionChangeCommitted += new System.EventHandler(this.cmbReportName_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 15);
            this.label9.TabIndex = 11318;
            this.label9.Text = "Report Name";
            // 
            // btnReport
            // 
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Location = new System.Drawing.Point(509, 508);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 30);
            this.btnReport.TabIndex = 11319;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // cbContractor
            // 
            this.cbContractor.AutoSize = true;
            this.cbContractor.Location = new System.Drawing.Point(1140, 163);
            this.cbContractor.Name = "cbContractor";
            this.cbContractor.Size = new System.Drawing.Size(85, 19);
            this.cbContractor.TabIndex = 11320;
            this.cbContractor.Text = "Contractor";
            this.cbContractor.UseVisualStyleBackColor = true;
            this.cbContractor.Visible = false;
            this.cbContractor.CheckedChanged += new System.EventHandler(this.cbContractor_CheckedChanged);
            // 
            // gbContractor
            // 
            this.gbContractor.Controls.Add(this.clbContractor);
            this.gbContractor.Controls.Add(this.cbSelectAllContractor);
            this.gbContractor.Enabled = false;
            this.gbContractor.Location = new System.Drawing.Point(895, 176);
            this.gbContractor.Name = "gbContractor";
            this.gbContractor.Size = new System.Drawing.Size(333, 293);
            this.gbContractor.TabIndex = 11321;
            this.gbContractor.TabStop = false;
            this.gbContractor.Text = "Contractor";
            this.gbContractor.Visible = false;
            // 
            // clbContractor
            // 
            this.clbContractor.FormattingEnabled = true;
            this.clbContractor.Location = new System.Drawing.Point(7, 37);
            this.clbContractor.Name = "clbContractor";
            this.clbContractor.Size = new System.Drawing.Size(319, 238);
            this.clbContractor.TabIndex = 11302;
            // 
            // cbSelectAllContractor
            // 
            this.cbSelectAllContractor.AutoSize = true;
            this.cbSelectAllContractor.Location = new System.Drawing.Point(11, 18);
            this.cbSelectAllContractor.Name = "cbSelectAllContractor";
            this.cbSelectAllContractor.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAllContractor.TabIndex = 11304;
            this.cbSelectAllContractor.Text = "Select All";
            this.cbSelectAllContractor.UseVisualStyleBackColor = true;
            this.cbSelectAllContractor.CheckedChanged += new System.EventHandler(this.cbSelectAllContractor_CheckedChanged);
            // 
            // cmbDatePeriodType
            // 
            this.cmbDatePeriodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDatePeriodType.FormattingEnabled = true;
            this.cmbDatePeriodType.Items.AddRange(new object[] {
            "Daily",
            "Monthly"});
            this.cmbDatePeriodType.Location = new System.Drawing.Point(550, 57);
            this.cmbDatePeriodType.Name = "cmbDatePeriodType";
            this.cmbDatePeriodType.Size = new System.Drawing.Size(330, 23);
            this.cmbDatePeriodType.TabIndex = 11322;
            this.cmbDatePeriodType.Visible = false;
            this.cmbDatePeriodType.SelectionChangeCommitted += new System.EventHandler(this.cmbDatePeriodType_SelectionChangeCommitted);
            // 
            // lblDatePeriodType
            // 
            this.lblDatePeriodType.AutoSize = true;
            this.lblDatePeriodType.Location = new System.Drawing.Point(450, 60);
            this.lblDatePeriodType.Name = "lblDatePeriodType";
            this.lblDatePeriodType.Size = new System.Drawing.Size(98, 15);
            this.lblDatePeriodType.TabIndex = 11323;
            this.lblDatePeriodType.Text = "Date Period Type";
            this.lblDatePeriodType.Visible = false;
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
            this.cmbMonth.Location = new System.Drawing.Point(53, 14);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(84, 23);
            this.cmbMonth.TabIndex = 11324;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(8, 17);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(43, 15);
            this.lblMonth.TabIndex = 11325;
            this.lblMonth.Text = "Month";
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
            this.cmbYear.Location = new System.Drawing.Point(181, 14);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(84, 23);
            this.cmbYear.TabIndex = 11326;
            // 
            // cmbStatusEmployee
            // 
            this.cmbStatusEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusEmployee.FormattingEnabled = true;
            this.cmbStatusEmployee.Items.AddRange(new object[] {
            "Working",
            "Resigned"});
            this.cmbStatusEmployee.Location = new System.Drawing.Point(88, 57);
            this.cmbStatusEmployee.Name = "cmbStatusEmployee";
            this.cmbStatusEmployee.Size = new System.Drawing.Size(141, 23);
            this.cmbStatusEmployee.TabIndex = 11315;
            this.cmbStatusEmployee.Visible = false;
            // 
            // lblStatusEmployee
            // 
            this.lblStatusEmployee.AutoSize = true;
            this.lblStatusEmployee.Location = new System.Drawing.Point(9, 61);
            this.lblStatusEmployee.Name = "lblStatusEmployee";
            this.lblStatusEmployee.Size = new System.Drawing.Size(41, 15);
            this.lblStatusEmployee.TabIndex = 11316;
            this.lblStatusEmployee.Text = "Status";
            this.lblStatusEmployee.Visible = false;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(149, 18);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(30, 15);
            this.lblYear.TabIndex = 11327;
            this.lblYear.Text = "Year";
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(550, 33);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(330, 23);
            this.cmbReportType.TabIndex = 11332;
            this.cmbReportType.SelectionChangeCommitted += new System.EventHandler(this.cmbReportType_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 11333;
            this.label1.Text = "Report Type";
            // 
            // gbDatePeriodType
            // 
            this.gbDatePeriodType.Controls.Add(this.dtpToDate);
            this.gbDatePeriodType.Controls.Add(this.dtpFromDate);
            this.gbDatePeriodType.Controls.Add(this.lblFromDate);
            this.gbDatePeriodType.Controls.Add(this.lblToDate);
            this.gbDatePeriodType.Controls.Add(this.cbToday);
            this.gbDatePeriodType.Location = new System.Drawing.Point(487, 86);
            this.gbDatePeriodType.Name = "gbDatePeriodType";
            this.gbDatePeriodType.Size = new System.Drawing.Size(412, 42);
            this.gbDatePeriodType.TabIndex = 11334;
            this.gbDatePeriodType.TabStop = false;
            this.gbDatePeriodType.Visible = false;
            // 
            // gbMonthYear
            // 
            this.gbMonthYear.Controls.Add(this.cmbYear);
            this.gbMonthYear.Controls.Add(this.lblYear);
            this.gbMonthYear.Controls.Add(this.cmbMonth);
            this.gbMonthYear.Controls.Add(this.lblMonth);
            this.gbMonthYear.Location = new System.Drawing.Point(496, 81);
            this.gbMonthYear.Name = "gbMonthYear";
            this.gbMonthYear.Size = new System.Drawing.Size(279, 42);
            this.gbMonthYear.TabIndex = 11335;
            this.gbMonthYear.TabStop = false;
            this.gbMonthYear.Visible = false;
            // 
            // DailyAndMonthlyAttendanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1252, 644);
            this.ControlBox = false;
            this.Controls.Add(this.gbDatePeriodType);
            this.Controls.Add(this.gbMonthYear);
            this.Controls.Add(this.gbLocationAndDepartment);
            this.Controls.Add(this.gbSearchEmployee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.cmbStatusEmployee);
            this.Controls.Add(this.lblStatusEmployee);
            this.Controls.Add(this.cmbDatePeriodType);
            this.Controls.Add(this.lblDatePeriodType);
            this.Controls.Add(this.cbContractor);
            this.Controls.Add(this.gbContractor);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cmbReportName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.gbStatus);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DailyAndMonthlyAttendanceReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.DailyAttendanceReport_Load);
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            this.gbSearchEmployee.ResumeLayout(false);
            this.gbSearchEmployee.PerformLayout();
            this.gbLocationAndDepartment.ResumeLayout(false);
            this.gbLocationAndDepartment.PerformLayout();
            this.gbDepartment.ResumeLayout(false);
            this.gbDepartment.PerformLayout();
            this.gbContractor.ResumeLayout(false);
            this.gbContractor.PerformLayout();
            this.gbDatePeriodType.ResumeLayout(false);
            this.gbDatePeriodType.PerformLayout();
            this.gbMonthYear.ResumeLayout(false);
            this.gbMonthYear.PerformLayout();
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
        private System.Windows.Forms.CheckedListBox clbStatus;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.CheckBox cbSelectAllStatus;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.CheckedListBox clbDepartment;
        private System.Windows.Forms.CheckBox cbSelectAllDepartment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearchEmployeeCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbEmployee;
        private System.Windows.Forms.TextBox txtSearchEmployeeName;
        private System.Windows.Forms.RichTextBox rtbEmployeeDetails;
        private System.Windows.Forms.GroupBox gbSearchEmployee;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ComboBox cmbReportName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.CheckBox cbContractor;
        private System.Windows.Forms.GroupBox gbContractor;
        private System.Windows.Forms.CheckedListBox clbContractor;
        private System.Windows.Forms.CheckBox cbSelectAllContractor;
        private System.Windows.Forms.ComboBox cmbDatePeriodType;
        private System.Windows.Forms.Label lblDatePeriodType;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbStatusEmployee;
        private System.Windows.Forms.Label lblStatusEmployee;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lbUnitNumber;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbLocationAndDepartment;
        private System.Windows.Forms.GroupBox gbDepartment;
        private System.Windows.Forms.GroupBox gbDatePeriodType;
        private System.Windows.Forms.GroupBox gbMonthYear;
    }
}