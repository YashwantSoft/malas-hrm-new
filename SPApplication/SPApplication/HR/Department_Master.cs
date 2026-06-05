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
    public partial class Department_Master : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        public Department_Master()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_DEPARTMENTMASTER);
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
            txtDepartmentID.Text = "";
            txtDepartmentName.Text = "";
            cmbLocation.Text = "";
            txtHODName.Text = "";
            txtContactPerson.Text = "";
            txtExtensionNo.Text = "";
            txtMobileNumber.Text = "";
            txtDescription.Text = "";
            txtSearch.Text = "";

        }

        private void txtDepartmentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDepartmentName.Focus();
        }

        private void txtDepartmentName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbLocation.Focus();
        }

        private void cmbLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtHODName.Focus();
        }

        private void txtHODName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtContactPerson.Focus();
        }

        private void txtContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtExtensionNo.Focus();

        }

        private void txtExtensionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMobileNumber.Focus();
        }

        private void txtMobileNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDescription.Focus();
        }

        private void lbDepartmentName_Click(object sender, EventArgs e)
        {

        }
        private bool Validation()
        {
            if (txtDepartmentID.Text == "")
            {
                txtDepartmentID.Focus();
                objEP.SetError(txtDepartmentID, " Enter Department Id");
                return false;
            }
            else if (txtDepartmentName.Text == "")
            {
                txtDepartmentName.Focus();
                objEP.SetError(txtDepartmentName, "Enter Department Name");
                return false;
            }
            else if (cmbLocation.SelectedIndex == -1)
            {
                cmbLocation.Focus();
                objEP.SetError(cmbLocation, "Select Location");
                return false;
            }
            else if (txtHODName.Text == "")
            {
                txtHODName.Focus();
                objEP.SetError(txtHODName, "Enter HOD");
                return false;
            }
            else if (txtContactPerson.Text == "")
            {
                txtContactPerson.Focus();
                objEP.SetError(txtContactPerson, "Enter Contact Person ");
                return false;
            }
            else if (txtExtensionNo.Text == "")
            {
                txtExtensionNo.Focus();
                objEP.SetError(txtExtensionNo, "Enter Extension Number");
                return false;
            }
            else if (txtMobileNumber.Text == "")
            {
                txtMobileNumber.Focus();
                objEP.SetError(txtMobileNumber, "Enter Mobile Number");
                return false;
            }
            else if (txtDescription.Text == "")
            {
                txtDescription.Focus();
                objEP.SetError(txtDescription, "Enter Description");
                return false;
            }
            else
                return false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Validation();
        }
    }
}
