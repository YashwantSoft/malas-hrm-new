using BusinessLayerUtility.Classes;
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

    public partial class Shift_Master : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        MasterClass objMC = new MasterClass();
        public Shift_Master()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_SHIFTMASTER);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Shift_Master_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtShiftName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtShortName.Focus();
        }

        private void txtShortName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBegingTime.Focus();
        }

        private void txtBegingTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEndTime.Focus();
        }

        private void txtEndTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbBreak1.Focus();
        }

        private void cbBreak1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBegingTime1.Focus();
        }

        private void txtBegingTime1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEndTime1.Focus();
        }

        private void txtEndTime1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbBreak2.Focus();
        }

        private void cbBreak2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBegingTime2.Focus();
        }

        private void txtBegingTime2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEndTime2.Focus();
        }

        private void txtEndTime2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbFlexibleShift.Focus();
        }

        private void cbFlexibleShift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbPunchBeginBefore.Focus();
        }

        private void cbPunchBeginBefore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPunchBeginBefore.Focus();
        }

        private void txtPunchBeginBefore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbPunchEndAfter.Focus();
        }

        private void cbPunchEndAfter_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            txtPunchEndAfter.Focus();
        }

        private void cbGraceTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtGraceTime.Focus();
        }

        private void txtGraceTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbPartialDayon.Focus();
        }

        private void cbPartialDayon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbPartialDayon.Focus();
        }

        private void cmbPartialDayon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBeginsAt.Focus();
        }

        private void txtBeginsAt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEndAt.Focus();
        }

        private void txtEndAt_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtPunchEndAfter_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            cbGraceTime.Focus();
        }

        private void ClearAll()
        {
            
            objEP.Clear();
            txtShiftName.Text = "";
            txtShortName.Text = "";
            txtBegingTime.Text = "";
            txtEndTime.Text = "";
            cbBreak1.Checked = false;
            txtBegingTime1.Text = "";
            txtEndTime1.Text = "";
            cbBreak2.Checked = false;
            txtBegingTime2.Text = "";
            txtEndTime2.Text = "";
            cbFlexibleShift.Checked = false;
            cbPunchBeginBefore.Checked = false;
            txtPunchBeginBefore.Text = "";
            cbPunchEndAfter.Checked= false;
            txtPunchEndAfter.Text = "";
            cbGraceTime.Checked = false;
            txtGraceTime.Text = "";
            cbPartialDayon.Checked =false;
            cmbPartialDayon.Text = "";
            txtBeginsAt.Text = "";
            txtEndAt.Text = "";
            txtSearch.Text = "";
            txtShiftName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
