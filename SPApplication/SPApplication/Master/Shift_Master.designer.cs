namespace SPApplication.Master
{
    partial class Shift_Master
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
            this.lbShiftName = new System.Windows.Forms.Label();
            this.lbShortName = new System.Windows.Forms.Label();
            this.txtShiftName = new System.Windows.Forms.TextBox();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.gbTiming = new System.Windows.Forms.GroupBox();
            this.lbHHMM24hrfmtBegingTime2 = new System.Windows.Forms.Label();
            this.lbHHMM24hrfmtBegingTime1 = new System.Windows.Forms.Label();
            this.cbFlexibleShift = new System.Windows.Forms.CheckBox();
            this.cbBreak2 = new System.Windows.Forms.CheckBox();
            this.cbBreak1 = new System.Windows.Forms.CheckBox();
            this.lbBegingTime2 = new System.Windows.Forms.Label();
            this.lbBegingTime1 = new System.Windows.Forms.Label();
            this.lbEndTime2 = new System.Windows.Forms.Label();
            this.lbHHMM24hrfmtEndTime2 = new System.Windows.Forms.Label();
            this.lbHHMM24hrfmtEndTime1 = new System.Windows.Forms.Label();
            this.lbEndTime1 = new System.Windows.Forms.Label();
            this.lbHHMM24hrfmtEndTime = new System.Windows.Forms.Label();
            this.lbEndTime = new System.Windows.Forms.Label();
            this.txtBegingTime2 = new System.Windows.Forms.TextBox();
            this.txtEndTime2 = new System.Windows.Forms.TextBox();
            this.txtEndTime1 = new System.Windows.Forms.TextBox();
            this.txtBegingTime1 = new System.Windows.Forms.TextBox();
            this.txtEndTime = new System.Windows.Forms.TextBox();
            this.lbHHMM24hrfmtBegingTime = new System.Windows.Forms.Label();
            this.txtBegingTime = new System.Windows.Forms.TextBox();
            this.lbBegingTime = new System.Windows.Forms.Label();
            this.cbPunchBeginBefore = new System.Windows.Forms.CheckBox();
            this.cbPunchEndAfter = new System.Windows.Forms.CheckBox();
            this.cbGraceTime = new System.Windows.Forms.CheckBox();
            this.cbPartialDayon = new System.Windows.Forms.CheckBox();
            this.txtPunchBeginBefore = new System.Windows.Forms.TextBox();
            this.txtGraceTime = new System.Windows.Forms.TextBox();
            this.cmbPartialDayon = new System.Windows.Forms.ComboBox();
            this.lbminsDefaultvaluecomesfromMasterSetting = new System.Windows.Forms.Label();
            this.lbminsDefaulisNextDayShiftBeginTimePunchBeginDuration = new System.Windows.Forms.Label();
            this.lbminsDefaultvaluecomesfromEmployeecategorySetting = new System.Windows.Forms.Label();
            this.lbBeginsAt = new System.Windows.Forms.Label();
            this.lbEndAt = new System.Windows.Forms.Label();
            this.lbHHMM24hrfmt = new System.Windows.Forms.Label();
            this.txtBeginsAt = new System.Windows.Forms.TextBox();
            this.txtEndAt = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtPunchEndAfter = new System.Windows.Forms.TextBox();
            this.gbTiming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(-1, 1);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(800, 30);
            this.lblHeader.TabIndex = 215;
            this.lblHeader.Text = "Shift Master";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbShiftName
            // 
            this.lbShiftName.AutoSize = true;
            this.lbShiftName.Location = new System.Drawing.Point(124, 37);
            this.lbShiftName.Name = "lbShiftName";
            this.lbShiftName.Size = new System.Drawing.Size(66, 15);
            this.lbShiftName.TabIndex = 216;
            this.lbShiftName.Text = "Shift Name";
            // 
            // lbShortName
            // 
            this.lbShortName.AutoSize = true;
            this.lbShortName.Location = new System.Drawing.Point(400, 39);
            this.lbShortName.Name = "lbShortName";
            this.lbShortName.Size = new System.Drawing.Size(70, 15);
            this.lbShortName.TabIndex = 217;
            this.lbShortName.Text = "Short Name";
            // 
            // txtShiftName
            // 
            this.txtShiftName.Location = new System.Drawing.Point(194, 33);
            this.txtShiftName.Name = "txtShiftName";
            this.txtShiftName.Size = new System.Drawing.Size(200, 23);
            this.txtShiftName.TabIndex = 0;
            this.txtShiftName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShiftName_KeyDown);
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(474, 35);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(200, 23);
            this.txtShortName.TabIndex = 1;
            this.txtShortName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShortName_KeyDown);
            // 
            // gbTiming
            // 
            this.gbTiming.Controls.Add(this.lbHHMM24hrfmtBegingTime2);
            this.gbTiming.Controls.Add(this.lbHHMM24hrfmtBegingTime1);
            this.gbTiming.Controls.Add(this.cbFlexibleShift);
            this.gbTiming.Controls.Add(this.cbBreak2);
            this.gbTiming.Controls.Add(this.cbBreak1);
            this.gbTiming.Controls.Add(this.lbBegingTime2);
            this.gbTiming.Controls.Add(this.lbBegingTime1);
            this.gbTiming.Controls.Add(this.lbEndTime2);
            this.gbTiming.Controls.Add(this.lbHHMM24hrfmtEndTime2);
            this.gbTiming.Controls.Add(this.lbHHMM24hrfmtEndTime1);
            this.gbTiming.Controls.Add(this.lbEndTime1);
            this.gbTiming.Controls.Add(this.lbHHMM24hrfmtEndTime);
            this.gbTiming.Controls.Add(this.lbEndTime);
            this.gbTiming.Controls.Add(this.txtBegingTime2);
            this.gbTiming.Controls.Add(this.txtEndTime2);
            this.gbTiming.Controls.Add(this.txtEndTime1);
            this.gbTiming.Controls.Add(this.txtBegingTime1);
            this.gbTiming.Controls.Add(this.txtEndTime);
            this.gbTiming.Controls.Add(this.lbHHMM24hrfmtBegingTime);
            this.gbTiming.Controls.Add(this.txtBegingTime);
            this.gbTiming.Controls.Add(this.lbBegingTime);
            this.gbTiming.Location = new System.Drawing.Point(83, 60);
            this.gbTiming.Name = "gbTiming";
            this.gbTiming.Size = new System.Drawing.Size(632, 168);
            this.gbTiming.TabIndex = 2;
            this.gbTiming.TabStop = false;
            this.gbTiming.Text = "Timing";
            // 
            // lbHHMM24hrfmtBegingTime2
            // 
            this.lbHHMM24hrfmtBegingTime2.AutoSize = true;
            this.lbHHMM24hrfmtBegingTime2.Location = new System.Drawing.Point(220, 123);
            this.lbHHMM24hrfmtBegingTime2.Name = "lbHHMM24hrfmtBegingTime2";
            this.lbHHMM24hrfmtBegingTime2.Size = new System.Drawing.Size(101, 15);
            this.lbHHMM24hrfmtBegingTime2.TabIndex = 32;
            this.lbHHMM24hrfmtBegingTime2.Text = "HH:MM 24 hr fmt";
            // 
            // lbHHMM24hrfmtBegingTime1
            // 
            this.lbHHMM24hrfmtBegingTime1.AutoSize = true;
            this.lbHHMM24hrfmtBegingTime1.Location = new System.Drawing.Point(219, 74);
            this.lbHHMM24hrfmtBegingTime1.Name = "lbHHMM24hrfmtBegingTime1";
            this.lbHHMM24hrfmtBegingTime1.Size = new System.Drawing.Size(92, 15);
            this.lbHHMM24hrfmtBegingTime1.TabIndex = 31;
            this.lbHHMM24hrfmtBegingTime1.Text = "HH:MM24hrfmt";
            this.lbHHMM24hrfmtBegingTime1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbFlexibleShift
            // 
            this.cbFlexibleShift.AutoSize = true;
            this.cbFlexibleShift.Location = new System.Drawing.Point(45, 146);
            this.cbFlexibleShift.Name = "cbFlexibleShift";
            this.cbFlexibleShift.Size = new System.Drawing.Size(97, 19);
            this.cbFlexibleShift.TabIndex = 11;
            this.cbFlexibleShift.Text = "Flexible Shift";
            this.cbFlexibleShift.UseVisualStyleBackColor = true;
            this.cbFlexibleShift.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbFlexibleShift_KeyDown);
            // 
            // cbBreak2
            // 
            this.cbBreak2.AutoSize = true;
            this.cbBreak2.Location = new System.Drawing.Point(45, 98);
            this.cbBreak2.Name = "cbBreak2";
            this.cbBreak2.Size = new System.Drawing.Size(64, 19);
            this.cbBreak2.TabIndex = 8;
            this.cbBreak2.Text = "Break2";
            this.cbBreak2.UseVisualStyleBackColor = true;
            this.cbBreak2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbBreak2_KeyDown);
            // 
            // cbBreak1
            // 
            this.cbBreak1.AutoSize = true;
            this.cbBreak1.Location = new System.Drawing.Point(45, 50);
            this.cbBreak1.Name = "cbBreak1";
            this.cbBreak1.Size = new System.Drawing.Size(70, 19);
            this.cbBreak1.TabIndex = 5;
            this.cbBreak1.Text = "Break 1 ";
            this.cbBreak1.UseVisualStyleBackColor = true;
            this.cbBreak1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbBreak1_KeyDown);
            // 
            // lbBegingTime2
            // 
            this.lbBegingTime2.AutoSize = true;
            this.lbBegingTime2.Location = new System.Drawing.Point(40, 124);
            this.lbBegingTime2.Name = "lbBegingTime2";
            this.lbBegingTime2.Size = new System.Drawing.Size(72, 15);
            this.lbBegingTime2.TabIndex = 27;
            this.lbBegingTime2.Text = "Beging Time";
            // 
            // lbBegingTime1
            // 
            this.lbBegingTime1.AutoSize = true;
            this.lbBegingTime1.Location = new System.Drawing.Point(40, 76);
            this.lbBegingTime1.Name = "lbBegingTime1";
            this.lbBegingTime1.Size = new System.Drawing.Size(72, 15);
            this.lbBegingTime1.TabIndex = 26;
            this.lbBegingTime1.Text = "Beging Time";
            // 
            // lbEndTime2
            // 
            this.lbEndTime2.AutoSize = true;
            this.lbEndTime2.Location = new System.Drawing.Point(333, 126);
            this.lbEndTime2.Name = "lbEndTime2";
            this.lbEndTime2.Size = new System.Drawing.Size(56, 15);
            this.lbEndTime2.TabIndex = 25;
            this.lbEndTime2.Text = "End Time";
            // 
            // lbHHMM24hrfmtEndTime2
            // 
            this.lbHHMM24hrfmtEndTime2.AutoSize = true;
            this.lbHHMM24hrfmtEndTime2.Location = new System.Drawing.Point(496, 125);
            this.lbHHMM24hrfmtEndTime2.Name = "lbHHMM24hrfmtEndTime2";
            this.lbHHMM24hrfmtEndTime2.Size = new System.Drawing.Size(101, 15);
            this.lbHHMM24hrfmtEndTime2.TabIndex = 24;
            this.lbHHMM24hrfmtEndTime2.Text = "HH:MM 24 hr fmt";
            // 
            // lbHHMM24hrfmtEndTime1
            // 
            this.lbHHMM24hrfmtEndTime1.AutoSize = true;
            this.lbHHMM24hrfmtEndTime1.Location = new System.Drawing.Point(496, 75);
            this.lbHHMM24hrfmtEndTime1.Name = "lbHHMM24hrfmtEndTime1";
            this.lbHHMM24hrfmtEndTime1.Size = new System.Drawing.Size(101, 15);
            this.lbHHMM24hrfmtEndTime1.TabIndex = 23;
            this.lbHHMM24hrfmtEndTime1.Text = "HH:MM 24 hr fmt";
            // 
            // lbEndTime1
            // 
            this.lbEndTime1.AutoSize = true;
            this.lbEndTime1.Location = new System.Drawing.Point(333, 74);
            this.lbEndTime1.Name = "lbEndTime1";
            this.lbEndTime1.Size = new System.Drawing.Size(56, 15);
            this.lbEndTime1.TabIndex = 22;
            this.lbEndTime1.Text = "End Time";
            // 
            // lbHHMM24hrfmtEndTime
            // 
            this.lbHHMM24hrfmtEndTime.AutoSize = true;
            this.lbHHMM24hrfmtEndTime.Location = new System.Drawing.Point(495, 29);
            this.lbHHMM24hrfmtEndTime.Name = "lbHHMM24hrfmtEndTime";
            this.lbHHMM24hrfmtEndTime.Size = new System.Drawing.Size(101, 15);
            this.lbHHMM24hrfmtEndTime.TabIndex = 21;
            this.lbHHMM24hrfmtEndTime.Text = "HH:MM 24 hr fmt";
            // 
            // lbEndTime
            // 
            this.lbEndTime.AutoSize = true;
            this.lbEndTime.Location = new System.Drawing.Point(333, 28);
            this.lbEndTime.Name = "lbEndTime";
            this.lbEndTime.Size = new System.Drawing.Size(56, 15);
            this.lbEndTime.TabIndex = 20;
            this.lbEndTime.Text = "End Time";
            // 
            // txtBegingTime2
            // 
            this.txtBegingTime2.Location = new System.Drawing.Point(115, 121);
            this.txtBegingTime2.Name = "txtBegingTime2";
            this.txtBegingTime2.Size = new System.Drawing.Size(100, 23);
            this.txtBegingTime2.TabIndex = 9;
            this.txtBegingTime2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBegingTime2_KeyDown);
            // 
            // txtEndTime2
            // 
            this.txtEndTime2.Location = new System.Drawing.Point(392, 121);
            this.txtEndTime2.Name = "txtEndTime2";
            this.txtEndTime2.Size = new System.Drawing.Size(100, 23);
            this.txtEndTime2.TabIndex = 10;
            this.txtEndTime2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEndTime2_KeyDown);
            // 
            // txtEndTime1
            // 
            this.txtEndTime1.Location = new System.Drawing.Point(393, 71);
            this.txtEndTime1.Name = "txtEndTime1";
            this.txtEndTime1.Size = new System.Drawing.Size(100, 23);
            this.txtEndTime1.TabIndex = 7;
            this.txtEndTime1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEndTime1_KeyDown);
            // 
            // txtBegingTime1
            // 
            this.txtBegingTime1.Location = new System.Drawing.Point(115, 71);
            this.txtBegingTime1.Name = "txtBegingTime1";
            this.txtBegingTime1.Size = new System.Drawing.Size(100, 23);
            this.txtBegingTime1.TabIndex = 6;
            this.txtBegingTime1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBegingTime1_KeyDown);
            // 
            // txtEndTime
            // 
            this.txtEndTime.Location = new System.Drawing.Point(392, 25);
            this.txtEndTime.Name = "txtEndTime";
            this.txtEndTime.Size = new System.Drawing.Size(100, 23);
            this.txtEndTime.TabIndex = 4;
            this.txtEndTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEndTime_KeyDown);
            // 
            // lbHHMM24hrfmtBegingTime
            // 
            this.lbHHMM24hrfmtBegingTime.AutoSize = true;
            this.lbHHMM24hrfmtBegingTime.Location = new System.Drawing.Point(219, 28);
            this.lbHHMM24hrfmtBegingTime.Name = "lbHHMM24hrfmtBegingTime";
            this.lbHHMM24hrfmtBegingTime.Size = new System.Drawing.Size(101, 15);
            this.lbHHMM24hrfmtBegingTime.TabIndex = 14;
            this.lbHHMM24hrfmtBegingTime.Text = "HH:MM 24 hr fmt";
            // 
            // txtBegingTime
            // 
            this.txtBegingTime.Location = new System.Drawing.Point(116, 25);
            this.txtBegingTime.Name = "txtBegingTime";
            this.txtBegingTime.Size = new System.Drawing.Size(100, 23);
            this.txtBegingTime.TabIndex = 3;
            this.txtBegingTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBegingTime_KeyDown);
            // 
            // lbBegingTime
            // 
            this.lbBegingTime.AutoSize = true;
            this.lbBegingTime.Location = new System.Drawing.Point(40, 28);
            this.lbBegingTime.Name = "lbBegingTime";
            this.lbBegingTime.Size = new System.Drawing.Size(72, 15);
            this.lbBegingTime.TabIndex = 0;
            this.lbBegingTime.Text = "Beging Time";
            // 
            // cbPunchBeginBefore
            // 
            this.cbPunchBeginBefore.AutoSize = true;
            this.cbPunchBeginBefore.Location = new System.Drawing.Point(108, 235);
            this.cbPunchBeginBefore.Name = "cbPunchBeginBefore";
            this.cbPunchBeginBefore.Size = new System.Drawing.Size(131, 19);
            this.cbPunchBeginBefore.TabIndex = 12;
            this.cbPunchBeginBefore.Text = "Punch Begin Before";
            this.cbPunchBeginBefore.UseVisualStyleBackColor = true;
            this.cbPunchBeginBefore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPunchBeginBefore_KeyDown);
            // 
            // cbPunchEndAfter
            // 
            this.cbPunchEndAfter.AutoSize = true;
            this.cbPunchEndAfter.Location = new System.Drawing.Point(108, 264);
            this.cbPunchEndAfter.Name = "cbPunchEndAfter";
            this.cbPunchEndAfter.Size = new System.Drawing.Size(112, 19);
            this.cbPunchEndAfter.TabIndex = 14;
            this.cbPunchEndAfter.Text = "Punch End After";
            this.cbPunchEndAfter.UseVisualStyleBackColor = true;
            this.cbPunchEndAfter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPunchEndAfter_KeyDown);
            // 
            // cbGraceTime
            // 
            this.cbGraceTime.AutoSize = true;
            this.cbGraceTime.Location = new System.Drawing.Point(108, 292);
            this.cbGraceTime.Name = "cbGraceTime";
            this.cbGraceTime.Size = new System.Drawing.Size(87, 19);
            this.cbGraceTime.TabIndex = 16;
            this.cbGraceTime.Text = "Grace Time";
            this.cbGraceTime.UseVisualStyleBackColor = true;
            this.cbGraceTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbGraceTime_KeyDown);
            // 
            // cbPartialDayon
            // 
            this.cbPartialDayon.AutoSize = true;
            this.cbPartialDayon.Location = new System.Drawing.Point(108, 321);
            this.cbPartialDayon.Name = "cbPartialDayon";
            this.cbPartialDayon.Size = new System.Drawing.Size(104, 19);
            this.cbPartialDayon.TabIndex = 18;
            this.cbPartialDayon.Text = "Partial Day on";
            this.cbPartialDayon.UseVisualStyleBackColor = true;
            this.cbPartialDayon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPartialDayon_KeyDown);
            // 
            // txtPunchBeginBefore
            // 
            this.txtPunchBeginBefore.Location = new System.Drawing.Point(245, 233);
            this.txtPunchBeginBefore.Name = "txtPunchBeginBefore";
            this.txtPunchBeginBefore.Size = new System.Drawing.Size(119, 23);
            this.txtPunchBeginBefore.TabIndex = 13;
            this.txtPunchBeginBefore.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPunchBeginBefore_KeyDown);
            // 
            // txtGraceTime
            // 
            this.txtGraceTime.Location = new System.Drawing.Point(245, 290);
            this.txtGraceTime.Name = "txtGraceTime";
            this.txtGraceTime.Size = new System.Drawing.Size(119, 23);
            this.txtGraceTime.TabIndex = 17;
            this.txtGraceTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGraceTime_KeyDown);
            // 
            // cmbPartialDayon
            // 
            this.cmbPartialDayon.FormattingEnabled = true;
            this.cmbPartialDayon.Location = new System.Drawing.Point(245, 319);
            this.cmbPartialDayon.Name = "cmbPartialDayon";
            this.cmbPartialDayon.Size = new System.Drawing.Size(121, 23);
            this.cmbPartialDayon.TabIndex = 19;
            this.cmbPartialDayon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPartialDayon_KeyDown);
            // 
            // lbminsDefaultvaluecomesfromMasterSetting
            // 
            this.lbminsDefaultvaluecomesfromMasterSetting.AutoSize = true;
            this.lbminsDefaultvaluecomesfromMasterSetting.Location = new System.Drawing.Point(369, 237);
            this.lbminsDefaultvaluecomesfromMasterSetting.Name = "lbminsDefaultvaluecomesfromMasterSetting";
            this.lbminsDefaultvaluecomesfromMasterSetting.Size = new System.Drawing.Size(263, 15);
            this.lbminsDefaultvaluecomesfromMasterSetting.TabIndex = 226;
            this.lbminsDefaultvaluecomesfromMasterSetting.Text = "mins(Default value comes from Master Setting)";
            // 
            // lbminsDefaulisNextDayShiftBeginTimePunchBeginDuration
            // 
            this.lbminsDefaulisNextDayShiftBeginTimePunchBeginDuration.AutoSize = true;
            this.lbminsDefaulisNextDayShiftBeginTimePunchBeginDuration.Location = new System.Drawing.Point(368, 267);
            this.lbminsDefaulisNextDayShiftBeginTimePunchBeginDuration.Name = "lbminsDefaulisNextDayShiftBeginTimePunchBeginDuration";
            this.lbminsDefaulisNextDayShiftBeginTimePunchBeginDuration.Size = new System.Drawing.Size(357, 15);
            this.lbminsDefaulisNextDayShiftBeginTimePunchBeginDuration.TabIndex = 227;
            this.lbminsDefaulisNextDayShiftBeginTimePunchBeginDuration.Text = "mins(Default is Next Day Shift Begin Time Punch Begin Duration)";
            // 
            // lbminsDefaultvaluecomesfromEmployeecategorySetting
            // 
            this.lbminsDefaultvaluecomesfromEmployeecategorySetting.AutoSize = true;
            this.lbminsDefaultvaluecomesfromEmployeecategorySetting.Location = new System.Drawing.Point(368, 295);
            this.lbminsDefaultvaluecomesfromEmployeecategorySetting.Name = "lbminsDefaultvaluecomesfromEmployeecategorySetting";
            this.lbminsDefaultvaluecomesfromEmployeecategorySetting.Size = new System.Drawing.Size(329, 15);
            this.lbminsDefaultvaluecomesfromEmployeecategorySetting.TabIndex = 228;
            this.lbminsDefaultvaluecomesfromEmployeecategorySetting.Text = "mins (Default value comes from Employee category Setting)";
            // 
            // lbBeginsAt
            // 
            this.lbBeginsAt.AutoSize = true;
            this.lbBeginsAt.Location = new System.Drawing.Point(370, 323);
            this.lbBeginsAt.Name = "lbBeginsAt";
            this.lbBeginsAt.Size = new System.Drawing.Size(57, 15);
            this.lbBeginsAt.TabIndex = 229;
            this.lbBeginsAt.Text = "Begins At";
            // 
            // lbEndAt
            // 
            this.lbEndAt.AutoSize = true;
            this.lbEndAt.Location = new System.Drawing.Point(508, 322);
            this.lbEndAt.Name = "lbEndAt";
            this.lbEndAt.Size = new System.Drawing.Size(41, 15);
            this.lbEndAt.TabIndex = 230;
            this.lbEndAt.Text = "End At";
            // 
            // lbHHMM24hrfmt
            // 
            this.lbHHMM24hrfmt.AutoSize = true;
            this.lbHHMM24hrfmt.Location = new System.Drawing.Point(628, 323);
            this.lbHHMM24hrfmt.Name = "lbHHMM24hrfmt";
            this.lbHHMM24hrfmt.Size = new System.Drawing.Size(92, 15);
            this.lbHHMM24hrfmt.TabIndex = 231;
            this.lbHHMM24hrfmt.Text = "HH:MM24hrfmt";
            // 
            // txtBeginsAt
            // 
            this.txtBeginsAt.Location = new System.Drawing.Point(433, 319);
            this.txtBeginsAt.Name = "txtBeginsAt";
            this.txtBeginsAt.Size = new System.Drawing.Size(70, 23);
            this.txtBeginsAt.TabIndex = 20;
            this.txtBeginsAt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBeginsAt_KeyDown);
            // 
            // txtEndAt
            // 
            this.txtEndAt.Location = new System.Drawing.Point(553, 319);
            this.txtEndAt.Name = "txtEndAt";
            this.txtEndAt.Size = new System.Drawing.Size(70, 23);
            this.txtEndAt.TabIndex = 21;
            this.txtEndAt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEndAt_KeyDown);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(558, 357);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 241;
            this.lbSearch.Text = "Search ";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(612, 353);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(179, 23);
            this.txtSearch.TabIndex = 238;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(10, 366);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 240;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(480, 349);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 237;
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
            this.btnDelete.Location = new System.Drawing.Point(401, 349);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 236;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
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
            this.dataGridView1.Location = new System.Drawing.Point(5, 387);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(789, 154);
            this.dataGridView1.TabIndex = 239;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(322, 349);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 235;
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
            this.btnSave.Location = new System.Drawing.Point(243, 349);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 234;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // txtPunchEndAfter
            // 
            this.txtPunchEndAfter.Location = new System.Drawing.Point(243, 261);
            this.txtPunchEndAfter.Name = "txtPunchEndAfter";
            this.txtPunchEndAfter.Size = new System.Drawing.Size(123, 23);
            this.txtPunchEndAfter.TabIndex = 242;
            this.txtPunchEndAfter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPunchEndAfter_KeyDown);
            // 
            // Shift_Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(798, 553);
            this.ControlBox = false;
            this.Controls.Add(this.txtPunchEndAfter);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtEndAt);
            this.Controls.Add(this.txtBeginsAt);
            this.Controls.Add(this.lbHHMM24hrfmt);
            this.Controls.Add(this.lbEndAt);
            this.Controls.Add(this.lbBeginsAt);
            this.Controls.Add(this.lbminsDefaultvaluecomesfromEmployeecategorySetting);
            this.Controls.Add(this.lbminsDefaulisNextDayShiftBeginTimePunchBeginDuration);
            this.Controls.Add(this.lbminsDefaultvaluecomesfromMasterSetting);
            this.Controls.Add(this.cmbPartialDayon);
            this.Controls.Add(this.txtGraceTime);
            this.Controls.Add(this.txtPunchBeginBefore);
            this.Controls.Add(this.cbPartialDayon);
            this.Controls.Add(this.cbGraceTime);
            this.Controls.Add(this.cbPunchEndAfter);
            this.Controls.Add(this.cbPunchBeginBefore);
            this.Controls.Add(this.gbTiming);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.txtShiftName);
            this.Controls.Add(this.lbShortName);
            this.Controls.Add(this.lbShiftName);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Shift_Master";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Shift_Master_Load);
            this.gbTiming.ResumeLayout(false);
            this.gbTiming.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lbShiftName;
        private System.Windows.Forms.Label lbShortName;
        private System.Windows.Forms.TextBox txtShiftName;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.GroupBox gbTiming;
        private System.Windows.Forms.Label lbEndTime1;
        private System.Windows.Forms.Label lbHHMM24hrfmtEndTime;
        private System.Windows.Forms.Label lbEndTime;
        private System.Windows.Forms.TextBox txtBegingTime2;
        private System.Windows.Forms.TextBox txtEndTime2;
        private System.Windows.Forms.TextBox txtEndTime1;
        private System.Windows.Forms.TextBox txtBegingTime1;
        private System.Windows.Forms.TextBox txtEndTime;
        private System.Windows.Forms.Label lbHHMM24hrfmtBegingTime;
        private System.Windows.Forms.TextBox txtBegingTime;
        private System.Windows.Forms.Label lbBegingTime;
        private System.Windows.Forms.Label lbBegingTime2;
        private System.Windows.Forms.Label lbBegingTime1;
        private System.Windows.Forms.Label lbEndTime2;
        private System.Windows.Forms.Label lbHHMM24hrfmtEndTime2;
        private System.Windows.Forms.Label lbHHMM24hrfmtEndTime1;
        private System.Windows.Forms.CheckBox cbFlexibleShift;
        private System.Windows.Forms.CheckBox cbBreak2;
        private System.Windows.Forms.CheckBox cbBreak1;
        private System.Windows.Forms.Label lbHHMM24hrfmtBegingTime1;
        private System.Windows.Forms.Label lbHHMM24hrfmtBegingTime2;
        private System.Windows.Forms.CheckBox cbPunchBeginBefore;
        private System.Windows.Forms.CheckBox cbPunchEndAfter;
        private System.Windows.Forms.CheckBox cbGraceTime;
        private System.Windows.Forms.CheckBox cbPartialDayon;
        private System.Windows.Forms.TextBox txtPunchBeginBefore;
        private System.Windows.Forms.TextBox txtGraceTime;
        private System.Windows.Forms.ComboBox cmbPartialDayon;
        private System.Windows.Forms.Label lbminsDefaultvaluecomesfromMasterSetting;
        private System.Windows.Forms.Label lbminsDefaulisNextDayShiftBeginTimePunchBeginDuration;
        private System.Windows.Forms.Label lbminsDefaultvaluecomesfromEmployeecategorySetting;
        private System.Windows.Forms.Label lbBeginsAt;
        private System.Windows.Forms.Label lbEndAt;
        private System.Windows.Forms.Label lbHHMM24hrfmt;
        private System.Windows.Forms.TextBox txtBeginsAt;
        private System.Windows.Forms.TextBox txtEndAt;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPunchEndAfter;
    }
}