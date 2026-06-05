using BusinessLayerUtility;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPApplication.HR
{
    public partial class AddUser : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();
         
        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        public AddUser()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_USERMANAGEMENT);

            objRL.Get_UserRights_By_MenuName(BusinessResources.LBL_HEADER_USERMANAGEMENT);
            
            objQL.Fill_Master_ComboBox(cmbUserType, "usertypemaster");
            objQL.Fill_Master_ComboBox(cmbDepartment, "departmentmaster");
            objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");
            //objQL.Fill_Master_ComboBox(cmbUserType, "designationmaster");
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
            btnDelete.Enabled = false;
            objEP.Clear();
            cmbUserType.SelectedIndex = -1;
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbEmployeeName.SelectedIndex = -1;
            txtUserName.Text = "";
            txtDesignation.Text = "";
                        objPC.EmployeeId = 0;
            cmbUserType.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FlagDelete = true;
            SaveDB();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FlagDelete = false;
            SaveDB();
        }

        private bool CheckExistUser()
        {
            bool ReturnValue = false;
            objPC.LoginId = TableId;
            objPC.UserName = txtUserName.Text;
            ReturnValue = objQL.SP_Login_CheckExist();
            return ReturnValue;
        }

        string Search = string.Empty;
        private void SaveDB()
        {
            if(!Validation())
            {
                if (!CheckExistUser())
                {
                    if (!FlagDelete)
                        objPC.DeleteFlag = false;
                    else
                        objPC.DeleteFlag = true;
                        
                    objPC.LoginId = TableId;
                    objPC.UserTypeId = Convert.ToInt32(cmbUserType.SelectedValue);
                    objPC.UserName = txtUserName.Text;
                    //objPC.UserType = cmbUserType.Text;
                    objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                    
                    //Result = objQL.SP_Insert_Update_Delete_Select_LoginUsers();
                    Result = objQL.SP_Login_Insert_Update_Delete_Select();
                    
                    if (Result > 0)
                    {
                        objRL.ShowMessage(7, 1);
                        ClearAll();
                        FillGrid();
                    }
                    else
                    {

                    }
                }
                else
                {
                    objRL.ShowMessage(12, 4);
                    return;
                }
            }
            else
            {

            }
        }

        private bool Validation()
        {
            objEP.Clear();
            if (cmbLocation.SelectedIndex == -1)
            {
                objEP.SetError(cmbLocation, "Select Location");
                return true;
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                objEP.SetError(cmbDepartment, "Select User Type");
                return true;
            }
            else if (cmbEmployeeName.SelectedIndex == -1)
            {
                objEP.SetError(cmbEmployeeName, "Select Employee Name");
                return true;
            }
            else if (cmbUserType.SelectedIndex == -1)
            {
                objEP.SetError(cmbUserType, "Select User Type");
                return true;
            }
            else if (txtUserName.Text == "")
            {
                objEP.SetError(txtUserName, "Enter User Name");
                return true;
            }
            else if (txtDesignation.Text == "")
            {
                objEP.SetError(txtDesignation, "Enter Designation");
                return true;
            }
            else
                return false;
        }

        private void Users_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        protected void FillGrid()
        {
            dataGridView1.DataSource = null;
            lblTotalCount.Text = "";
            objPC.EmployeeName = "";

            DataSet ds = new DataSet();

            if (!SearchFlag)
                objPC.SearchFlag = false;
            else
            {
                objPC.SearchFlag = true;
                objPC.EmployeeName = txtSearch.Text;
            }
              
            ds = objQL.SP_Login_FillGrid();
             
            if (ds.Tables[0].Rows.Count > 0)
            {
                //0	L.LoginId,
                //1 UTM.UserType as 'User Type',
                //2 D.LocationName as 'Location',
                //3 DME.Department,
                //4 L.UserName as 'User Name',
                //5 E.EmployeeName as 'Employee Name', 
                //6 DM.Designation,
                //7 L.UserTypeId,
                //8 L.EmployeeId,
                //9 E.DesignationId,
                //10 E.DepartmentId,
                //11 E.LocationId

                lblTotalCount.Text = "Total Count-" + ds.Tables[0].Rows.Count;
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
                dataGridView1.Columns[9].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;

                dataGridView1.Columns[1].Width = 120;
                dataGridView1.Columns[2].Width = 120;
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[4].Width = 120;
                dataGridView1.Columns[5].Width = 200;
                dataGridView1.Columns[6].Width = 120;

            }
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Employee_ComboBox();
        }

        private void Fill_Employee_ComboBox()
        {
            if (cmbDepartment.SelectedIndex > -1 && cmbLocation.SelectedIndex >-1)
            {
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objPC.DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                objQL.SP_Employees_ComboBox_By_DepartmentId_LocationId(cmbEmployeeName);
                //objQL.SP_Employees_Get_By_All(BusinessResources.SearchBy_Designation, BusinessResources.USER_TYPE_INCHARGE, cmbInchargeName, "");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dataGridView1.Rows.Count;
                CurrentRowIndex = dataGridView1.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    ClearAll();

                    //0	L.LoginId,
                    //1 UTM.UserType as 'User Type',
                    //2 D.LocationName as 'Location',
                    //3 DME.Department,
                    //4 L.UserName as 'User Name',
                    //5 E.EmployeeName as 'Employee Name', 
                    //6 DM.Designation,
                    //7 L.UserTypeId,
                    //8 L.EmployeeId,
                    //9 E.DesignationId,
                    //10 E.DepartmentId,
                    //11 E.LocationId

                    btnDelete.Enabled = true;
                    TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    cmbUserType.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cmbLocation.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    cmbDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtUserName.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    objQL.Fill_Master_ComboBox(cmbEmployeeName, "employees");
                    cmbEmployeeName.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    Fill_EmployeeDetails();
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        private void cmbEmployeeName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_EmployeeDetails();
        }

        private void Fill_EmployeeDetails()
        {
            txtUserName.Text = "";
            txtDesignation.Text = "";

            if (cmbEmployeeName.SelectedIndex > -1)
            {
                objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                 
                DataSet ds = new DataSet();
                objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                ds = objQL.SP_Employees_By_EmployeeId();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Code"].ToString())))
                        txtUserName.Text = ds.Tables[0].Rows[0]["Code"].ToString();
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["Designation"].ToString())))
                        txtDesignation.Text = ds.Tables[0].Rows[0]["Designation"].ToString();
                }
            }
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
