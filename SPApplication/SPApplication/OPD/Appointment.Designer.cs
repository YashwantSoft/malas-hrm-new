namespace SPApplication.OPD
{
    partial class Appointment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpAppointmentDate = new System.Windows.Forms.DateTimePicker();
            this.gbRegisterPatientDetails = new System.Windows.Forms.GroupBox();
            this.txtSearchID = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTokenNumber = new System.Windows.Forms.Label();
            this.lbSearchPatient = new System.Windows.Forms.ListBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSexAge = new System.Windows.Forms.TextBox();
            this.txtPatientRegNo = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnAddPatient = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPatientSearch = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbIsSpecial = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvAppointment = new System.Windows.Forms.DataGridView();
            this.cbToday = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtSearchPatientGrid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gbRegisterPatientDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointment)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Blue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1227, 35);
            this.lblHeader.TabIndex = 11190;
            this.lblHeader.Text = "Appointment";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 11203;
            this.label1.Text = "Appointment";
            // 
            // dtpAppointmentDate
            // 
            this.dtpAppointmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAppointmentDate.Location = new System.Drawing.Point(413, 18);
            this.dtpAppointmentDate.Name = "dtpAppointmentDate";
            this.dtpAppointmentDate.Size = new System.Drawing.Size(355, 25);
            this.dtpAppointmentDate.TabIndex = 0;
            this.dtpAppointmentDate.ValueChanged += new System.EventHandler(this.dtpAppointmentDate_ValueChanged);
            // 
            // gbRegisterPatientDetails
            // 
            this.gbRegisterPatientDetails.Controls.Add(this.txtSearchID);
            this.gbRegisterPatientDetails.Controls.Add(this.label11);
            this.gbRegisterPatientDetails.Controls.Add(this.lblTokenNumber);
            this.gbRegisterPatientDetails.Controls.Add(this.lbSearchPatient);
            this.gbRegisterPatientDetails.Controls.Add(this.btnClear);
            this.gbRegisterPatientDetails.Controls.Add(this.label1);
            this.gbRegisterPatientDetails.Controls.Add(this.txtSexAge);
            this.gbRegisterPatientDetails.Controls.Add(this.txtPatientRegNo);
            this.gbRegisterPatientDetails.Controls.Add(this.dtpAppointmentDate);
            this.gbRegisterPatientDetails.Controls.Add(this.btnSave);
            this.gbRegisterPatientDetails.Controls.Add(this.label6);
            this.gbRegisterPatientDetails.Controls.Add(this.label5);
            this.gbRegisterPatientDetails.Controls.Add(this.txtAddress);
            this.gbRegisterPatientDetails.Controls.Add(this.btnAddPatient);
            this.gbRegisterPatientDetails.Controls.Add(this.label10);
            this.gbRegisterPatientDetails.Controls.Add(this.txtPatientSearch);
            this.gbRegisterPatientDetails.Controls.Add(this.label31);
            this.gbRegisterPatientDetails.Controls.Add(this.lblSex);
            this.gbRegisterPatientDetails.Controls.Add(this.txtFullName);
            this.gbRegisterPatientDetails.Controls.Add(this.label7);
            this.gbRegisterPatientDetails.Controls.Add(this.txtMobileNo);
            this.gbRegisterPatientDetails.Controls.Add(this.label8);
            this.gbRegisterPatientDetails.Controls.Add(this.cbIsSpecial);
            this.gbRegisterPatientDetails.Location = new System.Drawing.Point(18, 35);
            this.gbRegisterPatientDetails.Name = "gbRegisterPatientDetails";
            this.gbRegisterPatientDetails.Size = new System.Drawing.Size(1195, 220);
            this.gbRegisterPatientDetails.TabIndex = 0;
            this.gbRegisterPatientDetails.TabStop = false;
            this.gbRegisterPatientDetails.Text = "Appointment";
            this.gbRegisterPatientDetails.Visible = false;
            // 
            // txtSearchID
            // 
            this.txtSearchID.Location = new System.Drawing.Point(706, 43);
            this.txtSearchID.Name = "txtSearchID";
            this.txtSearchID.Size = new System.Drawing.Size(62, 25);
            this.txtSearchID.TabIndex = 11449;
            this.txtSearchID.TextChanged += new System.EventHandler(this.TxtSearchID_TextChanged);
            this.txtSearchID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearchID_KeyDown);
            this.txtSearchID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSearchID_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(675, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 18);
            this.label11.TabIndex = 11450;
            this.label11.Text = "ID";
            // 
            // lblTokenNumber
            // 
            this.lblTokenNumber.BackColor = System.Drawing.Color.DimGray;
            this.lblTokenNumber.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTokenNumber.Location = new System.Drawing.Point(1101, 17);
            this.lblTokenNumber.Name = "lblTokenNumber";
            this.lblTokenNumber.Size = new System.Drawing.Size(74, 75);
            this.lblTokenNumber.TabIndex = 11448;
            this.lblTokenNumber.Text = "1";
            this.lblTokenNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbSearchPatient
            // 
            this.lbSearchPatient.FormattingEnabled = true;
            this.lbSearchPatient.ItemHeight = 17;
            this.lbSearchPatient.Location = new System.Drawing.Point(413, 70);
            this.lbSearchPatient.Name = "lbSearchPatient";
            this.lbSearchPatient.Size = new System.Drawing.Size(355, 140);
            this.lbSearchPatient.TabIndex = 2;
            this.lbSearchPatient.Visible = false;
            this.lbSearchPatient.Click += new System.EventHandler(this.lbSearchPatient_Click);
            this.lbSearchPatient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbSearchPatient_KeyDown);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(1091, 150);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(84, 35);
            this.btnClear.TabIndex = 4;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtSexAge
            // 
            this.txtSexAge.BackColor = System.Drawing.Color.White;
            this.txtSexAge.Location = new System.Drawing.Point(413, 178);
            this.txtSexAge.Name = "txtSexAge";
            this.txtSexAge.ReadOnly = true;
            this.txtSexAge.Size = new System.Drawing.Size(120, 25);
            this.txtSexAge.TabIndex = 11247;
            this.txtSexAge.TabStop = false;
            // 
            // txtPatientRegNo
            // 
            this.txtPatientRegNo.BackColor = System.Drawing.Color.White;
            this.txtPatientRegNo.Location = new System.Drawing.Point(413, 152);
            this.txtPatientRegNo.Name = "txtPatientRegNo";
            this.txtPatientRegNo.ReadOnly = true;
            this.txtPatientRegNo.Size = new System.Drawing.Size(121, 25);
            this.txtPatientRegNo.TabIndex = 11246;
            this.txtPatientRegNo.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(999, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(304, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 18);
            this.label6.TabIndex = 11245;
            this.label6.Text = "Patient Reg. No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 11243;
            this.label5.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.Location = new System.Drawing.Point(413, 96);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(355, 55);
            this.txtAddress.TabIndex = 11244;
            this.txtAddress.TabStop = false;
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.BackColor = System.Drawing.Color.Blue;
            this.btnAddPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPatient.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPatient.ForeColor = System.Drawing.Color.White;
            this.btnAddPatient.Location = new System.Drawing.Point(785, 45);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(126, 35);
            this.btnAddPatient.TabIndex = 2;
            this.btnAddPatient.Text = "New Patient";
            this.btnAddPatient.UseVisualStyleBackColor = false;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPatient_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(935, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 18);
            this.label10.TabIndex = 11258;
            this.label10.Text = "Next Token Number";
            // 
            // txtPatientSearch
            // 
            this.txtPatientSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPatientSearch.Location = new System.Drawing.Point(413, 44);
            this.txtPatientSearch.Name = "txtPatientSearch";
            this.txtPatientSearch.Size = new System.Drawing.Size(256, 25);
            this.txtPatientSearch.TabIndex = 1;
            this.txtPatientSearch.TextChanged += new System.EventHandler(this.txtPatientSearch_TextChanged);
            this.txtPatientSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPatientSearch_KeyDown);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(304, 46);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(107, 18);
            this.label31.TabIndex = 11240;
            this.label31.Text = "Search by Name";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(304, 182);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(66, 18);
            this.lblSex.TabIndex = 11197;
            this.lblSex.Text = "Sex / Age";
            // 
            // txtFullName
            // 
            this.txtFullName.BackColor = System.Drawing.Color.White;
            this.txtFullName.Location = new System.Drawing.Point(413, 70);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(355, 25);
            this.txtFullName.TabIndex = 11191;
            this.txtFullName.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(304, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 18);
            this.label7.TabIndex = 11196;
            this.label7.Text = "Full Name";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.BackColor = System.Drawing.Color.White;
            this.txtMobileNo.Location = new System.Drawing.Point(648, 152);
            this.txtMobileNo.Mask = "0000000000";
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.ReadOnly = true;
            this.txtMobileNo.Size = new System.Drawing.Size(120, 25);
            this.txtMobileNo.TabIndex = 11190;
            this.txtMobileNo.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(548, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 18);
            this.label8.TabIndex = 11189;
            this.label8.Text = "Mobile No.";
            // 
            // cbIsSpecial
            // 
            this.cbIsSpecial.AutoSize = true;
            this.cbIsSpecial.Location = new System.Drawing.Point(648, 179);
            this.cbIsSpecial.Name = "cbIsSpecial";
            this.cbIsSpecial.Size = new System.Drawing.Size(71, 22);
            this.cbIsSpecial.TabIndex = 11259;
            this.cbIsSpecial.Text = "Special";
            this.cbIsSpecial.UseVisualStyleBackColor = true;
            this.cbIsSpecial.CheckedChanged += new System.EventHandler(this.cbIsSpecial_CheckedChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.Enabled = false;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Location = new System.Drawing.Point(1091, 321);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 35);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvAppointment
            // 
            this.dgvAppointment.AllowUserToAddRows = false;
            this.dgvAppointment.AllowUserToResizeColumns = false;
            this.dgvAppointment.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppointment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAppointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAppointment.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvAppointment.Location = new System.Drawing.Point(16, 63);
            this.dgvAppointment.Name = "dgvAppointment";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppointment.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvAppointment.RowHeadersWidth = 51;
            this.dgvAppointment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppointment.Size = new System.Drawing.Size(1163, 252);
            this.dgvAppointment.TabIndex = 11252;
            this.dgvAppointment.TabStop = false;
            this.dgvAppointment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointment_CellClick);
            // 
            // cbToday
            // 
            this.cbToday.AutoSize = true;
            this.cbToday.Location = new System.Drawing.Point(804, 26);
            this.cbToday.Name = "cbToday";
            this.cbToday.Size = new System.Drawing.Size(96, 22);
            this.cbToday.TabIndex = 8;
            this.cbToday.Text = "Today\'s List";
            this.cbToday.UseVisualStyleBackColor = true;
            this.cbToday.CheckedChanged += new System.EventHandler(this.cbToday_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(576, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 18);
            this.label2.TabIndex = 11257;
            this.label2.Text = "To Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(647, 25);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(134, 25);
            this.dtpToDate.TabIndex = 7;
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 11256;
            this.label4.Text = "From Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(439, 25);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(134, 25);
            this.dtpFromDate.TabIndex = 6;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // txtSearchPatientGrid
            // 
            this.txtSearchPatientGrid.BackColor = System.Drawing.Color.White;
            this.txtSearchPatientGrid.Location = new System.Drawing.Point(141, 26);
            this.txtSearchPatientGrid.Name = "txtSearchPatientGrid";
            this.txtSearchPatientGrid.Size = new System.Drawing.Size(200, 25);
            this.txtSearchPatientGrid.TabIndex = 5;
            this.txtSearchPatientGrid.TextChanged += new System.EventHandler(this.txtSearchPatientGrid_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 18);
            this.label9.TabIndex = 11247;
            this.label9.Text = "Search Patient";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCount.Location = new System.Drawing.Point(969, 28);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(130, 18);
            this.lblTotalCount.TabIndex = 11248;
            this.lblTotalCount.Text = "Total Appointments";
            // 
            // btnReport
            // 
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Location = new System.Drawing.Point(1019, 624);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(84, 35);
            this.btnReport.TabIndex = 10;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(1109, 624);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(84, 35);
            this.btnExit.TabIndex = 11;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.txtSearchPatientGrid);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.lblTotalCount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgvAppointment);
            this.groupBox1.Controls.Add(this.cbToday);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(18, 255);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1195, 364);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Appointment List";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(137, 321);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 29);
            this.label3.TabIndex = 11191;
            this.label3.Text = "Appointment Done";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Location = new System.Drawing.Point(17, 320);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 35);
            this.btnRefresh.TabIndex = 11258;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // Appointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1219, 664);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.gbRegisterPatientDetails);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Appointment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Appointment_Load);
            this.gbRegisterPatientDetails.ResumeLayout(false);
            this.gbRegisterPatientDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointment)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpAppointmentDate;
        private System.Windows.Forms.GroupBox gbRegisterPatientDetails;
        private System.Windows.Forms.ListBox lbSearchPatient;
        private System.Windows.Forms.TextBox txtPatientRegNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.TextBox txtPatientSearch;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtMobileNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvAppointment;
        private System.Windows.Forms.CheckBox cbToday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.TextBox txtSearchPatientGrid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSexAge;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.CheckBox cbIsSpecial;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTokenNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchID;
        private System.Windows.Forms.Label label11;
    }
}