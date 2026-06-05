namespace SPApplication.Report.AssetReport
{
    partial class AssetReport
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
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lbUnitNumber = new System.Windows.Forms.Label();
            this.cbDepartment = new System.Windows.Forms.CheckBox();
            this.gbDepartment = new System.Windows.Forms.GroupBox();
            this.clbDepartment = new System.Windows.Forms.CheckedListBox();
            this.cbSelectAllDepartment = new System.Windows.Forms.CheckBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSearchName = new System.Windows.Forms.Label();
            this.cmbSearch = new System.Windows.Forms.ComboBox();
            this.cmbSearchBy = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblTotalAssetCost = new System.Windows.Forms.Label();
            this.gbDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(110, 45);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(302, 23);
            this.cmbLocation.TabIndex = 11335;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // lbUnitNumber
            // 
            this.lbUnitNumber.AutoSize = true;
            this.lbUnitNumber.Location = new System.Drawing.Point(21, 49);
            this.lbUnitNumber.Name = "lbUnitNumber";
            this.lbUnitNumber.Size = new System.Drawing.Size(87, 15);
            this.lbUnitNumber.TabIndex = 11334;
            this.lbUnitNumber.Text = "Location Name";
            // 
            // cbDepartment
            // 
            this.cbDepartment.AutoSize = true;
            this.cbDepartment.Location = new System.Drawing.Point(740, 32);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(90, 19);
            this.cbDepartment.TabIndex = 11332;
            this.cbDepartment.Text = "Department";
            this.cbDepartment.UseVisualStyleBackColor = true;
            this.cbDepartment.CheckedChanged += new System.EventHandler(this.cbDepartment_CheckedChanged);
            // 
            // gbDepartment
            // 
            this.gbDepartment.Controls.Add(this.clbDepartment);
            this.gbDepartment.Controls.Add(this.cbSelectAllDepartment);
            this.gbDepartment.Enabled = false;
            this.gbDepartment.Location = new System.Drawing.Point(432, 45);
            this.gbDepartment.Name = "gbDepartment";
            this.gbDepartment.Size = new System.Drawing.Size(400, 155);
            this.gbDepartment.TabIndex = 11333;
            this.gbDepartment.TabStop = false;
            this.gbDepartment.Text = "Department";
            // 
            // clbDepartment
            // 
            this.clbDepartment.FormattingEnabled = true;
            this.clbDepartment.Location = new System.Drawing.Point(8, 39);
            this.clbDepartment.Name = "clbDepartment";
            this.clbDepartment.Size = new System.Drawing.Size(386, 112);
            this.clbDepartment.TabIndex = 11302;
            // 
            // cbSelectAllDepartment
            // 
            this.cbSelectAllDepartment.AutoSize = true;
            this.cbSelectAllDepartment.Location = new System.Drawing.Point(11, 18);
            this.cbSelectAllDepartment.Name = "cbSelectAllDepartment";
            this.cbSelectAllDepartment.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAllDepartment.TabIndex = 11304;
            this.cbSelectAllDepartment.Text = "Select All";
            this.cbSelectAllDepartment.UseVisualStyleBackColor = true;
            this.cbSelectAllDepartment.CheckedChanged += new System.EventHandler(this.cbSelectAllDepartment_CheckedChanged);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Blue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1255, 30);
            this.lblHeader.TabIndex = 11336;
            this.lblHeader.Text = "Asset Dashboard";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReport
            // 
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Location = new System.Drawing.Point(589, 675);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 30);
            this.btnReport.TabIndex = 11340;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnView
            // 
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnView.Location = new System.Drawing.Point(1005, 166);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 30);
            this.btnView.TabIndex = 11339;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(1166, 166);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11338;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(1086, 166);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11337;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 206);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1229, 464);
            this.dataGridView1.TabIndex = 11342;
            this.dataGridView1.TabStop = false;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.BackColor = System.Drawing.Color.MistyRose;
            this.lblTotalCount.Location = new System.Drawing.Point(14, 188);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11341;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.Location = new System.Drawing.Point(845, 53);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAll.TabIndex = 11344;
            this.cbSelectAll.Text = "Select All";
            this.cbSelectAll.UseVisualStyleBackColor = true;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Controls.Add(this.lblSearchName);
            this.gbSearch.Controls.Add(this.cmbSearch);
            this.gbSearch.Controls.Add(this.cmbSearchBy);
            this.gbSearch.Location = new System.Drawing.Point(839, 78);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(405, 68);
            this.gbSearch.TabIndex = 11343;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search by";
            this.gbSearch.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 248;
            this.label1.Text = "Search Type";
            // 
            // lblSearchName
            // 
            this.lblSearchName.AutoSize = true;
            this.lblSearchName.Location = new System.Drawing.Point(10, 45);
            this.lblSearchName.Name = "lblSearchName";
            this.lblSearchName.Size = new System.Drawing.Size(60, 15);
            this.lblSearchName.TabIndex = 215;
            this.lblSearchName.Text = "Search by";
            // 
            // cmbSearch
            // 
            this.cmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearch.FormattingEnabled = true;
            this.cmbSearch.Location = new System.Drawing.Point(94, 41);
            this.cmbSearch.Name = "cmbSearch";
            this.cmbSearch.Size = new System.Drawing.Size(277, 23);
            this.cmbSearch.TabIndex = 213;
            this.cmbSearch.Visible = false;
            this.cmbSearch.SelectionChangeCommitted += new System.EventHandler(this.cmbSearch_SelectionChangeCommitted);
            // 
            // cmbSearchBy
            // 
            this.cmbSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchBy.FormattingEnabled = true;
            this.cmbSearchBy.Location = new System.Drawing.Point(94, 15);
            this.cmbSearchBy.Name = "cmbSearchBy";
            this.cmbSearchBy.Size = new System.Drawing.Size(277, 23);
            this.cmbSearchBy.TabIndex = 247;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(110, 84);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(277, 23);
            this.txtSearch.TabIndex = 207;
            this.txtSearch.Visible = false;
            // 
            // lblTotalAssetCost
            // 
            this.lblTotalAssetCost.AutoSize = true;
            this.lblTotalAssetCost.BackColor = System.Drawing.Color.MistyRose;
            this.lblTotalAssetCost.Location = new System.Drawing.Point(244, 188);
            this.lblTotalAssetCost.Name = "lblTotalAssetCost";
            this.lblTotalAssetCost.Size = new System.Drawing.Size(65, 15);
            this.lblTotalAssetCost.TabIndex = 11345;
            this.lblTotalAssetCost.Text = "Total Cost-";
            // 
            // AssetReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1253, 709);
            this.ControlBox = false;
            this.Controls.Add(this.lblTotalAssetCost);
            this.Controls.Add(this.cbSelectAll);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.lbUnitNumber);
            this.Controls.Add(this.cbDepartment);
            this.Controls.Add(this.gbDepartment);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AssetReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AssetReport_Load);
            this.gbDepartment.ResumeLayout(false);
            this.gbDepartment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lbUnitNumber;
        private System.Windows.Forms.CheckBox cbDepartment;
        private System.Windows.Forms.GroupBox gbDepartment;
        private System.Windows.Forms.CheckedListBox clbDepartment;
        private System.Windows.Forms.CheckBox cbSelectAllDepartment;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.CheckBox cbSelectAll;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearchName;
        private System.Windows.Forms.ComboBox cmbSearch;
        private System.Windows.Forms.ComboBox cmbSearchBy;
        private System.Windows.Forms.Label lblTotalAssetCost;
    }
}