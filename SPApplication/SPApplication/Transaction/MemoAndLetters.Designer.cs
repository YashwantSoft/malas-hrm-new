namespace SPApplication.Transaction
{
    partial class MemoAndLetters
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbMemoSubject = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddMemo = new System.Windows.Forms.Button();
            this.dtpEntryDate = new System.Windows.Forms.DateTimePicker();
            this.lbMarriageDate = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lbPlaceOfPosting = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dtpEntryTime = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDesignation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEmployeeName = new System.Windows.Forms.ComboBox();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDepartmentName = new System.Windows.Forms.Label();
            this.txtFine = new System.Windows.Forms.TextBox();
            this.lblFine = new System.Windows.Forms.Label();
            this.dgvMemo = new System.Windows.Forms.DataGridView();
            this.clmMemoTemplateId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMemoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rtbTemplate = new System.Windows.Forms.RichTextBox();
            this.txtCTCMonthly = new System.Windows.Forms.TextBox();
            this.txtCTCYearly = new System.Windows.Forms.TextBox();
            this.lblCTCMonthly = new System.Windows.Forms.Label();
            this.lblCTCYearly = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Blue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1202, 30);
            this.lblHeader.TabIndex = 11195;
            this.lblHeader.Text = "Asset Data";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(886, 361);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(289, 23);
            this.txtSearch.TabIndex = 11449;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(837, 365);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 11452;
            this.lbSearch.Text = "Search ";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(20, 376);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11451;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(650, 356);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11448;
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
            this.btnDelete.Location = new System.Drawing.Point(570, 356);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11447;
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
            this.btnClear.Location = new System.Drawing.Point(490, 356);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11446;
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
            this.btnSave.Location = new System.Drawing.Point(410, 356);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11445;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbMemoSubject
            // 
            this.cmbMemoSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMemoSubject.FormattingEnabled = true;
            this.cmbMemoSubject.Location = new System.Drawing.Point(563, 36);
            this.cmbMemoSubject.Name = "cmbMemoSubject";
            this.cmbMemoSubject.Size = new System.Drawing.Size(591, 23);
            this.cmbMemoSubject.TabIndex = 11454;
            this.cmbMemoSubject.SelectionChangeCommitted += new System.EventHandler(this.cmbMemoSubject_SelectionChangeCommitted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(505, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 15);
            this.label9.TabIndex = 11455;
            this.label9.Text = "Subject";
            // 
            // btnAddMemo
            // 
            this.btnAddMemo.BackColor = System.Drawing.Color.Blue;
            this.btnAddMemo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddMemo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddMemo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMemo.ForeColor = System.Drawing.Color.White;
            this.btnAddMemo.Location = new System.Drawing.Point(1168, 35);
            this.btnAddMemo.Name = "btnAddMemo";
            this.btnAddMemo.Size = new System.Drawing.Size(20, 20);
            this.btnAddMemo.TabIndex = 11456;
            this.btnAddMemo.Text = "+";
            this.btnAddMemo.UseVisualStyleBackColor = false;
            this.btnAddMemo.Click += new System.EventHandler(this.btnAddMemo_Click);
            // 
            // dtpEntryDate
            // 
            this.dtpEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEntryDate.Location = new System.Drawing.Point(102, 34);
            this.dtpEntryDate.Name = "dtpEntryDate";
            this.dtpEntryDate.Size = new System.Drawing.Size(100, 23);
            this.dtpEntryDate.TabIndex = 11457;
            // 
            // lbMarriageDate
            // 
            this.lbMarriageDate.AutoSize = true;
            this.lbMarriageDate.Location = new System.Drawing.Point(7, 39);
            this.lbMarriageDate.Name = "lbMarriageDate";
            this.lbMarriageDate.Size = new System.Drawing.Size(32, 15);
            this.lbMarriageDate.TabIndex = 11458;
            this.lbMarriageDate.Text = "Date";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(102, 59);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(394, 23);
            this.cmbLocation.TabIndex = 11459;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // lbPlaceOfPosting
            // 
            this.lbPlaceOfPosting.AutoSize = true;
            this.lbPlaceOfPosting.Location = new System.Drawing.Point(7, 63);
            this.lbPlaceOfPosting.Name = "lbPlaceOfPosting";
            this.lbPlaceOfPosting.Size = new System.Drawing.Size(53, 15);
            this.lbPlaceOfPosting.TabIndex = 11460;
            this.lbPlaceOfPosting.Text = "Location";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(505, 66);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 15);
            this.label20.TabIndex = 11462;
            this.label20.Text = "Template";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(730, 356);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 30);
            this.btnPrint.TabIndex = 11463;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 390);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1165, 302);
            this.dataGridView1.TabIndex = 11464;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // dtpEntryTime
            // 
            this.dtpEntryTime.CustomFormat = "HH:mm";
            this.dtpEntryTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEntryTime.Location = new System.Drawing.Point(276, 34);
            this.dtpEntryTime.Name = "dtpEntryTime";
            this.dtpEntryTime.Size = new System.Drawing.Size(100, 23);
            this.dtpEntryTime.TabIndex = 11465;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(241, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 15);
            this.label7.TabIndex = 11466;
            this.label7.Text = "Time";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(102, 83);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(394, 23);
            this.cmbDepartment.TabIndex = 11476;
            this.cmbDepartment.SelectionChangeCommitted += new System.EventHandler(this.cmbDepartment_SelectionChangeCommitted);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 15);
            this.label8.TabIndex = 11475;
            this.label8.Text = "Department";
            // 
            // txtDesignation
            // 
            this.txtDesignation.Location = new System.Drawing.Point(276, 131);
            this.txtDesignation.Name = "txtDesignation";
            this.txtDesignation.ReadOnly = true;
            this.txtDesignation.Size = new System.Drawing.Size(220, 23);
            this.txtDesignation.TabIndex = 11471;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 11472;
            this.label1.Text = "Designation";
            // 
            // cmbEmployeeName
            // 
            this.cmbEmployeeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployeeName.FormattingEnabled = true;
            this.cmbEmployeeName.Location = new System.Drawing.Point(102, 107);
            this.cmbEmployeeName.Name = "cmbEmployeeName";
            this.cmbEmployeeName.Size = new System.Drawing.Size(394, 23);
            this.cmbEmployeeName.TabIndex = 11470;
            this.cmbEmployeeName.SelectionChangeCommitted += new System.EventHandler(this.cmbEmployeeName_SelectionChangeCommitted);
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(102, 131);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.ReadOnly = true;
            this.txtEmployeeCode.Size = new System.Drawing.Size(73, 23);
            this.txtEmployeeCode.TabIndex = 11468;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 11469;
            this.label2.Text = "Employee Code";
            // 
            // lbDepartmentName
            // 
            this.lbDepartmentName.AutoSize = true;
            this.lbDepartmentName.Location = new System.Drawing.Point(7, 111);
            this.lbDepartmentName.Name = "lbDepartmentName";
            this.lbDepartmentName.Size = new System.Drawing.Size(93, 15);
            this.lbDepartmentName.TabIndex = 11467;
            this.lbDepartmentName.Text = "Employee Name";
            // 
            // txtFine
            // 
            this.txtFine.Location = new System.Drawing.Point(102, 156);
            this.txtFine.MaxLength = 5;
            this.txtFine.Name = "txtFine";
            this.txtFine.Size = new System.Drawing.Size(73, 23);
            this.txtFine.TabIndex = 11477;
            this.txtFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFine.Visible = false;
            this.txtFine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFine_KeyPress);
            // 
            // lblFine
            // 
            this.lblFine.AutoSize = true;
            this.lblFine.Location = new System.Drawing.Point(7, 158);
            this.lblFine.Name = "lblFine";
            this.lblFine.Size = new System.Drawing.Size(49, 15);
            this.lblFine.TabIndex = 11478;
            this.lblFine.Text = "Fine Rs.";
            this.lblFine.Visible = false;
            // 
            // dgvMemo
            // 
            this.dgvMemo.AllowUserToAddRows = false;
            this.dgvMemo.AllowUserToDeleteRows = false;
            this.dgvMemo.AllowUserToResizeRows = false;
            this.dgvMemo.BackgroundColor = System.Drawing.Color.White;
            this.dgvMemo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMemo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMemoTemplateId,
            this.clmMemoName,
            this.clmCount});
            this.dgvMemo.Location = new System.Drawing.Point(10, 185);
            this.dgvMemo.Name = "dgvMemo";
            this.dgvMemo.ReadOnly = true;
            this.dgvMemo.RowHeadersVisible = false;
            this.dgvMemo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMemo.Size = new System.Drawing.Size(533, 165);
            this.dgvMemo.TabIndex = 11479;
            this.dgvMemo.TabStop = false;
            // 
            // clmMemoTemplateId
            // 
            this.clmMemoTemplateId.HeaderText = "Template Id";
            this.clmMemoTemplateId.Name = "clmMemoTemplateId";
            this.clmMemoTemplateId.ReadOnly = true;
            this.clmMemoTemplateId.Visible = false;
            // 
            // clmMemoName
            // 
            this.clmMemoName.HeaderText = "Memo Name";
            this.clmMemoName.Name = "clmMemoName";
            this.clmMemoName.ReadOnly = true;
            this.clmMemoName.Width = 450;
            // 
            // clmCount
            // 
            this.clmCount.HeaderText = "Count";
            this.clmCount.Name = "clmCount";
            this.clmCount.ReadOnly = true;
            this.clmCount.Width = 50;
            // 
            // rtbTemplate
            // 
            this.rtbTemplate.BackColor = System.Drawing.Color.White;
            this.rtbTemplate.Location = new System.Drawing.Point(563, 62);
            this.rtbTemplate.Name = "rtbTemplate";
            this.rtbTemplate.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtbTemplate.Size = new System.Drawing.Size(625, 288);
            this.rtbTemplate.TabIndex = 11480;
            this.rtbTemplate.Text = "";
            // 
            // txtCTCMonthly
            // 
            this.txtCTCMonthly.Location = new System.Drawing.Point(276, 155);
            this.txtCTCMonthly.Name = "txtCTCMonthly";
            this.txtCTCMonthly.ReadOnly = true;
            this.txtCTCMonthly.Size = new System.Drawing.Size(66, 23);
            this.txtCTCMonthly.TabIndex = 11481;
            this.txtCTCMonthly.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCTCMonthly.Visible = false;
            // 
            // txtCTCYearly
            // 
            this.txtCTCYearly.Location = new System.Drawing.Point(390, 155);
            this.txtCTCYearly.Name = "txtCTCYearly";
            this.txtCTCYearly.ReadOnly = true;
            this.txtCTCYearly.Size = new System.Drawing.Size(106, 23);
            this.txtCTCYearly.TabIndex = 11482;
            this.txtCTCYearly.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCTCYearly.Visible = false;
            // 
            // lblCTCMonthly
            // 
            this.lblCTCMonthly.AutoSize = true;
            this.lblCTCMonthly.Location = new System.Drawing.Point(186, 159);
            this.lblCTCMonthly.Name = "lblCTCMonthly";
            this.lblCTCMonthly.Size = new System.Drawing.Size(76, 15);
            this.lblCTCMonthly.TabIndex = 11483;
            this.lblCTCMonthly.Text = "CTC Monthly";
            this.lblCTCMonthly.Visible = false;
            // 
            // lblCTCYearly
            // 
            this.lblCTCYearly.AutoSize = true;
            this.lblCTCYearly.Location = new System.Drawing.Point(347, 159);
            this.lblCTCYearly.Name = "lblCTCYearly";
            this.lblCTCYearly.Size = new System.Drawing.Size(40, 15);
            this.lblCTCYearly.TabIndex = 11484;
            this.lblCTCYearly.Text = "Yearly";
            this.lblCTCYearly.Visible = false;
            // 
            // MemoAndLetters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1201, 696);
            this.ControlBox = false;
            this.Controls.Add(this.lblCTCYearly);
            this.Controls.Add(this.lblCTCMonthly);
            this.Controls.Add(this.txtCTCYearly);
            this.Controls.Add(this.txtCTCMonthly);
            this.Controls.Add(this.rtbTemplate);
            this.Controls.Add(this.dgvMemo);
            this.Controls.Add(this.txtFine);
            this.Controls.Add(this.lblFine);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDesignation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEmployeeName);
            this.Controls.Add(this.txtEmployeeCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbDepartmentName);
            this.Controls.Add(this.dtpEntryTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lbPlaceOfPosting);
            this.Controls.Add(this.dtpEntryDate);
            this.Controls.Add(this.lbMarriageDate);
            this.Controls.Add(this.btnAddMemo);
            this.Controls.Add(this.cmbMemoSubject);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MemoAndLetters";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MemoInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbMemoSubject;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAddMemo;
        private System.Windows.Forms.DateTimePicker dtpEntryDate;
        private System.Windows.Forms.Label lbMarriageDate;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lbPlaceOfPosting;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dtpEntryTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDesignation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbDepartmentName;
        private System.Windows.Forms.TextBox txtFine;
        private System.Windows.Forms.Label lblFine;
        private System.Windows.Forms.DataGridView dgvMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMemoTemplateId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMemoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCount;
        private System.Windows.Forms.RichTextBox rtbTemplate;
        private System.Windows.Forms.TextBox txtCTCMonthly;
        private System.Windows.Forms.TextBox txtCTCYearly;
        private System.Windows.Forms.Label lblCTCMonthly;
        private System.Windows.Forms.Label lblCTCYearly;
    }
}