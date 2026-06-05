namespace SPApplication.ESSLUtility
{
    partial class ImportExportFacility
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpAttendanceDate = new System.Windows.Forms.DateTimePicker();
            this.label30 = new System.Windows.Forms.Label();
            this.cmbFor = new System.Windows.Forms.ComboBox();
            this.lblFor = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnConvertDATExel = new System.Windows.Forms.Button();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmEmployeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAttendanceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmOutTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Blue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1199, 30);
            this.lblHeader.TabIndex = 11184;
            this.lblHeader.Text = "Asset Entry";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1023, 669);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11397;
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
            this.btnExit.Location = new System.Drawing.Point(1101, 669);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11396;
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
            this.btnDelete.Location = new System.Drawing.Point(863, 669);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11395;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(943, 669);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11394;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpAttendanceDate
            // 
            this.dtpAttendanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAttendanceDate.Location = new System.Drawing.Point(92, 34);
            this.dtpAttendanceDate.Name = "dtpAttendanceDate";
            this.dtpAttendanceDate.Size = new System.Drawing.Size(100, 23);
            this.dtpAttendanceDate.TabIndex = 11441;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(18, 38);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(72, 15);
            this.label30.TabIndex = 11442;
            this.label30.Text = "Import Date";
            // 
            // cmbFor
            // 
            this.cmbFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFor.FormattingEnabled = true;
            this.cmbFor.Location = new System.Drawing.Point(469, 34);
            this.cmbFor.Name = "cmbFor";
            this.cmbFor.Size = new System.Drawing.Size(330, 23);
            this.cmbFor.TabIndex = 11440;
            this.cmbFor.SelectionChangeCommitted += new System.EventHandler(this.cmbFor_SelectionChangeCommitted);
            // 
            // lblFor
            // 
            this.lblFor.AutoSize = true;
            this.lblFor.Location = new System.Drawing.Point(399, 37);
            this.lblFor.Name = "lblFor";
            this.lblFor.Size = new System.Drawing.Size(68, 15);
            this.lblFor.TabIndex = 11439;
            this.lblFor.Text = "Import For ";
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Location = new System.Drawing.Point(724, 61);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 30);
            this.btnDownload.TabIndex = 11443;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnConvertDATExel
            // 
            this.btnConvertDATExel.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnConvertDATExel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertDATExel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertDATExel.ForeColor = System.Drawing.Color.White;
            this.btnConvertDATExel.Location = new System.Drawing.Point(564, 61);
            this.btnConvertDATExel.Name = "btnConvertDATExel";
            this.btnConvertDATExel.Size = new System.Drawing.Size(154, 30);
            this.btnConvertDATExel.TabIndex = 11445;
            this.btnConvertDATExel.Text = "Convert DAT to Exel";
            this.btnConvertDATExel.UseVisualStyleBackColor = false;
            this.btnConvertDATExel.Visible = false;
            this.btnConvertDATExel.Click += new System.EventHandler(this.btnConvertDATExel_Click);
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(15, 81);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(69, 15);
            this.lblTotalCount.TabIndex = 11446;
            this.lblTotalCount.Text = "Total Count";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmEmployeeCode,
            this.clmAttendanceDate,
            this.clmInTime,
            this.clmOutDate,
            this.clmOutTime,
            this.clmStatus});
            this.dataGridView1.Location = new System.Drawing.Point(12, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1174, 548);
            this.dataGridView1.TabIndex = 11447;
            // 
            // clmEmployeeCode
            // 
            this.clmEmployeeCode.HeaderText = "Employee Code";
            this.clmEmployeeCode.Name = "clmEmployeeCode";
            this.clmEmployeeCode.ReadOnly = true;
            this.clmEmployeeCode.Width = 200;
            // 
            // clmAttendanceDate
            // 
            this.clmAttendanceDate.HeaderText = "Attendance Date";
            this.clmAttendanceDate.Name = "clmAttendanceDate";
            this.clmAttendanceDate.ReadOnly = true;
            this.clmAttendanceDate.Width = 200;
            // 
            // clmInTime
            // 
            this.clmInTime.HeaderText = "InTime";
            this.clmInTime.Name = "clmInTime";
            this.clmInTime.ReadOnly = true;
            this.clmInTime.Width = 200;
            // 
            // clmOutDate
            // 
            this.clmOutDate.HeaderText = "OutDate";
            this.clmOutDate.Name = "clmOutDate";
            this.clmOutDate.ReadOnly = true;
            this.clmOutDate.Width = 200;
            // 
            // clmOutTime
            // 
            this.clmOutTime.HeaderText = "OutTime";
            this.clmOutTime.Name = "clmOutTime";
            this.clmOutTime.ReadOnly = true;
            this.clmOutTime.Width = 200;
            // 
            // clmStatus
            // 
            this.clmStatus.HeaderText = "Status";
            this.clmStatus.Name = "clmStatus";
            this.clmStatus.ReadOnly = true;
            this.clmStatus.Width = 150;
            // 
            // ImportExportFacility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1198, 704);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnConvertDATExel);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.dtpAttendanceDate);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.cmbFor);
            this.Controls.Add(this.lblFor);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImportExportFacility";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EmployeeUploadExcelUtility_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpAttendanceDate;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox cmbFor;
        private System.Windows.Forms.Label lblFor;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnConvertDATExel;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmployeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAttendanceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOutDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmOutTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmStatus;
    }
}