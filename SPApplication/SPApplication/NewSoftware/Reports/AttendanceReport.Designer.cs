namespace SPApplication.NewSoftware.Reports
{
    partial class AttendanceReport
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
            this.lblOutdoorEntryCount = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblHRApproved = new System.Windows.Forms.Label();
            this.dgvTransferOut = new System.Windows.Forms.DataGridView();
            this.dgvTransferIN = new System.Windows.Forms.DataGridView();
            this.lblTransferCount = new System.Windows.Forms.Label();
            this.dgvAttendanceStatus = new System.Windows.Forms.DataGridView();
            this.rtbContractorWiseCount = new System.Windows.Forms.RichTextBox();
            this.lblContractorCount = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblManagerApproved = new System.Windows.Forms.Label();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.cbDevice = new System.Windows.Forms.CheckBox();
            this.cmbDevice = new System.Windows.Forms.ComboBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.cbContractor = new System.Windows.Forms.CheckBox();
            this.label51 = new System.Windows.Forms.Label();
            this.txtSearchEmpCode = new System.Windows.Forms.TextBox();
            this.cmbContractor = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cbSelectAllStatus = new System.Windows.Forms.CheckBox();
            this.cmbApprovalStatusSearch = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbDepartment = new System.Windows.Forms.CheckBox();
            this.cbLocation = new System.Windows.Forms.CheckBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbDatePeriodType = new System.Windows.Forms.GroupBox();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.cbLatePunch = new System.Windows.Forms.CheckBox();
            this.cbEarlyGoing = new System.Windows.Forms.CheckBox();
            this.cbEmployeeWise = new System.Windows.Forms.CheckBox();
            this.lbEmployee = new System.Windows.Forms.ListBox();
            this.rtbEmployee = new System.Windows.Forms.RichTextBox();
            this.gbOtherSelection = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbDatePeriodType.SuspendLayout();
            this.gbOtherSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 1);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1301, 30);
            this.lblHeader.TabIndex = 23;
            this.lblHeader.Text = "REPORTS";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOutdoorEntryCount
            // 
            this.lblOutdoorEntryCount.BackColor = System.Drawing.Color.Fuchsia;
            this.lblOutdoorEntryCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutdoorEntryCount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutdoorEntryCount.Location = new System.Drawing.Point(1072, 673);
            this.lblOutdoorEntryCount.Name = "lblOutdoorEntryCount";
            this.lblOutdoorEntryCount.Size = new System.Drawing.Size(140, 20);
            this.lblOutdoorEntryCount.TabIndex = 11476;
            this.lblOutdoorEntryCount.Text = "Completed";
            this.lblOutdoorEntryCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCount.Location = new System.Drawing.Point(196, 673);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(140, 20);
            this.lblTotalCount.TabIndex = 11474;
            this.lblTotalCount.Text = "Total Count";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHRApproved
            // 
            this.lblHRApproved.BackColor = System.Drawing.Color.Cyan;
            this.lblHRApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHRApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHRApproved.Location = new System.Drawing.Point(488, 673);
            this.lblHRApproved.Name = "lblHRApproved";
            this.lblHRApproved.Size = new System.Drawing.Size(140, 20);
            this.lblHRApproved.TabIndex = 11473;
            this.lblHRApproved.Text = "HR Approved";
            this.lblHRApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvTransferOut
            // 
            this.dgvTransferOut.AllowUserToAddRows = false;
            this.dgvTransferOut.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransferOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferOut.Location = new System.Drawing.Point(803, 135);
            this.dgvTransferOut.Name = "dgvTransferOut";
            this.dgvTransferOut.RowHeadersVisible = false;
            this.dgvTransferOut.Size = new System.Drawing.Size(243, 105);
            this.dgvTransferOut.TabIndex = 11472;
            // 
            // dgvTransferIN
            // 
            this.dgvTransferIN.AllowUserToAddRows = false;
            this.dgvTransferIN.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransferIN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferIN.Location = new System.Drawing.Point(803, 36);
            this.dgvTransferIN.Name = "dgvTransferIN";
            this.dgvTransferIN.RowHeadersVisible = false;
            this.dgvTransferIN.Size = new System.Drawing.Size(243, 98);
            this.dgvTransferIN.TabIndex = 11471;
            // 
            // lblTransferCount
            // 
            this.lblTransferCount.AutoSize = true;
            this.lblTransferCount.Location = new System.Drawing.Point(12, 676);
            this.lblTransferCount.Name = "lblTransferCount";
            this.lblTransferCount.Size = new System.Drawing.Size(87, 15);
            this.lblTransferCount.TabIndex = 11470;
            this.lblTransferCount.Text = "Transfer Count";
            // 
            // dgvAttendanceStatus
            // 
            this.dgvAttendanceStatus.AllowUserToAddRows = false;
            this.dgvAttendanceStatus.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendanceStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendanceStatus.Location = new System.Drawing.Point(433, 36);
            this.dgvAttendanceStatus.Name = "dgvAttendanceStatus";
            this.dgvAttendanceStatus.RowHeadersVisible = false;
            this.dgvAttendanceStatus.Size = new System.Drawing.Size(367, 207);
            this.dgvAttendanceStatus.TabIndex = 11469;
            // 
            // rtbContractorWiseCount
            // 
            this.rtbContractorWiseCount.BackColor = System.Drawing.Color.White;
            this.rtbContractorWiseCount.Location = new System.Drawing.Point(1052, 47);
            this.rtbContractorWiseCount.Name = "rtbContractorWiseCount";
            this.rtbContractorWiseCount.ReadOnly = true;
            this.rtbContractorWiseCount.Size = new System.Drawing.Size(218, 193);
            this.rtbContractorWiseCount.TabIndex = 11466;
            this.rtbContractorWiseCount.Text = "";
            // 
            // lblContractorCount
            // 
            this.lblContractorCount.AutoSize = true;
            this.lblContractorCount.Location = new System.Drawing.Point(1049, 31);
            this.lblContractorCount.Name = "lblContractorCount";
            this.lblContractorCount.Size = new System.Drawing.Size(138, 15);
            this.lblContractorCount.TabIndex = 11464;
            this.lblContractorCount.Text = "Contractor\'s wise Count";
            // 
            // lblRemark
            // 
            this.lblRemark.BackColor = System.Drawing.Color.Khaki;
            this.lblRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemark.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(780, 673);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(140, 20);
            this.lblRemark.TabIndex = 11462;
            this.lblRemark.Text = "Remarks";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblManagerApproved
            // 
            this.lblManagerApproved.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblManagerApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManagerApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagerApproved.Location = new System.Drawing.Point(634, 673);
            this.lblManagerApproved.Name = "lblManagerApproved";
            this.lblManagerApproved.Size = new System.Drawing.Size(140, 20);
            this.lblManagerApproved.TabIndex = 11461;
            this.lblManagerApproved.Text = "Manager Approved";
            this.lblManagerApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompleted
            // 
            this.lblCompleted.BackColor = System.Drawing.Color.Lime;
            this.lblCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompleted.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleted.Location = new System.Drawing.Point(926, 673);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(140, 20);
            this.lblCompleted.TabIndex = 11460;
            this.lblCompleted.Text = "Completed";
            this.lblCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPending
            // 
            this.lblPending.BackColor = System.Drawing.Color.Yellow;
            this.lblPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPending.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.Location = new System.Drawing.Point(342, 673);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(140, 20);
            this.lblPending.TabIndex = 11459;
            this.lblPending.Text = "Pending";
            this.lblPending.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbDevice
            // 
            this.cbDevice.AutoSize = true;
            this.cbDevice.Location = new System.Drawing.Point(222, 86);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(62, 19);
            this.cbDevice.TabIndex = 11458;
            this.cbDevice.Text = "Device";
            this.cbDevice.UseVisualStyleBackColor = true;
            this.cbDevice.CheckedChanged += new System.EventHandler(this.cbDevice_CheckedChanged);
            // 
            // cmbDevice
            // 
            this.cmbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevice.FormattingEnabled = true;
            this.cmbDevice.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cmbDevice.Location = new System.Drawing.Point(287, 83);
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.Size = new System.Drawing.Size(86, 23);
            this.cmbDevice.TabIndex = 11457;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(125, 78);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(119, 23);
            this.txtEmployeeName.TabIndex = 11455;
            this.txtEmployeeName.TextChanged += new System.EventHandler(this.txtEmployeeName_TextChanged);
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Location = new System.Drawing.Point(9, 246);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(60, 19);
            this.cbStatus.TabIndex = 11454;
            this.cbStatus.Text = "Status";
            this.cbStatus.UseVisualStyleBackColor = true;
            this.cbStatus.CheckedChanged += new System.EventHandler(this.cbStatus_CheckedChanged);
            // 
            // cbContractor
            // 
            this.cbContractor.AutoSize = true;
            this.cbContractor.Location = new System.Drawing.Point(5, 60);
            this.cbContractor.Name = "cbContractor";
            this.cbContractor.Size = new System.Drawing.Size(85, 19);
            this.cbContractor.TabIndex = 11453;
            this.cbContractor.Text = "Contractor";
            this.cbContractor.UseVisualStyleBackColor = true;
            this.cbContractor.CheckedChanged += new System.EventHandler(this.cbContractor_CheckedChanged);
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(255, 82);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(63, 15);
            this.label51.TabIndex = 11452;
            this.label51.Text = "Emp. Code";
            // 
            // txtSearchEmpCode
            // 
            this.txtSearchEmpCode.Location = new System.Drawing.Point(320, 78);
            this.txtSearchEmpCode.Name = "txtSearchEmpCode";
            this.txtSearchEmpCode.Size = new System.Drawing.Size(56, 23);
            this.txtSearchEmpCode.TabIndex = 11451;
            this.txtSearchEmpCode.TextChanged += new System.EventHandler(this.txtSearchEmpCode_TextChanged);
            this.txtSearchEmpCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchEmpCode_KeyPress);
            this.txtSearchEmpCode.Leave += new System.EventHandler(this.txtSearchEmpCode_Leave);
            // 
            // cmbContractor
            // 
            this.cmbContractor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContractor.FormattingEnabled = true;
            this.cmbContractor.Location = new System.Drawing.Point(120, 59);
            this.cmbContractor.Name = "cmbContractor";
            this.cmbContractor.Size = new System.Drawing.Size(253, 23);
            this.cmbContractor.TabIndex = 11450;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "All",
            "Working",
            "Resigned"});
            this.cmbStatus.Location = new System.Drawing.Point(125, 244);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(94, 23);
            this.cmbStatus.TabIndex = 11449;
            // 
            // cbSelectAllStatus
            // 
            this.cbSelectAllStatus.AutoSize = true;
            this.cbSelectAllStatus.Location = new System.Drawing.Point(5, 84);
            this.cbSelectAllStatus.Name = "cbSelectAllStatus";
            this.cbSelectAllStatus.Size = new System.Drawing.Size(113, 19);
            this.cbSelectAllStatus.TabIndex = 11448;
            this.cbSelectAllStatus.Text = "Approval Status";
            this.cbSelectAllStatus.UseVisualStyleBackColor = true;
            this.cbSelectAllStatus.CheckedChanged += new System.EventHandler(this.cbSelectAllStatus_CheckedChanged);
            // 
            // cmbApprovalStatusSearch
            // 
            this.cmbApprovalStatusSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApprovalStatusSearch.FormattingEnabled = true;
            this.cmbApprovalStatusSearch.Location = new System.Drawing.Point(120, 83);
            this.cmbApprovalStatusSearch.Name = "cmbApprovalStatusSearch";
            this.cmbApprovalStatusSearch.Size = new System.Drawing.Size(94, 23);
            this.cmbApprovalStatusSearch.TabIndex = 11447;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 285);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1278, 383);
            this.dataGridView1.TabIndex = 11446;
            this.dataGridView1.TabStop = false;
            // 
            // cbDepartment
            // 
            this.cbDepartment.AutoSize = true;
            this.cbDepartment.Location = new System.Drawing.Point(5, 36);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(90, 19);
            this.cbDepartment.TabIndex = 11445;
            this.cbDepartment.Text = "Department";
            this.cbDepartment.UseVisualStyleBackColor = true;
            this.cbDepartment.CheckedChanged += new System.EventHandler(this.cbDepartment_CheckedChanged);
            // 
            // cbLocation
            // 
            this.cbLocation.AutoSize = true;
            this.cbLocation.Location = new System.Drawing.Point(5, 12);
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.Size = new System.Drawing.Size(72, 19);
            this.cbLocation.TabIndex = 11444;
            this.cbLocation.Text = "Location";
            this.cbLocation.UseVisualStyleBackColor = true;
            this.cbLocation.CheckedChanged += new System.EventHandler(this.cbLocation_CheckedChanged);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(120, 35);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(253, 23);
            this.cmbDepartment.TabIndex = 11441;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(120, 11);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(253, 23);
            this.cmbLocation.TabIndex = 11440;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(690, 249);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11436;
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
            this.btnDelete.Location = new System.Drawing.Point(534, 249);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11435;
            this.btnDelete.Text = "Search";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(612, 249);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11434;
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
            this.btnSave.Location = new System.Drawing.Point(889, 249);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11433;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbDatePeriodType
            // 
            this.gbDatePeriodType.Controls.Add(this.cmbReportType);
            this.gbDatePeriodType.Controls.Add(this.dtpToDate);
            this.gbDatePeriodType.Controls.Add(this.dtpFromDate);
            this.gbDatePeriodType.Controls.Add(this.label2);
            this.gbDatePeriodType.Controls.Add(this.lblToDate);
            this.gbDatePeriodType.Location = new System.Drawing.Point(6, 32);
            this.gbDatePeriodType.Name = "gbDatePeriodType";
            this.gbDatePeriodType.Size = new System.Drawing.Size(411, 42);
            this.gbDatePeriodType.TabIndex = 11477;
            this.gbDatePeriodType.TabStop = false;
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "All",
            "Working",
            "Resigned"});
            this.cmbReportType.Location = new System.Drawing.Point(307, 14);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(95, 23);
            this.cmbReportType.TabIndex = 11478;
            this.cmbReportType.SelectionChangeCommitted += new System.EventHandler(this.cmbReportType_SelectionChangeCommitted);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(212, 14);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(90, 23);
            this.dtpToDate.TabIndex = 11298;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(71, 13);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(90, 23);
            this.dtpFromDate.TabIndex = 11297;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 11300;
            this.label2.Text = "From Date";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(163, 17);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(47, 15);
            this.lblToDate.TabIndex = 11301;
            this.lblToDate.Text = "To Date";
            // 
            // cbLatePunch
            // 
            this.cbLatePunch.AutoSize = true;
            this.cbLatePunch.Location = new System.Drawing.Point(226, 247);
            this.cbLatePunch.Name = "cbLatePunch";
            this.cbLatePunch.Size = new System.Drawing.Size(82, 19);
            this.cbLatePunch.TabIndex = 11478;
            this.cbLatePunch.Text = "LatePunch";
            this.cbLatePunch.UseVisualStyleBackColor = true;
            this.cbLatePunch.CheckedChanged += new System.EventHandler(this.cbLatePunch_CheckedChanged);
            // 
            // cbEarlyGoing
            // 
            this.cbEarlyGoing.AutoSize = true;
            this.cbEarlyGoing.Location = new System.Drawing.Point(316, 247);
            this.cbEarlyGoing.Name = "cbEarlyGoing";
            this.cbEarlyGoing.Size = new System.Drawing.Size(89, 19);
            this.cbEarlyGoing.TabIndex = 11479;
            this.cbEarlyGoing.Text = "Early Going";
            this.cbEarlyGoing.UseVisualStyleBackColor = true;
            this.cbEarlyGoing.CheckedChanged += new System.EventHandler(this.cbEarlyGoing_CheckedChanged);
            // 
            // cbEmployeeWise
            // 
            this.cbEmployeeWise.AutoSize = true;
            this.cbEmployeeWise.Location = new System.Drawing.Point(10, 80);
            this.cbEmployeeWise.Name = "cbEmployeeWise";
            this.cbEmployeeWise.Size = new System.Drawing.Size(109, 19);
            this.cbEmployeeWise.TabIndex = 11481;
            this.cbEmployeeWise.Text = "Employee Wise";
            this.cbEmployeeWise.UseVisualStyleBackColor = true;
            this.cbEmployeeWise.CheckedChanged += new System.EventHandler(this.cbEmployeeWise_CheckedChanged);
            // 
            // lbEmployee
            // 
            this.lbEmployee.FormattingEnabled = true;
            this.lbEmployee.ItemHeight = 15;
            this.lbEmployee.Location = new System.Drawing.Point(8, 105);
            this.lbEmployee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(418, 139);
            this.lbEmployee.TabIndex = 11482;
            this.lbEmployee.Click += new System.EventHandler(this.lbEmployee_Click);
            this.lbEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbEmployee_KeyDown);
            // 
            // rtbEmployee
            // 
            this.rtbEmployee.Location = new System.Drawing.Point(8, 104);
            this.rtbEmployee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtbEmployee.Name = "rtbEmployee";
            this.rtbEmployee.ReadOnly = true;
            this.rtbEmployee.Size = new System.Drawing.Size(418, 137);
            this.rtbEmployee.TabIndex = 11483;
            this.rtbEmployee.Text = "";
            // 
            // gbOtherSelection
            // 
            this.gbOtherSelection.Controls.Add(this.cbSelectAllStatus);
            this.gbOtherSelection.Controls.Add(this.cmbLocation);
            this.gbOtherSelection.Controls.Add(this.cmbDevice);
            this.gbOtherSelection.Controls.Add(this.cbDevice);
            this.gbOtherSelection.Controls.Add(this.cmbApprovalStatusSearch);
            this.gbOtherSelection.Controls.Add(this.cmbDepartment);
            this.gbOtherSelection.Controls.Add(this.cbDepartment);
            this.gbOtherSelection.Controls.Add(this.cbContractor);
            this.gbOtherSelection.Controls.Add(this.cmbContractor);
            this.gbOtherSelection.Controls.Add(this.cbLocation);
            this.gbOtherSelection.Location = new System.Drawing.Point(11, 107);
            this.gbOtherSelection.Name = "gbOtherSelection";
            this.gbOtherSelection.Size = new System.Drawing.Size(406, 110);
            this.gbOtherSelection.TabIndex = 11486;
            this.gbOtherSelection.TabStop = false;
            // 
            // AttendanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1298, 698);
            this.ControlBox = false;
            this.Controls.Add(this.gbOtherSelection);
            this.Controls.Add(this.lbEmployee);
            this.Controls.Add(this.rtbEmployee);
            this.Controls.Add(this.cbEmployeeWise);
            this.Controls.Add(this.cbEarlyGoing);
            this.Controls.Add(this.cbLatePunch);
            this.Controls.Add(this.gbDatePeriodType);
            this.Controls.Add(this.lblOutdoorEntryCount);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.lblHRApproved);
            this.Controls.Add(this.dgvTransferOut);
            this.Controls.Add(this.dgvTransferIN);
            this.Controls.Add(this.lblTransferCount);
            this.Controls.Add(this.dgvAttendanceStatus);
            this.Controls.Add(this.rtbContractorWiseCount);
            this.Controls.Add(this.lblContractorCount);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblManagerApproved);
            this.Controls.Add(this.lblCompleted);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.txtSearchEmpCode);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.cmbStatus);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AttendanceReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CommanReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbDatePeriodType.ResumeLayout(false);
            this.gbDatePeriodType.PerformLayout();
            this.gbOtherSelection.ResumeLayout(false);
            this.gbOtherSelection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblOutdoorEntryCount;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblHRApproved;
        private System.Windows.Forms.DataGridView dgvTransferOut;
        private System.Windows.Forms.DataGridView dgvTransferIN;
        private System.Windows.Forms.Label lblTransferCount;
        private System.Windows.Forms.DataGridView dgvAttendanceStatus;
        private System.Windows.Forms.RichTextBox rtbContractorWiseCount;
        private System.Windows.Forms.Label lblContractorCount;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblManagerApproved;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.CheckBox cbDevice;
        private System.Windows.Forms.ComboBox cmbDevice;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.CheckBox cbContractor;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox txtSearchEmpCode;
        private System.Windows.Forms.ComboBox cmbContractor;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.CheckBox cbSelectAllStatus;
        private System.Windows.Forms.ComboBox cmbApprovalStatusSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox cbDepartment;
        private System.Windows.Forms.CheckBox cbLocation;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbDatePeriodType;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.CheckBox cbLatePunch;
        private System.Windows.Forms.CheckBox cbEarlyGoing;
        private System.Windows.Forms.CheckBox cbEmployeeWise;
        private System.Windows.Forms.ListBox lbEmployee;
        private System.Windows.Forms.RichTextBox rtbEmployee;
        private System.Windows.Forms.GroupBox gbOtherSelection;
    }
}