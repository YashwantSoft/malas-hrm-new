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
    public partial class Health_Insurance_Policy_Master : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
       

        public Health_Insurance_Policy_Master()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_HEALTHINSURANCEPOLICYMASTER);
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
            txtPolicyID.Text = "";
            txtPolicyName.Text = "";
            txtDescription.Text = "";
            txtSearch.Text = "";
        }

        private void txtPolicyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPolicyName.Focus();
        }

        private void txtPolicyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDescription.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Validation();
        }
        private bool Validation()
        {
            if (txtPolicyID.Text == "")
            {
                txtPolicyID.Focus();
                objEP.SetError(txtPolicyID, " Enter Policy  Id");
                return false;
            }
            else if (txtPolicyName.Text == "")
            {
                txtPolicyName.Focus();
                objEP.SetError(txtPolicyName, "Enter  Policy Name");
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
