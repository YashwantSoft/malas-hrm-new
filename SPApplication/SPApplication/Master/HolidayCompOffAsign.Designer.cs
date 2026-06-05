namespace SPApplication.Master
{
    partial class HolidayCompOffAsign
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtCompOffDay = new System.Windows.Forms.TextBox();
            this.dtpCompOffDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clbLocation = new System.Windows.Forms.CheckedListBox();
            this.cbSelectAllLocation = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTotalHoliday = new System.Windows.Forms.Label();
            this.dgvHolidayList = new System.Windows.Forms.DataGridView();
            this.clmSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmTempHolidayId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHolidayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHolidayDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFestival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmHolidayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolidayList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Blue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1149, 30);
            this.lblHeader.TabIndex = 11193;
            this.lblHeader.Text = "TT DB";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(849, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 11555;
            this.label4.Text = "Comp Off Day";
            // 
            // txtCompOffDay
            // 
            this.txtCompOffDay.BackColor = System.Drawing.Color.White;
            this.txtCompOffDay.Location = new System.Drawing.Point(937, 131);
            this.txtCompOffDay.Name = "txtCompOffDay";
            this.txtCompOffDay.ReadOnly = true;
            this.txtCompOffDay.Size = new System.Drawing.Size(126, 23);
            this.txtCompOffDay.TabIndex = 11554;
            // 
            // dtpCompOffDate
            // 
            this.dtpCompOffDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCompOffDate.Location = new System.Drawing.Point(621, 131);
            this.dtpCompOffDate.Name = "dtpCompOffDate";
            this.dtpCompOffDate.Size = new System.Drawing.Size(126, 23);
            this.dtpCompOffDate.TabIndex = 11552;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(533, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 11553;
            this.label3.Text = "Comp Off Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(543, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 11551;
            this.label2.Text = "Location";
            // 
            // clbLocation
            // 
            this.clbLocation.FormattingEnabled = true;
            this.clbLocation.Location = new System.Drawing.Point(621, 36);
            this.clbLocation.Name = "clbLocation";
            this.clbLocation.Size = new System.Drawing.Size(442, 94);
            this.clbLocation.TabIndex = 11549;
            // 
            // cbSelectAllLocation
            // 
            this.cbSelectAllLocation.AutoSize = true;
            this.cbSelectAllLocation.Location = new System.Drawing.Point(1066, 36);
            this.cbSelectAllLocation.Name = "cbSelectAllLocation";
            this.cbSelectAllLocation.Size = new System.Drawing.Size(76, 19);
            this.cbSelectAllLocation.TabIndex = 11550;
            this.cbSelectAllLocation.Text = "Select All";
            this.cbSelectAllLocation.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(767, 195);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 23);
            this.txtSearch.TabIndex = 11560;
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(718, 199);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 11563;
            this.lbSearch.Text = "Search ";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(14, 203);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11562;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 219);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1130, 319);
            this.dataGridView1.TabIndex = 11561;
            this.dataGridView1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(581, 186);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 11559;
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
            this.btnDelete.Location = new System.Drawing.Point(502, 186);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 11558;
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
            this.btnClear.Location = new System.Drawing.Point(423, 186);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 11557;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(344, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 11556;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(313, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(190, 15);
            this.label11.TabIndex = 11566;
            this.label11.Text = "Select Only One from Holiday List";
            // 
            // lblTotalHoliday
            // 
            this.lblTotalHoliday.AutoSize = true;
            this.lblTotalHoliday.Location = new System.Drawing.Point(7, 32);
            this.lblTotalHoliday.Name = "lblTotalHoliday";
            this.lblTotalHoliday.Size = new System.Drawing.Size(80, 15);
            this.lblTotalHoliday.TabIndex = 11565;
            this.lblTotalHoliday.Text = "Total Holiday";
            // 
            // dgvHolidayList
            // 
            this.dgvHolidayList.AllowUserToAddRows = false;
            this.dgvHolidayList.AllowUserToDeleteRows = false;
            this.dgvHolidayList.AllowUserToOrderColumns = true;
            this.dgvHolidayList.AllowUserToResizeColumns = false;
            this.dgvHolidayList.AllowUserToResizeRows = false;
            this.dgvHolidayList.BackgroundColor = System.Drawing.Color.White;
            this.dgvHolidayList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHolidayList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmSelect,
            this.clmTempHolidayId,
            this.clmHolidayDate,
            this.clmHolidayDay,
            this.clmFestival,
            this.clmHolidayType});
            this.dgvHolidayList.Location = new System.Drawing.Point(4, 49);
            this.dgvHolidayList.Name = "dgvHolidayList";
            this.dgvHolidayList.RowHeadersVisible = false;
            this.dgvHolidayList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHolidayList.Size = new System.Drawing.Size(513, 131);
            this.dgvHolidayList.TabIndex = 11564;
            this.dgvHolidayList.TabStop = false;
            // 
            // clmSelect
            // 
            this.clmSelect.HeaderText = "";
            this.clmSelect.Name = "clmSelect";
            this.clmSelect.Width = 30;
            // 
            // clmTempHolidayId
            // 
            this.clmTempHolidayId.HeaderText = "TempHolidayId";
            this.clmTempHolidayId.Name = "clmTempHolidayId";
            this.clmTempHolidayId.ReadOnly = true;
            this.clmTempHolidayId.Visible = false;
            // 
            // clmHolidayDate
            // 
            this.clmHolidayDate.HeaderText = "Holiday Date";
            this.clmHolidayDate.Name = "clmHolidayDate";
            this.clmHolidayDate.ReadOnly = true;
            // 
            // clmHolidayDay
            // 
            this.clmHolidayDay.HeaderText = "Holiday Day";
            this.clmHolidayDay.Name = "clmHolidayDay";
            this.clmHolidayDay.ReadOnly = true;
            // 
            // clmFestival
            // 
            this.clmFestival.HeaderText = "Festival";
            this.clmFestival.Name = "clmFestival";
            this.clmFestival.ReadOnly = true;
            this.clmFestival.Width = 150;
            // 
            // clmHolidayType
            // 
            this.clmHolidayType.HeaderText = "Holiday Type";
            this.clmHolidayType.Name = "clmHolidayType";
            this.clmHolidayType.ReadOnly = true;
            // 
            // HolidayCompOffAsign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1151, 542);
            this.ControlBox = false;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblTotalHoliday);
            this.Controls.Add(this.dgvHolidayList);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCompOffDay);
            this.Controls.Add(this.dtpCompOffDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clbLocation);
            this.Controls.Add(this.cbSelectAllLocation);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HolidayCompOffAsign";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HolidayCompOffAsign_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolidayList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCompOffDay;
        private System.Windows.Forms.DateTimePicker dtpCompOffDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox clbLocation;
        private System.Windows.Forms.CheckBox cbSelectAllLocation;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblTotalHoliday;
        private System.Windows.Forms.DataGridView dgvHolidayList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTempHolidayId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHolidayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHolidayDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFestival;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmHolidayType;
    }
}