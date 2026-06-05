using BusinessLayerUtility;
using DocumentFormat.OpenXml.Bibliography;
using SPApplication.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace SPApplication.Transaction
{
    public partial class OutdoorPunchNew : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        AttendanceLogics objAL = new AttendanceLogics();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false, GridFlag=false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0, Pending_Count = 0, HRApproved_Count = 0, InchargeApproved_Count = 0, ManagerApproved_Count = 0, Completed_Count = 0, Remarks_Count = 0, Reject_Count = 0, SelectedCount = 0, LocationId = 0, DepartmentId=0;
        public OutdoorPunchNew()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_OUTDOORENTRIES);

            if (BusinessLayer.Department == "COMPLIANCE" || BusinessLayer.Department == "TIME OFFICE")
            {
                cmbStatus.Enabled = true;
                txtEmployeeName.Enabled = true;
            }
            else
            {
                cmbStatus.Enabled = false;
                txtEmployeeName.Enabled = false;
            }

            objRL.Fill_Shift_ComboBox(cmbShift);
            objRL.Fill_Status_ComboBox(cmbStatus);
        }

        private void ClearAll()
        {
            objEP.Clear();
            GridFlag = false;
            objPC.CompOffApplicationId = 0;

            
            EmployeeId = 0;
            objPC.EmployeeId = 0;

            txtEmployeeName.Text = "";
            rtbEmployee.Text = "";
            lbEmployee.Visible = true;
     
            Fill_Employee_ListBox();

           
             
            cmbStatus.SelectedIndex = -1;
            

            cmbStatus.Text = BusinessResources.LS_Pending;
             
        }

        public void Fill_Employee_ListBox()
        {
            txtEmployeeName.Enabled = false;

            if (BusinessLayer.Department == "COMPLIANCE" || BusinessLayer.Department == "TIME OFFICE")
            {
                txtEmployeeName.Enabled = true;
                txtEmployeeName.Focus();
                lbEmployee.Visible = true;
                objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "All");
            }
            else
            {
                txtEmployeeName.Enabled = false;
                EmployeeId = BusinessLayer.EmployeeLoginId_Static;
                GetEmployeeDetails();
            }
        }
        private void lbEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetEmployeeDetails();
            }
        }

        private void dtpAttendanceDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpInTime_Leave(object sender, EventArgs e)
        {

        }

        private void dtpOutTime_Leave(object sender, EventArgs e)
        {
            Get_Shift_Details();
        }

        private bool ValidationDate()
        {
            DateTime today = DateTime.Today;

            if (dtpInTime.Value.Date >= today)
            {
                MessageBox.Show("In Time date must be greater than today's date.");
                return true;
            }
            else if (dtpOutTime.Value.Date >= today)
            {
                MessageBox.Show("Out Time date must be greater than today's date.");
                return true;
            }
            else if (dtpInTime.Value.Date >= dtpOutTime.Value) 
            {
                MessageBox.Show("Out Time  must be greater than In Time.");
                return true;
            }
            else
                return false;
        }

        private void Get_Shift_Details()
        {
            if(!ValidationDate())
            {
                MainQuery = string.Empty; WhereClause = string.Empty;

                DataTable dt=new DataTable();
                objBL.Query = "select AttendanceLogId,AttendanceDate,EmployeeCode from attendancelogs where CancelTag=0 and EmployeeId=" + EmployeeId + " and AttendanceDate='" + dtpInTime.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) +"' ";
                dt = objBL.ReturnDataTable();
                if(dt.Rows.Count >0)
                {
                    objPC.AttendanceLogId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["AttendanceLogId"])));
                    objPC.AttendanceDate =  Convert.ToDateTime(dt.Rows[0]["AttendanceDate"]);
                    objPC.EmployeeId = EmployeeId;
                }

                //if (cbLeaveForce.Checked)
                //    objPC.IsLeaveForce = 1;
                //else

                objPC.IsLeaveForce = 0;

                objPC.InTime = dtpInTime.Value;
                objPC.OutTime = dtpOutTime.Value;

                objAL.Save_Edit_Attendance();

                //objPC.ShiftId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["ShiftId"])));
                cmbShift.Text = objPC.ShiftFName; // = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["ShiftFName"]));
                dtpShiftInTime.Value = Convert.ToDateTime(objPC.BeginTime); // = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["BeginTime"]));
                dtpShiftOutTime.Value = Convert.ToDateTime(objPC.EndTime);
                txtDuration.Text = objPC.Duration;
                txtTotalDuration.Text = objPC.Duration;
                txtOverTime.Text = objPC.OverTime;
                txtOverTime1.Text = objPC.OverTime;
                txtShiftDuration.Text = objPC.ShiftDuration;
                txtLateBy.Text = objPC.LateBy.ToString();
                txtEarlyBy.Text = objPC.EarlyBy.ToString();
                cmbStatus.Text = objPC.Status;

                //if (objPC.Status == "WOP" || objPC.Status == "P" || objPC.Status == "HD" || objPC.Status == "HP" || objPC.Status == "CO")
                //{
                //    gbOtherEdit.Visible = true;
                //    //gbAttendanceAndOTRemarksReply.Visible = true;
                //    gbOtherEdit.Enabled = true;
                //}
                //else
                //{
                //    gbOtherEdit.Visible = false;
                //    //gbAttendanceAndOTRemarksReply.Visible = false;
                //    gbOtherEdit.Enabled = false;
                //}
            }
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

        private void lbEmployee_Click(object sender, EventArgs e)
        {
            GetEmployeeDetails();
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
                lbEmployee.Visible = false;
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

            //Get_Leaves();
        }

        int EmployeeId = 0;
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
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(objPC.AttendanceLogId >0)
            {
                objBL.Query = "update attendancelogs set IsOutdoorEntry=1,OutdoorApprovalStatusId=1 where AttendanceLogId=" + objPC.AttendanceLogId + " and CancelTag=0";
                Result= objBL.Function_ExecuteNonQuery();

                if(Result>0)
                {
                    objRL.ShowMessage(7, 1);
                    FillGrid();
                }
            }
        }

        private void OutdoorPunchNew_Load(object sender, EventArgs e)
        {
            ClearAll();

            dtpInTime.Format = DateTimePickerFormat.Custom;
            dtpInTime.CustomFormat = "dd/MM/yyyy HH:mm";

            dtpOutTime.Format = DateTimePickerFormat.Custom;
            dtpOutTime.CustomFormat = "dd/MM/yyyy HH:mm";

            FillGrid();
        }

        string  OrderByClause = string.Empty;

        private void FillGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            MainQuery = string.Empty;
            WhereClause = string.Empty;
            OrderByClause = string.Empty;

            WhereClause = " AND AL.EmployeeId =" + EmployeeId + " ";

            MainQuery = "select " +
                  "AL.AttendanceLogId," +
                  "DATE_FORMAT(AL.AttendanceDate, '%d/%m/%Y') AS AttendanceDate," +
                  "AL.LocationId," +
                  "LM.LocationName as 'Location'," +
                  "AL.DepartmentId, " +
                  "DM.Department," +
                  "L.LocationName AS 'Tran Location', " +
                  "D.Department AS 'Tran Department', " +
                  "AL.EmployeeId," +
                  "AL.EmployeeCode as 'Emp Code'," +
                  "E.EmployeeName as 'Employee Name'," +
                  "E.Gender," +
                  "AL.ContractorId," +
                  "CM.ContractorName as 'Roll Name'," +
                  "AL.CategoryId, " +
                  "C.CategoryFName as 'Weekly Off'," +
                  "AL.DesignationId, " +
                  "DES.Designation, " +
                  "AL.JobProfile, " +
                  "AL.ShiftGroupId, " +
                  "AL.OverTimeApplicable, " +
                  "AL.ShiftId, " +
                  "AL.ShiftFName as 'Shift Name'," +
                  "TIME_FORMAT(AL.ShiftBeginTime, '%H:%i') AS 'Shift Begin'," +
                  "TIME_FORMAT(AL.ShiftEndTime, '%H:%i') AS 'Shift End'," +
                  "TIME_FORMAT(SEC_TO_TIME(AL.ShiftDuration * 60), '%H:%i') AS 'Shift Duration'," +
                  "DATE_FORMAT(AL.InTime, '%d/%m/%Y %H:%i') AS 'IN Time', " +
                  "DATE_FORMAT(AL.OutTime, '%d/%m/%Y %H:%i') AS 'Out Time', " +
                  //"AL.InTime AS 'In Time'," +
                  //"AL.OutTime AS 'Out Time'," +
                  "TIME_FORMAT(SEC_TO_TIME(AL.Duration * 60), '%H:%i') AS Duration," +
                  //"TIME_FORMAT(SEC_TO_TIME(AL.OverTime * 60), '%H:%i') AS OT," +
                  //"TIME_FORMAT(SEC_TO_TIME(CEIL(AL.OverTime * 60) * 60), '%H:%i') AS OT,"+
                  //"TIME_FORMAT(SEC_TO_TIME(CEIL(AL.OverTime) * 60), '%H:%i') AS OT,"+
                  "TIME_FORMAT(SEC_TO_TIME(CEIL(TIME_TO_SEC(SEC_TO_TIME(AL.OverTime * 60)) / 3600) * 3600),'%H:%i') AS OT," +
                  "AL.Status, " +
                  "AL.Present, " +
                  "AL.HalfDay, " +
                  "AL.Absent, " +
                  "AL.MissedInPunch, " +
                  "AL.MissedOutPunch, " +
                  "AL.LateBy as 'Late by', " +
                  "AL.EarlyBy as 'Early by', " +
                  "AL.LossOfHours as 'Loss', " +
                  "AL.PunchRecords as 'Punch Records', " +
                  "AL.LeaveTypeId, " +
                  "AL.LeaveType, " +
                  "AL.LeaveDuration, " +
                  "AL.LeaveRemarks, " +
                  "AL.IsCompOff, " +
                  "AL.IsCompOffUsed, " +
                  "AL.CompOffRemarks, " +
                  "AL.CompOffUsedRemarks, " +
                  "AL.IsEditAttendance, " +
                  "AL.IsEditOverwrite, " +
                  "AL.IsLeaveForce, " +
                  "AL.HREditRemarks as 'HR Edit Remarks', " +
                  "AL.InchargeRemarks, " +
                  "AL.ManagerRemarks as 'Manager Remarks', " +
                  "AL.HRReply as 'HR Reply', " +
                  "AL.IsFlexibleHoursFlag, " +
                  "AL.FinancialYearId, " +
                  "AL.IsOutdoorEntry," +
                  "AL.IsRoll, " +
                  "AL.ChangeDepartmentFlag, " +
                  "AL.ChangeLocationtId, " +
                  "AL.ChangeDepartmentId, " +
                  "AL.TransferRemarks, " +
                  "AL.ApprovalStatusId, " +
                  "AL.IsEditOvertime, " +
                  "AL.OvertimePrevious, " +
                  " CASE WHEN AL.OverTimeApplicable = 1 THEN 'Yes' WHEN AL.OverTimeApplicable = 0 THEN 'No' ELSE 'Unknown' END AS 'OT Applicable', " +
                  " CASE " +
                  " WHEN ChangeDepartmentFlag IS NOT NULL " +
                  " AND ChangeDepartmentFlag= 1  " +
                  " THEN  'Transfer' " +
                  " WHEN " + LocationId + " IS NOT NULL AND  " + LocationId + " >0 " +
                          " AND " + DepartmentId + " IS NOT NULL AND  " + DepartmentId + " >0 " +
                          " AND AL.ChangeDepartmentId IS NOT NULL " +
                          " AND AL.ChangeDepartmentId<> AL.DepartmentId " +
                          " AND AL.ChangeLocationtId = " + LocationId + " " +
                          " AND AL.ChangeDepartmentId =" + DepartmentId +
                  " THEN 'Transfer IN' " +
                  " WHEN " + LocationId + " IS NOT NULL AND  " + LocationId + " >0 " +
                         " AND " + DepartmentId + " IS NOT NULL AND  " + DepartmentId + " >0 " +
                          " AND AL.ChangeDepartmentId IS NOT NULL " +
                          " AND AL.ChangeDepartmentId<> AL.DepartmentId " +
                  " THEN 'Transfer OUT' " +
                  " ELSE 'Original' " +
              " END AS TransferDirection," +
              " CASE WHEN AL.ApprovalStatusId = 1 THEN 'Pending' WHEN AL.ApprovalStatusId = 2 THEN 'Completed' WHEN AL.ApprovalStatusId = 3 THEN 'Remarks' WHEN AL.ApprovalStatusId = 6 THEN 'HR Approved' WHEN AL.ApprovalStatusId = 8 THEN 'Manager Approved' ELSE 'Unknown' END AS 'Approval Status' " +
                  " from attendancelogs AL inner join employees E on AL.EmployeeId=E.EmployeeId " +
                  " LEFT JOIN locationmaster L ON L.LocationId = AL.ChangeLocationtId " +
                  " LEFT JOIN departmentmaster D ON D.DepartmentId = AL.ChangeDepartmentId " +
                  " inner join locationmaster LM on LM.LocationId=AL.LocationId " +
                  " inner join departmentmaster DM on DM.DepartmentId=AL.DepartmentId " +
                  " inner join contractormaster CM on CM.ContractorId=AL.ContractorId " +
                  " inner join categories C on C.CategoryId=AL.CategoryId " +
                  " inner join designationmaster DES on DES.DesignationId=AL.DesignationId " +
                  " where AL.CancelTag=0 and E.CancelTag=0 and LM.CancelTag=0 and DM.CancelTag=0 " +
                  " AND AL.IsOutdoorEntry =1 ";

            OrderByClause = " ORDER BY AL.AttendanceDate desc ";
           objBL.Query = MainQuery + WhereClause + OrderByClause;

            DataTable dt=new DataTable();
            dt= objBL.ReturnDataTable();

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;

                // Hide multiple columns
                int[] indexesToHide = { 0, 1, 2, 4, 8, 12, 14, 16, 17, 18, 19, 20, 21, 31, 32, 33, 34, 35, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 52, 55, 56, 57, 58, 59, 60, 61, 63, 64, 65 };

                foreach (int i in indexesToHide)
                {
                    if (i < dataGridView1.Columns.Count)
                    {
                        dataGridView1.Columns[i].Visible = false;
                    }
                }

                dataGridView1.Columns[3].Width = 80;
                dataGridView1.Columns[6].Width = 80;
                dataGridView1.Columns[9].Width = 50;
                dataGridView1.Columns[11].Width = 50;
                dataGridView1.Columns[10].Width = 200;
                dataGridView1.Columns[23].Width = 50;
                dataGridView1.Columns[24].Width = 50;
                dataGridView1.Columns[25].Width = 50;
                dataGridView1.Columns[26].Width = 120;
                dataGridView1.Columns[27].Width = 120;
                dataGridView1.Columns[28].Width = 50;
                dataGridView1.Columns[29].Width = 50;
                dataGridView1.Columns[30].Width = 50;
                dataGridView1.Columns[35].Width = 40;
                dataGridView1.Columns[36].Width = 40;
                dataGridView1.Columns[37].Width = 40;
                dataGridView1.Columns[38].Width = 40;
                //dataGridView1.Columns[39].Width = 100;

                dataGridView1.Columns[29].Width = 50;

                dataGridView1.Columns[0].ReadOnly = false;
            }
            //AllCountQuery = "select Count(*) from attendancelogs where CancelTag=0 and " +
            //                  " AttendanceDate='" + AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' " +
            //                  " AND(LocationId = " + LocationId + " OR " + LocationId + " = 0) AND(DepartmentId = " + DepartmentId + " OR " + DepartmentId + " = 0)";

        }

        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;
        string MainQuery = string.Empty;
        string WhereClause = string.Empty;

        double WorkDurationCal = 0, OverTime_Cal = 0;
        int SearchId = 0;


       
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
