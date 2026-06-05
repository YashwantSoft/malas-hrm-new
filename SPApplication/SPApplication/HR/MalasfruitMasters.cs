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
    public partial class MalasfruitMasters : Form
    {
        public MalasfruitMasters()
        {
            InitializeComponent();
            btnUserMaster.BackgroundImage = BusinessResources.Users;
            btnContractorMaster.BackgroundImage = BusinessResources.ContractorMaster;
            btnDepartmentMaster.BackgroundImage = BusinessResources.DepartmentMaster;
            btnUnitMaster.BackgroundImage = BusinessResources.UnitMaster;
            btnEmployeeTypeMaster.BackgroundImage = BusinessResources.EmployeeTypeMaster;
            btnApprovalLevelMaster.BackgroundImage = BusinessResources.ApprovalLevelMaster;
            btnHealthInsurancePolicyMaster.BackgroundImage = BusinessResources.HealthInsurancePolicyMastetr;
            btnBasicSalaryMaster.BackgroundImage = BusinessResources.BasicSalaryMaster;
            btnEmployeeMaster.BackgroundImage = BusinessResources.EmployeeMaster;
            btnCompanyProfile.BackgroundImage = BusinessResources.CompanyProfile;
            btnLeaveApproval.BackgroundImage = BusinessResources.LeaveApproval;
            btnDesignationMaster.BackgroundImage = BusinessResources.DesignationMaster;
            btnPercentageStructure.BackgroundImage = BusinessResources.PercentageSrtucture;
            btnLeaveMaster.BackgroundImage = BusinessResources.LeaveMaster;
            btnLeaveManagementMaster.BackgroundImage = BusinessResources.LeaveManagementMaster;
            btnExit.BackgroundImage = BusinessResources.Exit;
        }

        private void btnConstractorMaster_Click(object sender, EventArgs e)
        {
            Contractor_Master objForm = new Contractor_Master();
            objForm.ShowDialog(this);
        }

        private void btnDepartmentMaster_Click(object sender, EventArgs e)
        {
           Department_Master objForm = new Department_Master();
            objForm.ShowDialog(this);
        }

        private void btnUnitMaster_Click(object sender, EventArgs e)
        {
            Unit_Master objForm = new Unit_Master();
            objForm.ShowDialog(this);
        }

        private void btnDesignationMaster_Click(object sender, EventArgs e)
        {
            Designation_Master objForm = new Designation_Master();
            objForm.ShowDialog(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnEmployeeTypeMaster_Click(object sender, EventArgs e)
        {
            Employee_Type_Master objForm = new Employee_Type_Master();
            objForm.ShowDialog(this);
        }

        private void btnApprovalLevelMaster_Click(object sender, EventArgs e)
        {
            Approval_Level_Master objForm = new Approval_Level_Master();
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

        private void btnLeaveApproval_Click(object sender, EventArgs e)
        {
            Leave_Approval objForm = new Leave_Approval();
            objForm.ShowDialog(this);

        }

        private void btnLeaveManagementMaster_Click(object sender, EventArgs e)
        {
            Leave_Management_Master objForm  = new Leave_Management_Master();
            objForm.ShowDialog( this);

        }

        private void btnEmployeeMaster_Click(object sender, EventArgs e)
        {
            Employee_Master objForm = new Employee_Master();
            objForm.ShowDialog(this);
        }

        private void btnCompanyProfile_Click(object sender, EventArgs e)
        {
            Company_Profile objForm = new Company_Profile();
            objForm.ShowDialog(this);
        }

        private void MalasfruitMasters_Load(object sender, EventArgs e)
        {

        }

        private void btnUserMaster_Click(object sender, EventArgs e)
        {
            Users objForm = new Users();
            objForm.ShowDialog(this);
        }
    }
}
