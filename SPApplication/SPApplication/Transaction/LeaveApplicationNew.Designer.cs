namespace SPApplication.Transaction
{
    partial class LeaveApplicationNew
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbEmployee = new System.Windows.Forms.ListBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbEmployee = new System.Windows.Forms.RichTextBox();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbLeaveType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbLeaveRecords = new System.Windows.Forms.RichTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtLeaveReason = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpLeaveDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLeaveRemarks = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHRApproved = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblManagerApproved = new System.Windows.Forms.Label();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblReject = new System.Windows.Forms.Label();
            this.clbDates = new System.Windows.Forms.CheckedListBox();
            this.gbLeaveDetails = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblAttendanceDay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbLeaveDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1197, 30);
            this.lblHeader.TabIndex = 22;
            this.lblHeader.Text = "Leave Application";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 11453;
            this.label1.Text = "Employee Details";
            // 
            // lbEmployee
            // 
            this.lbEmployee.FormattingEnabled = true;
            this.lbEmployee.ItemHeight = 15;
            this.lbEmployee.Location = new System.Drawing.Point(111, 80);
            this.lbEmployee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(379, 184);
            this.lbEmployee.TabIndex = 11450;
            this.lbEmployee.Click += new System.EventHandler(this.lbEmployee_Click);
            this.lbEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbEmployee_KeyDown);
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(111, 56);
            this.txtEmployeeName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(379, 23);
            this.txtEmployeeName.TabIndex = 11449;
            this.txtEmployeeName.TextChanged += new System.EventHandler(this.txtEmployeeName_TextChanged);
            this.txtEmployeeName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 11451;
            this.label2.Text = "Search Employee";
            // 
            // rtbEmployee
            // 
            this.rtbEmployee.Location = new System.Drawing.Point(111, 81);
            this.rtbEmployee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtbEmployee.Name = "rtbEmployee";
            this.rtbEmployee.ReadOnly = true;
            this.rtbEmployee.Size = new System.Drawing.Size(379, 181);
            this.rtbEmployee.TabIndex = 11452;
            this.rtbEmployee.Text = "";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(8, 36);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(32, 15);
            this.lblFromDate.TabIndex = 11455;
            this.lblFromDate.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(111, 32);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 23);
            this.dtpDate.TabIndex = 11454;
            // 
            // cmbLeaveType
            // 
            this.cmbLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeaveType.FormattingEnabled = true;
            this.cmbLeaveType.Location = new System.Drawing.Point(77, 39);
            this.cmbLeaveType.Name = "cmbLeaveType";
            this.cmbLeaveType.Size = new System.Drawing.Size(365, 23);
            this.cmbLeaveType.TabIndex = 11457;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 11456;
            this.label5.Text = "Leave Type";
            // 
            // rtbLeaveRecords
            // 
            this.rtbLeaveRecords.BackColor = System.Drawing.Color.FloralWhite;
            this.rtbLeaveRecords.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLeaveRecords.Location = new System.Drawing.Point(969, 36);
            this.rtbLeaveRecords.Name = "rtbLeaveRecords";
            this.rtbLeaveRecords.Size = new System.Drawing.Size(217, 230);
            this.rtbLeaveRecords.TabIndex = 11458;
            this.rtbLeaveRecords.Text = "";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(682, 277);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11462;
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
            this.btnDelete.Location = new System.Drawing.Point(602, 277);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11461;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(522, 277);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11460;
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
            this.btnSave.Location = new System.Drawing.Point(442, 277);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11459;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtLeaveReason
            // 
            this.txtLeaveReason.Location = new System.Drawing.Point(77, 63);
            this.txtLeaveReason.Multiline = true;
            this.txtLeaveReason.Name = "txtLeaveReason";
            this.txtLeaveReason.Size = new System.Drawing.Size(365, 80);
            this.txtLeaveReason.TabIndex = 11465;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 30);
            this.label6.TabIndex = 11466;
            this.label6.Text = "Reason of \r\nLeave";
            // 
            // dtpLeaveDate
            // 
            this.dtpLeaveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLeaveDate.Location = new System.Drawing.Point(77, 15);
            this.dtpLeaveDate.Name = "dtpLeaveDate";
            this.dtpLeaveDate.Size = new System.Drawing.Size(100, 23);
            this.dtpLeaveDate.TabIndex = 11463;
            this.dtpLeaveDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 11464;
            this.label3.Text = "Leave Date";
            // 
            // txtLeaveRemarks
            // 
            this.txtLeaveRemarks.Location = new System.Drawing.Point(77, 145);
            this.txtLeaveRemarks.Multiline = true;
            this.txtLeaveRemarks.Name = "txtLeaveRemarks";
            this.txtLeaveRemarks.Size = new System.Drawing.Size(365, 80);
            this.txtLeaveRemarks.TabIndex = 11467;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 30);
            this.label13.TabIndex = 11468;
            this.label13.Text = "Leave \r\nRemarks";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(988, 285);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(198, 23);
            this.txtSearch.TabIndex = 11471;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(939, 289);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 11472;
            this.lbSearch.Text = "Search ";
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
            this.dataGridView1.Location = new System.Drawing.Point(5, 312);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1181, 356);
            this.dataGridView1.TabIndex = 11469;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(8, 295);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11470;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(86, 673);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.TabIndex = 11478;
            this.label4.Text = "Total Count";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHRApproved
            // 
            this.lblHRApproved.BackColor = System.Drawing.Color.Cyan;
            this.lblHRApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHRApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHRApproved.Location = new System.Drawing.Point(378, 673);
            this.lblHRApproved.Name = "lblHRApproved";
            this.lblHRApproved.Size = new System.Drawing.Size(140, 20);
            this.lblHRApproved.TabIndex = 11477;
            this.lblHRApproved.Text = "HR Approved";
            this.lblHRApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRemark
            // 
            this.lblRemark.BackColor = System.Drawing.Color.Khaki;
            this.lblRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemark.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(670, 673);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(140, 20);
            this.lblRemark.TabIndex = 11476;
            this.lblRemark.Text = "Remarks";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblManagerApproved
            // 
            this.lblManagerApproved.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblManagerApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManagerApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagerApproved.Location = new System.Drawing.Point(524, 673);
            this.lblManagerApproved.Name = "lblManagerApproved";
            this.lblManagerApproved.Size = new System.Drawing.Size(140, 20);
            this.lblManagerApproved.TabIndex = 11475;
            this.lblManagerApproved.Text = "Manager Approved";
            this.lblManagerApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompleted
            // 
            this.lblCompleted.BackColor = System.Drawing.Color.Lime;
            this.lblCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompleted.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleted.Location = new System.Drawing.Point(816, 673);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(140, 20);
            this.lblCompleted.TabIndex = 11474;
            this.lblCompleted.Text = "Completed";
            this.lblCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPending
            // 
            this.lblPending.BackColor = System.Drawing.Color.Yellow;
            this.lblPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPending.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.Location = new System.Drawing.Point(232, 673);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(140, 20);
            this.lblPending.TabIndex = 11473;
            this.lblPending.Text = "Pending";
            this.lblPending.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReject
            // 
            this.lblReject.BackColor = System.Drawing.Color.DarkOrchid;
            this.lblReject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReject.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReject.Location = new System.Drawing.Point(962, 673);
            this.lblReject.Name = "lblReject";
            this.lblReject.Size = new System.Drawing.Size(140, 20);
            this.lblReject.TabIndex = 11479;
            this.lblReject.Text = "Reject";
            this.lblReject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // clbDates
            // 
            this.clbDates.FormattingEnabled = true;
            this.clbDates.Location = new System.Drawing.Point(12, 130);
            this.clbDates.Name = "clbDates";
            this.clbDates.Size = new System.Drawing.Size(41, 22);
            this.clbDates.TabIndex = 11480;
            this.clbDates.Visible = false;
            // 
            // gbLeaveDetails
            // 
            this.gbLeaveDetails.Controls.Add(this.lblAttendanceDay);
            this.gbLeaveDetails.Controls.Add(this.txtLeaveRemarks);
            this.gbLeaveDetails.Controls.Add(this.label5);
            this.gbLeaveDetails.Controls.Add(this.cmbLeaveType);
            this.gbLeaveDetails.Controls.Add(this.label3);
            this.gbLeaveDetails.Controls.Add(this.dtpLeaveDate);
            this.gbLeaveDetails.Controls.Add(this.label6);
            this.gbLeaveDetails.Controls.Add(this.txtLeaveReason);
            this.gbLeaveDetails.Controls.Add(this.label13);
            this.gbLeaveDetails.Location = new System.Drawing.Point(497, 33);
            this.gbLeaveDetails.Name = "gbLeaveDetails";
            this.gbLeaveDetails.Size = new System.Drawing.Size(466, 233);
            this.gbLeaveDetails.TabIndex = 11481;
            this.gbLeaveDetails.TabStop = false;
            this.gbLeaveDetails.Text = "Leave Details";
            this.gbLeaveDetails.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(68, 269);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 15);
            this.label7.TabIndex = 11482;
            this.label7.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Enabled = false;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(111, 266);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(185, 23);
            this.cmbStatus.TabIndex = 11469;
            // 
            // lblAttendanceDay
            // 
            this.lblAttendanceDay.AutoSize = true;
            this.lblAttendanceDay.Location = new System.Drawing.Point(196, 18);
            this.lblAttendanceDay.Name = "lblAttendanceDay";
            this.lblAttendanceDay.Size = new System.Drawing.Size(34, 15);
            this.lblAttendanceDay.TabIndex = 11483;
            this.lblAttendanceDay.Text = "Day :";
            // 
            // LeaveApplicationNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 698);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gbLeaveDetails);
            this.Controls.Add(this.clbDates);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblReject);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblHRApproved);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblManagerApproved);
            this.Controls.Add(this.lblCompleted);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rtbLeaveRecords);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbEmployee);
            this.Controls.Add(this.txtEmployeeName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtbEmployee);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "LeaveApplicationNew";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LeaveApplicationNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbLeaveDetails.ResumeLayout(false);
            this.gbLeaveDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbEmployee;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbEmployee;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbLeaveType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbLeaveRecords;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLeaveReason;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpLeaveDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLeaveRemarks;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHRApproved;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblManagerApproved;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblReject;
        private System.Windows.Forms.CheckedListBox clbDates;
        private System.Windows.Forms.GroupBox gbLeaveDetails;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAttendanceDay;
    }
}