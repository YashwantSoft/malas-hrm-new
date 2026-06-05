namespace SPApplication.Master
{
    partial class TalukaMaster
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddState = new System.Windows.Forms.Button();
            this.cmbStateName = new System.Windows.Forms.ComboBox();
            this.btnAddContry = new System.Windows.Forms.Button();
            this.cmbContryName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.txtTalukaName = new System.Windows.Forms.TextBox();
            this.lbUdyogAadharNumber = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnAddDistrict = new System.Windows.Forms.Button();
            this.cmbDistrictName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 11291;
            this.label2.Text = "District Name";
            // 
            // btnAddState
            // 
            this.btnAddState.BackColor = System.Drawing.Color.Blue;
            this.btnAddState.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddState.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddState.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddState.ForeColor = System.Drawing.Color.White;
            this.btnAddState.Location = new System.Drawing.Point(511, 60);
            this.btnAddState.Name = "btnAddState";
            this.btnAddState.Size = new System.Drawing.Size(20, 20);
            this.btnAddState.TabIndex = 11290;
            this.btnAddState.Text = "+";
            this.btnAddState.UseVisualStyleBackColor = false;
            this.btnAddState.Click += new System.EventHandler(this.btnAddState_Click);
            // 
            // cmbStateName
            // 
            this.cmbStateName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStateName.FormattingEnabled = true;
            this.cmbStateName.Location = new System.Drawing.Point(142, 59);
            this.cmbStateName.Name = "cmbStateName";
            this.cmbStateName.Size = new System.Drawing.Size(363, 23);
            this.cmbStateName.TabIndex = 11276;
            this.cmbStateName.SelectionChangeCommitted += new System.EventHandler(this.cmbStateName_SelectionChangeCommitted);
            // 
            // btnAddContry
            // 
            this.btnAddContry.BackColor = System.Drawing.Color.Blue;
            this.btnAddContry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddContry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddContry.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddContry.ForeColor = System.Drawing.Color.White;
            this.btnAddContry.Location = new System.Drawing.Point(511, 36);
            this.btnAddContry.Name = "btnAddContry";
            this.btnAddContry.Size = new System.Drawing.Size(20, 20);
            this.btnAddContry.TabIndex = 11289;
            this.btnAddContry.Text = "+";
            this.btnAddContry.UseVisualStyleBackColor = false;
            this.btnAddContry.Click += new System.EventHandler(this.btnAddContry_Click);
            // 
            // cmbContryName
            // 
            this.cmbContryName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContryName.FormattingEnabled = true;
            this.cmbContryName.Location = new System.Drawing.Point(142, 35);
            this.cmbContryName.Name = "cmbContryName";
            this.cmbContryName.Size = new System.Drawing.Size(363, 23);
            this.cmbContryName.TabIndex = 11275;
            this.cmbContryName.SelectionChangeCommitted += new System.EventHandler(this.cmbContryName_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 11288;
            this.label1.Text = "Contry Name";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(369, 178);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(218, 23);
            this.txtSearch.TabIndex = 11282;
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(320, 182);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 11287;
            this.lbSearch.Text = "Search ";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(14, 185);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11286;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // txtTalukaName
            // 
            this.txtTalukaName.Location = new System.Drawing.Point(142, 107);
            this.txtTalukaName.Name = "txtTalukaName";
            this.txtTalukaName.Size = new System.Drawing.Size(363, 23);
            this.txtTalukaName.TabIndex = 11277;
            // 
            // lbUdyogAadharNumber
            // 
            this.lbUdyogAadharNumber.AutoSize = true;
            this.lbUdyogAadharNumber.Location = new System.Drawing.Point(58, 63);
            this.lbUdyogAadharNumber.Name = "lbUdyogAadharNumber";
            this.lbUdyogAadharNumber.Size = new System.Drawing.Size(68, 15);
            this.lbUdyogAadharNumber.TabIndex = 11285;
            this.lbUdyogAadharNumber.Text = "State Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 202);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(580, 360);
            this.dataGridView1.TabIndex = 11284;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(386, 135);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11281;
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
            this.btnDelete.Location = new System.Drawing.Point(307, 135);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11280;
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
            this.btnClear.Location = new System.Drawing.Point(228, 135);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11279;
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
            this.btnSave.Location = new System.Drawing.Point(149, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11278;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(599, 30);
            this.lblHeader.TabIndex = 11283;
            this.lblHeader.Text = "Contry Master";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddDistrict
            // 
            this.btnAddDistrict.BackColor = System.Drawing.Color.Blue;
            this.btnAddDistrict.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddDistrict.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddDistrict.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDistrict.ForeColor = System.Drawing.Color.White;
            this.btnAddDistrict.Location = new System.Drawing.Point(511, 84);
            this.btnAddDistrict.Name = "btnAddDistrict";
            this.btnAddDistrict.Size = new System.Drawing.Size(20, 20);
            this.btnAddDistrict.TabIndex = 11293;
            this.btnAddDistrict.Text = "+";
            this.btnAddDistrict.UseVisualStyleBackColor = false;
            this.btnAddDistrict.Click += new System.EventHandler(this.btnAddDistrict_Click);
            // 
            // cmbDistrictName
            // 
            this.cmbDistrictName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistrictName.FormattingEnabled = true;
            this.cmbDistrictName.Location = new System.Drawing.Point(142, 83);
            this.cmbDistrictName.Name = "cmbDistrictName";
            this.cmbDistrictName.Size = new System.Drawing.Size(363, 23);
            this.cmbDistrictName.TabIndex = 11292;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 11294;
            this.label3.Text = "Taluka Name";
            // 
            // TalukaMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 598);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddDistrict);
            this.Controls.Add(this.cmbDistrictName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddState);
            this.Controls.Add(this.cmbStateName);
            this.Controls.Add(this.btnAddContry);
            this.Controls.Add(this.cmbContryName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.txtTalukaName);
            this.Controls.Add(this.lbUdyogAadharNumber);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "TalukaMaster";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.TalukaMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddState;
        private System.Windows.Forms.ComboBox cmbStateName;
        private System.Windows.Forms.Button btnAddContry;
        private System.Windows.Forms.ComboBox cmbContryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.TextBox txtTalukaName;
        private System.Windows.Forms.Label lbUdyogAadharNumber;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnAddDistrict;
        private System.Windows.Forms.ComboBox cmbDistrictName;
        private System.Windows.Forms.Label label3;
    }
}