namespace SPApplication.Transaction
{
    partial class RaiseTicket
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTicketNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTicketType = new System.Windows.Forms.ComboBox();
            this.cmbAssignedTo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReply = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSearchTicketNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSearchQuery = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dtpSearch = new System.Windows.Forms.DateTimePicker();
            this.cbToday = new System.Windows.Forms.CheckBox();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbRatings = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtSolvedPeriod = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.btnAddTicketType = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkViolet;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1230, 29);
            this.lblHeader.TabIndex = 75;
            this.lblHeader.Text = "Raise Ticket";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 65;
            this.label1.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(42, 31);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(116, 23);
            this.dtpDate.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1041, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 73;
            this.label5.Text = "Ticket No.";
            // 
            // txtTicketNo
            // 
            this.txtTicketNo.Location = new System.Drawing.Point(1103, 32);
            this.txtTicketNo.Name = "txtTicketNo";
            this.txtTicketNo.ReadOnly = true;
            this.txtTicketNo.Size = new System.Drawing.Size(116, 23);
            this.txtTicketNo.TabIndex = 74;
            this.txtTicketNo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 15);
            this.label2.TabIndex = 78;
            this.label2.Text = "Time";
            // 
            // dtpTime
            // 
            this.dtpTime.Enabled = false;
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(204, 31);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(116, 23);
            this.dtpTime.TabIndex = 77;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(12, 76);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(641, 239);
            this.txtQuery.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 15);
            this.label3.TabIndex = 80;
            this.label3.Text = "Raise Query In Details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(662, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 15);
            this.label6.TabIndex = 82;
            this.label6.Text = "Ticket Type";
            // 
            // cmbTicketType
            // 
            this.cmbTicketType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTicketType.FormattingEnabled = true;
            this.cmbTicketType.Location = new System.Drawing.Point(735, 72);
            this.cmbTicketType.Name = "cmbTicketType";
            this.cmbTicketType.Size = new System.Drawing.Size(317, 23);
            this.cmbTicketType.TabIndex = 2;
            this.cmbTicketType.SelectionChangeCommitted += new System.EventHandler(this.cmbTicketType_SelectionChangeCommitted);
            // 
            // cmbAssignedTo
            // 
            this.cmbAssignedTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssignedTo.FormattingEnabled = true;
            this.cmbAssignedTo.Location = new System.Drawing.Point(735, 96);
            this.cmbAssignedTo.Name = "cmbAssignedTo";
            this.cmbAssignedTo.Size = new System.Drawing.Size(317, 23);
            this.cmbAssignedTo.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(662, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 15);
            this.label7.TabIndex = 84;
            this.label7.Text = "Priority";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(662, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 81;
            this.label4.Text = "Assigned To";
            // 
            // cmbPriority
            // 
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(735, 120);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(122, 23);
            this.cmbPriority.TabIndex = 4;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Location = new System.Drawing.Point(617, 320);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(532, 320);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 30);
            this.btnClear.TabIndex = 9;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(447, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(702, 320);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 30);
            this.btnExit.TabIndex = 11;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "Pending",
            "In Process",
            "Complete",
            "Cancel"});
            this.cmbStatus.Location = new System.Drawing.Point(735, 144);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(122, 23);
            this.cmbStatus.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(662, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 15);
            this.label8.TabIndex = 91;
            this.label8.Text = "Status";
            // 
            // txtReply
            // 
            this.txtReply.BackColor = System.Drawing.Color.White;
            this.txtReply.Location = new System.Drawing.Point(735, 168);
            this.txtReply.Multiline = true;
            this.txtReply.Name = "txtReply";
            this.txtReply.ReadOnly = true;
            this.txtReply.Size = new System.Drawing.Size(484, 119);
            this.txtReply.TabIndex = 7;
            this.txtReply.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(662, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 30);
            this.label9.TabIndex = 94;
            this.label9.Text = "Reply or\r\nAnswer";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(13, 337);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 98;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(11, 354);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1205, 339);
            this.dataGridView1.TabIndex = 96;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // txtSearchTicketNo
            // 
            this.txtSearchTicketNo.Location = new System.Drawing.Point(168, 324);
            this.txtSearchTicketNo.Name = "txtSearchTicketNo";
            this.txtSearchTicketNo.Size = new System.Drawing.Size(68, 23);
            this.txtSearchTicketNo.TabIndex = 95;
            this.txtSearchTicketNo.TextChanged += new System.EventHandler(this.txtSearchTicketNo_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(109, 328);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 15);
            this.label10.TabIndex = 97;
            this.label10.Text = "Ticket No";
            // 
            // txtSearchQuery
            // 
            this.txtSearchQuery.Location = new System.Drawing.Point(284, 324);
            this.txtSearchQuery.Name = "txtSearchQuery";
            this.txtSearchQuery.Size = new System.Drawing.Size(134, 23);
            this.txtSearchQuery.TabIndex = 99;
            this.txtSearchQuery.TextChanged += new System.EventHandler(this.txtSearchQuery_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(238, 328);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 15);
            this.label11.TabIndex = 100;
            this.label11.Text = "Search";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(961, 328);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 15);
            this.label12.TabIndex = 102;
            this.label12.Text = "Search Date";
            // 
            // dtpSearch
            // 
            this.dtpSearch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSearch.Location = new System.Drawing.Point(1035, 324);
            this.dtpSearch.Name = "dtpSearch";
            this.dtpSearch.Size = new System.Drawing.Size(116, 23);
            this.dtpSearch.TabIndex = 101;
            // 
            // cbToday
            // 
            this.cbToday.AutoSize = true;
            this.cbToday.Location = new System.Drawing.Point(1158, 326);
            this.cbToday.Name = "cbToday";
            this.cbToday.Size = new System.Drawing.Size(58, 19);
            this.cbToday.TabIndex = 103;
            this.cbToday.Text = "Today";
            this.cbToday.UseVisualStyleBackColor = true;
            this.cbToday.CheckedChanged += new System.EventHandler(this.cbToday_CheckedChanged);
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.Items.AddRange(new object[] {
            "1 Hour",
            "2 Hours",
            "3 Hours",
            "4 Hours",
            "5 Hours",
            "1 Day",
            "2 Days",
            "3 Days",
            "4 Days",
            "5 Days"});
            this.cmbPeriod.Location = new System.Drawing.Point(936, 120);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.Size = new System.Drawing.Size(116, 23);
            this.cmbPeriod.TabIndex = 5;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(862, 124);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 15);
            this.label13.TabIndex = 104;
            this.label13.Text = "Hours/Days";
            // 
            // cmbRatings
            // 
            this.cmbRatings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRatings.FormattingEnabled = true;
            this.cmbRatings.Items.AddRange(new object[] {
            "5*",
            "4*",
            "3*",
            "2*",
            "1*",
            "0"});
            this.cmbRatings.Location = new System.Drawing.Point(735, 289);
            this.cmbRatings.Name = "cmbRatings";
            this.cmbRatings.Size = new System.Drawing.Size(82, 23);
            this.cmbRatings.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(662, 293);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 15);
            this.label14.TabIndex = 107;
            this.label14.Text = "Ratings";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.LawnGreen;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Location = new System.Drawing.Point(934, 292);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 15);
            this.label15.TabIndex = 108;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(951, 292);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 15);
            this.label16.TabIndex = 109;
            this.label16.Text = "Complete";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1028, 292);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 15);
            this.label17.TabIndex = 111;
            this.label17.Text = "Pending";
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Yellow;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Location = new System.Drawing.Point(1011, 292);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(15, 15);
            this.label18.TabIndex = 110;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1099, 292);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 15);
            this.label19.TabIndex = 113;
            this.label19.Text = "In Process";
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Aqua;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Location = new System.Drawing.Point(1082, 292);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 15);
            this.label20.TabIndex = 112;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1182, 292);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(44, 15);
            this.label21.TabIndex = 115;
            this.label21.Text = "Cancel";
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Red;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Location = new System.Drawing.Point(1165, 292);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(15, 15);
            this.label22.TabIndex = 114;
            // 
            // txtSolvedPeriod
            // 
            this.txtSolvedPeriod.Location = new System.Drawing.Point(936, 144);
            this.txtSolvedPeriod.Name = "txtSolvedPeriod";
            this.txtSolvedPeriod.ReadOnly = true;
            this.txtSolvedPeriod.Size = new System.Drawing.Size(116, 23);
            this.txtSolvedPeriod.TabIndex = 117;
            this.txtSolvedPeriod.TabStop = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(857, 148);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(82, 15);
            this.label23.TabIndex = 116;
            this.label23.Text = "Solved Period";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(1054, 148);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(54, 15);
            this.label24.TabIndex = 118;
            this.label24.Text = "In Hours";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(876, 293);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 15);
            this.label27.TabIndex = 135;
            this.label27.Text = "Selected";
            // 
            // lblSelected
            // 
            this.lblSelected.BackColor = System.Drawing.Color.Navy;
            this.lblSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSelected.Location = new System.Drawing.Point(859, 293);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(15, 15);
            this.lblSelected.TabIndex = 134;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(428, 31);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(225, 23);
            this.cmbDepartment.TabIndex = 0;
            this.cmbDepartment.SelectionChangeCommitted += new System.EventHandler(this.cmbDepartment_SelectionChangeCommitted);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(355, 34);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(71, 15);
            this.label25.TabIndex = 137;
            this.label25.Text = "Department";
            // 
            // btnAddTicketType
            // 
            this.btnAddTicketType.BackColor = System.Drawing.Color.Blue;
            this.btnAddTicketType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddTicketType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddTicketType.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTicketType.ForeColor = System.Drawing.Color.White;
            this.btnAddTicketType.Location = new System.Drawing.Point(1059, 73);
            this.btnAddTicketType.Name = "btnAddTicketType";
            this.btnAddTicketType.Size = new System.Drawing.Size(20, 20);
            this.btnAddTicketType.TabIndex = 11437;
            this.btnAddTicketType.Text = "+";
            this.btnAddTicketType.UseVisualStyleBackColor = false;
            this.btnAddTicketType.Click += new System.EventHandler(this.btnAddTicketType_Click);
            // 
            // RaiseTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1228, 698);
            this.ControlBox = false;
            this.Controls.Add(this.btnAddTicketType);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtSolvedPeriod);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbRatings);
            this.Controls.Add(this.cmbPeriod);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbToday);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dtpSearch);
            this.Controls.Add(this.txtSearchQuery);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtSearchTicketNo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtReply);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.cmbAssignedTo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbTicketType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.txtTicketNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDate);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "RaiseTicket";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.RaiseTicket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTicketNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTicketType;
        private System.Windows.Forms.ComboBox cmbAssignedTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtReply;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSearchTicketNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSearchQuery;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpSearch;
        private System.Windows.Forms.CheckBox cbToday;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbRatings;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtSolvedPeriod;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnAddTicketType;
    }
}