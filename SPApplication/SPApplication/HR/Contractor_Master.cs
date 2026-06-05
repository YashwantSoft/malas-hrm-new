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
    public partial class Contractor_Master : Form
    {

        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
       
        bool FlagDelete = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableID = 0;
        bool SearchTag = false;
        public Contractor_Master()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_CONTRACTORMASTER);
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
            txtContractorId.Text = "";
            txtContractorName.Text = "";
            txtAddress.Text = "";
            txtRegisterNo.Text ="";
            txtGSTIN.Text ="";
            txtContactPerson.Text = "";
            txtMobileNumber.Text = "";
            dtpJoiningDate.Text = "";
            txtSearch.Text = "";
        }

        private void Contractor_Master_Load(object sender, EventArgs e)
        {

        }

        private void txtContractorId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtContractorName.Focus();
        }

        private void txtContractorName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAddress.Focus();
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRegisterNo.Focus();
        }

        private void txtRegisterNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtGSTIN.Focus();
        }

        private void txtGSTIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtContactPerson.Focus();
        }

        private void txtContactPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMobileNumber.Focus();
        }

        private void txtMobileNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpJoiningDate.Focus();
        }

    }
}
