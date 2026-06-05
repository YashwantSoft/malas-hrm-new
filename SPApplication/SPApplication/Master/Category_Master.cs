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
    public partial class Category_Master : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        public Category_Master()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_CATEGORYMASTER);

        }

        private void Category_Master_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void ClearAll()
        {
            objEP.Clear();
            txtCategoryName.Text = "";
            txtShortName.Text = "";
            cmbOTFormula.Text = "";
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
            cbCalculateHalfDayifWorkDurationIslessthan.Checked = false;
            txtCalculateHalfDayifWorkDurationIslessThan.Text = "";
            cbCalculationAbsentifWorkDurationislessthan.Checked = false;
            txtCalculationAbsentifWorkDurationislessThan.Text = "";
            cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan.Checked = false;
            txtOnPartialDayCalculateHalfDayifWorkDurationislessthan.Text = "";
            cbOnPartialDayCalculateAbsentDayifWorkDurationislessthan.Checked = false;
            txtOnPartialDayCalculateAbsentDayifWorkDurationislessthan.Text = "";
            cbMarkWeeklyOffandHolidayasAbsentifPrefixDayisAbsent.Checked = false;
            cbMarkWeeklyOffandHolidayasAbsentifSuffixDayisAbsent.Checked = false;
            cbMarkWeeklyOffandHolidayasAbsentifBothPrefixandSuffixDayisAbsent.Checked = false;
            cbMark.Checked = false;
            cmbMark.Text = "";
            cmbAbsentWhenLateFor.Text = "";
            cbMarkHalfDayiflateby.Checked = false;
            txtMarkHalfDayiflateby.Text = "";
            cbMarkHalfDayifEarlyGoingby.Checked = false;
            txtMarksHalfDayifearlyGoingby.Text = "";
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
            if(e.KeyCode == Keys.Enter)
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
                cbCalculateHalfDayifWorkDurationIslessthan.Focus();
        }

        private void cbCalculateHalfDayifWorkDurationIslessthan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCalculateHalfDayifWorkDurationIslessThan.Focus();
        }

        private void txtCalculateHalfDayifWorkDurationIslessThan_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                cbCalculationAbsentifWorkDurationislessthan.Focus();
        }

        private void cbCalculationAbsentifWorkDurationislessthan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCalculationAbsentifWorkDurationislessThan.Focus();
        }

        private void txtCalculationAbsentifWorkDurationislessThan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan.Focus();
        }

        private void cbOnPartialDayCalculateHalfDayifWorkDurationisLessthan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtOnPartialDayCalculateHalfDayifWorkDurationislessthan.Focus();
        }

        private void txtOnPartialDayCalculateHalfDayifWorkDurationislessthan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbOnPartialDayCalculateAbsentDayifWorkDurationislessthan.Focus();
        }

        private void cbOnPartialDayCalculateAbsentDayifWorkDurationislessthan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtOnPartialDayCalculateAbsentDayifWorkDurationislessthan.Focus();
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
                cmbMark.Focus();
        }

        private void cmbMark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbAbsentWhenLateFor.Focus();
        }

        private void cmbAbsentWhenLateFor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbMarkHalfDayiflateby.Focus();
        }

        private void cbMarkHalfDayiflateby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMarkHalfDayiflateby.Focus();
        }

        private void txtMarkHalfDayiflateby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbMarkHalfDayifEarlyGoingby.Focus();
        }

        private void cbMarkHalfDayifEarlyGoingby_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMarksHalfDayifearlyGoingby.Focus();
        }
    }
}
