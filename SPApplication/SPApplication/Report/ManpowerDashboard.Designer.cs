namespace SPApplication.Report
{
    partial class ManpowerDashboard
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
            this.cbSelectAllLocation = new System.Windows.Forms.CheckBox();
            this.cbSelectAllDepartment = new System.Windows.Forms.CheckBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.btnView = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbToday = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmSrNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepartmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDepartment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPRESENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPLANTHEAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHOD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMANAGER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmINCHARGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSUPERVISOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTECHNICIAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOPERATOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmWORKER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTRAINEE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEXECUTIVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAbsent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPresentPer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmADMINISTRATOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSelectAllLocation
            // 
            this.cbSelectAllLocation.AutoSize = true;
            this.cbSelectAllLocation.Location = new System.Drawing.Point(246, 35);
            this.cbSelectAllLocation.Name = "cbSelectAllLocation";
            this.cbSelectAllLocation.Size = new System.Drawing.Size(72, 19);
            this.cbSelectAllLocation.TabIndex = 11453;
            this.cbSelectAllLocation.Text = "Location";
            this.cbSelectAllLocation.UseVisualStyleBackColor = true;
            this.cbSelectAllLocation.CheckedChanged += new System.EventHandler(this.cbSelectAllLocation_CheckedChanged);
            // 
            // cbSelectAllDepartment
            // 
            this.cbSelectAllDepartment.AutoSize = true;
            this.cbSelectAllDepartment.Location = new System.Drawing.Point(603, 35);
            this.cbSelectAllDepartment.Name = "cbSelectAllDepartment";
            this.cbSelectAllDepartment.Size = new System.Drawing.Size(90, 19);
            this.cbSelectAllDepartment.TabIndex = 11452;
            this.cbSelectAllDepartment.Text = "Department";
            this.cbSelectAllDepartment.UseVisualStyleBackColor = true;
            this.cbSelectAllDepartment.CheckedChanged += new System.EventHandler(this.cbSelectAllDepartment_CheckedChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(467, 64);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(116, 23);
            this.dtpDate.TabIndex = 11450;
            this.dtpDate.Visible = false;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(695, 33);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(224, 23);
            this.cmbDepartment.TabIndex = 11449;
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(320, 33);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(224, 23);
            this.cmbLocation.TabIndex = 11448;
            this.cmbLocation.SelectionChangeCommitted += new System.EventHandler(this.cmbLocation_SelectionChangeCommitted);
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnView.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.ForeColor = System.Drawing.Color.White;
            this.btnView.Location = new System.Drawing.Point(1010, 33);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 30);
            this.btnView.TabIndex = 11447;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1088, 33);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11446;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(1167, 33);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11454;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbToday
            // 
            this.cbToday.AutoSize = true;
            this.cbToday.Location = new System.Drawing.Point(407, 66);
            this.cbToday.Name = "cbToday";
            this.cbToday.Size = new System.Drawing.Size(58, 19);
            this.cbToday.TabIndex = 11455;
            this.cbToday.Text = "Today";
            this.cbToday.UseVisualStyleBackColor = true;
            this.cbToday.Visible = false;
            this.cbToday.CheckedChanged += new System.EventHandler(this.cbToday_CheckedChanged);
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
            this.clmSrNo,
            this.clmLocationId,
            this.clmLocation,
            this.clmDepartmentId,
            this.clmDepartment,
            this.clmPRESENT,
            this.clmPLANTHEAD,
            this.clmHOD,
            this.clmMANAGER,
            this.clmINCHARGE,
            this.clmSUPERVISOR,
            this.clmTECHNICIAN,
            this.clmOPERATOR,
            this.clmWORKER,
            this.clmTRAINEE,
            this.clmEXECUTIVE,
            this.clmAbsent,
            this.clmTotal,
            this.clmPresentPer,
            this.clmADMINISTRATOR});
            this.dataGridView1.Location = new System.Drawing.Point(12, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1226, 595);
            this.dataGridView1.TabIndex = 11456;
            // 
            // clmSrNo
            // 
            this.clmSrNo.HeaderText = "Sr. No";
            this.clmSrNo.Name = "clmSrNo";
            this.clmSrNo.ReadOnly = true;
            this.clmSrNo.Width = 30;
            // 
            // clmLocationId
            // 
            this.clmLocationId.HeaderText = "LocationId";
            this.clmLocationId.Name = "clmLocationId";
            this.clmLocationId.ReadOnly = true;
            this.clmLocationId.Visible = false;
            // 
            // clmLocation
            // 
            this.clmLocation.HeaderText = "Location";
            this.clmLocation.Name = "clmLocation";
            this.clmLocation.ReadOnly = true;
            this.clmLocation.Width = 120;
            // 
            // clmDepartmentId
            // 
            this.clmDepartmentId.HeaderText = "DepartmentId";
            this.clmDepartmentId.Name = "clmDepartmentId";
            this.clmDepartmentId.ReadOnly = true;
            this.clmDepartmentId.Visible = false;
            // 
            // clmDepartment
            // 
            this.clmDepartment.HeaderText = "Department";
            this.clmDepartment.Name = "clmDepartment";
            this.clmDepartment.ReadOnly = true;
            this.clmDepartment.Width = 150;
            // 
            // clmPRESENT
            // 
            this.clmPRESENT.HeaderText = "PRESENT";
            this.clmPRESENT.Name = "clmPRESENT";
            this.clmPRESENT.ReadOnly = true;
            this.clmPRESENT.Width = 60;
            // 
            // clmPLANTHEAD
            // 
            this.clmPLANTHEAD.HeaderText = "PLANT HEAD";
            this.clmPLANTHEAD.Name = "clmPLANTHEAD";
            this.clmPLANTHEAD.ReadOnly = true;
            this.clmPLANTHEAD.Width = 60;
            // 
            // clmHOD
            // 
            this.clmHOD.HeaderText = "HOD";
            this.clmHOD.Name = "clmHOD";
            this.clmHOD.ReadOnly = true;
            this.clmHOD.Width = 60;
            // 
            // clmMANAGER
            // 
            this.clmMANAGER.HeaderText = "MANAGER";
            this.clmMANAGER.Name = "clmMANAGER";
            this.clmMANAGER.ReadOnly = true;
            this.clmMANAGER.Width = 70;
            // 
            // clmINCHARGE
            // 
            this.clmINCHARGE.HeaderText = "INCHARGE";
            this.clmINCHARGE.Name = "clmINCHARGE";
            this.clmINCHARGE.ReadOnly = true;
            this.clmINCHARGE.Width = 70;
            // 
            // clmSUPERVISOR
            // 
            this.clmSUPERVISOR.HeaderText = "SUPERVISOR";
            this.clmSUPERVISOR.Name = "clmSUPERVISOR";
            this.clmSUPERVISOR.ReadOnly = true;
            this.clmSUPERVISOR.Width = 80;
            // 
            // clmTECHNICIAN
            // 
            this.clmTECHNICIAN.HeaderText = "TECHNICIAN";
            this.clmTECHNICIAN.Name = "clmTECHNICIAN";
            this.clmTECHNICIAN.ReadOnly = true;
            this.clmTECHNICIAN.Width = 80;
            // 
            // clmOPERATOR
            // 
            this.clmOPERATOR.HeaderText = "OPERATOR";
            this.clmOPERATOR.Name = "clmOPERATOR";
            this.clmOPERATOR.ReadOnly = true;
            this.clmOPERATOR.Width = 80;
            // 
            // clmWORKER
            // 
            this.clmWORKER.HeaderText = "WORKER";
            this.clmWORKER.Name = "clmWORKER";
            this.clmWORKER.ReadOnly = true;
            this.clmWORKER.Width = 60;
            // 
            // clmTRAINEE
            // 
            this.clmTRAINEE.HeaderText = "TRAINEE";
            this.clmTRAINEE.Name = "clmTRAINEE";
            this.clmTRAINEE.ReadOnly = true;
            this.clmTRAINEE.Width = 60;
            // 
            // clmEXECUTIVE
            // 
            this.clmEXECUTIVE.HeaderText = "EXECUTIVE";
            this.clmEXECUTIVE.Name = "clmEXECUTIVE";
            this.clmEXECUTIVE.ReadOnly = true;
            this.clmEXECUTIVE.Width = 80;
            // 
            // clmAbsent
            // 
            this.clmAbsent.HeaderText = "ABSENT";
            this.clmAbsent.Name = "clmAbsent";
            this.clmAbsent.ReadOnly = true;
            this.clmAbsent.Width = 60;
            // 
            // clmTotal
            // 
            this.clmTotal.HeaderText = "TOTAL";
            this.clmTotal.Name = "clmTotal";
            this.clmTotal.ReadOnly = true;
            this.clmTotal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmTotal.Width = 60;
            // 
            // clmPresentPer
            // 
            this.clmPresentPer.HeaderText = "PER %";
            this.clmPresentPer.Name = "clmPresentPer";
            this.clmPresentPer.ReadOnly = true;
            this.clmPresentPer.Visible = false;
            this.clmPresentPer.Width = 60;
            // 
            // clmADMINISTRATOR
            // 
            this.clmADMINISTRATOR.HeaderText = "ADMIN";
            this.clmADMINISTRATOR.Name = "clmADMINISTRATOR";
            this.clmADMINISTRATOR.ReadOnly = true;
            this.clmADMINISTRATOR.Visible = false;
            this.clmADMINISTRATOR.Width = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 15);
            this.label2.TabIndex = 11460;
            this.label2.Text = "To Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(68, 57);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(100, 23);
            this.dtpToDate.TabIndex = 11459;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(3, 36);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(63, 15);
            this.lblFromDate.TabIndex = 11458;
            this.lblFromDate.Text = "From Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(68, 33);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(100, 23);
            this.dtpFromDate.TabIndex = 11457;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1250, 30);
            this.lblHeader.TabIndex = 11461;
            this.lblHeader.Text = "Database";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ManpowerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1250, 698);
            this.ControlBox = false;
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpToDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbToday);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cbSelectAllLocation);
            this.Controls.Add(this.cbSelectAllDepartment);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnClear);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ManpowerDashboard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DashboardReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbSelectAllLocation;
        private System.Windows.Forms.CheckBox cbSelectAllDepartment;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox cbToday;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSrNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepartmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDepartment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPRESENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPLANTHEAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHOD;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMANAGER;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmINCHARGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSUPERVISOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTECHNICIAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOPERATOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmWORKER;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTRAINEE;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEXECUTIVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAbsent;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPresentPer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmADMINISTRATOR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblHeader;
    }
}