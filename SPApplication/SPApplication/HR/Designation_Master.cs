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
    public partial class Designation_Master : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        public Designation_Master()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_DESIGNATIONMASTER);
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
            txtDesignationId.Text = "";
            txtDesignation.Text = "";
            txtDescription.Text = "";
            txtSearch.Text = "";
            
        }

        private void txtDesignationId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDesignation.Focus();
        }

        private void txtDesignation_KeyDown(object sender, KeyEventArgs e)
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
            if (txtDesignationId.Text == "")
            {
                txtDesignationId.Focus();
                objEP.SetError(txtDesignationId, " Enter Designation Id");
                return false;
            }
            else if (txtDesignation.Text == "")
            {
                txtDesignation.Focus();
                objEP.SetError(txtDesignation, "Enter Designation");
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
