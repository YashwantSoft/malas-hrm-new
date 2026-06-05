using BusinessLayerUtility;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.Master
{
    public partial class CategoryMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        //int CategoryId = 0, ConsiderEarlyPunch = 0, ConsiderLatePunch = 0, SundayWeeklyOff = 0, SaturdayWeeklyOff = 0, CalculateHalfDay = 0, CalculateAbsentDay = 0, TransferHPintoCompOff = 0, TransferWOPintoCompOff = 0;
        //int DeductBreakHours = 0, ForMissedPunch = 0, RecordStatus = 0, MarkWOandHAsAbsent = 0, MarkAsAbsentForLate = 0, ContiousLateDay = 0;
        //int MarkWOandHAsPreDayAbsent = 0, PCalculateHalfDay = 0, PCalculateAbsentDay = 0, MarkWOandHAsBothDayAbsent = 0, MarkHalfDayForLate = 0, MarkHalfdayForEarlyGoing = 0, ConsiderFirstLastPunch = 0;

        //string CategoryFName = string.Empty, CategorySName = string.Empty, OTFormula = string.Empty, MinOT = string.Empty;
        //string GraceTime = string.Empty, WhichSaturday = string.Empty, HalfDayMins = string.Empty, AbsentDayMins = string.Empty;
        //string AbsentDayType = string.Empty, EarlyGoingGraceTime = string.Empty, MaxOT = string.Empty, PHalfDayMins = string.Empty, PAbsentDayMins = string.Empty, HalfDayLateByMins = string.Empty, HalfDayEarlyGoingMins = string.Empty;

        public CategoryMaster()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_CATEGORYMASTER);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);

            objRL.ColumnNameCM = "OTFormula";
            objRL.Fill_ComboBox_Comman(cmbOTFormula);

            objRL.ColumnNameCM = "WeekDays";
            objRL.Fill_ComboBox_Comman(cmbWeeklyOff1);
            objRL.Fill_ComboBox_Comman(cmbWeeklyOff2);

        }

        private void Category_Master_Load(object sender, EventArgs e)
        {
            FillGrid();
            ClearAll();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        private void ClearAll()
        {
            objEP.Clear();
            FlagDelete = false;
            txtCategoryName.Text = "";
            txtShortName.Text = "";
            cmbOTFormula.SelectedIndex = -1;
            txtMinOT.Text = "";
            cbMaxOT.Checked = false;
            txtMaxOT.Text = "";
            cbConsiderOnlyFirstAndLastPunchInAttCalculations.Checked = false;
            cbNeglectLastInPunchForMissedOutPunch.Checked = false;
            txtGraceTimeForLateComing.Text = "";
            txtGraceTimeForEarlyGoing.Text = "";
            cbWeeklyOff1.Checked = false;
            cmbWeeklyOff1.Text = "";
            cbWeeklyOff2.Checked = false;
            cmbWeeklyOff2.Text = "";
            cb1st.Checked = false;
            cb2nd.Checked = false;
            cb3rd.Checked = false;
            cb4th.Checked = false;
            cb5th.Checked = false;
            cbConsiderEarlyComingPunch.Checked = false;
            cbConsiderLateGoingPunch.Checked = false;
            cbDeductBreakHoursFormWorkDuration.Checked = false;
            cbCalculateHalfDayifWorkDurationIsLessThan.Checked = false;
            txtCalculateHalfDayifWorkDurationIsLessThanMins.Text = "";

            txtCalculationAbsentIfWorkDurationIsLessThanMins.Text = "";
            cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan.Checked = false;
            txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.Text = "";
            cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan.Checked = false;
            txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.Text = "";
            cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent.Checked = false;
            cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent.Checked = false;
            cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent.Checked = false;
            cbMark.Checked = false;
            cmbMarkValue.Text = "";
            cmbAbsentWhenLateForValue.Text = "";
            cbMarkHalfDayifLateBy.Checked = false;
            txtMarkHalfDayifLateByMins.Text = "";
            cbMarkHalfDayifEarlyGoingBy.Checked = false;
            txtMarkHalfDayifEarlyGoingByMins.Text = "";
            TableId = 0;
            txtCategoryName.Text = "";
            txtShortName.Text = "";
            txtMinOT.Text = "";
            MaxOTCheck = 0;
            txtMaxOT.Text = "";
            ConsiderOnlyFirstAndLastPunchInAttCalculations = 0;
            txtGraceTimeForLateComing.Text = "";
            NeglectLastInPunchForMissedOutPunch = 0;
            txtGraceTimeForEarlyGoing.Text = "";
            WeeklyOff1 = 0;
            cmbWeeklyOff1.SelectedIndex = -1;
            WeeklyOff2 = 0;
            cmbWeeklyOff2.SelectedIndex = -1;
            FirstST = 0;
            Second = 0;
            Third = 0;
            Forth = 0;
            Fifth = 0;
            ConsiderEarlyComingPunch = 0;
            ConsiderLateGoingPunch = 0;
            DeductBreakHoursFormWorkDuration = 0;
            CalculateHalfDayifWorkDurationIsLessThan = 0;
            txtCalculateHalfDayifWorkDurationIsLessThanMins.Text = "";
            CalculationAbsentIfWorkDurationIsLessThan = 0;
            txtCalculationAbsentIfWorkDurationIsLessThanMins.Text = "";
            OnPartialDayCalculateHalfDayifWorkDurationisLessthan = 0;
            txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.Text = "";
            OnPartialDayCalculateAbsentDayifWorkDurationislessThan = 0;
            txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.Text = "";
            MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent = 0;
            MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent = 0;
            MarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent = 0;
            Mark = 0;
            cmbMarkValue.Text = "";
            cmbAbsentWhenLateForValue.Text = "";
            MarkHalfDayifLateBy = 0;
            txtMarkHalfDayifLateByMins.Text = "";
            MarkHalfDayifEarlyGoingBy = 0;
            txtMarkHalfDayifEarlyGoingByMins.Text = "";
            FlagDelete = false;
            btnDelete.Enabled = false;
            //CategoryFName = string.Empty; CategorySName = string.Empty; OTFormula = string.Empty; MinOT = string.Empty;
            //GraceTime = string.Empty; WeeklyOff1 = string.Empty; WeeklyOff2 = string.Empty; WhichSaturday = string.Empty; HalfDayMins = string.Empty; AbsentDayMins = string.Empty;
            //AbsentDayType = string.Empty; EarlyGoingGraceTime = string.Empty; MaxOT = string.Empty; PHalfDayMins = string.Empty; PAbsentDayMins = string.Empty; HalfDayLateByMins = string.Empty; HalfDayEarlyGoingMins = string.Empty;

            //CategoryId = 0; ConsiderEarlyPunch = 0; ConsiderLatePunch = 0; SundayWeeklyOff = 0; SaturdayWeeklyOff = 0; CalculateHalfDay = 0; CalculateAbsentDay = 0; TransferHPintoCompOff = 0; TransferWOPintoCompOff = 0;
            //DeductBreakHours = 0; ForMissedPunch = 0; RecordStatus = 0; MarkWOandHAsAbsent = 0; MarkAsAbsentForLate = 0; ContiousLateDay = 0;
            //MarkWOandHAsPreDayAbsent = 0; PCalculateHalfDay = 0; PCalculateAbsentDay = 0; MarkWOandHAsBothDayAbsent = 0; MarkHalfDayForLate = 0; MarkHalfdayForEarlyGoing = 0; ConsiderFirstLastPunch = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void txtCategoryName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtShortName.Focus();

        }

        private void txtShortName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbOTFormula.Focus();

        }

        private void cmbOTFormula_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMinOT.Focus();
        }

        private void txtMinOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbMaxOT.Focus();
        }

        private void cbMaxOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMaxOT.Focus();
        }

        private void txtMaxOT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbConsiderOnlyFirstAndLastPunchInAttCalculations.Focus();
        }

        private void cbConsiderOnlyFirstAndLastPunchInAttCalculations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbNeglectLastInPunchForMissedOutPunch.Focus();
        }

        private void cbNeglectLastInPunchForMissedOutPunch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtGraceTimeForLateComing.Focus();
        }

        private void txtGraceTimeForLateComing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtGraceTimeForEarlyGoing.Focus();
        }

        private void txtGraceTimeForEarlyGoing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbWeeklyOff1.Focus();
        }

        private void cbWeeklyOff1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbWeeklyOff1.Focus();
        }

        private void cmbWeeklyOff1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbWeeklyOff2.Focus();
        }

        private void cbWeeklyOff2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbWeeklyOff2.Focus();
        }

        private void cmbWeeklyOff2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cb1st.Focus();
        }

        private void cb1st_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cb2nd.Focus();
        }

        private void cb2nd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cb3rd.Focus();
        }

        private void cb3rd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cb4th.Focus();
        }

        private void cb4th_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cb5th.Focus();
        }

        private void cb5th_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbConsiderEarlyComingPunch.Focus();
        }

        private void cbConsiderEarlyComingPunch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbConsiderLateGoingPunch.Focus();
        }

        private void cbConsiderLateGoingPunch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbDeductBreakHoursFormWorkDuration.Focus();
        }

        private void cbDeductBreakHoursFormWorkDuration_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbCalculateHalfDayifWorkDurationIsLessThan.Focus();
        }

        private void cbCalculateHalfDayifWorkDurationIslessthan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCalculateHalfDayifWorkDurationIsLessThanMins.Focus();
        }

        private void txtCalculateHalfDayifWorkDurationIslessThan_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCalculationAbsentifWorkDurationislessThan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan.Focus();
        }

        private void cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.Focus();
        }

        private void txtOnPartialDayCalculateHalfDayifWorkDurationislessthan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan.Focus();
        }

        private void cbOnPartialDayCalculateAbsentDayifWorkDurationislessthan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.Focus();
        }

        private void txtOnPartialDayCalculateAbsentDayifWorkDurationislessthan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent.Focus();
        }

        private void cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent.Focus();
        }

        private void cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent.Focus();
        }

        private void cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbMark.Focus();
        }

        private void cbMark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbMarkValue.Focus();
        }

        private void cmbMark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbAbsentWhenLateForValue.Focus();
        }

        private void cmbAbsentWhenLateFor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbMarkHalfDayifLateBy.Focus();
        }

        private void cbMarkHalfDayiflateby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMarkHalfDayifLateByMins.Focus();
        }

        private void txtMarkHalfDayiflateby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbMarkHalfDayifEarlyGoingBy.Focus();
        }

        private void cbMarkHalfDayifEarlyGoingby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMarkHalfDayifEarlyGoingByMins.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (objPC.AddFlag == 1)
            {
                try
                {
                    FlagDelete = false;
                    SaveDB();
                }
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
        }

        private bool Validation()
        {
            if (txtCategoryName.Text == "")
            {
                txtCategoryName.Focus();
                objEP.SetError(txtCategoryName, " Enter Category Name");
                return true;
            }
            else if (txtShortName.Text == "")
            {
                txtShortName.Focus();
                objEP.SetError(txtShortName, " Enter Short Name");
                return true;
            }
            else if (cmbOTFormula.SelectedIndex == -1)
            {
                cmbOTFormula.Focus();
                objEP.SetError(cmbOTFormula, "Select OT Formula");
                return true;
            }
            else
                return false;
        }

        protected bool CheckExist()
        {
            DataSet ds = new DataSet();

            ds = objQL.SP_Categories_CheckExist();
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            else
                return false;
        }

        protected void SaveDB()
        {
            if (!Validation())
            {
                objPC.CategoryId = TableId;
                objPC.CategoryFName = txtCategoryName.Text;
                objPC.CategorySName = txtShortName.Text;
                objPC.OTFormula = cmbOTFormula.Text;
                objPC.MinOT = txtMinOT.Text;
                objPC.MaxOT = MaxOTCheck;
                objPC.MaxOTMin = txtMaxOT.Text;
                objPC.ConsiderOnlyFirstAndLastPunchInAttCalculations = ConsiderOnlyFirstAndLastPunchInAttCalculations;
                objPC.GraceTimeForLateComingMins = txtGraceTimeForLateComing.Text;
                objPC.NeglectLastInPunchForMissedOutPunch = NeglectLastInPunchForMissedOutPunch;
                objPC.GraceTimeForEarlyGoingMins = txtGraceTimeForEarlyGoing.Text;
                objPC.WeeklyOff1 = WeeklyOff1;
                objPC.WeeklyOff1Value = cmbWeeklyOff1.Text;
                objPC.WeeklyOff2 = WeeklyOff2;
                objPC.WeeklyOff2Value = cmbWeeklyOff2.Text;
                objPC.FirstR = FirstST;
                objPC.SecondR = Second;
                objPC.ThirdR = Third;
                objPC.ForthR = Forth;
                objPC.FiveR = Fifth;
                objPC.ConsiderEarlyComingPunch = ConsiderEarlyComingPunch;
                objPC.ConsiderLateGoingPunch = ConsiderLateGoingPunch;
                objPC.DeductBreakHoursFormWorkDuration = DeductBreakHoursFormWorkDuration;
                objPC.CalculateHalfDayifWorkDurationIsLessThan = CalculateHalfDayifWorkDurationIsLessThan;
                objPC.CalculateHalfDayifWorkDurationIsLessThanMins = txtCalculateHalfDayifWorkDurationIsLessThanMins.Text;
                objPC.CalculationAbsentIfWorkDurationIsLessThan = CalculationAbsentIfWorkDurationIsLessThan;
                objPC.CalculationAbsentIfWorkDurationIsLessThanMins = txtCalculationAbsentIfWorkDurationIsLessThanMins.Text;
                objPC.OnPartialDayCalculateHalfDayifWorkDurationisLessThan = OnPartialDayCalculateHalfDayifWorkDurationisLessthan;
                objPC.OnPartialDayCalculateHalfDayifWorkDurationisLessThanMins = txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.Text;
                objPC.OnPartialDayCalculateAbsentDayifWorkDurationislessThan = OnPartialDayCalculateAbsentDayifWorkDurationislessThan;
                objPC.OnPartialDayCalculateAbsentDayifWorkDurationislessThanMins = txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.Text;
                objPC.MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent = MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent;
                objPC.MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent = MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent;
                objPC.MWOHAbsentifBothPrefixandSuffixDayisAbsent = MarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent;
                objPC.Mark = Mark;
                objPC.MarkValue = cmbMarkValue.Text;
                objPC.AbsentWhenLateForValue = cmbAbsentWhenLateForValue.Text;
                objPC.MarkHalfDayifLateBy = MarkHalfDayifLateBy;
                objPC.MarkHalfDayifLateByMins = txtMarkHalfDayifLateByMins.Text;
                objPC.MarkHalfDayifEarlyGoingBy = MarkHalfDayifEarlyGoingBy;
                objPC.MarkHalfDayifEarlyGoingByMins = txtMarkHalfDayifEarlyGoingByMins.Text;
                objPC.UserId = BusinessLayer.LoginId_Static;
                objPC.DeleteFlag = FlagDelete;

                if (!FlagDelete)
                {
                    if (CheckExist())
                    {
                        objRL.ShowMessage(12, 4);
                        return;
                    }
                }
                Result = objQL.SP_CategoriesNew_Insert_Update_Delete();
                if (Result > 0)
                {
                    if (!FlagDelete)
                        objRL.ShowMessage(7, 1);
                    else
                        objRL.ShowMessage(9, 1);

                    FillGrid();
                    ClearAll();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        protected void FillGrid()
        {
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            objPC.CategoryFName = txtSearch.Text;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_Categories_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0	CategoryId,
                //1	CategoryFName,
                //2	CategorySName,
                //3	OTFormula,
                //4	MinOT,
                //5	MaxOT, 
                //6	MaxOTMin,
                //7	ConsiderOnlyFirstAndLastPunchInAttCalculations,
                //8	GraceTimeForLateComingMins, 
                //9	NeglectLastInPunchForMissedOutPunch, 
                //10	GraceTimeForEarlyGoingMins, 
                //11	WeeklyOff1, 
                //12	WeeklyOff1Value, 
                //13	WeeklyOff2, 
                //14	WeeklyOff2Value, 
                //15	1st, 
                //16	2nd, 
                //17	3rd, 
                //18	4th, 
                //19	5th,
                //20	ConsiderEarlyComingPunch, 
                //21	ConsiderLateGoingPunch, 
                //22	DeductBreakHoursFormWorkDuration, 
                //23	CalculateHalfDayifWorkDurationIsLessThan, 
                //24	CalculateHalfDayifWorkDurationIsLessThanMins, 
                //25	CalculationAbsentIfWorkDurationIsLessThan, 
                //26	CalculationAbsentIfWorkDurationIsLessThanMins, 
                //27	OnPartialDayCalculateHalfDayifWorkDurationisLessThan, 
                //28	OnPartialDayCalculateHalfDayifWorkDurationisLessThanMins, 
                //29	OnPartialDayCalculateAbsentDayifWorkDurationislessThan, 
                //30	OnPartialDayCalculateAbsentDayifWorkDurationislessThanMins, 
                //31	MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent, 
                //32	MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent, 
                //33	MWOHAbsentifBothPrefixandSuffixDayisAbsent, 
                //34	Mark, 
                //35	MarkValue, 
                //36	AbsentWhenLateForValue,
                //37	MarkHalfDayifLateBy, 
                //38	MarkHalfDayifLateByMins, 
                //39	MarkHalfDayifEarlyGoingBy,
                //40	MarkHalfDayifEarlyGoingByMins


                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;

                for (int i = 15; i < dataGridView1.Columns.Count; i++)
                {
                    dataGridView1.Columns[i].Visible = false;
                }

                for (int i = 1; i < 16; i++)
                {
                    dataGridView1.Columns[i].Width = 200;
                }

                //dataGridView1.Columns[3].Visible = false;
                //dataGridView1.Columns[5].Visible = false;
                //dataGridView1.Columns[7].Visible = false;
                //dataGridView1.Columns[9].Visible = false;
                //dataGridView1.Columns[2].Width = 120;
                //dataGridView1.Columns[4].Width = 120;
                //dataGridView1.Columns[6].Width = 120;
                //dataGridView1.Columns[8].Width = 120;
                //dataGridView1.Columns[10].Width = 120;
                //dataGridView1.Columns[11].Width = 100;
            }
        }


        int ConsiderOnlyFirstAndLastPunchInAttCalculations = 0, NeglectLastInPunchForMissedOutPunch = 0;
        private void cbConsiderOnlyFirstAndLastPunchInAttCalculations_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConsiderOnlyFirstAndLastPunchInAttCalculations.Checked)
                ConsiderOnlyFirstAndLastPunchInAttCalculations = 1;
            else
                ConsiderOnlyFirstAndLastPunchInAttCalculations = 0;
        }

        private void cbNeglectLastInPunchForMissedOutPunch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNeglectLastInPunchForMissedOutPunch.Checked)
                NeglectLastInPunchForMissedOutPunch = 1;
            else
                NeglectLastInPunchForMissedOutPunch = 0;
        }

        int MaxOTCheck = 0, WeeklyOff1 = 0, WeeklyOff2 = 0;
        string WeeklyOff1Value = string.Empty, WeeklyOff2Value = string.Empty;

        private void cbMaxOT_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMaxOT.Checked)
                MaxOTCheck = 1;
            else
                MaxOTCheck = 0;
        }

        private void cbWeeklyOff1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWeeklyOff1.Checked)
            {
                cmbWeeklyOff1.Enabled = true;
                WeeklyOff1 = 1;
            }
            else
            {
                cmbWeeklyOff1.SelectedIndex = -1;
                cmbWeeklyOff1.Enabled = false;
                WeeklyOff1 = 0;
            }
        }

        private void cbWeeklyOff2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWeeklyOff2.Checked)
            {
                cmbWeeklyOff2.Enabled = true;
                WeeklyOff2 = 1;
            }
            else
            {
                cmbWeeklyOff2.SelectedIndex = -1;
                cmbWeeklyOff2.Enabled = false;
                WeeklyOff2 = 0;
            }
        }

        int FirstST = 0, Second = 0, Third = 0, Forth = 0, Fifth = 0, ConsiderEarlyComingPunch = 0, ConsiderLateGoingPunch = 0, DeductBreakHoursFormWorkDuration = 0;
        private void cb1st_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1st.Checked)
                FirstST = 1;
            else
                FirstST = 0;
        }

        private void cb2nd_CheckedChanged(object sender, EventArgs e)
        {
            if (cb2nd.Checked)
                Second = 1;
            else
                Second = 0;
        }

        private void cb3rd_CheckedChanged(object sender, EventArgs e)
        {
            if (cb3rd.Checked)
                Third = 1;
            else
                Third = 0;
        }

        private void cb4th_CheckedChanged(object sender, EventArgs e)
        {
            if (cb4th.Checked)
                Forth = 1;
            else
                Forth = 0;
        }

        private void cb5th_CheckedChanged(object sender, EventArgs e)
        {
            if (cb5th.Checked)
                Fifth = 1;
            else
                Fifth = 0;
        }

        private void cbConsiderEarlyComingPunch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConsiderEarlyComingPunch.Checked)
                ConsiderEarlyComingPunch = 1;
            else
                ConsiderEarlyComingPunch = 0;
        }

        private void cbConsiderLateGoingPunch_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConsiderLateGoingPunch.Checked)
                ConsiderLateGoingPunch = 1;
            else
                ConsiderLateGoingPunch = 0;
        }

        private void cbDeductBreakHoursFormWorkDuration_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDeductBreakHoursFormWorkDuration.Checked)
                DeductBreakHoursFormWorkDuration = 1;
            else
                DeductBreakHoursFormWorkDuration = 0;
        }

        private void cbCalculateHalfDayifWorkDurationIsLessThan_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCalculateHalfDayifWorkDurationIsLessThan.Checked)
            {
                txtCalculateHalfDayifWorkDurationIsLessThanMins.Enabled = true;
                CalculateHalfDayifWorkDurationIsLessThan = 1;
            }
            else
            {
                txtCalculateHalfDayifWorkDurationIsLessThanMins.Enabled = false;
                txtCalculateHalfDayifWorkDurationIsLessThanMins.Text = "";
                CalculateHalfDayifWorkDurationIsLessThan = 0;
            }
        }

        int CalculateHalfDayifWorkDurationIsLessThan = 0, CalculationAbsentIfWorkDurationIsLessThan = 0, OnPartialDayCalculateHalfDayifWorkDurationisLessthan = 0, OnPartialDayCalculateAbsentDayifWorkDurationislessThan = 0, MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent = 0, MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent = 0, MarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent = 0, Mark = 0, MarkHalfDayifLateBy = 0, MarkHalfDayifEarlyGoingBy = 0;



        private void cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan.Checked)
            {
                txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.Enabled = true;
                OnPartialDayCalculateHalfDayifWorkDurationisLessthan = 1;
            }
            else
            {
                txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.Enabled = false;
                txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.Text = "";
                OnPartialDayCalculateHalfDayifWorkDurationisLessthan = 0;
            }
        }



        private void cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan.Checked)
            {
                txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.Enabled = true;
                OnPartialDayCalculateAbsentDayifWorkDurationislessThan = 1;
            }
            else
            {
                txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.Enabled = false;
                txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.Text = "";
                OnPartialDayCalculateAbsentDayifWorkDurationislessThan = 0;
            }
        }



        private void cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent.Checked)
                MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent = 1;
            else
                MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent = 0;
        }



        private void cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent.Checked)
                MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent = 1;
            else
                MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent = 0;
        }



        private void cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent.Checked)
                MarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent = 1;
            else
                MarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent = 0;
        }


        private void cbMark_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMark.Checked)
            {
                cmbMarkValue.Enabled = true;
                cmbAbsentWhenLateForValue.Enabled = true;
                Mark = 1;
            }
            else
            {
                cmbMarkValue.Enabled = false;
                cmbAbsentWhenLateForValue.Enabled = false;
                cmbMarkValue.SelectedIndex = -1;
                cmbAbsentWhenLateForValue.SelectedIndex = -1;
                Mark = 0;
            }
        }


        private void cbMarkHalfDayifLateBy_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMarkHalfDayifLateBy.Checked)
            {
                txtMarkHalfDayifLateByMins.Enabled = true;
                MarkHalfDayifLateBy = 1;
            }
            else
            {
                txtMarkHalfDayifLateByMins.Enabled = false;
                txtMarkHalfDayifLateByMins.Text = "";

                MarkHalfDayifLateBy = 0;
            }
        }

        private void cbMarkHalfDayifEarlyGoingBy_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMarkHalfDayifEarlyGoingBy.Checked)
            {
                txtMarkHalfDayifEarlyGoingByMins.Enabled = true;
                MarkHalfDayifEarlyGoingBy = 1;
            }
            else
            {
                txtMarkHalfDayifEarlyGoingByMins.Enabled = false;
                txtMarkHalfDayifEarlyGoingByMins.Text = "";
                MarkHalfDayifEarlyGoingBy = 0;
            }
        }

        private void cbCalculationAbsentIfWorkDurationIsLessThan_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCalculationAbsentIfWorkDurationIsLessThan.Checked)
            {
                txtCalculationAbsentIfWorkDurationIsLessThanMins.Enabled = true;
                CalculationAbsentIfWorkDurationIsLessThan = 1;
            }
            else
            {
                txtCalculationAbsentIfWorkDurationIsLessThanMins.Enabled = false;
                txtCalculationAbsentIfWorkDurationIsLessThanMins.Text = "";
                CalculationAbsentIfWorkDurationIsLessThan = 0;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (objPC.ViewFlag == 1)
            {
                try
                {
                    RowCount_Grid = dataGridView1.Rows.Count;
                    CurrentRowIndex = dataGridView1.CurrentRow.Index;

                    if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                    {
                        ClearAll();

                        //0	CategoryId,
                        //1	CategoryFName,
                        //2	CategorySName,
                        //3 cmbOTFormula.Text;
                        //3	MinOT,
                        //4	MaxOT, 
                        //5	MaxOTMin,
                        //6	ConsiderOnlyFirstAndLastPunchInAttCalculations,
                        //7	GraceTimeForLateComingMins, 
                        //8	NeglectLastInPunchForMissedOutPunch, 
                        //9	GraceTimeForEarlyGoingMins, 
                        //10	WeeklyOff1, 
                        //11	WeeklyOff1Value, 
                        //12	WeeklyOff2, 
                        //13	WeeklyOff2Value, 
                        //14	1st, 
                        //15	2nd, 
                        //16	3rd, 
                        //17	4th, 
                        //18	5th,
                        //19	ConsiderEarlyComingPunch, 
                        //20	ConsiderLateGoingPunch, 
                        //21	DeductBreakHoursFormWorkDuration, 
                        //22	CalculateHalfDayifWorkDurationIsLessThan, 
                        //23	CalculateHalfDayifWorkDurationIsLessThanMins, 
                        //24	CalculationAbsentIfWorkDurationIsLessThan, 
                        //25	CalculationAbsentIfWorkDurationIsLessThanMins, 
                        //26	OnPartialDayCalculateHalfDayifWorkDurationisLessThan, 
                        //27	OnPartialDayCalculateHalfDayifWorkDurationisLessThanMins, 
                        //28	OnPartialDayCalculateAbsentDayifWorkDurationislessThan, 
                        //29	OnPartialDayCalculateAbsentDayifWorkDurationislessThanMins, 
                        //30	MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent, 
                        //31	MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent, 
                        //32	MWOHAbsentifBothPrefixandSuffixDayisAbsent, 
                        //33	Mark, 
                        //34	MarkValue, 
                        //35	AbsentWhenLateForValue,
                        //36	MarkHalfDayifLateBy, 
                        //37	MarkHalfDayifLateByMins, 
                        //38	MarkHalfDayifEarlyGoingBy,
                        //39	MarkHalfDayifEarlyGoingByMins


                        btnDelete.Enabled = true;
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        txtCategoryName.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()));
                        txtShortName.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString()));
                        cmbOTFormula.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()));
                        txtMinOT.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()));


                        MaxOTCheck = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(MaxOTCheck, cbMaxOT);
                        txtMaxOT.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()));

                        ConsiderOnlyFirstAndLastPunchInAttCalculations = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[7].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(ConsiderOnlyFirstAndLastPunchInAttCalculations, cbConsiderOnlyFirstAndLastPunchInAttCalculations);
                        txtGraceTimeForLateComing.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString()));

                        NeglectLastInPunchForMissedOutPunch = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[9].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(NeglectLastInPunchForMissedOutPunch, cbNeglectLastInPunchForMissedOutPunch);
                        txtGraceTimeForEarlyGoing.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString()));

                        WeeklyOff1 = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[11].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(WeeklyOff1, cbWeeklyOff1);
                        cmbWeeklyOff1.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString()));

                        WeeklyOff2 = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[13].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(WeeklyOff2, cbWeeklyOff2);
                        cmbWeeklyOff2.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString()));

                        FirstST = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[15].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(FirstST, cb1st);

                        Second = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[16].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(Second, cb2nd);

                        Third = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[17].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(Third, cb3rd);

                        Forth = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[18].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(Forth, cb4th);

                        Fifth = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[19].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(Fifth, cb5th);

                        ConsiderEarlyComingPunch = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[20].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(ConsiderEarlyComingPunch, cbConsiderEarlyComingPunch);

                        ConsiderLateGoingPunch = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[21].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(ConsiderLateGoingPunch, cbConsiderLateGoingPunch);

                        DeductBreakHoursFormWorkDuration = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[22].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(DeductBreakHoursFormWorkDuration, cbDeductBreakHoursFormWorkDuration);

                        CalculateHalfDayifWorkDurationIsLessThan = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[23].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(CalculateHalfDayifWorkDurationIsLessThan, cbCalculateHalfDayifWorkDurationIsLessThan);
                        txtCalculateHalfDayifWorkDurationIsLessThanMins.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[24].Value.ToString()));

                        CalculationAbsentIfWorkDurationIsLessThan = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[25].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(CalculationAbsentIfWorkDurationIsLessThan, cbCalculationAbsentIfWorkDurationIsLessThan);
                        txtCalculationAbsentIfWorkDurationIsLessThanMins.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[26].Value.ToString()));

                        OnPartialDayCalculateHalfDayifWorkDurationisLessthan = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[27].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(OnPartialDayCalculateHalfDayifWorkDurationisLessthan, cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan);
                        txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[28].Value.ToString()));

                        OnPartialDayCalculateAbsentDayifWorkDurationislessThan = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[29].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(OnPartialDayCalculateAbsentDayifWorkDurationislessThan, cbOnPartialDayCalculateAbsentDayifWorkDurationislessThan);
                        txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[30].Value.ToString()));

                        MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[31].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(MarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent, cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent);

                        MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[32].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(MarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent, cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent);

                        MarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[33].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(MarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent, cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent);

                        Mark = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[34].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(Mark, cbMark);
                        cmbMarkValue.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[35].Value.ToString()));
                        cmbAbsentWhenLateForValue.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[36].Value.ToString()));

                        MarkHalfDayifLateBy = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[37].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(MarkHalfDayifLateBy, cbMarkHalfDayifLateBy);
                        txtMarkHalfDayifLateByMins.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[38].Value.ToString()));

                        MarkHalfDayifEarlyGoingBy = Convert.ToInt32(objRL.CheckNullString_ReturnInt(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[39].Value)));
                        objRL.CheckBox_Checked_ByZeroOne(MarkHalfDayifEarlyGoingBy, cbMarkHalfDayifEarlyGoingBy);
                        txtMarkHalfDayifEarlyGoingByMins.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[40].Value.ToString()));
                    }
                }
                catch (Exception ex1)
                {
                    objRL.ErrorMessge(ex1.ToString());
                    return;
                }
                finally
                {
                    GC.Collect();
                }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (objPC.DeleteFlagUR == 1)
            {
                try
                {
                    DialogResult dr = objRL.Delete_Record_Show_Message();
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        FlagDelete = true;
                        SaveDB();
                    }
                }
                catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
                finally { GC.Collect(); }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
        }

        private void txtMinOT_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtMinOT);
        }

        private void txtMaxOT_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtMaxOT);
        }

        private void txtGraceTimeForLateComing_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtGraceTimeForLateComing);
        }

        private void txtGraceTimeForEarlyGoing_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtGraceTimeForEarlyGoing);
        }

        private void txtCalculateHalfDayifWorkDurationIsLessThanMins_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtCalculateHalfDayifWorkDurationIsLessThanMins);
        }

        private void txtCalculationAbsentIfWorkDurationIsLessThanMins_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtCalculationAbsentIfWorkDurationIsLessThanMins);
        }

        private void txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtOnPartialDayCalculateHalfDayifWorkDurationisLessThanMins);
        }

        private void txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtOnPartialDayCalculateAbsentDayifWorkDurationislessThanMins);
        }

        private void txtMarkHalfDayifLateByMins_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtMarkHalfDayifLateByMins);
        }

        private void txtMarkHalfDayifEarlyGoingByMins_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtMarkHalfDayifEarlyGoingByMins);
        }

        private void txtCalculateHalfDayifWorkDurationIsLessThanMins_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
