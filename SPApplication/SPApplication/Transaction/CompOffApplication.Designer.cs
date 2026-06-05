namespace SPApplication.Transaction
{
    partial class CompOffApplication
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
            this.rtbLeaveRecords = new System.Windows.Forms.RichTextBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lbUnitNumber = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbEmployeeName = new System.Windows.Forms.ComboBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDepartmentName = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvHolidayList = new System.Windows.Forms.DataGridView();
            this.clmSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmTempHolidayId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHolidayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHolidayDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFestival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHolidayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbLeaveType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompOffReason = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbWorkingRemarks = new System.Windows.Forms.GroupBox();
            this.txtWorkingRemarks = new System.Windows.Forms.TextBox();
            this.txtWeeklyOff = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalHoliday = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpCompOffDate = new System.Windows.Forms.DateTimePicker();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbCompOffDetails = new System.Windows.Forms.GroupBox();
            this.dtpCompOffDueDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFestival = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.gbCompOffUsedDetails = new System.Windows.Forms.GroupBox();
            this.cbUsedCompOffDate = new System.Windows.Forms.CheckBox();
            this.dtpUsedCompOffDate = new System.Windows.Forms.DateTimePicker();
            this.txtUsedCompOffDay = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblManagerApproved = new System.Windows.Forms.Label();
            this.lblHRApproved = new System.Windows.Forms.Label();
            this.lblReject = new System.Windows.Forms.Label();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.cbCompOffUsedList = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.lblDue = new System.Windows.Forms.Label();
            this.lblExpired = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolidayList)).BeginInit();
            this.gbWorkingRemarks.SuspendLayout();
            this.gbCompOffDetails.SuspendLayout();
            this.gbCompOffUsedDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbLeaveRecords
            // 
            this.rtbLeaveRecords.BackColor = System.Drawing.Color.FloralWhite;
            this.rtbLeaveRecords.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLeaveRecords.Location = new System.Drawing.Point(975, 72);
            this.rtbLeaveRecords.Name = "rtbLeaveRecords";
            this.rtbLeaveRecords.Size = new System.Drawing.Size(211, 303);
            this.rtbLeaveRecords.TabIndex = 11388;
            this.rtbLeaveRecords.Text = "";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(105, 57);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(405, 23);
            this.cmbDepartment.TabIndex = 11387;
            this.cmbDepartment.SelectionChangeCommitted += new System.EventHandler(this.cmbDepartment_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 11386;
            this.label8.Text = "Department";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(105, 33);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(405, 23);
            this.cmbLocation.TabIndex = 11385;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // lbUnitNumber
            // 
            this.lbUnitNumber.AutoSize = true;
            this.lbUnitNumber.Location = new System.Drawing.Point(16, 37);
            this.lbUnitNumber.Name = "lbUnitNumber";
            this.lbUnitNumber.Size = new System.Drawing.Size(87, 15);
            this.lbUnitNumber.TabIndex = 11384;
            this.lbUnitNumber.Text = "Location Name";
            // 
            // txtDesignation
            // 
            this.txtDesignation.Location = new System.Drawing.Point(824, 57);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.ReadOnly = true;
            this.txtDesignation.Size = new System.Drawing.Size(139, 23);
            this.txtDesignation.TabIndex = 11382;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(735, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 11383;
            this.label7.Text = "Designation";
            // 
            // cmbEmployeeName
            // 
            this.cmbEmployeeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployeeName.FormattingEnabled = true;
            this.cmbEmployeeName.Location = new System.Drawing.Point(613, 33);
            this.cmbEmployeeName.Name = "cmbEmployeeName";
            this.cmbEmployeeName.Size = new System.Drawing.Size(350, 23);
            this.cmbEmployeeName.TabIndex = 11381;
            this.cmbEmployeeName.SelectionChangeCommitted += new System.EventHandler(this.cmbEmployeeName_SelectionChangeCommitted);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(1050, 37);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(32, 15);
            this.lblFromDate.TabIndex = 11380;
            this.lblFromDate.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(1084, 33);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 23);
            this.dtpDate.TabIndex = 11379;
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(613, 57);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.ReadOnly = true;
            this.txtEmployeeCode.Size = new System.Drawing.Size(101, 23);
            this.txtEmployeeCode.TabIndex = 11377;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(518, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 11378;
            this.label1.Text = "Employee Code";
            // 
            // lbDepartmentName
            // 
            this.lbDepartmentName.AutoSize = true;
            this.lbDepartmentName.Location = new System.Drawing.Point(518, 38);
            this.lbDepartmentName.Name = "lbDepartmentName";
            this.lbDepartmentName.Size = new System.Drawing.Size(93, 15);
            this.lbDepartmentName.TabIndex = 11376;
            this.lbDepartmentName.Text = "Employee Name";
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1198, 30);
            this.lblHeader.TabIndex = 11375;
            this.lblHeader.Text = "Database";
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 420);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1172, 247);
            this.dataGridView1.TabIndex = 11393;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(15, 403);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11394;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(639, 384);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11392;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(824, 384);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11391;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(561, 384);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11390;
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
            this.btnSave.Location = new System.Drawing.Point(483, 384);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11389;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvHolidayList
            // 
            this.dgvHolidayList.AllowUserToAddRows = false;
            this.dgvHolidayList.AllowUserToDeleteRows = false;
            this.dgvHolidayList.AllowUserToOrderColumns = true;
            this.dgvHolidayList.AllowUserToResizeColumns = false;
            this.dgvHolidayList.AllowUserToResizeRows = false;
            this.dgvHolidayList.BackgroundColor = System.Drawing.Color.White;
            this.dgvHolidayList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHolidayList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSelect,
            this.clmTempHolidayId,
            this.clmHolidayDate,
            this.clmHolidayDay,
            this.clmFestival,
            this.clmHolidayType});
            this.dgvHolidayList.Location = new System.Drawing.Point(11, 113);
            this.dgvHolidayList.Name = "dgvHolidayList";
            this.dgvHolidayList.RowHeadersVisible = false;
            this.dgvHolidayList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHolidayList.Size = new System.Drawing.Size(513, 193);
            this.dgvHolidayList.TabIndex = 11395;
            this.dgvHolidayList.TabStop = false;
            this.dgvHolidayList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHolidayList_CellValueChanged);
            this.dgvHolidayList.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvHolidayList_CurrentCellDirtyStateChanged);
            // 
            // clmSelect
            // 
            this.clmSelect.HeaderText = "";
            this.clmSelect.Name = "clmSelect";
            this.clmSelect.Width = 30;
            // 
            // clmTempHolidayId
            // 
            this.clmTempHolidayId.HeaderText = "TempHolidayId";
            this.clmTempHolidayId.Name = "clmTempHolidayId";
            this.clmTempHolidayId.ReadOnly = true;
            this.clmTempHolidayId.Visible = false;
            // 
            // clmHolidayDate
            // 
            this.clmHolidayDate.HeaderText = "Holiday Date";
            this.clmHolidayDate.Name = "clmHolidayDate";
            this.clmHolidayDate.ReadOnly = true;
            // 
            // clmHolidayDay
            // 
            this.clmHolidayDay.HeaderText = "Holiday Day";
            this.clmHolidayDay.Name = "clmHolidayDay";
            this.clmHolidayDay.ReadOnly = true;
            // 
            // clmFestival
            // 
            this.clmFestival.HeaderText = "Festival";
            this.clmFestival.Name = "clmFestival";
            this.clmFestival.ReadOnly = true;
            this.clmFestival.Width = 150;
            // 
            // clmHolidayType
            // 
            this.clmHolidayType.HeaderText = "Holiday Type";
            this.clmHolidayType.Name = "clmHolidayType";
            this.clmHolidayType.ReadOnly = true;
            // 
            // cmbLeaveType
            // 
            this.cmbLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeaveType.FormattingEnabled = true;
            this.cmbLeaveType.Location = new System.Drawing.Point(824, 81);
            this.cmbLeaveType.Name = "cmbLeaveType";
            this.cmbLeaveType.Size = new System.Drawing.Size(139, 23);
            this.cmbLeaveType.TabIndex = 11397;
            this.cmbLeaveType.SelectionChangeCommitted += new System.EventHandler(this.cmbLeaveType_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(743, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 11396;
            this.label5.Text = "Leave Type";
            // 
            // txtCompOffReason
            // 
            this.txtCompOffReason.Location = new System.Drawing.Point(541, 127);
            this.txtCompOffReason.Multiline = true;
            this.txtCompOffReason.Name = "txtCompOffReason";
            this.txtCompOffReason.Size = new System.Drawing.Size(422, 86);
            this.txtCompOffReason.TabIndex = 11398;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(544, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 15);
            this.label6.TabIndex = 11399;
            this.label6.Text = "Comp off Reson";
            // 
            // gbWorkingRemarks
            // 
            this.gbWorkingRemarks.Controls.Add(this.txtWorkingRemarks);
            this.gbWorkingRemarks.Enabled = false;
            this.gbWorkingRemarks.Location = new System.Drawing.Point(538, 219);
            this.gbWorkingRemarks.Name = "gbWorkingRemarks";
            this.gbWorkingRemarks.Size = new System.Drawing.Size(431, 102);
            this.gbWorkingRemarks.TabIndex = 11400;
            this.gbWorkingRemarks.TabStop = false;
            this.gbWorkingRemarks.Text = "Working Remarks";
            // 
            // txtWorkingRemarks
            // 
            this.txtWorkingRemarks.Location = new System.Drawing.Point(6, 17);
            this.txtWorkingRemarks.Multiline = true;
            this.txtWorkingRemarks.Name = "txtWorkingRemarks";
            this.txtWorkingRemarks.Size = new System.Drawing.Size(419, 80);
            this.txtWorkingRemarks.TabIndex = 11335;
            // 
            // txtWeeklyOff
            // 
            this.txtWeeklyOff.Location = new System.Drawing.Point(613, 81);
            this.txtWeeklyOff.Name = "txtWeeklyOff";
            this.txtWeeklyOff.ReadOnly = true;
            this.txtWeeklyOff.Size = new System.Drawing.Size(101, 23);
            this.txtWeeklyOff.TabIndex = 11401;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 11402;
            this.label2.Text = "Weekly off";
            // 
            // lblTotalHoliday
            // 
            this.lblTotalHoliday.AutoSize = true;
            this.lblTotalHoliday.Location = new System.Drawing.Point(14, 96);
            this.lblTotalHoliday.Name = "lblTotalHoliday";
            this.lblTotalHoliday.Size = new System.Drawing.Size(80, 15);
            this.lblTotalHoliday.TabIndex = 11403;
            this.lblTotalHoliday.Text = "Total Holiday";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 11405;
            this.label3.Text = "Comp off Date";
            // 
            // dtpCompOffDate
            // 
            this.dtpCompOffDate.Enabled = false;
            this.dtpCompOffDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCompOffDate.Location = new System.Drawing.Point(99, 16);
            this.dtpCompOffDate.Name = "dtpCompOffDate";
            this.dtpCompOffDate.Size = new System.Drawing.Size(100, 23);
            this.dtpCompOffDate.TabIndex = 11404;
            this.dtpCompOffDate.ValueChanged += new System.EventHandler(this.dtpCompOffDate_ValueChanged);
            // 
            // txtDay
            // 
            this.txtDay.BackColor = System.Drawing.Color.White;
            this.txtDay.Location = new System.Drawing.Point(241, 16);
            this.txtDay.Name = "txtDay";
            this.txtDay.ReadOnly = true;
            this.txtDay.Size = new System.Drawing.Size(101, 23);
            this.txtDay.TabIndex = 11406;
            this.txtDay.TextChanged += new System.EventHandler(this.txtDay_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 15);
            this.label4.TabIndex = 11407;
            this.label4.Text = "Day";
            // 
            // gbCompOffDetails
            // 
            this.gbCompOffDetails.Controls.Add(this.dtpCompOffDueDate);
            this.gbCompOffDetails.Controls.Add(this.label12);
            this.gbCompOffDetails.Controls.Add(this.txtType);
            this.gbCompOffDetails.Controls.Add(this.label10);
            this.gbCompOffDetails.Controls.Add(this.txtFestival);
            this.gbCompOffDetails.Controls.Add(this.label9);
            this.gbCompOffDetails.Controls.Add(this.dtpCompOffDate);
            this.gbCompOffDetails.Controls.Add(this.txtDay);
            this.gbCompOffDetails.Controls.Add(this.label4);
            this.gbCompOffDetails.Controls.Add(this.label3);
            this.gbCompOffDetails.Location = new System.Drawing.Point(11, 307);
            this.gbCompOffDetails.Name = "gbCompOffDetails";
            this.gbCompOffDetails.Size = new System.Drawing.Size(513, 69);
            this.gbCompOffDetails.TabIndex = 11408;
            this.gbCompOffDetails.TabStop = false;
            this.gbCompOffDetails.Text = "Comp off Details";
            // 
            // dtpCompOffDueDate
            // 
            this.dtpCompOffDueDate.Enabled = false;
            this.dtpCompOffDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCompOffDueDate.Location = new System.Drawing.Point(406, 40);
            this.dtpCompOffDueDate.Name = "dtpCompOffDueDate";
            this.dtpCompOffDueDate.Size = new System.Drawing.Size(101, 23);
            this.dtpCompOffDueDate.TabIndex = 11412;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(348, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 15);
            this.label12.TabIndex = 11413;
            this.label12.Text = "Due Date";
            // 
            // txtType
            // 
            this.txtType.BackColor = System.Drawing.Color.White;
            this.txtType.Location = new System.Drawing.Point(406, 16);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(101, 23);
            this.txtType.TabIndex = 11410;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(348, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 15);
            this.label10.TabIndex = 11411;
            this.label10.Text = "Type";
            // 
            // txtFestival
            // 
            this.txtFestival.BackColor = System.Drawing.Color.White;
            this.txtFestival.Location = new System.Drawing.Point(99, 40);
            this.txtFestival.Name = "txtFestival";
            this.txtFestival.ReadOnly = true;
            this.txtFestival.Size = new System.Drawing.Size(243, 23);
            this.txtFestival.TabIndex = 11408;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 15);
            this.label9.TabIndex = 11409;
            this.label9.Text = "Festival";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(320, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(190, 15);
            this.label11.TabIndex = 11409;
            this.label11.Text = "Select Only One from Holiday List";
            // 
            // gbCompOffUsedDetails
            // 
            this.gbCompOffUsedDetails.Controls.Add(this.cbUsedCompOffDate);
            this.gbCompOffUsedDetails.Controls.Add(this.dtpUsedCompOffDate);
            this.gbCompOffUsedDetails.Controls.Add(this.txtUsedCompOffDay);
            this.gbCompOffUsedDetails.Controls.Add(this.label15);
            this.gbCompOffUsedDetails.Location = new System.Drawing.Point(538, 327);
            this.gbCompOffUsedDetails.Name = "gbCompOffUsedDetails";
            this.gbCompOffUsedDetails.Size = new System.Drawing.Size(431, 49);
            this.gbCompOffUsedDetails.TabIndex = 11412;
            this.gbCompOffUsedDetails.TabStop = false;
            this.gbCompOffUsedDetails.Text = "Comp off Details";
            this.gbCompOffUsedDetails.Visible = false;
            // 
            // cbUsedCompOffDate
            // 
            this.cbUsedCompOffDate.AutoSize = true;
            this.cbUsedCompOffDate.Location = new System.Drawing.Point(9, 18);
            this.cbUsedCompOffDate.Name = "cbUsedCompOffDate";
            this.cbUsedCompOffDate.Size = new System.Drawing.Size(133, 19);
            this.cbUsedCompOffDate.TabIndex = 11408;
            this.cbUsedCompOffDate.Text = "Used Comp off Date";
            this.cbUsedCompOffDate.UseVisualStyleBackColor = true;
            this.cbUsedCompOffDate.CheckedChanged += new System.EventHandler(this.cbUsedCompOffDate_CheckedChanged);
            // 
            // dtpUsedCompOffDate
            // 
            this.dtpUsedCompOffDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUsedCompOffDate.Location = new System.Drawing.Point(169, 15);
            this.dtpUsedCompOffDate.Name = "dtpUsedCompOffDate";
            this.dtpUsedCompOffDate.Size = new System.Drawing.Size(100, 23);
            this.dtpUsedCompOffDate.TabIndex = 11404;
            this.dtpUsedCompOffDate.ValueChanged += new System.EventHandler(this.dtpUsedCompOffDate_ValueChanged);
            // 
            // txtUsedCompOffDay
            // 
            this.txtUsedCompOffDay.BackColor = System.Drawing.Color.White;
            this.txtUsedCompOffDay.Location = new System.Drawing.Point(311, 15);
            this.txtUsedCompOffDay.Name = "txtUsedCompOffDay";
            this.txtUsedCompOffDay.ReadOnly = true;
            this.txtUsedCompOffDay.Size = new System.Drawing.Size(101, 23);
            this.txtUsedCompOffDay.TabIndex = 11406;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(281, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(28, 15);
            this.label15.TabIndex = 11407;
            this.label15.Text = "Day";
            // 
            // lblRemark
            // 
            this.lblRemark.BackColor = System.Drawing.Color.Khaki;
            this.lblRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemark.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(615, 672);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(100, 20);
            this.lblRemark.TabIndex = 11414;
            this.lblRemark.Text = "Remarks";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblManagerApproved
            // 
            this.lblManagerApproved.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblManagerApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManagerApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagerApproved.Location = new System.Drawing.Point(222, 672);
            this.lblManagerApproved.Name = "lblManagerApproved";
            this.lblManagerApproved.Size = new System.Drawing.Size(100, 20);
            this.lblManagerApproved.TabIndex = 11413;
            this.lblManagerApproved.Text = "Manager Approved";
            this.lblManagerApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHRApproved
            // 
            this.lblHRApproved.BackColor = System.Drawing.Color.Aqua;
            this.lblHRApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHRApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHRApproved.Location = new System.Drawing.Point(353, 672);
            this.lblHRApproved.Name = "lblHRApproved";
            this.lblHRApproved.Size = new System.Drawing.Size(100, 20);
            this.lblHRApproved.TabIndex = 11412;
            this.lblHRApproved.Text = "HR Approved";
            this.lblHRApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReject
            // 
            this.lblReject.BackColor = System.Drawing.Color.DarkOrchid;
            this.lblReject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReject.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReject.Location = new System.Drawing.Point(484, 672);
            this.lblReject.Name = "lblReject";
            this.lblReject.Size = new System.Drawing.Size(100, 20);
            this.lblReject.TabIndex = 11411;
            this.lblReject.Text = "Reject";
            this.lblReject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompleted
            // 
            this.lblCompleted.BackColor = System.Drawing.Color.Lime;
            this.lblCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompleted.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleted.Location = new System.Drawing.Point(746, 672);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(100, 20);
            this.lblCompleted.TabIndex = 11410;
            this.lblCompleted.Text = "Completed";
            this.lblCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPending
            // 
            this.lblPending.BackColor = System.Drawing.Color.Yellow;
            this.lblPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPending.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.Location = new System.Drawing.Point(91, 672);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(100, 20);
            this.lblPending.TabIndex = 11409;
            this.lblPending.Text = "Pending";
            this.lblPending.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbCompOffUsedList
            // 
            this.cbCompOffUsedList.AutoSize = true;
            this.cbCompOffUsedList.Location = new System.Drawing.Point(134, 388);
            this.cbCompOffUsedList.Name = "cbCompOffUsedList";
            this.cbCompOffUsedList.Size = new System.Drawing.Size(129, 19);
            this.cbCompOffUsedList.TabIndex = 11415;
            this.cbCompOffUsedList.Text = "Comp Off Used List";
            this.cbCompOffUsedList.UseVisualStyleBackColor = true;
            this.cbCompOffUsedList.CheckedChanged += new System.EventHandler(this.cbCompOffUsed_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(964, 388);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 23);
            this.txtSearch.TabIndex = 11416;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(915, 392);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 11417;
            this.lbSearch.Text = "Search ";
            // 
            // lblDue
            // 
            this.lblDue.BackColor = System.Drawing.Color.HotPink;
            this.lblDue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDue.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDue.Location = new System.Drawing.Point(877, 672);
            this.lblDue.Name = "lblDue";
            this.lblDue.Size = new System.Drawing.Size(100, 20);
            this.lblDue.TabIndex = 11419;
            this.lblDue.Text = "Due";
            this.lblDue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblExpired
            // 
            this.lblExpired.BackColor = System.Drawing.Color.Red;
            this.lblExpired.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExpired.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpired.Location = new System.Drawing.Point(1008, 672);
            this.lblExpired.Name = "lblExpired";
            this.lblExpired.Size = new System.Drawing.Size(100, 20);
            this.lblExpired.TabIndex = 11418;
            this.lblExpired.Text = "Expired";
            this.lblExpired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CompOffApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 698);
            this.ControlBox = false;
            this.Controls.Add(this.lblDue);
            this.Controls.Add(this.lblExpired);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.cbCompOffUsedList);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.gbCompOffUsedDetails);
            this.Controls.Add(this.lblManagerApproved);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblHRApproved);
            this.Controls.Add(this.gbCompOffDetails);
            this.Controls.Add(this.lblReject);
            this.Controls.Add(this.lblCompleted);
            this.Controls.Add(this.lblTotalHoliday);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.txtWeeklyOff);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbWorkingRemarks);
            this.Controls.Add(this.txtCompOffReason);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbLeaveType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvHolidayList);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rtbLeaveRecords);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lbUnitNumber);
            this.Controls.Add(this.txtDesignation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbEmployeeName);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtEmployeeCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbDepartmentName);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CompOffApplication";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CompOffApplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolidayList)).EndInit();
            this.gbWorkingRemarks.ResumeLayout(false);
            this.gbWorkingRemarks.PerformLayout();
            this.gbCompOffDetails.ResumeLayout(false);
            this.gbCompOffDetails.PerformLayout();
            this.gbCompOffUsedDetails.ResumeLayout(false);
            this.gbCompOffUsedDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbLeaveRecords;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lbUnitNumber;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbEmployeeName;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbDepartmentName;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvHolidayList;
        private System.Windows.Forms.ComboBox cmbLeaveType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCompOffReason;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbWorkingRemarks;
        private System.Windows.Forms.TextBox txtWorkingRemarks;
        private System.Windows.Forms.TextBox txtWeeklyOff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalHoliday;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpCompOffDate;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbCompOffDetails;
        private System.Windows.Forms.TextBox txtFestival;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTempHolidayId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHolidayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHolidayDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFestival;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHolidayType;
        private System.Windows.Forms.GroupBox gbCompOffUsedDetails;
        private System.Windows.Forms.CheckBox cbUsedCompOffDate;
        private System.Windows.Forms.DateTimePicker dtpUsedCompOffDate;
        private System.Windows.Forms.TextBox txtUsedCompOffDay;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtpCompOffDueDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblManagerApproved;
        private System.Windows.Forms.Label lblHRApproved;
        private System.Windows.Forms.Label lblReject;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.CheckBox cbCompOffUsedList;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Label lblDue;
        private System.Windows.Forms.Label lblExpired;
    }
}