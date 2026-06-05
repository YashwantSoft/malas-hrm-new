namespace SPApplication.Transaction
{
    partial class OutdoorPunchNew
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
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lbEmployee = new System.Windows.Forms.ListBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbEmployee = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbEditAttendance = new System.Windows.Forms.GroupBox();
            this.txtOverTime1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbOverTime = new System.Windows.Forms.CheckBox();
            this.dtpShiftOutTime = new System.Windows.Forms.DateTimePicker();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.dtpShiftInTime = new System.Windows.Forms.DateTimePicker();
            this.txtOverTime = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.dtpOutTime = new System.Windows.Forms.DateTimePicker();
            this.lblAttendanceDay = new System.Windows.Forms.Label();
            this.dtpAttendanceDate = new System.Windows.Forms.DateTimePicker();
            this.label37 = new System.Windows.Forms.Label();
            this.cmbShift = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtShiftDuration = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMissedOutPunch = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMissedInPunch = new System.Windows.Forms.TextBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.dtpInTime = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotalDuration = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEarlyBy = new System.Windows.Forms.TextBox();
            this.txtLateBy = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.gbEditAttendance.SuspendLayout();
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
            this.lblHeader.Size = new System.Drawing.Size(1199, 30);
            this.lblHeader.TabIndex = 11357;
            this.lblHeader.Text = "TT DB";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(92, 37);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(32, 15);
            this.lblFromDate.TabIndex = 11496;
            this.lblFromDate.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(195, 33);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(100, 23);
            this.dtpDate.TabIndex = 11495;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 11494;
            this.label1.Text = "Employee Details";
            // 
            // lbEmployee
            // 
            this.lbEmployee.FormattingEnabled = true;
            this.lbEmployee.ItemHeight = 15;
            this.lbEmployee.Location = new System.Drawing.Point(195, 81);
            this.lbEmployee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lbEmployee.Name = "lbEmployee";
            this.lbEmployee.Size = new System.Drawing.Size(332, 214);
            this.lbEmployee.TabIndex = 11491;
            this.lbEmployee.Click += new System.EventHandler(this.lbEmployee_Click);
            this.lbEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbEmployee_KeyDown);
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(195, 57);
            this.txtEmployeeName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(332, 23);
            this.txtEmployeeName.TabIndex = 11490;
            this.txtEmployeeName.TextChanged += new System.EventHandler(this.txtEmployeeName_TextChanged);
            this.txtEmployeeName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmployeeName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 11492;
            this.label2.Text = "Search Employee";
            // 
            // rtbEmployee
            // 
            this.rtbEmployee.Location = new System.Drawing.Point(195, 82);
            this.rtbEmployee.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtbEmployee.Name = "rtbEmployee";
            this.rtbEmployee.ReadOnly = true;
            this.rtbEmployee.Size = new System.Drawing.Size(332, 213);
            this.rtbEmployee.TabIndex = 11493;
            this.rtbEmployee.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(522, 301);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11501;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(682, 301);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11500;
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
            this.btnDelete.Location = new System.Drawing.Point(602, 301);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11499;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(442, 301);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11498;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbEditAttendance
            // 
            this.gbEditAttendance.Controls.Add(this.txtOverTime1);
            this.gbEditAttendance.Controls.Add(this.label3);
            this.gbEditAttendance.Controls.Add(this.label15);
            this.gbEditAttendance.Controls.Add(this.cbOverTime);
            this.gbEditAttendance.Controls.Add(this.dtpShiftOutTime);
            this.gbEditAttendance.Controls.Add(this.txtDuration);
            this.gbEditAttendance.Controls.Add(this.dtpShiftInTime);
            this.gbEditAttendance.Controls.Add(this.txtOverTime);
            this.gbEditAttendance.Controls.Add(this.label36);
            this.gbEditAttendance.Controls.Add(this.label35);
            this.gbEditAttendance.Controls.Add(this.dtpOutTime);
            this.gbEditAttendance.Controls.Add(this.lblAttendanceDay);
            this.gbEditAttendance.Controls.Add(this.dtpAttendanceDate);
            this.gbEditAttendance.Controls.Add(this.label37);
            this.gbEditAttendance.Controls.Add(this.cmbShift);
            this.gbEditAttendance.Controls.Add(this.label4);
            this.gbEditAttendance.Controls.Add(this.txtShiftDuration);
            this.gbEditAttendance.Controls.Add(this.label13);
            this.gbEditAttendance.Controls.Add(this.label5);
            this.gbEditAttendance.Controls.Add(this.label6);
            this.gbEditAttendance.Controls.Add(this.txtMissedOutPunch);
            this.gbEditAttendance.Controls.Add(this.label14);
            this.gbEditAttendance.Controls.Add(this.txtMissedInPunch);
            this.gbEditAttendance.Controls.Add(this.cmbStatus);
            this.gbEditAttendance.Controls.Add(this.dtpInTime);
            this.gbEditAttendance.Controls.Add(this.label7);
            this.gbEditAttendance.Controls.Add(this.label8);
            this.gbEditAttendance.Controls.Add(this.label12);
            this.gbEditAttendance.Controls.Add(this.txtTotalDuration);
            this.gbEditAttendance.Controls.Add(this.label9);
            this.gbEditAttendance.Controls.Add(this.label10);
            this.gbEditAttendance.Controls.Add(this.txtEarlyBy);
            this.gbEditAttendance.Controls.Add(this.txtLateBy);
            this.gbEditAttendance.Controls.Add(this.label11);
            this.gbEditAttendance.Location = new System.Drawing.Point(534, 31);
            this.gbEditAttendance.Name = "gbEditAttendance";
            this.gbEditAttendance.Size = new System.Drawing.Size(572, 264);
            this.gbEditAttendance.TabIndex = 11502;
            this.gbEditAttendance.TabStop = false;
            this.gbEditAttendance.Text = "Attendance Rcords";
            // 
            // txtOverTime1
            // 
            this.txtOverTime1.Enabled = false;
            this.txtOverTime1.Location = new System.Drawing.Point(444, 66);
            this.txtOverTime1.Name = "txtOverTime1";
            this.txtOverTime1.Size = new System.Drawing.Size(100, 23);
            this.txtOverTime1.TabIndex = 11454;
            this.txtOverTime1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 11453;
            this.label3.Text = "Over Time";
            this.label3.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(96, 15);
            this.label15.TabIndex = 11442;
            this.label15.Text = "Attendance Date";
            this.label15.Visible = false;
            // 
            // cbOverTime
            // 
            this.cbOverTime.AutoSize = true;
            this.cbOverTime.Location = new System.Drawing.Point(255, 92);
            this.cbOverTime.Name = "cbOverTime";
            this.cbOverTime.Size = new System.Drawing.Size(81, 19);
            this.cbOverTime.TabIndex = 11452;
            this.cbOverTime.Text = "Over Time";
            this.cbOverTime.UseVisualStyleBackColor = true;
            // 
            // dtpShiftOutTime
            // 
            this.dtpShiftOutTime.CustomFormat = "HH:mm";
            this.dtpShiftOutTime.Enabled = false;
            this.dtpShiftOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShiftOutTime.Location = new System.Drawing.Point(338, 161);
            this.dtpShiftOutTime.Name = "dtpShiftOutTime";
            this.dtpShiftOutTime.Size = new System.Drawing.Size(100, 23);
            this.dtpShiftOutTime.TabIndex = 11444;
            // 
            // txtDuration
            // 
            this.txtDuration.Enabled = false;
            this.txtDuration.Location = new System.Drawing.Point(108, 89);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(100, 23);
            this.txtDuration.TabIndex = 11439;
            // 
            // dtpShiftInTime
            // 
            this.dtpShiftInTime.CustomFormat = "HH:mm";
            this.dtpShiftInTime.Enabled = false;
            this.dtpShiftInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShiftInTime.Location = new System.Drawing.Point(108, 161);
            this.dtpShiftInTime.Name = "dtpShiftInTime";
            this.dtpShiftInTime.Size = new System.Drawing.Size(100, 23);
            this.dtpShiftInTime.TabIndex = 11441;
            // 
            // txtOverTime
            // 
            this.txtOverTime.Enabled = false;
            this.txtOverTime.Location = new System.Drawing.Point(338, 89);
            this.txtOverTime.Name = "txtOverTime";
            this.txtOverTime.Size = new System.Drawing.Size(100, 23);
            this.txtOverTime.TabIndex = 11438;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(10, 165);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(75, 15);
            this.label36.TabIndex = 11442;
            this.label36.Text = "Shift In Time";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(10, 93);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(55, 15);
            this.label35.TabIndex = 11440;
            this.label35.Text = "Duration";
            // 
            // dtpOutTime
            // 
            this.dtpOutTime.CustomFormat = "HH:mm";
            this.dtpOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOutTime.Location = new System.Drawing.Point(108, 65);
            this.dtpOutTime.Name = "dtpOutTime";
            this.dtpOutTime.Size = new System.Drawing.Size(330, 23);
            this.dtpOutTime.TabIndex = 11437;
            this.dtpOutTime.Leave += new System.EventHandler(this.dtpOutTime_Leave);
            // 
            // lblAttendanceDay
            // 
            this.lblAttendanceDay.AutoSize = true;
            this.lblAttendanceDay.Location = new System.Drawing.Point(252, 20);
            this.lblAttendanceDay.Name = "lblAttendanceDay";
            this.lblAttendanceDay.Size = new System.Drawing.Size(92, 15);
            this.lblAttendanceDay.TabIndex = 11362;
            this.lblAttendanceDay.Text = "Attendance Day";
            this.lblAttendanceDay.Visible = false;
            // 
            // dtpAttendanceDate
            // 
            this.dtpAttendanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAttendanceDate.Location = new System.Drawing.Point(108, 17);
            this.dtpAttendanceDate.Name = "dtpAttendanceDate";
            this.dtpAttendanceDate.Size = new System.Drawing.Size(100, 23);
            this.dtpAttendanceDate.TabIndex = 11361;
            this.dtpAttendanceDate.Visible = false;
            this.dtpAttendanceDate.ValueChanged += new System.EventHandler(this.dtpAttendanceDate_ValueChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(221, 165);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(84, 15);
            this.label37.TabIndex = 11443;
            this.label37.Text = "Shift Out Time";
            // 
            // cmbShift
            // 
            this.cmbShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShift.Enabled = false;
            this.cmbShift.FormattingEnabled = true;
            this.cmbShift.Location = new System.Drawing.Point(108, 137);
            this.cmbShift.Name = "cmbShift";
            this.cmbShift.Size = new System.Drawing.Size(330, 23);
            this.cmbShift.TabIndex = 11403;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 11402;
            this.label4.Text = "Shift";
            // 
            // txtShiftDuration
            // 
            this.txtShiftDuration.BackColor = System.Drawing.Color.White;
            this.txtShiftDuration.Enabled = false;
            this.txtShiftDuration.Location = new System.Drawing.Point(108, 185);
            this.txtShiftDuration.Name = "txtShiftDuration";
            this.txtShiftDuration.ReadOnly = true;
            this.txtShiftDuration.Size = new System.Drawing.Size(100, 23);
            this.txtShiftDuration.TabIndex = 11404;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(221, 238);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 15);
            this.label13.TabIndex = 11423;
            this.label13.Text = "Missed Punch (Out)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 11405;
            this.label5.Text = "Shift Duration";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Pink;
            this.label6.Location = new System.Drawing.Point(224, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 21);
            this.label6.TabIndex = 11406;
            this.label6.Text = "Status";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMissedOutPunch
            // 
            this.txtMissedOutPunch.BackColor = System.Drawing.Color.White;
            this.txtMissedOutPunch.Enabled = false;
            this.txtMissedOutPunch.Location = new System.Drawing.Point(338, 234);
            this.txtMissedOutPunch.Name = "txtMissedOutPunch";
            this.txtMissedOutPunch.ReadOnly = true;
            this.txtMissedOutPunch.Size = new System.Drawing.Size(100, 23);
            this.txtMissedOutPunch.TabIndex = 11422;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(221, 214);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 15);
            this.label14.TabIndex = 11421;
            this.label14.Text = "Missed Punch (In)";
            // 
            // txtMissedInPunch
            // 
            this.txtMissedInPunch.BackColor = System.Drawing.Color.White;
            this.txtMissedInPunch.Enabled = false;
            this.txtMissedInPunch.Location = new System.Drawing.Point(338, 210);
            this.txtMissedInPunch.Name = "txtMissedInPunch";
            this.txtMissedInPunch.ReadOnly = true;
            this.txtMissedInPunch.Size = new System.Drawing.Size(100, 23);
            this.txtMissedInPunch.TabIndex = 11420;
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Enabled = false;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(338, 185);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(100, 23);
            this.cmbStatus.TabIndex = 11407;
            // 
            // dtpInTime
            // 
            this.dtpInTime.CustomFormat = "HH:mm";
            this.dtpInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInTime.Location = new System.Drawing.Point(108, 41);
            this.dtpInTime.Name = "dtpInTime";
            this.dtpInTime.Size = new System.Drawing.Size(330, 23);
            this.dtpInTime.TabIndex = 11408;
            this.dtpInTime.Leave += new System.EventHandler(this.dtpInTime_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 15);
            this.label7.TabIndex = 11409;
            this.label7.Text = "In Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 15);
            this.label8.TabIndex = 11411;
            this.label8.Text = "Out Time";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 238);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 15);
            this.label12.TabIndex = 11419;
            this.label12.Text = "Early by";
            // 
            // txtTotalDuration
            // 
            this.txtTotalDuration.Enabled = false;
            this.txtTotalDuration.Location = new System.Drawing.Point(108, 113);
            this.txtTotalDuration.Name = "txtTotalDuration";
            this.txtTotalDuration.Size = new System.Drawing.Size(100, 23);
            this.txtTotalDuration.TabIndex = 11412;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 15);
            this.label9.TabIndex = 11413;
            this.label9.Text = "Total Duration";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(252, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 15);
            this.label10.TabIndex = 11415;
            this.label10.Text = "Over Time";
            // 
            // txtEarlyBy
            // 
            this.txtEarlyBy.BackColor = System.Drawing.Color.White;
            this.txtEarlyBy.Enabled = false;
            this.txtEarlyBy.Location = new System.Drawing.Point(108, 234);
            this.txtEarlyBy.Name = "txtEarlyBy";
            this.txtEarlyBy.ReadOnly = true;
            this.txtEarlyBy.Size = new System.Drawing.Size(100, 23);
            this.txtEarlyBy.TabIndex = 11418;
            // 
            // txtLateBy
            // 
            this.txtLateBy.BackColor = System.Drawing.Color.White;
            this.txtLateBy.Enabled = false;
            this.txtLateBy.Location = new System.Drawing.Point(108, 210);
            this.txtLateBy.Name = "txtLateBy";
            this.txtLateBy.ReadOnly = true;
            this.txtLateBy.Size = new System.Drawing.Size(100, 23);
            this.txtLateBy.TabIndex = 11416;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 214);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 15);
            this.label11.TabIndex = 11417;
            this.label11.Text = "Late by";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(13, 321);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11503;
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
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(10, 338);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1176, 348);
            this.dataGridView1.TabIndex = 11505;
            // 
            // OutdoorPunchNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 698);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.gbEditAttendance);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
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
            this.Name = "OutdoorPunchNew";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.OutdoorPunchNew_Load);
            this.gbEditAttendance.ResumeLayout(false);
            this.gbEditAttendance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbEmployee;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbEmployee;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbEditAttendance;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox cbOverTime;
        private System.Windows.Forms.DateTimePicker dtpShiftOutTime;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.DateTimePicker dtpShiftInTime;
        private System.Windows.Forms.TextBox txtOverTime;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.DateTimePicker dtpOutTime;
        private System.Windows.Forms.Label lblAttendanceDay;
        private System.Windows.Forms.DateTimePicker dtpAttendanceDate;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.ComboBox cmbShift;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtShiftDuration;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMissedOutPunch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMissedInPunch;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker dtpInTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalDuration;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEarlyBy;
        private System.Windows.Forms.TextBox txtLateBy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOverTime1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}