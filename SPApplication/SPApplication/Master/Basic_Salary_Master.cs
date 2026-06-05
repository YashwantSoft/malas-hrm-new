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
    public partial class Basic_Salary_Master : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();

        public Basic_Salary_Master()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_BASICSALARYMASTER);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void ClearAll()
        {
            objEP.Clear();
            txtSalaryID.Text = "";
            txtDesignation.Text = "";
            txtBasicSalary.Text = "";
            txtSearch.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void txtSalaryID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDesignation.Focus();
        }

        private void txtDesignation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBasicSalary.Focus();
        }
        private bool Validation()
        {
            if (txtSalaryID.Text == "")
            {
                txtSalaryID.Focus();
                objEP.SetError(txtSalaryID, "Enter Salary ID");
                return true;
            }
            else if (txtDesignation.Text == "")
            {
                txtDesignation.Focus();
                objEP.SetError(txtDesignation, " Enter Designation ");
                return true;
            }
            else if (txtBasicSalary.Text == "")
            {
                txtBasicSalary.Focus();
                objEP.SetError(txtBasicSalary, " Enter Basic Salary ");
                return true;
            }
            else
                return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Validation();
        }

        private void Basic_Salary_Master_Load(object sender, EventArgs e)
        {

        }
    }
}
