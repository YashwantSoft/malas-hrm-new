using BusinessLayerUtility;
using SPApplication.Master;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SPApplication.HR
{
    public partial class EmployeeMaster : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public EmployeeMaster()
        {
            InitializeComponent();
            SetDesign();
            GetId();
        }

        public EmployeeMaster(int EmployeeId)
        {
            InitializeComponent();
            SetDesign();
            objPC.EmployeeId = EmployeeId;
            txtEmployeeNumber.Text = EmployeeId.ToString();
            txtEmployeePunchNumber.Text = objPC.EmployeeCode.ToString();

            FillEmployeeData();
            TableId = objPC.EmployeeId;
        }

        private void GetId()
        {
            txtEmployeeNumber.Text = "";
            txtEmployeeNumber.Text= Convert.ToString(objQL.GetTableId("EmployeeId", "employees"));
        }

        private void FillEmployeeData()
        {
            Fill_All_Controls();
            //txtEmployeeNumber.Text = TableId.ToString();
            FillGrid_EmployeeExperience();
            FillGrid_Qualification();
        }

        private void SetDesign()
        {
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_EMPLOYEEMASTER);
            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_MASTER);
            objDL.SetPlusButtonDesign(btnEmployeeType);
            objDL.SetPlusButtonDesign(btnContractor);
            objDL.SetPlusButtonDesign(btnAddDepartment);
            objDL.SetPlusButtonDesign(btnDesignation);
            objDL.SetPlusButtonDesign(btnAddLocation);
            objDL.SetPlusButtonDesign(btnShiftGroup);
            objDL.SetPlusButtonDesign(btnAddContry);
            objDL.SetPlusButtonDesign(btnAddContry1);
            objDL.SetPlusButtonDesign(btnAddState);
            objDL.SetPlusButtonDesign(btnAddState1);
            objDL.SetPlusButtonDesign(btnAddDistrict);
            objDL.SetPlusButtonDesign(btnAddDistrict1);
            objDL.SetPlusButtonDesign(btnAddTaluka);
            objDL.SetPlusButtonDesign(btnAddTaluka1);
            objDL.SetPlusButtonDesign(btnAddCityVillage);
            objDL.SetPlusButtonDesign(btnAddCityVillage1);
            objDL.SetPlusButtonDesign(btnAddArea);
            objDL.SetPlusButtonDesign(btnAddArea1);
            objDL.SetPlusButtonDesign(btnAddJobProfile);

            objDL.SetPlusButtonDesign(btnAddState);
            objDL.SetPlusButtonDesign(btnLanguage);
            objDL.SetPlusButtonDesign(btnFluency);
            objDL.SetPlusButtonDesign(btnPoliceStation1);

            objQL.Fill_Master_ComboBox(cmbEmployeeType, "employementtypemaster");
            //objQL.Fill_Master_ComboBox(cmbDepartment, "departmentmaster");
            objQL.Fill_Master_ComboBox(cmbContractor, "contractormaster");
            objQL.Fill_Master_ComboBox(cmbDesignation, "designationmaster");
            objQL.Fill_Master_ComboBox(cmbDesignationExperience, "designationmaster");
            objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");

            objQL.Fill_Master_ComboBox(cmbShiftGroup, "shiftgroups");

            btnDocuments.BackColor = objDL.GetBackgroundColor();
            btnDocuments.ForeColor = objDL.GetForeColor();

            objQL.Fill_Master_ComboBox(cmbContryName, "contrymaster");
            objQL.Fill_Master_ComboBox(cmbContryName1, "contrymaster");
            objQL.Fill_Master_ComboBox(cmbCategory, "categories");

            objQL.Fill_Master_ComboBox(cmbBankPrimary, "bankmaster");
            objQL.Fill_Master_ComboBox(cmbBankSecondary, "bankmaster");
            objQL.Fill_Master_ComboBox(cmbBankNameNominee, "bankmaster");
            objQL.Fill_Master_ComboBox(cmbJobProfile, "jobprofilemaster");

            objRL.ColumnNameCM = "EffectType";
            objRL.Fill_ComboBox_Comman(cmbEffetType);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void ClearAll()
        {
            objEP.Clear();
            TableId = 0;
            cmbType.SelectedIndex = -1;
            cmbType.Text = "All";
            ClearAll_Profile();
            ClearAll_Contact();
            ClearAll_Dependents();
            ClearAll_Compliance();
            ClearAll_ExperienceAndLanguages();
            ClearAll_Qualification();
            ClearAll_Skill();
            ClearAll_Attachment();
            ClearAll_Allowance();
            ClearAll_Salary();
            Clearall_CustomiseField();
            cmbLocation.Enabled = true;
            cmbDepartment.Enabled = true;
            btnAddDepartment.Enabled = true;
            btnAddLocation.Enabled = true;
            //dtpDateOfExit.Value = new DateTime(3000, 01, 01);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearchCode.Text = "";
            txtSearch.Text = "";
            SearchFlag = false;
            SearchFlagCode = false;
            ClearAll();
            FillGrid();
        }

        private void ClearAll_Profile()
        {
            objEP.Clear();
            txtEmployeeNumber.Text = "";
            txtEmployeePunchNumber.Text = "";
            cmbInitial.SelectedIndex = -1;
            txtEmployeeName.Text = "";
            txtMiddleName.Text = "";
            cmbGender.SelectedIndex = -1;
            dtpDateOfBirth.Value = DateTime.Now.Date;
            txtAge.Text = "";
            dtpDateOfJoin.Value = DateTime.Now.Date;
            txtTotalYears.Text = "";
            cmbMaritalStatus.SelectedIndex = -1;
            dtpMarriageDate.Value = DateTime.Now.Date;
            txtPersonalEmailID.Text = "";
            txtMobileNumber.Text = "";
            txtOfficialEmail.Text = "";
            cmbBloodGroup.SelectedIndex = -1;
            txtAadharCardNo.Text = "";
            txtPANNo.Text = "";
            txtPersonalIdentificationMark.Text = "";
            cbPhysicalDisability.Checked = false;
            txtDescriptionPhysicalDisability.Text = "";
            txtFathersName.Text = "";
            txtMothersName.Text = "";
            cmbEmployeeType.SelectedIndex = -1;
            cmbContractor.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbDesignation.SelectedIndex = -1;
            cmbJobProfile.SelectedIndex = -1;
            cmbLocation.SelectedIndex = -1;
            cmbShiftGroup.SelectedIndex = -1;
            cmbCategory.SelectedIndex = -1;
        }

        private void ClearAll_Contact()
        {
            objEP.Clear();
            cmbNationality.SelectedIndex = -1;
            cbSame.Checked = false;
            txtAddress.Text = "";
            cmbContryName.SelectedIndex = -1;
            cmbStateName.SelectedIndex = -1;
            cmbDistrictName.SelectedIndex = -1;
            cmbTalukaName.SelectedIndex = -1;
            cmbCityVillageName.SelectedIndex = -1;
            cmbAreaName.SelectedIndex = -1;
            txtPincode.Text = "";
            cmbPoliceStation.Text = "";
            txtAddress1.Text = "";
            cmbContryName1.SelectedIndex = -1;
            cmbStateName1.SelectedIndex = -1;
            cmbDistrictName1.SelectedIndex = -1;
            cmbTalukaName1.SelectedIndex = -1;
            cmbCityVillageName1.SelectedIndex = -1;
            cmbAreaName1.SelectedIndex = -1;
            txtPincode1.Text = "";
            cmbPoliceStation1.Text = "";

        }


        private void ClearAll_Dependents()
        {
            objEP.Clear();
            txtNameMember.Text = "";
            cmbRelationshipMember.SelectedIndex = -1;
            cmbGenderMember.SelectedIndex = -1;
            dtpDOBMember.Value = DateTime.Now.Date;
            cbIsResidingWithHimHer.Checked = false;
            cbIsDependentOnYou.Checked = false;
            txtPANCardMember.Text = "";
            txtAadharCardMember.Text = "";
            txtContactNoMember.Text = "";
            cbPrimaryNomineeMember.Checked = false;
            txtNameNominee.Text = "";
            cmbRelationshipNominee.SelectedIndex = -1;
            txtAddressNominee.Text = "";
            cbIsResidingWithHimHer.Checked = false;
            cbIsDependentOnYou.Checked = false;
            txtNameNominee.Text = "";
            txtAddressNominee.Text = "";
            dtpDateOfBirthNominee.Text = "";
            txtContactNoNominee.Text = "";
            cmbBankNameNominee.SelectedIndex = -1;
            txtAccountNoNominee.Text = "";
            txtIFSCCodeNominee.Text = "";
            txtMICRCodeNominee.Text = "";
            txtNameEC.Text = "";
            txtMobileNumberEC.Text = "";
            txtWorkPhoneEC.Text = "";
            cmbRelationshipEC.SelectedIndex = -1;
            txtHomePhoneEC.Text = "";

        }
        private void ClearAll_Compliance()
        {
            objEP.Clear();
            txtPFNo.Text = "";
            txtUANNumber.Text = "";
            txtESICNo.Text = "";
            txtLWFLINNo.Text = "";
            //dtpComfirmDate.Text = "";
            //dtpPFStartDate.Text = "";
            //dtpDateOfRetrirement.Text = "";
            
            txtPassportNo.Text = "";
            dtpPassportIssueDate.Value = DateTime.Now.Date;
            dtpRenewalDate.Value = DateTime.Now.Date;
            //dtpDateOfExpiry.Value = DateTime.Now.Date;
            dtpComfirmDate.Value = DateTime.Now.Date;
            dtpPFStartDate.Value = DateTime.Now.Date;
            dtpDateOfRetrirement.Value = DateTime.Now.Date;

            //dtpDateOfExit.Value = new DateTime(3000, 01, 01);
            dtpA1.Value = DateTime.Now.Date;
            dtpA2.Value = DateTime.Now.Date;
            dtpA3.Value = DateTime.Now.Date;

        }

        private void ClearAll_ExperienceAndLanguages()
        {
            objEP.Clear();


            cmbLanguage.SelectedIndex = -1;
            cmbFluency.SelectedIndex = -1;
            cbWrite.Checked = false;
            cbRead.Checked = false;
            cbSpeak.Checked = false;
            cbUnderstand.Checked = false;
        }


        private void ClearAll_Qualification()
        {
            EmployeeQualificationId = 0;
            GridFlag = false;
            btnDeleteGrid.Visible = false;
            objEP.Clear();
            cmbQualification.SelectedIndex = -1;
            txtStream.Text = "";
            txtCollege.Text = "";
            txtUniversity.Text = "";
            cmbYearOfPassing.SelectedIndex = -1;
            txtGradeQualification.Text = "";
        }

        int EmployeeExperienceId = 0;

        private void ClearAll_PreviousExperience()
        {
            EmployeeExperienceId = 0;
            GridFlag = false;
            FlagDelete = false;
            btnDeletePreviousExperience.Visible = false;
            objEP.Clear();
            txtOrganizationNameExperience.Text = "";
            txtOrganizationAddressExperience.Text = "";
            dtpStartDate.Value = DateTime.Now.Date;
            dtpEndDate.Value = DateTime.Now.Date;
            cmbDesignationExperience.SelectedIndex = -1;
            txtGrossSalaryPreviousExperience.Text = "";
        }

        private void ClearAll_Skill()
        {
            GridFlag = false;
            EmployeeSkillId = 0;
            objEP.Clear();
            cmbSkillType.SelectedIndex = -1;
            cmbSkills.SelectedIndex = -1;
            txtYesrsOfExperince.Text = "";
            txtCommentsSkill.Text = "";

        }
        private void ClearAll_Attachment()
        {
            objEP.Clear();

        }

        private void ClearAll_Allowance()
        {
            objEP.Clear();
            txtBasicMonthly.Text = "";
            txtHRAMonthly.Text = "";
            txtTravelAllowance.Text = "";
            txtLoanAmount.Text = "";
            txtOtherAdvance.Text = "";
            txtGrossSalaryMonthly.Text = "";

            txtBasicAnual.Text = "";
            txtHRAAnual.Text = "";
            txtEducationAllowanceAnual.Text = "";
            txtConveyanceAllowanceAnual.Text = "";
            txtOtherAllowanceAnual.Text = "";
            txtGrossSalaryAnual.Text = "";
        }

        private void ClearAll_Salary()
        {
            objEP.Clear();
            cmbPaymentMode.SelectedIndex = -1;
            cmbBankPrimary.SelectedIndex = -1;
            txtIFSCode.Text = "";
            txtAccountNo.Text = "";
            txtBranchName.Text = "";
            txtMICRNO.Text = "";
            cmbCostCenter.SelectedIndex = -1;
            txtBasicMonthly.Text = "";
            txtHRAMonthly.Text = "";
            cmbPaymentModeSB.SelectedIndex = -1;
            cmbBankSecondary.Text = "";
            txtAccountNoSB.Text = "";
            txtBranchNameSB.Text = "";
            txtMICRNOSB.Text = "";
            txtIFSCCodeSB.Text = "";

        }
        private void Clearall_CustomiseField()
        {
            objEP.Clear();
        }

        private bool Validation_Profile()
        {
            objEP.Clear();
            if (txtEmployeeNumber.Text == "")
            {
                txtEmployeeNumber.Focus();
                objEP.SetError(txtEmployeeNumber, "Enter Employee Number");
                return true;
            }
            else if (txtEmployeePunchNumber.Text == "")
            {
                txtEmployeePunchNumber.Focus();
                objEP.SetError(txtEmployeePunchNumber, "Enter Employee Punch Number");
                return true;
            }
            else if (CheckExist())
            {
                txtEmployeePunchNumber.Focus();
                objEP.SetError(txtEmployeePunchNumber, "Code Duplicate enter other code");
                return true;
            }
            else if (cmbInitial.SelectedIndex == -1)
            {
                cmbInitial.Focus();
                objEP.SetError(cmbInitial, "select Initial ");
                return true;
            }
            else if (txtEmployeeName.Text == "")
            {
                txtEmployeeName.Focus();
                objEP.SetError(txtEmployeeName, "Enter First Name");
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
                objEP.SetError(txtAge, "Enter Middle Name");
                return true;
            }
            else if (cmbMaritalStatus.Text == "")
            {
                cmbMaritalStatus.Focus();
                objEP.SetError(cmbMaritalStatus, "Enter Marital Status");
                return true;
            }
            //else if (txtPersonalEmailID.Text == "")
            //{
            //    txtPersonalEmailID.Focus();
            //    objEP.SetError(txtPersonalEmailID, "Enter Personal Email ID");
            //    return true;
            //}
            else if (txtMobileNumber.Text == "")
            {
                txtMobileNumber.Focus();
                objEP.SetError(txtMobileNumber, "Enter Mobile No");
                return true;
            }
            //else if (txtOfficialEmail.Text == "")
            //{
            //    txtOfficialEmail.Focus();
            //    objEP.SetError(txtOfficialEmail, "Enter Official Email");
            //    return true;
            //}
            //else if (cmbBloodGroup.Text == "")
            //{
            //    cmbBloodGroup.Focus();
            //    objEP.SetError(cmbBloodGroup, "Enter  Blood Group");
            //    return true;
            //}
            else if (txtAadharCardNo.Text == "")
            {
                txtAadharCardNo.Focus();
                objEP.SetError(txtAadharCardNo, "Enter Aadhar Card No");
                return true;
            }
            else if (txtPANNo.Text == "")
            {
                txtPANNo.Focus();
                objEP.SetError(txtPANNo, "Enter PAN No");
                return true;
            }
            else if (txtFathersName.Text == "")
            {
                txtFathersName.Focus();
                objEP.SetError(txtFathersName, "Enter Fathers Name");
                return true;
            }
            else if (txtMothersName.Text == "")
            {
                txtMothersName.Focus();
                objEP.SetError(txtMothersName, "Enter Mothers Name");
                return true;
            }
            //else if (txtPersonalIdentificationMark.Text == "")
            //{
            //    txtPersonalIdentificationMark.Focus();
            //    objEP.SetError(txtPersonalIdentificationMark, "Enter Personal Identification Mark");
            //    return true;
            //}
            else if (cbPhysicalDisability.Checked && txtDescriptionPhysicalDisability.Text == "")
            {
                txtDescriptionPhysicalDisability.Focus();
                objEP.SetError(txtDescriptionPhysicalDisability, "Enter Description");
                return true;
            }
            else if (txtTotalYears.Text == "")
            {
                txtTotalYears.Focus();
                objEP.SetError(txtTotalYears, "Enter Total Years");
                return true;
            }
            else if (cmbContractor.SelectedIndex == -1)
            {
                cmbContractor.Focus();
                objEP.SetError(cmbContractor, "Select Contractor");
                return true;
            }
            else if (cmbEmployeeType.SelectedIndex == -1)
            {
                cmbEmployeeType.Focus();
                objEP.SetError(cmbEmployeeType, "Select Employee Type");
                return true;
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                cmbDepartment.Focus();
                objEP.SetError(cmbDepartment, "Select Department");
                return true;
            }
            else if (cmbDesignation.SelectedIndex == -1)
            {
                cmbDesignation.Focus();
                objEP.SetError(cmbDesignation, "Select Designation");
                return true;
            }
            else if (txtGrade.Text == "")
            {
                txtGrade.Focus();
                objEP.SetError(txtGrade, "Enter Grade");
                return true;
            }
            else if (cmbJobProfile.SelectedIndex == -1)
            {
                cmbJobProfile.Focus();
                objEP.SetError(cmbJobProfile, "Select Job Profile");
                return true;
            }
            else if (cmbCategory.SelectedIndex == -1)
            {
                cmbCategory.Focus();
                objEP.SetError(cmbCategory, "Select Category");
                return true;
            }
            else if (cmbLocation.Text == "")
            {
                cmbLocation.Focus();
                objEP.SetError(cmbLocation, "Enter Place Of Posting");
                return true;
            }
            else if (cmbShiftGroup.SelectedIndex == -1)
            {
                cmbShiftGroup.Focus();
                objEP.SetError(cmbShiftGroup, "Select Shift Group");
                return true;
            }

            else
                return false;
        }

        private bool Validation_Contact()
        {
            if (cmbNationality.SelectedIndex == -1)
            {
                cmbNationality.Focus();
                objEP.SetError(cmbNationality, "Nationality ");
                return true;
            }
            else if (txtAddress.Text == "")
            {
                txtAddress.Focus();
                objEP.SetError(txtAddress, "Enter Address");
                return true;
            }
            else if (cmbContryName.SelectedIndex == -1)
            {
                cmbContryName.Focus();
                objEP.SetError(cmbContryName, "Select Contry Name");
                return true;
            }
            else if (cmbStateName.SelectedIndex == -1)
            {
                cmbStateName.Focus();
                objEP.SetError(cmbStateName, "Select State Name");
                return true;
            }
            else if (cmbDistrictName.SelectedIndex == -1)
            {
                cmbDistrictName.Focus();
                objEP.SetError(cmbDistrictName, "Enter District Name");
                return true;
            }
            else if (cmbTalukaName.SelectedIndex == -1)
            {
                cmbTalukaName.Focus();
                objEP.SetError(cmbTalukaName, "select  Taluka Name ");
                return true;
            }
            else if (cmbCityVillageName.SelectedIndex == -1)
            {
                cmbCityVillageName.Focus();
                objEP.SetError(cmbCityVillageName, "select City Village Name");
                return true;
            }
            else if (cmbAreaName.SelectedIndex == -1)
            {
                cmbAreaName.Focus();
                objEP.SetError(cmbAreaName, "select Area Name");
                return true;
            }
            else if (txtPincode.Text == "")
            {
                txtPincode.Focus();
                objEP.SetError(txtPincode, "Enter  Pin Code   ");
                return true;
            }
            else if (cmbPoliceStation.SelectedIndex == -1)
            {
                cmbPoliceStation.Focus();
                objEP.SetError(cmbPoliceStation, "Enter Police Station");
                return true;
            }
            else if (cmbContryName1.SelectedIndex == -1)
            {
                cmbContryName1.Focus();
                objEP.SetError(cmbContryName1, "Select Contry Name");
                return true;
            }
            else if (cmbStateName1.SelectedIndex == -1)
            {
                cmbStateName1.Focus();
                objEP.SetError(cmbStateName1, "Select State Name");
                return true;
            }
            else if (cmbDistrictName1.SelectedIndex == -1)
            {
                cmbDistrictName1.Focus();
                objEP.SetError(cmbDistrictName1, "Enter District Name");
                return true;
            }
            else if (cmbTalukaName1.SelectedIndex == -1)
            {
                cmbTalukaName1.Focus();
                objEP.SetError(cmbTalukaName1, "select  Taluka Name ");
                return true;
            }
            else if (cmbCityVillageName1.SelectedIndex == -1)
            {
                cmbCityVillageName1.Focus();
                objEP.SetError(cmbCityVillageName1, "select City Village Name");
                return true;
            }
            else if (cmbAreaName1.SelectedIndex == -1)
            {
                cmbAreaName1.Focus();
                objEP.SetError(cmbAreaName1, "select Area Name");
                return true;
            }
            else if (txtPincode1.Text == "")
            {
                txtPincode1.Focus();
                objEP.SetError(txtPincode1, "Enter Pin Code");
                return true;
            }
            else
                return false;
        }

        private bool Validation_Dependents()
        {
            objEP.Clear();
            if (txtNameNominee.Text == "")
            {
                txtNameNominee.Focus();
                objEP.SetError(txtNameNominee, "Enter  Nominee Name ");
                return true;
            }
            else if (cmbRelationshipNominee.SelectedIndex == -1)
            {
                cmbRelationshipNominee.Focus();
                objEP.SetError(cmbRelationshipNominee, "Enter Relationship Nominee");
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
            else if (txtContactNoNominee.Text == "")
            {
                txtContactNoNominee.Focus();
                objEP.SetError(txtContactNoNominee, "Enter the Contact No Nominee");
                return true;
            }
            else if (cmbBankNameNominee.SelectedIndex == -1)
            {
                cmbBankNameNominee.Focus();
                objEP.SetError(cmbBankNameNominee, " Select Bank Name Nominee");
                return true;
            }
            else if (txtAccountNoNominee.Text == "")
            {
                txtAccountNoNominee.Focus();
                objEP.SetError(txtAccountNoNominee, " Enter  Account No Nominee");
                return true;
            }
            else if (txtIFSCCodeNominee.Text == "")
            {
                txtIFSCCodeNominee.Focus();
                objEP.SetError(txtIFSCCodeNominee, " Enter IFSC Code Nominee");
                return true;
            }
            else if (txtMICRCodeNominee.Text == "")
            {
                txtMICRCodeNominee.Focus();
                objEP.SetError(txtMICRCodeNominee, " Enter MICR Code");
                return true;
            }
            else if (txtNameMember.Text == "")
            {
                txtNameMember.Focus();
                objEP.SetError(txtNameMember, " Enter Name");
                return true;
            }
            else if (cmbRelationshipMember.SelectedIndex == -1)
            {
                cmbRelationshipMember.Focus();
                objEP.SetError(cmbRelationshipMember, " Select Relation Family Details");
                return true;
            }
            else if (cmbGenderMember.SelectedIndex == -1)
            {
                cmbGenderMember.Focus();
                objEP.SetError(cmbGenderMember, " Select Gender ");
                return true;
            }
            else if (dtpDOBMember.Text == "")
            {
                dtpDOBMember.Focus();
                objEP.SetError(dtpDOBMember, "Enter Date of Birth");
                return true;
            }
            else if (cbIsResidingWithHimHer.Text == "")
            {
                cbIsResidingWithHimHer.Focus();
                objEP.SetError(cbIsResidingWithHimHer, "Select Is Residing With HimHer");
                return true;
            }
            else if (cbIsDependentOnYou.Text == "")
            {
                cbIsDependentOnYou.Focus();
                objEP.SetError(cbIsDependentOnYou, "Select Is Dependent on you");
                return true;
            }
            else if (txtPANCardMember.Text == "")
            {
                txtPANCardMember.Focus();
                objEP.SetError(txtPANCardMember, "Enter PAN Card");
                return true;
            }
            else if (txtAadharCardMember.Text == "")
            {
                txtAadharCardMember.Focus();
                objEP.SetError(txtAadharCardMember, "Enter Aadhar Card");
                return true;
            }
            else if (txtContactNoMember.Text == "")
            {
                txtContactNoMember.Focus();
                objEP.SetError(txtContactNoMember, "Enter Contact No");
                return true;
            }
            else if (cbPrimaryNomineeMember.Text == "")
            {
                cbPrimaryNomineeMember.Focus();
                objEP.SetError(cbPrimaryNomineeMember, "Enter Primary Nominee");
                return true;
            }
            else if (txtNameEC.Text == "")
            {
                txtNameEC.Focus();
                objEP.SetError(txtNameEC, "Enter Name");
                return true;
            }
            else if (txtMobileNumberEC.Text == "")
            {
                txtMobileNumberEC.Focus();
                objEP.SetError(txtMobileNumberEC, "Enter Mobile Number");
                return true;
            }
            else if (txtWorkPhoneEC.Text == "")
            {
                txtWorkPhoneEC.Focus();
                objEP.SetError(txtWorkPhoneEC, "Enter Work Phone");
                return true;
            }
            else if (cmbRelationshipEC.Text == "")
            {
                cmbRelationshipEC.Focus();
                objEP.SetError(cmbRelationshipEC, "Enter Relationship");
                return true;
            }
            else if (txtHomePhoneEC.Text == "")
            {
                txtHomePhoneEC.Focus();
                objEP.SetError(txtHomePhoneEC, "Enter Home Phone");
                return true;
            }
            else
                return false;
        }

        private bool Validation_Compliance()
        {
            objEP.Clear();
            if (txtPFNo.Text == "")
            {
                txtPFNo.Focus();
                objEP.SetError(txtPFNo, " Enter PFNo");
                return true;
            }
            else if (txtUANNumber.Text == "")
            {
                txtUANNumber.Focus();
                objEP.SetError(txtUANNumber, " Enter UAN Number");
                return true;
            }
            else if (txtLWFLINNo.Text == "")
            {
                txtLWFLINNo.Focus();
                objEP.SetError(txtLWFLINNo, " Enter LWF LIN No");
                return true;
            }
            //else if (txtPassportNo.Text == "")
            //{
            //    txtPassportNo.Focus();
            //    objEP.SetError(txtPassportNo, "Enter PassPort No");
            //    return true;
            //}
            else if (dtpDateOfExpiry.Text == "")
            {
                dtpDateOfExpiry.Focus();
                objEP.SetError(dtpDateOfExpiry, " Select Date Of Expiry");
                return true;
            }
            else if (dtpComfirmDate.Text == "")
            {
                dtpComfirmDate.Focus();
                objEP.SetError(dtpComfirmDate, " Enter Comfirm Date");
                return true;
            }
            else if (dtpPFStartDate.Text == "")
            {
                dtpPFStartDate.Focus();
                objEP.SetError(dtpPFStartDate, " Enter PF Start Date");
                return true;
            }
            else if (dtpDateOfRetrirement.Text == "")
            {
                dtpDateOfRetrirement.Focus();
                objEP.SetError(dtpDateOfRetrirement, " Enter Date Of Retrirement");
                return true;
            }
            else if (dtpDateOfExit.Text == "")
            {
                dtpDateOfExit.Focus();
                objEP.SetError(dtpDateOfExit, " Enter Date Of Exit");
                return true;
            }
            else
                return false;
        }

        //private bool Validation_ExperienceLanguages()
        //{
        //    if (txtOrganizationNameExperience.Text == "")
        //    {
        //        txtOrganizationNameExperience.Focus();
        //        objEP.SetError(txtOrganizationNameExperience, "Enter employer");
        //        return true;
        //    }
        //    else if (dtpStartDate.Text == "")
        //    {
        //        dtpStartDate.Focus();
        //        objEP.SetError(dtpStartDate, "Enter start Date");
        //        return true;
        //    }

        //    else if (dtpEndDate.Text == "")
        //    {
        //        dtpEndDate.Focus();
        //        objEP.SetError(dtpEndDate, " Enter End Date");
        //        return true;
        //    }

        //    else if (cmbLanguage.SelectedIndex == -1)
        //    {
        //        cmbLanguage.Focus();
        //        objEP.SetError(cmbLanguage, " Enter Language");
        //        return true;
        //    }
        //    else if (cmbFluency.SelectedIndex == -1)
        //    {
        //        cmbFluency.Focus();
        //        objEP.SetError(cmbFluency, " Enter Fluency");
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //private bool Validation_Qualification()
        //{
        //    if (txtYear.Text == "")
        //    {
        //        txtYear.Focus();
        //        objEP.SetError(txtYear, "Enter Year");
        //        return true;
        //    }
        //    else if (dtpStartDateQualification.Text == "")
        //    {
        //        dtpStartDateQualification.Focus();
        //        objEP.SetError(dtpStartDateQualification, "Enter Start Date ");
        //        return true;
        //    }
        //    else if (txtComment.Text == "")
        //    {
        //        txtComment.Focus();
        //        objEP.SetError(txtComment, "Enter Comment");
        //        return true;
        //    }
        //    else if (txtSpeciazation.Text == "")
        //    {
        //        txtSpeciazation.Focus();
        //        objEP.SetError(txtSpeciazation, " Enter Speciazation ");
        //        return true;
        //    }
        //    else if (txtScoreClass.Text == "")
        //    {
        //        txtScoreClass.Focus();
        //        objEP.SetError(txtScoreClass, " Enter Scrore Class ");
        //        return true;
        //    }
        //    else if (dtpEndDateQualification.Text == "")
        //    {
        //        dtpEndDateQualification.Focus();
        //        objEP.SetError(dtpEndDateQualification, " Enter End date");
        //        return true;
        //    }
        //    else if (txtOrganizationNameExperience.Text == "")
        //    {
        //        txtOrganizationNameExperience.Focus();
        //        objEP.SetError(txtOrganizationNameExperience, " Enter Employer");
        //        return true;
        //    }

        //    else if (txtBranch.Text == "")
        //    {
        //        txtBranch.Focus();
        //        objEP.SetError(txtBranch, " Enter Branch ");
        //        return true;
        //    }

        //    else if (txtBranch.Text == "")
        //    {
        //        txtBranch.Focus();
        //        objEP.SetError(txtBranch, " Enter Branch");
        //        return true;
        //    }
        //    else if (dtpStartDate.Text == "")
        //    {
        //        dtpStartDate.Focus();
        //        objEP.SetError(dtpStartDate, " Enter Start Date");
        //        return true;
        //    }

        //    else if (dtpEndDate.Text == "")
        //    {
        //        dtpEndDate.Focus();
        //        objEP.SetError(dtpEndDate, " Enter End date");
        //        return true;
        //    }
        //    else if (txtCTC.Text == "")
        //    {
        //        txtCTC.Focus();
        //        objEP.SetError(txtCTC, " Enter CTC ");
        //        return true;
        //    }

        //    else if (txtGrossSalary.Text == "")
        //    {
        //        txtGrossSalary.Focus();
        //        objEP.SetError(txtGrossSalary, " Enter Gross Salary");
        //        return true;
        //    }
        //    else if (txtManagerEL.Text == "")
        //    {
        //        txtManagerEL.Focus();
        //        objEP.SetError(txtManagerEL, " Enter Manager");
        //        return true;
        //    }
        //    else if (txtManagerContactNo.Text == "")
        //    {
        //        txtManagerContactNo.Focus();
        //        objEP.SetError(txtManagerContactNo, " Enter Manager Contact No");
        //        return true;
        //    }
        //    else if (txtRemrks.Text == "")
        //    {
        //        txtRemrks.Focus();
        //        objEP.SetError(txtRemrks, " Enter Remrks");
        //        return true;
        //    }
        //    else if (cmbIndustryType.SelectedIndex == -1)
        //    {
        //        cmbIndustryType.Focus();
        //        objEP.SetError(cmbIndustryType, "select Industry Type");
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        private bool Validation_Skill()
        {
            if (cmbSkillType.SelectedIndex == -1)
            {
                cmbSkillType.Focus();
                objEP.SetError(cmbSkillType, "Select  Skill type");
                return true;
            }
            else if (cmbLanguage.SelectedIndex == -1)
            {
                cmbLanguage.Focus();
                objEP.SetError(cmbLanguage, "Select Language");
                return true;
            }
            else if (cmbFluency.SelectedIndex == -1)
            {
                cmbFluency.Focus();
                objEP.SetError(cmbFluency, "Select Fluency");
                return true;
            }


            else
                return false;
        }


        private bool Validation_Salary()
        {
            if (cmbCostCenter.SelectedIndex == -1)
            {
                cmbCostCenter.Focus();
                objEP.SetError(cmbCostCenter, "Select Cost");
                return true;
            }
            else if (txtBasicMonthly.Text == "")
            {
                txtBasicMonthly.Focus();
                objEP.SetError(txtBasicMonthly, " Enter Monthly Basic ");
                return true;
            }

            else if (txtHRAMonthly.Text == "")
            {
                txtHRAMonthly.Focus();
                objEP.SetError(txtHRAMonthly, " Enter Monthly Gross ");
                return true;
            }
            else if (cmbPaymentMode.SelectedIndex == -1)
            {
                cmbPaymentMode.Focus();
                objEP.SetError(cmbPaymentMode, " Enter Payment Mode ");
                return true;
            }
            else if (cmbBankPrimary.SelectedIndex == -1)
            {
                cmbBankPrimary.Focus();
                objEP.SetError(cmbBankPrimary, " Enter Bank ");
                return true;
            }
            else if (txtAccountNo.Text == "")
            {
                txtAccountNo.Focus();
                objEP.SetError(txtAccountNo, " Total AccountNo ");
                return true;
            }
            else if (txtBranchName.Text == "")
            {
                txtBranchName.Focus();
                objEP.SetError(txtBranchName, " Enter Branch Name ");
                return true;
            }

            else if (txtMICRNO.Text == "")
            {
                txtMICRNO.Focus();
                objEP.SetError(txtMICRNO, " Enter MICR NO ");
                return true;
            }
            else if (txtIFSCode.Text == "")
            {
                txtIFSCode.Focus();
                objEP.SetError(txtIFSCode, " Enter IFSC Code ");
                return true;
            }
            else
                return false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ProfileSaveDB();
        }

        private bool Validation()
        {
            bool FlagReturn = false;
            return FlagReturn;
        }

        int PhysicalDisiabity = 0;

        private bool CheckExist()
        {
            bool flag = false;

            DataSet ds = new DataSet();
            objBL.Query ="select * from Employees where EmployeeCode="+txtEmployeePunchNumber.Text+" and EmployeeId != "+objPC.EmployeeId +"";
            ds = objBL.ReturnDataSet();
            if(ds.Tables[0].Rows.Count > 0 )    

                { flag = true; }    


            return flag;
        }
        private void ProfileSaveDB()
        {
            if (!Validation_Profile())
            {
                objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
                objPC.EmployeeCodeInDevice = Convert.ToInt32(txtEmployeePunchNumber.Text);
                objPC.EmpInital = cmbInitial.Text;

                objPC.EmployeeName = txtEmployeeName.Text;
                objPC.Gender = cmbGender.Text;
                objPC.DOB = dtpDateOfBirth.Value;
                objPC.Age = Convert.ToInt32(txtAge.Text);

                objPC.MaritalStatus = cmbMaritalStatus.Text;
                objPC.MarriageDate = dtpMarriageDate.Value;
                objPC.PersonalEmailID = txtPersonalEmailID.Text;
                objPC.MobileNo = txtMobileNumber.Text;
                objPC.OfficialEmailID = txtOfficialEmail.Text;
                objPC.BloodGroup = cmbBloodGroup.Text;

                objPC.AadharCardNumber = txtAadharCardNo.Text;
                objPC.PANCardNumber = txtPANNo.Text;
                objPC.FatherName = txtFathersName.Text;
                objPC.MotherName = txtMothersName.Text;
                objPC.DrivingLicenseNumber = txtDrivingLicenseNo.Text;

                objPC.PersonalIdentificationMark = txtPersonalIdentificationMark.Text;
                if (cbPhysicalDisability.Checked)
                    PhysicalDisiabity = 1;

                objPC.PhysicalDisability = Convert.ToInt32(PhysicalDisiabity);
                objPC.DescriptionOfPhysicalDisability = txtDescriptionPhysicalDisability.Text;
                objPC.DOJ = dtpDateOfJoin.Value;
                objPC.TotalYearsService = txtTotalYears.Text;
                objPC.ContractorId = Convert.ToInt32(cmbContractor.SelectedValue);
                objPC.EmployementTypeId = Convert.ToInt32(cmbEmployeeType.SelectedValue);
                objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                objPC.DesignationId = Convert.ToInt32(cmbDesignation.SelectedValue);
                objPC.JobProfile = cmbJobProfile.Text;
                objPC.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                //objPC.MemoTemplateMasterId = Convert.ToInt32(cmbCategory.SelectedValue);
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objPC.ShiftGroupId = Convert.ToInt32(cmbShiftGroup.SelectedValue);
                objPC.Status = cmbStatus.Text;
                objPC.NewFlag = 1;
                objPC.OverTimeApplicable = OverTimeApplicable;
                objPC.DateOfExit = dtpDateOfExit.Value;

                if(cbFlexibleHours.Checked)
                    objPC.FlexibleHoursFlag = 1;
                else
                    objPC.FlexibleHoursFlag = 0;

                Result = objQL.SP_Employees_Profile_Insert_Update_Delete();

                if (Result > 0)
                {
                    //Updates on 25-12-2024

                    //Save_Effective_Data_New_Employee();

                    //objPC.EmployeeId = Convert.ToInt32(objRL.ReturnMaxID_Fix("Employees"));
                    if (!FlagDelete)
                    {
                        tbEmployee.SelectedIndex = (tbEmployee.SelectedIndex + 1 < tbEmployee.TabCount) ?
                                tbEmployee.SelectedIndex + 1 : tbEmployee.SelectedIndex;

                        objRL.ShowMessage(7, 1);
                    }
                    else
                        objRL.ShowMessage(9, 1);

                    FillGrid();
                    //ClearAll();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        string EffectType = string.Empty, MasterName = string.Empty;//, MasterName1 = string.Empty;
        int EmployeeId = 0;
        DateTime FromDate;
        int MasterId = 0;//, IsPrimary = 0;//, MasterId1 = 0;
        private void Save_Effective_Data_New_Employee()
        {
            //dtpDateOfJoin
            //Location and Department
            //Contractor
            //Designation
            //Employment Type
            //Job Profile
            //Weekly Off
            if(objPC.NewFlag ==1)
            {
                EmployeeId = TableId;
                FromDate = dtpDateOfJoin.Value;

                if (cmbLocation.SelectedIndex > -1 && cmbDepartment.SelectedIndex > -1)
                {
                    
                    EffectType = "Location and Department";
                    MasterName = cmbLocation.Text;
                    MasterId = Convert.ToInt32(cmbLocation.SelectedValue);
                    MasterName1 = cmbDepartment.Text;
                    MasterId1 = Convert.ToInt32(cmbDepartment.SelectedValue);
                    IsPrimary = 1;
                    Save_Effective_Query();
                }
                if (cmbContractor.SelectedIndex > -1)
                {
                    EffectType = "Contractor";
                    MasterName = cmbContractor.Text;
                    MasterId = Convert.ToInt32(cmbContractor.SelectedValue);
                    MasterName1 = "NA";
                    MasterId1 = 0;
                    IsPrimary = 1;
                    Save_Effective_Query();
                }
                if (cmbDesignation.SelectedIndex > -1)
                {
                     
                    EffectType = "Designation";
                    MasterName = cmbDesignation.Text;
                    MasterId = Convert.ToInt32(cmbDesignation.SelectedValue);
                    MasterName1 = "NA";
                    MasterId1 = 0;
                    IsPrimary = 1;
                    Save_Effective_Query();
                }
                if (cmbJobProfile.SelectedIndex > -1)
                {
                    EffectType = "Job Profile";
                    MasterName = cmbJobProfile.Text;
                    MasterId = Convert.ToInt32(cmbJobProfile.SelectedValue);
                    MasterName1 = "NA";
                    MasterId1 = 0;
                    IsPrimary = 1;
                    Save_Effective_Query();
                }
                if (cmbEmployeeType.SelectedIndex > -1)
                {
                    EffectType = "Employment Type";
                    MasterName = cmbEmployeeType.Text;
                    MasterId = Convert.ToInt32(cmbEmployeeType.SelectedValue);
                    MasterName1 = "NA";
                    MasterId1 = 0;
                    IsPrimary = 1;
                    Save_Effective_Query();
                }
                if (cmbCategory.SelectedIndex > -1)
                {
                    EffectType = "Weekly Off";
                    MasterName = cmbCategory.Text;
                    MasterId = Convert.ToInt32(cmbCategory.SelectedValue);
                    MasterName1 = "NA";
                    MasterId1 = 0;
                    IsPrimary = 1;
                    Save_Effective_Query();
                }
            }
        }

        private void Save_Effective_Query()
        {
            objBL.Query = "insert into employeeseffect(EmployeeId,FromDate,EffectType,MasterName,MasterId,MasterName1,MasterId1,IsPrimary,UserId) values(" + EmployeeId + ",'" + FromDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + EffectType + "','" + MasterName + "'," + MasterId + ",'" + MasterName1 + "'," + MasterId1 + "," + IsPrimary + "," + BusinessLayer.EmployeeLoginId_Static + ")";
            Result = objBL.Function_ExecuteNonQuery();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProfileSaveDB();

            //Validation_Profile();
            //Validation_Contact();
            //Validation_Dependents();
            //Validation_Compliance();
            //Validation_ExperienceLanguages();
            //Validation_Qualification();
            //Validation_Skill();
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
                txtEmployeePunchNumber.Focus();
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
            if (e.KeyCode == Keys.Enter)
                txtTotalYears.Focus();
        }

        private void cmbShiftName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbDesignation_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtMonthlyCTC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBasicMonthly.Focus();
        }

        private void txtMonthlyBasic_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtHRAMonthly.Focus();
        }

        private void txtMonthlyGross_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtEnrollNo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtOfficeEmailID_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtManager_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbSalaryCycle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbPaymentMode.Focus();
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
                cbFullPF.Focus();
        }

        private void cbPMGKYApplication_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbPensionNotApplicable.Focus();
        }

        private void dteDOB_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPANNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPersonalIdentificationMark.Focus();
        }

        private void txtPFNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtUANNumber.Focus();
        }

        private void txtESICNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtLWFLINNo.Focus();
        }

        private void txtProbation_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cbIsMetroCity_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dtpComfirmDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpPFStartDate.Focus();
        }

        private void txtNoOfChildren_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dtpPFStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpDateOfRetrirement.Focus();
        }

        private void dtpMarriageDate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cbPhysicalDisability_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtDescriptionPhysicalDisability.Focus();
        }


        private void txtPincode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbNationality.Focus();
        }

        private void cmbPoliceStation_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                txtAddress1.Focus();
        }

        private void cmbpoliceStationPAD_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPincode.Focus();
        }

        private void txtExtensionNo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtMobileNumber_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbRelationshipNominee_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtAddressNominee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpDateOfBirthNominee.Focus();
        }

        private void dtpDateOfBirthNominee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtContactNoNominee.Focus();
        }

        private void txtShareNominee_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtNomineeFor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbBankNameNominee.Focus();
        }

        private void txtPANCardNominee_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtAadharcardNominee_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtNameFamilyDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbRelationshipMember.Focus();
        }

        private void cmbRelationshipFamilyDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbGenderMember.Focus();
        }

        private void cmbGenderFamilyDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpDOBMember.Focus();
        }

        private void dtpDateOfBirthFD_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                cbIsResidingWithHimHer.Focus();
        }

        private void chIsResidingWithHimHer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbIsDependentOnYou.Focus();
        }

        private void cbIsDependentonyou_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPANCardMember.Focus();
        }

        private void txtPANCardFD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAadharCardMember.Focus();
        }

        private void txtAadharCardFD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtContactNoMember.Focus();
        }

        private void Passport_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void lbVisa_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPassportNo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtIssuesDate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtRenewDate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtComments_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbCitizenship_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpDateOfExpiry.Focus();
        }

        private void txtLocation_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtDesignationEL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpStartDate.Focus();
        }

        private void cmbIndustryType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbLanguage.Focus();
        }

        private void cmbLanguage_KeyDown(object sender, KeyEventArgs e)
        {

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

        }

        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {

        }

        /* private void txtsStartDateQualification_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Enter)
                 txtComment.Focus();
         }*/

        private void txtComment_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSpeciazation_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtScoreClass_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbSkill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbSkills.Focus();
        }

        private void txtYesrsOfExperince_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtCommentsSkill.Focus();
        }

        private void cmbDocumentName_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtBasic_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtGross_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtAnnunalCTC_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtTotalDeducation_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtTotalEarning_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCTCAllowance_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtPT_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbPaymentMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbBankPrimary.Focus();
        }

        private void cmbBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAccountNo.Focus();
        }

        private void txtIFSCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbPaymentModeSB.Focus();
        }

        private void txtAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBranchName.Focus();
        }

        private void txtBranchName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMICRNO.Focus();
        }

        private void dtpStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpEndDate.Focus();
        }
        private void Employee_Master_Load(object sender, EventArgs e)
        {
            cmbType.Text = "New";
            objPC.NewFlag = 1;
            SearchFlag = false;
            FillGrid();
            //dtpDateOfExit.Value = new DateTime(3000, 01, 01);
        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            SetAge(dtpDateOfBirth, txtAge);
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

        private void SetAge(DateTimePicker dtp, TextBox tb)
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

        private void txtEmployeePunchNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbInitial.Focus();
        }

        private void txtTotalYears_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbMaritalStatus.Focus();
        }

        private void dtpMarriageDate_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPersonalEmailID.Focus();
        }

        private void txtPersonalEmailID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMobileNumber.Focus();
        }

        private void txtMobileNoPAD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtOfficialEmail.Focus();
        }

        private void txtOfficialEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbBloodGroup.Focus();
        }

        private void cmbBloodGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAadharCardNo.Focus();
        }

        private void txtAadharCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPANNo.Focus();
        }

        private void cmbMaritalStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpMarriageDate.Focus();
        }

        private void txtPersonalIdentificationMark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbPhysicalDisability.Focus();
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtFathersName.Focus();
        }

        private void txtFathersName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                txtMothersName.Focus();
        }

        private void txtMothersName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbEmployeeType.Focus();
        }

        private void cmbEmployeeType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbContractor.Focus();
        }

        private void cmbContractor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbDepartment.Focus();
        }

        private void cmbDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbDesignation.Focus();
        }

        private void cmbDesignation_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbJobProfile.Focus();
        }

        private void cmbJobProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbLocation.Focus();
        }

        private void cmbLocation_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbGrade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbShiftGroup.Focus();
        }

        private void cmbNationality_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbPoliceStation.Focus();
        }



        private void txtPincodePAD_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbNationalityPAD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbPoliceStation1.Focus();
        }

        private void cmbPoliceStationPAD_KeyDown_1(object sender, KeyEventArgs e)
        {

        }



        private void txtContactNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbPrimaryNomineeMember.Focus();
        }

        private void cbPrimaryNominee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNameNominee.Focus();
        }

        private void cmbRelationshipNominee_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAddressNominee.Focus();
        }

        private void txtContactNoNominee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                clbNomineeFor.Focus();
        }

        private void cmbBankNameNominee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAccountNoNominee.Focus();
        }

        private void txtIFSCCodeNominee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMICRCodeNominee.Focus();
        }

        private void txtMICRCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtNameEC.Focus();
        }

        private void txtName_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                txtMobileNumberEC.Focus();
        }

        private void txtMobileNumber_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtWorkPhoneEC.Focus();
        }

        private void txtWorkPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbRelationshipEC.Focus();
        }

        private void cmbRelationship_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtHomePhoneEC.Focus();
        }

        private void txtNameNominee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbRelationshipNominee.Focus();
        }

        private void txtAccountNoNominee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtIFSCCodeNominee.Focus();
        }


        private void txtComment_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtOrganizationNameExperience.Focus();
        }



        private void cmbLanguage_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbFluency.Focus();
        }

        private void cbUnderstand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbSkillType.Focus();
        }

        private void cmbSkills_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtYesrsOfExperince.Focus();
        }



        private void txtMICRNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtIFSCode.Focus();
        }

        private void cmbPaymentModeSB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbBankSecondary.Focus();
        }

        private void txtBankSB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtAccountNoSB.Focus();
        }

        private void txtAccountNoSB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtBranchNameSB.Focus();
        }

        private void txtBranchNameSB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMICRNOSB.Focus();
        }

        private void txtMICRNOSB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtIFSCCodeSB.Focus();
        }

        private void txtUANNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtESICNo.Focus();
        }

        private void txtLWFLINNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rbPassport.Focus();
        }

        private void rbPassport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rbVisa.Focus();
        }

        private void rbVisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPassportNo.Focus();
        }

        private void txtStatus_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtDateOfJoining_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpComfirmDate.Focus();
        }

        private void dtpDateOfRetrirement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dtpDateOfExit.Focus();
        }

        private void dtpDateOfExit_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cmbCostCenter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cbFullPF.Focus();
        }

        private void cmbInitial_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
                txtEmployeeName.Focus();
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            if (TableId != 0)
            {
                objPC.FormName = this.Name;
                objPC.FormHeader = BusinessResources.LBL_HEADER_EMPLOYEEMASTER;
                objPC.TableId = TableId;
                Documents objForm = new Documents();
                objForm.ShowDialog(this);
            }
        }

        private void cmbDesignation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Grade();
        }

        private void Fill_Grade()
        {
            if (cmbDesignation.SelectedIndex > -1)
            {
                txtGrade.Text = "";
                DataSet ds = new DataSet();
                objQL.Designation = cmbDesignation.Text;
                ds = objQL.SP_DesignationMaster_By_Designation();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Grade"].ToString())))
                        txtGrade.Text = Convert.ToString(ds.Tables[0].Rows[0]["Grade"].ToString());

                    OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OvertimeFlag"])));
                    objPC.DesignationCategory = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["DesignationCategory"]));
                    if (OverTimeApplicable == 1)
                        cbOverTimeApplicable.Checked = true;
                    else
                        cbOverTimeApplicable.Checked = false;
                }
            }
        }

        private void cmbContryName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_State();
        }

        private void cmbStateName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_District();
        }

        private void cmbDistrictName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Taluka();
        }

        private void cmbTalukaName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_CityVillage();

        }

        private void cmbCityVillageName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Area();

        }

        private void cmbAreaName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetPincode();
        }

        private void GetPincode()
        {
            if (cmbAreaName.SelectedIndex > -1)
            {
                objPC.AreaId = Convert.ToInt32(cmbAreaName.SelectedValue);
                txtPincode.Text = Convert.ToString(objQL.SP_Get_Pincode_By_CityVillageId());
            }
        }

        private void Fill_State()
        {
            if (cmbContryName.SelectedIndex > -1)
            {
                objPC.SearchType = "State";
                objPC.SearchId = Convert.ToInt32(cmbContryName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbStateName);
                cmbDistrictName.SelectedIndex = -1;
                cmbTalukaName.SelectedIndex = -1;
            }
        }

        private void Fill_District()
        {
            if (cmbContryName.SelectedIndex > -1 && cmbStateName.SelectedIndex > -1)
            {
                objPC.SearchType = "District";
                objPC.SearchId = Convert.ToInt32(cmbStateName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbDistrictName);
                cmbTalukaName.SelectedIndex = -1;
            }
        }

        private void Fill_Taluka()
        {
            if (cmbContryName.SelectedIndex > -1 && cmbStateName.SelectedIndex > -1 && cmbDistrictName.SelectedIndex > -1)
            {
                objPC.SearchType = "Taluka";
                objPC.SearchId = Convert.ToInt32(cmbDistrictName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbTalukaName);
            }
        }

        private void Fill_CityVillage()
        {
            if (cmbContryName.SelectedIndex > -1 && cmbStateName.SelectedIndex > -1 && cmbDistrictName.SelectedIndex > -1 && cmbTalukaName.SelectedIndex > -1)
            {
                objPC.SearchType = "CityVillage";
                objPC.SearchId = Convert.ToInt32(cmbTalukaName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbCityVillageName);
                objQL.SP_State_District_Area_Master_By_Id(cmbPoliceStation);
            }
        }

        private void Fill_Area()
        {
            if (cmbContryName.SelectedIndex > -1 && cmbStateName.SelectedIndex > -1 && cmbDistrictName.SelectedIndex > -1 && cmbTalukaName.SelectedIndex > -1 && cmbCityVillageName.SelectedIndex > -1)
            {
                objPC.SearchType = "Area";
                objPC.SearchId = Convert.ToInt32(cmbCityVillageName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbAreaName);
            }
        }

        private void btnAddContry_Click(object sender, EventArgs e)
        {
            CountryMaster objForm = new CountryMaster();
            objForm.ShowDialog(this);
            objQL.Fill_Master_ComboBox(cmbContryName, "contrymaster");
            cmbStateName.SelectedIndex = -1;
            cmbDistrictName.SelectedIndex = -1;
            cmbTalukaName.SelectedIndex = -1;
            cmbCityVillageName.SelectedIndex = -1;
        }

        private void btnAddState_Click(object sender, EventArgs e)
        {
            StateMaster objForm = new StateMaster();
            objForm.ShowDialog(this);
            Fill_State();
        }

        private void btnAddDistrict_Click(object sender, EventArgs e)
        {
            DistrictMaster objForm = new DistrictMaster();
            objForm.ShowDialog(this);
            Fill_District();
        }

        private void btnAddTaluka_Click(object sender, EventArgs e)
        {
            TalukaMaster objForm = new TalukaMaster();
            objForm.ShowDialog(this);
            Fill_Taluka();
        }

        private void btnAddCityVillage_Click(object sender, EventArgs e)
        {
            CityVillageMaster objForm = new CityVillageMaster();
            objForm.ShowDialog(this);
            Fill_CityVillage();
        }

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            AreaMaster objForm = new AreaMaster();
            objForm.ShowDialog(this);
            Fill_Area();
        }


        private void cmbContryName1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_State1();
        }

        private void cmbStateName1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_District1();
        }

        private void cmbDistrictName1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Taluka1();
        }

        private void cmbTalukaName1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_CityVillage1();

        }

        private void cmbCityVillageName1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Area1();

        }

        private void cmbAreaName1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetPincode1();
        }

        private void GetPincode1()
        {
            if (cmbAreaName1.SelectedIndex > -1)
            {
                objPC.AreaId = Convert.ToInt32(cmbAreaName1.SelectedValue);
                txtPincode1.Text = Convert.ToString(objQL.SP_Get_Pincode_By_CityVillageId());
            }
        }

        private void Fill_State1()
        {
            if (cmbContryName1.SelectedIndex > -1)
            {
                objPC.SearchType = "State";
                objPC.SearchId = Convert.ToInt32(cmbContryName1.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbStateName1);
                cmbDistrictName1.SelectedIndex = -1;
                cmbTalukaName1.SelectedIndex = -1;
            }
        }

        private void Fill_District1()
        {
            if (cmbContryName1.SelectedIndex > -1 && cmbStateName1.SelectedIndex > -1)
            {
                objPC.SearchType = "District";
                objPC.SearchId = Convert.ToInt32(cmbStateName1.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbDistrictName1);
                cmbTalukaName1.SelectedIndex = -1;
            }
        }

        private void Fill_Taluka1()
        {
            if (cmbContryName1.SelectedIndex > -1 && cmbStateName1.SelectedIndex > -1 && cmbDistrictName1.SelectedIndex > -1)
            {
                objPC.SearchType = "Taluka";
                objPC.SearchId = Convert.ToInt32(cmbDistrictName1.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbTalukaName1);
            }
        }

        private void Fill_CityVillage1()
        {
            if (cmbContryName1.SelectedIndex > -1 && cmbStateName1.SelectedIndex > -1 && cmbDistrictName1.SelectedIndex > -1 && cmbTalukaName1.SelectedIndex > -1)
            {
                objPC.SearchType = "CityVillage";
                objPC.SearchId = Convert.ToInt32(cmbTalukaName1.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbCityVillageName1);
                objQL.SP_State_District_Area_Master_By_Id(cmbPoliceStation1);
            }
        }

        private void Fill_Area1()
        {
            if (cmbContryName1.SelectedIndex > -1 && cmbStateName1.SelectedIndex > -1 && cmbDistrictName1.SelectedIndex > -1 && cmbTalukaName1.SelectedIndex > -1 && cmbCityVillageName1.SelectedIndex > -1)
            {
                objPC.SearchType = "Area";
                objPC.SearchId = Convert.ToInt32(cmbCityVillageName1.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbAreaName1);
            }
        }



        private void btnAddContry1_Click(object sender, EventArgs e)
        {
            CountryMaster objForm = new CountryMaster();
            objForm.ShowDialog(this);
            objQL.Fill_Master_ComboBox(cmbContryName1, "contrymaster");
            cmbStateName1.SelectedIndex = -1;
            cmbDistrictName1.SelectedIndex = -1;
            cmbTalukaName1.SelectedIndex = -1;
            cmbCityVillageName1.SelectedIndex = -1;
        }

        private void btnAddState1_Click(object sender, EventArgs e)
        {
            StateMaster objForm = new StateMaster();
            objForm.ShowDialog(this);
            Fill_State1();
        }

        private void btnAddDistrict1_Click(object sender, EventArgs e)
        {
            DistrictMaster objForm = new DistrictMaster();
            objForm.ShowDialog(this);
            Fill_District1();
        }

        private void btnAddTaluka1_Click(object sender, EventArgs e)
        {
            TalukaMaster objForm = new TalukaMaster();
            objForm.ShowDialog(this);
            Fill_Taluka1();
        }

        private void btnAddCityVillage1_Click(object sender, EventArgs e)
        {
            CityVillageMaster objForm = new CityVillageMaster();
            objForm.ShowDialog(this);
            Fill_CityVillage1();
        }

        private void btnAddArea1_Click(object sender, EventArgs e)
        {
            AreaMaster objForm = new AreaMaster();
            objForm.ShowDialog(this);
            Fill_Area1();
        }

        private void btnPoliceStation_Click(object sender, EventArgs e)
        {
            CityVillageMaster objForm = new CityVillageMaster();
            objForm.ShowDialog(this);
            Fill_PoliceStation();
        }

        private void btnPoliceStation1_Click(object sender, EventArgs e)
        {
            CityVillageMaster objForm = new CityVillageMaster();
            objForm.ShowDialog(this);
            Fill_PoliceStation1();
        }

        private void Fill_PoliceStation()
        {
            if (cmbContryName.SelectedIndex > -1 && cmbStateName.SelectedIndex > -1 && cmbDistrictName1.SelectedIndex > -1 && cmbTalukaName.SelectedIndex > -1)
            {
                objPC.SearchType = "CityVillage";
                objPC.SearchId = Convert.ToInt32(cmbTalukaName.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbPoliceStation);
            }
        }

        private void Fill_PoliceStation1()
        {
            if (cmbContryName1.SelectedIndex > -1 && cmbStateName1.SelectedIndex > -1 && cmbDistrictName1.SelectedIndex > -1 && cmbTalukaName1.SelectedIndex > -1)
            {
                objPC.SearchType = "CityVillage";
                objPC.SearchId = Convert.ToInt32(cmbTalukaName1.SelectedValue);
                objQL.SP_State_District_Area_Master_By_Id(cmbPoliceStation1);
            }
        }

        private void cbSame_CheckedChanged(object sender, EventArgs e)
        {
            SamePresentAddress();
        }

        private void SamePresentAddress()
        {
            if (cbSame.Checked)
            {
                txtAddress1.Text = txtAddress.Text;
                cmbContryName1.Text = cmbContryName.Text;
                Fill_State1();
                cmbStateName1.Text = cmbStateName.Text;
                Fill_District1();
                cmbDistrictName1.Text = cmbDistrictName.Text;
                Fill_Taluka1();
                cmbTalukaName1.Text = cmbTalukaName.Text;
                Fill_CityVillage1();
                cmbCityVillageName1.Text = cmbCityVillageName.Text;
                cmbPoliceStation1.Text = cmbCityVillageName.Text;
                Fill_Area1();
                cmbAreaName1.Text = cmbAreaName.Text;
                GetPincode1();
                txtPincode1.Text = txtPincode.Text;

            }
            else
            {
                ClearAll_PermanentAddress();
            }
        }

        private void ClearAll_PermanentAddress()
        {
            txtAddress1.Text = "";
            cmbContryName1.SelectedIndex = -1;
            cmbStateName1.SelectedIndex = -1;
            cmbDistrictName1.SelectedIndex = -1;
            cmbTalukaName1.SelectedIndex = -1;
            cmbCityVillageName1.SelectedIndex = -1;
            cmbPoliceStation1.SelectedIndex = -1;
            cmbAreaName1.SelectedIndex = -1;
            txtPincode1.Text = "";

        }

        private void txtTotalYears_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ContactSaveDB()
        {
            if (!Validation_Contact())
            {
                objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
                objPC.EmployeeCodeInDevice = Convert.ToInt32(txtEmployeePunchNumber.Text);
                objPC.EmpInital = cmbInitial.Text;

                objPC.EmployeeName = txtEmployeeName.Text;
                objPC.Gender = cmbGender.Text;
                objPC.DOB = dtpDateOfBirth.Value;
                objPC.Age = Convert.ToInt32(txtAge.Text);

                objPC.MaritalStatus = cmbMaritalStatus.Text;
                objPC.MarriageDate = dtpMarriageDate.Value;
                objPC.PersonalEmailID = txtPersonalEmailID.Text;
                objPC.MobileNo = txtMobileNumberEC.Text;
                objPC.OfficialEmailID = txtOfficialEmail.Text;
                objPC.BloodGroup = cmbBloodGroup.Text;

                objPC.AadharCardNumber = txtAadharCardNo.Text;
                objPC.FatherName = txtFathersName.Text;
                objPC.MotherName = txtMothersName.Text;
                objPC.DrivingLicenseNumber = txtDrivingLicenseNo.Text;

                objPC.PersonalIdentificationMark = txtPersonalIdentificationMark.Text;
                if (cbPhysicalDisability.Checked)
                    PhysicalDisiabity = 1;

                objPC.PhysicalDisability = Convert.ToInt32(PhysicalDisiabity);
                objPC.DescriptionOfPhysicalDisability = txtDescriptionPhysicalDisability.Text;
                objPC.DOJ = dtpDateOfJoin.Value;
                objPC.TotalYearsService = txtTotalYears.Text;
                objPC.ContractorId = Convert.ToInt32(cmbContractor.SelectedValue);
                objPC.EmployementTypeId = Convert.ToInt32(cmbEmployeeType.SelectedValue);
                objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                objPC.DesignationId = Convert.ToInt32(cmbDesignation.SelectedValue);
                objPC.JobProfile = cmbJobProfile.Text;
                objPC.CategoryId = Convert.ToInt32(cmbCategory.SelectedValue);
                objPC.ReportingTo = 1;//  Convert.ToInt32(cmbShiftGroup.SelectedValue);

                Result = objQL.SP_Employees_Profile_Insert_Update_Delete();
                if (Result > 0)
                {

                    //objPC.EmployeeId = Convert.ToInt32(objRL.ReturnMaxID_Fix("Employees"));
                    if (!FlagDelete)
                    {
                        objRL.ShowMessage(7, 1);

                    }
                    else
                        objRL.ShowMessage(9, 1);

                    //FillGrid();
                    //ClearAll();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        int SameAsPA = 0;

        private void btnNextContact_Click(object sender, EventArgs e)
        {
            if (!Validation_Contact())
            {
                objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
                objPC.Nationality = cmbNationality.Text;
                objPC.Address = txtAddress.Text;
                objPC.AreaId = Convert.ToInt32(cmbAreaName.SelectedValue);
                objPC.PoliceStationId = Convert.ToInt32(cmbPoliceStation.SelectedValue);

                if (cbSame.Checked)
                    SameAsPA = 1;
                else
                    SameAsPA = 0;

                objPC.SameAsPA = SameAsPA;
                objPC.Address1 = txtAddress1.Text;
                objPC.AreaId1 = Convert.ToInt32(cmbAreaName1.SelectedValue);
                objPC.PoliceStationId1 = Convert.ToInt32(cmbPoliceStation1.SelectedValue);

                Result = objQL.SP_Employees_Contact_Update();

                if (Result > 0)
                {
                    //objPC.EmployeeId = Convert.ToInt32(objRL.ReturnMaxID_Fix("Employees"));
                    if (!FlagDelete)
                    {
                        tbEmployee.SelectedIndex = (tbEmployee.SelectedIndex + 1 < tbEmployee.TabCount) ?
                               tbEmployee.SelectedIndex + 1 : tbEmployee.SelectedIndex;
                        objRL.ShowMessage(7, 1);
                    }
                    else
                        objRL.ShowMessage(9, 1);

                    //FillGrid();
                    //ClearAll();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        protected void FillGrid()
        {
            lblTotalCount.Text = "";
            dataGridView1.DataSource = null;
            DataSet ds = new DataSet();
            objPC.EmployeeName = txtSearch.Text;

            if (SearchFlagCode)
                objPC.EmployeeCode = EmployeeCode_V;
            else
                objPC.EmployeeCode = 0;

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
                objPC.SearchFlag = true;

            ds = objQL.SP_Employees_FillGrid();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                //0 EmployeeId, 
                //1 EmployeeCode,
                //2 EmpInital,
                //3 EmployeeName, 
                //4 Gender, 
                //5 DOB, 
                //6 Age, 
                //7 MaritalStatus, 
                //8 MarriageDate, 
                //9 PersonalEmailID,
                //10 MobileNo, 
                //11 OfficialEmailID,
                //12 BloodGroup,
                //13 AadharCardNumber,
                //14 PanCardNumber,
                //15 FartherName, 
                //16 MotherName,
                //17 DrivingLicenseNumber, 
                //18 PersonalIdentificationMark, 
                //19 PhysicalDisability, 
                //20 DescriptionOfPhysicalDisability,
                //21 DOJ, 
                //22 TotalYearsService, 
                //23 E.ContractorId, 
                //24 CM.ContractorName as 'Contractor Name',
                //25 E.EmployementTypeId, 
                //26 ETM.EmployementType as 'Employement Type',
                //27 E.DepartmentId, 
                //28 DM.Department,
                //29 E.DesignationId, 
                //30 DESM.Designation,
                //31 E.JobProfile, 
                //32 E.CategoryId, 
                //33 CT.CategoryFName as 'Category F Name',
                //34 E.LocationId,
                //35 LM.LocationName as 'Location Name',
                //36 RE.eportingTo

                ////0 E.EmployeeId, 
                //dataGridView1.Columns[1].Width = 100;//1 E.EmployeeCode as 'Code',
                ////2 E.EmpInital,
                //dataGridView1.Columns[3].Width = 200;//3 E.EmployeeName as 'Employee Name', 
                //dataGridView1.Columns[4].Width = 60;//4 E.Gender, 
                ////5 E.DOB, 
                //dataGridView1.Columns[6].Width = 40;//6 E.Age, 
                //dataGridView1.Columns[7].Width = 120;//7 E.MobileNo as 'Mobile No', 
                ////8 E.PersonalEmailID as 'Personal Email',   
                ////9 E.OfficialEmailID as 'Official Email',
                ////10 E.BloodGroup as 'Blood Group',
                ////11 E.AadharCardNumber as 'Aadhar Card Number',
                ////12 E.PanCardNumber as 'PAN Card Number',
                //dataGridView1.Columns[13].Width = 150;//13 CM.ContractorName as 'Contractor Name',
                //dataGridView1.Columns[14].Width = 120;//14 ETM.EmployementType as 'Employement Type',
                //dataGridView1.Columns[15].Width = 120;//15 CT.CategoryFName as 'Category F Name',
                //dataGridView1.Columns[16].Width = 120;//16 LM.LocationName as 'Location Name',
                //dataGridView1.Columns[17].Width = 100;//17 DM.Department,
                //dataGridView1.Columns[18].Width = 120;//18 DESM.Designation,
                //dataGridView1.Columns[19].Width = 120;//19 E.JobProfile as 'Job Profile', 
                //dataGridView1.Columns[20].Width = 70;//20 E.Status,
                //21 E.NewFlag

                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[21].Visible = false;

                //0 E.EmployeeId, 
                dataGridView1.Columns[1].Width = 120;//1 E.EmployeeCode as 'Code',
                //2 E.EmpInital,
                dataGridView1.Columns[3].Width = 200;//3 E.EmployeeName as 'Employee Name', 
                dataGridView1.Columns[4].Width = 60;//4 E.Gender, 
                //5 E.DOB, 
                dataGridView1.Columns[6].Width = 40;//6 E.Age, 
                dataGridView1.Columns[7].Width = 120;//7 E.MobileNo as 'Mobile No', 
                //8 E.PersonalEmailID as 'Personal Email',   
                //9 E.OfficialEmailID as 'Official Email',
                //10 E.BloodGroup as 'Blood Group',
                //11 E.AadharCardNumber as 'Aadhar Card Number',
                //12 E.PanCardNumber as 'PAN Card Number',
                dataGridView1.Columns[13].Width = 150;//13 CM.ContractorName as 'Contractor Name',
                dataGridView1.Columns[14].Width = 140;//14 ETM.EmployementType as 'Employement Type',
                dataGridView1.Columns[15].Width = 140;//15 CT.CategoryFName as 'Category F Name',
                dataGridView1.Columns[16].Width = 120;//16 LM.LocationName as 'Location Name',
                dataGridView1.Columns[17].Width = 100;//17 DM.Department,
                dataGridView1.Columns[18].Width = 120;//18 DESM.Designation,
                dataGridView1.Columns[19].Width = 120;//19 E.JobProfile as 'Job Profile', 
                dataGridView1.Columns[20].Width = 70;//20 E.Status,

                // dataGridView1.Columns[22].Visible = false;
                //dataGridView1.Columns[23].Visible = false;

                //dataGridView1.Columns[2].Width = 120;
                //dataGridView1.Columns[4].Width = 120;
                //dataGridView1.Columns[6].Width = 120;
                //dataGridView1.Columns[8].Width = 120;
                //dataGridView1.Columns[9].Width = 120;
                //dataGridView1.Columns[10].Width = 100;

                //for (int i = 0; i < dataGridView1.Columns.Count; i++)
                //{
                //    dataGridView1.Columns[i].Width = 150;
                //}

                int NFlag = 0;
                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    NFlag = 0; // = string.Empty;
                    //Here 2 cell is target value and 1 cell is Volume
                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[21].Value)))
                        NFlag = Convert.ToInt32(Myrow.Cells[21].Value);

                    if (NFlag == 1)
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                    }
                }

                //dataGridView1.Columns[3].Width = 200;
            }
        }

        private void Fill_All_Controls()
        {
            DataSet ds = new DataSet();
            ds = objQL.SP_Employees_By_EmployeeId();

            if (ds.Tables[0].Rows.Count > 0)
            {

                //1	E.EmployeeCode as 'Code',
                //2	E.EmpInital,
                //3	E.EmployeeName as 'Employee Name', 
                //4	E.Gender, 
                //5	E.DOB, 
                //6	E.Age, 
                //7	E.MaritalStatus as 'Marital Status',  
                //8	E.MarriageDate as 'Marital Date',   
                //9	E.PersonalEmailID as 'Personal Email',   
                //10	E.MobileNo as 'Mobile No', 
                //11	E.OfficialEmailID as 'Official Email',
                //12	E.BloodGroup as 'Blood Group',
                //13	E.AadharCardNumber as 'Aadhar Card Number',
                //14	E.PanCardNumber as 'PAN Card Number',
                //15	E.FatherName as 'Father Name', 
                //16	E.MotherName as 'Mother Name', 
                //17	E.DrivingLicenseNumber as 'Driving License Number', 
                //18	E.PersonalIdentificationMark as 'Personal Identification Mark', 
                //19	E.PhysicalDisability, 
                //20	E.DescriptionOfPhysicalDisability,
                //21	E.DOJ, 
                //22	E.TotalYearsService, 
                //23	E.ContractorId, 
                //24	CM.ContractorName as 'Contractor Name',
                //25	E.EmployementTypeId, 
                //26	ETM.EmployementType as 'Employement Type',
                //27	E.DepartmentId, 
                //28	DM.Department,
                //29	E.DesignationId, 
                //30	DESM.Designation,
                //31	E.JobProfile, 
                //32	E.CategoryId, 
                //33	CT.CategoryFName as 'Category F Name',
                //34	E.LocationId,
                //35	LM.LocationName as 'Location Name',
                //36	E.ReportingTo,
                //37	E.Nationality,
                //38	E.Address,
                //39	E.AreaId, 
                //40	E.SameAsPA,
                //41	E.Address1,
                //42	E.AreaId1,
                //43	E.NomineeName,
                //44	E.NomineeRelationship,
                //45	E.NomineeAddress, 
                //46	E.NomineeDOB,
                //47	E.NomineeContactNo,
                //48	E.NomineeFor,
                //49	E.NomineeBankName,
                //50	E.NomineeAccountNo,
                //51	E.NomineeIFSCCode,
                //52	E.NomineeMICRCode,
                //53	E.EmergancyContactName,
                //54	E.EmergancyContactMobileNumber,
                //55	E.EmergancyContactWorkPhone, 
                //56	E.EmergancyContactRelationship,
                //57	E.EmergancyContactHomePhone,
                //58	E.SkillLanguage, 
                //59	E.SkillFluency, 
                //60	E.SkillAbilityWrite,
                //61	E.SkillAbilityRead, 
                //62	E.SkillAbilitySpeak, 
                //63	E.SkillAbilityUnderstand,
                //64	E.SkillType,
                //65	E.CostCenter as 'Cost Center',
                //66	E.SalaryMonthlyBasic,
                //67	E.SalaryMonthlyHRA,
                //68	E.SalaryMonthlyEducationAllowance, 
                //69	E.SalaryMonthlyConveyanceAllowance,
                //70	E.SalaryMonthlyOtherAllowance, 
                //71	E.SalaryMonthlyGrossSalary, 
                //72	E.SalaryMonthlyTaxDeducted,
                //73	E.SalaryMonthlyProvidentFund,
                //74	E.SalaryMonthlyNetSalary,
                //75	E.SalaryAnualBasic,
                //76	E.SalaryAnualHRA,
                //77	E.SalaryAnualEducationAllowance,
                //78	E.SalaryAnualConveyanceAllowance,
                //79	E.SalaryAnualOtherAllowance, 
                //80	E.SalaryAnualGrossSalary, 
                //81	E.SalaryAnualTaxDeducted,
                //82	E.SalaryAnualProvidentFund,
                //83	E.SalaryAnualNetSalary,
                //84	E.SalaryPaymentMode,
                //85	E.SalaryBank, 
                //86	E.SalaryAccountNo,
                //87	E.SalaryBranchName, 
                //88	E.SalaryMICRNo,
                //89	E.SalaryIFSCCode, 
                //90	E.SalaryPaymentMode1,
                //91	E.SalaryBank1, 
                //92	E.SalaryAccountNo1, 
                //93	E.SalaryBranchName1,
                //94	E.SalaryMICRNo1,
                //95	E.SalaryIFSCCode1,
                //96	E.PFMemberIDNo, 
                //97	E.UANNumber, 
                //98	E.ESICNo, 
                //99	E.LWFLINNo,
                //100	E.PassportType, 
                //101	E.PassportNo,
                //102	E.IssuesDate, 
                //103	E.RenewalDate,
                //104	E.DateOfExpiry, 
                //105	E.Citizenship, 
                //106	E.DateOfJoining, 
                //107	E.ConfirmDate, 
                //108	E.PFStartDate, 
                //109	E.DateOfRetirement, 
                //110	E.DateOfExit, 
                //111	E.A1, 
                //112	E.A2, 
                //113	E.A3, 
                //114	E.DOR, 
                //115	E.DOC, 
                //116	E.EmployeeCodeInDevice, 
                //117	E.EmployeeRFIDNumber,
                //118	E.Status, 
                //119	E.RecordStatus,
                //120	E.EmployeeDeviceGroup,
                //121	E.TotalLeave,
                //122	E.BalanceLeave,
                //123   sg.ShiftGroupFName,
                //124   E.OverTimeApplicable
                //125   E.FlexibleHoursFlag

                ds.Tables[0].Rows[0][0].ToString();
                txtEmployeeNumber.Text = ds.Tables[0].Rows[0][0].ToString();
                txtEmployeePunchNumber.Text = ds.Tables[0].Rows[0][1].ToString();
                cmbInitial.Text = ds.Tables[0].Rows[0][2].ToString();
                txtEmployeeName.Text = ds.Tables[0].Rows[0][3].ToString();
                cmbGender.Text = ds.Tables[0].Rows[0][4].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][5])))
                    dtpDateOfBirth.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][5].ToString());

                SetAge(dtpDateOfBirth, txtAge);

                txtAge.Text = ds.Tables[0].Rows[0][6].ToString();

               

                cmbMaritalStatus.Text = ds.Tables[0].Rows[0][7].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][8])))
                    dtpMarriageDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][8].ToString());

                txtPersonalEmailID.Text = ds.Tables[0].Rows[0][9].ToString();
                txtMobileNumber.Text = ds.Tables[0].Rows[0][10].ToString();
                txtOfficialEmail.Text = ds.Tables[0].Rows[0][11].ToString();
                cmbBloodGroup.Text = ds.Tables[0].Rows[0][12].ToString();
                txtAadharCardNo.Text = ds.Tables[0].Rows[0][13].ToString();
                txtPANNo.Text = ds.Tables[0].Rows[0][14].ToString();
                txtFathersName.Text = ds.Tables[0].Rows[0][15].ToString();

                txtMothersName.Text = ds.Tables[0].Rows[0][16].ToString();
                txtDrivingLicenseNo.Text = ds.Tables[0].Rows[0][17].ToString();
                txtPersonalIdentificationMark.Text = ds.Tables[0].Rows[0][18].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][19])))
                    PhysicalDisiabity = Convert.ToInt32(ds.Tables[0].Rows[0][19].ToString());

                if (PhysicalDisiabity == 1)
                {
                    cbPhysicalDisability.Checked = true;
                    txtDescriptionPhysicalDisability.Enabled = true;
                    txtDescriptionPhysicalDisability.Text = ds.Tables[0].Rows[0][20].ToString();
                }
                else
                {
                    cbPhysicalDisability.Checked = false;
                    txtDescriptionPhysicalDisability.Enabled = false;
                    txtDescriptionPhysicalDisability.Text = "";
                }

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][21])))
                    dtpDateOfJoin.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][21].ToString());

                txtTotalYears.Text = ds.Tables[0].Rows[0][22].ToString();

                SetAge(dtpDateOfJoin, txtTotalYears);

                //dtpDateOfJoin.Text =  ds.Tables[0].Rows[0][21].ToString();
                
                cmbContractor.Text = ds.Tables[0].Rows[0][24].ToString();
                cmbEmployeeType.Text = ds.Tables[0].Rows[0][26].ToString();
                cmbLocation.Text = ds.Tables[0].Rows[0][35].ToString();
                Fill_Department_EmployeeWise();
                cmbDepartment.Text = ds.Tables[0].Rows[0][28].ToString();
                cmbDesignation.Text = ds.Tables[0].Rows[0][30].ToString();
                Fill_Grade();
                
                cmbJobProfile.Text = ds.Tables[0].Rows[0]["JobProfile"].ToString();
                cmbCategory.Text = ds.Tables[0].Rows[0][33].ToString();
                

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["ShiftGroupFName"])))
                    cmbShiftGroup.Text = ds.Tables[0].Rows[0]["ShiftGroupFName"].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][118])))
                    cmbStatus.Text = ds.Tables[0].Rows[0][118].ToString();

                Fill_FamilyMember();

                //37	E.Nationality,
                cmbNationality.Text = ds.Tables[0].Rows[0][37].ToString();

                //38	E.Address,
                txtAddress.Text = ds.Tables[0].Rows[0][38].ToString();

                int AID = 0;

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][39])))
                {
                    DataSet dsArea = new DataSet();
                    AID = Convert.ToInt32(ds.Tables[0].Rows[0][39].ToString());
                    dsArea = objQL.SP_AreaMaster_FillGrid_by_AreaId(AID);

                    if (dsArea.Tables[0].Rows.Count > 0)
                    {
                        cmbContryName.Text = dsArea.Tables[0].Rows[0]["Contry Name"].ToString();
                        Fill_State();
                        cmbStateName.Text = dsArea.Tables[0].Rows[0]["State Name"].ToString();
                        Fill_District();
                        cmbDistrictName.Text = dsArea.Tables[0].Rows[0]["District Name"].ToString();
                        Fill_Taluka();
                        cmbTalukaName.Text = dsArea.Tables[0].Rows[0]["Taluka Name"].ToString();
                        Fill_CityVillage();
                        cmbCityVillageName.Text = dsArea.Tables[0].Rows[0]["City/Village Name"].ToString();
                        Fill_Area();
                        cmbAreaName.Text = dsArea.Tables[0].Rows[0]["Area Name"].ToString();
                        GetPincode();
                        cmbPoliceStation.Text = dsArea.Tables[0].Rows[0]["City/Village Name"].ToString();
                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][40])))
                    SameAsPA = Convert.ToInt32(ds.Tables[0].Rows[0][40].ToString());

                if (SameAsPA == 1)
                {
                    cbSame.Checked = true;
                    SamePresentAddress();
                }
                else
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][41])))
                        txtAddress1.Text = ds.Tables[0].Rows[0][41].ToString();


                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][42])))
                    {
                        DataSet dsArea1 = new DataSet();
                        AID = Convert.ToInt32(ds.Tables[0].Rows[0][42].ToString());
                        dsArea1 = objQL.SP_AreaMaster_FillGrid_by_AreaId(AID);

                        if (dsArea1.Tables[0].Rows.Count > 0)
                        {
                            cmbContryName1.Text = dsArea1.Tables[0].Rows[0]["Contry Name"].ToString();
                            Fill_State1();
                            cmbStateName1.Text = dsArea1.Tables[0].Rows[0]["State Name"].ToString();
                            Fill_District1();
                            cmbDistrictName1.Text = dsArea1.Tables[0].Rows[0]["District Name"].ToString();
                            Fill_Taluka1();
                            cmbTalukaName1.Text = dsArea1.Tables[0].Rows[0]["Taluka Name"].ToString();
                            Fill_CityVillage1();
                            cmbCityVillageName1.Text = dsArea1.Tables[0].Rows[0]["City/Village Name"].ToString();
                            Fill_Area1();
                            cmbAreaName1.Text = dsArea1.Tables[0].Rows[0]["Area Name"].ToString();
                            GetPincode1();
                            cmbPoliceStation1.Text = dsArea1.Tables[0].Rows[0]["City/Village Name"].ToString();
                        }
                    }
                }



                //39	AM.ContryId,
                //40	CMS.ContryName as 'Contry Name',
                //41	AM.StateId,
                //42	SM.StateName as 'State Name',
                //43	AM.DistrictId,
                //44	DMS.DistrictName as 'District Name',
                //45	AM.TalukaId,
                //46	TM.TalukaName as 'Taluka Name',
                //47	AM.CityVillageId,
                //48	CVM.CityVillageName as 'City/Village Name',
                //49	E.AreaId, 
                //50	AM.AreaName as 'Area Name',
                //51	E.PoliceStationId,
                //52	CVMPS.CityVillageName as 'Police Station',



                //53	E.SameAsPA,
                //54	E.Address1,
                //55	AM1.ContryId,
                //56	CM1.ContryName as 'Contry Name',
                //57	AM1.StateId,
                //58	SM1.StateName as 'State Name',
                //59	AM1.DistrictId,
                //60	DMS1.DistrictName as 'District Name',
                //61	AM1.TalukaId,
                //62	TM1.TalukaName as 'Taluka Name',
                //63	AM1.CityVillageId,
                //64	CVM1.CityVillageName as 'City/Village Name',
                //65	E.AreaId1, 
                //66	AM1.AreaName as 'Area Name',
                //67	E.PoliceStationId1, 
                //68	CVMPS1.CityVillageName as 'Police Station 1',




                //cmbContryName1.Text = ds.Tables[0].Rows[0][56].ToString();
                //Fill_State1();
                //cmbStateName1.Text = ds.Tables[0].Rows[0][58].ToString();
                //Fill_District1();
                //cmbDistrictName1.Text = ds.Tables[0].Rows[0][60].ToString();
                //Fill_Taluka1();
                //cmbTalukaName1.Text = ds.Tables[0].Rows[0][62].ToString();
                //Fill_CityVillage();
                //cmbCityVillageName1.Text = ds.Tables[0].Rows[0][64].ToString();
                //Fill_Area1();
                //cmbAreaName1.Text = ds.Tables[0].Rows[0][66].ToString();
                //GetPincode1();
                //cmbPoliceStation.Text = ds.Tables[0].Rows[0][68].ToString();

                //69	E.NomineeName,
                //70	E.NomineeRelationship,
                //71	E.NomineeAddress, 
                //72	E.NomineeDOB,
                //73	E.NomineeContactNo,
                //74	E.NomineeFor,
                //75	E.NomineeBankName,
                //76	E.NomineeAccountNo,
                //77	E.NomineeIFSCCode,
                //78	E.NomineeMICRCode,
                //79	E.EmergancyContactName,
                //80	E.EmergancyContactMobileNumber,
                //81	E.EmergancyContactWorkPhone, 
                //82	E.EmergancyContactRelationship,
                //83	E.EmergancyContactHomePhone,

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][43])))
                    txtNameNominee.Text = ds.Tables[0].Rows[0][43].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][44])))
                    cmbRelationshipNominee.Text = ds.Tables[0].Rows[0][44].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][45])))
                    txtAddressNominee.Text = ds.Tables[0].Rows[0][45].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][46])))
                    dtpDateOfBirthNominee.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][46].ToString());

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][47])))
                    txtContactNoNominee.Text = ds.Tables[0].Rows[0][47].ToString();

                string line = string.Empty;

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][48])))
                    line = ds.Tables[0].Rows[0][48].ToString();

                List<string> listStrLineElements = line.Split(',').ToList();

                for (int i = 0; i < clbNomineeFor.Items.Count; i++)
                {
                    for (int j = 0; j < listStrLineElements.Count; j++)
                    {
                        if (clbNomineeFor.Items[i].ToString() == listStrLineElements[j].ToString())
                            clbNomineeFor.SetItemChecked(i, true);
                    }
                }

                cmbBankNameNominee.Text = ds.Tables[0].Rows[0][49].ToString();
                txtAccountNoNominee.Text = ds.Tables[0].Rows[0][50].ToString();
                txtIFSCCodeNominee.Text = ds.Tables[0].Rows[0][51].ToString();
                txtMICRCodeNominee.Text = ds.Tables[0].Rows[0][52].ToString();

                txtNameEC.Text = ds.Tables[0].Rows[0][53].ToString();
                txtMobileNumberEC.Text = ds.Tables[0].Rows[0][54].ToString();
                txtWorkPhoneEC.Text = ds.Tables[0].Rows[0][55].ToString();
                cmbRelationshipEC.Text = ds.Tables[0].Rows[0][56].ToString();
                txtHomePhoneEC.Text = ds.Tables[0].Rows[0][57].ToString();

                //84	E.SkillLanguage, 
                //85	E.SkillFluency, 
                //86	E.SkillAbilityWrite,
                //87	E.SkillAbilityRead, 
                //88	E.SkillAbilitySpeak, 
                //89	E.SkillAbilityUnderstand,
                //90	E.SkillType,


                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][58])))
                    cmbLanguage.Text = ds.Tables[0].Rows[0][58].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][59])))
                    cmbFluency.Text = ds.Tables[0].Rows[0][59].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][60])))
                {
                    SkillAbilityWrite = ds.Tables[0].Rows[0][60].ToString();
                    objRL.CheckBox_Checked(SkillAbilityWrite, cbWrite);
                }

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][61])))
                {
                    SkillAbilityRead = ds.Tables[0].Rows[0][61].ToString();
                    objRL.CheckBox_Checked(SkillAbilityRead, cbRead);
                }

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][62])))
                {
                    SkillAbilitySpeak = ds.Tables[0].Rows[0][62].ToString();
                    objRL.CheckBox_Checked(SkillAbilitySpeak, cbSpeak);
                }

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][63])))
                {
                    SkillAbilityUnderstand = ds.Tables[0].Rows[0][63].ToString();
                    objRL.CheckBox_Checked(SkillAbilityUnderstand, cbUnderstand);
                }

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][64])))
                {
                    cmbSkillType.Text = ds.Tables[0].Rows[0][64].ToString();
                    Fill_Skill_Grid();
                }

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][65])))
                    cmbCostCenter.Text = ds.Tables[0].Rows[0][65].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][66])))
                    txtBasicMonthly.Text = ds.Tables[0].Rows[0][66].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][67])))
                    txtHRAMonthly.Text = ds.Tables[0].Rows[0][67].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][68])))
                    txtTravelAllowance.Text = ds.Tables[0].Rows[0][68].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][69])))
                    txtLoanAmount.Text = ds.Tables[0].Rows[0][69].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][70])))
                    txtOtherAdvance.Text = ds.Tables[0].Rows[0][70].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][71])))
                    txtGrossSalaryMonthly.Text = ds.Tables[0].Rows[0][71].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][72])))
                    txtTaxDeductedAsSourceMonthly.Text = ds.Tables[0].Rows[0][72].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][73])))
                    txtProvidentFundMonthly.Text = ds.Tables[0].Rows[0][73].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][74])))
                    txtNetSalaryMonthly.Text = ds.Tables[0].Rows[0][74].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][75])))
                    txtBasicAnual.Text = ds.Tables[0].Rows[0][75].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][76])))
                    txtHRAAnual.Text = ds.Tables[0].Rows[0][76].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][77])))
                    txtEducationAllowanceAnual.Text = ds.Tables[0].Rows[0][77].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][78])))
                    txtConveyanceAllowanceAnual.Text = ds.Tables[0].Rows[0][78].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][79])))
                    txtOtherAllowanceAnual.Text = ds.Tables[0].Rows[0][79].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][80])))
                    txtGrossSalaryAnual.Text = ds.Tables[0].Rows[0][80].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][81])))
                    txtTaxDeductedAsSourceAnual.Text = ds.Tables[0].Rows[0][81].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][82])))
                    txtProvidentFundAnual.Text = ds.Tables[0].Rows[0][82].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][83])))
                    txtNetSalaryAnual.Text = ds.Tables[0].Rows[0][83].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][84])))
                    cmbPaymentMode.Text = ds.Tables[0].Rows[0][84].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][85])))
                    cmbBankPrimary.Text = ds.Tables[0].Rows[0][85].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][86])))
                    txtAccountNo.Text = ds.Tables[0].Rows[0][86].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][87])))
                    txtBranchName.Text = ds.Tables[0].Rows[0][87].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][88])))
                    txtMICRNO.Text = ds.Tables[0].Rows[0][88].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][89])))
                    txtIFSCode.Text = ds.Tables[0].Rows[0][89].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][90])))
                    cmbPaymentModeSB.Text = ds.Tables[0].Rows[0][90].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][91])))
                    cmbBankSecondary.Text = ds.Tables[0].Rows[0][91].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][92])))
                    txtAccountNoSB.Text = ds.Tables[0].Rows[0][92].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][93])))
                    txtBranchNameSB.Text = ds.Tables[0].Rows[0][93].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][94])))
                    txtMICRNOSB.Text = ds.Tables[0].Rows[0][94].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][95])))
                    txtIFSCCodeSB.Text = ds.Tables[0].Rows[0][95].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][96])))
                    txtPFNo.Text = ds.Tables[0].Rows[0][96].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][97])))
                    txtUANNumber.Text = ds.Tables[0].Rows[0][97].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][98])))
                    txtESICNo.Text = ds.Tables[0].Rows[0][98].ToString();
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][99])))
                    txtLWFLINNo.Text = ds.Tables[0].Rows[0][99].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][100])))
                    PassportType = ds.Tables[0].Rows[0][100].ToString();

                if (PassportType == "Passport")
                    rbPassport.Checked = true;
                else
                    rbVisa.Checked = true;

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["PassportNo"])))
                    txtPassportNo.Text = ds.Tables[0].Rows[0]["PassportNo"].ToString();

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["IssuesDate"])))
                    dtpPassportIssueDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["IssuesDate"].ToString());

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["RenewalDate"])))
                    dtpRenewalDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["RenewalDate"].ToString());

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DateOfExpiry"])))
                    dtpDateOfExpiry.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfExpiry"].ToString());

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["ConfirmDate"])))
                    dtpComfirmDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["ConfirmDate"].ToString());

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["PFStartDate"])))
                    dtpPFStartDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["PFStartDate"].ToString());

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DateOfRetirement"])))
                    dtpDateOfRetrirement.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfRetirement"].ToString());

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["DateOfExit"])))
                {
                    //01/01/1999 12:00:00 AM
                    DateTime dtCheck = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfExit"]);
                    string CD = dtCheck.ToString(BusinessResources.DATEFORMATDDMMYYYY);

                    if (CD== "01/01/1999")
                    {
                        CD = "01/01/2099"; 
                        dtCheck = Convert.ToDateTime(CD);
                    }
                    else
                         dtCheck = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfExit"]);

                    dtpDateOfExit.Value = dtCheck; // Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfExit"].ToString());
                }

                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][109])))
                    dtpA1.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][109].ToString());


            
                //if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][110])))
                //    dtpA2.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][110].ToString());

                //if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][111])))
                //    dtpA3.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][111].ToString());

                //124   E.OverTimeApplicable
                //if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][124])))
                OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OverTimeApplicable"])));

                if (OverTimeApplicable == 1)
                    cbOverTimeApplicable.Checked = true;
                else
                    cbOverTimeApplicable.Checked = false;

                FlexibleHoursFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["FlexibleHoursFlag"])));

                if (FlexibleHoursFlag == 1)
                    cbFlexibleHours.Checked = true;
                else
                    cbFlexibleHours.Checked = false;

                //Effect Information
                FillGrid_Effect_Information();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (objPC.ViewFlag == 1)
            {
                try
                {
                    RowCount_Grid = dataGridView1.Rows.Count;
                    CurrentRowIndex = dataGridView1.CurrentRow.Index;

                    if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                    {
                        //0	E.EmployeeId, 
                        //1	E.EmployeeCode as 'Code',
                        //2	E.EmpInital,
                        //3	E.EmployeeName as 'Employee Name', 
                        //4	E.Gender, 
                        //5	E.DOB, 
                        //6	E.Age, 
                        //7	E.MaritalStatus as 'Marital Status',  
                        //8	E.MarriageDate as 'Marital Date',   
                        //9	E.PersonalEmailID as 'Personal Email',   
                        //10	E.MobileNo as 'Mobile No', 
                        //11	E.OfficialEmailID as 'Official Email',
                        //12	E.BloodGroup as 'Blood Group',
                        //13	E.AadharCardNumber as 'Aadhar Card Number',
                        //14	E.PanCardNumber as 'PAN Card Number',
                        //15	E.FatherName as 'Father Name', 
                        //16	E.MotherName as 'Mother Name', 
                        //17	E.DrivingLicenseNumber as 'Driving License Number', 
                        //18	E.PersonalIdentificationMark as 'Personal Identification Mark', 
                        //19	E.PhysicalDisability, 
                        //20	E.DescriptionOfPhysicalDisability,
                        //21	E.DOJ, 
                        //22	E.TotalYearsService, 
                        //23	E.ContractorId, 
                        //24	CM.ContractorName as 'Contractor Name',
                        //25	E.EmployementTypeId, 
                        //26	ETM.EmployementType as 'Employement Type',
                        //27	E.DepartmentId, 
                        //28	DM.Department,
                        //29	E.DesignationId, 
                        //30	DESM.Designation,
                        //31	E.JobProfile, 
                        //32	E.CategoryId, 
                        //33	CT.CategoryFName as 'Category F Name',
                        //34	E.LocationId,
                        //35	LM.LocationName as 'Location Name',
                        //36	E.ReportingTo,
                        //37	E.Nationality,
                        //38	E.Address,
                        //39	AM.ContryId,
                        //40	CMS.ContryName as 'Contry Name',
                        //41	AM.StateId,
                        //42	SM.StateName as 'State Name',
                        //43	AM.DistrictId,
                        //44	DMS.DistrictName as 'District Name',
                        //45	AM.TalukaId,
                        //46	TM.TalukaName as 'Taluka Name',
                        //47	AM.CityVillageId,
                        //48	CVM.CityVillageName as 'City/Village Name',
                        //49	E.AreaId, 
                        //50	AM.AreaName as 'Area Name',
                        //51	E.PoliceStationId,
                        //52	CVMPS.CityVillageName as 'Police Station',
                        //53	E.SameAsPA,
                        //54	E.Address1,
                        //55	AM1.ContryId,
                        //56	CM1.ContryName as 'Contry Name',
                        //57	AM1.StateId,
                        //58	SM1.StateName as 'State Name',
                        //59	AM1.DistrictId,
                        //60	DMS1.DistrictName as 'District Name',
                        //61	AM1.TalukaId,
                        //62	TM1.TalukaName as 'Taluka Name',
                        //63	AM1.CityVillageId,
                        //64	CVM1.CityVillageName as 'City/Village Name',
                        //65	E.AreaId1, 
                        //66	AM1.AreaName as 'Area Name',
                        //67	E.PoliceStationId1, 
                        //68	CVMPS1.CityVillageName as 'Police Station 1',
                        //69	E.NomineeName,
                        //70	E.NomineeRelationship,
                        //71	E.NomineeAddress, 
                        //72	E.NomineeDOB,
                        //73	E.NomineeContactNo,
                        //74	E.NomineeFor,
                        //75	E.NomineeBankName,
                        //76	E.NomineeAccountNo,
                        //77	E.NomineeIFSCCode,
                        //78	E.NomineeMICRCode,
                        //79	E.EmergancyContactName,
                        //80	E.EmergancyContactMobileNumber,
                        //81	E.EmergancyContactWorkPhone, 
                        //82	E.EmergancyContactRelationship,
                        //83	E.EmergancyContactHomePhone,
                        //84	E.SkillLanguage, 
                        //85	E.SkillFluency, 
                        //86	E.SkillAbilityWrite,
                        //87	E.SkillAbilityRead, 
                        //88	E.SkillAbilitySpeak, 
                        //89	E.SkillAbilityUnderstand,
                        //90	E.SkillType,
                        //91	E.CostCenter as 'Cost Center',
                        //92	E.SalaryMonthlyBasic,
                        //93	E.SalaryMonthlyHRA,
                        //94	E.SalaryMonthlyEducationAllowance, 
                        //95	E.SalaryMonthlyConveyanceAllowance,
                        //96	E.SalaryMonthlyOtherAllowance, 
                        //97	E.SalaryMonthlyGrossSalary, 
                        //98	E.SalaryMonthlyTaxDeducted,
                        //99	E.SalaryMonthlyProvidentFund,
                        //100	E.SalaryMonthlyNetSalary,
                        //101	E.SalaryAnualBasic,
                        //102	E.SalaryAnualHRA,
                        //103	E.SalaryAnualEducationAllowance,
                        //104	E.SalaryAnualConveyanceAllowance,
                        //105	E.SalaryAnualOtherAllowance, 
                        //106	E.SalaryAnualGrossSalary, 
                        //107	E.SalaryAnualTaxDeducted,
                        //108	E.SalaryAnualProvidentFund,
                        //109	E.SalaryAnualNetSalary,
                        //110	E.SalaryPaymentMode,
                        //111	E.SalaryBank, 
                        //112	E.SalaryAccountNo,
                        //113	E.SalaryBranchName, 
                        //114	E.SalaryMICRNo,
                        //115	E.SalaryIFSCCode, 
                        //116	E.SalaryPaymentMode1,
                        //117	E.SalaryBank1, 
                        //118	E.SalaryAccountNo1, 
                        //119	E.SalaryBranchName1,
                        //120	E.SalaryMICRNo1,
                        //121	E.SalaryIFSCCode1,
                        //122	E.PFMemberIDNo, 
                        //123	E.UANNumber, 
                        //124	E.ESICNo, 
                        //125	E.LWFLINNo,
                        //126	E.PassportType, 
                        //127	E.PassportNo,
                        //128	E.IssuesDate, 
                        //129	E.RenewalDate,
                        //130	E.DateOfExpiry, 
                        //131	E.Citizenship, 
                        //132	E.DateOfJoining, 
                        //133	E.ConfirmDate, 
                        //134	E.PFStartDate, 
                        //135	E.DateOfRetirement, 
                        //136	E.DateOfExit, 
                        //137	E.A1, 
                        //138	E.A2, 
                        //139	E.A3, 
                        //140	E.DOR, 
                        //141	E.DOC, 
                        //142	E.EmployeeCodeInDevice, 
                        //143	E.EmployeeRFIDNumber,
                        //144	E.Status, 
                        //145	E.RecordStatus,
                        //146	E.EmployeeDeviceGroup,
                        //147	E.TotalLeave,
                        //148	E.BalanceLeave 

                        ClearAll();

                        btnDelete.Enabled = true;

                        //Profile
                        TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        objPC.EmployeeId = TableId;

                        Fill_All_Controls();

                        txtEmployeeNumber.Text = TableId.ToString();
                        FillGrid_EmployeeExperience();
                        FillGrid_Qualification();


                        if (objPC.DesignationCategory != BusinessResources.USER_TYPE_TRAINEE || objPC.DesignationCategory != BusinessResources.USER_TYPE_CONTRACTWORKER)
                        {
                           // gbLeave.Enabled = true;
                            Fill_OpeningLeave();
                            objRL.Get_Leaves_Count_All();
                            txtEnjoyLeave.Text = objPC.EnjoyLeave_Count.ToString();
                            Get_Leaves();
                        }
                        else
                        {
                            //gbLeave.Enabled = false;
                        }


                        //txtEmployeeNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                        //txtEmployeePunchNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                        //cmbInitial.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                        //txtEmployeeName.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                        //cmbGender.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value)))
                        //    dtpDateOfBirth.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString());
                        //txtAge.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                        //cmbMaritalStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[8].Value)))
                        //    dtpMarriageDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                        //txtPersonalEmailID.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                        //txtMobileNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                        //txtOfficialEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                        //cmbBloodGroup.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
                        //txtAadharCardNo.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
                        //txtPANNo.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
                        //txtFathersName.Text = dataGridView1.Rows[e.RowIndex].Cells[15].Value.ToString();

                        //txtMothersName.Text = dataGridView1.Rows[e.RowIndex].Cells[16].Value.ToString();
                        //txtDrivingLicenseNo.Text = dataGridView1.Rows[e.RowIndex].Cells[17].Value.ToString();
                        //txtPersonalIdentificationMark.Text = dataGridView1.Rows[e.RowIndex].Cells[18].Value.ToString();

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[19].Value)))
                        //    PhysicalDisiabity = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[19].Value);

                        //if (PhysicalDisiabity == 1)
                        //{
                        //    cbPhysicalDisability.Checked = true;
                        //    txtDescriptionPhysicalDisability.Enabled = true;
                        //    txtDescriptionPhysicalDisability.Text = dataGridView1.Rows[e.RowIndex].Cells[20].Value.ToString();
                        //}
                        //else
                        //{
                        //    cbPhysicalDisability.Checked = false;
                        //    txtDescriptionPhysicalDisability.Enabled = false;
                        //    txtDescriptionPhysicalDisability.Text = "";
                        //}

                        ////if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[21].Value)))
                        ////    dtpDateOfJoin.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[21].Value.ToString());

                        //txtTotalYears.Text = dataGridView1.Rows[e.RowIndex].Cells[22].Value.ToString();
                        //cmbContractor.Text = dataGridView1.Rows[e.RowIndex].Cells[24].Value.ToString();
                        //cmbEmployeeType.Text = dataGridView1.Rows[e.RowIndex].Cells[26].Value.ToString();
                        //cmbDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[28].Value.ToString();
                        //cmbDesignation.Text = dataGridView1.Rows[e.RowIndex].Cells[30].Value.ToString();
                        //cmbJobProfile.Text = dataGridView1.Rows[e.RowIndex].Cells[31].Value.ToString();
                        //cmbCategory.Text = dataGridView1.Rows[e.RowIndex].Cells[33].Value.ToString();
                        //cmbPlaceOfPosting.Text = dataGridView1.Rows[e.RowIndex].Cells[35].Value.ToString();
                        //cmbReportingTo.Text = dataGridView1.Rows[e.RowIndex].Cells[36].Value.ToString();
                        //Fill_FamilyMember();

                        ////37	E.Nationality,
                        ////38	E.Address,
                        ////39	AM.ContryId,
                        ////40	CMS.ContryName as 'Contry Name',
                        ////41	AM.StateId,
                        ////42	SM.StateName as 'State Name',
                        ////43	AM.DistrictId,
                        ////44	DMS.DistrictName as 'District Name',
                        ////45	AM.TalukaId,
                        ////46	TM.TalukaName as 'Taluka Name',
                        ////47	AM.CityVillageId,
                        ////48	CVM.CityVillageName as 'City/Village Name',
                        ////49	E.AreaId, 
                        ////50	AM.AreaName as 'Area Name',
                        ////51	E.PoliceStationId,
                        ////52	CVMPS.CityVillageName as 'Police Station',

                        //cmbNationality.Text = dataGridView1.Rows[e.RowIndex].Cells[37].Value.ToString();
                        //txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[38].Value.ToString();
                        //cmbContryName.Text = dataGridView1.Rows[e.RowIndex].Cells[40].Value.ToString();
                        //Fill_State();
                        //cmbStateName.Text = dataGridView1.Rows[e.RowIndex].Cells[42].Value.ToString();
                        //Fill_District();
                        //cmbDistrictName.Text = dataGridView1.Rows[e.RowIndex].Cells[44].Value.ToString();
                        //Fill_Taluka();
                        //cmbTalukaName.Text = dataGridView1.Rows[e.RowIndex].Cells[46].Value.ToString();
                        //Fill_CityVillage();
                        //cmbCityVillageName.Text = dataGridView1.Rows[e.RowIndex].Cells[48].Value.ToString();
                        //Fill_Area();
                        //cmbAreaName.Text = dataGridView1.Rows[e.RowIndex].Cells[50].Value.ToString();
                        //GetPincode();
                        //cmbPoliceStation.Text = dataGridView1.Rows[e.RowIndex].Cells[52].Value.ToString();

                        ////53	E.SameAsPA,
                        ////54	E.Address1,
                        ////55	AM1.ContryId,
                        ////56	CM1.ContryName as 'Contry Name',
                        ////57	AM1.StateId,
                        ////58	SM1.StateName as 'State Name',
                        ////59	AM1.DistrictId,
                        ////60	DMS1.DistrictName as 'District Name',
                        ////61	AM1.TalukaId,
                        ////62	TM1.TalukaName as 'Taluka Name',
                        ////63	AM1.CityVillageId,
                        ////64	CVM1.CityVillageName as 'City/Village Name',
                        ////65	E.AreaId1, 
                        ////66	AM1.AreaName as 'Area Name',
                        ////67	E.PoliceStationId1, 
                        ////68	CVMPS1.CityVillageName as 'Police Station 1',

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[53].Value)))
                        //    SameAsPA = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[53].Value.ToString());

                        //if (SameAsPA == 1)
                        //{
                        //    cbSame.Checked = true;
                        //    SamePresentAddress();
                        //}

                        //txtAddress1.Text = dataGridView1.Rows[e.RowIndex].Cells[54].Value.ToString();
                        //cmbContryName1.Text = dataGridView1.Rows[e.RowIndex].Cells[56].Value.ToString();
                        //Fill_State1();
                        //cmbStateName1.Text = dataGridView1.Rows[e.RowIndex].Cells[58].Value.ToString();
                        //Fill_District1();
                        //cmbDistrictName1.Text = dataGridView1.Rows[e.RowIndex].Cells[60].Value.ToString();
                        //Fill_Taluka1();
                        //cmbTalukaName1.Text = dataGridView1.Rows[e.RowIndex].Cells[62].Value.ToString();
                        //Fill_CityVillage();
                        //cmbCityVillageName1.Text = dataGridView1.Rows[e.RowIndex].Cells[64].Value.ToString();
                        //Fill_Area1();
                        //cmbAreaName1.Text = dataGridView1.Rows[e.RowIndex].Cells[66].Value.ToString();
                        //GetPincode1();
                        //cmbPoliceStation.Text = dataGridView1.Rows[e.RowIndex].Cells[68].Value.ToString();

                        ////69	E.NomineeName,
                        ////70	E.NomineeRelationship,
                        ////71	E.NomineeAddress, 
                        ////72	E.NomineeDOB,
                        ////73	E.NomineeContactNo,
                        ////74	E.NomineeFor,
                        ////75	E.NomineeBankName,
                        ////76	E.NomineeAccountNo,
                        ////77	E.NomineeIFSCCode,
                        ////78	E.NomineeMICRCode,
                        ////79	E.EmergancyContactName,
                        ////80	E.EmergancyContactMobileNumber,
                        ////81	E.EmergancyContactWorkPhone, 
                        ////82	E.EmergancyContactRelationship,
                        ////83	E.EmergancyContactHomePhone,

                        //txtNameNominee.Text = dataGridView1.Rows[e.RowIndex].Cells[69].Value.ToString();
                        //cmbRelationshipNominee.Text = dataGridView1.Rows[e.RowIndex].Cells[70].Value.ToString();
                        //txtAddressNominee.Text = dataGridView1.Rows[e.RowIndex].Cells[71].Value.ToString();
                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[72].Value)))
                        //    dtpDateOfBirthNominee.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[72].Value.ToString());
                        //txtContactNoNominee.Text = dataGridView1.Rows[e.RowIndex].Cells[73].Value.ToString();

                        //string line = string.Empty;
                        //line = dataGridView1.Rows[e.RowIndex].Cells[74].Value.ToString();

                        //List<string> listStrLineElements = line.Split(',').ToList();

                        //for (int i = 0; i < clbNomineeFor.Items.Count; i++)
                        //{
                        //    for (int j = 0; j < listStrLineElements.Count; j++)
                        //    {
                        //        if (clbNomineeFor.Items[i].ToString() == listStrLineElements[j].ToString())
                        //            clbNomineeFor.SetItemChecked(i, true);
                        //    }
                        //}

                        //cmbBankNameNominee.Text = dataGridView1.Rows[e.RowIndex].Cells[75].Value.ToString();
                        //txtAccountNoNominee.Text = dataGridView1.Rows[e.RowIndex].Cells[76].Value.ToString();
                        //txtIFSCCodeNominee.Text = dataGridView1.Rows[e.RowIndex].Cells[77].Value.ToString();
                        //txtMICRCodeNominee.Text = dataGridView1.Rows[e.RowIndex].Cells[78].Value.ToString();

                        //txtNameEC.Text = dataGridView1.Rows[e.RowIndex].Cells[79].Value.ToString();
                        //txtMobileNumberEC.Text = dataGridView1.Rows[e.RowIndex].Cells[80].Value.ToString();
                        //txtWorkPhoneEC.Text = dataGridView1.Rows[e.RowIndex].Cells[81].Value.ToString();
                        //cmbRelationshipEC.Text = dataGridView1.Rows[e.RowIndex].Cells[82].Value.ToString();
                        //txtHomePhoneEC.Text = dataGridView1.Rows[e.RowIndex].Cells[83].Value.ToString();

                        ////84	E.SkillLanguage, 
                        ////85	E.SkillFluency, 
                        ////86	E.SkillAbilityWrite,
                        ////87	E.SkillAbilityRead, 
                        ////88	E.SkillAbilitySpeak, 
                        ////89	E.SkillAbilityUnderstand,
                        ////90	E.SkillType,

                        //cmbLanguage.Text = dataGridView1.Rows[e.RowIndex].Cells[84].Value.ToString();
                        //cmbFluency.Text = dataGridView1.Rows[e.RowIndex].Cells[85].Value.ToString();

                        //SkillAbilityWrite = dataGridView1.Rows[e.RowIndex].Cells[86].Value.ToString();
                        //objRL.CheckBox_Checked(SkillAbilityWrite, cbWrite);

                        //SkillAbilityRead = dataGridView1.Rows[e.RowIndex].Cells[87].Value.ToString();
                        //objRL.CheckBox_Checked(SkillAbilityRead, cbRead);

                        //SkillAbilitySpeak = dataGridView1.Rows[e.RowIndex].Cells[88].Value.ToString();
                        //objRL.CheckBox_Checked(SkillAbilitySpeak, cbSpeak);

                        //SkillAbilityUnderstand = dataGridView1.Rows[e.RowIndex].Cells[89].Value.ToString();
                        //objRL.CheckBox_Checked(SkillAbilityUnderstand, cbUnderstand);

                        //cmbSkillType.Text = dataGridView1.Rows[e.RowIndex].Cells[90].Value.ToString();
                        //Fill_Skill_Grid();

                        //// 91	E.CostCenter as 'Cost Center',
                        //// 92	E.SalaryMonthlyBasic,
                        //// 93	E.SalaryMonthlyHRA,
                        //// 94	E.SalaryMonthlyEducationAllowance, 
                        //// 95	E.SalaryMonthlyConveyanceAllowance,
                        //// 96	E.SalaryMonthlyOtherAllowance, 
                        //// 97	E.SalaryMonthlyGrossSalary, 
                        //// 98	E.SalaryMonthlyTaxDeducted,
                        //// 99	E.SalaryMonthlyProvidentFund,
                        //// 100	E.SalaryMonthlyNetSalary,
                        //// 101	E.SalaryAnualBasic,
                        //// 102	E.SalaryAnualHRA,
                        //// 103	E.SalaryAnualEducationAllowance,
                        //// 104	E.SalaryAnualConveyanceAllowance,
                        //// 105	E.SalaryAnualOtherAllowance, 
                        //// 106	E.SalaryAnualGrossSalary, 
                        //// 107	E.SalaryAnualTaxDeducted,
                        //// 108	E.SalaryAnualProvidentFund,
                        //// 109	E.SalaryAnualNetSalary,
                        //// 110	E.SalaryPaymentMode,
                        //// 111	E.SalaryBank, 
                        //// 112	E.SalaryAccountNo,
                        //// 113	E.SalaryBranchName, 
                        //// 114	E.SalaryMICRNo,
                        //// 115	E.SalaryIFSCCode, 
                        //// 116	E.SalaryPaymentMode1,
                        //// 117	E.SalaryBank1, 
                        //// 118	E.SalaryAccountNo1, 
                        //// 119	E.SalaryBranchName1,
                        //// 120	E.SalaryMICRNo1,
                        //// 121	E.SalaryIFSCCode1,


                        //cmbCostCenter.Text = dataGridView1.Rows[e.RowIndex].Cells[91].Value.ToString();

                        //txtBasicMonthly.Text = dataGridView1.Rows[e.RowIndex].Cells[92].Value.ToString();
                        //txtHRAMonthly.Text = dataGridView1.Rows[e.RowIndex].Cells[93].Value.ToString();
                        //txtEducationAllowanceMonthly.Text = dataGridView1.Rows[e.RowIndex].Cells[94].Value.ToString();
                        //txtConveyanceAllowanceMonthly.Text = dataGridView1.Rows[e.RowIndex].Cells[95].Value.ToString();
                        //txtOtherAllowanceMonthly.Text = dataGridView1.Rows[e.RowIndex].Cells[96].Value.ToString();
                        //txtGrossSalaryMonthly.Text = dataGridView1.Rows[e.RowIndex].Cells[97].Value.ToString();
                        //txtTaxDeductedAsSourceMonthly.Text = dataGridView1.Rows[e.RowIndex].Cells[98].Value.ToString();
                        //txtProvidentFundMonthly.Text = dataGridView1.Rows[e.RowIndex].Cells[99].Value.ToString();
                        //txtNetSalaryMonthly.Text = dataGridView1.Rows[e.RowIndex].Cells[100].Value.ToString();


                        //txtBasicAnual.Text = dataGridView1.Rows[e.RowIndex].Cells[101].Value.ToString();
                        //txtHRAAnual.Text = dataGridView1.Rows[e.RowIndex].Cells[102].Value.ToString();
                        //txtEducationAllowanceAnual.Text = dataGridView1.Rows[e.RowIndex].Cells[103].Value.ToString();
                        //txtConveyanceAllowanceAnual.Text = dataGridView1.Rows[e.RowIndex].Cells[104].Value.ToString();
                        //txtOtherAllowanceAnual.Text = dataGridView1.Rows[e.RowIndex].Cells[105].Value.ToString();
                        //txtGrossSalaryAnual.Text = dataGridView1.Rows[e.RowIndex].Cells[106].Value.ToString();
                        //txtTaxDeductedAsSourceAnual.Text = dataGridView1.Rows[e.RowIndex].Cells[107].Value.ToString();
                        //txtProvidentFundAnual.Text = dataGridView1.Rows[e.RowIndex].Cells[108].Value.ToString();
                        //txtNetSalaryAnual.Text = dataGridView1.Rows[e.RowIndex].Cells[109].Value.ToString();


                        //cmbPaymentMode.Text = dataGridView1.Rows[e.RowIndex].Cells[110].Value.ToString();
                        //cmbBankPrimary.Text = dataGridView1.Rows[e.RowIndex].Cells[111].Value.ToString();
                        //txtAccountNo.Text = dataGridView1.Rows[e.RowIndex].Cells[112].Value.ToString();
                        //txtBranchName.Text = dataGridView1.Rows[e.RowIndex].Cells[113].Value.ToString();
                        //txtMICRNO.Text = dataGridView1.Rows[e.RowIndex].Cells[114].Value.ToString();
                        //txtIFSCode.Text = dataGridView1.Rows[e.RowIndex].Cells[115].Value.ToString();

                        //cmbPaymentModeSB.Text = dataGridView1.Rows[e.RowIndex].Cells[116].Value.ToString();
                        //cmbBankSecondary.Text = dataGridView1.Rows[e.RowIndex].Cells[117].Value.ToString();
                        //txtAccountNoSB.Text = dataGridView1.Rows[e.RowIndex].Cells[118].Value.ToString();
                        //txtBranchNameSB.Text = dataGridView1.Rows[e.RowIndex].Cells[119].Value.ToString();
                        //txtMICRNOSB.Text = dataGridView1.Rows[e.RowIndex].Cells[120].Value.ToString();
                        //txtIFSCCodeSB.Text = dataGridView1.Rows[e.RowIndex].Cells[121].Value.ToString();

                        ////122	E.PFMemberIDNo, 
                        ////123	E.UANNumber, 
                        ////124	E.ESICNo, 
                        ////125	E.LWFLINNo,
                        ////126	E.PassportType, 
                        ////127	E.PassportNo,
                        ////128	E.IssuesDate, 
                        ////129	E.RenewalDate,
                        ////130	E.DateOfExpiry, 
                        ////131	E.Citizenship, 
                        ////132	E.DateOfJoining, 
                        ////133	E.ConfirmDate, 
                        ////134	E.PFStartDate, 
                        ////135	E.DateOfRetirement, 
                        ////136	E.DateOfExit, 
                        ////137	E.A1, 
                        ////138	E.A2, 
                        ////139	E.A3, 
                        ////140	E.DOR, 
                        ////141	E.DOC, 
                        ////142	E.EmployeeCodeInDevice, 
                        ////143	E.EmployeeRFIDNumber,
                        ////144	E.Status, 
                        ////145	E.RecordStatus,
                        ////146	E.EmployeeDeviceGroup,
                        ////147	E.TotalLeave,
                        ////148	E.BalanceLeave 


                        //txtPFNo.Text = dataGridView1.Rows[e.RowIndex].Cells[122].Value.ToString();
                        //txtUANNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[123].Value.ToString();
                        //txtESICNo.Text = dataGridView1.Rows[e.RowIndex].Cells[124].Value.ToString();
                        //txtLWFLINNo.Text = dataGridView1.Rows[e.RowIndex].Cells[125].Value.ToString();
                        //PassportType = dataGridView1.Rows[e.RowIndex].Cells[126].Value.ToString();

                        //if (PassportType == "Passport")
                        //    rbPassport.Checked = true;
                        //else
                        //    rbVisa.Checked = true;

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[127].Value)))
                        //    txtPassportNo.Text = dataGridView1.Rows[e.RowIndex].Cells[127].Value.ToString();

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[128].Value)))
                        //    dtpPassportIssueDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[128].Value.ToString());

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[129].Value)))
                        //    dtpRenewalDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[129].Value.ToString());

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[130].Value)))
                        //    dtpDateOfExpiry.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[130].Value.ToString());

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[133].Value)))
                        //    dtpComfirmDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[133].Value.ToString());

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[134].Value)))
                        //    dtpPFStartDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[134].Value.ToString());

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[135].Value)))
                        //    dtpDateOfRetrirement.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[135].Value.ToString());

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[136].Value)))
                        //    dtpDateOfExit.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[136].Value.ToString());

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[137].Value)))
                        //    dtpA1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[137].Value.ToString());

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[138].Value)))
                        //    dtpA2.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[138].Value.ToString());

                        //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[139].Value)))
                        //    dtpA3.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[139].Value.ToString());

                        ////dtpA3.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[139].Value.ToString());
                        ////dtpA3.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[139].Value.ToString());

                    }

                    cmbLocation.Enabled = false;
                    cmbDepartment.Enabled = false;
                    btnAddDepartment.Enabled = false;
                    btnAddLocation.Enabled = false;

                    objPC.NewFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[21].Value)));

                    if(objPC.NewFlag ==1)
                        dtpDateOfExit.Enabled = true;
                    else
                        dtpDateOfExit.Enabled = false;
                }
                catch (Exception ex1)
                {
                    objRL.ErrorMessge(ex1.ToString());
                    return;
                }
                finally
                {
                    GC.Collect();
                }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        private void cbPhysicalDisability_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPhysicalDisability.Checked)
            {
                PhysicalDisiabity = 1;
                txtDescriptionPhysicalDisability.Enabled = true;
            }
            else
            {
                PhysicalDisiabity = 0;
                txtDescriptionPhysicalDisability.Enabled = false;
            }
        }

        private void btnNextDependents_Click(object sender, EventArgs e)
        {
            //if (!Validation_Dependents())
            //{
                string NFor = string.Empty, NForConcat = string.Empty;

                for (int i = 0; i <= (clbNomineeFor.Items.Count - 1); i++)
                {
                    if (clbNomineeFor.GetItemChecked(i))
                    {
                        NForConcat += clbNomineeFor.Items[i].ToString() + ",";
                    }
                }

                if (!string.IsNullOrEmpty(Convert.ToString(NForConcat)))
                    NForConcat = NForConcat.Remove(NForConcat.Length - 1);

                objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
                objPC.NomineeName = txtNameNominee.Text;
                objPC.NomineeRelationship = cmbRelationshipNominee.Text;
                objPC.NomineeAddress = txtAddressNominee.Text;
                objPC.NomineeDOB = dtpDateOfBirthNominee.Value;
                objPC.NomineeContactNo = txtContactNoNominee.Text;
                objPC.NomineeFor = NForConcat;
                objPC.NomineeBankName = cmbBankNameNominee.Text;
                objPC.NomineeAccountNo = txtAccountNoNominee.Text;
                objPC.NomineeIFSCCode = txtIFSCCodeNominee.Text;
                objPC.NomineeMICRCode = txtMICRCodeNominee.Text;
                objPC.EmergancyContactName = txtNameEC.Text;
                objPC.EmergancyContactMobileNumber = txtMobileNumberEC.Text;
                objPC.EmergancyContactWorkPhone = txtWorkPhoneEC.Text;
                objPC.EmergancyContactRelationship = cmbRelationshipEC.Text;
                objPC.EmergancyContactHomePhone = txtHomePhoneEC.Text;
                Result = objQL.SP_Employees_Nominee_Emergancy_Update();
                if (Result > 0)
                {
                //objPC.EmployeeId = Convert.ToInt32(objRL.ReturnMaxID_Fix("Employees"));
                if (!FlagDelete)
                {
                    tbEmployee.SelectedIndex = (tbEmployee.SelectedIndex + 1 < tbEmployee.TabCount) ?
                               tbEmployee.SelectedIndex + 1 : tbEmployee.SelectedIndex;

                    objRL.ShowMessage(7, 1);
                }
                else
                        objRL.ShowMessage(9, 1);

                    //FillGrid();
                    //ClearAll();
                }
            //}
            //else
            //{
            //    objRL.ShowMessage(17, 4);
            //    return;
            //}
        }

        int EmployeeFamilyId = 0;
        string IsResidingWith = string.Empty, IsDependentOnYou = string.Empty, IsPrimaryNominee = string.Empty;

        bool GridFlag = false;

        private void FamilyMemberAdd()
        {
            if (objPC.EmployeeId != 0)
            {
                if (!GridFlag)
                    objPC.EmployeeFamilyId = 0;
                else
                    objPC.EmployeeFamilyId = EmployeeFamilyId;

                objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
                objPC.MemberName = txtNameMember.Text;
                objPC.Relationship = cmbRelationshipMember.Text;
                objPC.FamilyGender = cmbGenderMember.Text;
                objPC.MemberDOB = dtpDOBMember.Value;

                if (cbIsResidingWithHimHer.Checked)
                    IsResidingWith = "Yes";
                else
                    IsResidingWith = "No";

                objPC.IsResidingWith = IsResidingWith;

                if (cbIsDependentOnYou.Checked)
                    IsDependentOnYou = "Yes";
                else
                    IsDependentOnYou = "No";

                objPC.IsDependentOnYou = IsDependentOnYou;

                objPC.MemberPANCard = txtPANCardMember.Text;
                objPC.MemberAadharCard = txtAadharCardMember.Text;
                objPC.MemberContactNo = txtContactNoMember.Text;

                if (cbPrimaryNomineeMember.Checked)
                    IsPrimaryNominee = "Yes";
                else
                    IsPrimaryNominee = "No";

                objPC.IsPrimaryNominee = IsPrimaryNominee;

                Result = 0;
                Result = objQL.SP_EmployeeFamily_Save_Update();

                if (Result > 0)
                {
                    //objPC.EmployeeId = Convert.ToInt32(objRL.ReturnMaxID_Fix("Employees"));
                    if (!FlagDelete)
                    {
                        Fill_FamilyMember();
                        objRL.ShowMessage(7, 1);
                    }
                    else
                        objRL.ShowMessage(9, 1);

                    //FillGrid();
                    //ClearAll();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void Fill_FamilyMember()
        {
            dgvFamilyMember.DataSource = null;
            DataSet ds = new DataSet();
            objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
            ds = objQL.SP_EmployeeFamily_Select_By_EmployeeId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //0 EmployeeFamilyId,
                //1 EmployeeId,
                //2 MemberName, 
                //3 Relationship, 
                //4 Gender, 
                //5 DOB, 
                //6 IsResidingWith, 
                //7 DependentOnYou, 
                //8 PANCard,
                //9 AadharCard, 
                //10 ContactNo, 
                //11 IsPrimaryNominee

                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                dgvFamilyMember.DataSource = ds.Tables[0];
                dgvFamilyMember.Columns[0].Visible = false;
                dgvFamilyMember.Columns[1].Visible = false;
                dgvFamilyMember.Columns[6].Visible = false;
                dgvFamilyMember.Columns[7].Visible = false;
                dgvFamilyMember.Columns[11].Visible = false;
                //dataGridView1.Columns[2].Width = 120;
                //dataGridView1.Columns[4].Width = 120;
                //dataGridView1.Columns[6].Width = 120;
                //dataGridView1.Columns[8].Width = 120;
                //dataGridView1.Columns[9].Width = 120;
                //dataGridView1.Columns[10].Width = 100;

                for (int i = 0; i < dgvFamilyMember.Columns.Count; i++)
                {
                    dgvFamilyMember.Columns[i].Width = 150;
                }
            }
        }

        private void btnSaveClear_Click(object sender, EventArgs e)
        {
            FamilyMemberAdd();
        }

        private void btnGridClear_Click(object sender, EventArgs e)
        {
            Clear_FamilyMember();
        }

        private void Clear_FamilyMember()
        {
            btnDeleteMember.Enabled = false;
            GridFlag = false;
            EmployeeFamilyId = 0;
            txtNameMember.Text = "";
            cmbRelationshipMember.SelectedIndex = -1;
            cmbGenderMember.SelectedIndex = -1;
            dtpDOBMember.Value = DateTime.Now.Date;
            cbIsResidingWithHimHer.Checked = false;
            cbIsDependentOnYou.Checked = false;
            txtPANCardMember.Text = "";
            txtAadharCardMember.Text = "";
            txtContactNoMember.Text = "";
            cbPrimaryNomineeMember.Checked = false;
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNextQualification_Click(object sender, EventArgs e)
        {
            tbEmployee.SelectedIndex = (tbEmployee.SelectedIndex + 1 < tbEmployee.TabCount) ?
                              tbEmployee.SelectedIndex + 1 : tbEmployee.SelectedIndex;

            objRL.ShowMessage(7, 1);

            //if (!Validation_Qualification())
            //{
            //    objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
            //    objPC.QualificationEducation = cmbQualification.Text;
            //    //objPC.QualificationSpeciazation = txtSpeciazation.Text;
            //    //objPC.QualificationStartDate = dtpStartDateQualification.Value;
            //    //objPC.QualificationEndDate = dtpEndDateQualification.Value;

            //    //objPC.QualificationScoreClass = txtScoreClass.Text;
            //    //objPC.QualificationYear = txtYear.Text;
            //    //objPC.QualificationRemarks = txtComment.Text;

            //    //objPC.ExperienceEmployer = txtEmployer.Text;
            //    //objPC.ExperienceBranch = txtBranch.Text;
            //    //objPC.ExperienceLocation = txtLocationQualification.Text;
            //    //objPC.ExperienceDesignation = cmbDesignationExperience.Text;
            //    //objPC.ExperienceCTC = txtCTC.Text;
            //    //objPC.ExperienceGrossSalary = txtGrossSalary.Text;

            //    //objPC.ExperienceStartDate = dtpStartDate.Value;
            //    //objPC.ExperienceEndDate = dtpEndDate.Value;
            //    //objPC.ExperienceManager = txtManagerEL.Text;
            //    //objPC.ExperienceManagerContactNo = txtManagerContactNo.Text;
            //    //objPC.ExperienceIndustryType = cmbIndustryType.Text;
            //    //objPC.ExperienceRemarks = txtRemrks.Text;

            //    //Result = 0;
            //    //Result = objQL.SP_Employees_Qualification_Education_Update();

            //    //if (Result > 0)
            //    //{
            //    //    //objPC.EmployeeId = Convert.ToInt32(objRL.ReturnMaxID_Fix("Employees"));
            //    //    if (!FlagDelete)
            //    //    {
            //    //        objRL.ShowMessage(7, 1);
            //    //    }
            //    //    else
            //    //        objRL.ShowMessage(9, 1);

            //    //    //FillGrid();
            //    //    //ClearAll();
            //    //}
            //}
            //else
            //{
            //    objRL.ShowMessage(17, 4);
            //    return;
            //}
        }

        string SkillAbilityWrite = string.Empty, SkillAbilityRead = string.Empty, SkillAbilitySpeak = string.Empty, SkillAbilityUnderstand = string.Empty;
        private void btnNextSkill_Click(object sender, EventArgs e)
        {
            if (!Validation_Skill())
            {
                objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
                objPC.SkillLanguage = cmbLanguage.Text;
                objPC.SkillFluency = cmbFluency.Text;
                objPC.SkillAbilityWrite = SkillAbilityWrite;
                objPC.SkillAbilityRead = SkillAbilityRead;
                objPC.SkillAbilitySpeak = SkillAbilitySpeak;
                objPC.SkillAbilityUnderstand = SkillAbilityUnderstand;
                objPC.SkillType = cmbSkillType.Text;

                Result = 0;
                Result = objQL.SP_Employees_Skill_Update();

                if (Result > 0)
                {
                    tbEmployee.SelectedIndex = (tbEmployee.SelectedIndex + 1 < tbEmployee.TabCount) ?
                              tbEmployee.SelectedIndex + 1 : tbEmployee.SelectedIndex;

                    objRL.ShowMessage(7, 1);
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void btnNextSalary_Click(object sender, EventArgs e)
        {
            if (!Validation_Salary())
            {
                objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
                objPC.CostCenter = cmbCostCenter.Text;
                objPC.SalaryMonthlyBasic = txtBasicMonthly.Text;
                objPC.SalaryMonthlyHRA = txtHRAMonthly.Text;
                objPC.SalaryMonthlyEducationAllowance = txtTravelAllowance.Text;
                objPC.SalaryMonthlyConveyanceAllowance = txtLoanAmount.Text;
                objPC.SalaryMonthlyOtherAllowance = txtOtherAdvance.Text;
                objPC.SalaryMonthlyGrossSalary = txtGrossSalaryMonthly.Text;
                objPC.SalaryMonthlyTaxDeducted = txtTaxDeductedAsSourceMonthly.Text;
                objPC.SalaryMonthlyProvidentFund = txtProvidentFundMonthly.Text;
                objPC.SalaryMonthlyNetSalary = txtNetSalaryMonthly.Text;
                objPC.SalaryAnualBasic = txtBasicAnual.Text;
                objPC.SalaryAnualHRA = txtHRAAnual.Text;
                objPC.SalaryAnualEducationAllowance = txtEducationAllowanceAnual.Text;
                objPC.SalaryAnualConveyanceAllowance = txtConveyanceAllowanceAnual.Text;
                objPC.SalaryAnualOtherAllowance = txtOtherAllowanceAnual.Text;
                objPC.SalaryAnualGrossSalary = txtGrossSalaryAnual.Text;
                objPC.SalaryAnualTaxDeducted = txtTaxDeductedAsSourceAnual.Text;
                objPC.SalaryAnualProvidentFund = txtProvidentFundAnual.Text;
                objPC.SalaryAnualNetSalary = txtNetSalaryAnual.Text;
                objPC.SalaryPaymentMode = cmbPaymentMode.Text;
                objPC.SalaryBank = cmbBankPrimary.Text;
                objPC.SalaryAccountNo = txtAccountNo.Text;
                objPC.SalaryBranchName = txtBranchName.Text;
                objPC.SalaryMICRNo = txtMICRNO.Text;
                objPC.SalaryIFSCCode = txtIFSCode.Text;
                objPC.SalaryPaymentMode1 = cmbPaymentModeSB.Text;
                objPC.SalaryBank1 = cmbBankSecondary.Text;
                objPC.SalaryAccountNo1 = txtAccountNoSB.Text;
                objPC.SalaryBranchName1 = txtBranchNameSB.Text;
                objPC.SalaryMICRNo1 = txtMICRNOSB.Text;
                objPC.SalaryIFSCCode1 = txtIFSCCodeSB.Text;

                Result = 0;
                Result = objQL.SP_Employees_Salary_Update();

                if (Result > 0)
                {
                    //objPC.EmployeeId = Convert.ToInt32(objRL.ReturnMaxID_Fix("Employees"));
                    if (!FlagDelete)
                    {
                        tbEmployee.SelectedIndex = (tbEmployee.SelectedIndex + 1 < tbEmployee.TabCount) ?
                              tbEmployee.SelectedIndex + 1 : tbEmployee.SelectedIndex;

                        objRL.ShowMessage(7, 1);
                    }
                    else
                        objRL.ShowMessage(9, 1);

                    //FillGrid();
                    //ClearAll();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        string PassportType = string.Empty;

        private void btnNextCompliance_Click(object sender, EventArgs e)
        {
            if (!Validation_Compliance())
            {
                if (rbPassport.Checked)
                    PassportType = "Passport";
                if (rbVisa.Checked)
                    PassportType = "Visa";

                objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
                objPC.PFMemberIDNo = txtPFNo.Text;
                objPC.UANNumber = txtUANNumber.Text;
                objPC.ESICNo = txtESICNo.Text;
                objPC.LWFLINNo = txtLWFLINNo.Text;
                objPC.PassportType = PassportType;
                objPC.PassportNo = txtPassportNo.Text;
                objPC.IssuesDate = dtpPassportIssueDate.Value;
                objPC.RenewalDate = dtpRenewalDate.Value;
                objPC.DateOfExpiry = dtpDateOfExpiry.Value;
                objPC.ConfirmDate = dtpComfirmDate.Value;
                objPC.PFStartDate = dtpPFStartDate.Value;
                objPC.DateOfRetirement = dtpDateOfRetrirement.Value;
                objPC.DateOfExit = dtpDateOfExit.Value;
                objPC.DateOfExpiry = dtpA1.Value;
                objPC.DateOfExpiry = dtpDateOfExpiry.Value;

                Result = 0;
                Result = objQL.SP_Employee_PF_Update();

                if (Result > 0)
                {
                    tbEmployee.SelectedIndex = (tbEmployee.SelectedIndex + 1 < tbEmployee.TabCount) ?
                               tbEmployee.SelectedIndex + 1 : tbEmployee.SelectedIndex;

                    objRL.ShowMessage(7, 1);
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void dgvFamilyMember_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dgvFamilyMember.Rows.Count;
                CurrentRowIndex = dgvFamilyMember.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    //0 EmployeeFamilyId,
                    //1 EmployeeId,
                    //2 MemberName, 
                    //3 Relationship, 
                    //4 Gender, 
                    //5 DOB, 
                    //6 IsResidingWith, 
                    //7 DependentOnYou, 
                    //8 PANCard,
                    //9 AadharCard, 
                    //10 ContactNo, 
                    //11 IsPrimaryNominee

                    Clear_FamilyMember();

                    btnDeleteMember.Enabled = true;
                    GridFlag = true;
                    //Clear_FamilyMember();
                    //Profile
                    EmployeeFamilyId = Convert.ToInt32(dgvFamilyMember.Rows[e.RowIndex].Cells[0].Value);
                    objPC.EmployeeFamilyId = EmployeeFamilyId;

                    txtNameMember.Text = dgvFamilyMember.Rows[e.RowIndex].Cells[2].Value.ToString();
                    cmbRelationshipMember.Text = dgvFamilyMember.Rows[e.RowIndex].Cells[3].Value.ToString();
                    cmbGenderMember.Text = dgvFamilyMember.Rows[e.RowIndex].Cells[4].Value.ToString();
                    dtpDOBMember.Value = Convert.ToDateTime(dgvFamilyMember.Rows[e.RowIndex].Cells[5].Value.ToString());

                    IsResidingWith = dgvFamilyMember.Rows[e.RowIndex].Cells[6].Value.ToString();
                    objRL.CheckBox_Checked(IsResidingWith, cbIsResidingWithHimHer);

                    IsDependentOnYou = dgvFamilyMember.Rows[e.RowIndex].Cells[7].Value.ToString();
                    objRL.CheckBox_Checked(IsDependentOnYou, cbIsDependentOnYou);

                    txtPANCardMember.Text = dgvFamilyMember.Rows[e.RowIndex].Cells[8].Value.ToString();
                    txtAadharCardMember.Text = dgvFamilyMember.Rows[e.RowIndex].Cells[9].Value.ToString();
                    txtContactNoMember.Text = dgvFamilyMember.Rows[e.RowIndex].Cells[10].Value.ToString();
                    IsPrimaryNominee = dgvFamilyMember.Rows[e.RowIndex].Cells[11].Value.ToString();
                    objRL.CheckBox_Checked(IsPrimaryNominee, cbPrimaryNomineeMember);
                }
            }
            catch (Exception ex1)
            {
                objRL.ErrorMessge(ex1.ToString());
                return;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void cbPrimaryNomineeMember_CheckedChanged(object sender, EventArgs e)
        {
            objRL.CheckBox_SetString(ref IsPrimaryNominee, cbPrimaryNomineeMember);
        }

        private void cbIsDependentOnYou_CheckedChanged(object sender, EventArgs e)
        {
            objRL.CheckBox_SetString(ref IsDependentOnYou, cbIsDependentOnYou);
        }

        private void cbIsResidingWithHimHer_CheckedChanged(object sender, EventArgs e)
        {
            objRL.CheckBox_SetString(ref IsResidingWith, cbIsResidingWithHimHer);
        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = objRL.Delete_Record_Show_Message();

            if (dr.ToString() == "Yes")
            {
                objPC.EmployeeFamilyId = EmployeeFamilyId;
                Result = 0;
                Result = objQL.SP_EmployeeFamily_Delete();

                if (Result > 0)
                {
                    objRL.ShowMessage(9, 1);
                    Fill_FamilyMember();
                }
            }
        }

        private void cbWrite_CheckedChanged(object sender, EventArgs e)
        {
            objRL.CheckBox_SetString(ref SkillAbilityWrite, cbWrite);
        }

        private void cbRead_CheckedChanged(object sender, EventArgs e)
        {
            objRL.CheckBox_SetString(ref SkillAbilityRead, cbRead);
        }

        private void cbSpeak_CheckedChanged(object sender, EventArgs e)
        {
            objRL.CheckBox_SetString(ref SkillAbilitySpeak, cbSpeak);
        }

        private void cbUnderstand_CheckedChanged(object sender, EventArgs e)
        {
            objRL.CheckBox_SetString(ref SkillAbilityUnderstand, cbUnderstand);
        }

        private void btnAddGridSkill_Click(object sender, EventArgs e)
        {
            Skill_Add();
        }

        int EmployeeSkillId = 0;
        private void Skill_Add()
        {
            if (objPC.EmployeeId != 0)
            {
                if (!GridFlag)
                    objPC.EmployeeSkillId = 0;
                else
                    objPC.EmployeeSkillId = EmployeeSkillId;

                objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
                objPC.Skills = cmbSkills.Text;
                objPC.YearsOfExperience = txtYesrsOfExperince.Text;
                objPC.Comments = txtCommentsSkill.Text;

                Result = 0;
                Result = objQL.SP_EmployeeSkill_Save_Update();

                if (Result > 0)
                {
                    Fill_Skill_Grid();
                    objRL.ShowMessage(7, 1);
                    ClearAll_Skill();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void Fill_Skill_Grid()
        {
            dgvSkill.DataSource = null;
            DataSet ds = new DataSet();
            objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
            ds = objQL.SP_EmployeeSkill_Grid();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //0 EmployeeSkillId,
                //1 EmployeeId, 
                //2 Skills, 
                //3 YearsOfExperience, 
                //4 Comments 

                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                dgvSkill.DataSource = ds.Tables[0];
                dgvSkill.Columns[0].Visible = false;
                dgvSkill.Columns[1].Visible = false;

                for (int i = 0; i < dgvSkill.Columns.Count; i++)
                {
                    dgvSkill.Columns[i].Width = 150;
                }
            }
        }

        private void ClearAll_Skill_Grid()
        {
            objEP.Clear();
            EmployeeSkillId = 0;
            GridFlag = false;
            cmbSkills.SelectedIndex = -1;
            txtYesrsOfExperince.Text = "";
            txtCommentsSkill.Text = "";
        }

        private void btnClearGridSkill_Click(object sender, EventArgs e)
        {
            ClearAll_Skill_Grid();
        }

        private void btnDeleteGridSkill_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = objRL.Delete_Record_Show_Message();

            if (dr.ToString() == "Yes")
            {
                objPC.EmployeeSkillId = EmployeeSkillId;
                Result = 0;
                Result = objQL.SP_EmployeeSkill_Delete();

                if (Result > 0)
                {
                    Fill_Skill_Grid();
                    objRL.ShowMessage(9, 1);
                    ClearAll_Skill();
                }
            }
        }

        private void dgvSkill_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dgvSkill.Rows.Count;
                CurrentRowIndex = dgvSkill.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    //0 EmployeeSkillId,
                    //1 EmployeeId, 
                    //2 Skills, 
                    //3 YearsOfExperience, 
                    //4 Comments 

                    ClearAll_Skill();
                    btnDeleteGridSkill.Enabled = true;
                    GridFlag = true;
                    EmployeeSkillId = Convert.ToInt32(dgvSkill.Rows[e.RowIndex].Cells[0].Value);
                    objPC.EmployeeSkillId = EmployeeSkillId;
                    cmbSkills.Text = dgvSkill.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtYesrsOfExperince.Text = dgvSkill.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtCommentsSkill.Text = dgvSkill.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
            }
            catch (Exception ex1)
            {
                objRL.ErrorMessge(ex1.ToString());
                return;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void CalculateAnual(string T1, TextBox tb)
        {
            double A1 = 0, A2 = 0, AnualValue = 0;

            double.TryParse(T1, out A1);
            AnualValue = A1 * 12;
            tb.Text = AnualValue.ToString();
        }

        double BasicMonthly = 0, HRAMonthly = 0, EducationAllowanceMonthly = 0, ConveyanceAllowanceMonthly = 0, OtherAllowanceMonthly = 0;
        double MonthlyGrossSalary = 0, TaxDeductedAsSourceMonthly = 0, ProvidentFundMonthly = 0, NetSalaryMonthly = 0, AnualGrossSalary = 0, NetSalaryAnual = 0;

        private void CalculateSalaryMonthly()
        {
            BasicMonthly = 0; HRAMonthly = 0; EducationAllowanceMonthly = 0; ConveyanceAllowanceMonthly = 0; OtherAllowanceMonthly = 0;
            MonthlyGrossSalary = 0; TaxDeductedAsSourceMonthly = 0; ProvidentFundMonthly = 0; AnualGrossSalary = 0; NetSalaryAnual = 0;

            double.TryParse(txtBasicMonthly.Text, out BasicMonthly);
            double.TryParse(txtHRAMonthly.Text, out HRAMonthly);
            double.TryParse(txtTravelAllowance.Text, out EducationAllowanceMonthly);
            double.TryParse(txtLoanAmount.Text, out ConveyanceAllowanceMonthly);
            double.TryParse(txtOtherAdvance.Text, out OtherAllowanceMonthly);
            double.TryParse(txtTaxDeductedAsSourceMonthly.Text, out TaxDeductedAsSourceMonthly);
            double.TryParse(txtProvidentFundMonthly.Text, out ProvidentFundMonthly);

            MonthlyGrossSalary = BasicMonthly + HRAMonthly + EducationAllowanceMonthly + ConveyanceAllowanceMonthly + OtherAllowanceMonthly;
            txtGrossSalaryMonthly.Text = MonthlyGrossSalary.ToString();

            NetSalaryMonthly = MonthlyGrossSalary - (TaxDeductedAsSourceMonthly + ProvidentFundMonthly);
            txtNetSalaryMonthly.Text = NetSalaryMonthly.ToString();

            AnualGrossSalary = 0;
            AnualGrossSalary = MonthlyGrossSalary * 12;
            txtGrossSalaryAnual.Text = AnualGrossSalary.ToString();

            NetSalaryAnual = 0;
            NetSalaryAnual = NetSalaryMonthly * 12;
            txtNetSalaryAnual.Text = NetSalaryAnual.ToString();
        }

        private void txtBasicMonthly_TextChanged(object sender, EventArgs e)
        {
            CalculateAnual(txtBasicMonthly.Text, txtBasicAnual);
            CalculateSalaryMonthly();
        }

        private void txtHRAMonthly_TextChanged(object sender, EventArgs e)
        {
            CalculateAnual(txtHRAMonthly.Text, txtHRAAnual);
            CalculateSalaryMonthly();
        }

        private void txtEducationAllowanceMonthly_TextChanged(object sender, EventArgs e)
        {
            CalculateAnual(txtTravelAllowance.Text, txtEducationAllowanceAnual);
            CalculateSalaryMonthly();
        }

        private void txtConveyanceAllowanceMonthly_TextChanged(object sender, EventArgs e)
        {
            CalculateAnual(txtLoanAmount.Text, txtConveyanceAllowanceAnual);
            CalculateSalaryMonthly();
        }

        private void txtOtherAllowanceMonthly_TextChanged(object sender, EventArgs e)
        {
            CalculateAnual(txtOtherAdvance.Text, txtOtherAllowanceAnual);
            CalculateSalaryMonthly();
        }

        private void txtMonthlyGrossSalary_TextChanged(object sender, EventArgs e)
        {
            CalculateAnual(txtGrossSalaryMonthly.Text, txtGrossSalaryAnual);
            CalculateSalaryMonthly();
        }

        private void txtTaxDeductedAsSourceMonthly_TextChanged(object sender, EventArgs e)
        {
            CalculateAnual(txtTaxDeductedAsSourceMonthly.Text, txtTaxDeductedAsSourceAnual);
            CalculateSalaryMonthly();
        }

        private void txtProvidentFundMonthly_TextChanged(object sender, EventArgs e)
        {
            CalculateAnual(txtProvidentFundMonthly.Text, txtProvidentFundAnual);
            CalculateSalaryMonthly();
        }

        private void txtBasicAnual_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHRAAnual_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEducationAllowanceAnual_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConveyanceAllowanceAnual_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOtherAllowanceAnual_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTaxDeductedAsSourceAnual_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProvidentFundAnual_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGrossSalaryAnual_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbPassport_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPassport.Checked)
                PassportType = rbPassport.Text;
        }

        private void rbVisa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVisa.Checked)
                PassportType = rbVisa.Text;
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            Get_File();
        }

        string FileName = string.Empty, SourcePath = string.Empty, DestinationPath = string.Empty;

        private void Get_File()
        {
            FileName = string.Empty; SourcePath = string.Empty; DestinationPath = string.Empty;
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Files (*.jpg;*.jpeg;.*.png;)|*.jpg;*.jpeg;.*.png";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                SourcePath = opnfd.FileName;
                FileName = Path.GetFileName(SourcePath);
                pbEmployeePhoto.Image = new Bitmap(opnfd.FileName);
            }
        }

        string FileNameInsert = string.Empty;
        string FilePathInsert = string.Empty;
        string FilePathMain = string.Empty;

        private void CopyPasteFile()
        {

            DestinationPath = objRL.GetPath("EmployeePhotos") + "\\" + objPC.EmployeeId + "\\";
            DirectoryInfo objDI = new DirectoryInfo(Path.GetFullPath(DestinationPath));

            if (!Directory.Exists(Path.GetFullPath(DestinationPath)))
                objDI.Create();

            File.Copy(FilePathMain, DestinationPath + Path.GetFileName(FilePathMain));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (objPC.DeleteFlagUR == 1)
            {
                DialogResult dr = objRL.Delete_Record_Show_Message();
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    FlagDelete = true;
                    objPC.EmployeeId = TableId;
                    int R = objQL.SP_Employees_Delete();
                    if (R > 0)
                    {
                        objRL.ShowMessage(9, 1);
                        ClearAll();
                        FillGrid();
                    }
                }
            }
            else
            {
                objRL.ShowMessage(24, 4);
                return;
            }
        }

        private bool Validation_Qualification_Grid()
        {
            objEP.Clear();

            if (cmbQualification.SelectedIndex == -1)
            {
                cmbQualification.Focus();
                objEP.SetError(cmbQualification, "Select Qualification");
                return true;
            }
            else if (txtStream.Text == "")
            {
                txtStream.Focus();
                objEP.SetError(txtStream, "Enter Stream");
                return true;
            }
            else if (txtCollege.Text == "")
            {
                txtCollege.Focus();
                objEP.SetError(txtCollege, "Enter College");
                return true;
            }
            else if (txtUniversity.Text == "")
            {
                txtUniversity.Focus();
                objEP.SetError(txtUniversity, "Enter College");
                return true;
            }
            else if (cmbYearOfPassing.SelectedIndex == -1)
            {
                cmbYearOfPassing.Focus();
                objEP.SetError(cmbYearOfPassing, "Select Year Of Passing");
                return true;
            }
            else if (txtGradeQualification.Text == "")
            {
                txtGradeQualification.Focus();
                objEP.SetError(txtGradeQualification, "Enter Grade Qualification");
                return true;
            }
            else
                return false;
        }

        int EmployeeQualificationId = 0;

        private void SaveDB_Qualification()
        {
            if (objPC.EmployeeId != 0)
            {
                if (!GridFlag)
                    objPC.EmployeeQualificationId = 0;
                else
                    objPC.EmployeeQualificationId = EmployeeQualificationId;

                objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
                objPC.Qualification = cmbQualification.Text;
                objPC.Stream = txtStream.Text;
                objPC.College = txtCollege.Text;
                objPC.University = txtUniversity.Text;
                objPC.YearOfPassing = Convert.ToInt32(cmbYearOfPassing.Text);
                objPC.GradeQualification = txtGradeQualification.Text;
                objPC.DeleteFlag = FlagDelete;
                Result = 0;
                Result = objQL.SP_EmployeeQualification_Save_Update();

                if (Result > 0)
                {
                    if (!FlagDelete)
                        objRL.ShowMessage(7, 1);
                    else
                        objRL.ShowMessage(9, 1);

                    FillGrid_Qualification();
                    ClearAll_Qualification();
                    GridFlag = false;
                    objPC.EmployeeQualificationId = 0;
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void btnAddGrid_Click(object sender, EventArgs e)
        {
            FlagDelete = false;
            SaveDB_Qualification();
        }

        private void FillGrid_Qualification()
        {
            dgvQualification.DataSource = null;
            DataSet ds = new DataSet();
            objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
            ds = objQL.SP_EmployeeQualification_Select_By_EmployeeId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //0 EmployeeQualificationId,
                //1 EmployeeId, 
                //2 Qualification,
                //3 Stream,
                //4 College,
                //5 University
                //6 YearOfPassing as 'Year of Passing',
                //7 Grade

                //lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                dgvQualification.DataSource = ds.Tables[0];
                dgvQualification.Columns[0].Visible = false;
                dgvQualification.Columns[1].Visible = false;

                dgvQualification.Columns[2].Width = 200;
                dgvQualification.Columns[3].Width = 200;
                dgvQualification.Columns[4].Width = 200;
                dgvQualification.Columns[5].Width = 200;
                dgvQualification.Columns[6].Width = 200;
                dgvQualification.Columns[7].Width = 100;
            }
        }

        private void FillGrid_EmployeeExperience()
        {
            dgvPreviousExperience.DataSource = null;
            DataSet ds = new DataSet();

            if (!string.IsNullOrEmpty(Convert.ToString(txtEmployeeNumber.Text))) 
                objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);

            //objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
            ds = objQL.SP_EmployeeExperience_Select_By_EmployeeId();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //0 EmployeeExperienceId,
                //1 EmployeeId, 
                //2 OrganizationName,
                //3 OrganizationAddress,
                //4 StartDate,
                //5 EndDate,
                //6 Designation,
                //7 GrossSalaryPE 

                //lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;
                dgvPreviousExperience.DataSource = ds.Tables[0];
                dgvPreviousExperience.Columns[0].Visible = false;
                dgvPreviousExperience.Columns[1].Visible = false;

                dgvPreviousExperience.Columns[2].Width = 150;
                dgvPreviousExperience.Columns[3].Width = 150;
                dgvPreviousExperience.Columns[4].Width = 150;
                dgvPreviousExperience.Columns[5].Width = 150;
                dgvPreviousExperience.Columns[6].Width = 150;
                dgvPreviousExperience.Columns[7].Width = 150;
            }
        }

        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            ClearAll_Qualification();
        }

        private void btnAddPreviousExperience_Click(object sender, EventArgs e)
        {
            FlagDelete = false;
            SaveDB_EmployeeExperience();
        }

        private void SaveDB_EmployeeExperience()
        {
            if (objPC.EmployeeId != 0)
            {
                if (!GridFlag)
                    objPC.EmployeeExperienceId = 0;
                else
                    objPC.EmployeeExperienceId = EmployeeExperienceId;

                objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
                objPC.OrganizationNameExperience = txtOrganizationNameExperience.Text;
                objPC.OrganizationAddressExperience = txtOrganizationAddressExperience.Text;
                objPC.StartDate = dtpStartDate.Value;
                objPC.EndDate = dtpEndDate.Value;
                objPC.DesignationExperience = cmbDesignationExperience.Text;
                objPC.GrossSalaryPreviousExperience = txtGrossSalaryPreviousExperience.Text;
                objPC.DeleteFlag = FlagDelete;

                Result = 0;
                Result = objQL.SP_EmployeeExperience_Save_Update();

                if (Result > 0)
                {
                    if (!FlagDelete)
                        objRL.ShowMessage(7, 1);
                    else
                        objRL.ShowMessage(9, 1);

                    FillGrid_EmployeeExperience();
                    ClearAll_PreviousExperience();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void btnClearPreviousExperience_Click(object sender, EventArgs e)
        {
            ClearAll_PreviousExperience();
        }

        private void btnDeletePreviousExperience_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = objRL.Delete_Record_Show_Message();

            if (dr.ToString() == "Yes")
            {
                FlagDelete = true;
                SaveDB_EmployeeExperience();
            }
        }

        private void btnDeleteGrid_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = objRL.Delete_Record_Show_Message();

            if (dr.ToString() == "Yes")
            {
                FlagDelete = true;
                SaveDB_Qualification();
            }
            else
                FlagDelete = false;
        }

        private void dgvQualification_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dgvQualification.Rows.Count;
                CurrentRowIndex = dgvQualification.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    //0 EmployeeQualificationId,
                    //1 EmployeeId, 
                    //2 Qualification,
                    //3 Stream,
                    //4 College,
                    //5 University
                    //6 YearOfPassing as 'Year of Passing',
                    //7 Grade

                    ClearAll_Qualification();
                    GridFlag = true;
                    btnDeleteGrid.Visible = true;
                    EmployeeQualificationId = Convert.ToInt32(dgvQualification.Rows[e.RowIndex].Cells[0].Value);
                    cmbQualification.Text = dgvQualification.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtStream.Text = dgvQualification.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtCollege.Text = dgvQualification.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtUniversity.Text = dgvQualification.Rows[e.RowIndex].Cells[5].Value.ToString();
                    cmbYearOfPassing.Text = dgvQualification.Rows[e.RowIndex].Cells[6].Value.ToString();
                    txtGradeQualification.Text = dgvQualification.Rows[e.RowIndex].Cells[7].Value.ToString();
                }
            }
            catch (Exception ex1)
            {
                objRL.ErrorMessge(ex1.ToString());
                return;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void dgvPreviousExperience_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dgvPreviousExperience.Rows.Count;
                CurrentRowIndex = dgvPreviousExperience.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    //0 EmployeeExperienceId,
                    //1 EmployeeId, 
                    //2 OrganizationName,
                    //3 OrganizationAddress,
                    //4 StartDate,
                    //5 EndDate,
                    //6 Designation,
                    //7 GrossSalaryPE 

                    ClearAll_PreviousExperience();
                    GridFlag = true;
                    btnDeletePreviousExperience.Visible = true;
                    EmployeeExperienceId = Convert.ToInt32(dgvPreviousExperience.Rows[e.RowIndex].Cells[0].Value);
                    txtOrganizationNameExperience.Text = dgvPreviousExperience.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtOrganizationAddressExperience.Text = dgvPreviousExperience.Rows[e.RowIndex].Cells[3].Value.ToString();
                    dtpStartDate.Value = Convert.ToDateTime(dgvPreviousExperience.Rows[e.RowIndex].Cells[4].Value.ToString());
                    dtpEndDate.Value = Convert.ToDateTime(dgvPreviousExperience.Rows[e.RowIndex].Cells[5].Value.ToString());
                    cmbDesignationExperience.Text = dgvPreviousExperience.Rows[e.RowIndex].Cells[6].Value.ToString();
                    txtGrossSalaryPreviousExperience.Text = dgvPreviousExperience.Rows[e.RowIndex].Cells[7].Value.ToString();
                }
            }
            catch (Exception ex1)
            {
                objRL.ErrorMessge(ex1.ToString());
                return;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void btnShiftGroup_Click(object sender, EventArgs e)
        {
            ShiftGroupMaster objForm = new ShiftGroupMaster();
            objForm.ShowDialog(this);
            objQL.Fill_Master_ComboBox(cmbShiftGroup, "shiftgroups");
        }

        private void txtTotalYears_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtTotalYears);
        }

        private void cmbMaritalStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //if (cmbMaritalStatus.SelectedIndex > -1)
            //{
            //    if (cmbMaritalStatus.Text == "Married")
            //    {
            //        lbMarriageDate.Visible = true;
            //        dtpMarriageDate.Visible = true;
            //    }
            //    else
            //    {
            //        lbMarriageDate.Visible = false;
            //        dtpMarriageDate.Visible = false;
            //    }
            //}
        }

        private void btnContractor_Click(object sender, EventArgs e)
        {
            ContractorMaster objForm = new ContractorMaster();
            objForm.ShowDialog(this);
            objQL.Fill_Master_ComboBox(cmbContractor, "contractormaster");
        }

        private void btnEmployeeType_Click(object sender, EventArgs e)
        {
            EmployeeTypeMaster objForm = new EmployeeTypeMaster();
            objForm.ShowDialog(this);
            objQL.Fill_Master_ComboBox(cmbEmployeeType, "employementtypemaster");
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            DepartmentMaster objForm = new DepartmentMaster();
            objForm.ShowDialog(this);
            objQL.Fill_Master_ComboBox(cmbDepartment, "departmentmaster");
        }

        private void btnDesignation_Click(object sender, EventArgs e)
        {
            DesignationMaster objForm = new DesignationMaster();
            objForm.ShowDialog(this);
            objQL.Fill_Master_ComboBox(cmbDesignation, "designationmaster");
            objQL.Fill_Master_ComboBox(cmbDesignationExperience, "designationmaster");

        }

        private void btnAddLocation_Click(object sender, EventArgs e)
        {
            LocationMaster objForm = new LocationMaster();
            objForm.ShowDialog(this);
            objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {

        }

        private void btnFluency_Click(object sender, EventArgs e)
        {

        }

        private void btnAddJobProfile_Click(object sender, EventArgs e)
        {
            JobProfileMaster objForm = new JobProfileMaster();
            objForm.ShowDialog(this);
            objQL.Fill_Master_ComboBox(cmbJobProfile, "jobprofilemaster");
        }

        int NewFlag = 0;

        private void cmbType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex > -1)
            {
                if (cmbType.Text == "New")
                    NewFlag = 1;
                else
                    NewFlag = 0;
            }
            else
                NewFlag = 0;

            objPC.NewFlag = NewFlag;
            SearchFlag = false;
            FillGrid();
        }

        int EmployeeCode_V = 0; bool SearchFlagCode = false;
        private void txtSearchCode_TextChanged(object sender, EventArgs e)
        {
            EmployeeCode_V = 0; SearchFlagCode = false;
            if (txtSearchCode.Text != "")
            {
                SearchFlagCode = true;
                EmployeeCode_V = Convert.ToInt32(txtSearchCode.Text);
            }
            else
                EmployeeCode_V = 0;

            FillGrid();
        }

        private void txtSearchCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtSearchCode);
        }

        private void cbFullPF_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void cbPT_CheckedChanged(object sender, EventArgs e)
        {

        }

        private bool Validation_OpeningLeave()
        {
            objEP.Clear();

            if (txtOpeningLeave.Text == "")
            {
                txtOpeningLeave.Focus();
                objEP.SetError(txtOpeningLeave, "Enter Opening Leave");
                return true;
            }
            else if (txtTotalApplicableLeave.Text == "")
            {
                txtTotalApplicableLeave.Focus();
                objEP.SetError(txtTotalApplicableLeave, "Enter Net Balance Leave");
                return true;
            }
            else
                return false;
        }

        private void btnNextOpeningLeave_Click(object sender, EventArgs e)
        {
            if (!Validation_OpeningLeave())
            {
                objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
                objPC.OpeningLeave = txtOpeningLeave.Text;
                objPC.TotalLeave = txtCurrentLeave.Text;
                objPC.BalanceLeave = txtTotalApplicableLeave.Text;

                Result = 0;

                objBL.Query = "update employees set OpeningLeave='" + txtOpeningLeave.Text + "',CurrentLeave='" + txtCurrentLeave.Text + "',TotalApplicableLeave='" + txtTotalApplicableLeave.Text + "',EnjoyLeave='" + txtEnjoyLeave.Text + "',BalanceLeave='" + txtBalanceLeave.Text + "',ModifiedUserId=" + BusinessLayer.LoginId_Static + " where CancelTag=0 and EmployeeId=" + TableId + "";
                Result = objBL.Function_ExecuteNonQuery();

                //Result = objQL.SP_Employees_OpeningLeave_Update();

                if (Result > 0)
                {
                    objRL.ShowMessage(7, 1);
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }


        private void txtOpeningLeave_TextChanged(object sender, EventArgs e)
        {
            CalculationLeaves();
        }

        private void txtOpeningLeave_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtOpeningLeave);
        }

        private void txtTotalLeave_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtCurrentLeave);
        }

        private void txtBalanceLeave_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtBalanceLeave);
        }

        private void txtCurrentLeave_TextChanged(object sender, EventArgs e)
        {
            CalculationLeaves();
        }

        private void txtBalanceLeave_TextChanged(object sender, EventArgs e)
        {
            //CalculationLeaves();
        }

        private void Fill_OpeningLeave()
        {
            DataSet ds = new DataSet();
            //objPC.EmployeeId = Convert.ToInt32(txtEmployeeNumber.Text);
            //ds = objQL.SP_Employees_OpeningLeave_Grid();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    //0 EmployeeId, 
            //    //1 TotalLeave,
            //    //2 OpeningLeave, 
            //    //3 BalanceLeave

            //    txtCurrentLeave.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["TotalLeave"]));
            //    txtOpeningLeave.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OpeningLeave"]));
            //    txtBalanceLeave.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["BalanceLeave"]));
            //}

            objBL.Query = "select OpeningLeave,CurrentLeave,TotalApplicableLeave,EnjoyLeave,BalanceLeave from employees where CancelTag=0 and EmployeeId=" + TableId + "";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtOpeningLeave.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["OpeningLeave"]));
                txtCurrentLeave.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["CurrentLeave"]));
                txtTotalApplicableLeave.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["TotalApplicableLeave"]));
                txtEnjoyLeave.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["EnjoyLeave"]));
                txtBalanceLeave.Text = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["BalanceLeave"]));

                //objRL.Get_Leaves_Count_All
            }
        }

        double OpeningLeave = 0, CurrentLeave = 0, TotalApplicableLeaves = 0, EnjoyLeaves = 0, BalanceLeaves = 0;
        private void CalculationLeaves()
        {
            OpeningLeave = 0; CurrentLeave = 0; TotalApplicableLeaves = 0; EnjoyLeaves = 0; BalanceLeaves = 0; 

            double.TryParse(txtOpeningLeave.Text, out OpeningLeave);
            double.TryParse(txtCurrentLeave.Text, out CurrentLeave);
            double.TryParse(txtBalanceLeave.Text, out BalanceLeaves);
            double.TryParse(txtEnjoyLeave.Text, out EnjoyLeaves);

            TotalApplicableLeaves = OpeningLeave + CurrentLeave;
            txtTotalApplicableLeave.Text = TotalApplicableLeaves.ToString();
            BalanceLeaves = TotalApplicableLeaves - EnjoyLeaves;

            //NetBalanceLeave = OpeningLeave + CurrentLeave;

            if (BalanceLeaves > 30)
                BalanceLeaves = 30;

            txtBalanceLeave.Text = BalanceLeaves.ToString();
        }

        int OverTimeApplicable = 0, FlexibleHoursFlag = 0;

        private void cbOverTimeApplicable_CheckedChanged(object sender, EventArgs e)
        {
            if(cbOverTimeApplicable.Checked)
                OverTimeApplicable = 1;
            else
                OverTimeApplicable = 0;
        }

        private void cmbEffetType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Effect_Master(cmbEffetType.Text);
        }

        bool LocationDepartmentFlag = false;
        string ColumnName_V=string.Empty, ColumnName1_V = string.Empty, TableName_V = string.Empty;
        private void Fill_Effect_Master(string EffectType)
        {
            //Location and Department
            //Contractor
            //Designation
            //Employment Type
            //Job Profile
            //Weekly Off
            cmbMasterName.SelectedIndex = -1;
            cmbMasterName1.SelectedIndex = -1;

            cmbMasterName.DataSource = null;
            cmbMasterName1.DataSource = null;

            ColumnName_V = string.Empty; ColumnName1_V = string.Empty; TableName_V = string.Empty;
            lblMasterName1.Visible = false;
            cmbMasterName1.Visible = false;
            LocationDepartmentFlag = false;

            if (EffectType == "Contractor")
            {
                ColumnName_V = "ContractorId"; ColumnName1_V = "ContractorName"; TableName_V = "contractormaster";
                lblMasterName.Text = "Contractor Name";
            }
            else if (EffectType == "Employment Type")
            {
                ColumnName_V = "EmployementTypeId"; ColumnName1_V = "EmployementType"; TableName_V = "employementtypemaster";
                lblMasterName.Text = "Employment Type";
            }
            else if (EffectType == "Location and Department")
            {
                lblMasterName.Text = "Location";
                lblMasterName1.Text = "Department";
                LocationDepartmentFlag = true;
                lblMasterName1.Visible = true;
                cmbMasterName1.Visible = true;
                objRL.Fill_Location_ComboBox(cmbMasterName);
                //ColumnName_V = "DepartmentId"; ColumnName1_V = "Department"; TableName_V = "departmentmaster";
            }
            else if (EffectType == "Designation")
            {
                ColumnName_V = "DesignationId"; ColumnName1_V = "Designation"; TableName_V = "designationmaster";
                lblMasterName.Text = "Designation";
            }
            else if (EffectType == "Job Profile")
            {
                ColumnName_V = "JobProfileId"; ColumnName1_V = "JobProfile"; TableName_V = "jobprofilemaster";
                lblMasterName.Text = "Job Profile";
            }
            else if (EffectType == "Weekly Off")
            {
                ColumnName_V = "CategoryId"; ColumnName1_V = "CategoryFName"; TableName_V = "categories";
                lblMasterName.Text = "Weekly Off";
            }
            else { }

            if(!LocationDepartmentFlag)
            {
                string Query = string.Empty;    
                Query = "select " + ColumnName_V + "," + ColumnName1_V + " from " + TableName_V + " where CancelTag=0";

                objBL.Query = Query;

                DataSet ds = new DataSet();
                ds = objBL.ReturnDataSet(); 
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbMasterName.DataSource = ds.Tables[0];
                    cmbMasterName.DisplayMember = ColumnName1_V;
                    cmbMasterName.ValueMember = ColumnName_V;
                    cmbMasterName.SelectedIndex = -1;
                }
            }
        }

        private bool Validation_Effect_Information()
        {
            objEP.Clear();
            bool ReturnFlag = false;

            if (cmbEffetType.SelectedIndex == -1)
            {
                objEP.SetError(cmbEffetType, "Select Effet Type");
                cmbEffetType.Focus();
            }
            else if (cmbMasterName.SelectedIndex == -1)
            {
                objEP.SetError(cmbMasterName, "Select Master Name");
                cmbMasterName.Focus();
            }
            else
                ReturnFlag = false;

            return ReturnFlag;
        }

        int IsPrimary = 0,MasterId1 = 0; string MasterName1 = string.Empty;

        private void SaveEffectiveData()
        {
            if (!Validation_Effect_Information())
            {
                string ColumnName = string.Empty, ColumnName1 = string.Empty, UpdateQuery = string.Empty;
                MasterName1 = string.Empty; MasterId1 = 0;

                if (cbIsPrimary.Checked)
                    IsPrimary = 1;
                else
                    IsPrimary = 0;

                if (cmbEffetType.Text == "Location and Department")
                {
                    MasterName1 = cmbMasterName1.Text;
                    MasterId1 = Convert.ToInt32(cmbMasterName1.SelectedValue);

                    ColumnName = " LocationId ";
                    ColumnName1 = " DepartmentId ";
                    UpdateQuery = ColumnName + "=" + cmbMasterName.SelectedValue + "," + ColumnName1 + "=" + cmbMasterName1.SelectedValue;
                }
                else if (cmbEffetType.Text == "Contractor")
                {
                    ColumnName = " ContractorId ";
                    UpdateQuery = ColumnName + "=" + cmbMasterName.SelectedValue;
                }
                else if (cmbEffetType.Text == "Designation")
                {
                    ColumnName = " DesignationId ";
                    UpdateQuery = ColumnName + "=" + cmbMasterName.SelectedValue;
                }
                else if (cmbEffetType.Text == "Employment Type")
                {
                    ColumnName = " EmployementTypeId ";
                    UpdateQuery = ColumnName + "=" + cmbMasterName.SelectedValue;
                }
                else if (cmbEffetType.Text == "Job Profile")
                {
                    ColumnName = " JobProfile ";
                    UpdateQuery = ColumnName + "='" + cmbMasterName.Text + "'";
                }
                else if (cmbEffetType.Text == "Weekly Off")
                {
                    ColumnName = " CategoryId ";
                    UpdateQuery = ColumnName + "=" + cmbMasterName.SelectedValue;
                }
                else
                {

                }
                if(EmployeeEffectId ==0)
                {
                    objBL.Query = "update employeeseffect set IsPrimary=0 where EmployeeId=" + objPC.EmployeeId + " and EffectType='" + cmbEffetType.Text + "' and CancelTag=0 ";
                    Result = objBL.Function_ExecuteNonQuery();

                    objBL.Query = "insert into employeeseffect(EmployeeId,FromDate,EffectType,MasterName,MasterId,MasterName1,MasterId1,IsPrimary,UserId,FinancialYearId) values(" + objPC.EmployeeId + ",'" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + cmbEffetType.Text + "','" + cmbMasterName.Text + "'," + cmbMasterName.SelectedValue + ",'" + MasterName1 + "'," + MasterId1 + "," + IsPrimary + "," + BusinessLayer.LoginId_Static + "," + objPC.FinancialYearId + ")";
                    Result = objBL.Function_ExecuteNonQuery();

                    //Update Primary
                   
                }
                else
                {
                    objBL.Query = "update employeeseffect set  EmployeeId="+objPC.EmployeeId+",FromDate='" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "',EffectType='" + cmbEffetType.Text + "',MasterName='" + cmbMasterName.Text + "',MasterId=" + cmbMasterName.SelectedValue + ",MasterName1='" + MasterName1 + "',MasterId1=" + MasterId1 + ",IsPrimary=" + IsPrimary + ",ModifiedUserId=" + BusinessLayer.LoginId_Static + ",FinancialYearId=" + objPC.FinancialYearId + " where EmployeeEffectId=" + EmployeeEffectId + " and CancelTag=0 ";
                    Result = objBL.Function_ExecuteNonQuery();
                }
                

                if (Result > 0)
                {
                    ClearAll_Effect_Information();
                    FillGrid_Effect_Information();

                    objBL.Query = "update employees set " + UpdateQuery + " where EmployeeId=" + objPC.EmployeeId + " and CancelTag=0"; // (EmployeeId,FromDate,EffectType,MasterName,MasterId,MasterName1,MasterId1,IsPrimary,UserId) values(" + objPC.EmployeeId + ",'" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "','" + cmbEffetType.Text + "','" + cmbMasterName.Text + "'," + cmbMasterName.SelectedValue + ",'" + MasterName1 + "'," + MasterId1 + "," + IsPrimary + "," + BusinessLayer.LoginId_Static + ")";
                    Result = objBL.Function_ExecuteNonQuery();
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }
        private void btnAddEI_Click(object sender, EventArgs e)
        {
            //EmployeeEffectId = 0;
            SaveEffectiveData();
        }
        private void FillGrid_Effect_Information()
        {
            dgvEffectInformation.DataSource = null;
            DataSet ds = new DataSet();
            objBL.Query = "select EmployeeEffectId,EmployeeId,FromDate as 'Effect From',ToDate,EffectType,MasterName,MasterId,MasterName1,MasterId1,IsPrimary from employeeseffect where CancelTag=0 and EmployeeId=" + objPC.EmployeeId+"";
            ds= objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                //0 EmployeeEffectId,
                //1 EmployeeId,
                //2 FromDate,
                //3 ToDate,
                //4 EffectType,
                //5 MasterName,
                //6 MasterId,
                //7 MasterName1,
                //8 MasterId1
                //9 IsPrimary
                dgvEffectInformation.DataSource = ds.Tables[0];
                dgvEffectInformation.Columns[0].Visible = false;
                dgvEffectInformation.Columns[1].Visible = false;
                dgvEffectInformation.Columns[3].Visible = false;
                dgvEffectInformation.Columns[6].Visible = false;
                dgvEffectInformation.Columns[8].Visible = false;
                dgvEffectInformation.Columns[9].Visible = false;

                dgvEffectInformation.Columns[2].Width = 150;
                dgvEffectInformation.Columns[4].Width = 200;
                dgvEffectInformation.Columns[5].Width = 200;
            }
        }

        private void ClearAll_Effect_Information()
        {
            objEP.Clear();
            EmployeeEffectId = 0;
            dtpFromDate.Value = DateTime.Now.Date;
            cmbEffetType.SelectedIndex = -1;
            cmbMasterName.SelectedIndex = -1;
            cmbMasterName1.SelectedIndex = -1;
            cbIsPrimary.Checked = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //if(EmployeeEffectId >0)
            //{
            //    SaveEffectiveData();
            //}
        }
        int EmployeeEffectId = 0;
        private void dgvEffectInformation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                EmployeeEffectId = 0;
                RowCount_Grid = 0;
                CurrentRowIndex = 0;
                RowCount_Grid = dgvEffectInformation.Rows.Count;
                CurrentRowIndex = dgvEffectInformation.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    //0 EmployeeEffectId,
                    //1 EmployeeId,
                    //2 FromDate,
                    //3 ToDate,
                    //4 EffectType,
                    //5 MasterName,
                    //6 MasterId,
                    //7 MasterName1,
                    //8 MasterId1
                    //9 IsPrimary


                    EmployeeEffectId = Convert.ToInt32(dgvEffectInformation.Rows[e.RowIndex].Cells[0].Value);

                    if (!string.IsNullOrEmpty(Convert.ToString(dgvEffectInformation.Rows[e.RowIndex].Cells[2].Value)))
                        dtpFromDate.Value =Convert.ToDateTime(dgvEffectInformation.Rows[e.RowIndex].Cells[2].Value);

                    cmbEffetType.Text = objRL.CheckNullString(Convert.ToString(dgvEffectInformation.Rows[e.RowIndex].Cells[4].Value));

                    Fill_Effect_Master(cmbEffetType.Text);

                    cmbMasterName.Text = objRL.CheckNullString(Convert.ToString(dgvEffectInformation.Rows[e.RowIndex].Cells[5].Value));

                    if (cmbEffetType.Text == "Location and Department")
                    {
                        if (cmbMasterName.SelectedIndex > -1)
                        {
                            objPC.LocationId = Convert.ToInt32(cmbMasterName.SelectedValue);
                            objRL.Fill_Department_ComboBox_By_Location(cmbMasterName1, Convert.ToInt32(cmbMasterName.SelectedValue));
                            cmbMasterName1.Text = objRL.CheckNullString(Convert.ToString(dgvEffectInformation.Rows[e.RowIndex].Cells[7].Value));
                        }
                    }
                }
            }
            catch (Exception ex1)
            {
                objRL.ErrorMessge(ex1.ToString());
                return;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void cmbStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbStatus.SelectedIndex > -1)
                dtpDateOfExit.Enabled = true;
            else
                dtpDateOfExit.Enabled = false;
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Department_EmployeeWise();
        }

        private void Fill_Department_EmployeeWise()
        {
            if (cmbLocation.SelectedIndex > -1)
            {
                objPC.LocationId = (Convert.ToInt32(cmbLocation.SelectedValue));
                objRL.Fill_Department_ComboBox_By_Location(cmbDepartment,Convert.ToInt32(cmbLocation.SelectedValue));
            }
        }

        private void cmbMasterName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cmbMasterName1.DataSource = null;
            cmbMasterName1.SelectedIndex = -1;

            if (cmbEffetType.Text == "Location and Department")
            {
                if (cmbMasterName.SelectedIndex > -1)
                {
                    objPC.LocationId = Convert.ToInt32(cmbMasterName.SelectedValue);
                    objRL.Fill_Department_ComboBox_By_Location(cmbMasterName1, Convert.ToInt32(cmbMasterName.SelectedValue));
                }
            }
        }

        private void btnClearEI_Click(object sender, EventArgs e)
        {
            EmployeeEffectId = 0;
            ClearAll_Effect_Information();
        }

        private void btnDeleteEI_Click(object sender, EventArgs e)
        {

        }

        private void txtEmployeePunchNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtEmployeePunchNumber);
        }
        private void txtEmployeeNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtEmployeeNumber);
        }

        private void txtBasicMonthly_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtBasicMonthly);
        }

        private void txtHRAMonthly_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtHRAMonthly);
        }

        private void txtEducationAllowanceMonthly_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtTravelAllowance);
        }

        private void txtConveyanceAllowanceMonthly_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtLoanAmount);
        }

        private void txtOtherAllowanceMonthly_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtOtherAdvance);
        }

        private void txtTaxDeductedAsSourceMonthly_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtTaxDeductedAsSourceMonthly);
        }

        private void txtProvidentFundMonthly_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtProvidentFundMonthly);
        }

        private void txtGrossSalaryMonthly_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtGrossSalaryMonthly);
        }

        private void txtNetSalaryMonthly_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtNetSalaryMonthly);
        }

        private void txtPincode_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtPincode);
        }

        private void txtPincode1_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtPincode1);
        }

        private void txtAadharCardMember_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtAadharCardMember);
        }

        private void txtContactNoMember_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtContactNoMember);
        }

        private void txtContactNoNominee_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtContactNoNominee);
        }

        private void txtIFSCCodeNominee_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.TxtNumericValue(sender, e, txtIFSCCodeNominee);
        }

        private void txtMobileNumberEC_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtMobileNumberEC);
        }

        private void txtWorkPhoneEC_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtWorkPhoneEC);
        }

        private void txtHomePhoneEC_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtHomePhoneEC);
        }

        private void txtAadharCardNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtAadharCardNo);
        }

        private void txtPANNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.TxtNumericValue(sender, e, txtPANNo);
        }

        private void txtMobileNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtMobileNumber);
        }

        //

        private void Get_Leaves()
        {
            double LeaveApplicable = 0;// txtCurrentLeave.Text = "";
            dgvLeaves.Rows.Clear();
            DataSet ds = new DataSet();

            objBL.Query = "select LT.LeaveTypeId,LT.LeaveTypeFName,LADWM.LeaveApplicable from leavetypes LT inner join leaveassigndesignationwisemaster LADWM on LADWM.LeaveTypeId=LT.LeaveTypeId inner join usertypemaster UTM on UTM.UserTypeId=LADWM.UserTypeId where LADWM.CancelTag=0 and LT.CancelTag=0 and LT.LeaveTypeFName IN ('Casual Leave','Paid Leave','Sick Leave','Marraige Leave') AND UTM.UserType='"+objPC.DesignationCategory+"'";
            ds= objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvLeaves.Rows.Add();
                    dgvLeaves.Rows[i].Cells["clmLeaveTypeId"].Value = ds.Tables[0].Rows[i]["LeaveTypeId"].ToString();
                    dgvLeaves.Rows[i].Cells["clmLeaveType"].Value = ds.Tables[0].Rows[i]["LeaveTypeFName"].ToString();
                    LeaveApplicable = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["LeaveApplicable"])));

                    if (dgvLeaves.Rows[i].Cells["clmLeaveType"].Value.ToString() == "Marraige Leave")
                    {
                        if (cmbMaritalStatus.SelectedIndex > -1 && cmbMaritalStatus.Text == "MARRIED")
                            LeaveApplicable = 0;
                    }
                        
                    dgvLeaves.Rows[i].Cells["clmLeaveApplicable"].Value = LeaveApplicable.ToString();// ds.Tables[0].Rows[i]["LeaveApplicable"].ToString();

                    //if (dgvLeaves.Rows[i].Cells["clmLeaveType"].Value.ToString() == "Paid Leave")
                    //    txtCurrentLeave.Text = LeaveApplicable.ToString();
                }
                CalculationLeaves();
            }
        }

        private void txtTotalApplicableLeave_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbFlexibleHours_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFlexibleHours.Checked)
                FlexibleHoursFlag = 1;
            else
                FlexibleHoursFlag = 0;
        }
    }
}
