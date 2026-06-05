namespace SPApplication.Master
{
    partial class EmployeeEditMaster
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
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbShiftGroup = new System.Windows.Forms.ComboBox();
            this.lbReportingTo = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbJobProfile = new System.Windows.Forms.ComboBox();
            this.lbJobProfile = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblSearchFor = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbDesignation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.txtSearchCode = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.cmbContractor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1243, 30);
            this.lblHeader.TabIndex = 267;
            this.lblHeader.Text = "Asset Master";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCount.Location = new System.Drawing.Point(12, 659);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(93, 19);
            this.lblTotalCount.TabIndex = 275;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1221, 566);
            this.dataGridView1.TabIndex = 274;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // cmbShiftGroup
            // 
            this.cmbShiftGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShiftGroup.FormattingEnabled = true;
            this.cmbShiftGroup.Location = new System.Drawing.Point(78, 58);
            this.cmbShiftGroup.Name = "cmbShiftGroup";
            this.cmbShiftGroup.Size = new System.Drawing.Size(130, 23);
            this.cmbShiftGroup.TabIndex = 381;
            this.cmbShiftGroup.SelectionChangeCommitted += new System.EventHandler(this.Fill_Combo_Event);
            // 
            // lbReportingTo
            // 
            this.lbReportingTo.AutoSize = true;
            this.lbReportingTo.Location = new System.Drawing.Point(7, 62);
            this.lbReportingTo.Name = "lbReportingTo";
            this.lbReportingTo.Size = new System.Drawing.Size(69, 15);
            this.lbReportingTo.TabIndex = 387;
            this.lbReportingTo.Text = "Shift Group";
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(78, 34);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(130, 23);
            this.cmbLocation.TabIndex = 376;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.Fill_Combo_Event);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 15);
            this.label6.TabIndex = 386;
            this.label6.Text = "Location";
            // 
            // cmbJobProfile
            // 
            this.cmbJobProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJobProfile.FormattingEnabled = true;
            this.cmbJobProfile.Location = new System.Drawing.Point(284, 57);
            this.cmbJobProfile.Name = "cmbJobProfile";
            this.cmbJobProfile.Size = new System.Drawing.Size(130, 23);
            this.cmbJobProfile.TabIndex = 379;
            this.cmbJobProfile.SelectionChangeCommitted += new System.EventHandler(this.Fill_Combo_Event);
            // 
            // lbJobProfile
            // 
            this.lbJobProfile.AutoSize = true;
            this.lbJobProfile.Location = new System.Drawing.Point(211, 61);
            this.lbJobProfile.Name = "lbJobProfile";
            this.lbJobProfile.Size = new System.Drawing.Size(64, 15);
            this.lbJobProfile.TabIndex = 384;
            this.lbJobProfile.Text = "Job Profile";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(284, 33);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(130, 23);
            this.cmbDepartment.TabIndex = 377;
            this.cmbDepartment.SelectionChangeCommitted += new System.EventHandler(this.Fill_Combo_Event);
            // 
            // lblSearchFor
            // 
            this.lblSearchFor.AutoSize = true;
            this.lblSearchFor.Location = new System.Drawing.Point(211, 36);
            this.lblSearchFor.Name = "lblSearchFor";
            this.lblSearchFor.Size = new System.Drawing.Size(71, 15);
            this.lblSearchFor.TabIndex = 383;
            this.lblSearchFor.Text = "Department";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1156, 657);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 395;
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
            this.btnDelete.Location = new System.Drawing.Point(970, 658);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 394;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1077, 658);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 393;
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
            this.btnSave.Location = new System.Drawing.Point(889, 659);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 392;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            // 
            // cmbDesignation
            // 
            this.cmbDesignation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDesignation.FormattingEnabled = true;
            this.cmbDesignation.Location = new System.Drawing.Point(496, 33);
            this.cmbDesignation.Name = "cmbDesignation";
            this.cmbDesignation.Size = new System.Drawing.Size(130, 23);
            this.cmbDesignation.TabIndex = 396;
            this.cmbDesignation.SelectionChangeCommitted += new System.EventHandler(this.Fill_Combo_Event);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(422, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 397;
            this.label1.Text = "Designation";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(894, 34);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(130, 23);
            this.cmbCategory.TabIndex = 398;
            this.cmbCategory.SelectionChangeCommitted += new System.EventHandler(this.Fill_Combo_Event);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(837, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 399;
            this.label2.Text = "Category";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "All",
            "Working",
            "Resigned"});
            this.cmbStatus.Location = new System.Drawing.Point(1094, 34);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(130, 23);
            this.cmbStatus.TabIndex = 400;
            this.cmbStatus.SelectionChangeCommitted += new System.EventHandler(this.Fill_Combo_Event);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1029, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 401;
            this.label3.Text = "Status";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(496, 57);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(130, 23);
            this.cmbType.TabIndex = 402;
            this.cmbType.SelectionChangeCommitted += new System.EventHandler(this.Fill_Combo_Event);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 15);
            this.label4.TabIndex = 403;
            this.label4.Text = "Type";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(1029, 62);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(63, 15);
            this.label51.TabIndex = 407;
            this.label51.Text = "Emp. Code";
            // 
            // txtSearchCode
            // 
            this.txtSearchCode.Location = new System.Drawing.Point(1094, 58);
            this.txtSearchCode.Name = "txtSearchCode";
            this.txtSearchCode.Size = new System.Drawing.Size(130, 23);
            this.txtSearchCode.TabIndex = 406;
            this.txtSearchCode.TextChanged += new System.EventHandler(this.txtSearchCode_TextChanged);
            this.txtSearchCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchCode_KeyPress);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(894, 58);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(130, 23);
            this.txtSearch.TabIndex = 404;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(837, 61);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(44, 15);
            this.lbSearch.TabIndex = 405;
            this.lbSearch.Text = "Search";
            // 
            // cmbContractor
            // 
            this.cmbContractor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContractor.FormattingEnabled = true;
            this.cmbContractor.Location = new System.Drawing.Point(694, 34);
            this.cmbContractor.Name = "cmbContractor";
            this.cmbContractor.Size = new System.Drawing.Size(130, 23);
            this.cmbContractor.TabIndex = 408;
            this.cmbContractor.SelectionChangeCommitted += new System.EventHandler(this.Fill_Combo_Event);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(626, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 409;
            this.label5.Text = "Contractor";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(626, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 15);
            this.label8.TabIndex = 411;
            this.label8.Text = "Employee";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Items.AddRange(new object[] {
            "New",
            "All"});
            this.cmbEmployee.Location = new System.Drawing.Point(694, 58);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(130, 23);
            this.cmbEmployee.TabIndex = 410;
            this.cmbEmployee.SelectionChangeCommitted += new System.EventHandler(this.Fill_Combo_Event);
            // 
            // EmployeeEditMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1244, 693);
            this.ControlBox = false;
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbContractor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label51);
            this.Controls.Add(this.txtSearchCode);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDesignation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbShiftGroup);
            this.Controls.Add(this.lbReportingTo);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbJobProfile);
            this.Controls.Add(this.lbJobProfile);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblSearchFor);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EmployeeEditMaster";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EmployeeEditMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbShiftGroup;
        private System.Windows.Forms.Label lbReportingTo;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbJobProfile;
        private System.Windows.Forms.Label lbJobProfile;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblSearchFor;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbDesignation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox txtSearchCode;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.ComboBox cmbContractor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbEmployee;
    }
}