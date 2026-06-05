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

namespace SPApplication.Transaction
{
    public partial class LeaveApplication : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;
        
        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;

        int SearchId = 0, LocationId = 0;

        public LeaveApplication()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_LEAVEAPPLICATION);
            ClearAll();
            //objQL.Fill_Master_ComboBox(cmbLeaveType, "leavetypes");
            objRL.Fill_LeaveType(cmbLeaveType, true);
            objRL.FillLocation(cmbLocation, cmbDepartment);
            FillEmployee_Fixed();
        }


        //private void FillLocation()
        //{
        //    //ADMINISTRATOR     BusinessResources.USER_TYPE_ADMINISTRATOR
        //    //HR OFFICER        BusinessResources.USER_TYPE_HROFFICER
        //    //MANAGER           BusinessResources.USER_TYPE_MANAGER
        //    //SENIOR OFFICER    BusinessResources.USER_TYPE_SENIOROFFICER
        //    //OFFICER           BusinessResources.USER_TYPE_OFFICER
        //    //SUPERVISOR        BusinessResources.USER_TYPE_SUPERVISOR
        //    //TRAINEE           BusinessResources.USER_TYPE_TRAINEE
        //    //WORKER            BusinessResources.USER_TYPE_WORKER


        //    bool FlagCheck = false;
        //    cmbLocation.Enabled = true;
        //    cmbDepartment.Enabled = true;
        //    cmbEmployeeName.Enabled = true;
        //    FlagCheck = false;

        //    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
        //    {
        //        btnSave.Visible = true;
        //        objQL.WhereClause_V = "";
        //    }
        //    else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
        //        objQL.WhereClause_V = " and lwd.PlantHeadId=" + SearchId + " ";
        //    else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
        //        objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + " ";
        //    else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
        //        FlagCheck = true;
        //    else
        //    {
        //        objRL.ShowMessage(38, 4);
        //        return;
        //    }

        //    if (!FlagCheck)
        //    {
        //        objQL.Fill_Location_By_EmployeeId(cmbLocation);

        //        if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER) // || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_MANAGER)
        //        {
        //            cmbLocation.Text = BusinessLayer.LocationName;
        //            FillDepartment();
        //            //cmbLocation.Enabled = false;
        //            cmbDepartment.Text = BusinessLayer.Department;
        //        }
        //        else
        //        {
        //            cmbLocation.Enabled = true;
        //            cmbLocation.SelectedIndex = -1;
        //            cmbDepartment.SelectedIndex = -1;
        //        }
        //    }
        //    else
        //    {
        //        cmbLocation.Enabled = false;
        //        cmbDepartment.Enabled = false;
        //        cmbEmployeeName.Enabled = false;
        //        objRL.Fill_Location_ComboBox(cmbLocation);
        //        cmbLocation.Text = BusinessLayer.LocationName;
        //        objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
        //        objRL.Fill_Department_ComboBox_By_Location(cmbDepartment, Convert.ToInt32(cmbLocation.SelectedValue));

        //        cmbDepartment.Text = BusinessLayer.Department;
        //        cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static;
        //    }

        //    //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
        //    //    objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + " ";
        //    //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
        //    //    objQL.WhereClause_V = " and lwd.PlantHeadId=" + SearchId + " ";
        //    //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
        //    //    objQL.WhereClause_V = "";
        //    //else
        //    //{
        //    //    FlagCheck = true;
        //    //    //objRL.ShowMessage(38, 4);
        //    //    //return;
        //    //}

        //    //if (!FlagCheck)
        //    //{
        //    //    objQL.Fill_Location_By_EmployeeId(cmbLocation);

        //    //    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
        //    //    {
        //    //        cmbLocation.Text = BusinessLayer.LocationName;
        //    //        FillDepartment();
        //    //        //cmbLocation.Enabled = false;
        //    //        cmbDepartment.Text = BusinessLayer.Department;
        //    //    }
        //    //    else
        //    //    {
        //    //        cmbLocation.Enabled = true;
        //    //        cmbLocation.SelectedIndex = -1;
        //    //        cmbDepartment.SelectedIndex = -1;
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    objRL.Fill_Location_ComboBox(cmbLocation);
        //    //    cmbLocation.Enabled = false;
        //    //    cmbLocation.Text = BusinessLayer.LocationName;
        //    //    objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
        //    //    objRL.Fill_Department_ComboBox_By_Location(cmbDepartment,Convert.ToInt32(cmbLocation.SelectedValue));
        //    //    cmbDepartment.Text = BusinessLayer.Department;
        //    //    cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static;
        //    //    cmbDepartment.Enabled = false;
        //    //}
        //}

        //private void FillDepartmentAdmin()
        //{
        //    //Hardcode
        //    if (cmbLocation.SelectedIndex > -1)
        //    {
        //        //LocationId = 
        //        objRL.Fill_Department_ComboBox_By_Location(cmbDepartment, Convert.ToInt32(cmbLocation.SelectedValue));
        //    }
        //}


        private void ClearAll_Location_Department()
        {
            cmbEmployeeName.SelectedIndex = -1;
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";
            
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;
            txtTotalDays.Text = "";
            cmbLeaveType.SelectedIndex = -1;
            txtReason.Text = "";
            txtRemarks.Text = "";
            rtbLeaveRecords.Text = "";
        }

        //private void FillDepartment()
        //{
        //    if (cmbLocation.SelectedIndex > -1)
        //    {
        //        LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
        //        objPC.LocationId = LocationId;
        //        objPC.InchargeId = BusinessLayer.EmployeeLoginId_Static;
        //        objQL.WhereClause_V = string.Empty;

        //        if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
        //            objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
        //        else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
        //            objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
        //        else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
        //            objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + "  and lwd.LocationId=" + objPC.LocationId + " ";
        //        //else if (BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.DesignationCategory == BusinessResources.USER_TYPE_SUPERVISOR)
        //        //    FlagCheck = true;
        //        else
        //        {
        //        }

        //        //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
        //        //    objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + "  and lwd.LocationId=" + objPC.LocationId + " ";
        //        //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
        //        //    objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
        //        //else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
        //        //    objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
        //        //else
        //        //{
        //        //    objRL.ShowMessage(38, 4);
        //        //    return;
        //        //}
        //        objQL.Fill_Department_By_EmployeeId(cmbDepartment);
        //    }
        //}

        //private void FillEmployees_Combobox()
        //{
        //    if (!string.IsNullOrEmpty(Convert.ToString(BusinessLayer.Designation)) && !string.IsNullOrEmpty(Convert.ToString(BusinessLayer.Department)))
        //    {
        //        cmbEmployeeName.Enabled = true;

        //        EmpDesignation = string.Empty;
        //        EmpDesignation = BusinessLayer.Designation.ToString();
        //        EmpDepartment = BusinessLayer.Department.ToString();
        //        objPC.DepartmentId = BusinessLayer.DepartmentId;

        //        if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
        //        {
        //            objQL.SP_Employees_ComboBox_By_Department(cmbEmployeeName);
        //            cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static.ToString();
        //            cmbEmployeeName.Enabled = false;
        //            Fill_EmployeeDetails();
        //        }
        //        else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
        //        {
        //            objQL.SP_Employees_ComboBox_By_Department(cmbEmployeeName);
        //        }
        //        else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR)
        //        {
        //            objQL.Fill_Master_ComboBox(cmbEmployeeName, "employees");
        //            //cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static.ToString();
        //            Fill_EmployeeDetails();
        //        }
        //        else
        //        {

        //        }


        //        //if (EmpDesignation == BusinessResources.USER_TYPE_INCHARGE || EmpDesignation == BusinessResources.USER_TYPE_OFFICER || EmpDesignation == BusinessResources.USER_TYPE_PLANTHEAD || EmpDesignation == BusinessResources.USER_TYPE_MANAGER)
        //        //{
        //        //    objQL.SP_Employees_ComboBox_By_Department(cmbEmployeeName);

        //        //    //objQL.SP_Employees_Get_By_All(BusinessResources.SearchBy_DesignationId, objPC.DepartmentId.ToString(), cmbEmployeeName, "");

        //        //    if (EmpDesignation == BusinessResources.USER_TYPE_OFFICER || EmpDesignation == BusinessResources.USER_TYPE_MANAGER)
        //        //    {
        //        //        objQL.Fill_Master_ComboBox(cmbEmployeeName, "employees");
        //        //        cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static.ToString();
        //        //        Fill_EmployeeDetails();
        //        //        cmbEmployeeName.Enabled = false;
        //        //    }
        //        //    else
        //        //    {
        //        //        cmbEmployeeName.Enabled = true;
        //        //    }
        //        //}
        //    }
        //}

        private void FillEmployees()
        {
            if (cmbLocation.SelectedIndex > -1 && cmbDepartment.SelectedIndex > -1)
            {
                objQL.WhereClause_V = string.Empty;
                LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objPC.LocationId = LocationId;

                objQL.WhereClause_V = " and E.LocationId=" + cmbLocation.SelectedValue + "  and E.DepartmentId=" + cmbDepartment.SelectedValue + "";
                objQL.SP_Employees_Get_By_All(cmbEmployeeName);
            }
        }

        private void ClearAll()
        {
            gbLeaveDetails.Enabled = true;
            objEP.Clear();
            cbRevertLeave.Visible = false;
            LeaveStatus = string.Empty;
            TableId = 0;
            //ReferanceCompOffLeaveApplicationId = 0;

            objPC.IsCompensationOff = 0;
            objPC.IsRevertLeave = 0;

            dtpDate.Value = DateTime.Now.Date;
            cmbLeaveType.SelectedIndex = -1;
            txtReason.Text = "";
            txtLeaveStatus.Text = "";
            rtbLeaveRecords.Text = "";
            txtLeaveStatus.Text = BusinessResources.LS_Pending;
            ClearAll_Location_Department();
            cbRevertLeave.Checked = false;
            //gbCompOffUtilization.Visible = false;
            //dgvCompOffList.Rows.Clear();
            //dtpCompOffUsedDate.Value = DateTime.Now.Date;
            //lblCompOffUsedDate.Visible = false;
            //dtpCompOffUsedDate.Visible = false;
            objPC.IsCompensationOff = 0;
            objPC.IsRevertLeave = 0;
            objPC.CompOffUsedFlag = 0;
        }

        private void LeaveApplication_Load(object sender, EventArgs e)
        {
            //ClearAll();
            FillGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //GST

            //GST Amount = Original Cost – [Original Cost x {100/(100+GST%)}] 
            //Net Price = Original Cost – GST Amount.

            //double OriginalCost = 3600, GSTAmount = 0, BasicPrice = 0;

            ////GSTAmount = ((double)80 / 100) * 18;


            //GSTAmount = OriginalCost - OriginalCost * 100 / (100 + 18);

            //GSTAmount = Math.Round(GSTAmount, 2);
            //BasicPrice = OriginalCost - GSTAmount;

            //GSTAmount = OriginalCost-(OriginalCost * (100/(100 + (18))));
            //NetPrice = OriginalCost - GSTAmount;

            //Net Price = Original Cost – GST Amount
            this.Dispose();
        }

        private bool Validation()
        {
            BalanceFlag = false;
            objEP.Clear();
            if(Leave_Validation())
            {
                BalanceFlag = true;
                return true;
            }
            else if (objPC.Balance_Count <= 0 && cmbLeaveType.Text != "Revert Leave" && cmbLeaveType.Text != "Special Leave")
            {
                BalanceFlag = true;
                return true;
            }
            else if(cmbEmployeeName.SelectedIndex == -1)
            {
                cmbEmployeeName.Focus();
                objEP.SetError(cmbEmployeeName, "Select Employee Name");
                return true;
            }
            else if (txtEmployeeCode.Text == "")
            {
                txtEmployeeCode.Focus();
                objEP.SetError(txtEmployeeCode, "Enter Employee Code");
                return true;
            }
            else if (txtDesignation.Text == "")
            {
                txtDesignation.Focus();
                objEP.SetError(txtDesignation, "Enter Designation");
                return true;
            }
            else if (txtTotalDays.Text == "")
            {
                txtTotalDays.Focus();
                objEP.SetError(txtTotalDays, "Enter Total Days");
                return true;
            }
            else if (cmbLeaveType.SelectedIndex == -1)
            {
                cmbLeaveType.Focus();
                objEP.SetError(cmbLeaveType, "Select Leave Type");
                return true;
            }
            else if (txtReason.Text == "")
            {
                txtReason.Focus();
                objEP.SetError(txtReason, "Enter Reason");
                return true;
            }
            else if (txtLeaveStatus.Text == "")
            {
                txtLeaveStatus.Focus();
                objEP.SetError(txtLeaveStatus, "Enter Status Current Leaves");
                return true;
            }
            
            else
                return false;
        }

        bool BalanceFlag = false;
        double TotalLeaves = 0, TotalLeavesAssigned=0;
        double BalanceLeavePrevious = 0;
        double CasualLeave_Count = 0, PaidLeave_Count = 0, SickLeave_Count = 0;


        string QueryColumn = string.Empty;
        string CheckBy = string.Empty;


        private double GetSumLeaveType()
        {
            double TCount = 0;
            
            DataSet ds = new DataSet();
            objBL.Query = "select COALESCE(SUM(TotalDays),0) from LeaveApplication LA inner join leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId where LA.CancelTag=0 and LT.CancelTag=0 and LT.LeaveTypeFName='" + CheckBy + "'";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0].ToString())))
                    TCount = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
            }
            return TCount;
        }

        

        //private void Get_Leave_Count()
        //{
        //    TotalLeaves = 0;

        //    CheckBy = "Casual Leave";
        //    CasualLeave_Count = GetSumLeaveType();
        //    CheckBy = "Paid Leave";
        //    PaidLeave_Count = GetSumLeaveType();
        //    CheckBy = "Sick Leave";
        //    SickLeave_Count = GetSumLeaveType();

        //    TotalLeaves = CasualLeave_Count + PaidLeave_Count + SickLeave_Count;

        //    //lblCasualLeave.Text = CasualLeave_Count.ToString();
             
        //    //lblSickLeave.Text = SickLeave_Count.ToString();
        //    //lblTotalLeaves.Text = TotalLeaves.ToString();

        //    //DataSet ds = new DataSet();
        //    //objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
        //    //ds = objQL.SP_LeaveApplication_Get_Leave_Count_By_EmployeeId();

        //    //if (ds.Tables[0].Rows.Count > 0)
        //    //{
        //    //    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0].ToString())))
        //    //        CasualLeave_Count = Convert.ToDouble(ds.Tables[0].Rows[0][0].ToString());
        //    //    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][1].ToString())))
        //    //        PaidLeave_Count = Convert.ToDouble(ds.Tables[0].Rows[0][1].ToString());
        //    //    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][2].ToString())))
        //    //        SickLeave_Count = Convert.ToDouble(ds.Tables[0].Rows[0][2].ToString());
               
        //    //}
        //}

        private bool CheckExist()
        {
            if (!FlagDelete)
            {
                if (!cbRevertLeave.Checked)
                {
                    DataSet ds = new DataSet();
                    objPC.LeaveApplicationId = TableId; // Convert.ToInt32(cmbEmployeeName.SelectedValue);
                    objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                    objPC.FromDate = dtpFromDate.Value;
                    objPC.ToDate = dtpToDate.Value;

                    //objPC.LeaveStatus = BusinessResources.STATUS_DEPARTMENT_HEAD_APPROVED;
                    ds = objQL.SP_LeaveApplication_CheckExist();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0].ToString())))
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
return false;
            }
            else
                return false;
        }
       

        private bool Leave_Validation()
        {
            if (cmbLeaveType.Text != "Special Leave")
            {
                double TLeaves = 0;
                double BCount = objPC.Balance_Count;

                TLeaves = Convert.ToDouble(txtTotalDays.Text);

                double TestLeaves = 0;

                TestLeaves = BCount - TLeaves;

                //double NewBalanceLeaves=

                if (TestLeaves < 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private void SaveDB()
        {
            if (!Validation())
            {
                if (!CheckExist())
                {
                    objPC.LeaveApplicationId = TableId;
                    objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                    objPC.FromDate = dtpFromDate.Value;
                    objPC.ToDate = dtpToDate.Value;
                    objPC.TotalDays = txtTotalDays.Text;
                    objPC.LeaveTypeId = Convert.ToInt32(cmbLeaveType.SelectedValue);
                    objPC.LeaveReason = txtReason.Text;
                    objPC.LeaveStatus = txtLeaveStatus.Text;
                    objPC.DeleteFlag = FlagDelete;
                    objPC.Remarks = txtRemarks.Text;
                    objPC.EntryDate = dtpDate.Value;

                    //if (cbRevertLeave.Checked)
                    //    objPC.IsRevertLeave = 1;
                    //else
                    //    objPC.IsRevertLeave = 0;

                    //if (cmbLeaveType.Text == "Compensation Off")
                    //{
                    //    objPC.IsCompensationOff = 1;
                    //    objPC.CompOffUsedFlag = 0;
                    //}
                    //else if (cmbLeaveType.Text == "Compensation Off Used")
                    //{
                    //    //objPC.IsCompensationOff = 0;
                    //    objPC.CompOffUsedFlag = 1;
                    //    //objPC.UsedCompOffDate = dtpCompOffUsedDate.Value;
                        
                    //}
                    //else
                    //{
                    //    objPC.IsCompensationOff = 0;
                    //    objPC.CompOffUsedFlag = 0;
                    //}

                    //objPC.ReferanceCompOffLeaveApplicationId = ReferanceCompOffLeaveApplicationId;

                    objPC.IsRevertLeave = 0;

                    if (TableId != 0)
                    {
                        if (cbRevertLeave.Checked)
                        {
                            objPC.IsRevertLeave = 1;
                            //objPC.LeaveStatus = BusinessResources.LS_Reject;
                        }
                    }

                    Result = objQL.SP_LeaveApplication_Insert_Update_Delete();
                    
                    if (Result > 0)
                    {
                        if (!FlagDelete)
                            objRL.ShowMessage(7, 1);
                        else
                        {
                            //Get_Leave_Count();
                            
                            objRL.ShowMessage(9, 1);
                        }

                        FillGrid();
                        ClearAll();

                        objPC.SearchFlagLeaveCompOff = false;
                        objRL.Get_Leaves_Count_All();
                        objRL.Fill_Leave_RichTextBox(rtbLeaveRecords);
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
                if(BalanceFlag)
                    objRL.ShowMessage(46, 4);
                else
                    objRL.ShowMessage(17, 4);
                return;
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            FlagDelete = false;
            SaveDB();
        }

        string MainQuery = string.Empty, WhereClauseOther = string.Empty, OrderClause = string.Empty, WhereClause = string.Empty;

        protected void FillGrid()
        {
            DataSet ds = new DataSet();
            MainQuery = string.Empty;  WhereClause = string.Empty; WhereClauseOther = string.Empty; OrderClause = string.Empty;
            dataGridView1.DataSource = null;

            MainQuery = "Select distinct " +
                   "LA.LeaveApplicationId, " +
                   "LA.EntryDate as 'Date', " +
                   "LA.EmployeeId, " +
                   "LM.LocationName, " +
                   "DM.Department, " +
                   "E.EmployeeName as 'Employee Name'," +
                   "DES.Designation," +
                   "LA.FromDate as 'From Date'," +
                   "LA.ToDate as 'To Date'," +
                   "LA.TotalDays as 'Total Days'," +
                   "LT.LeaveTypeFName as 'Leave Type'," +
                   "LA.LeaveReason as 'Leave Reason'," +
                   "LA.LeaveStatus as 'Leave Status'," +
                   "E.TotalLeave," +
                   "LA.LeaveTypeId," +
                   "LA.IsRevertLeave " +
               " from " +
                   " LeaveApplication LA inner join " +
                   " leavetypes LT on LT.LeaveTypeId=LA.LeaveTypeId inner join " +
                   " Employees E on E.EmployeeId=LA.EmployeeId inner join " +
                   " DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
                   " LocationMaster LM on LM.LocationId=E.LocationId inner join " +
                   " DepartmentMaster DM on DM.DepartmentId=E.DepartmentId " +
               " where " +
                   "LA.CancelTag=0 and " +
                   "LT.CancelTag=0 and " +
                   "E.CancelTag=0 and " +
                   "DM.CancelTag=0 and " +
                   "DES.CancelTag=0 and " +
                   "LM.CancelTag=0 ";

           
            
            //ds = objQL.SP_LeaveApplication_FillGrid();
 

            if (BusinessLayer.UserType == "ADMINISTRATOR")
            {
                if (SearchFlag && txtSearch.Text != "")
                    WhereClause = " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";
                else
                    WhereClause = string.Empty;
            }
            else
            {
                WhereClause = " and E.EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + " ";
            }


           // if (SearchFlag && txtSearch.Text != "")
                OrderClause = " order by LA.LeaveApplicationId desc ";
            //
            // OrderClause = " order by LA.LeaveApplicationId desc ";

            //if (BusinessLayer.UserType == "ADMINISTRATOR")
            //{
            //    objBL.Query = BusinessResources.LEAVE_LIST_QUERY + objRL.WhereClasuse_CompOff_Comman() + WhereClause + OrderClause;



            //    //objBL.Query = Query1 + objRL.WhereClasuse_CompOff_Comman() + WhereClause + OrderClause;
            //}
            //else
            //{

            //    //objBL.Query = Query1 + objRL.WhereClasuse_CompOff_Comman() + WhereClause + OrderClause;
            //    objBL.Query = BusinessResources.LEAVE_LIST_QUERY + objRL.WhereClasuse_CompOff_Comman() + WhereClause + OrderClause;
            //}

            objBL.Query = MainQuery + WhereClause + OrderClause;

            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;

                //0 LA.LeaveApplicationId,
                //1 LA.EntryDate
                //2 LA.EmployeeId,
                //3 LM.LocationName,
                //4 DM.Department,
                //5 E.EmployeeName as 'Employee Name',
                //6 DES.Designation,
                //7 LA.FromDate as 'From Date',
                //8 LA.ToDate as 'To Date',
                //9 LA.TotalDays as 'Total Days',
                //10 LA.LeaveType as 'Leave Type',
                //11 LA.LeaveReason as 'Leave Reason',
                //12 LA.LeaveStatus as 'Leave Status',
                //13 E.TotalLeave
                //14 LA.LeaveTypeId,
                //15 LA.IsRevertLeave,
                //16 LA.IsRevertLeave


                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                //dataGridView1.Columns[2].Visible = false;
                //dataGridView1.Columns[10].Visible = false;
                //dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                dataGridView1.Columns[14].Visible = false;
                dataGridView1.Columns[15].Visible = false;
                //dataGridView1.Columns[16].Visible = false;

                //dataGridView1.Columns[15].Visible = false;
                //dataGridView1.Columns[16].Visible = false;
                //dataGridView1.Columns[17].Visible = false;
                //dataGridView1.Columns[18].Visible = false;

                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[3].Width = 100;
                dataGridView1.Columns[4].Width = 100;
                dataGridView1.Columns[5].Width = 180;
                dataGridView1.Columns[6].Width = 150;
                dataGridView1.Columns[7].Width = 80;
                dataGridView1.Columns[8].Width = 80;
                dataGridView1.Columns[9].Width = 80;
                dataGridView1.Columns[11].Width = 80;

                //DEPARTMENT HEAD APPROVED
                //FINAL APPROVED
                //HR APPROVED
                //CANCEL

                //Pending_Count = 0; Approved_Count = 0; HRApproved_Count = 0; Remarks_Count = 0; Cancel_Count = 0;
                Pending_Count = 0; ManagerApproved_Count = 0; HRApproved_Count = 0; Remarks_Count = 0; Reject_Count = 0; Completed_Count = 0;
                string LeaveStatus = string.Empty;int RevertLeaveStatus = 0;
                foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                {
                    LeaveStatus = string.Empty;
                    //Here 2 cell is target value and 1 cell is Volume
                    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells[12].Value)))
                        LeaveStatus = Convert.ToString(Myrow.Cells[12].Value);

                    RevertLeaveStatus = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(Myrow.Cells[15].Value)));


                    //Remark-
                    //Cancel
                    //Remark
                    //Approved
                    //HR Approved

                     if (RevertLeaveStatus == 1) // BusinessResources.LS_Reject)
                    {
                        Reject_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
                    }
                    else if(LeaveStatus == BusinessResources.LS_Pending)
                    {
                        Pending_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_ManagerApproved)
                    {
                        ManagerApproved_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_HRApproved)
                    {
                        HRApproved_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_Remarks)
                    {
                        Remarks_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_Completed)
                    {
                        Completed_Count++;
                        Myrow.DefaultCellStyle.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
                        //Myrow.Cells[0].ReadOnly = true;
                    }
                    else
                    {
                        Myrow.DefaultCellStyle.BackColor = Color.White;
                        //string hex = BusinessResources.BACKGROUND_COLOUR;
                        //Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                        //Myrow.DefaultCellStyle.BackColor = _color;
                    }
                }

                lblPending.Text = BusinessResources.LS_Pending + "-" + Pending_Count.ToString();
                lblManagerApproved.Text = BusinessResources.LS_ManagerApproved + "-" + ManagerApproved_Count.ToString();
                lblHRApproved.Text = BusinessResources.LS_HRApproved + "-" + HRApproved_Count.ToString();
                lblReject.Text = BusinessResources.LS_Reject + "-" + Reject_Count.ToString();
                lblRemark.Text = BusinessResources.LS_Remarks + "-" + Remarks_Count.ToString();
                lblCompleted.Text = BusinessResources.LS_Completed + "-" + Completed_Count.ToString();
                dataGridView1.ClearSelection();
            }
        }

        int Pending_Count = 0, ManagerApproved_Count = 0, HRApproved_Count = 0, Remarks_Count = 0, Reject_Count = 0, Completed_Count = 0;
        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbDepartment.SelectedIndex = -1;
            cmbEmployeeName.SelectedIndex = -1;
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";
            //ReferanceCompOffLeaveApplicationId = 0;

            ClearAll();
            cmbLocation.SelectedIndex = -1;

            objRL.Fill_LeaveType(cmbLeaveType, true);
            objRL.FillLocation(cmbLocation, cmbDepartment);
            FillEmployee_Fixed();
            txtSearch.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = objRL.Delete_Record_Show_Message();

            if (dr == System.Windows.Forms.DialogResult.Yes)
            {
                FlagDelete = true;
                SaveDB();
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            Calculate_LeaveDays();
        }

        private void Calculate_LeaveDays()
        {
            if (dtpToDate.Value < dtpFromDate.Value)
                objRL.ShowMessage(36, 4);
            else
            {
                double TotalDays = (dtpToDate.Value - dtpFromDate.Value).TotalDays;
                TotalDays++;

                TotalDays = Math.Round(TotalDays, 1);
                //if (TotalDays == 0)
                //    TotalDays = 1;
                txtTotalDays.Text = TotalDays.ToString();
            }
        }

        string LeaveStatus = string.Empty;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dataGridView1.Rows.Count;
                CurrentRowIndex = dataGridView1.CurrentRow.Index;
                //cbRevertLeave.Visible = false;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    ClearAll();
                    //cbRevertLeave.Visible = true;

                    //0 LA.LeaveApplicationId,
                    //1 LA.EntryDate
                    //2 LA.EmployeeId,
                    //3 LM.LocationName,
                    //4 DM.Department,
                    //5 E.EmployeeName as 'Employee Name',
                    //6 DES.Designation,
                    //7 LA.FromDate as 'From Date',
                    //8 LA.ToDate as 'To Date',
                    //9 LA.TotalDays as 'Total Days',
                    //10 LA.LeaveType as 'Leave Type',
                    //11 LA.LeaveReason as 'Leave Reason',
                    //12 LA.LeaveStatus as 'Leave Status',
                    //13 E.TotalLeave
                    //14 LA.LeaveTypeId,
                    //15 LA.IsRevertLeave,

                    TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    dtpDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());

                    cmbLocation.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    objRL.FillDepartment(cmbLocation, cmbDepartment);
                    cmbDepartment.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    FillEmployee_Fixed();
                    cmbEmployeeName.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    Fill_EmployeeDetails();
                    dtpFromDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
                    dtpToDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
                    txtTotalDays.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                    cmbLeaveType.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
                    txtReason.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                    txtLeaveStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();

                    LeaveStatus = txtLeaveStatus.Text;
                    //lblBalanceLeave.Text = BalanceLeavePrevious.ToString();// dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                    btnDelete.Enabled = false;
                    gbReply.Enabled = false;

                    if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR) // BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD || BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                    {
                        btnDelete.Enabled = true;
                        gbReply.Enabled = true;
                        cbRevertLeave.Visible = true;

                        objPC.IsRevertLeave = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[15].Value)));

                        if (objPC.IsRevertLeave == 1)
                            cbRevertLeave.Checked = true;
                        else
                            cbRevertLeave.Checked = false;
                    }
                    else
                    {
                        btnDelete.Enabled = false;
                        gbReply.Enabled = false;
                    }

                    //objPC.IsCompensationOff = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[14].Value)));
                   


                    //if (LeaveStatus == BusinessResources.LS_Pending)
                    //{
                    //    txtLeaveStatus.BackColor = Color.Yellow;
                    //}
                    //else if (LeaveStatus == BusinessResources.LS_ManagerApproved)
                    //{
                    //    txtLeaveStatus.BackColor = Color.Lime;
                    //}
                    //else if (LeaveStatus == BusinessResources.LS_HRApproved)
                    //{
                    //    txtLeaveStatus.BackColor = Color.Cyan;
                    //}
                    //else if (LeaveStatus == BusinessResources.LS_Remarks)
                    //{
                    //    txtLeaveStatus.BackColor = Color.Violet;
                    //}
                    //else if (LeaveStatus == BusinessResources.LS_Reject)
                    //{
                    //    txtLeaveStatus.BackColor = Color.Tomato;
                    //}
                    //else
                    //{
                    //    //string hex = BusinessResources.BACKGROUND_COLOUR;
                    //    //Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                    //    //Myrow.DefaultCellStyle.BackColor = _color;
                    //}

                    if (LeaveStatus == BusinessResources.LS_Pending)
                    {
                        txtLeaveStatus.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_ManagerApproved)
                    {
                        txtLeaveStatus.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_HRApproved)
                    {
                        txtLeaveStatus.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_Reject)
                    {
                        txtLeaveStatus.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_Remarks)
                    {
                        txtLeaveStatus.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
                    }
                    else if (LeaveStatus == BusinessResources.LS_Completed)
                    {
                        txtLeaveStatus.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);

                        gbLeaveDetails.Enabled = false;
                        //btnDelete.Enabled = false;
                    }
                    else
                    {
                        txtLeaveStatus.BackColor = Color.White;
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

        private void cmbEmployeeName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_EmployeeDetails();
        }
        
        private void Fill_EmployeeDetails()
        {
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";
            if (cmbEmployeeName.SelectedIndex > -1)
            {
                objPC.SearchFlagLeaveCompOff = false;
                objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                objRL.Fill_EmployeeDetails();
                txtEmployeeCode.Text = objPC.EmployeeCode.ToString();
                txtDesignation.Text = objPC.Designation.ToString();
                objRL.Get_Leaves_Count_All();
                objPC.SearchFlagLeaveCompOff = true;
                objRL.Get_CompOff_Count_All();
                objRL.Fill_Leave_RichTextBox(rtbLeaveRecords);

                if (objPC.Balance_Count <= 0)
                {
                    objRL.ShowMessage(46, 4);
                    return;
                }
            }
        }

        private void txtTotalDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.FloatValue(sender, e, txtTotalDays);
        }

        double TotalDays = 0, BalanceLeave = 0;

        //private void Calculate_BalanceLeave()
        //{
        //    TotalDays = 0; BalanceLeave = 0;

        //    double.TryParse(lblCurrentLeaves.Text, out BalanceLeave);
        //    double.TryParse(txtTotalDays.Text, out TotalDays);

        //    if (TotalDays > BalanceLeave)
        //    {
        //        objRL.ShowMessage(37, 4);
        //        txtTotalDays.Focus();
                 
        //    }
        //}

        private void txtTotalDays_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTotalDays_Leave(object sender, EventArgs e)
        {
            //Calculate_BalanceLeave();
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClearAll();
            //FillDepartment();
            objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillEmployee_Fixed();
            //FillEmployees();
        }

        private void FillEmployee_Fixed()
        {
            //FillEmployees_Combobox();
            ClearAll_Location_Department();

            if (cmbLocation.SelectedIndex > -1 && cmbDepartment.SelectedIndex > -1)
            {
                objQL.WhereClause_V = " and E.LocationId=" + cmbLocation.SelectedValue + "  and E.DepartmentId=" + cmbDepartment.SelectedValue + " and DM.DesignationCategory NOT IN('" + BusinessResources.USER_TYPE_TRAINEE + "')";
                objQL.SP_Employees_Get_By_All(cmbEmployeeName);

                if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
                {
                    cmbEmployeeName.Enabled = false;
                    cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static;
                    //objRL.Fill_EmployeeDetails();
                    Fill_EmployeeDetails();
                }
                else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                {
                    //3,8,17,5076,23,41,19,55,100001,100002
                    //if (BusinessLayer.UserName_Static == "3" || BusinessLayer.UserName_Static == "8" || BusinessLayer.UserName_Static == "17" || BusinessLayer.UserName_Static == "19" || BusinessLayer.UserName_Static == "23" || BusinessLayer.UserName_Static == "41" || BusinessLayer.UserName_Static == "55" || BusinessLayer.UserName_Static == "5076" || BusinessLayer.UserName_Static == "100001" || BusinessLayer.UserName_Static == "100002")
                    //{
                        objQL.SP_Employees_ComboBox_By_Department(cmbEmployeeName);
                        cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static.ToString();
                        cmbEmployeeName.Enabled = false;
                        Fill_EmployeeDetails();
                    //}
                    //BusinessLayer.Designation
                }
                else
                {
                }
                //objRL.FillEmployees();
            }
        }

        
        private void cbRevertLeave_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRevertLeave.Checked)
            {
                objPC.IsRevertLeave = 1;
                cmbLeaveType.Text = "Revert Leave";
                cmbLeaveType.Enabled= false;
            }
            else
            {
                objPC.IsRevertLeave = 0;
                cmbLeaveType.Enabled = false;
            }
        }

        private void cmbLeaveType_SelectionChangeCommitted(object sender, EventArgs e)
        {
             
        }

       
        int num = 0;

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;
         
            FillGrid();
        }
        //private void dgvCompOffList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex < 0)
        //        return;
        //    bool isChecked = (bool)dgvCompOffList.Rows[e.RowIndex].Cells[0].Value;

        //    if(isChecked)
        //    {
        //        num += 1;
        //    }
        //    else
        //    {
        //        num = 0;
        //    }

        //    if (num == 1)
        //    {
        //        lblCompOffUsedDate.Visible = true;
        //        dtpCompOffUsedDate.Visible = true;
        //    }
        //    else
        //    {
        //        lblCompOffUsedDate.Visible = false;
        //        dtpCompOffUsedDate.Visible = false;
        //        //objRL.ShowMessage(40, 4);
        //        //return;
        //    }
             
        //   // lblSelectedCount.Text = "Selected Employee: " + num;
        //}

    }
}
