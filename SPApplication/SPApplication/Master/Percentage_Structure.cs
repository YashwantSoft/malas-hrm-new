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
    public partial class Percentage_Structure : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        public Percentage_Structure()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_PERCENTAGESTUCTUREMASTER);
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
            dtpDate.Text ="";
            txtPF.Text = "";
            txtESIC.Text = "";
            txtGraturity.Text = "";
            txtProfessionalTax.Text = "";
            txtHRA.Text = "";
            txtTA.Text = "";
            txtOther.Text = "";
            txtBonus.Text = "";
            txtIncentive.Text= "";
            txtSearch.Text = "";

        }

        private void txtPF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpDate.Focus();
        }

        private void dtpDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtESIC.Focus();
        }

        private void txtESIC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtGraturity.Focus();
        }

        private void txtGraturity_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                txtProfessionalTax.Focus();
        }

        private void txtProfessionalTax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtHRA.Focus();
        }

        private void txtHRA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtTA.Focus();
        }

        private void txtTA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtOther.Focus();
        }

        private void txtOther_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBonus.Focus();
        }

        private void txtBonus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtIncentive.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Validation();
        }
        private bool Validation()
        {
            if (txtPF.Text == "")
            {
                txtPF.Focus();
                objEP.SetError(txtPF, " Enter PF");
                return false;
            }
            else if (dtpDate.Text == "")
            {
                dtpDate.Focus();
                objEP.SetError(dtpDate, "Enter Date ");
                return false;
            }
            else if (txtESIC.Text == "")
            {
                txtESIC.Focus();
                objEP.SetError(txtESIC, "Enter ESIC ");
                return false;
            }
            else if (txtGraturity.Text == "")
            {
                txtGraturity.Focus();
                objEP.SetError(txtGraturity, "Enter Graturity ");
                return false;
            }
            else if (txtProfessionalTax.Text == "")
            {
                txtProfessionalTax.Focus();
                objEP.SetError(txtProfessionalTax, "Enter Professinal Tax ");
                return false;
            }
            else if (txtHRA.Text == "")
            {
                txtHRA.Focus();
                objEP.SetError(txtHRA, "Enter HRA ");
                return false;
            }
            else if (txtTA.Text == "")
            {
                txtTA.Focus();
                objEP.SetError(txtTA, "Enter TA ");
                return false;
            }
            else if (txtOther.Text == "")
            {
                txtOther.Focus();
                objEP.SetError(txtOther, "Enter Other");
                return false;
            }
            else if (txtBonus.Text == "")
            {
                txtBonus.Focus();
                objEP.SetError(txtBonus, "Enter Bonus ");
                return false;
            }
            else if (txtIncentive.Text == "")
            {
                txtIncentive.Focus();
                objEP.SetError(txtIncentive, "Enter Incentive ");
                return false;
            }
            else
                return false;
        }

        private void Percentage_Structure_Load(object sender, EventArgs e)
        {

        }
  

    }
}
