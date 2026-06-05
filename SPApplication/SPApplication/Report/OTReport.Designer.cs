namespace SPApplication.Report.HRReports
{
    partial class OTReport
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
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cbRoll = new System.Windows.Forms.CheckBox();
            this.cmbRoll = new System.Windows.Forms.ComboBox();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.cbStatusAll = new System.Windows.Forms.CheckBox();
            this.cbSelectAllLocation = new System.Windows.Forms.CheckBox();
            this.cbSelectAllDepartment = new System.Windows.Forms.CheckBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmEmployeeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRoll = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clm31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalOT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotalOTDays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "WORKING",
            "RESIGNED"});
            this.cmbStatus.Location = new System.Drawing.Point(885, 64);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(255, 23);
            this.cmbStatus.TabIndex = 11467;
            // 
            // cbRoll
            // 
            this.cbRoll.AutoSize = true;
            this.cbRoll.Location = new System.Drawing.Point(823, 41);
            this.cbRoll.Name = "cbRoll";
            this.cbRoll.Size = new System.Drawing.Size(48, 19);
            this.cbRoll.TabIndex = 11466;
            this.cbRoll.Text = "Roll";
            this.cbRoll.UseVisualStyleBackColor = true;
            // 
            // cmbRoll
            // 
            this.cmbRoll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoll.FormattingEnabled = true;
            this.cmbRoll.Location = new System.Drawing.Point(885, 38);
            this.cmbRoll.Name = "cmbRoll";
            this.cmbRoll.Size = new System.Drawing.Size(255, 23);
            this.cmbRoll.TabIndex = 11465;
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
            this.cmbYear.Location = new System.Drawing.Point(604, 34);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(100, 23);
            this.cmbYear.TabIndex = 11463;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(572, 38);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(30, 15);
            this.lblYear.TabIndex = 11462;
            this.lblYear.Text = "Year";
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
            this.cmbMonth.Location = new System.Drawing.Point(465, 34);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(100, 23);
            this.cmbMonth.TabIndex = 11461;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(420, 38);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(43, 15);
            this.lblMonth.TabIndex = 11460;
            this.lblMonth.Text = "Month";
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1231, 30);
            this.lblHeader.TabIndex = 11445;
            this.lblHeader.Text = "Database";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbStatusAll
            // 
            this.cbStatusAll.AutoSize = true;
            this.cbStatusAll.Location = new System.Drawing.Point(823, 66);
            this.cbStatusAll.Name = "cbStatusAll";
            this.cbStatusAll.Size = new System.Drawing.Size(60, 19);
            this.cbStatusAll.TabIndex = 11468;
            this.cbStatusAll.Text = "Status";
            this.cbStatusAll.UseVisualStyleBackColor = true;
            // 
            // cbSelectAllLocation
            // 
            this.cbSelectAllLocation.AutoSize = true;
            this.cbSelectAllLocation.Location = new System.Drawing.Point(7, 36);
            this.cbSelectAllLocation.Name = "cbSelectAllLocation";
            this.cbSelectAllLocation.Size = new System.Drawing.Size(72, 19);
            this.cbSelectAllLocation.TabIndex = 11459;
            this.cbSelectAllLocation.Text = "Location";
            this.cbSelectAllLocation.UseVisualStyleBackColor = true;
            this.cbSelectAllLocation.CheckedChanged += new System.EventHandler(this.cbSelectAllLocation_CheckedChanged);
            // 
            // cbSelectAllDepartment
            // 
            this.cbSelectAllDepartment.AutoSize = true;
            this.cbSelectAllDepartment.Location = new System.Drawing.Point(7, 59);
            this.cbSelectAllDepartment.Name = "cbSelectAllDepartment";
            this.cbSelectAllDepartment.Size = new System.Drawing.Size(90, 19);
            this.cbSelectAllDepartment.TabIndex = 11458;
            this.cbSelectAllDepartment.Text = "Department";
            this.cbSelectAllDepartment.UseVisualStyleBackColor = true;
            this.cbSelectAllDepartment.CheckedChanged += new System.EventHandler(this.cbSelectAllDepartment_CheckedChanged);
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(105, 58);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(251, 23);
            this.cmbDepartment.TabIndex = 11457;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(105, 34);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(251, 23);
            this.cmbLocation.TabIndex = 11456;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // btnReport
            // 
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Location = new System.Drawing.Point(841, 110);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 30);
            this.btnReport.TabIndex = 11449;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
            // 
            // btnView
            // 
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnView.Location = new System.Drawing.Point(981, 110);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 30);
            this.btnView.TabIndex = 11448;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(1142, 110);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11447;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(1062, 110);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11446;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(14, 129);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11451;
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
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmEmployeeId,
            this.clmLocation,
            this.clmDepartment,
            this.clmRoll,
            this.clmEmployeeCode,
            this.clmEmployeeName,
            this.clm1,
            this.clm2,
            this.clm3,
            this.clm4,
            this.clm5,
            this.clm6,
            this.clm7,
            this.clm8,
            this.clm9,
            this.clm10,
            this.clm11,
            this.clm12,
            this.clm13,
            this.clm14,
            this.clm15,
            this.clm16,
            this.clm17,
            this.clm18,
            this.clm19,
            this.clm20,
            this.clm21,
            this.clm22,
            this.clm23,
            this.clm24,
            this.clm25,
            this.clm26,
            this.clm27,
            this.clm28,
            this.clm29,
            this.clm30,
            this.clm31,
            this.clmTotalOT,
            this.clmTotalOTDays});
            this.dataGridView1.Location = new System.Drawing.Point(12, 147);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1205, 547);
            this.dataGridView1.TabIndex = 11450;
            // 
            // clmEmployeeId
            // 
            this.clmEmployeeId.HeaderText = "Employee Id";
            this.clmEmployeeId.Name = "clmEmployeeId";
            this.clmEmployeeId.ReadOnly = true;
            this.clmEmployeeId.Visible = false;
            // 
            // clmLocation
            // 
            this.clmLocation.HeaderText = "Location";
            this.clmLocation.Name = "clmLocation";
            this.clmLocation.ReadOnly = true;
            // 
            // clmDepartment
            // 
            this.clmDepartment.HeaderText = "Department";
            this.clmDepartment.Name = "clmDepartment";
            this.clmDepartment.ReadOnly = true;
            // 
            // clmRoll
            // 
            this.clmRoll.HeaderText = "Roll";
            this.clmRoll.Name = "clmRoll";
            this.clmRoll.ReadOnly = true;
            // 
            // clmEmployeeCode
            // 
            this.clmEmployeeCode.HeaderText = "Employee Code";
            this.clmEmployeeCode.Name = "clmEmployeeCode";
            this.clmEmployeeCode.ReadOnly = true;
            this.clmEmployeeCode.Width = 80;
            // 
            // clmEmployeeName
            // 
            this.clmEmployeeName.HeaderText = "Employee Name";
            this.clmEmployeeName.Name = "clmEmployeeName";
            this.clmEmployeeName.ReadOnly = true;
            this.clmEmployeeName.Width = 250;
            // 
            // clm1
            // 
            this.clm1.HeaderText = "1";
            this.clm1.Name = "clm1";
            this.clm1.ReadOnly = true;
            this.clm1.Width = 60;
            // 
            // clm2
            // 
            this.clm2.HeaderText = "2";
            this.clm2.Name = "clm2";
            this.clm2.ReadOnly = true;
            // 
            // clm3
            // 
            this.clm3.HeaderText = "3";
            this.clm3.Name = "clm3";
            this.clm3.ReadOnly = true;
            // 
            // clm4
            // 
            this.clm4.HeaderText = "4";
            this.clm4.Name = "clm4";
            this.clm4.ReadOnly = true;
            // 
            // clm5
            // 
            this.clm5.HeaderText = "5";
            this.clm5.Name = "clm5";
            this.clm5.ReadOnly = true;
            // 
            // clm6
            // 
            this.clm6.HeaderText = "6";
            this.clm6.Name = "clm6";
            this.clm6.ReadOnly = true;
            // 
            // clm7
            // 
            this.clm7.HeaderText = "7";
            this.clm7.Name = "clm7";
            this.clm7.ReadOnly = true;
            // 
            // clm8
            // 
            this.clm8.HeaderText = "8";
            this.clm8.Name = "clm8";
            this.clm8.ReadOnly = true;
            // 
            // clm9
            // 
            this.clm9.HeaderText = "9";
            this.clm9.Name = "clm9";
            this.clm9.ReadOnly = true;
            // 
            // clm10
            // 
            this.clm10.HeaderText = "10";
            this.clm10.Name = "clm10";
            this.clm10.ReadOnly = true;
            // 
            // clm11
            // 
            this.clm11.HeaderText = "11";
            this.clm11.Name = "clm11";
            this.clm11.ReadOnly = true;
            // 
            // clm12
            // 
            this.clm12.HeaderText = "12";
            this.clm12.Name = "clm12";
            this.clm12.ReadOnly = true;
            // 
            // clm13
            // 
            this.clm13.HeaderText = "13";
            this.clm13.Name = "clm13";
            this.clm13.ReadOnly = true;
            // 
            // clm14
            // 
            this.clm14.HeaderText = "14";
            this.clm14.Name = "clm14";
            this.clm14.ReadOnly = true;
            // 
            // clm15
            // 
            this.clm15.HeaderText = "15";
            this.clm15.Name = "clm15";
            this.clm15.ReadOnly = true;
            // 
            // clm16
            // 
            this.clm16.HeaderText = "16";
            this.clm16.Name = "clm16";
            this.clm16.ReadOnly = true;
            // 
            // clm17
            // 
            this.clm17.HeaderText = "17";
            this.clm17.Name = "clm17";
            this.clm17.ReadOnly = true;
            // 
            // clm18
            // 
            this.clm18.HeaderText = "18";
            this.clm18.Name = "clm18";
            this.clm18.ReadOnly = true;
            // 
            // clm19
            // 
            this.clm19.HeaderText = "19";
            this.clm19.Name = "clm19";
            this.clm19.ReadOnly = true;
            // 
            // clm20
            // 
            this.clm20.HeaderText = "20";
            this.clm20.Name = "clm20";
            this.clm20.ReadOnly = true;
            // 
            // clm21
            // 
            this.clm21.HeaderText = "21";
            this.clm21.Name = "clm21";
            this.clm21.ReadOnly = true;
            // 
            // clm22
            // 
            this.clm22.HeaderText = "22";
            this.clm22.Name = "clm22";
            this.clm22.ReadOnly = true;
            // 
            // clm23
            // 
            this.clm23.HeaderText = "23";
            this.clm23.Name = "clm23";
            this.clm23.ReadOnly = true;
            // 
            // clm24
            // 
            this.clm24.HeaderText = "24";
            this.clm24.Name = "clm24";
            this.clm24.ReadOnly = true;
            // 
            // clm25
            // 
            this.clm25.HeaderText = "25";
            this.clm25.Name = "clm25";
            this.clm25.ReadOnly = true;
            // 
            // clm26
            // 
            this.clm26.HeaderText = "26";
            this.clm26.Name = "clm26";
            this.clm26.ReadOnly = true;
            // 
            // clm27
            // 
            this.clm27.HeaderText = "27";
            this.clm27.Name = "clm27";
            this.clm27.ReadOnly = true;
            // 
            // clm28
            // 
            this.clm28.HeaderText = "28";
            this.clm28.Name = "clm28";
            this.clm28.ReadOnly = true;
            // 
            // clm29
            // 
            this.clm29.HeaderText = "29";
            this.clm29.Name = "clm29";
            this.clm29.ReadOnly = true;
            // 
            // clm30
            // 
            this.clm30.HeaderText = "30";
            this.clm30.Name = "clm30";
            this.clm30.ReadOnly = true;
            // 
            // clm31
            // 
            this.clm31.HeaderText = "31";
            this.clm31.Name = "clm31";
            this.clm31.ReadOnly = true;
            // 
            // clmTotalOT
            // 
            this.clmTotalOT.HeaderText = "Total OT";
            this.clmTotalOT.Name = "clmTotalOT";
            this.clmTotalOT.ReadOnly = true;
            // 
            // clmTotalOTDays
            // 
            this.clmTotalOTDays.HeaderText = "Total OT Days";
            this.clmTotalOTDays.Name = "clmTotalOTDays";
            this.clmTotalOTDays.ReadOnly = true;
            // 
            // OTReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1231, 698);
            this.ControlBox = false;
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.cbRoll);
            this.Controls.Add(this.cmbRoll);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.cbStatusAll);
            this.Controls.Add(this.cbSelectAllLocation);
            this.Controls.Add(this.cbSelectAllDepartment);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "OTReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.OTReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.CheckBox cbRoll;
        private System.Windows.Forms.ComboBox cmbRoll;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.CheckBox cbStatusAll;
        private System.Windows.Forms.CheckBox cbSelectAllLocation;
        private System.Windows.Forms.CheckBox cbSelectAllDepartment;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRoll;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm5;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm6;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm7;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm8;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm9;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm10;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm11;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm12;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm13;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm14;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm15;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm16;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm17;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm18;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm19;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm20;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm21;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm22;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm23;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm24;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm25;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm26;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm27;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm28;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm29;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm30;
        private System.Windows.Forms.DataGridViewTextBoxColumn clm31;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalOT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotalOTDays;
    }
}