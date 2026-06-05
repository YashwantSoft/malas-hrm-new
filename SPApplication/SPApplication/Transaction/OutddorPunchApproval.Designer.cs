namespace SPApplication.Transaction
{
    partial class OutddorPunchApproval
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
            this.cbTransferOut = new System.Windows.Forms.CheckBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.lblManagerApproved = new System.Windows.Forms.Label();
            this.lblHRApproved = new System.Windows.Forms.Label();
            this.lblPending = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dgvTransferIN = new System.Windows.Forms.DataGridView();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblTransferCount = new System.Windows.Forms.Label();
            this.lblCompleted = new System.Windows.Forms.Label();
            this.cbDevice = new System.Windows.Forms.CheckBox();
            this.cmbDevice = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchEmployee = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.txtSearchEmpCode = new System.Windows.Forms.TextBox();
            this.dgvTransferOut = new System.Windows.Forms.DataGridView();
            this.dgvAttendanceStatus = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.lbUnitNumber = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.cmbApprovalStatus = new System.Windows.Forms.ComboBox();
            this.lblOverTime = new System.Windows.Forms.Label();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpAttenanceDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.pSave = new System.Windows.Forms.Panel();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.cbTransferIn = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferIN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceStatus)).BeginInit();
            this.pSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1300, 30);
            this.lblHeader.TabIndex = 11358;
            this.lblHeader.Text = "OUT DOOR PUNCH APPROVAL";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbTransferOut
            // 
            this.cbTransferOut.AutoSize = true;
            this.cbTransferOut.BackColor = System.Drawing.Color.Transparent;
            this.cbTransferOut.Location = new System.Drawing.Point(234, 186);
            this.cbTransferOut.Name = "cbTransferOut";
            this.cbTransferOut.Size = new System.Drawing.Size(97, 19);
            this.cbTransferOut.TabIndex = 11492;
            this.cbTransferOut.Text = "Transfer OUT";
            this.cbTransferOut.UseVisualStyleBackColor = false;
            // 
            // lblRemark
            // 
            this.lblRemark.BackColor = System.Drawing.Color.Khaki;
            this.lblRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRemark.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemark.Location = new System.Drawing.Point(729, 633);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(140, 20);
            this.lblRemark.TabIndex = 11491;
            this.lblRemark.Text = "Remarks";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblManagerApproved
            // 
            this.lblManagerApproved.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblManagerApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblManagerApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblManagerApproved.Location = new System.Drawing.Point(575, 633);
            this.lblManagerApproved.Name = "lblManagerApproved";
            this.lblManagerApproved.Size = new System.Drawing.Size(140, 20);
            this.lblManagerApproved.TabIndex = 11490;
            this.lblManagerApproved.Text = "Manager Approved";
            this.lblManagerApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHRApproved
            // 
            this.lblHRApproved.BackColor = System.Drawing.Color.Aqua;
            this.lblHRApproved.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHRApproved.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHRApproved.Location = new System.Drawing.Point(421, 633);
            this.lblHRApproved.Name = "lblHRApproved";
            this.lblHRApproved.Size = new System.Drawing.Size(140, 20);
            this.lblHRApproved.TabIndex = 11489;
            this.lblHRApproved.Text = "HR Approved";
            this.lblHRApproved.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPending
            // 
            this.lblPending.BackColor = System.Drawing.Color.Yellow;
            this.lblPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPending.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPending.Location = new System.Drawing.Point(267, 633);
            this.lblPending.Name = "lblPending";
            this.lblPending.Size = new System.Drawing.Size(140, 20);
            this.lblPending.TabIndex = 11488;
            this.lblPending.Text = "Pending";
            this.lblPending.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1061, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11382;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 207);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1276, 423);
            this.dataGridView1.TabIndex = 11485;
            this.dataGridView1.TabStop = false;
            // 
            // dgvTransferIN
            // 
            this.dgvTransferIN.AllowUserToAddRows = false;
            this.dgvTransferIN.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransferIN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferIN.Location = new System.Drawing.Point(822, 35);
            this.dgvTransferIN.Name = "dgvTransferIN";
            this.dgvTransferIN.RowHeadersVisible = false;
            this.dgvTransferIN.Size = new System.Drawing.Size(243, 146);
            this.dgvTransferIN.TabIndex = 11477;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(293, 8);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(706, 23);
            this.txtRemarks.TabIndex = 11386;
            this.txtRemarks.Visible = false;
            // 
            // lblTransferCount
            // 
            this.lblTransferCount.AutoSize = true;
            this.lblTransferCount.Location = new System.Drawing.Point(540, 186);
            this.lblTransferCount.Name = "lblTransferCount";
            this.lblTransferCount.Size = new System.Drawing.Size(87, 15);
            this.lblTransferCount.TabIndex = 11487;
            this.lblTransferCount.Text = "Transfer Count";
            // 
            // lblCompleted
            // 
            this.lblCompleted.BackColor = System.Drawing.Color.Lime;
            this.lblCompleted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCompleted.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompleted.Location = new System.Drawing.Point(875, 633);
            this.lblCompleted.Name = "lblCompleted";
            this.lblCompleted.Size = new System.Drawing.Size(140, 20);
            this.lblCompleted.TabIndex = 11486;
            this.lblCompleted.Text = "Completed";
            this.lblCompleted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbDevice
            // 
            this.cbDevice.AutoSize = true;
            this.cbDevice.Location = new System.Drawing.Point(234, 38);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(62, 19);
            this.cbDevice.TabIndex = 11484;
            this.cbDevice.Text = "Device";
            this.cbDevice.UseVisualStyleBackColor = true;
            // 
            // cmbDevice
            // 
            this.cmbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevice.FormattingEnabled = true;
            this.cmbDevice.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cmbDevice.Location = new System.Drawing.Point(298, 35);
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.Size = new System.Drawing.Size(67, 23);
            this.cmbDevice.TabIndex = 11483;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 11482;
            this.label2.Text = "Search Employee";
            // 
            // txtSearchEmployee
            // 
            this.txtSearchEmployee.Location = new System.Drawing.Point(110, 107);
            this.txtSearchEmployee.Name = "txtSearchEmployee";
            this.txtSearchEmployee.Size = new System.Drawing.Size(255, 23);
            this.txtSearchEmployee.TabIndex = 11481;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(9, 136);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(63, 15);
            this.label51.TabIndex = 11480;
            this.label51.Text = "Emp. Code";
            // 
            // txtSearchEmpCode
            // 
            this.txtSearchEmpCode.Location = new System.Drawing.Point(110, 131);
            this.txtSearchEmpCode.Name = "txtSearchEmpCode";
            this.txtSearchEmpCode.Size = new System.Drawing.Size(56, 23);
            this.txtSearchEmpCode.TabIndex = 11479;
            // 
            // dgvTransferOut
            // 
            this.dgvTransferOut.AllowUserToAddRows = false;
            this.dgvTransferOut.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransferOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferOut.Location = new System.Drawing.Point(1071, 35);
            this.dgvTransferOut.Name = "dgvTransferOut";
            this.dgvTransferOut.RowHeadersVisible = false;
            this.dgvTransferOut.Size = new System.Drawing.Size(219, 146);
            this.dgvTransferOut.TabIndex = 11478;
            // 
            // dgvAttendanceStatus
            // 
            this.dgvAttendanceStatus.AllowUserToAddRows = false;
            this.dgvAttendanceStatus.BackgroundColor = System.Drawing.Color.White;
            this.dgvAttendanceStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttendanceStatus.Location = new System.Drawing.Point(388, 35);
            this.dgvAttendanceStatus.Name = "dgvAttendanceStatus";
            this.dgvAttendanceStatus.RowHeadersVisible = false;
            this.dgvAttendanceStatus.Size = new System.Drawing.Size(428, 146);
            this.dgvAttendanceStatus.TabIndex = 11476;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 11475;
            this.label5.Text = "Department";
            // 
            // lbUnitNumber
            // 
            this.lbUnitNumber.AutoSize = true;
            this.lbUnitNumber.Location = new System.Drawing.Point(9, 62);
            this.lbUnitNumber.Name = "lbUnitNumber";
            this.lbUnitNumber.Size = new System.Drawing.Size(87, 15);
            this.lbUnitNumber.TabIndex = 11474;
            this.lbUnitNumber.Text = "Location Name";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(110, 83);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(255, 23);
            this.cmbDepartment.TabIndex = 11473;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(110, 59);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(255, 23);
            this.cmbLocation.TabIndex = 11472;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // cmbApprovalStatus
            // 
            this.cmbApprovalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApprovalStatus.FormattingEnabled = true;
            this.cmbApprovalStatus.Location = new System.Drawing.Point(46, 8);
            this.cmbApprovalStatus.Name = "cmbApprovalStatus";
            this.cmbApprovalStatus.Size = new System.Drawing.Size(151, 23);
            this.cmbApprovalStatus.TabIndex = 11388;
            // 
            // lblOverTime
            // 
            this.lblOverTime.BackColor = System.Drawing.Color.Pink;
            this.lblOverTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOverTime.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverTime.Location = new System.Drawing.Point(847, 185);
            this.lblOverTime.Name = "lblOverTime";
            this.lblOverTime.Size = new System.Drawing.Size(242, 20);
            this.lblOverTime.TabIndex = 11469;
            this.lblOverTime.Text = "Total OT";
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.Location = new System.Drawing.Point(20, 186);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAll.TabIndex = 11468;
            this.cbSelectAll.Text = "Select All";
            this.cbSelectAll.UseVisualStyleBackColor = true;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.BackColor = System.Drawing.Color.White;
            this.lblTotalCount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCount.Location = new System.Drawing.Point(384, 184);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(150, 21);
            this.lblTotalCount.TabIndex = 11467;
            this.lblTotalCount.Text = "Total Count";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1213, 662);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11464;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(9, 39);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(96, 15);
            this.lblFromDate.TabIndex = 11463;
            this.lblFromDate.Text = "Attendance Date";
            // 
            // dtpAttenanceDate
            // 
            this.dtpAttenanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAttenanceDate.Location = new System.Drawing.Point(110, 35);
            this.dtpAttenanceDate.Name = "dtpAttenanceDate";
            this.dtpAttenanceDate.Size = new System.Drawing.Size(100, 23);
            this.dtpAttenanceDate.TabIndex = 11462;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 11387;
            this.label1.Text = "Status";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(212, 133);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11466;
            this.btnDelete.Text = "View";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(290, 133);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11465;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pSave
            // 
            this.pSave.Controls.Add(this.btnSave);
            this.pSave.Controls.Add(this.txtRemarks);
            this.pSave.Controls.Add(this.cmbApprovalStatus);
            this.pSave.Controls.Add(this.label1);
            this.pSave.Controls.Add(this.lblRemarks);
            this.pSave.Location = new System.Drawing.Point(16, 659);
            this.pSave.Name = "pSave";
            this.pSave.Size = new System.Drawing.Size(1155, 36);
            this.pSave.TabIndex = 11470;
            this.pSave.Visible = false;
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(237, 12);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(54, 15);
            this.lblRemarks.TabIndex = 11389;
            this.lblRemarks.Text = "Remarks";
            this.lblRemarks.Visible = false;
            // 
            // cbTransferIn
            // 
            this.cbTransferIn.AutoSize = true;
            this.cbTransferIn.BackColor = System.Drawing.Color.Transparent;
            this.cbTransferIn.Location = new System.Drawing.Point(124, 186);
            this.cbTransferIn.Name = "cbTransferIn";
            this.cbTransferIn.Size = new System.Drawing.Size(86, 19);
            this.cbTransferIn.TabIndex = 11471;
            this.cbTransferIn.Text = "Transfer IN";
            this.cbTransferIn.UseVisualStyleBackColor = false;
            // 
            // OutddorPunchApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1298, 698);
            this.ControlBox = false;
            this.Controls.Add(this.cbTransferOut);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblManagerApproved);
            this.Controls.Add(this.lblHRApproved);
            this.Controls.Add(this.lblPending);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dgvTransferIN);
            this.Controls.Add(this.lblTransferCount);
            this.Controls.Add(this.lblCompleted);
            this.Controls.Add(this.cbDevice);
            this.Controls.Add(this.cmbDevice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchEmployee);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.txtSearchEmpCode);
            this.Controls.Add(this.dgvTransferOut);
            this.Controls.Add(this.dgvAttendanceStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbUnitNumber);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lblOverTime);
            this.Controls.Add(this.cbSelectAll);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpAttenanceDate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pSave);
            this.Controls.Add(this.cbTransferIn);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "OutddorPunchApproval";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.OutddorPunchApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferIN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttendanceStatus)).EndInit();
            this.pSave.ResumeLayout(false);
            this.pSave.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.CheckBox cbTransferOut;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.Label lblManagerApproved;
        private System.Windows.Forms.Label lblHRApproved;
        private System.Windows.Forms.Label lblPending;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dgvTransferIN;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblTransferCount;
        private System.Windows.Forms.Label lblCompleted;
        private System.Windows.Forms.CheckBox cbDevice;
        private System.Windows.Forms.ComboBox cmbDevice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSearchEmployee;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox txtSearchEmpCode;
        private System.Windows.Forms.DataGridView dgvTransferOut;
        private System.Windows.Forms.DataGridView dgvAttendanceStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbUnitNumber;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.ComboBox cmbApprovalStatus;
        private System.Windows.Forms.Label lblOverTime;
        private System.Windows.Forms.CheckBox cbSelectAll;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpAttenanceDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel pSave;
        private System.Windows.Forms.Label lblRemarks;
        private System.Windows.Forms.CheckBox cbTransferIn;
    }
}