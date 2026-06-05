namespace SPApplication.NewSoftware.Reports
{
    partial class EmployeeAttendanceReport
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
            this.lbEmployee = new System.Windows.Forms.ListBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.rtbEmployee = new System.Windows.Forms.RichTextBox();
            this.cbEarlyGoing = new System.Windows.Forms.CheckBox();
            this.cbLatePunch = new System.Windows.Forms.CheckBox();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.gbDatePeriodType = new System.Windows.Forms.GroupBox();
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
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.label51 = new System.Windows.Forms.Label();
            this.txtSearchEmpCode = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbDatePeriodType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceStatus)).BeginInit();
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
            this.lblHeader.Size = new System.Drawing.Size(1299, 30);
            this.lblHeader.TabIndex = 23;
            this.lblHeader.Text = "INDVIDUALS ATTENDANCE REPORT";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbEmployee
            // 
            this.lbEmployee.FormattingEnabled = true;
            this.lbEmployee.ItemHeight = 15;
            this.lbEmployee.Location = new System.Drawing.Point(111, 103);
            this.lbEmployee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(315, 139);
            this.lbEmployee.TabIndex = 11516;
            this.lbEmployee.Click += new System.EventHandler(this.lbEmployee_Click);
            this.lbEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbEmployee_KeyDown);
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
            // rtbEmployee
            // 
            this.rtbEmployee.Location = new System.Drawing.Point(111, 102);
            this.rtbEmployee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtbEmployee.Name = "rtbEmployee";
            this.rtbEmployee.ReadOnly = true;
            this.rtbEmployee.Size = new System.Drawing.Size(315, 146);
            this.rtbEmployee.TabIndex = 11517;
            this.rtbEmployee.Text = "";
            // 
            // cbEarlyGoing
            // 
            this.cbEarlyGoing.AutoSize = true;
            this.cbEarlyGoing.Location = new System.Drawing.Point(302, 254);
            this.cbEarlyGoing.Name = "cbEarlyGoing";
            this.cbEarlyGoing.Size = new System.Drawing.Size(89, 19);
            this.cbEarlyGoing.TabIndex = 11513;
            this.cbEarlyGoing.Text = "Early Going";
            this.cbEarlyGoing.UseVisualStyleBackColor = true;
            // 
            // cbLatePunch
            // 
            this.cbLatePunch.AutoSize = true;
            this.cbLatePunch.Location = new System.Drawing.Point(212, 254);
            this.cbLatePunch.Name = "cbLatePunch";
            this.cbLatePunch.Size = new System.Drawing.Size(82, 19);
            this.cbLatePunch.TabIndex = 11512;
            this.cbLatePunch.Text = "LatePunch";
            this.cbLatePunch.UseVisualStyleBackColor = true;
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
            // gbDatePeriodType
            // 
            this.gbDatePeriodType.Controls.Add(this.cmbReportType);
            this.gbDatePeriodType.Controls.Add(this.dtpToDate);
            this.gbDatePeriodType.Controls.Add(this.dtpFromDate);
            this.gbDatePeriodType.Controls.Add(this.label2);
            this.gbDatePeriodType.Controls.Add(this.lblToDate);
            this.gbDatePeriodType.Location = new System.Drawing.Point(6, 31);
            this.gbDatePeriodType.Name = "gbDatePeriodType";
            this.gbDatePeriodType.Size = new System.Drawing.Size(421, 42);
            this.gbDatePeriodType.TabIndex = 11511;
            this.gbDatePeriodType.TabStop = false;
            // 
            // lblOutdoorEntryCount
            // 
            this.lblOutdoorEntryCount.BackColor = System.Drawing.Color.Fuchsia;
            this.lblOutdoorEntryCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutdoorEntryCount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutdoorEntryCount.Location = new System.Drawing.Point(1072, 675);
            this.lblOutdoorEntryCount.Name = "lblOutdoorEntryCount";
            this.lblOutdoorEntryCount.Size = new System.Drawing.Size(140, 20);
            this.lblOutdoorEntryCount.TabIndex = 11510;
            this.lblOutdoorEntryCount.Text = "Completed";
            this.lblOutdoorEntryCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalCount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCount.Location = new System.Drawing.Point(196, 675);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(140, 20);
            this.lblTotalCount.TabIndex = 11509;
            this.lblTotalCount.Text = "Total Count";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHRApproved
            // 
            this.lblHRApproved.BackColor = System.Drawing.Color.Cyan;
            this.lblHRApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHRApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHRApproved.Location = new System.Drawing.Point(488, 675);
            this.lblHRApproved.Name = "lblHRApproved";
            this.lblHRApproved.Size = new System.Drawing.Size(140, 20);
            this.lblHRApproved.TabIndex = 11508;
            this.lblHRApproved.Text = "HR Approved";
            this.lblHRApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvTransferOut
            // 
            this.dgvTransferOut.AllowUserToAddRows = false;
            this.dgvTransferOut.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransferOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferOut.Location = new System.Drawing.Point(803, 137);
            this.dgvTransferOut.Name = "dgvTransferOut";
            this.dgvTransferOut.RowHeadersVisible = false;
            this.dgvTransferOut.Size = new System.Drawing.Size(243, 105);
            this.dgvTransferOut.TabIndex = 11507;
            // 
            // dgvTransferIN
            // 
            this.dgvTransferIN.AllowUserToAddRows = false;
            this.dgvTransferIN.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransferIN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferIN.Location = new System.Drawing.Point(803, 38);
            this.dgvTransferIN.Name = "dgvTransferIN";
            this.dgvTransferIN.RowHeadersVisible = false;
            this.dgvTransferIN.Size = new System.Drawing.Size(243, 98);
            this.dgvTransferIN.TabIndex = 11506;
            // 
            // lblTransferCount
            // 
            this.lblTransferCount.AutoSize = true;
            this.lblTransferCount.Location = new System.Drawing.Point(12, 678);
            this.lblTransferCount.Name = "lblTransferCount";
            this.lblTransferCount.Size = new System.Drawing.Size(87, 15);
            this.lblTransferCount.TabIndex = 11505;
            this.lblTransferCount.Text = "Transfer Count";
            // 
            // dgvAttendanceStatus
            // 
            this.dgvAttendanceStatus.AllowUserToAddRows = false;
            this.dgvAttendanceStatus.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendanceStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendanceStatus.Location = new System.Drawing.Point(433, 38);
            this.dgvAttendanceStatus.Name = "dgvAttendanceStatus";
            this.dgvAttendanceStatus.RowHeadersVisible = false;
            this.dgvAttendanceStatus.Size = new System.Drawing.Size(367, 207);
            this.dgvAttendanceStatus.TabIndex = 11504;
            // 
            // rtbContractorWiseCount
            // 
            this.rtbContractorWiseCount.BackColor = System.Drawing.Color.White;
            this.rtbContractorWiseCount.Location = new System.Drawing.Point(1052, 49);
            this.rtbContractorWiseCount.Name = "rtbContractorWiseCount";
            this.rtbContractorWiseCount.ReadOnly = true;
            this.rtbContractorWiseCount.Size = new System.Drawing.Size(218, 193);
            this.rtbContractorWiseCount.TabIndex = 11503;
            this.rtbContractorWiseCount.Text = "";
            // 
            // lblContractorCount
            // 
            this.lblContractorCount.AutoSize = true;
            this.lblContractorCount.Location = new System.Drawing.Point(1049, 33);
            this.lblContractorCount.Name = "lblContractorCount";
            this.lblContractorCount.Size = new System.Drawing.Size(138, 15);
            this.lblContractorCount.TabIndex = 11502;
            this.lblContractorCount.Text = "Contractor\'s wise Count";
            // 
            // lblRemark
            // 
            this.lblRemark.BackColor = System.Drawing.Color.Khaki;
            this.lblRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemark.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(780, 675);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(140, 20);
            this.lblRemark.TabIndex = 11501;
            this.lblRemark.Text = "Remarks";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblManagerApproved
            // 
            this.lblManagerApproved.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblManagerApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManagerApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagerApproved.Location = new System.Drawing.Point(634, 675);
            this.lblManagerApproved.Name = "lblManagerApproved";
            this.lblManagerApproved.Size = new System.Drawing.Size(140, 20);
            this.lblManagerApproved.TabIndex = 11500;
            this.lblManagerApproved.Text = "Manager Approved";
            this.lblManagerApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompleted
            // 
            this.lblCompleted.BackColor = System.Drawing.Color.Lime;
            this.lblCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompleted.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleted.Location = new System.Drawing.Point(926, 675);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(140, 20);
            this.lblCompleted.TabIndex = 11499;
            this.lblCompleted.Text = "Completed";
            this.lblCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPending
            // 
            this.lblPending.BackColor = System.Drawing.Color.Yellow;
            this.lblPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPending.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.Location = new System.Drawing.Point(342, 675);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(140, 20);
            this.lblPending.TabIndex = 11498;
            this.lblPending.Text = "Pending";
            this.lblPending.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(111, 76);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(133, 23);
            this.txtEmployeeName.TabIndex = 11497;
            this.txtEmployeeName.TextChanged += new System.EventHandler(this.txtEmployeeName_TextChanged);
            this.txtEmployeeName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeName_KeyDown);
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Location = new System.Drawing.Point(49, 253);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(60, 19);
            this.cbStatus.TabIndex = 11496;
            this.cbStatus.Text = "Status";
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(306, 80);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(63, 15);
            this.label51.TabIndex = 11495;
            this.label51.Text = "Emp. Code";
            // 
            // txtSearchEmpCode
            // 
            this.txtSearchEmpCode.Location = new System.Drawing.Point(371, 76);
            this.txtSearchEmpCode.Name = "txtSearchEmpCode";
            this.txtSearchEmpCode.Size = new System.Drawing.Size(56, 23);
            this.txtSearchEmpCode.TabIndex = 11494;
            this.txtSearchEmpCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchEmpCode_KeyPress);
            this.txtSearchEmpCode.Leave += new System.EventHandler(this.txtSearchEmpCode_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 287);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1278, 383);
            this.dataGridView1.TabIndex = 11492;
            this.dataGridView1.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(534, 251);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11490;
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
            this.btnClear.Location = new System.Drawing.Point(612, 251);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11489;
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
            this.btnSave.Location = new System.Drawing.Point(1211, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11488;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(690, 251);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11491;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "All",
            "Working",
            "Resigned"});
            this.cmbStatus.Location = new System.Drawing.Point(111, 251);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(94, 23);
            this.cmbStatus.TabIndex = 11493;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 15);
            this.label1.TabIndex = 11518;
            this.label1.Text = "Search Employee";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 105);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 15);
            this.label3.TabIndex = 11519;
            this.label3.Text = "Employee Details";
            // 
            // EmployeeAttendanceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1298, 698);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbEmployee);
            this.Controls.Add(this.rtbEmployee);
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
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "EmployeeAttendanceReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EmployeeAttendanceReport_Load);
            this.gbDatePeriodType.ResumeLayout(false);
            this.gbDatePeriodType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ListBox lbEmployee;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.RichTextBox rtbEmployee;
        private System.Windows.Forms.CheckBox cbEarlyGoing;
        private System.Windows.Forms.CheckBox cbLatePunch;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.GroupBox gbDatePeriodType;
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
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox txtSearchEmpCode;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}