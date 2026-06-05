namespace SPApplication.Master
{
    partial class CategoryMaster
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
            this.LbCategoryName = new System.Windows.Forms.Label();
            this.lbShortName = new System.Windows.Forms.Label();
            this.lbOTFormula = new System.Windows.Forms.Label();
            this.lbMins = new System.Windows.Forms.Label();
            this.lbMinOT = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.txtMinOT = new System.Windows.Forms.TextBox();
            this.cmbOTFormula = new System.Windows.Forms.ComboBox();
            this.cbConsiderOnlyFirstAndLastPunchInAttCalculations = new System.Windows.Forms.CheckBox();
            this.cbNeglectLastInPunchForMissedOutPunch = new System.Windows.Forms.CheckBox();
            this.cbWeeklyOff1 = new System.Windows.Forms.CheckBox();
            this.cb1st = new System.Windows.Forms.CheckBox();
            this.cbMaxOT = new System.Windows.Forms.CheckBox();
            this.cbWeeklyOff2 = new System.Windows.Forms.CheckBox();
            this.cb2nd = new System.Windows.Forms.CheckBox();
            this.cmbWeeklyOff1 = new System.Windows.Forms.ComboBox();
            this.txtMaxOT = new System.Windows.Forms.TextBox();
            this.lbGraceTimeForLateComing = new System.Windows.Forms.Label();
            this.lGraceTimeForEarlyGoing = new System.Windows.Forms.Label();
            this.lbMinsGTFLC = new System.Windows.Forms.Label();
            this.lbMinsGTFEG = new System.Windows.Forms.Label();
            this.txtGraceTimeForLateComing = new System.Windows.Forms.TextBox();
            this.txtGraceTimeForEarlyGoing = new System.Windows.Forms.TextBox();
            this.cmbWeeklyOff2 = new System.Windows.Forms.ComboBox();
            this.cb5th = new System.Windows.Forms.CheckBox();
            this.cb3rd = new System.Windows.Forms.CheckBox();
            this.cb4th = new System.Windows.Forms.CheckBox();
            this.cbConsiderEarlyComingPunch = new System.Windows.Forms.CheckBox();
            this.cbConsiderLateGoingPunch = new System.Windows.Forms.CheckBox();
            this.cbDeductBreakHoursFormWorkDuration = new System.Windows.Forms.CheckBox();
            this.cbCalculateHalfDayifWorkDurationIsLessThan = new System.Windows.Forms.CheckBox();
            this.cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan = new System.Windows.Forms.CheckBox();
            this.cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan = new System.Windows.Forms.CheckBox();
            this.cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent = new System.Windows.Forms.CheckBox();
            this.cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent = new System.Windows.Forms.CheckBox();
            this.cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent = new System.Windows.Forms.CheckBox();
            this.cbMark = new System.Windows.Forms.CheckBox();
            this.cbMarkHalfDayifLateBy = new System.Windows.Forms.CheckBox();
            this.cbMarkHalfDayifEarlyGoingBy = new System.Windows.Forms.CheckBox();
            this.txtCalculateHalfDayifWorkDurationIsLessThanMins = new System.Windows.Forms.TextBox();
            this.txtCalculationAbsentIfWorkDurationIsLessThanMins = new System.Windows.Forms.TextBox();
            this.txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins = new System.Windows.Forms.TextBox();
            this.txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins = new System.Windows.Forms.TextBox();
            this.txtMarkHalfDayifLateByMins = new System.Windows.Forms.TextBox();
            this.txtMarkHalfDayifEarlyGoingByMins = new System.Windows.Forms.TextBox();
            this.lbAbsentWhenLateFor = new System.Windows.Forms.Label();
            this.lbMinsAbsentWhenLateFor = new System.Windows.Forms.Label();
            this.lbMinsMarkHalfDayiflateby = new System.Windows.Forms.Label();
            this.lbMinsMarkHalfDayifearlyGoingby = new System.Windows.Forms.Label();
            this.lbMinsCalculateHalfDayifWorkDurationIslessThan = new System.Windows.Forms.Label();
            this.lbMinsCalculationAbsentifWorkDurationislessThan = new System.Windows.Forms.Label();
            this.lbMinsOnPartialDayCalculateHalfDayifWorkDurationislessthan = new System.Windows.Forms.Label();
            this.lbMinsOnPartialDayCalculateAbsentDayifWorkDurationislessthan = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbMarkValue = new System.Windows.Forms.ComboBox();
            this.cmbAbsentWhenLateForValue = new System.Windows.Forms.ComboBox();
            this.cbCalculationAbsentIfWorkDurationIsLessThan = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.lblHeader.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(2, 1);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(894, 30);
            this.lblHeader.TabIndex = 214;
            this.lblHeader.Text = "Category Details";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LbCategoryName
            // 
            this.LbCategoryName.AutoSize = true;
            this.LbCategoryName.Location = new System.Drawing.Point(97, 38);
            this.LbCategoryName.Name = "LbCategoryName";
            this.LbCategoryName.Size = new System.Drawing.Size(89, 15);
            this.LbCategoryName.TabIndex = 215;
            this.LbCategoryName.Text = "Category Name";
            // 
            // lbShortName
            // 
            this.lbShortName.AutoSize = true;
            this.lbShortName.Location = new System.Drawing.Point(424, 37);
            this.lbShortName.Name = "lbShortName";
            this.lbShortName.Size = new System.Drawing.Size(70, 15);
            this.lbShortName.TabIndex = 216;
            this.lbShortName.Text = "Short Name";
            // 
            // lbOTFormula
            // 
            this.lbOTFormula.AutoSize = true;
            this.lbOTFormula.Location = new System.Drawing.Point(97, 63);
            this.lbOTFormula.Name = "lbOTFormula";
            this.lbOTFormula.Size = new System.Drawing.Size(71, 15);
            this.lbOTFormula.TabIndex = 217;
            this.lbOTFormula.Text = "OT Formula";
            // 
            // lbMins
            // 
            this.lbMins.AutoSize = true;
            this.lbMins.Location = new System.Drawing.Point(760, 60);
            this.lbMins.Name = "lbMins";
            this.lbMins.Size = new System.Drawing.Size(35, 15);
            this.lbMins.TabIndex = 218;
            this.lbMins.Text = "Mins";
            this.lbMins.Visible = false;
            // 
            // lbMinOT
            // 
            this.lbMinOT.AutoSize = true;
            this.lbMinOT.Location = new System.Drawing.Point(424, 60);
            this.lbMinOT.Name = "lbMinOT";
            this.lbMinOT.Size = new System.Drawing.Size(47, 15);
            this.lbMinOT.TabIndex = 219;
            this.lbMinOT.Text = "Min OT";
            this.lbMinOT.Visible = false;
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(586, 33);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(200, 23);
            this.txtShortName.TabIndex = 1;
            this.txtShortName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtShortName_KeyDown);
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(198, 34);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(200, 23);
            this.txtCategoryName.TabIndex = 0;
            this.txtCategoryName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCategoryName_KeyDown);
            // 
            // txtMinOT
            // 
            this.txtMinOT.Location = new System.Drawing.Point(586, 57);
            this.txtMinOT.Name = "txtMinOT";
            this.txtMinOT.Size = new System.Drawing.Size(47, 23);
            this.txtMinOT.TabIndex = 3;
            this.txtMinOT.Visible = false;
            this.txtMinOT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMinOT_KeyDown);
            this.txtMinOT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinOT_KeyPress);
            // 
            // cmbOTFormula
            // 
            this.cmbOTFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOTFormula.FormattingEnabled = true;
            this.cmbOTFormula.Location = new System.Drawing.Point(198, 58);
            this.cmbOTFormula.Name = "cmbOTFormula";
            this.cmbOTFormula.Size = new System.Drawing.Size(200, 23);
            this.cmbOTFormula.TabIndex = 2;
            this.cmbOTFormula.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbOTFormula_KeyDown);
            // 
            // cbConsiderOnlyFirstAndLastPunchInAttCalculations
            // 
            this.cbConsiderOnlyFirstAndLastPunchInAttCalculations.AutoSize = true;
            this.cbConsiderOnlyFirstAndLastPunchInAttCalculations.Location = new System.Drawing.Point(99, 85);
            this.cbConsiderOnlyFirstAndLastPunchInAttCalculations.Name = "cbConsiderOnlyFirstAndLastPunchInAttCalculations";
            this.cbConsiderOnlyFirstAndLastPunchInAttCalculations.Size = new System.Drawing.Size(322, 19);
            this.cbConsiderOnlyFirstAndLastPunchInAttCalculations.TabIndex = 6;
            this.cbConsiderOnlyFirstAndLastPunchInAttCalculations.Text = "Consider Only First And Last Punch In Att Calculations";
            this.cbConsiderOnlyFirstAndLastPunchInAttCalculations.UseVisualStyleBackColor = true;
            this.cbConsiderOnlyFirstAndLastPunchInAttCalculations.CheckedChanged += new System.EventHandler(this.cbConsiderOnlyFirstAndLastPunchInAttCalculations_CheckedChanged);
            this.cbConsiderOnlyFirstAndLastPunchInAttCalculations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbConsiderOnlyFirstAndLastPunchInAttCalculations_KeyDown);
            // 
            // cbNeglectLastInPunchForMissedOutPunch
            // 
            this.cbNeglectLastInPunchForMissedOutPunch.AutoSize = true;
            this.cbNeglectLastInPunchForMissedOutPunch.Location = new System.Drawing.Point(99, 110);
            this.cbNeglectLastInPunchForMissedOutPunch.Name = "cbNeglectLastInPunchForMissedOutPunch";
            this.cbNeglectLastInPunchForMissedOutPunch.Size = new System.Drawing.Size(274, 19);
            this.cbNeglectLastInPunchForMissedOutPunch.TabIndex = 7;
            this.cbNeglectLastInPunchForMissedOutPunch.Text = "Neglect Last In Punch (For Missed Out Punch)";
            this.cbNeglectLastInPunchForMissedOutPunch.UseVisualStyleBackColor = true;
            this.cbNeglectLastInPunchForMissedOutPunch.CheckedChanged += new System.EventHandler(this.cbNeglectLastInPunchForMissedOutPunch_CheckedChanged);
            this.cbNeglectLastInPunchForMissedOutPunch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbNeglectLastInPunchForMissedOutPunch_KeyDown);
            // 
            // cbWeeklyOff1
            // 
            this.cbWeeklyOff1.AutoSize = true;
            this.cbWeeklyOff1.Location = new System.Drawing.Point(99, 135);
            this.cbWeeklyOff1.Name = "cbWeeklyOff1";
            this.cbWeeklyOff1.Size = new System.Drawing.Size(96, 19);
            this.cbWeeklyOff1.TabIndex = 10;
            this.cbWeeklyOff1.Text = "Weekly Off 1";
            this.cbWeeklyOff1.UseVisualStyleBackColor = true;
            this.cbWeeklyOff1.CheckedChanged += new System.EventHandler(this.cbWeeklyOff1_CheckedChanged);
            this.cbWeeklyOff1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbWeeklyOff1_KeyDown);
            // 
            // cb1st
            // 
            this.cb1st.AutoSize = true;
            this.cb1st.Location = new System.Drawing.Point(424, 161);
            this.cb1st.Name = "cb1st";
            this.cb1st.Size = new System.Drawing.Size(46, 19);
            this.cb1st.TabIndex = 14;
            this.cb1st.Text = "1st ";
            this.cb1st.UseVisualStyleBackColor = true;
            this.cb1st.CheckedChanged += new System.EventHandler(this.cb1st_CheckedChanged);
            this.cb1st.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb1st_KeyDown);
            // 
            // cbMaxOT
            // 
            this.cbMaxOT.AutoSize = true;
            this.cbMaxOT.Location = new System.Drawing.Point(637, 60);
            this.cbMaxOT.Name = "cbMaxOT";
            this.cbMaxOT.Size = new System.Drawing.Size(68, 19);
            this.cbMaxOT.TabIndex = 4;
            this.cbMaxOT.Text = "Max OT";
            this.cbMaxOT.UseVisualStyleBackColor = true;
            this.cbMaxOT.Visible = false;
            this.cbMaxOT.CheckedChanged += new System.EventHandler(this.cbMaxOT_CheckedChanged);
            this.cbMaxOT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMaxOT_KeyDown);
            // 
            // cbWeeklyOff2
            // 
            this.cbWeeklyOff2.AutoSize = true;
            this.cbWeeklyOff2.Location = new System.Drawing.Point(424, 133);
            this.cbWeeklyOff2.Name = "cbWeeklyOff2";
            this.cbWeeklyOff2.Size = new System.Drawing.Size(96, 19);
            this.cbWeeklyOff2.TabIndex = 12;
            this.cbWeeklyOff2.Text = "Weekly Off 2";
            this.cbWeeklyOff2.UseVisualStyleBackColor = true;
            this.cbWeeklyOff2.CheckedChanged += new System.EventHandler(this.cbWeeklyOff2_CheckedChanged);
            this.cbWeeklyOff2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbWeeklyOff2_KeyDown);
            // 
            // cb2nd
            // 
            this.cb2nd.AutoSize = true;
            this.cb2nd.Location = new System.Drawing.Point(478, 161);
            this.cb2nd.Name = "cb2nd";
            this.cb2nd.Size = new System.Drawing.Size(47, 19);
            this.cb2nd.TabIndex = 15;
            this.cb2nd.Text = "2nd";
            this.cb2nd.UseVisualStyleBackColor = true;
            this.cb2nd.CheckedChanged += new System.EventHandler(this.cb2nd_CheckedChanged);
            this.cb2nd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb2nd_KeyDown);
            // 
            // cmbWeeklyOff1
            // 
            this.cmbWeeklyOff1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeeklyOff1.Enabled = false;
            this.cmbWeeklyOff1.FormattingEnabled = true;
            this.cmbWeeklyOff1.Location = new System.Drawing.Point(198, 132);
            this.cmbWeeklyOff1.Name = "cmbWeeklyOff1";
            this.cmbWeeklyOff1.Size = new System.Drawing.Size(121, 23);
            this.cmbWeeklyOff1.TabIndex = 11;
            this.cmbWeeklyOff1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbWeeklyOff1_KeyDown);
            // 
            // txtMaxOT
            // 
            this.txtMaxOT.Location = new System.Drawing.Point(709, 57);
            this.txtMaxOT.Name = "txtMaxOT";
            this.txtMaxOT.Size = new System.Drawing.Size(46, 23);
            this.txtMaxOT.TabIndex = 5;
            this.txtMaxOT.Visible = false;
            this.txtMaxOT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaxOT_KeyDown);
            this.txtMaxOT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxOT_KeyPress);
            // 
            // lbGraceTimeForLateComing
            // 
            this.lbGraceTimeForLateComing.AutoSize = true;
            this.lbGraceTimeForLateComing.Location = new System.Drawing.Point(426, 84);
            this.lbGraceTimeForLateComing.Name = "lbGraceTimeForLateComing";
            this.lbGraceTimeForLateComing.Size = new System.Drawing.Size(158, 15);
            this.lbGraceTimeForLateComing.TabIndex = 233;
            this.lbGraceTimeForLateComing.Text = "Grace Time For Late Coming";
            // 
            // lGraceTimeForEarlyGoing
            // 
            this.lGraceTimeForEarlyGoing.AutoSize = true;
            this.lGraceTimeForEarlyGoing.Location = new System.Drawing.Point(424, 109);
            this.lGraceTimeForEarlyGoing.Name = "lGraceTimeForEarlyGoing";
            this.lGraceTimeForEarlyGoing.Size = new System.Drawing.Size(155, 15);
            this.lGraceTimeForEarlyGoing.TabIndex = 234;
            this.lGraceTimeForEarlyGoing.Text = "Grace Time For Early Going";
            // 
            // lbMinsGTFLC
            // 
            this.lbMinsGTFLC.AutoSize = true;
            this.lbMinsGTFLC.Location = new System.Drawing.Point(691, 85);
            this.lbMinsGTFLC.Name = "lbMinsGTFLC";
            this.lbMinsGTFLC.Size = new System.Drawing.Size(35, 15);
            this.lbMinsGTFLC.TabIndex = 235;
            this.lbMinsGTFLC.Text = "Mins";
            // 
            // lbMinsGTFEG
            // 
            this.lbMinsGTFEG.AutoSize = true;
            this.lbMinsGTFEG.Location = new System.Drawing.Point(692, 108);
            this.lbMinsGTFEG.Name = "lbMinsGTFEG";
            this.lbMinsGTFEG.Size = new System.Drawing.Size(35, 15);
            this.lbMinsGTFEG.TabIndex = 236;
            this.lbMinsGTFEG.Text = "Mins";
            // 
            // txtGraceTimeForLateComing
            // 
            this.txtGraceTimeForLateComing.Location = new System.Drawing.Point(586, 81);
            this.txtGraceTimeForLateComing.Name = "txtGraceTimeForLateComing";
            this.txtGraceTimeForLateComing.Size = new System.Drawing.Size(100, 23);
            this.txtGraceTimeForLateComing.TabIndex = 8;
            this.txtGraceTimeForLateComing.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGraceTimeForLateComing_KeyDown);
            this.txtGraceTimeForLateComing.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGraceTimeForLateComing_KeyPress);
            // 
            // txtGraceTimeForEarlyGoing
            // 
            this.txtGraceTimeForEarlyGoing.Location = new System.Drawing.Point(586, 105);
            this.txtGraceTimeForEarlyGoing.Name = "txtGraceTimeForEarlyGoing";
            this.txtGraceTimeForEarlyGoing.Size = new System.Drawing.Size(100, 23);
            this.txtGraceTimeForEarlyGoing.TabIndex = 9;
            this.txtGraceTimeForEarlyGoing.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGraceTimeForEarlyGoing_KeyDown);
            this.txtGraceTimeForEarlyGoing.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGraceTimeForEarlyGoing_KeyPress);
            // 
            // cmbWeeklyOff2
            // 
            this.cmbWeeklyOff2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWeeklyOff2.Enabled = false;
            this.cmbWeeklyOff2.FormattingEnabled = true;
            this.cmbWeeklyOff2.Location = new System.Drawing.Point(586, 129);
            this.cmbWeeklyOff2.Name = "cmbWeeklyOff2";
            this.cmbWeeklyOff2.Size = new System.Drawing.Size(100, 23);
            this.cmbWeeklyOff2.TabIndex = 13;
            this.cmbWeeklyOff2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbWeeklyOff2_KeyDown);
            // 
            // cb5th
            // 
            this.cb5th.AutoSize = true;
            this.cb5th.Location = new System.Drawing.Point(638, 161);
            this.cb5th.Name = "cb5th";
            this.cb5th.Size = new System.Drawing.Size(44, 19);
            this.cb5th.TabIndex = 18;
            this.cb5th.Text = "5th";
            this.cb5th.UseVisualStyleBackColor = true;
            this.cb5th.CheckedChanged += new System.EventHandler(this.cb5th_CheckedChanged);
            this.cb5th.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb5th_KeyDown);
            // 
            // cb3rd
            // 
            this.cb3rd.AutoSize = true;
            this.cb3rd.Location = new System.Drawing.Point(533, 161);
            this.cb3rd.Name = "cb3rd";
            this.cb3rd.Size = new System.Drawing.Size(45, 19);
            this.cb3rd.TabIndex = 16;
            this.cb3rd.Text = "3rd";
            this.cb3rd.UseVisualStyleBackColor = true;
            this.cb3rd.CheckedChanged += new System.EventHandler(this.cb3rd_CheckedChanged);
            this.cb3rd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb3rd_KeyDown);
            // 
            // cb4th
            // 
            this.cb4th.AutoSize = true;
            this.cb4th.Location = new System.Drawing.Point(586, 161);
            this.cb4th.Name = "cb4th";
            this.cb4th.Size = new System.Drawing.Size(44, 19);
            this.cb4th.TabIndex = 17;
            this.cb4th.Text = "4th";
            this.cb4th.UseVisualStyleBackColor = true;
            this.cb4th.CheckedChanged += new System.EventHandler(this.cb4th_CheckedChanged);
            this.cb4th.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cb4th_KeyDown);
            // 
            // cbConsiderEarlyComingPunch
            // 
            this.cbConsiderEarlyComingPunch.AutoSize = true;
            this.cbConsiderEarlyComingPunch.Location = new System.Drawing.Point(100, 181);
            this.cbConsiderEarlyComingPunch.Name = "cbConsiderEarlyComingPunch";
            this.cbConsiderEarlyComingPunch.Size = new System.Drawing.Size(187, 19);
            this.cbConsiderEarlyComingPunch.TabIndex = 19;
            this.cbConsiderEarlyComingPunch.Text = "Consider Early Coming Punch";
            this.cbConsiderEarlyComingPunch.UseVisualStyleBackColor = true;
            this.cbConsiderEarlyComingPunch.CheckedChanged += new System.EventHandler(this.cbConsiderEarlyComingPunch_CheckedChanged);
            this.cbConsiderEarlyComingPunch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbConsiderEarlyComingPunch_KeyDown);
            // 
            // cbConsiderLateGoingPunch
            // 
            this.cbConsiderLateGoingPunch.AutoSize = true;
            this.cbConsiderLateGoingPunch.Location = new System.Drawing.Point(300, 181);
            this.cbConsiderLateGoingPunch.Name = "cbConsiderLateGoingPunch";
            this.cbConsiderLateGoingPunch.Size = new System.Drawing.Size(172, 19);
            this.cbConsiderLateGoingPunch.TabIndex = 20;
            this.cbConsiderLateGoingPunch.Text = "Consider Late Going Punch";
            this.cbConsiderLateGoingPunch.UseVisualStyleBackColor = true;
            this.cbConsiderLateGoingPunch.CheckedChanged += new System.EventHandler(this.cbConsiderLateGoingPunch_CheckedChanged);
            this.cbConsiderLateGoingPunch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbConsiderLateGoingPunch_KeyDown);
            // 
            // cbDeductBreakHoursFormWorkDuration
            // 
            this.cbDeductBreakHoursFormWorkDuration.AutoSize = true;
            this.cbDeductBreakHoursFormWorkDuration.Location = new System.Drawing.Point(485, 181);
            this.cbDeductBreakHoursFormWorkDuration.Name = "cbDeductBreakHoursFormWorkDuration";
            this.cbDeductBreakHoursFormWorkDuration.Size = new System.Drawing.Size(248, 19);
            this.cbDeductBreakHoursFormWorkDuration.TabIndex = 21;
            this.cbDeductBreakHoursFormWorkDuration.Text = "Deduct Break Hours Form Work Duration";
            this.cbDeductBreakHoursFormWorkDuration.UseVisualStyleBackColor = true;
            this.cbDeductBreakHoursFormWorkDuration.CheckedChanged += new System.EventHandler(this.cbDeductBreakHoursFormWorkDuration_CheckedChanged);
            this.cbDeductBreakHoursFormWorkDuration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDeductBreakHoursFormWorkDuration_KeyDown);
            // 
            // cbCalculateHalfDayifWorkDurationIsLessThan
            // 
            this.cbCalculateHalfDayifWorkDurationIsLessThan.AutoSize = true;
            this.cbCalculateHalfDayifWorkDurationIsLessThan.Location = new System.Drawing.Point(99, 205);
            this.cbCalculateHalfDayifWorkDurationIsLessThan.Name = "cbCalculateHalfDayifWorkDurationIsLessThan";
            this.cbCalculateHalfDayifWorkDurationIsLessThan.Size = new System.Drawing.Size(288, 19);
            this.cbCalculateHalfDayifWorkDurationIsLessThan.TabIndex = 22;
            this.cbCalculateHalfDayifWorkDurationIsLessThan.Text = "Calculate Half Day if Work Duration Is less than";
            this.cbCalculateHalfDayifWorkDurationIsLessThan.UseVisualStyleBackColor = true;
            this.cbCalculateHalfDayifWorkDurationIsLessThan.CheckedChanged += new System.EventHandler(this.cbCalculateHalfDayifWorkDurationIsLessThan_CheckedChanged);
            this.cbCalculateHalfDayifWorkDurationIsLessThan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbCalculateHalfDayifWorkDurationIslessthan_KeyDown);
            // 
            // cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan
            // 
            this.cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan.AutoSize = true;
            this.cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan.Location = new System.Drawing.Point(99, 255);
            this.cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan.Name = "cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan";
            this.cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan.Size = new System.Drawing.Size(371, 19);
            this.cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan.TabIndex = 26;
            this.cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan.Text = "On Partial Day Calculate Half Day if Work Duration is less than";
            this.cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan.UseVisualStyleBackColor = true;
            this.cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan.CheckedChanged += new System.EventHandler(this.cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan_CheckedChanged);
            this.cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan_KeyDown);
            // 
            // cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan
            // 
            this.cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan.AutoSize = true;
            this.cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan.Location = new System.Drawing.Point(99, 280);
            this.cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan.Name = "cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan";
            this.cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan.Size = new System.Drawing.Size(385, 19);
            this.cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan.TabIndex = 27;
            this.cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan.Text = "On Partial Day Calculate Absent Day if Work Duration is less than";
            this.cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan.UseVisualStyleBackColor = true;
            this.cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan.CheckedChanged += new System.EventHandler(this.cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan_CheckedChanged);
            this.cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbOnPartialDayCalculateAbsentDayifWorkDurationislessthan_KeyDown);
            // 
            // cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent
            // 
            this.cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent.AutoSize = true;
            this.cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent.Location = new System.Drawing.Point(99, 306);
            this.cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent.Name = "cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent";
            this.cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent.Size = new System.Drawing.Size(366, 19);
            this.cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent.TabIndex = 28;
            this.cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent.Text = "Mark Weekly Off and Holiday as Absent if Prefix Day is Absent";
            this.cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent.UseVisualStyleBackColor = true;
            this.cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent.CheckedChanged += new System.EventHandler(this.cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent_CheckedChanged);
            this.cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent_KeyDown);
            // 
            // cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent
            // 
            this.cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent.AutoSize = true;
            this.cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent.Location = new System.Drawing.Point(99, 329);
            this.cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent.Name = "cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent";
            this.cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent.Size = new System.Drawing.Size(365, 19);
            this.cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent.TabIndex = 29;
            this.cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent.Text = "Mark Weekly Off and Holiday as Absent if Suffix Day is Absent";
            this.cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent.UseVisualStyleBackColor = true;
            this.cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent.CheckedChanged += new System.EventHandler(this.cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent_CheckedChanged);
            this.cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent_KeyDown);
            // 
            // cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent
            // 
            this.cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent.AutoSize = true;
            this.cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent.Location = new System.Drawing.Point(99, 354);
            this.cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent.Name = "cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent";
            this.cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent.Size = new System.Drawing.Size(454, 19);
            this.cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent.TabIndex = 30;
            this.cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent.Text = "Mark Weekly Off and Holiday as Absent if Both Prefix and Suffix Day is Absent ";
            this.cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent.UseVisualStyleBackColor = true;
            this.cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent.CheckedChanged += new System.EventHandler(this.cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent_CheckedChanged);
            this.cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent_KeyDown);
            // 
            // cbMark
            // 
            this.cbMark.AutoSize = true;
            this.cbMark.Location = new System.Drawing.Point(99, 378);
            this.cbMark.Name = "cbMark";
            this.cbMark.Size = new System.Drawing.Size(55, 19);
            this.cbMark.TabIndex = 31;
            this.cbMark.Text = "Mark";
            this.cbMark.UseVisualStyleBackColor = true;
            this.cbMark.CheckedChanged += new System.EventHandler(this.cbMark_CheckedChanged);
            this.cbMark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMark_KeyDown);
            // 
            // cbMarkHalfDayifLateBy
            // 
            this.cbMarkHalfDayifLateBy.AutoSize = true;
            this.cbMarkHalfDayifLateBy.Location = new System.Drawing.Point(99, 404);
            this.cbMarkHalfDayifLateBy.Name = "cbMarkHalfDayifLateBy";
            this.cbMarkHalfDayifLateBy.Size = new System.Drawing.Size(156, 19);
            this.cbMarkHalfDayifLateBy.TabIndex = 34;
            this.cbMarkHalfDayifLateBy.Text = "Mark Half Day if late by";
            this.cbMarkHalfDayifLateBy.UseVisualStyleBackColor = true;
            this.cbMarkHalfDayifLateBy.Visible = false;
            this.cbMarkHalfDayifLateBy.CheckedChanged += new System.EventHandler(this.cbMarkHalfDayifLateBy_CheckedChanged);
            this.cbMarkHalfDayifLateBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMarkHalfDayiflateby_KeyDown);
            // 
            // cbMarkHalfDayifEarlyGoingBy
            // 
            this.cbMarkHalfDayifEarlyGoingBy.AutoSize = true;
            this.cbMarkHalfDayifEarlyGoingBy.Location = new System.Drawing.Point(99, 429);
            this.cbMarkHalfDayifEarlyGoingBy.Name = "cbMarkHalfDayifEarlyGoingBy";
            this.cbMarkHalfDayifEarlyGoingBy.Size = new System.Drawing.Size(198, 19);
            this.cbMarkHalfDayifEarlyGoingBy.TabIndex = 35;
            this.cbMarkHalfDayifEarlyGoingBy.Text = "Mark Half Day if early Going by";
            this.cbMarkHalfDayifEarlyGoingBy.UseVisualStyleBackColor = true;
            this.cbMarkHalfDayifEarlyGoingBy.CheckedChanged += new System.EventHandler(this.cbMarkHalfDayifEarlyGoingBy_CheckedChanged);
            this.cbMarkHalfDayifEarlyGoingBy.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbMarkHalfDayifEarlyGoingby_KeyDown);
            // 
            // txtCalculateHalfDayifWorkDurationIsLessThanMins
            // 
            this.txtCalculateHalfDayifWorkDurationIsLessThanMins.Enabled = false;
            this.txtCalculateHalfDayifWorkDurationIsLessThanMins.Location = new System.Drawing.Point(392, 204);
            this.txtCalculateHalfDayifWorkDurationIsLessThanMins.Name = "txtCalculateHalfDayifWorkDurationIsLessThanMins";
            this.txtCalculateHalfDayifWorkDurationIsLessThanMins.Size = new System.Drawing.Size(70, 23);
            this.txtCalculateHalfDayifWorkDurationIsLessThanMins.TabIndex = 23;
            this.txtCalculateHalfDayifWorkDurationIsLessThanMins.TextChanged += new System.EventHandler(this.txtCalculateHalfDayifWorkDurationIsLessThanMins_TextChanged);
            this.txtCalculateHalfDayifWorkDurationIsLessThanMins.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCalculateHalfDayifWorkDurationIslessThan_KeyDown);
            this.txtCalculateHalfDayifWorkDurationIsLessThanMins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalculateHalfDayifWorkDurationIsLessThanMins_KeyPress);
            // 
            // txtCalculationAbsentIfWorkDurationIsLessThanMins
            // 
            this.txtCalculationAbsentIfWorkDurationIsLessThanMins.Enabled = false;
            this.txtCalculationAbsentIfWorkDurationIsLessThanMins.Location = new System.Drawing.Point(392, 228);
            this.txtCalculationAbsentIfWorkDurationIsLessThanMins.Name = "txtCalculationAbsentIfWorkDurationIsLessThanMins";
            this.txtCalculationAbsentIfWorkDurationIsLessThanMins.Size = new System.Drawing.Size(70, 23);
            this.txtCalculationAbsentIfWorkDurationIsLessThanMins.TabIndex = 25;
            this.txtCalculationAbsentIfWorkDurationIsLessThanMins.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCalculationAbsentifWorkDurationislessThan_KeyDown);
            this.txtCalculationAbsentIfWorkDurationIsLessThanMins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalculationAbsentIfWorkDurationIsLessThanMins_KeyPress);
            // 
            // txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins
            // 
            this.txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.Enabled = false;
            this.txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.Location = new System.Drawing.Point(483, 255);
            this.txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.Name = "txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins";
            this.txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.Size = new System.Drawing.Size(70, 23);
            this.txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.TabIndex = 0;
            this.txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.TabStop = false;
            this.txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOnPartialDayCalculateHalfDayifWorkDurationislessthan_KeyDown);
            this.txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins_KeyPress);
            // 
            // txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins
            // 
            this.txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.Enabled = false;
            this.txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.Location = new System.Drawing.Point(483, 279);
            this.txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.Name = "txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins";
            this.txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.Size = new System.Drawing.Size(70, 23);
            this.txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.TabIndex = 0;
            this.txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.TabStop = false;
            this.txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOnPartialDayCalculateAbsentDayifWorkDurationislessthan_KeyDown);
            this.txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins_KeyPress);
            // 
            // txtMarkHalfDayifLateByMins
            // 
            this.txtMarkHalfDayifLateByMins.Enabled = false;
            this.txtMarkHalfDayifLateByMins.Location = new System.Drawing.Point(258, 402);
            this.txtMarkHalfDayifLateByMins.Name = "txtMarkHalfDayifLateByMins";
            this.txtMarkHalfDayifLateByMins.Size = new System.Drawing.Size(70, 23);
            this.txtMarkHalfDayifLateByMins.TabIndex = 0;
            this.txtMarkHalfDayifLateByMins.TabStop = false;
            this.txtMarkHalfDayifLateByMins.Visible = false;
            this.txtMarkHalfDayifLateByMins.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMarkHalfDayiflateby_KeyDown);
            this.txtMarkHalfDayifLateByMins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarkHalfDayifLateByMins_KeyPress);
            // 
            // txtMarkHalfDayifEarlyGoingByMins
            // 
            this.txtMarkHalfDayifEarlyGoingByMins.Enabled = false;
            this.txtMarkHalfDayifEarlyGoingByMins.Location = new System.Drawing.Point(297, 426);
            this.txtMarkHalfDayifEarlyGoingByMins.Name = "txtMarkHalfDayifEarlyGoingByMins";
            this.txtMarkHalfDayifEarlyGoingByMins.Size = new System.Drawing.Size(70, 23);
            this.txtMarkHalfDayifEarlyGoingByMins.TabIndex = 0;
            this.txtMarkHalfDayifEarlyGoingByMins.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMarkHalfDayifEarlyGoingByMins_KeyPress);
            // 
            // lbAbsentWhenLateFor
            // 
            this.lbAbsentWhenLateFor.AutoSize = true;
            this.lbAbsentWhenLateFor.Location = new System.Drawing.Point(230, 380);
            this.lbAbsentWhenLateFor.Name = "lbAbsentWhenLateFor";
            this.lbAbsentWhenLateFor.Size = new System.Drawing.Size(125, 15);
            this.lbAbsentWhenLateFor.TabIndex = 264;
            this.lbAbsentWhenLateFor.Text = "Absent When Late For";
            // 
            // lbMinsAbsentWhenLateFor
            // 
            this.lbMinsAbsentWhenLateFor.AutoSize = true;
            this.lbMinsAbsentWhenLateFor.Location = new System.Drawing.Point(425, 380);
            this.lbMinsAbsentWhenLateFor.Name = "lbMinsAbsentWhenLateFor";
            this.lbMinsAbsentWhenLateFor.Size = new System.Drawing.Size(34, 15);
            this.lbMinsAbsentWhenLateFor.TabIndex = 265;
            this.lbMinsAbsentWhenLateFor.Text = "Days";
            // 
            // lbMinsMarkHalfDayiflateby
            // 
            this.lbMinsMarkHalfDayiflateby.AutoSize = true;
            this.lbMinsMarkHalfDayiflateby.Location = new System.Drawing.Point(332, 406);
            this.lbMinsMarkHalfDayiflateby.Name = "lbMinsMarkHalfDayiflateby";
            this.lbMinsMarkHalfDayiflateby.Size = new System.Drawing.Size(35, 15);
            this.lbMinsMarkHalfDayiflateby.TabIndex = 266;
            this.lbMinsMarkHalfDayiflateby.Text = "Mins";
            this.lbMinsMarkHalfDayiflateby.Visible = false;
            // 
            // lbMinsMarkHalfDayifearlyGoingby
            // 
            this.lbMinsMarkHalfDayifearlyGoingby.AutoSize = true;
            this.lbMinsMarkHalfDayifearlyGoingby.Location = new System.Drawing.Point(371, 433);
            this.lbMinsMarkHalfDayifearlyGoingby.Name = "lbMinsMarkHalfDayifearlyGoingby";
            this.lbMinsMarkHalfDayifearlyGoingby.Size = new System.Drawing.Size(35, 15);
            this.lbMinsMarkHalfDayifearlyGoingby.TabIndex = 267;
            this.lbMinsMarkHalfDayifearlyGoingby.Text = "Mins";
            // 
            // lbMinsCalculateHalfDayifWorkDurationIslessThan
            // 
            this.lbMinsCalculateHalfDayifWorkDurationIslessThan.AutoSize = true;
            this.lbMinsCalculateHalfDayifWorkDurationIslessThan.Location = new System.Drawing.Point(467, 208);
            this.lbMinsCalculateHalfDayifWorkDurationIslessThan.Name = "lbMinsCalculateHalfDayifWorkDurationIslessThan";
            this.lbMinsCalculateHalfDayifWorkDurationIslessThan.Size = new System.Drawing.Size(35, 15);
            this.lbMinsCalculateHalfDayifWorkDurationIslessThan.TabIndex = 268;
            this.lbMinsCalculateHalfDayifWorkDurationIslessThan.Text = "Mins";
            // 
            // lbMinsCalculationAbsentifWorkDurationislessThan
            // 
            this.lbMinsCalculationAbsentifWorkDurationislessThan.AutoSize = true;
            this.lbMinsCalculationAbsentifWorkDurationislessThan.Location = new System.Drawing.Point(467, 232);
            this.lbMinsCalculationAbsentifWorkDurationislessThan.Name = "lbMinsCalculationAbsentifWorkDurationislessThan";
            this.lbMinsCalculationAbsentifWorkDurationislessThan.Size = new System.Drawing.Size(35, 15);
            this.lbMinsCalculationAbsentifWorkDurationislessThan.TabIndex = 269;
            this.lbMinsCalculationAbsentifWorkDurationislessThan.Text = "Mins";
            // 
            // lbMinsOnPartialDayCalculateHalfDayifWorkDurationislessthan
            // 
            this.lbMinsOnPartialDayCalculateHalfDayifWorkDurationislessthan.AutoSize = true;
            this.lbMinsOnPartialDayCalculateHalfDayifWorkDurationislessthan.Location = new System.Drawing.Point(556, 260);
            this.lbMinsOnPartialDayCalculateHalfDayifWorkDurationislessthan.Name = "lbMinsOnPartialDayCalculateHalfDayifWorkDurationislessthan";
            this.lbMinsOnPartialDayCalculateHalfDayifWorkDurationislessthan.Size = new System.Drawing.Size(35, 15);
            this.lbMinsOnPartialDayCalculateHalfDayifWorkDurationislessthan.TabIndex = 270;
            this.lbMinsOnPartialDayCalculateHalfDayifWorkDurationislessthan.Text = "Mins";
            // 
            // lbMinsOnPartialDayCalculateAbsentDayifWorkDurationislessthan
            // 
            this.lbMinsOnPartialDayCalculateAbsentDayifWorkDurationislessthan.AutoSize = true;
            this.lbMinsOnPartialDayCalculateAbsentDayifWorkDurationislessthan.Location = new System.Drawing.Point(556, 283);
            this.lbMinsOnPartialDayCalculateAbsentDayifWorkDurationislessthan.Name = "lbMinsOnPartialDayCalculateAbsentDayifWorkDurationislessthan";
            this.lbMinsOnPartialDayCalculateAbsentDayifWorkDurationislessthan.Size = new System.Drawing.Size(35, 15);
            this.lbMinsOnPartialDayCalculateAbsentDayifWorkDurationislessthan.TabIndex = 271;
            this.lbMinsOnPartialDayCalculateAbsentDayifWorkDurationislessthan.Text = "Mins";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(708, 466);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(163, 23);
            this.txtSearch.TabIndex = 40;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(657, 470);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(47, 15);
            this.lbSearch.TabIndex = 278;
            this.lbSearch.Text = "Search ";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Location = new System.Drawing.Point(17, 477);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(73, 15);
            this.lblTotalCount.TabIndex = 277;
            this.lblTotalCount.Text = "Total Count-";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(534, 460);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 30);
            this.btnExit.TabIndex = 39;
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
            this.btnDelete.Location = new System.Drawing.Point(451, 460);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 38;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.dataGridView1.Location = new System.Drawing.Point(14, 494);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(866, 187);
            this.dataGridView1.TabIndex = 41;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(368, 460);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 30);
            this.btnClear.TabIndex = 37;
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
            this.btnSave.Location = new System.Drawing.Point(285, 460);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 36;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbMarkValue
            // 
            this.cmbMarkValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarkValue.Enabled = false;
            this.cmbMarkValue.FormattingEnabled = true;
            this.cmbMarkValue.Items.AddRange(new object[] {
            "Half Day",
            "Full Day"});
            this.cmbMarkValue.Location = new System.Drawing.Point(157, 376);
            this.cmbMarkValue.Name = "cmbMarkValue";
            this.cmbMarkValue.Size = new System.Drawing.Size(68, 23);
            this.cmbMarkValue.TabIndex = 32;
            this.cmbMarkValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbMark_KeyDown);
            // 
            // cmbAbsentWhenLateForValue
            // 
            this.cmbAbsentWhenLateForValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAbsentWhenLateForValue.Enabled = false;
            this.cmbAbsentWhenLateForValue.FormattingEnabled = true;
            this.cmbAbsentWhenLateForValue.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbAbsentWhenLateForValue.Location = new System.Drawing.Point(359, 376);
            this.cmbAbsentWhenLateForValue.Name = "cmbAbsentWhenLateForValue";
            this.cmbAbsentWhenLateForValue.Size = new System.Drawing.Size(64, 23);
            this.cmbAbsentWhenLateForValue.TabIndex = 33;
            this.cmbAbsentWhenLateForValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAbsentWhenLateFor_KeyDown);
            // 
            // cbCalculationAbsentIfWorkDurationIsLessThan
            // 
            this.cbCalculationAbsentIfWorkDurationIsLessThan.AutoSize = true;
            this.cbCalculationAbsentIfWorkDurationIsLessThan.Location = new System.Drawing.Point(99, 230);
            this.cbCalculationAbsentIfWorkDurationIsLessThan.Name = "cbCalculationAbsentIfWorkDurationIsLessThan";
            this.cbCalculationAbsentIfWorkDurationIsLessThan.Size = new System.Drawing.Size(292, 19);
            this.cbCalculationAbsentIfWorkDurationIsLessThan.TabIndex = 280;
            this.cbCalculationAbsentIfWorkDurationIsLessThan.Text = "Calculation Absent If Work Duration Is Less Than";
            this.cbCalculationAbsentIfWorkDurationIsLessThan.UseVisualStyleBackColor = true;
            this.cbCalculationAbsentIfWorkDurationIsLessThan.CheckedChanged += new System.EventHandler(this.cbCalculationAbsentIfWorkDurationIsLessThan_CheckedChanged);
            // 
            // CategoryMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(895, 693);
            this.ControlBox = false;
            this.Controls.Add(this.cbCalculationAbsentIfWorkDurationIsLessThan);
            this.Controls.Add(this.cmbAbsentWhenLateForValue);
            this.Controls.Add(this.cmbMarkValue);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lbSearch);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbMinsOnPartialDayCalculateAbsentDayifWorkDurationislessthan);
            this.Controls.Add(this.lbMinsOnPartialDayCalculateHalfDayifWorkDurationislessthan);
            this.Controls.Add(this.lbMinsCalculationAbsentifWorkDurationislessThan);
            this.Controls.Add(this.lbMinsCalculateHalfDayifWorkDurationIslessThan);
            this.Controls.Add(this.lbMinsMarkHalfDayifearlyGoingby);
            this.Controls.Add(this.lbMinsMarkHalfDayiflateby);
            this.Controls.Add(this.lbMinsAbsentWhenLateFor);
            this.Controls.Add(this.lbAbsentWhenLateFor);
            this.Controls.Add(this.txtMarkHalfDayifEarlyGoingByMins);
            this.Controls.Add(this.txtMarkHalfDayifLateByMins);
            this.Controls.Add(this.txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins);
            this.Controls.Add(this.txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins);
            this.Controls.Add(this.txtCalculationAbsentIfWorkDurationIsLessThanMins);
            this.Controls.Add(this.txtCalculateHalfDayifWorkDurationIsLessThanMins);
            this.Controls.Add(this.cbMarkHalfDayifEarlyGoingBy);
            this.Controls.Add(this.cbMarkHalfDayifLateBy);
            this.Controls.Add(this.cbMark);
            this.Controls.Add(this.cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent);
            this.Controls.Add(this.cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent);
            this.Controls.Add(this.cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent);
            this.Controls.Add(this.cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan);
            this.Controls.Add(this.cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan);
            this.Controls.Add(this.cbCalculateHalfDayifWorkDurationIsLessThan);
            this.Controls.Add(this.cbDeductBreakHoursFormWorkDuration);
            this.Controls.Add(this.cbConsiderLateGoingPunch);
            this.Controls.Add(this.cbConsiderEarlyComingPunch);
            this.Controls.Add(this.cb4th);
            this.Controls.Add(this.cb3rd);
            this.Controls.Add(this.cb5th);
            this.Controls.Add(this.cmbWeeklyOff2);
            this.Controls.Add(this.txtGraceTimeForEarlyGoing);
            this.Controls.Add(this.txtGraceTimeForLateComing);
            this.Controls.Add(this.lbMinsGTFEG);
            this.Controls.Add(this.lbMinsGTFLC);
            this.Controls.Add(this.lGraceTimeForEarlyGoing);
            this.Controls.Add(this.lbGraceTimeForLateComing);
            this.Controls.Add(this.txtMaxOT);
            this.Controls.Add(this.cmbWeeklyOff1);
            this.Controls.Add(this.cb2nd);
            this.Controls.Add(this.cbWeeklyOff2);
            this.Controls.Add(this.cbMaxOT);
            this.Controls.Add(this.cb1st);
            this.Controls.Add(this.cbWeeklyOff1);
            this.Controls.Add(this.cbNeglectLastInPunchForMissedOutPunch);
            this.Controls.Add(this.cbConsiderOnlyFirstAndLastPunchInAttCalculations);
            this.Controls.Add(this.cmbOTFormula);
            this.Controls.Add(this.txtMinOT);
            this.Controls.Add(this.txtCategoryName);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.lbMinOT);
            this.Controls.Add(this.lbMins);
            this.Controls.Add(this.lbOTFormula);
            this.Controls.Add(this.lbShortName);
            this.Controls.Add(this.LbCategoryName);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CategoryMaster";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Category_Master_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label LbCategoryName;
        private System.Windows.Forms.Label lbShortName;
        private System.Windows.Forms.Label lbOTFormula;
        private System.Windows.Forms.Label lbMins;
        private System.Windows.Forms.Label lbMinOT;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.TextBox txtMinOT;
        private System.Windows.Forms.ComboBox cmbOTFormula;
        private System.Windows.Forms.CheckBox cbConsiderOnlyFirstAndLastPunchInAttCalculations;
        private System.Windows.Forms.CheckBox cbNeglectLastInPunchForMissedOutPunch;
        private System.Windows.Forms.CheckBox cbWeeklyOff1;
        private System.Windows.Forms.CheckBox cb1st;
        private System.Windows.Forms.CheckBox cbMaxOT;
        private System.Windows.Forms.CheckBox cbWeeklyOff2;
        private System.Windows.Forms.CheckBox cb2nd;
        private System.Windows.Forms.ComboBox cmbWeeklyOff1;
        private System.Windows.Forms.TextBox txtMaxOT;
        private System.Windows.Forms.Label lbGraceTimeForLateComing;
        private System.Windows.Forms.Label lGraceTimeForEarlyGoing;
        private System.Windows.Forms.Label lbMinsGTFLC;
        private System.Windows.Forms.Label lbMinsGTFEG;
        private System.Windows.Forms.TextBox txtGraceTimeForLateComing;
        private System.Windows.Forms.TextBox txtGraceTimeForEarlyGoing;
        private System.Windows.Forms.ComboBox cmbWeeklyOff2;
        private System.Windows.Forms.CheckBox cb5th;
        private System.Windows.Forms.CheckBox cb3rd;
        private System.Windows.Forms.CheckBox cb4th;
        private System.Windows.Forms.CheckBox cbConsiderEarlyComingPunch;
        private System.Windows.Forms.CheckBox cbConsiderLateGoingPunch;
        private System.Windows.Forms.CheckBox cbDeductBreakHoursFormWorkDuration;
        private System.Windows.Forms.CheckBox cbCalculateHalfDayifWorkDurationIsLessThan;
       
        private System.Windows.Forms.CheckBox cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan;
        private System.Windows.Forms.CheckBox cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan;
        private System.Windows.Forms.CheckBox cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent;
        private System.Windows.Forms.CheckBox cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent;
        private System.Windows.Forms.CheckBox cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent;
        private System.Windows.Forms.CheckBox cbMark;
        private System.Windows.Forms.CheckBox cbMarkHalfDayifLateBy;
        private System.Windows.Forms.CheckBox cbMarkHalfDayifEarlyGoingBy;
        private System.Windows.Forms.TextBox txtCalculateHalfDayifWorkDurationIsLessThanMins;
        private System.Windows.Forms.TextBox txtCalculationAbsentIfWorkDurationIsLessThanMins;
        private System.Windows.Forms.TextBox txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins;
        private System.Windows.Forms.TextBox txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins;
        private System.Windows.Forms.TextBox txtMarkHalfDayifLateByMins;
        private System.Windows.Forms.TextBox txtMarkHalfDayifEarlyGoingByMins;
        private System.Windows.Forms.Label lbAbsentWhenLateFor;
        private System.Windows.Forms.Label lbMinsAbsentWhenLateFor;
        private System.Windows.Forms.Label lbMinsMarkHalfDayiflateby;
        private System.Windows.Forms.Label lbMinsMarkHalfDayifearlyGoingby;
        private System.Windows.Forms.Label lbMinsCalculateHalfDayifWorkDurationIslessThan;
        private System.Windows.Forms.Label lbMinsCalculationAbsentifWorkDurationislessThan;
        private System.Windows.Forms.Label lbMinsOnPartialDayCalculateHalfDayifWorkDurationislessthan;
        private System.Windows.Forms.Label lbMinsOnPartialDayCalculateAbsentDayifWorkDurationislessthan;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbSearch;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbMarkValue;
        private System.Windows.Forms.ComboBox cmbAbsentWhenLateForValue;
        private System.Windows.Forms.CheckBox cbCalculationAbsentIfWorkDurationIsLessThan;
    }
}