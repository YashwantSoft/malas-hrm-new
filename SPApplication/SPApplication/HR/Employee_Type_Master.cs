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
    public partial class Employee_Type_Master : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        public Employee_Type_Master()
        {
            InitializeComponent();
          objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_EMPLOYEETYPEMASTER);
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
            txtEmployeeTypeID.Text = "";
            txtEmployeeType.Text = "";
            txtDescription.Text = "";
            txtSearch.Text = "";
        }

        private void txtEmployeeTypeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEmployeeType.Focus();
        }

        private void txtEmployeeType_KeyDown(object sender, KeyEventArgs e)
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
            if (txtEmployeeTypeID.Text == "")
            {
                txtEmployeeTypeID.Focus();
                objEP.SetError(txtEmployeeTypeID, " Enter Employee Type Id");
                return false;
            }
            else if (txtEmployeeType.Text == "")
            {
                txtEmployeeType.Focus();
                objEP.SetError(txtEmployeeType, "Enter Employee Type");
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
