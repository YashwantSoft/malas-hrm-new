namespace SPApplication.Master
{
    partial class DistrictMaster
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
            this.btnAddContry = new System.Windows.Forms.Button();
            this.cmbContryName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.txtDistrictName = new System.Windows.Forms.TextBox();
            this.lbUdyogAadharNumber = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnAddState = new System.Windows.Forms.Button();
            this.cmbStateName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.btnAddContry.TabIndex = 11271;
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
            this.cmbContryName.TabIndex = 0;
            this.cmbContryName.SelectionChangeCommitted += new System.EventHandler(this.cmbContryName_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 11269;
            this.label1.Text = "Contry Name";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(368, 146);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(218, 23);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(319, 150);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 11267;
            this.lbSearch.Text = "Search ";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(13, 153);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11266;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // txtDistrictName
            // 
            this.txtDistrictName.Location = new System.Drawing.Point(142, 83);
            this.txtDistrictName.Name = "txtDistrictName";
            this.txtDistrictName.Size = new System.Drawing.Size(363, 23);
            this.txtDistrictName.TabIndex = 2;
            // 
            // lbUdyogAadharNumber
            // 
            this.lbUdyogAadharNumber.AutoSize = true;
            this.lbUdyogAadharNumber.Location = new System.Drawing.Point(58, 63);
            this.lbUdyogAadharNumber.Name = "lbUdyogAadharNumber";
            this.lbUdyogAadharNumber.Size = new System.Drawing.Size(68, 15);
            this.lbUdyogAadharNumber.TabIndex = 11265;
            this.lbUdyogAadharNumber.Text = "State Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(580, 399);
            this.dataGridView1.TabIndex = 11263;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(380, 110);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 6;
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
            this.btnDelete.Location = new System.Drawing.Point(301, 110);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 5;
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
            this.btnClear.Location = new System.Drawing.Point(222, 110);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 4;
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
            this.btnSave.Location = new System.Drawing.Point(143, 110);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 3;
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
            this.lblHeader.TabIndex = 11258;
            this.lblHeader.Text = "Contry Master";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnAddState.TabIndex = 11273;
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
            this.cmbStateName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 11274;
            this.label2.Text = "District Name";
            // 
            // DistrictMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(598, 598);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddState);
            this.Controls.Add(this.cmbStateName);
            this.Controls.Add(this.btnAddContry);
            this.Controls.Add(this.cmbContryName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.txtDistrictName);
            this.Controls.Add(this.lbUdyogAadharNumber);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DistrictMaster";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DistrictMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddContry;
        private System.Windows.Forms.ComboBox cmbContryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.TextBox txtDistrictName;
        private System.Windows.Forms.Label lbUdyogAadharNumber;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnAddState;
        private System.Windows.Forms.ComboBox cmbStateName;
        private System.Windows.Forms.Label label2;
    }
}