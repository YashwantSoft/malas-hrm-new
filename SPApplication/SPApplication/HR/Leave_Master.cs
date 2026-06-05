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
    public partial class Leave_Master : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        public Leave_Master()
        {
            InitializeComponent(); 
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_LEAVEMASTER);
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
            objEP.Clear();
            txtLeaveID.Text = "";
            txtLeave.Text ="";
            txtDescription.Text = "";
            txtSearch.Text = "";


        }

        private void txtLeaveID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLeave.Focus();
        }

        private void txtLeave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDescription.Focus();
        }

        private void txtDiscription_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Validation();
        }
        private bool Validation()
        {
            if (txtLeaveID.Text == "")
            {
                txtLeaveID.Focus();
                objEP.SetError(txtLeaveID, " Enter Leave Id");
                return false;
            }
            else if (txtLeave.Text == "")
            {
                txtLeave.Focus();
                objEP.SetError(txtLeave, "Enter Leave ");
                return false;
            }
            else if (txtDescription.Text == "")
            {
                txtDescription.Focus();
                objEP.SetError(txtDescription, "Enter Description ");
                return false;
            }
            else
                return false;
        }
  
    }
}
