using BusinessLayerUtility;
using BusinessLayerUtility.Classes;
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
    public partial class Employee_Master : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        LoginClass objLC = new LoginClass();
        QueryLayer objQL = new QueryLayer();
        
        int TableId = 0, Result = 0;
        bool FlagDelete = false;

        public Employee_Master()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_EMPLOYEEMASTER);
            objDL.SetPlusButtonDesign(btnDesignation);
            objDL.SetPlusButtonDesign(btnDepartment);
            objDL.SetPlusButtonDesign(btnEmployeeType);
            objDL.SetPlusButtonDesign(btnSalaryCycle);
            objDL.SetPlusButtonDesign(btnPlaceOfPosting);
            objDL.SetPlusButtonDesign(btnState);
            objDL.SetPlusButtonDesign(btnPoliceStation);
            objDL.SetPlusButtonDesign(btnCountry);
            objDL.SetPlusButtonDesign(btnLanguage);
            objDL.SetPlusButtonDesign(btnFluency);
            objDL.SetPlusButtonDesign(btnCitizenship);
            //objDL.SetPlusButtonDesign(btnCountry);

            //objQL.Fill_Master_ComboBox(cmbUserType, "usertypemaster");
            objQL.Fill_Master_ComboBox(cmbDepartment, "departmentmaster");


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();

        }
      
   

       

        private void lbMonthlyBasic_Click(object sender, EventArgs e)
        {

        }

        
        private void btnExit_Click_2(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtWeight_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
        
             ClearALl_MYProfile();
             ClearAll_PersonalInformation();
             ClearAll_Contact();
             ClearAll_EmergencyContact();
             ClearAll_Dependents();
             ClearAll_Immigrantion();
             ClearAll_ExperienceAndLanguages();
             ClearAll_Qualification();
             ClearAll_Skill();
             ClearAll_Attachment();
             ClearAll_Allowance();
             ClearAll_Salary();
             Clearall_CustomiseField();

        }
        private void ClearALl_MYProfile()
        {
            
            txtESSLMachineID.Text = "";
            txtEMPCode.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            cmbGender.Text = "";
            dtpDateOfBirth.Text = "";
            txtAge.Text = "";
            dtpDateOfJoin.Text = "";
           
            cmbDesignation.Text = "";
            txtMonthlyBasic.Text = "";
            txtMonthlyCTC.Text = "";
            txtMonthlyGross.Text = "";
            cmbDepartment.Text = ""; ;
          
            cmbEmployeeType.Text = "";
            
            cmbPlaceOfPosting.Text = "";
           
            cmbSalaryCycle.Text = "";
            cbFullPF.Checked = false;
            cbPT.Checked = false;
            cbFixSalary.Checked = false;
            cbPartTime.Checked = false;
            cbProbation.Checked = false;
            cbLWF.Checked = false;
            cbPMGKYApplication.Checked = false;
            cbPensionNotApplicable.Checked = false;
        }
        private void ClearAll_PersonalInformation()
        {
            objEP.Clear();
            txtPersonalEmailID.Text = "";
            
            txtPANNo.Text="";
            txtPFNo.Text="";
            txtESICNo.Text="";
            txtUANNumber.Text="";
            cmbMaritalStatus.Text = "";
            dtpComfirmDate.Text = "";
            dtpDateOfRetrirement.Text="";
            dtpPFStartDate.Text = "";
            txtAadharCardNo.Text = "";
            cbPhysicalDisability.Checked = false;
        }
        private void ClearAll_Contact()
        {
            txtAddress.Text = "";
            txtTaluka.Text = "";
            txtDistrict.Text = "";
            txtCityVillage.Text="";
            cmbState.Text = "";
            txtPincode.Text = "";
            cmbPoliceStation.Text = "";
            cmbCountry.Text = "";
            txtMobileNoPAD.Text = "";
        }

        private void ClearAll_EmergencyContact()
        {
            objEP.Clear();
            txtName.Text = "";
            txtMobileNumber.Text = "";
            txtWorkPhone.Text = "";
            txtHomePhone.Text = "";
        }

        private void ClearAll_Dependents()
        {
            objEP.Clear();
            txtNameNominee.Text = "";
            txtAddressNominee.Text = "";
            dtpDateOfBirthNominee.Text = "";
            cmbNomineeFor.Text = "";
            txtAadharcardNominee.Text = "";
            txtNameFamilyDetails.Text = "";
            cmbRelationshipFamilyDetails.Text = "";
            cmbGenderFamilyDetails.Text = "";
            dtpDateOfBirthFD.Text = "";
            txtPANCardFD.Text = "";
            txtAadharCardFD.Text = "";
            chIsResidingWithHimHer.Checked = false;
            cbIsDependentonyou.Checked  =false; 
            
        }
        private void ClearAll_Immigrantion()
        {
            objEP.Clear();
            txtPassportNo.Text = "";
            txtIssuesDate.Text = "";
            txtRenewDate.Text = "";
            txtComments.Text = "";
            cmbCitizenship.Text = "";
            dtpDateOfExpiry.Text = "";
            txtStatus.Text = "";
            txtPassportNo.Text = "";
        }
        private void ClearAll_ExperienceAndLanguages()
        {
            objEP.Clear();
            txtEmployer.Text = "";
            txtLocation.Text = "";
            dtpStartDate.Text = "";
            txtCTC.Text = "";
            txtManagerEL.Text = "";
            txtRemrks.Text = "";
            txtBranch.Text = "";
            txtDesignationEL.Text = "";
            dtpEndDate.Text = "";
            txtGrossSalary.Text = "";
            txtManagerContactNo.Text = "";
            cmbIndustryType.Text = "";
            cmbLanguage.Text = "";
            cmbFluency.Text = "";
            cbWrite.Checked = false;
            cbRead.Checked = false;
            cbSpeak.Checked = false;
            cbUnderstand.Checked = false;
        }
        private void ClearAll_Qualification()
        {
            objEP.Clear();
            txtEducation.Text = "";
            txtYear.Text = "";
            dtpStartDateQualification.Text = "";
            txtComment.Text = "";
            txtSpeciazation.Text = "";
            txtScoreClass.Text = "";
            dtpEndDateQualification.Text = "";
        }
        private void ClearAll_Skill()
        {
            objEP.Clear();
            cmbSkill.Text = "";
            txtYesrsOfExperince.Text = "";
            txtCommentsSkill.Text = "";

        }
        private void ClearAll_Attachment()
        {
            objEP.Clear();
            cmbDocumentName.Text="";
            txtCommentAttachment.Text = "";
        }
        private void ClearAll_Allowance()
        {
            objEP.Clear();
            txtBasic.Text = "";
            txtGross.Text = "";
            txtAnnunalCTC.Text = "";
            txtTotalDeducation.Text = "";
            txtTotalEarning.Text = "";
            txtCTCAllowance.Text = "";
            txtPT.Text = "";
            txtNet.Text = "";
        }
        private void ClearAll_Salary()
        {
            objEP.Clear();
            cmbPaymentMode.Text = "";
            cmbBank.Text = "";
            txtIFSCode.Text = "";
            txtAccountNo.Text = "";
            txtBranchName.Text = "";
            txtBankBSRNo.Text = "";
            cmbCostCenter.Text = "";
        }
        private void Clearall_CustomiseField()
        {
            objEP.Clear();
          
        }


        private bool Validation_MyProfile()
        {
            if (txtESSLMachineID.Text == "")
            {
                txtESSLMachineID.Focus();
                objEP.SetError(txtESSLMachineID, "Enter ESSL Machine ID");
                return true;
            }
            else if (txtEMPCode.Text == "")
            {
                txtEMPCode.Focus();
                objEP.SetError(txtEMPCode, "Enter EMP Code");
                return true;
            }
            else if (txtFirstName.Text == "")
            {
                txtFirstName.Focus();
                objEP.SetError(txtFirstName, "Enter First Name");
                return true;
            }
            else if (txtMiddleName.Text == "")
            {
                txtMiddleName.Focus();
                objEP.SetError(txtMiddleName, "Enter Middle Name");
                return true;
            }
            else if (cmbGender.SelectedIndex == -1)
            {
                cmbGender.Focus();
                objEP.SetError(cmbGender, "select the Gender ");
                return true;
            }
            else if (txtAge.Text == "")
            {
                txtAge.Focus();
                objEP.SetError(txtAge, "Enter Age");
                return true;
            }
            else if (cmbDesignation.SelectedIndex == -1)
            {
                cmbDesignation.Focus();
                objEP.SetError(cmbDesignation, "Select Designation");
                return true;
            }
            else if (txtMonthlyCTC.Text == "")
            {
                txtMonthlyCTC.Focus();
                objEP.SetError(txtMonthlyCTC, "Enter Monthly CTC ");
                return true;
            }
            else if (txtMonthlyBasic.Text == "")
            {
                txtMonthlyBasic.Focus();
                objEP.SetError(txtMonthlyBasic, "Enter Monthly Basic");
                return true;
            }
            else if (txtMonthlyGross.Text == "")
            {
                txtMonthlyGross.Focus();
                objEP.SetError(txtMonthlyGross, "Enter Monthly Gross");
                return true;
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                cmbDepartment.Focus();
                objEP.SetError(cmbDepartment, "Selecte Department Name");
                return true;
            }
       
            else if (cmbEmployeeType.SelectedIndex == -1)
            {
                cmbEmployeeType.Focus();
                objEP.SetError(cmbEmployeeType, "Selecte Employee Type");
                return true;
            }
            else if (cmbPlaceOfPosting.SelectedIndex == -1)
            {
                cmbPlaceOfPosting.Focus();
                objEP.SetError(cmbPlaceOfPosting, "Selecte  Place Posting ");
                return true;
            }
            else if (cmbSalaryCycle.SelectedIndex == -1)
            {
                cmbSalaryCycle.Focus();
                objEP.SetError(cmbSalaryCycle, "Selecte Salary cycle");
                return true;
            }
            else
                return false;
        }

        private bool Validation_PersonalInformation()
        {
            if (txtPersonalEmailID.Text == "")
            {
                txtPersonalEmailID.Focus();
                objEP.SetError(txtPersonalEmailID, "Enter  Personal Email ID");
                return true;
            }
          
            else if (txtPFNo.Text == "")
            {
                txtPFNo.Focus();
                objEP.SetError(txtPFNo, "Enter PF No ");
                return true;
            }
            else if (txtESICNo. Text=="")
            {
                txtESICNo.Focus();
                objEP.SetError(txtESICNo, "Enter the ESI No  ");
                return true;
            }
            else if (txtUANNumber.Text == "")
            {
                txtUANNumber.Focus();
                objEP.SetError(txtUANNumber, "Enter UAN Number");
                return true;
            }
            else if (cmbMaritalStatus.SelectedIndex == -1)
            {
                cmbMaritalStatus.Focus();
                objEP.SetError(cmbMaritalStatus, "Select Marital Status");
                return true;
            }
            else if (dtpComfirmDate.Text == "")
            {
                dtpComfirmDate.Focus();
                objEP.SetError(dtpComfirmDate, "Enter Comfim Date ");
                return true;
            }
            else if (dtpDateOfRetrirement.Text == "")
            {
                dtpDateOfRetrirement.Focus();
                objEP.SetError(dtpDateOfRetrirement, "Enter Date Of Retrirement");
                return true;
            }
            else if (dtpPFStartDate.Text == "")
            {
                dtpPFStartDate.Focus();
                objEP.SetError(dtpPFStartDate, "Selecte  PF Start Date");
                return true;
            }
            else if (txtAadharCardNo.Text == "")
            {
                txtAadharCardNo.Focus();
                objEP.SetError(txtAadharCardNo, "AdharCard No.");
                return true;
            }
            else
                return false;

        }
        private bool Validation_Contact()
        {
            if (txtAddress.Text == "")
            {
                txtAddress.Focus();
                objEP.SetError(txtAddress, "Enter Address");
                return true;
            }
            else if (txtTaluka.Text == "")
            {
                txtTaluka.Focus();
                objEP.SetError(txtTaluka, "Enter Taluka");
                return true;
            }
            else if (txtDistrict.Text == "")
            {
                txtDistrict.Focus();
                objEP.SetError(txtDistrict, "Enter District");
                return true;
            }
            else if (txtCityVillage.Text == "")
            {
                cmbState.Focus();
                objEP.SetError(txtCityVillage, "Enter  City/Village");
                return true;
            }
            else if (cmbState.SelectedIndex == -1)
            {
                cmbState.Focus();
                objEP.SetError(cmbState, "select State ");
                return true;
            }
            else if (txtPincode.Text == "")
            {
                txtPincode.Focus();
                objEP.SetError(txtPincode, "Enter  Pin Code   ");
                return true;
            }
            else if (cmbPoliceStation.SelectedIndex  == -1)
            {
                cmbPoliceStation.Focus();
                objEP.SetError(cmbPoliceStation, "Enter Police Station");
                return true;
            }
            
            else if (cmbCountry.SelectedIndex == -1)
            {
                cmbCountry.Focus();
                objEP.SetError(cmbCountry, " Select Country");
                return true;
            }
            
            else if (txtMobileNoPAD.Text == "")
            {
                txtMobileNoPAD.Focus();
                objEP.SetError(txtMobileNoPAD, "Mobile No ");
                return true;
            }

            else
                return false;

        }

        private bool Validation_EmergencyContact()
        {
            if (txtName.Text == "")
            {
                txtName.Focus();
                objEP.SetError(txtName, "Enter Name ");
                return true;
            }
            else if (txtMobileNumber.Text == "")
            {
                txtMobileNumber.Focus();
                objEP.SetError(txtMobileNumber, "Enter Mobile Number");
                return true;
            }
            else if (txtWorkPhone.Text == "")
            {
                txtWorkPhone.Focus();
                objEP.SetError(txtWorkPhone, "Enter Work Phone Number");
                return true;
            }
            else if (txtHomePhone.Text=="")
            {
                txtHomePhone.Focus();
                objEP.SetError(txtHomePhone, " Enter Home Phone Number");
                return true;
            }
            else
                return false;

        }
        private bool Validation_Dependents()
        {
            if (txtNameNominee.Text == "")
            {
                txtNameNominee.Focus();
                objEP.SetError(txtNameNominee, "Enter  Nominee Name ");
                return true;
            }
            else if (txtAddressNominee.Text == "")
            {
                txtAddressNominee.Focus();
                objEP.SetError(txtAddressNominee, "Enter  Address Nominee");
                return true;
            }
            else if (dtpDateOfBirthNominee.Text == "")
            {
                dtpDateOfBirthNominee.Focus();
                objEP.SetError(dtpDateOfBirthNominee, "Enter the Date Of Birth Nominee");
                return true;
            }
            else if (cmbNomineeFor.SelectedIndex == -1)
            {
                cmbNomineeFor.Focus();
                objEP.SetError(cmbNomineeFor, " Select the Nominee For");
                return true;
            }
            else if (txtAadharcardNominee.Text == "")
            {
                txtAadharcardNominee.Focus();
                objEP.SetError(txtAadharcardNominee, " Enter Aadhar card");
                return true;
            }
            else if (txtNameFamilyDetails.Text == "")
            {
                txtNameFamilyDetails.Focus();
                objEP.SetError(txtNameFamilyDetails, " Enter Name");
                return true;
            }
            else if (cmbRelationshipFamilyDetails.SelectedIndex == -1)
            {
                cmbRelationshipFamilyDetails.Focus();
                objEP.SetError(cmbRelationshipFamilyDetails, " Select Relation Family Details");
                return true;
            }
            else if (cmbGenderFamilyDetails.SelectedIndex == -1)
            {
                cmbGenderFamilyDetails.Focus();
                objEP.SetError(cmbGenderFamilyDetails, " Select Gender ");
                return true;
            }
            else if (dtpDateOfBirthFD.Text == "")
            {
                dtpDateOfBirthFD.Focus();
                objEP.SetError(dtpDateOfBirthFD, "Enter Date of Birth");
                return true;
            }
            else if (txtPANCardFD.Text == "")
            {
                txtPANCardFD.Focus();
                objEP.SetError(txtPANCardFD, "Enter PAN Card");
                return true;
            }
            else if (txtAadharCardFD.Text == "")
            {
                txtAadharCardFD.Focus();
                objEP.SetError(txtAadharCardFD, "Enter Aadhar Card");
                return true;
            }
            else
                return false;
        }
        private bool Validation_Immigrantion()
        {
            if (txtPassportNo.Text == "")
            {
                txtPassportNo.Focus();
                objEP.SetError(txtPassportNo, "Enter PassPort No");
                return true;
            }
            else if (txtIssuesDate.Text == "")
            {
                txtIssuesDate.Focus();
                objEP.SetError(txtIssuesDate, "Enter the Issues Date");
                return true;
            }
            else if (txtRenewDate.Text == "")
            {
                txtRenewDate.Focus();
                objEP.SetError(txtRenewDate, "Enter Renew Date");
                return true;
            }
            else if (txtComments.Text == "")
            {
                txtComments.Focus();
                objEP.SetError(txtComments, "Enter Comment");
                return true;
            }
            else if (cmbCitizenship.SelectedIndex == -1)
            {
                cmbCitizenship.Focus();
                objEP.SetError(cmbCitizenship, " Enter Citizenship ");
                return true;
            }
            else if (dtpDateOfExpiry.Text == "")
            {
                dtpDateOfExpiry.Focus();
                objEP.SetError(dtpDateOfExpiry, " Select Date Of Expiry");
                return true;
            }
            else if (txtStatus.Text == "")
            {
                txtStatus.Focus();
                objEP.SetError(txtStatus, " Enter Status");
                return true;
            }
           
            else
                return false;

        }
        private bool Validation_ExperienceLanguages()
        {
            if (txtEmployer.Text == "")
            {
                txtEmployer.Focus();
                objEP.SetError(txtEmployer, "Enter employer");
                return true;
            }
            else if (txtLocation.Text == "")
            {
                txtLocation.Focus();
                objEP.SetError(txtLocation, "Enter Location");
                return true;
            }
            else if (dtpStartDate.Text == "")
            {
                dtpStartDate.Focus();
                objEP.SetError(dtpStartDate, "Enter start Date");
                return true;
            }
            else if (txtCTC.Text == "")
            {
                txtCTC.Focus();
                objEP.SetError(txtCTC, "Enter CTC");
                return true;
            }
            else if (txtManagerEL.Text== "")
            {
                txtManagerEL.Focus();
                objEP.SetError(txtManagerEL, " Enter Manager ");
                return true;
            }
            else if (txtRemrks.Text == "")
            {
                txtRemrks.Focus();
                objEP.SetError(txtRemrks, " Enter Remark ");
                return true;
            }
            else if (txtBranch.Text == "")
            {
                txtBranch.Focus();
                objEP.SetError(txtBranch, " Enter Branch");
                return true;
            }
            else if (txtBranch.Text == "")
            {
                txtBranch.Focus();
                objEP.SetError(txtBranch, " Enter Branch");
                return true;
            }
            else if (txtDesignationEL.Text == "")
            {
                txtDesignationEL.Focus();
                objEP.SetError(txtDesignationEL, " Enter Designation");
                return true;
            }
            else if (dtpEndDate.Text == "")
            {
                dtpEndDate.Focus();
                objEP.SetError(dtpEndDate, " Enter End Date");
                return true;
            }
            else if (txtGrossSalary.Text == "")
            {
                txtGrossSalary.Focus();
                objEP.SetError(txtGrossSalary, " Enter Gross Salary");
                return true;
            }
            else if (txtManagerContactNo.Text == "")
            {
                txtManagerContactNo.Focus();
                objEP.SetError(txtManagerContactNo, " Enter Manager Contact Number");
                return true;
            }
            else if (cmbIndustryType.SelectedIndex == -1)
            {
                cmbIndustryType.Focus();
                objEP.SetError(cmbIndustryType, " Enter Industry");
                return true;
            }
            else if (cmbLanguage.SelectedIndex == -1)
            {
                cmbLanguage.Focus();
                objEP.SetError(cmbLanguage, " Enter Language");
                return true;
            }
            else if (cmbFluency.SelectedIndex == -1)
            {
                cmbFluency.Focus();
                objEP.SetError(cmbFluency, " Enter Fluency");
                return true;
            }
            else
                return false;

        }
        private bool Validation_Qualification()
        {
            if (txtEducation.Text == "")
            {
                txtEducation.Focus();
                objEP.SetError(txtEducation, "Enter Education");
                return true;
            }
            else if (txtYear.Text == "")
            {
                txtYear.Focus();
                objEP.SetError(txtYear, "Enter Year");
                return true;
            }
            else if (dtpStartDateQualification.Text == "")
            {
                dtpStartDateQualification.Focus();
                objEP.SetError(dtpStartDateQualification, "Enter Start Date ");
                return true;
            }
            else if (txtComment.Text == "")
            {
                txtComment.Focus();
                objEP.SetError(txtComment, "Enter Comment");
                return true;
            }
            else if (txtSpeciazation.Text == "")
            {
                txtSpeciazation.Focus();
                objEP.SetError(txtSpeciazation, " Enter Speciazation ");
                return true;
            }
            else if (txtScoreClass.Text == "")
            {
                txtScoreClass.Focus();
                objEP.SetError(txtScoreClass, " Enter Scrore Class ");
                return true;
            }
            else if (dtpEndDateQualification.Text == "")
            {
                dtpEndDateQualification.Focus();
                objEP.SetError(dtpEndDateQualification, " Enter End date");
                return true;
            }
           
            else
                return false;
        }

        private bool Validation_Skill()
        {
            if (cmbSkill.SelectedIndex == -1)
            {
                cmbSkill.Focus();
                objEP.SetError(cmbSkill, "Enter Skill");
                return true;
            }
            else if (txtYesrsOfExperince.Text == "")
            {
                txtYesrsOfExperince.Focus();
                objEP.SetError(txtYesrsOfExperince, "Year of Experince");
                return true;
            }
            else if (txtCommentsSkill.Text == "")
            {
                txtCommentsSkill.Focus();
                objEP.SetError(txtCommentsSkill, "Enter Comment ");
                return true;
            }
            else
                return false;
        }
        private bool Validation_Attachment()
        {
            if (cmbDocumentName.SelectedIndex == -1)
            {
                cmbDocumentName.Focus();
                objEP.SetError(cmbDocumentName, "Select Document");
                return true;
            }
            else if (txtCommentAttachment.Text == "")
            {
                txtCommentAttachment.Focus();
                objEP.SetError(txtCommentAttachment, "Enter Comment ");
                return true;
            }
            
            else
                return false;
        }
        private bool Validation_Allowance()
        {
            if (txtBasic.Text=="")
            {
                txtBasic.Focus();
                objEP.SetError(txtBasic, "Select Document");
                return true;
            }
            else if (txtGross.Text == "")
            {
                txtGross.Focus();
                objEP.SetError(txtGross, " Enter Gross ");
                return true;
            }
            else if (txtAnnunalCTC.Text == "")
            {
                txtAnnunalCTC.Focus();
                objEP.SetError(txtAnnunalCTC, " EnterAnnunal CTC ");
                return true;
            }

            else if (txtTotalDeducation.Text == "")
            {
                txtTotalDeducation.Focus();
                objEP.SetError(txtTotalDeducation, " Enter Total Deduction ");
                return true;
            }

            else if (txtTotalEarning.Text == "")
            {
                txtTotalEarning.Focus();
                objEP.SetError(txtTotalEarning, " Total Earning ");
                return true;
            }

            else if (txtCTCAllowance.Text == "")
            {
                txtCTCAllowance.Focus();
                objEP.SetError(txtCTCAllowance, " Enter CTC Allowance ");
                return true;
            }

            else if (txtPT.Text == "")
            {
                txtPT.Focus();
                objEP.SetError(txtPT, " Enter PT ");
                return true;
            }

            else if (txtNet.Text == "")
            {
                txtNet.Focus();
                objEP.SetError(txtNet, " Enter Gross ");
                return true;
            }


            else
                return false;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Validation_MyProfile();
            Validation_PersonalInformation();
            Validation_Contact();
            Validation_EmergencyContact();
            Validation_Dependents();
            Validation_Immigrantion();
            Validation_ExperienceLanguages();
            Validation_Qualification();
            Validation_Skill();
            Validation_Attachment();
            Validation_Allowance();

        }

        private void txtESSLMachineID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtEMPCode.Focus();

            
        }

        private void cbFullPF_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtEMPCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtFirstName.Focus();

        }

        private void txtMiddleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLastName.Focus();
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMiddleName.Focus();
        }

        private void cmbGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
               dtpDateOfBirth.Focus();

        }

        private void dtpDateOfBirth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAge.Focus();
        }

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbGender.Focus();
        }

        private void txtAge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpDateOfJoin.Focus();
        }

        private void dtpDateOfJoin_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void cmbShiftName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbDesignation.Focus();
        }

        private void cmbDesignation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMonthlyCTC.Focus();

        }

        private void txtMonthlyCTC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMonthlyBasic.Focus();

        }

        private void txtMonthlyBasic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMonthlyGross.Focus();
        }

        private void txtMonthlyGross_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbDepartment.Focus();

        }

        private void cmbDepartment_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtEnrollNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbEmployeeType.Focus();
        }

        private void cmbEmployeeType_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtOfficeEmailID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbPlaceOfPosting.Focus();
        }

        private void cmbPlaceOfPosting_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void txtManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbSalaryCycle.Focus();

        }

        private void cmbSalaryCycle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbFullPF.Focus();
        }

        private void cbFullPF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbPT.Focus();
        }

        private void cbPT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbFixSalary.Focus();
        }

        private void cbFixSalary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbPartTime.Focus();
        }

        private void cbPartTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbProbation.Focus();
        }

        private void cbProbation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbLWF.Focus();

        }

        private void cbLWF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbPMGKYApplication.Focus();
        }

        private void cbPMGKYApplication_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbPensionNotApplicable.Focus();

        }

        private void txtPersonalEmailID_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtFathersName_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void txtMothersName_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dteDOB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPANNo.Focus();
        }

        private void txtPANNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPFNo.Focus();
        }

        private void txtPFNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtESICNo.Focus();
        }

        private void txtESICNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtUANNumber.Focus();
        }

        private void txtUANNumber_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void txtProbation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbMaritalStatus.Focus();
        }

        private void cmbMaritalStatus_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void cbIsMetroCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpComfirmDate.Focus();
        }

        private void dtpComfirmDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpDateOfRetrirement.Focus();
        }

        private void dtpDateOfRetrirement_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void txtNoOfChildren_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpPFStartDate.Focus();
        }

        private void dtpPFStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpMarriageDate.Focus();
        }

        private void dtpMarriageDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbPhysicalDisability.Focus();
        }

        private void cbPhysicalDisability_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAadharCardNo.Focus();
        }

        private void txtAadharCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtSkillType_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtMarkIdentification_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void cmbBloodGroup_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                txtTaluka.Focus();
        }

        private void txtTaluka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDistrict.Focus();
        }

        private void txtDistrict_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCityVillage.Focus();
        }

        private void txtCityVillage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbState.Focus();
        }

        private void cmbState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPincode.Focus();
        }

        private void txtPincode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbPoliceStation.Focus();
        }

        private void cmbPoliceStation_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void cbSomeAsPresentAddress_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void txtAddressPAD_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void txtTalukaPAD_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void txtDistrictPAD_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void txtcityVillagePAD_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void cmbStatePAD_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtPinCodePAD_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void cmbpoliceStationPAD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbCountry.Focus();
        }

        private void cmbCountry_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtWorkPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void txtPersonalPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtNationality_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void txtExtensionNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMobileNoPAD.Focus();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMobileNumber.Focus();
        }

        private void txtMobileNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtWorkPhone.Focus();
        }

        private void txtWorkPhone_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void cmbRelationship_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtHomePhone.Focus();
        }

        private void txtNameNominee_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void cmbRelationshipNominee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAddressNominee.Focus();
        }

        private void txtAddressNominee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpDateOfBirthNominee.Focus();
        }

        private void dtpDateOfBirthNominee_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtShareNominee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbNomineeFor.Focus();
        }

        private void txtNomineeFor_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void cbIsResidingWithHimHer_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtPANCardNominee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAadharcardNominee.Focus();
        }

        private void txtAadharcardNominee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNameFamilyDetails.Focus();
        }

        private void txtNameFamilyDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbRelationshipFamilyDetails.Focus();
        }

        private void cmbRelationshipFamilyDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbGenderFamilyDetails.Focus();
        }

        private void cmbGenderFamilyDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpDateOfBirthFD.Focus();
        }

        private void dtpDateOfBirthFD_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                chIsResidingWithHimHer.Focus();
        }

        private void chIsResidingWithHimHer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbIsDependentonyou.Focus();
        }

        private void cbIsDependentonyou_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPANCardFD.Focus();
        }

        private void txtPANCardFD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAadharCardFD.Focus();
        }

        private void txtAadharCardFD_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtHeight_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Passport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rbVisa.Focus();
        }

        private void lbVisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassportNo.Focus();
        }

        private void txtPassportNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtIssuesDate.Focus();
        }

        private void txtIssuesDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRenewDate.Focus();
        }

        private void txtRenewDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtComments.Focus();
        }

        private void txtComments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbCitizenship.Focus();
        }

        private void cmbCitizenship_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpDateOfExpiry.Focus();
        }

       

        private void txtEmployer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLocation.Focus();
        }

        private void txtLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpStartDate.Focus();
        }

        /*private void txtStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCTC.Focus();
        }*/

        private void txtCTC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtManagerEL.Focus();
        }

        private void txtManagerEL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRemrks.Focus();
        }

        private void txtRemrks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBranch.Focus();
        }

        private void txtBranch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDesignationEL.Focus();
        }

        private void txtDesignationEL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpEndDate.Focus();
        }

       /* private void txtEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtGrossSalary.Focus();
        }*/

        private void txtGrossSalary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtManagerContactNo.Focus();
        }

        private void txtManagerContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbIndustryType.Focus();
        }

        private void cmbIndustryType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbLanguage.Focus();
        }

        private void cmbLanguage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbFluency.Focus();
        }

        private void cmbFluency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbWrite.Focus();
        }

        private void cbWrite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbRead.Focus();
        }

        private void cbRead_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbSpeak.Focus();
        }

        private void cbSpeak_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbUnderstand.Focus();
        }

        private void txtEducation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSpeciazation.Focus();
        }

        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtScoreClass.Focus();
        }

       /* private void txtsStartDateQualification_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtComment.Focus();
        }*/

        private void txtComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtSpeciazation.Focus();
        }

        private void txtSpeciazation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtYear.Focus();
        }

        private void txtScoreClass_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                  dtpStartDateQualification.Focus();
        }

        private void cmbSkill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtYesrsOfExperince.Focus();
        }

        private void txtYesrsOfExperince_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCommentsSkill.Focus();
        }

        private void cmbDocumentName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCommentAttachment.Focus();
        }

        private void txtBasic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtGross.Focus();
        }

        private void txtGross_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAnnunalCTC.Focus();
        }

        private void txtAnnunalCTC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtTotalDeducation.Focus();
        }

        private void txtTotalDeducation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtTotalEarning.Focus();
        }

        private void txtTotalEarning_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCTCAllowance.Focus();
        }

        private void txtCTCAllowance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPT.Focus();
        }

        private void txtPT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNet.Focus();
        }

        private void cmbPaymentMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbBank.Focus();
        }

        private void cmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtIFSCode.Focus();
        }

        private void txtIFSCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAccountNo.Focus();
        }

        private void txtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBranchName.Focus();
        }

        private void txtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void cmbWagesType_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void cmbCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBankBSRNo.Focus();
        }

        private void txtBankBSRNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbCostCenter.Focus();
        }

        private void cmbCostCenter_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void cmbBusinessSegment_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void cmbSubVertical_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtSalesCode_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void cmbPaymentModeSecondaryBank_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void cmbBankSecondaryBank_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtIFSCCodeSecondaryBank_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void txtlbAccountNoSecondaryBank_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void txtBranchNameSecondaryBank_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void cmblbSalaryOnSecondaryBank_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtBusinessAreaCodeSecondaryBank_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void txtOldReferenceCodeSecondaryBank_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void txtQuartrNoSecondaryBank_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void cmbVerticalSecondaryBank_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void txtTesting_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtERFCode_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void txtLICGratuityID_KeyDown(object sender, KeyEventArgs e)
        {
             
        }

        private void dtpDateOfExpiry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtStatus.Focus();
        }

        private void dtpStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCTC.Focus();
        }

        private void dtpEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtGrossSalary.Focus();
        }

        private void dtpStartDateQualification_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpEndDateQualification.Focus();
        }

        private void dtpEndDateQualification_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtComment.Focus();
        }

        private void Employee_Master_Load(object sender, EventArgs e)
        {

        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            SetAge(dtpDateOfBirth,txtAge);
        }

        private void tpMyProfile_Click(object sender, EventArgs e)
        {

        }

        private void dtpDateOfJoin_ValueChanged(object sender, EventArgs e)
        {
            SetAge(dtpDateOfJoin, txtTotalYears);
        }

        private void lbCurrency_Click(object sender, EventArgs e)
        {

        }

        private void SetAge(DateTimePicker dtp,TextBox tb)
        {
            tb.Text = "";
            // Save today's date.
            var today = DateTime.Today;
 
            // Go back to the year in which the person was born in case of a leap year
            if (dtp.Value.Date > today)
            {
                tb.Text = "";
            }
            else
            {
                var age = today.Year - dtp.Value.Year;
                tb.Text = age.ToString();
            }
        }
    }
}
