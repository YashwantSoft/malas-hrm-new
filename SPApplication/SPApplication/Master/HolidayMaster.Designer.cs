namespace SPApplication.Master
{
    partial class HolidayMaster
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtHolidayDay = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpHolidayDate = new System.Windows.Forms.DateTimePicker();
            this.lbEstablishmentDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHolidayFestival = new System.Windows.Forms.TextBox();
            this.cbIsNationalHoliday = new System.Windows.Forms.CheckBox();
            this.cmbHolidayType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clbLocation = new System.Windows.Forms.CheckedListBox();
            this.cbSelectAllLocation = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.Blue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-3, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1001, 30);
            this.lblHeader.TabIndex = 11192;
            this.lblHeader.Text = "TT DB";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(561, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 15);
            this.label5.TabIndex = 11354;
            this.label5.Text = "Holiday Day";
            // 
            // txtHolidayDay
            // 
            this.txtHolidayDay.BackColor = System.Drawing.Color.White;
            this.txtHolidayDay.Location = new System.Drawing.Point(637, 34);
            this.txtHolidayDay.Name = "txtHolidayDay";
            this.txtHolidayDay.ReadOnly = true;
            this.txtHolidayDay.Size = new System.Drawing.Size(153, 23);
            this.txtHolidayDay.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(767, 260);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 23);
            this.txtSearch.TabIndex = 11349;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(718, 264);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 11352;
            this.lbSearch.Text = "Search ";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(14, 268);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 11351;
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
            this.dataGridView1.Location = new System.Drawing.Point(11, 285);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(976, 309);
            this.dataGridView1.TabIndex = 11350;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(579, 249);
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
            this.btnDelete.Location = new System.Drawing.Point(500, 249);
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
            this.btnClear.Location = new System.Drawing.Point(421, 249);
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
            this.btnSave.Location = new System.Drawing.Point(342, 249);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dtpHolidayDate
            // 
            this.dtpHolidayDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHolidayDate.Location = new System.Drawing.Point(348, 35);
            this.dtpHolidayDate.Name = "dtpHolidayDate";
            this.dtpHolidayDate.Size = new System.Drawing.Size(126, 23);
            this.dtpHolidayDate.TabIndex = 0;
            this.dtpHolidayDate.ValueChanged += new System.EventHandler(this.dtpHolidayDate_ValueChanged);
            // 
            // lbEstablishmentDate
            // 
            this.lbEstablishmentDate.AutoSize = true;
            this.lbEstablishmentDate.Location = new System.Drawing.Point(209, 38);
            this.lbEstablishmentDate.Name = "lbEstablishmentDate";
            this.lbEstablishmentDate.Size = new System.Drawing.Size(78, 15);
            this.lbEstablishmentDate.TabIndex = 11534;
            this.lbEstablishmentDate.Text = "Holiday Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(209, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 15);
            this.label7.TabIndex = 11538;
            this.label7.Text = "Holiday Name / Festival";
            // 
            // txtHolidayFestival
            // 
            this.txtHolidayFestival.BackColor = System.Drawing.Color.White;
            this.txtHolidayFestival.Location = new System.Drawing.Point(348, 59);
            this.txtHolidayFestival.Name = "txtHolidayFestival";
            this.txtHolidayFestival.Size = new System.Drawing.Size(442, 23);
            this.txtHolidayFestival.TabIndex = 2;
            // 
            // cbIsNationalHoliday
            // 
            this.cbIsNationalHoliday.AutoSize = true;
            this.cbIsNationalHoliday.Location = new System.Drawing.Point(480, 86);
            this.cbIsNationalHoliday.Name = "cbIsNationalHoliday";
            this.cbIsNationalHoliday.Size = new System.Drawing.Size(132, 19);
            this.cbIsNationalHoliday.TabIndex = 11539;
            this.cbIsNationalHoliday.Text = "Is National Holiday";
            this.cbIsNationalHoliday.UseVisualStyleBackColor = true;
            // 
            // cmbHolidayType
            // 
            this.cmbHolidayType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHolidayType.FormattingEnabled = true;
            this.cmbHolidayType.Items.AddRange(new object[] {
            "Holiday",
            "National Holiday",
            "State Holiday",
            "Company Holiday",
            "Comp Off Holiay"});
            this.cmbHolidayType.Location = new System.Drawing.Point(348, 83);
            this.cmbHolidayType.Name = "cmbHolidayType";
            this.cmbHolidayType.Size = new System.Drawing.Size(126, 23);
            this.cmbHolidayType.TabIndex = 11540;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 11541;
            this.label1.Text = "Holiday Type";
            // 
            // clbLocation
            // 
            this.clbLocation.FormattingEnabled = true;
            this.clbLocation.Location = new System.Drawing.Point(348, 110);
            this.clbLocation.Name = "clbLocation";
            this.clbLocation.Size = new System.Drawing.Size(442, 130);
            this.clbLocation.TabIndex = 11542;
            // 
            // cbSelectAllLocation
            // 
            this.cbSelectAllLocation.AutoSize = true;
            this.cbSelectAllLocation.Location = new System.Drawing.Point(212, 110);
            this.cbSelectAllLocation.Name = "cbSelectAllLocation";
            this.cbSelectAllLocation.Size = new System.Drawing.Size(76, 34);
            this.cbSelectAllLocation.TabIndex = 11543;
            this.cbSelectAllLocation.Text = "Location \r\nSelect All";
            this.cbSelectAllLocation.UseVisualStyleBackColor = true;
            this.cbSelectAllLocation.CheckedChanged += new System.EventHandler(this.cbSelectAllLocation_CheckedChanged);
            // 
            // HolidayMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(996, 598);
            this.ControlBox = false;
            this.Controls.Add(this.clbLocation);
            this.Controls.Add(this.cbSelectAllLocation);
            this.Controls.Add(this.cmbHolidayType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbIsNationalHoliday);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtHolidayFestival);
            this.Controls.Add(this.dtpHolidayDate);
            this.Controls.Add(this.lbEstablishmentDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHolidayDay);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HolidayMaster";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HolidayMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHolidayDay;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker dtpHolidayDate;
        private System.Windows.Forms.Label lbEstablishmentDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHolidayFestival;
        private System.Windows.Forms.CheckBox cbIsNationalHoliday;
        private System.Windows.Forms.ComboBox cmbHolidayType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clbLocation;
        private System.Windows.Forms.CheckBox cbSelectAllLocation;
    }
}