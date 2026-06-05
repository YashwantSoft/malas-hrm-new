using BusinessLayerUtility;
using SPApplication.Master;
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
    public partial class MalasfruitMasters : Form
    {
        DesignLayer objDL = new DesignLayer();

        public MalasfruitMasters()
        {
            InitializeComponent();
            btnUserMaster.BackgroundImage = BusinessResources.Users;
            btnContractorMaster.BackgroundImage = BusinessResources.ContractorMaster;
            btnDepartmentMaster.BackgroundImage = BusinessResources.DepartmentMaster;
            btnUnitMaster.BackgroundImage = BusinessResources.UnitMaster;
            btnEmployeeTypeMaster.BackgroundImage = BusinessResources.EmployeeTypeMaster;
            btnApprovalLevelMaster.BackgroundImage = BusinessResources.ApprovalLevelMaster;
            //btnHealthInsurancePolicyMaster.BackgroundImage = BusinessResources.HealthInsurancePolicyMastetr;
            btnBasicSalaryMaster.BackgroundImage = BusinessResources.BasicSalaryMaster;
            btnEmployeeMaster.BackgroundImage = BusinessResources.EmployeeMaster;
            btnCompanyProfile.BackgroundImage = BusinessResources.CompanyProfile;
            btnLeaveApproval.BackgroundImage = BusinessResources.LeaveApproval;
            btnDesignationMaster.BackgroundImage = BusinessResources.DesignationMaster;
            btnPercentageStructure.BackgroundImage = BusinessResources.PercentageSrtucture;
            btnLeaveMaster.BackgroundImage = BusinessResources.LeaveMaster;
            btnLeaveManagementMaster.BackgroundImage = BusinessResources.LeaveManagementMaster;
            btnExit.BackgroundImage = BusinessResources.Exit;
            btnContryMaster.BackgroundImage = BusinessResources.Contry;
            btnCategoryMaster.BackgroundImage = BusinessResources.CategoryMaster;
            btnShiftMaster.BackgroundImage = BusinessResources.ShiftMaster;

            btnStateMaster.BackgroundImage = BusinessResources.StateMaster;
            btnDistrictMaster.BackgroundImage = BusinessResources.DistrictMaster;
            btnTalukaMaster.BackgroundImage = BusinessResources.TalukaMaster;
            btnCityMaster.BackgroundImage = BusinessResources.CityMaster;
            btnAreaMaster.BackgroundImage = BusinessResources.AreaMaster;

            objDL.SetBackForeColour_Button(btnCategoryMaster);
            objDL.SetBackForeColour_Button(btnContryMaster);
            objDL.SetBackForeColour_Button(btnStateMaster);
            objDL.SetBackForeColour_Button(btnDistrictMaster);
            objDL.SetBackForeColour_Button(btnTalukaMaster);
            objDL.SetBackForeColour_Button(btnAreaMaster);
            objDL.SetBackForeColour_Button(btnCityMaster);
            objDL.SetBackForeColour_Button(btnShiftMaster);
        }

        private void btnConstractorMaster_Click(object sender, EventArgs e)
        {
            ContractorMaster objForm = new ContractorMaster();
            objForm.ShowDialog(this);
        }

        private void btnDepartmentMaster_Click(object sender, EventArgs e)
        {
           DepartmentMaster objForm = new DepartmentMaster();
            objForm.ShowDialog(this);
        }

        private void btnUnitMaster_Click(object sender, EventArgs e)
        {
            LocationMaster objForm = new LocationMaster();
            objForm.ShowDialog(this);
        }

        private void btnDesignationMaster_Click(object sender, EventArgs e)
        {
            DesignationMaster objForm = new DesignationMaster();
            objForm.ShowDialog(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEmployeeTypeMaster_Click(object sender, EventArgs e)
        {
            EmployeeTypeMaster objForm = new EmployeeTypeMaster();
            objForm.ShowDialog(this);
        }

        private void btnApprovalLevelMaster_Click(object sender, EventArgs e)
        {
            LocationDepartmentWiseUsers objForm = new LocationDepartmentWiseUsers();
            objForm.ShowDialog(this);
        }

        private void btnLeaveMaster_Click(object sender, EventArgs e)
        {
            Leave_Master objForm = new Leave_Master();
            objForm.ShowDialog(this);
        }

        private void btnHealthInsurancPolicyMaster_Click(object sender, EventArgs e)
        {
            Health_Insurance_Policy_Master objForm = new Health_Insurance_Policy_Master();
            objForm.ShowDialog(this);
        }

        private void btnBasicSalaryMaster_Click(object sender, EventArgs e)
        {
            Basic_Salary_Master objForm = new Basic_Salary_Master();
            objForm.ShowDialog(this);

        }

        private void btnPercentageStructure_Click(object sender, EventArgs e)
        {
            Percentage_Structure objForm = new Percentage_Structure();
            objForm.ShowDialog(this);
        }
 

        private void btnLeaveManagementMaster_Click(object sender, EventArgs e)
        {
            Leave_Management_Master objForm  = new Leave_Management_Master();
            objForm.ShowDialog( this);

        }

        private void btnEmployeeMaster_Click(object sender, EventArgs e)
        {
            EmployeeMaster objForm = new EmployeeMaster();
            objForm.ShowDialog(this);
        }

        private void btnCompanyProfile_Click(object sender, EventArgs e)
        {
            CompanyProfile objForm = new CompanyProfile();
            objForm.ShowDialog(this);
        }

        private void MalasfruitMasters_Load(object sender, EventArgs e)
        {

        }

        private void btnUserMaster_Click(object sender, EventArgs e)
        {
            AddUser objForm = new AddUser();
            objForm.ShowDialog(this);
        }

        private void btnCategoryMaster_Click_1(object sender, EventArgs e)
        {
            CategoryMaster objForm = new CategoryMaster();
            objForm.ShowDialog(this);
        }

        private void btnShiftMaster_Click(object sender, EventArgs e)
        {
            ShiftMaster objForm = new ShiftMaster();
            objForm.ShowDialog(this);
        }

        private void btnContryMaster_Click(object sender, EventArgs e)
        {
            CountryMaster objForm = new CountryMaster();
            objForm.ShowDialog(this);
        }

        private void btnDistrictMaster_Click(object sender, EventArgs e)
        {
            DistrictMaster objForm = new DistrictMaster();
            objForm.ShowDialog(this);
        }

        private void btnStateMaster_Click(object sender, EventArgs e)
        {
            StateMaster objForm = new StateMaster();
            objForm.ShowDialog(this);
        }

        private void btnTalukaMaster_Click(object sender, EventArgs e)
        {
            TalukaMaster objForm = new TalukaMaster();
            objForm.ShowDialog(this);
        }

        private void btnCityMaster_Click(object sender, EventArgs e)
        {
            CityVillageMaster objForm = new CityVillageMaster();
            objForm.ShowDialog(this);
        }

        private void btnAreaMaster_Click(object sender, EventArgs e)
        {
            AreaMaster objForm = new AreaMaster();
            objForm.ShowDialog(this);
        }
    }
}
