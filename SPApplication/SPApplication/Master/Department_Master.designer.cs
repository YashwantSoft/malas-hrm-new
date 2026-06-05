namespace SPApplication.HR
{
    partial class Department_Master
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtMobileNumber = new System.Windows.Forms.TextBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.txtExtensionNo = new System.Windows.Forms.TextBox();
            this.txtHODName = new System.Windows.Forms.TextBox();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.txtDepartmentID = new System.Windows.Forms.TextBox();
            this.lbDescription = new System.Windows.Forms.Label();
            this.lbMobileNumber = new System.Windows.Forms.Label();
            this.lbContactPerson = new System.Windows.Forms.Label();
            this.lbExtensionNo = new System.Windows.Forms.Label();
            this.lbLocation = new System.Windows.Forms.Label();
            this.lbHODName = new System.Windows.Forms.Label();
            this.lbDepartmentName = new System.Windows.Forms.Label();
            this.lbDepartmentID = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddLoaction = new System.Windows.Forms.Button();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 320);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(583, 266);
            this.dataGridView1.TabIndex = 13;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(225, 259);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 9;
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
            this.btnSave.Location = new System.Drawing.Point(142, 259);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMobileNumber
            // 
            this.txtMobileNumber.Location = new System.Drawing.Point(240, 152);
            this.txtMobileNumber.Name = "txtMobileNumber";
            this.txtMobileNumber.Size = new System.Drawing.Size(226, 23);
            this.txtMobileNumber.TabIndex = 6;
            this.txtMobileNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobileNumber_KeyDown);
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(240, 128);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(226, 23);
            this.txtContactPerson.TabIndex = 4;
            this.txtContactPerson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContactPerson_KeyDown);
            // 
            // txtExtensionNo
            // 
            this.txtExtensionNo.Location = new System.Drawing.Point(240, 200);
            this.txtExtensionNo.Name = "txtExtensionNo";
            this.txtExtensionNo.Size = new System.Drawing.Size(60, 23);
            this.txtExtensionNo.TabIndex = 5;
            this.txtExtensionNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExtensionNo_KeyDown);
            // 
            // txtHODName
            // 
            this.txtHODName.Location = new System.Drawing.Point(240, 104);
            this.txtHODName.Name = "txtHODName";
            this.txtHODName.Size = new System.Drawing.Size(226, 23);
            this.txtHODName.TabIndex = 3;
            this.txtHODName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHODName_KeyDown);
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(240, 80);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(226, 23);
            this.txtDepartmentName.TabIndex = 1;
            this.txtDepartmentName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDepartmentName_KeyDown);
            // 
            // txtDepartmentID
            // 
            this.txtDepartmentID.Location = new System.Drawing.Point(240, 32);
            this.txtDepartmentID.Name = "txtDepartmentID";
            this.txtDepartmentID.Size = new System.Drawing.Size(60, 23);
            this.txtDepartmentID.TabIndex = 0;
            this.txtDepartmentID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDepartmentID_KeyDown);
            // 
            // lbDescription
            // 
            this.lbDescription.AutoSize = true;
            this.lbDescription.Location = new System.Drawing.Point(131, 229);
            this.lbDescription.Name = "lbDescription";
            this.lbDescription.Size = new System.Drawing.Size(70, 15);
            this.lbDescription.TabIndex = 28;
            this.lbDescription.Text = "Description";
            // 
            // lbMobileNumber
            // 
            this.lbMobileNumber.AutoSize = true;
            this.lbMobileNumber.Location = new System.Drawing.Point(131, 156);
            this.lbMobileNumber.Name = "lbMobileNumber";
            this.lbMobileNumber.Size = new System.Drawing.Size(92, 15);
            this.lbMobileNumber.TabIndex = 27;
            this.lbMobileNumber.Text = "Mobile Number";
            // 
            // lbContactPerson
            // 
            this.lbContactPerson.AutoSize = true;
            this.lbContactPerson.Location = new System.Drawing.Point(131, 132);
            this.lbContactPerson.Name = "lbContactPerson";
            this.lbContactPerson.Size = new System.Drawing.Size(90, 15);
            this.lbContactPerson.TabIndex = 26;
            this.lbContactPerson.Text = "Contact Person";
            // 
            // lbExtensionNo
            // 
            this.lbExtensionNo.AutoSize = true;
            this.lbExtensionNo.Location = new System.Drawing.Point(131, 204);
            this.lbExtensionNo.Name = "lbExtensionNo";
            this.lbExtensionNo.Size = new System.Drawing.Size(78, 15);
            this.lbExtensionNo.TabIndex = 25;
            this.lbExtensionNo.Text = "Extension No";
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Location = new System.Drawing.Point(131, 60);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(53, 15);
            this.lbLocation.TabIndex = 24;
            this.lbLocation.Text = "Location";
            // 
            // lbHODName
            // 
            this.lbHODName.AutoSize = true;
            this.lbHODName.Location = new System.Drawing.Point(131, 108);
            this.lbHODName.Name = "lbHODName";
            this.lbHODName.Size = new System.Drawing.Size(89, 15);
            this.lbHODName.TabIndex = 23;
            this.lbHODName.Text = "Incharge Name";
            // 
            // lbDepartmentName
            // 
            this.lbDepartmentName.AutoSize = true;
            this.lbDepartmentName.Location = new System.Drawing.Point(131, 84);
            this.lbDepartmentName.Name = "lbDepartmentName";
            this.lbDepartmentName.Size = new System.Drawing.Size(105, 15);
            this.lbDepartmentName.TabIndex = 22;
            this.lbDepartmentName.Text = "Department Name";
            this.lbDepartmentName.Click += new System.EventHandler(this.lbDepartmentName_Click);
            // 
            // lbDepartmentID
            // 
            this.lbDepartmentID.AutoSize = true;
            this.lbDepartmentID.Location = new System.Drawing.Point(131, 36);
            this.lbDepartmentID.Name = "lbDepartmentID";
            this.lbDepartmentID.Size = new System.Drawing.Size(86, 15);
            this.lbDepartmentID.TabIndex = 21;
            this.lbDepartmentID.Text = "Department ID";
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-2, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(600, 30);
            this.lblHeader.TabIndex = 20;
            this.lblHeader.Text = "Department Master";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbLocation
            // 
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Items.AddRange(new object[] {
            "pune ",
            "mumbai"});
            this.cmbLocation.Location = new System.Drawing.Point(240, 56);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(226, 23);
            this.cmbLocation.TabIndex = 2;
            this.cmbLocation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbLocation_KeyDown);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(240, 224);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(226, 23);
            this.txtDescription.TabIndex = 7;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(308, 259);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(391, 259);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddLoaction
            // 
            this.btnAddLoaction.BackColor = System.Drawing.Color.Blue;
            this.btnAddLoaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddLoaction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddLoaction.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLoaction.ForeColor = System.Drawing.Color.White;
            this.btnAddLoaction.Location = new System.Drawing.Point(468, 59);
            this.btnAddLoaction.Name = "btnAddLoaction";
            this.btnAddLoaction.Size = new System.Drawing.Size(20, 20);
            this.btnAddLoaction.TabIndex = 211;
            this.btnAddLoaction.Text = "+";
            this.btnAddLoaction.UseVisualStyleBackColor = false;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(17, 301);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 212;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(119, 301);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 213;
            this.lbSearch.Text = "Search ";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(171, 294);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 23);
            this.txtSearch.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(240, 176);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(226, 23);
            this.textBox1.TabIndex = 214;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 215;
            this.label2.Text = "Email Id";
            // 
            // Department_Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 598);
            this.ControlBox = false;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnAddLoaction);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtMobileNumber);
            this.Controls.Add(this.txtContactPerson);
            this.Controls.Add(this.txtExtensionNo);
            this.Controls.Add(this.txtHODName);
            this.Controls.Add(this.txtDepartmentName);
            this.Controls.Add(this.txtDepartmentID);
            this.Controls.Add(this.lbDescription);
            this.Controls.Add(this.lbMobileNumber);
            this.Controls.Add(this.lbContactPerson);
            this.Controls.Add(this.lbExtensionNo);
            this.Controls.Add(this.lbLocation);
            this.Controls.Add(this.lbHODName);
            this.Controls.Add(this.lbDepartmentName);
            this.Controls.Add(this.lbDepartmentID);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Department_Master";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtMobileNumber;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.TextBox txtExtensionNo;
        private System.Windows.Forms.TextBox txtHODName;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.TextBox txtDepartmentID;
        private System.Windows.Forms.Label lbDescription;
        private System.Windows.Forms.Label lbMobileNumber;
        private System.Windows.Forms.Label lbContactPerson;
        private System.Windows.Forms.Label lbExtensionNo;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Label lbHODName;
        private System.Windows.Forms.Label lbDepartmentName;
        private System.Windows.Forms.Label lbDepartmentID;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddLoaction;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
    }
}