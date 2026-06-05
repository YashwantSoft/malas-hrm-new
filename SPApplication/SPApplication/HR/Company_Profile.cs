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
    public partial class Company_Profile : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        public Company_Profile()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_COMPANYPROFILE);
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
            txtCompanyName.Text = "";
            txtCompanyAddress.Text = "";
            txtCityCompanyInfo.Text = "";
            cmbStateCompanyInfo.Text = "";
            txtPinCodeCompanyInfo.Text = "";
            cmbCountryCompanyInfo.Text = "";
            txtEmailAddress.Text = "";
            txtPhoneNo.Text = "";
            txtWebsite.Text = "";
            dtpFromDate.Text = ""; 
           txtPFTrustNo.Text = "";
            txtPFNoCompanyInfo.Text = "";
            txtTANNo.Text = "";
            txtESICNoCompanyInfo.Text = "";
            txtPANNoCompanyInfo.Text = "";
            txtDomainName.Text = "";
            txtCompanyCode.Text = "";
            txtInOutDuration.Text = "";
            txtLWFNo.Text = "";
            cmbAlternateWeekOffDay.Text = "";
            txtAlternateFullWeekOff.Text = "";
            txtSearch.Text = "";
        }
        private bool Validation()
        {
            if (txtCompanyName.Text == "")
            {
                txtCompanyName.Focus();
                objEP.SetError(txtCompanyName, "Enter Company Name");
                return true;
            }
            else if (txtCompanyAddress.Text == "")
            {
                txtCompanyAddress.Focus();
                objEP.SetError(txtCompanyAddress, "Enter Company Address");
                return true;
            }
            else if (txtCityCompanyInfo.Text == "")
            {
                txtCityCompanyInfo.Focus();
                objEP.SetError(txtCityCompanyInfo, "Enter City");
                return true;
            }
            else if (cmbStateCompanyInfo.SelectedIndex == -1)
            {
                cmbStateCompanyInfo.Focus();
                objEP.SetError(cmbStateCompanyInfo, "Enter State");
                return true;
            }
            else if (txtPinCodeCompanyInfo.Text == "")
            {
                txtPinCodeCompanyInfo.Focus();
                objEP.SetError(txtPinCodeCompanyInfo, "Enter PinCode");
                return true;
            }
            else if (cmbCountryCompanyInfo.SelectedIndex == -1)
            {
                cmbCountryCompanyInfo.Focus();
                objEP.SetError(cmbCountryCompanyInfo, "Enter Country");
                return true;
            }
            else if (txtEmailAddress.Text == "")
            {
                txtEmailAddress.Focus();
                objEP.SetError(txtEmailAddress, "Select Email Address");
                return true;
            }
            else if (txtPhoneNo.Text == "")
            {
                txtPhoneNo.Focus();
                objEP.SetError(txtPhoneNo, "Select PhoneNo");
                return true;
            }
            else if (txtWebsite.Text == "")
            {
                txtWebsite.Focus();
                objEP.SetError(txtWebsite, "Select Website");
                return true;
            }
            else if (txtPFTrustNo.Text == "")
            {
                txtPFTrustNo.Focus();
                objEP.SetError(txtPFTrustNo, "Select PF Trust");
                return true;
            }
            else if (txtPFNoCompanyInfo.Text == "")
            {
                txtPFNoCompanyInfo.Focus();
                objEP.SetError(txtPFNoCompanyInfo, "Select PF No");
                return true;
            }
            else if (txtESICNoCompanyInfo.Text == "")
            {
                txtESICNoCompanyInfo.Focus();
                objEP.SetError(txtESICNoCompanyInfo, "Select ESICNo");
                return true;
            }
            else if (txtTANNo.Text == "")
            {
                txtTANNo.Focus();
                objEP.SetError(txtTANNo, "Select TAN NO");
                return true;
            }
            else if (txtPANNoCompanyInfo.Text == "")
            {
                txtPANNoCompanyInfo.Focus();
                objEP.SetError(txtPANNoCompanyInfo, "Select PAN No");
                return true;
            }
            else if (txtDomainName.Text == "")
            {
                txtDomainName.Focus();
                objEP.SetError(txtDomainName, "Select Domain Name");
                return true;
            }
            else if (txtCompanyCode.Text == "")
            {
                txtCompanyCode.Focus();
                objEP.SetError(txtCompanyCode, "Select Company Code");
                return true;
            }
            else if (txtLWFNo.Text == "")
            {
                txtLWFNo.Focus();
                objEP.SetError(txtLWFNo, "Select LWF No");
                return true;
            }
            else if (txtLWFNo.Text == "")
            {
                txtLWFNo.Focus();
                objEP.SetError(txtLWFNo, "Select LWF No");
                return true;
            }

            else if (txtInOutDuration.Text == "")
            {
                txtInOutDuration.Focus();
                objEP.SetError(txtInOutDuration, "Select In out of Duration");
                return true;
            }
            else if (txtAlternateFullWeekOff.Text == "")
            {
                txtAlternateFullWeekOff.Focus();
                objEP.SetError(txtAlternateFullWeekOff, "Select Alternate Full Week Off");
                return true;
            }
            else if (cmbAlternateWeekOffDay.SelectedIndex == -1)
            {
                cmbAlternateWeekOffDay.Focus();
                objEP.SetError(cmbAlternateWeekOffDay, "Select Altenate Week of Day");
                return true;
            }

            else
                return false;
        }


        private void lbSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Validation();
        }

    }
}
