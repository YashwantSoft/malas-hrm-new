namespace SPApplication.Report
{
    partial class LocationDepartmentWiseLeaveReport
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
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblLeaveType = new System.Windows.Forms.Label();
            this.cmbLeaveType = new System.Windows.Forms.ComboBox();
            this.cbSelectAllLeaveType = new System.Windows.Forms.CheckBox();
            this.cbSelectAllLocation = new System.Windows.Forms.CheckBox();
            this.cbSelectAllDepartment = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(442, 58);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(321, 23);
            this.cmbDepartment.TabIndex = 11379;
            this.cmbDepartment.SelectionChangeCommitted += new System.EventHandler(this.cmbDepartment_SelectionChangeCommitted);
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(442, 34);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(321, 23);
            this.cmbLocation.TabIndex = 11377;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1199, 30);
            this.lblHeader.TabIndex = 11388;
            this.lblHeader.Text = "TT DB";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(11, 129);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11394;
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
            this.dataGridView1.Location = new System.Drawing.Point(9, 147);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1177, 548);
            this.dataGridView1.TabIndex = 11393;
            // 
            // btnReport
            // 
            this.btnReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReport.Location = new System.Drawing.Point(482, 111);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 30);
            this.btnReport.TabIndex = 11392;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnView
            // 
            this.btnView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnView.Location = new System.Drawing.Point(1111, 37);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 30);
            this.btnView.TabIndex = 11391;
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Visible = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Location = new System.Drawing.Point(642, 111);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11390;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(562, 111);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11389;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblLeaveType
            // 
            this.lblLeaveType.AutoSize = true;
            this.lblLeaveType.Location = new System.Drawing.Point(353, 85);
            this.lblLeaveType.Name = "lblLeaveType";
            this.lblLeaveType.Size = new System.Drawing.Size(64, 15);
            this.lblLeaveType.TabIndex = 11385;
            this.lblLeaveType.Text = "Leave Type";
            this.lblLeaveType.Visible = false;
            // 
            // cmbLeaveType
            // 
            this.cmbLeaveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLeaveType.FormattingEnabled = true;
            this.cmbLeaveType.Location = new System.Drawing.Point(442, 82);
            this.cmbLeaveType.Name = "cmbLeaveType";
            this.cmbLeaveType.Size = new System.Drawing.Size(321, 23);
            this.cmbLeaveType.TabIndex = 11386;
            this.cmbLeaveType.Visible = false;
            // 
            // cbSelectAllLeaveType
            // 
            this.cbSelectAllLeaveType.AutoSize = true;
            this.cbSelectAllLeaveType.Location = new System.Drawing.Point(769, 84);
            this.cbSelectAllLeaveType.Name = "cbSelectAllLeaveType";
            this.cbSelectAllLeaveType.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAllLeaveType.TabIndex = 11387;
            this.cbSelectAllLeaveType.Text = "Select All";
            this.cbSelectAllLeaveType.UseVisualStyleBackColor = true;
            this.cbSelectAllLeaveType.Visible = false;
            this.cbSelectAllLeaveType.CheckedChanged += new System.EventHandler(this.cbSelectAllLeaveType_CheckedChanged);
            // 
            // cbSelectAllLocation
            // 
            this.cbSelectAllLocation.AutoSize = true;
            this.cbSelectAllLocation.Location = new System.Drawing.Point(346, 37);
            this.cbSelectAllLocation.Name = "cbSelectAllLocation";
            this.cbSelectAllLocation.Size = new System.Drawing.Size(72, 19);
            this.cbSelectAllLocation.TabIndex = 11434;
            this.cbSelectAllLocation.Text = "Location";
            this.cbSelectAllLocation.UseVisualStyleBackColor = true;
            this.cbSelectAllLocation.CheckedChanged += new System.EventHandler(this.cbSelectAllLocation_CheckedChanged);
            // 
            // cbSelectAllDepartment
            // 
            this.cbSelectAllDepartment.AutoSize = true;
            this.cbSelectAllDepartment.Location = new System.Drawing.Point(346, 60);
            this.cbSelectAllDepartment.Name = "cbSelectAllDepartment";
            this.cbSelectAllDepartment.Size = new System.Drawing.Size(90, 19);
            this.cbSelectAllDepartment.TabIndex = 11433;
            this.cbSelectAllDepartment.Text = "Department";
            this.cbSelectAllDepartment.UseVisualStyleBackColor = true;
            this.cbSelectAllDepartment.CheckedChanged += new System.EventHandler(this.cbSelectAllDepartment_CheckedChanged);
            // 
            // LocationDepartmentWiseLeaveReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 698);
            this.ControlBox = false;
            this.Controls.Add(this.cbSelectAllLocation);
            this.Controls.Add(this.cbSelectAllDepartment);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.cbSelectAllLeaveType);
            this.Controls.Add(this.cmbLeaveType);
            this.Controls.Add(this.lblLeaveType);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbLocation);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LocationDepartmentWiseLeaveReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LocationDepartmentWiseLeaveReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblLeaveType;
        private System.Windows.Forms.ComboBox cmbLeaveType;
        private System.Windows.Forms.CheckBox cbSelectAllLeaveType;
        private System.Windows.Forms.CheckBox cbSelectAllLocation;
        private System.Windows.Forms.CheckBox cbSelectAllDepartment;
    }
}