namespace SPApplication.Transaction
{
    partial class Attendance
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpAttendanceDate = new System.Windows.Forms.DateTimePicker();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lbUnitNumber = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblAttendanceDay = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblHRApproved = new System.Windows.Forms.Label();
            this.lblReject = new System.Windows.Forms.Label();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.lblInchargeApproved = new System.Windows.Forms.Label();
            this.lblManagerApproved = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbApprovalStatus = new System.Windows.Forms.ComboBox();
            this.cbSelectAllStatus = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cbAttendanceDate = new System.Windows.Forms.CheckBox();
            this.lblTotalCount = new System.Windows.Forms.Label();
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
            this.lblHeader.Size = new System.Drawing.Size(1255, 30);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "TT DB";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1169, 49);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11325;
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
            this.btnDelete.Location = new System.Drawing.Point(1204, 33);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 15);
            this.btnDelete.TabIndex = 11324;
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
            this.btnClear.Location = new System.Drawing.Point(1091, 49);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11323;
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
            this.btnSave.Location = new System.Drawing.Point(1013, 49);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11322;
            this.btnSave.Text = "Show";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpAttendanceDate
            // 
            this.dtpAttendanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAttendanceDate.Location = new System.Drawing.Point(486, 34);
            this.dtpAttendanceDate.Name = "dtpAttendanceDate";
            this.dtpAttendanceDate.Size = new System.Drawing.Size(100, 23);
            this.dtpAttendanceDate.TabIndex = 11320;
            this.dtpAttendanceDate.Visible = false;
            this.dtpAttendanceDate.ValueChanged += new System.EventHandler(this.dtpAttendanceDate_ValueChanged);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(92, 58);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(240, 23);
            this.cmbDepartment.TabIndex = 11319;
            this.cmbDepartment.SelectionChangeCommitted += new System.EventHandler(this.cmbDepartment_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 11318;
            this.label1.Text = "Department";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(92, 34);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(240, 23);
            this.cmbLocation.TabIndex = 11317;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // lbUnitNumber
            // 
            this.lbUnitNumber.AutoSize = true;
            this.lbUnitNumber.Location = new System.Drawing.Point(3, 38);
            this.lbUnitNumber.Name = "lbUnitNumber";
            this.lbUnitNumber.Size = new System.Drawing.Size(87, 15);
            this.lbUnitNumber.TabIndex = 11316;
            this.lbUnitNumber.Text = "Location Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 122);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1239, 545);
            this.dataGridView1.TabIndex = 11349;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // lblAttendanceDay
            // 
            this.lblAttendanceDay.AutoSize = true;
            this.lblAttendanceDay.Location = new System.Drawing.Point(588, 38);
            this.lblAttendanceDay.Name = "lblAttendanceDay";
            this.lblAttendanceDay.Size = new System.Drawing.Size(92, 15);
            this.lblAttendanceDay.TabIndex = 11355;
            this.lblAttendanceDay.Text = "Attendance Day";
            this.lblAttendanceDay.Visible = false;
            // 
            // lblRemark
            // 
            this.lblRemark.BackColor = System.Drawing.Color.Violet;
            this.lblRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemark.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(850, 669);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(150, 20);
            this.lblRemark.TabIndex = 11367;
            this.lblRemark.Text = "Remark";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHRApproved
            // 
            this.lblHRApproved.BackColor = System.Drawing.Color.Aqua;
            this.lblHRApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHRApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHRApproved.Location = new System.Drawing.Point(226, 669);
            this.lblHRApproved.Name = "lblHRApproved";
            this.lblHRApproved.Size = new System.Drawing.Size(150, 20);
            this.lblHRApproved.TabIndex = 11366;
            this.lblHRApproved.Text = "HR Approved";
            this.lblHRApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReject
            // 
            this.lblReject.BackColor = System.Drawing.Color.Tomato;
            this.lblReject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblReject.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReject.Location = new System.Drawing.Point(1006, 669);
            this.lblReject.Name = "lblReject";
            this.lblReject.Size = new System.Drawing.Size(150, 20);
            this.lblReject.TabIndex = 11365;
            this.lblReject.Text = "Cancel";
            this.lblReject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCompleted
            // 
            this.lblCompleted.BackColor = System.Drawing.Color.Lime;
            this.lblCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompleted.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleted.Location = new System.Drawing.Point(694, 669);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(150, 20);
            this.lblCompleted.TabIndex = 11364;
            this.lblCompleted.Text = "Completed";
            this.lblCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPending
            // 
            this.lblPending.BackColor = System.Drawing.Color.Yellow;
            this.lblPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPending.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.Location = new System.Drawing.Point(70, 669);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(150, 20);
            this.lblPending.TabIndex = 11363;
            this.lblPending.Text = "Pending";
            this.lblPending.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInchargeApproved
            // 
            this.lblInchargeApproved.BackColor = System.Drawing.Color.Tomato;
            this.lblInchargeApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInchargeApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInchargeApproved.Location = new System.Drawing.Point(382, 669);
            this.lblInchargeApproved.Name = "lblInchargeApproved";
            this.lblInchargeApproved.Size = new System.Drawing.Size(150, 20);
            this.lblInchargeApproved.TabIndex = 11368;
            this.lblInchargeApproved.Text = "Incharge Approved";
            this.lblInchargeApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblManagerApproved
            // 
            this.lblManagerApproved.BackColor = System.Drawing.Color.Lime;
            this.lblManagerApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManagerApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagerApproved.Location = new System.Drawing.Point(538, 669);
            this.lblManagerApproved.Name = "lblManagerApproved";
            this.lblManagerApproved.Size = new System.Drawing.Size(150, 20);
            this.lblManagerApproved.TabIndex = 11369;
            this.lblManagerApproved.Text = "Manager Approved";
            this.lblManagerApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(891, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 11370;
            this.label3.Text = "Search by Status";
            // 
            // cmbApprovalStatus
            // 
            this.cmbApprovalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApprovalStatus.FormattingEnabled = true;
            this.cmbApprovalStatus.Location = new System.Drawing.Point(753, 56);
            this.cmbApprovalStatus.Name = "cmbApprovalStatus";
            this.cmbApprovalStatus.Size = new System.Drawing.Size(237, 23);
            this.cmbApprovalStatus.TabIndex = 11371;
            this.cmbApprovalStatus.SelectionChangeCommitted += new System.EventHandler(this.cmbAttendanceStatus_SelectionChangeCommitted);
            // 
            // cbSelectAllStatus
            // 
            this.cbSelectAllStatus.AutoSize = true;
            this.cbSelectAllStatus.Location = new System.Drawing.Point(756, 35);
            this.cbSelectAllStatus.Name = "cbSelectAllStatus";
            this.cbSelectAllStatus.Size = new System.Drawing.Size(60, 19);
            this.cbSelectAllStatus.TabIndex = 11372;
            this.cbSelectAllStatus.Text = "Status";
            this.cbSelectAllStatus.UseVisualStyleBackColor = true;
            this.cbSelectAllStatus.CheckedChanged += new System.EventHandler(this.cbSelectAllStatus_CheckedChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(191, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 11402;
            this.label4.Text = "OT Pending";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.cmbMonth.Location = new System.Drawing.Point(414, 59);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(99, 23);
            this.cmbMonth.TabIndex = 11404;
            this.cmbMonth.Visible = false;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(369, 62);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(43, 15);
            this.lblMonth.TabIndex = 11403;
            this.lblMonth.Text = "Month";
            this.lblMonth.Visible = false;
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
            this.cmbYear.Location = new System.Drawing.Point(547, 59);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(80, 23);
            this.cmbYear.TabIndex = 11406;
            this.cmbYear.Visible = false;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(515, 63);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(30, 15);
            this.lblYear.TabIndex = 11405;
            this.lblYear.Text = "Year";
            this.lblYear.Visible = false;
            // 
            // cbAttendanceDate
            // 
            this.cbAttendanceDate.AutoSize = true;
            this.cbAttendanceDate.Location = new System.Drawing.Point(369, 36);
            this.cbAttendanceDate.Name = "cbAttendanceDate";
            this.cbAttendanceDate.Size = new System.Drawing.Size(115, 19);
            this.cbAttendanceDate.TabIndex = 11407;
            this.cbAttendanceDate.Text = "Attendance Date";
            this.cbAttendanceDate.UseVisualStyleBackColor = true;
            this.cbAttendanceDate.CheckedChanged += new System.EventHandler(this.cbAttendanceDate_CheckedChanged);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(3, 104);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11350;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1253, 698);
            this.ControlBox = false;
            this.Controls.Add(this.cbAttendanceDate);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbSelectAllStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbApprovalStatus);
            this.Controls.Add(this.lblManagerApproved);
            this.Controls.Add(this.lblInchargeApproved);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblHRApproved);
            this.Controls.Add(this.lblReject);
            this.Controls.Add(this.lblCompleted);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.lblAttendanceDay);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpAttendanceDate);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lbUnitNumber);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Attendance";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AttendanceApprovalMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpAttendanceDate;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lbUnitNumber;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblAttendanceDay;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblHRApproved;
        private System.Windows.Forms.Label lblReject;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Label lblInchargeApproved;
        private System.Windows.Forms.Label lblManagerApproved;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbApprovalStatus;
        private System.Windows.Forms.CheckBox cbSelectAllStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.CheckBox cbAttendanceDate;
        private System.Windows.Forms.Label lblTotalCount;
    }
}