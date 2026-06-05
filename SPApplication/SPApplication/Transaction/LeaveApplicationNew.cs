using BusinessLayerUtility;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Math;
using Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;
using SPApplication.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace SPApplication.Transaction
{
    public partial class LeaveApplicationNew : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        string MainQuery = string.Empty, WhereClauseOther = string.Empty, OrderClause = string.Empty, WhereClause = string.Empty;

        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;
        bool GridFlag = false;int EmployeeId = 0;

        int SearchId = 0, LocationId = 0;
        public LeaveApplicationNew()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_LEAVEAPPLICATION);
            //ClearAll();
            //objQL.Fill_Master_ComboBox(cmbLeaveType, "leavetypes");
            objRL.Fill_LeaveType(cmbLeaveType, true);
            //objRL.FillLocation(cmbLocation, cmbDepartment);
            //FillEmployee_Fixed();
            objRL.Fill_Approval_Status(cmbStatus);

            if (BusinessLayer.Department == "TIME OFFICE" || BusinessLayer.Department == "TIME OFFICE")
                cmbStatus.Enabled = true;
            else
                cmbStatus.Enabled = false;
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            if (!GridFlag)
            {
                EmployeeId = 0;
                rtbEmployee.Text = "";
            }

            if (!string.IsNullOrWhiteSpace(Convert.ToString(txtEmployeeName.Text)))
                objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "Text");
            else
                objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "All");
        }

        private void GetEmployeeDetails()
        {
            rtbEmployee.Text = "";
            if (EmployeeId == 0)
            {
                if (lbEmployee.SelectedIndex > -1)
                {
                    EmployeeId = 0;
                    EmployeeId = Convert.ToInt32(lbEmployee.SelectedValue);
                    objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
                    lbEmployee.Visible = false;
                    dtpDate.Focus();
                }
            }
            else if (GridFlag && EmployeeId != 0)
            {
                objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
            }
            else if (BusinessLayer.Department != "Time Office" && EmployeeId != 0)
            {
                objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
                lbEmployee.Visible = false;
            }
            else
            {
                rtbEmployee.Text = "";
                rtbEmployee.Visible = true;
                lbEmployee.Visible = true;
            }

            Get_Leaves();
        }

        private void Get_Leaves()
        {
            if(EmployeeId>0)
            {
                objPC.EmployeeId = EmployeeId;
                objRL.Fill_EmployeeDetails();
                //txtEmployeeCode.Text = objPC.EmployeeCode.ToString();
                //txtDesignation.Text = objPC.Designation.ToString();
                objRL.Get_Leaves_Count_All();
                objPC.SearchFlagLeaveCompOff = true;
                objRL.Get_CompOff_Count_All();
                objRL.Fill_Leave_RichTextBox(rtbLeaveRecords);
                gbLeaveDetails.Visible = true;
                //LoadDates();
            }
        }

        private void ClearAll()
        {
            objEP.Clear();
            EmployeeId = 0;
            objPC.EmployeeId = 0;
            txtEmployeeName.Text = "";
            rtbEmployee.Text = "";
            lbEmployee.Visible = true;
            //objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "All");
            gbLeaveDetails.Visible = false;
            Fill_Employee_ListBox();

            dtpLeaveDate.Value = DateTime.Now.Date;
            cmbLeaveType.SelectedIndex = -1;
            txtLeaveReason.Text = "";
            txtLeaveRemarks.Text = "";
            rtbLeaveRecords.Text = "";
        }

        private void txtEmployeeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtEmployeeName.Text != "" && lbEmployee.Items.Count > 0)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                {
                    lbEmployee.SelectedIndex = 0;
                    lbEmployee.Focus();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FlagDelete = false;
            SaveDB();
        }

        private bool Leave_Validation()
        {
            if (cmbLeaveType.Text != "Special Leave")
            {
                double TLeaves = 0;
                double BCount = objPC.Balance_Count;

                //TLeaves = Convert.ToDouble(txtTotalDays.Text);

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

        bool BalanceFlag = false;
        private bool Validation()
        {
            BalanceFlag = false;
            objEP.Clear();
            if (Leave_Validation())
            {
                BalanceFlag = true;
                return true;
            }
            else if (objPC.Balance_Count <= 0 && cmbLeaveType.Text != "Revert Leave" && cmbLeaveType.Text != "Special Leave")
            {
                BalanceFlag = true;
                return true;
            }
            else if (EmployeeId == 0)
            {
                txtEmployeeName.Focus();
                objEP.SetError(txtEmployeeName, "Select Employee Name");
                return true;
            }
            else if (cmbLeaveType.SelectedIndex ==-1)
            {
                cmbLeaveType.Focus();
                objEP.SetError(cmbLeaveType, "Enter Leave Type");
                return true;
            }
            else if (txtLeaveReason.Text == "")
            {
                txtLeaveReason.Focus();
                objEP.SetError(txtLeaveReason, "Enter Reason of Leave");
                return true;
            }
            else
                return false;
        }

        string LeaveStaus = string.Empty;
        private void SaveDB()
        {
            if (!Validation())
            {
                objPC.LeaveApplicationId = TableId;
                objPC.EmployeeId = EmployeeId;
                objPC.LeaveDate = dtpLeaveDate.Value;
                objPC.LeaveTypeId = Convert.ToInt32(cmbLeaveType.SelectedValue);
                objPC.LeaveReason = txtLeaveReason.Text;
                objPC.LeaveStatus = LeaveStaus;
                objPC.DeleteFlag = FlagDelete;
                objPC.Remarks = txtLeaveRemarks.Text;
                objPC.IsRevertLeave = 0;

                if(TableId ==0)
                {
                    cmbStatus.Text = "Pending";
                    objBL.Query = "insert into leaveapplication(EmployeeId,LeaveDate,LeaveTypeId,LeaveReason,LeaveRemarks,ApprovalStatusId,FinancialYearId,UserId) values(" + EmployeeId + ",'" + dtpLeaveDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'," + cmbLeaveType.SelectedValue + ",'" + txtLeaveReason.Text + "','" + txtLeaveRemarks.Text + "',"+cmbStatus.SelectedValue+"," + objPC.FinancialYearId + "," + BusinessLayer.UserName_Static + ")";
                }
                    
                else
                {
                    if(!FlagDelete)
                        objBL.Query = "update leaveapplication set EmployeeId=" + EmployeeId + ",LeaveDate='" + dtpLeaveDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "',LeaveTypeId=" + cmbLeaveType.SelectedValue + ",LeaveReason='" + txtLeaveReason.Text + "',LeaveRemarks='" + txtLeaveRemarks.Text + "',LeaveStatus=" + cmbStatus.SelectedValue + ",FinancialYearId=" + objPC.FinancialYearId + ",ModifiedUserId=" + BusinessLayer.UserName_Static + " where LeaveApplicationId=" + TableId + "";
                    else
                        objBL.Query = "update leaveapplication set CancelTag=1,ModifiedUserId="+   BusinessLayer.UserName_Static + " where LeaveApplicationId=" + TableId + "";
                }
                    

                Result = objBL.Function_ExecuteNonQuery();

               // Result = objQL.SP_LeaveApplication_Insert_Update_Delete();

                if (Result > 0)
                {
                    if (!FlagDelete)
                        objRL.ShowMessage(7, 1);
                    else
                    {
                        //Get_Leave_Count();

                        objRL.ShowMessage(9, 1);

                        if(FlagDelete)
                        {
                            
                        }
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
                if (BalanceFlag)
                    objRL.ShowMessage(46, 4);
                else
                    objRL.ShowMessage(17, 4);
                return;
            }
        }
       protected void FillGrid()
       {
            DataSet ds = new DataSet();
            MainQuery = string.Empty; WhereClause = string.Empty; WhereClauseOther = string.Empty; OrderClause = string.Empty;
            dataGridView1.DataSource = null;

            MainQuery = "Select distinct " +
                   "LA.LeaveApplicationId, " +
                   "LA.EmployeeId, " +
                   "LM.LocationName, " +
                   "DM.Department, " +
                   "E.EmployeeName as 'Employee Name'," +
                   "DES.Designation," +
                   "LA.LeaveDate as 'Leave Date'," +
                   "LT.LeaveTypeFName as 'Leave Type'," +
                   "LA.LeaveReason as 'Leave Reason'," +
                   "LA.LeaveRemarks as 'Leave Remarks'," +
                   " CASE WHEN LA.ApprovalStatusId = 1 THEN 'Pending' WHEN LA.ApprovalStatusId = 2 THEN 'Completed' WHEN LA.ApprovalStatusId = 3 THEN 'Remarks' WHEN LA.ApprovalStatusId = 6 THEN 'HR Approved' WHEN LA.ApprovalStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Status', " +
                   "LA.IsRevertLeave, " +
                   "LA.ApprovalStatusId "+
               " from " +
                   " leaveapplication LA inner join " +
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

            if (BusinessLayer.UserType == "ADMINISTRATOR")
            {
                if (SearchFlag && txtSearch.Text != "")
                    WhereClause += " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";
                else
                    WhereClause += string.Empty;
            }
            else
                WhereClause = " and E.EmployeeId=" + BusinessLayer.EmployeeLoginId_Static + " ";

            WhereClause += " and LA.FinancialYearId=" + objPC.FinancialYearId + " ";

            OrderClause = " order by LA.LeaveApplicationId desc ";
             
            objBL.Query = MainQuery + WhereClause + OrderClause;

            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total-" + ds.Tables[0].Rows.Count;

                //0	  LA.LeaveApplicationId,  +
                //1   LA.EmployeeId,  +
                //2   LM.LocationName,  +
                //3   DM.Department,  +
                //4   E.EmployeeName as 'Employee Name', +
                //5   DES.Designation, +
                //6   LA.LeaveDate as 'Leave Date', +
                //7   LT.LeaveTypeFName as 'Leave Type', +
                //8   LA.LeaveReason as 'Leave Reason', +
                //9   LA.LeaveRemarks as 'Leave Remarks', +
                //10   CASE WHEN LA.ApprovalStatusId = 1 THEN 'Pending' WHEN LA.ApprovalStatusId = 2 THEN 'Completed' WHEN LA.ApprovalStatusId = 3 THEN 'Remarks' WHEN LA.ApprovalStatusId = 6 THEN 'HR Approved' WHEN LA.ApprovalStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Status',  +
                //11  LA.IsRevertLeave,  +
                //12  LA.ApprovalStatusId +



                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
               
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                
                dataGridView1.Columns[2].Width = 80;
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[4].Width = 200;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;
                dataGridView1.Columns[7].Width = 80;
                dataGridView1.Columns[8].Width = 150;
                dataGridView1.Columns[9].Width = 150;
                dataGridView1.Columns[11].Width = 80;

                objRL.Set_Approval_Colour_DataGridView(dataGridView1, lblPending, lblHRApproved, lblManagerApproved, lblRemark, lblCompleted, "ApprovalStatusId");
                
                dataGridView1.ClearSelection();
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
                    
                    //0	  LA.LeaveApplicationId,  +
                    //1   LA.EmployeeId,  +
                    //2   LM.LocationName,  +
                    //3   DM.Department,  +
                    //4   E.EmployeeName as 'Employee Name', +
                    //5   DES.Designation, +
                    //6   LA.LeaveDate as 'Leave Date', +
                    //7   LT.LeaveTypeFName as 'Leave Type', +
                    //8   LA.LeaveReason as 'Leave Reason', +
                    //9   LA.LeaveRemarks as 'Leave Remarks', +
                    //10   CASE WHEN LA.ApprovalStatusId = 1 THEN 'Pending' WHEN LA.ApprovalStatusId = 2 THEN 'Completed' WHEN LA.ApprovalStatusId = 3 THEN 'Remarks' WHEN LA.ApprovalStatusId = 6 THEN 'HR Approved' WHEN LA.ApprovalStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Status',  +
                    //11  LA.IsRevertLeave,  +
                    //12  LA.ApprovalStatusId +

                    TableId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value)));
                    GetEmployeeDetails();
                    dtpLeaveDate.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                    cmbLeaveType.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[7].Value));
                    txtLeaveReason.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[8].Value));
                    txtLeaveRemarks.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[9].Value));
                    cmbStatus.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[10].Value));

                    if (cmbStatus.Text == BusinessResources.LS_Completed && BusinessLayer.Department == "TIME OFFICE")
                        btnDelete.Visible = true;
                    else
                        btnDelete.Visible = false;
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FlagDelete = true;
            SaveDB();
        }

        private void lbEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetEmployeeDetails();
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            objPC.LeaveDate = dtpLeaveDate.Value;
            int Result = objQL.Check_Leave_Date_Valid();

            if (Result > 0)
            {
                objRL.ShowMessage(54, 4);
                dtpLeaveDate.Value = DateTime.Now.Date;
                return;
            }
            lblAttendanceDay.Text = "Day-" + Convert.ToString(dtpLeaveDate.Value.Date.DayOfWeek);
        }

        private void lbEmployee_Click(object sender, EventArgs e)
        {
            GetEmployeeDetails();
        }
        public void Fill_Employee_ListBox()
        {
            txtLeaveRemarks.Enabled = false;
            //BusinessLayer.EmployeeLoginId_Static
            //if (BusinessLayer.UserType == "ADMINISTRATOR" && BusinessLayer.Department == "COMPLIANCE" || BusinessLayer.Department == "TIME OFFICE"  )
            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
            {
                txtEmployeeName.Enabled = true;
                txtLeaveRemarks.Enabled = true;
                txtEmployeeName.Focus();
                lbEmployee.Visible = true;
                objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "All");
            }
            else
            {
                txtEmployeeName.Enabled = false;
                txtLeaveRemarks.Enabled = false;
                EmployeeId = BusinessLayer.EmployeeLoginId_Static;
                GetEmployeeDetails();
            }
        }

        private void LeaveApplicationNew_Load(object sender, EventArgs e)
        {
            ClearAll();
            FillGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    //    private bool Check_Leave_Date_Valid()
    //    {
    ////        string QueryString = " SELECT " +
    ////" CASE " +
    ////    " WHEN  " +
    ////        " DAYNAME('" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "') NOT IN(  " +
    ////            " SELECT C.CategoryFName  " +
    ////            " FROM categories C  " +
    ////            " INNER JOIN employees e  " +
    ////                " ON e.CategoryId = C.CategoryId  " +
    ////            " WHERE e.EmployeeId = " + EmployeeId + "   " +
    ////        " ) " +
    ////        " AND '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' NOT IN( " +
    ////            " SELECT HolidayDate " +
    ////            " FROM holidaymaster " +
    ////        " ) " +
    ////    " THEN 1 " +
    ////    " ELSE 0 " +
    ////" END AS CheckValid ";

    ////        try
    ////        {
    ////            //conn.Open();
    ////            MySqlCommand cmd = new MySqlCommand(QueryString, objBL.objCon);
    ////            MySqlDataReader reader = cmd.ExecuteReader();

    ////            clbDates.Items.Clear();

    ////            while (reader.Read())
    ////            {
    ////            }
    ////        }
    ////        catch (Exception ex)
    ////        {
    ////            MessageBox.Show(ex.Message);
    ////        }
    //    }



private void LoadDates()
        {
            string fromDate = "2026-01-01", toDate = "2026-12-31"; ;

            string QueryString = string.Empty;

            QueryString = 
                        "WITH RECURSIVE all_dates AS (  "+
                             " SELECT DATE('" + fromDate + "') AS dt " +
                            "  UNION ALL " +
                             " SELECT dt + INTERVAL 1 DAY " +
                             " FROM all_dates " +
                             " WHERE dt < '" + toDate+"'  "+
                         " ) " +
                         " SELECT dt, DAYNAME(dt) AS day_name " +
                         " FROM all_dates " +
                         " WHERE  " +
                             " DAYNAME(dt) NOT IN( " +
                                 " SELECT C.CategoryFName  " +
                                 " FROM categories C  " +
                                 " INNER JOIN employees e  " +
                                    "  ON e.CategoryId = C.CategoryId  " +
                                 " WHERE e.EmployeeId = " + EmployeeId+"  "+
                            "  ) " +
                             " AND dt NOT IN( " +
                                "  SELECT HolidayDate  " +
                                 " FROM holidaymaster " +
                           " ) ";

            objBL.Connect();
            //using (MySqlConnection conn = new MySqlConnection(objBL.conString))
            //{
                try
                {
                    //conn.Open();
                    MySqlCommand cmd = new MySqlCommand(QueryString, objBL.objCon);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    clbDates.Items.Clear();

                    while (reader.Read())
                    {
                        DateTime dt = reader.GetDateTime("dt");
                        string day = reader.GetString("day_name");

                        // Format display text
                        string display = dt.ToString("yyyy-MM-dd") + " (" + day + ")";

                        clbDates.Items.Add(display, false); // unchecked by default
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            //}
        }
    }
     
}
