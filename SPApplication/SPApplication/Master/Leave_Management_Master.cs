using BusinessLayerUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPApplication.HR
{
    public partial class Leave_Management_Master : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();

        public Leave_Management_Master()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_LEAVEMANAGEMENTMASTER);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            //TableId = 0;
            objEP.Clear();
            txtUnitID.Text = "";
            txtUnitNumber.Text = "";
            txtEmployeName.Text = "";
            txtTotalLeave.Text = "";
            txtBalanceLeave.Text = "";
            txtSearch.Text = "";
        }

        private void txtTotalLeave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBalanceLeave.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Validation();
        }
        private bool Validation()
        {
            if (txtTotalLeave.Text == "")
            {
                txtTotalLeave.Focus();
                objEP.SetError(txtTotalLeave, " Enter Total Leave");
                return false;
            }
            else if (txtBalanceLeave.Text == "")
            {
                txtBalanceLeave.Focus();
                objEP.SetError(txtBalanceLeave, "EnterBalance Leave");
                return false;
            }

            else
                return false;

        }
    }
}
