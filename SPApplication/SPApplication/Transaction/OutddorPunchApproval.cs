using BusinessLayerUtility;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using MySql.Data.MySqlClient;
using OfficeOpenXml.Style;
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
    public partial class OutddorPunchApproval : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();

        PropertyClass objPC = new PropertyClass();
        AttendanceLogics objAL = new AttendanceLogics();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false, ChangeFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0, LocationId = 0;

        string SName = string.Empty;

        int SrNo = 1;
        string MainQuery = string.Empty, WhereClause = string.Empty, WhereClause_Other = string.Empty, OrderByClause = string.Empty;
        DateTime dtInTime, dtOutTime;
        TimeSpan TOT;

        public OutddorPunchApproval()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, "Outdoor Approval");
            btnDelete.Text = BusinessResources.BTN_VIEW;

            objRL.FillLocation(cmbLocation, cmbDepartment);
            objRL.Fill_Approval_Status(cmbApprovalStatus);

            Fill_Data();
            ClearAll();

            objDL.Set_Approval_Colour(lblPending);
            objDL.Set_Approval_Colour(lblHRApproved);
            objDL.Set_Approval_Colour(lblManagerApproved);
            objDL.Set_Approval_Colour(lblRemark);
            objDL.Set_Approval_Colour(lblCompleted);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dgvAttendanceStatus.DataSource = null;
            dgvTransferIN.DataSource = null;
            dgvTransferOut.DataSource = null;
            ChangeFlag = false;

            if (!Validation())
            {

                //Fill_Grid_AttendanceRecord();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                FillGrid();
            }
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillDepartment();
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (cbSelectAll.Checked)
                    {
                        dataGridView1.Rows[i].Cells["clmSelectAll"].Value = true;
                        pSave.Visible = true;
                    }
                        
                    else
                        dataGridView1.Rows[i].Cells["clmSelectAll"].Value = false;
                }
            }
        }

        private bool ValidationMain()
        {
            bool RetrunFlag = false;
            objEP.Clear();


            //if (cmbLocation.SelectedIndex == -1)
            //{
            //    cmbLocation.Focus();
            //    objEP.SetError(cmbLocation, "Select Location");
            //    RetrunFlag = true;
            //}
            //else
            //    RetrunFlag = false;

            //if (!RetrunFlag)
            //{

            //    if (cmbDepartment.SelectedIndex == -1)
            //    {
            //        cmbDepartment.Focus();
            //        objEP.SetError(cmbDepartment, "Select Department");
            //        RetrunFlag = true;
            //    }
            //    else
            //        RetrunFlag = false;

            //}

            if (!RetrunFlag)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    bool isChecked = (bool)dataGridView1.Rows[i].Cells[0].Value;

                    // int ID= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmAttendanceRecordId"].Value);
                    if (isChecked)
                    {
                        RetrunFlag = false;
                        break;
                    }
                    else
                        RetrunFlag = true;
                }
            }
            if (!RetrunFlag)
            {
                if (cmbApprovalStatus.SelectedIndex == -1)
                {
                    cmbApprovalStatus.Focus();
                    objEP.SetError(cmbApprovalStatus, "Select Status");
                    RetrunFlag = true;
                }
                else if (cmbApprovalStatus.Text == "Remarks")
                {
                    if (txtRemarks.Text == "")
                    {
                        txtRemarks.Focus();
                        objEP.SetError(txtRemarks, "Enter Remarks");
                        RetrunFlag = true;
                    }
                    else
                        RetrunFlag = false;
                }
                else
                    RetrunFlag = false;
            }
            if (!RetrunFlag)
            {
                if (SName == "Completed" || SName == "Pending")
                {
                    //lblStatusValue.Focus();
                    //objEP.SetError(lblStatusValue, "Status is not valid");

                    objRL.ShowMessage(51, 4);
                    RetrunFlag = true;
                }
                else
                    RetrunFlag = false;
            }
            return RetrunFlag;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidationMain())
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    bool isChecked = (bool)dataGridView1.Rows[i].Cells[0].Value;

                    if (isChecked)
                    {
                        int AttendanceLogId = 0, Result = 0;
                        AttendanceLogId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value)));


                        //AttendanceLogId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells[1].Value)));


                        //objBL.Query = "update attendancerecord set OTApprovalFlag=1,OTApprovalStatus='" + cmbAttendanceStatus.Text + "',OTRemarks='" + txtRemarks.Text + "' where AttendanceRecordId=" + AttendanceRecordId + "";
                        objBL.Query = "update attendancelogs set OutdoorApprovalStatusId=" + cmbApprovalStatus.SelectedValue + ",ManagerRemarks='" + txtRemarks.Text + "' where AttendanceLogId=" + AttendanceLogId + "";
                        Result = objBL.Function_ExecuteNonQuery();

                        int CompleteFlag = 0, OTApprovalFlag = 0;

                        if (cmbApprovalStatus.Text == BusinessResources.LS_Completed)
                            CompleteFlag = 1;
                        else
                            CompleteFlag = 0;

                        if (cmbApprovalStatus.Text == BusinessResources.LS_ManagerApproved)
                            OTApprovalFlag = 1;
                        else
                            OTApprovalFlag = 0;

                        ////objBL.Query = "update attendancerecordmaster set ApprovalStatusId="+cmbAttendanceStatus.SelectedValue+ ",CompleteFlag="+ CompleteFlag + ", OTApprovalFlag=" + OTApprovalFlag + " where AttendanceDate='" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
                        //objBL.Query = "update attendancerecordmaster set OutdoorApprovalStatusId=" + cmbApprovalStatus.SelectedValue + ",CompleteFlag=" + CompleteFlag + " where AttendanceDate='" + dtpAttenanceDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and LocationId=" + cmbLocation.SelectedValue + " and DepartmentId=" + cmbDepartment.SelectedValue + "";
                        //Result = objBL.Function_ExecuteNonQuery();

                    }
                }

                objRL.ShowMessage(7, 1);
                cmbApprovalStatus.SelectedIndex = -1;
                txtRemarks.Text = "";
                //return;
            }
        }

        private void FillDepartment()
        {
            if (cmbLocation.SelectedIndex > -1)
                objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private bool Validation()
        {
            bool RetrunFlag = false;
            objEP.Clear();


            //if (cmbLocation.SelectedIndex == -1)
            //{
            //    cmbLocation.Focus();
            //    objEP.SetError(cmbLocation, "Select Location");
            //    RetrunFlag = true;
            //}
            //else
            //    RetrunFlag = false;

            //if (!RetrunFlag)
            //{
            //    if (cmbDepartment.SelectedIndex == -1)
            //    {
            //        cmbDepartment.Focus();
            //        objEP.SetError(cmbDepartment, "Select Department");
            //        RetrunFlag = true;
            //    }
            //    else
            //        RetrunFlag = false;
            //}
            if (!RetrunFlag)
            {
                if (!CheckedAttendanceStatus())
                    RetrunFlag = false;
                else
                {
                    RetrunFlag = true;
                    objRL.ShowMessage(53, 4);

                }
            }
            return RetrunFlag;
        }

        private bool CheckedAttendanceStatus()
        {
            bool RetrunFlag = false;
            int StatusCheck = 0;

            System.Data.DataTable dt = new System.Data.DataTable();
            //objBL.Query = "select * FROM attendancelogs where CancelTag=0 and AttendanceDate='" + dtpAttenanceDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

            //objBL.Query = " SELECT "+
            //              " CASE "+
            //                " WHEN COUNT(*) = SUM(ApprovalStatusId = 6) " +
            //                " THEN 1 " +    //THEN 'ALL APPROVED'
            //                " ELSE 0 " +    // ELSE 'NOT ALL APPROVED'
            //                " END AS StatusCheck  " +
            //            " FROM attendancelogs " +
            //            " WHERE CancelTag = 0 " +
            //            " AND CancelTag=0 and LocationId=" + cmbLocation.SelectedValue + " AND DepartmentId=" + cmbDepartment.SelectedValue + " AND AttendanceDate = '" + dtpAttenanceDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

            objBL.Query = " SELECT " +
            " CASE " +
                " WHEN SUM(ApprovalStatusId = 1) > 0 THEN 1 " +
                " WHEN COUNT(*) = SUM(ApprovalStatusId IN(2, 3, 6, 8)) THEN 0 " +
                " ELSE 0 " +
              " END AS StatusCheck " +
            " FROM attendancelogs " +
            " WHERE CancelTag = 0 " +
            " AND CancelTag=0 and LocationId=" + cmbLocation.SelectedValue + " AND DepartmentId=" + cmbDepartment.SelectedValue + " AND AttendanceDate = '" + dtpAttenanceDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

            dt = objBL.ReturnDataTable();
            if (dt.Rows.Count > 0)
            {
                StatusCheck = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["StatusCheck"])));

                if (StatusCheck == 1)
                    RetrunFlag = true;
                else
                    RetrunFlag = false;
            }
            return RetrunFlag;
        }

        TimeSpan totalOT = TimeSpan.Zero;
        TimeSpan totalDuration = TimeSpan.Zero;
        int DepartmentId = 0;

        private void FillGrid()
        {
            LocationId = 0;
            DepartmentId = 0;
            totalOT = TimeSpan.Zero;
            totalDuration = TimeSpan.Zero;

            lblTransferCount.Text = "";
            lblTotalCount.Text = "";

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            System.Data.DataTable dt = new System.Data.DataTable();

            MainQuery = string.Empty;
            WhereClause = string.Empty;
            OrderByClause = string.Empty;

            //MainQuery = objPC.AttendanceLogsQuery;

            if (cmbLocation.SelectedIndex > -1)
            {
                LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                //WhereClause = " and AL.LocationId=" + LocationId + "";
            }
            if (cmbLocation.SelectedIndex > -1 && cmbDepartment.SelectedIndex > -1)
            {
                DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                // WhereClause += " and AL.DepartmentId=" + DepartmentId + "";
            }

            if (LocationId > 0 && DepartmentId > 0)
            {
                //WhereClause += " AND(AL.LocationId = " + LocationId + " OR AL.ChangeLocationtId = " + LocationId + " AND AL.DepartmentId = " + DepartmentId + " OR AL.ChangeDepartmentId = " + DepartmentId + ") ";
                WhereClause += " AND((AL.LocationId = " + LocationId + " AND AL.DepartmentId = " + DepartmentId + ") " +
                               " OR(AL.ChangeLocationtId = " + LocationId + " AND AL.ChangeDepartmentId = " + DepartmentId + ")) ";
            }

            //MainQuery = "select " +
            //            "AL.AttendanceLogId," +
            //            "DATE_FORMAT(AL.AttendanceDate, '%d/%m/%Y') AS AttendanceDate," +
            //            "AL.LocationId," +
            //            "LM.LocationName as 'Location'," +
            //            "AL.DepartmentId, " +
            //            "DM.Department," +
            //            "L.LocationName AS 'Tran Location', " +
            //            "D.Department AS 'Tran Department', " +
            //            "AL.EmployeeId," +
            //            "AL.EmployeeCode as 'Emp Code'," +
            //            "E.EmployeeName as 'Employee Name'," +
            //            "E.Gender," +
            //            "AL.ContractorId," +
            //            "CM.ContractorName as 'Roll Name'," +
            //            "AL.CategoryId, " +
            //            "C.CategoryFName as 'Weekly Off'," +
            //            "AL.DesignationId, " +
            //            "DES.Designation, " +
            //            "AL.JobProfile, " +
            //            "AL.ShiftGroupId, " +
            //            "AL.OverTimeApplicable, " +
            //            "AL.ShiftId, " +
            //            "AL.ShiftFName as 'Shift Name'," +
            //            "TIME_FORMAT(AL.ShiftBeginTime, '%H:%i') AS 'Shift Begin'," +
            //            "TIME_FORMAT(AL.ShiftEndTime, '%H:%i') AS 'Shift End'," +
            //            "TIME_FORMAT(SEC_TO_TIME(AL.ShiftDuration * 60), '%H:%i') AS 'Shift Duration'," +
            //            "DATE_FORMAT(AL.InTime, '%d/%m/%Y %H:%i') AS 'IN Time', " +
            //            "DATE_FORMAT(AL.OutTime, '%d/%m/%Y %H:%i') AS 'Out Time', " +
            //            //"AL.InTime AS 'In Time'," +
            //            //"AL.OutTime AS 'Out Time'," +
            //            "TIME_FORMAT(SEC_TO_TIME(AL.Duration * 60), '%H:%i') AS Duration," +
            //            //"TIME_FORMAT(SEC_TO_TIME(AL.OverTime * 60), '%H:%i') AS OT," +
            //            //"TIME_FORMAT(SEC_TO_TIME(CEIL(AL.OverTime * 60) * 60), '%H:%i') AS OT,"+
            //            //"TIME_FORMAT(SEC_TO_TIME(CEIL(AL.OverTime) * 60), '%H:%i') AS OT,"+
            //            "TIME_FORMAT(SEC_TO_TIME(CEIL(TIME_TO_SEC(SEC_TO_TIME(AL.OverTime * 60)) / 3600) * 3600),'%H:%i') AS OT," +
            //            "AL.Status, " +
            //            "AL.Present, " +
            //            "AL.HalfDay, " +
            //            "AL.Absent, " +
            //            "AL.MissedInPunch, " +
            //            "AL.MissedOutPunch, " +
            //            "AL.LateBy as 'Late by', " +
            //            "AL.EarlyBy as 'Early by', " +
            //            "AL.LossOfHours as 'Loss', " +
            //            "AL.PunchRecords as 'Punch Records', " +
            //            "AL.LeaveTypeId, " +
            //            "AL.LeaveType, " +
            //            "AL.LeaveDuration, " +
            //            "AL.LeaveRemarks, " +
            //            "AL.IsCompOff, " +
            //            "AL.IsCompOffUsed, " +
            //            "AL.CompOffRemarks, " +
            //            "AL.CompOffUsedRemarks, " +
            //            "AL.IsEditAttendance, " +
            //            "AL.IsEditOverwrite, " +
            //            "AL.IsLeaveForce, " +
            //            "AL.HREditRemarks as 'HR Edit Remarks', " +
            //            "AL.InchargeRemarks, " +
            //            "AL.ManagerRemarks as 'Manager Remarks', " +
            //            "AL.HRReply as 'HR Reply', " +
            //            "AL.IsFlexibleHoursFlag, " +
            //            "AL.FinancialYearId, " +
            //            "AL.IsOutdoorEntry," +
            //            "AL.IsRoll, " +
            //            "AL.ChangeDepartmentFlag, " +
            //            "AL.ChangeLocationtId, " +
            //            "AL.ChangeDepartmentId, " +
            //            "AL.TransferRemarks, " +
            //            "AL.ApprovalStatusId, " +
            //            "AL.IsEditOvertime, " +
            //            "AL.OvertimePrevious, " +
            //            " CASE WHEN AL.OverTimeApplicable = 1 THEN 'Yes' WHEN AL.OverTimeApplicable = 0 THEN 'No' ELSE 'Unknown' END AS 'OT Applicable', " +
            //            " CASE " +
            //            " WHEN ChangeDepartmentFlag IS NOT NULL " +
            //            " AND ChangeDepartmentFlag= 1  " +
            //            " THEN  'Transfer' " +
            //            " WHEN "+LocationId+" IS NOT NULL AND  "+LocationId+" >0 " +
            //                    " AND " + DepartmentId +" IS NOT NULL AND  " + DepartmentId + " >0 " +
            //                    " AND AL.ChangeDepartmentId IS NOT NULL " +
            //                    " AND AL.ChangeDepartmentId<> AL.DepartmentId " +
            //                    " AND AL.ChangeLocationtId = "+LocationId+" " +
            //                    " AND AL.ChangeDepartmentId =" + DepartmentId  +
            //            " THEN 'Transfer IN' " +
            //            " WHEN "+LocationId+ " IS NOT NULL AND  " + LocationId + " >0 " +
            //                   " AND " + DepartmentId + " IS NOT NULL AND  " + DepartmentId + " >0 " +
            //                    " AND AL.ChangeDepartmentId IS NOT NULL " +
            //                    " AND AL.ChangeDepartmentId<> AL.DepartmentId " +
            //            " THEN 'Transfer OUT' " +
            //            " ELSE 'Original' " +
            //        " END AS TransferDirection " +
            //            " from attendancelogs AL inner join employees E on AL.EmployeeId=E.EmployeeId " +
            //            " LEFT JOIN locationmaster L ON L.LocationId = AL.ChangeLocationtId " +
            //            " LEFT JOIN departmentmaster D ON D.DepartmentId = AL.ChangeDepartmentId " +
            //            " inner join locationmaster LM on LM.LocationId=AL.LocationId " +
            //            " inner join departmentmaster DM on DM.DepartmentId=AL.DepartmentId " +
            //            " inner join contractormaster CM on CM.ContractorId=AL.ContractorId " +
            //            " inner join categories C on C.CategoryId=AL.CategoryId " +
            //            " inner join designationmaster DES on DES.DesignationId=AL.DesignationId " +
            //            " where AL.CancelTag=0 and E.CancelTag=0 and LM.CancelTag=0 and DM.CancelTag=0 ";

            MainQuery = objPC.Get_AttendanceLogs_Query(LocationId, DepartmentId);


            //WhereClause += " and AL.AttendanceDate='" + dtpAttenanceDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            //WhereClause += " and AL.ApprovalStatusId IN (1,2,3,6,8) ";

            WhereClause += " and AL.OutdoorApprovalStatusId IN (1,2,3,6,8) ";


            WhereClause += " AND IsOutdoorEntry=1 ";

            //if (!cbSelectAllStatus.Checked)
            //    WhereClause += " and AL.ApprovalStatusId=" + cmbApprovalStatusSearch.SelectedValue + "";

            //if (!cbContractor.Checked)
            //    WhereClause += " and AL.ContractorId=" + cmbContractor.SelectedValue + "";

            //if (!cbStatus.Checked)
            //    WhereClause += " and AL.Status='" + cmbStatus.Text + "'";

            //if (!cbSelectAllStatus.Checked)
            //    WhereClause += " and AL.ApprovalStatusId=" + cmbApprovalStatusSearch.SelectedValue + "";

            if (!cbDevice.Checked)
                if (cmbDevice.SelectedIndex > -1)
                    WhereClause += " and E.DeviceId=" + cmbDevice.Text + "";

            if (!string.IsNullOrWhiteSpace(Convert.ToString(txtSearchEmpCode.Text)))
                WhereClause += " and E.EmployeeCode=" + txtSearchEmpCode.Text + "";

            if (!string.IsNullOrWhiteSpace(Convert.ToString(txtSearchEmployee.Text)))
                WhereClause += " and E.EmployeeName LIKE '%" + txtSearchEmployee.Text + "%'";
            //WhereClause += " and E.EmployeeName ='" + txtSearchEmployee.Text + "'";


            OrderByClause = " order by E.EmployeeName asc";

            //WhereClause = BusinessResources.AttendanceRecord_Where + " and arm.ApprovedFlag=3 " + WhereClause;

            //objQL.ColumnNames_V = BusinessResources.AttendanceRecord_Column;
            //objQL.TableNames_V = BusinessResources.AttendanceRecord_Table;
            //objQL.WhereClause_V = WhereClause;
            //objQL.OrderBy_V = " order by E.EmployeeName asc";
            //objQL.GroupBy_V = "";

            //dt = objQL.SP_Attendance_Report_Query_DataTable();


            objBL.Query = MainQuery + WhereClause + OrderByClause;
            dt = objBL.ReturnDataTable();

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                lblTotalCount.Text = "Total Count- " + dt.Rows.Count;


                // Create checkbox column
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.HeaderText = "Select";
                chk.Name = "clmSelectAll";
                chk.Width = 50;

                // Add to DataGridView
                dataGridView1.Columns.Insert(0, chk); // adds as first column

                //  0   chk.Name = "clmSelectAll";
                //	1	AL.AttendanceLogId, +
                //	2	DATE_FORMAT(AL.AttendanceDate, '%d/%m/%Y') AS AttendanceDate, +
                //	3	AL.LocationId, +
                //	4	LM.LocationName as 'Location', +
                //	5	AL.DepartmentId,  +
                //	6	DM.Department, +
                //	7	L.LocationName AS 'Tran Location',  +
                //	8	D.Department AS 'Tran Department',  +
                //	9	AL.EmployeeId, +
                //	10	AL.EmployeeCode as 'Emp Code', +
                //	11	E.EmployeeName as 'Employee Name', +
                //	12	E.Gender, +
                //	13	AL.ContractorId, +
                //	14	CM.ContractorName as 'Roll Name', +
                //	15	AL.CategoryId,  +
                //	16	C.CategoryFName as 'Weekly Off', +
                //	17	AL.DesignationId,  +
                //	18	DES.Designation,  +
                //	19	AL.JobProfile,  +
                //	20	AL.ShiftGroupId,  +
                //	21	AL.OverTimeApplicable,  +
                //	22	AL.ShiftId,  +
                //	23	AL.ShiftFName as 'Shift Name', +
                //	24	TIME_FORMAT(AL.ShiftBeginTime, '%H:%i') AS 'Shift Begin', +
                //	25	TIME_FORMAT(AL.ShiftEndTime, '%H:%i') AS 'Shift End', +
                //	26	TIME_FORMAT(SEC_TO_TIME(AL.ShiftDuration * 60), '%H:%i') AS 'Shift Duration', +
                //	27	AL.InTime AS 'In Time', +
                //	28	AL.OutTime AS 'Out Time', +
                //	29	TIME_FORMAT(SEC_TO_TIME(AL.Duration * 60), '%H:%i') AS Duration, +
                //	30	TIME_FORMAT(SEC_TO_TIME(AL.OverTime * 60), '%H:%i') AS OverTime, +
                //	31	AL.Status,  +
                //	32	AL.Present,  +
                //	33	AL.HalfDay,  +
                //	34	AL.Absent,  +
                //	35	AL.MissedInPunch,  +
                //	36	AL.MissedOutPunch,  +
                //	37	AL.LateBy,  +
                //	38	AL.EarlyBy,  +
                //	39	AL.LossOfHours,  +
                //	40	AL.PunchRecords,  +
                //	41	AL.LeaveTypeId,  +
                //	42	AL.LeaveType,  +
                //	43	AL.LeaveDuration,  +
                //	44	AL.LeaveRemarks,  +
                //	45	AL.IsCompOff,  +
                //	46	AL.IsCompOffUsed,  +
                //	47	AL.CompOffRemarks,  +
                //	48	AL.CompOffUsedRemarks,  +
                //	49	AL.IsEditAttendance,  +
                //	50	AL.IsEditOverwrite,  +
                //	51	AL.IsLeaveForce,  +
                //	52	AL.HREditRemarks,  +
                //	53	AL.InchargeRemarks,  +
                //	54	AL.ManagerRemarks,  +
                //	55	AL.HRReply,  +
                //	56	AL.IsFlexibleHoursFlag,  +
                //	57	AL.FinancialYearId,  +
                //	58	AL.IsOutdoorEntry,+
                //	59	AL.IsRoll,  +
                //	60	AL.ChangeDepartmentFlag,  +
                //	61	AL.ChangeLocationtId,  +
                //	62	AL.ChangeDepartmentId,  +
                //	63	AL.TransferRemarks,  +
                //	64	AL.ApprovalStatusId,  +
                //	65	AL.IsEditOvertime,  +
                //	66	AL.OvertimePrevious  +

                // Hide multiple columns
                //int[] indexesToHide = { 0, 1, 2, 4, 8, 12, 14, 16, 17, 18, 19, 20, 21, 31, 32, 33, 34, 35, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 52, 55, 56, 57, 58, 59, 60, 61, 63, 64, 65 };
                int[] indexesToHide = { 1, 2, 3, 5, 9, 13, 15, 17, 18, 19, 20, 21, 22, 32, 33, 34, 35, 36, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 53, 56, 57, 58, 59, 60, 61, 62, 64, 65, 66 };

                //	1	AL.AttendanceLogId, +
                //	2	DATE_FORMAT(AL.AttendanceDate, '%d/%m/%Y') AS AttendanceDate, +
                //	3	AL.LocationId, +
                //	4	LM.LocationName as 'Location', +

                foreach (int i in indexesToHide)
                {
                    if (i < dataGridView1.Columns.Count)
                    {
                        dataGridView1.Columns[i].Visible = false;
                    }
                }

                dataGridView1.Columns[4].Width = 50;
                dataGridView1.Columns[7].Width = 50;
                dataGridView1.Columns[10].Width = 50;
                dataGridView1.Columns[12].Width = 50;
                dataGridView1.Columns[13].Width = 200;
                dataGridView1.Columns[24].Width = 50;
                dataGridView1.Columns[25].Width = 50;
                dataGridView1.Columns[26].Width = 50;
                dataGridView1.Columns[27].Width = 120;
                dataGridView1.Columns[28].Width = 120;
                dataGridView1.Columns[29].Width = 50;
                dataGridView1.Columns[30].Width = 50;
                dataGridView1.Columns[31].Width = 50;
                dataGridView1.Columns[36].Width = 40;
                dataGridView1.Columns[37].Width = 40;
                dataGridView1.Columns[38].Width = 40;
                dataGridView1.Columns[39].Width = 40;
                //dataGridView1.Columns[39].Width = 100;

                dataGridView1.Columns[30].Width = 50;

                dataGridView1.Columns[1].ReadOnly = false;

                ////            var statusCounts = dt.AsEnumerable()
                ////            .GroupBy(r => r["Status"].ToString())
                ////            .Select(g => new
                ////            {
                ////                Status = g.Key,
                ////                Count = g.Count()
                ////            });

                ////            ConcatTotal = string.Empty;
                ////            foreach (var item in statusCounts)
                ////            {
                ////                //MessageBox.Show(item.Status + " - " + item.Count);
                ////                ConcatTotal += item.Status + "-\t" + item.Count + "\n";
                ////            }

                int TransferCount = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Duration"] != DBNull.Value)
                    {
                        TimeSpan ts;
                        if (TimeSpan.TryParse(dr["Duration"].ToString(), out ts))
                        {
                            totalDuration += ts;
                        }
                    }
                    if (dr["OT"] != DBNull.Value)
                    {
                        TimeSpan ts;
                        if (TimeSpan.TryParse(dr["OT"].ToString(), out ts))
                        {
                            totalOT += ts;
                        }
                    }

                    if (dr["ChangeDepartmentFlag"] != DBNull.Value)
                    {
                        if (Convert.ToInt32(dr["ChangeDepartmentFlag"]) > 0)
                            TransferCount++;
                    }

                    lblTotalCount.Text = "Total Count- " + dt.Rows.Count;
                    lblTransferCount.Text = "Total Transfer Count- " + TransferCount.ToString();
                }

                ////            //ConcatTotal += "Total Duration: " + totalDuration.ToString(@"hh\:mm") + "\n";
                ////            //ConcatTotal += "Total OT: " + totalOT.ToString(@"hh\:mm") + "\n";

                ////            //double Duration_Double = totalDuration.TotalHours;
                ////            //double OT_Double = totalDuration.TotalHours;

                ////            ConcatTotal += "Total Duration: " + Math.Round(totalDuration.TotalHours,0).ToString() + "\n";
                ////            ConcatTotal += "Total OT: " + Math.Round(totalOT.TotalHours, 0).ToString() + "\n";

                ////            //lblTotalOT.Text = "Total OT: " + totalOT.ToString(@"hh\:mm");

                ////            if (!string.IsNullOrWhiteSpace(ConcatTotal))
                ////                rtbStatusCount.Text = ConcatTotal.ToString();


                ////            string TransferTotal = string.Empty;

                ////            var TransferCounts = dt.AsEnumerable()
                ////                 .Where(r =>
                ////    r["ChangeDepartmentFlag"] != DBNull.Value &&
                ////    Convert.ToInt32(r["ChangeDepartmentFlag"]) == 1 &&

                ////    r["ChangeLocationtId"] != DBNull.Value &&
                ////    Convert.ToInt32(r["ChangeLocationtId"]) > 0 &&

                ////    r["ChangeDepartmentId"] != DBNull.Value &&
                ////    Convert.ToInt32(r["ChangeDepartmentId"]) > 0
                ////)
                ////.GroupBy(r => new
                ////{
                ////    TranLocation = r["Tran Location"].ToString(),
                ////    TranDepartment = r["Tran Department"].ToString()
                ////})
                ////.Select(g => new
                ////{
                ////    Location = g.Key.TranLocation,
                ////    Department = g.Key.TranDepartment,
                ////    Count = g.Count()
                ////});

                ////            foreach (var item in TransferCounts)
                ////            {
                ////                TransferTotal += item.Location + " - " + item.Department + " - " + item.Count + "\n";
                ////            }

                ////            rtbStatusCount.Visible = true;

                ////            if (!string.IsNullOrWhiteSpace(TransferTotal))
                ////                rtbStatusCount.Text = TransferTotal;

                ////            if (!string.IsNullOrWhiteSpace(TransferTotal))
                ////                rtbStatusCount.Text = TransferTotal.ToString();


                //            string RollTotal = string.Empty;

                //            var rollCounts = dt.AsEnumerable()
                //.GroupBy(r => r["Roll Name"].ToString())   // or "ContractorName" based on your column name
                //.Select(g => new
                //{
                //    RollName = g.Key,
                //    Count = g.Count()
                //});

                //            foreach (var item in rollCounts)
                //            {
                //                Console.WriteLine(item.RollName + " - " + item.Count);
                //                //RollTotal += item.RollName + "-\t\t" + item.Count + "\n";
                //                //RollTotal += item.RollName.PadRight(40) + " - " + item.Count.ToString().PadLeft(5) + "\n";
                //                RollTotal += item.RollName + " - " + item.Count.ToString() + "\n";

                //            }

                //rtbContractorWiseCount.Visible = true;

                //if (!string.IsNullOrWhiteSpace(RollTotal))
                //    rtbContractorWiseCount.Text = RollTotal.ToString();


                //            string DesignationTotal = string.Empty;

                //            //            var designationCounts = dt.AsEnumerable()
                //            //.GroupBy(r => r["Designation"].ToString())   // or "ContractorName" based on your column name
                //            //.Select(g => new
                //            //{
                //            //    RollName = g.Key,
                //            //    Count = g.Count()
                //            //});

                //            var designationCounts = dt.AsEnumerable()
                //.Where(r => new[] { "P", "HD", "HP" }.Contains(r["Status"].ToString()))
                //.GroupBy(r => r["Designation"].ToString())
                //.Select(g => new
                //{
                //    RollName = g.Key,
                //    Count = g.Count()
                //});

                //            foreach (var item in designationCounts)
                //            {
                //                Console.WriteLine(item.RollName + " - " + item.Count);
                //                DesignationTotal += item.RollName + " - " + item.Count.ToString() + "\n";

                //            }

                //            rtbDesignationCount.Visible = true;

                //            if (!string.IsNullOrWhiteSpace(DesignationTotal))
                //                rtbDesignationCount.Text = DesignationTotal.ToString();

                //Approval Status

                objRL.Set_Approval_Colour_DataGridView(dataGridView1, lblPending, lblHRApproved, lblManagerApproved, lblRemark, lblCompleted, "OutdoorApprovalStatusId");





                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //PendingCount = 0; CompletedCount = 0, RemarksCount = 0, RejectCount = 0, ErrorCount = 0, HRApprovedCount = 0, InchargeApprovedCount = 0, ManagerApprovedCount = 0;

                    //if (!string.IsNullOrWhiteSpace(Convert.ToString(row.Cells["ApprovalStatusId"].Value)))
                    //{
                    //    //Pending 1
                    //    if (row.Cells["ApprovalStatusId"].Value != null && Convert.ToInt32(row.Cells["ApprovalStatusId"].Value) == 1)
                    //    {
                    //        row.DefaultCellStyle.BackColor = Color.Yellow;
                    //        PendingCount++;
                    //    }
                    //    //Completed 1
                    //    else if (row.Cells["ApprovalStatusId"].Value != null && Convert.ToInt32(row.Cells["ApprovalStatusId"].Value) == 2)
                    //    {
                    //        row.DefaultCellStyle.BackColor = Color.Green;
                    //        completed++;
                    //    }
                    //    //Remarks
                    //    else if (row.Cells["ApprovalStatusId"].Value != null && Convert.ToInt32(row.Cells["ApprovalStatusId"].Value) == 2)
                    //    {
                    //        row.DefaultCellStyle.BackColor = Color.Green;
                    //        PendingCount++;
                    //    }

                    //}

                    // Check LateBy column (only color that cell)
                    if (row.Cells["Late by"].Value != null &&
                        !string.IsNullOrWhiteSpace(row.Cells["Late by"].Value.ToString()))
                    {
                        double lateBy = Convert.ToDouble(row.Cells["Late by"].Value);

                        if (lateBy > 0)
                        {
                            row.Cells["Late by"].Style.BackColor = Color.Red;
                            row.Cells["Late by"].Style.ForeColor = Color.White; // optional for visibility
                        }
                    }

                    // Check LateBy column (only color that cell)
                    if (row.Cells["Early by"].Value != null &&
                        !string.IsNullOrWhiteSpace(row.Cells["Early by"].Value.ToString()))
                    {
                        double lateBy = Convert.ToDouble(row.Cells["Early by"].Value);

                        if (lateBy > 0)
                        {
                            row.Cells["Early by"].Style.BackColor = Color.Red;
                            row.Cells["Early by"].Style.ForeColor = Color.White; // optional for visibility
                        }
                    }
                }

                //lblPending.Text = "Pending: " + PendingCount;

                //Datagridview Sub
                dgvAttendanceStatus.DataSource = null;

                List<string> statusList = new List<string>();

                using (MySqlConnection con = new MySqlConnection(objBL.conString))
                {
                    con.Open();

                    string QueryStatus = "SELECT DISTINCT Status " +
                        " FROM statusmaster " +
                        " ORDER BY " +
                        " CASE Status " +
                            "WHEN 'P'   THEN 1 " +
                            "WHEN 'HD'  THEN 2 " +
                            "WHEN 'L'   THEN 3 " +
                            "WHEN 'WOP' THEN 4 " +
                            "WHEN 'HP'  THEN 5 " +
                            "WHEN 'SL'  THEN 6 " +
                            "WHEN 'CO'  THEN 7 " +
                            "WHEN 'COU' THEN 8 " +
                            "WHEN 'A'   THEN 9 " +
                            "WHEN 'ODP' THEN 10 " +
                            "ELSE 11 " +
                            " END; ";

                    MySqlCommand cmd = new MySqlCommand(QueryStatus, con);



                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["Status"] != DBNull.Value)
                            statusList.Add(reader["Status"].ToString());
                    }
                }

                string[] statuses = statusList.ToArray();
                // Define statuses you want as columns
                //string[] statuses = { "P", "A", "H", "HD", "COA", "COU", "WO" };

                // Create result table
                System.Data.DataTable resultTable = new System.Data.DataTable();
                resultTable.Columns.Add("Designation");

                // Add dynamic status columns
                foreach (var status in statuses)
                {
                    resultTable.Columns.Add(status, typeof(int));
                }

                // Group data
                var groupedData = dt.AsEnumerable()
                    .GroupBy(r => r["Designation"].ToString())
                    .OrderBy(g => g.Key);

                // Fill rows
                foreach (var group in groupedData)
                {
                    DataRow row = resultTable.NewRow();
                    row["Designation"] = group.Key;

                    foreach (var status in statuses)
                    {
                        int count = group.Count(r => r["Status"] != DBNull.Value &&
                                                      r["Status"].ToString() == status);
                        row[status] = count;
                    }

                    resultTable.Rows.Add(row);
                }

                // ✅ ADD TOTAL ROW HERE (outside loop)
                DataRow totalRow = resultTable.NewRow();
                totalRow["Designation"] = "Total";

                foreach (var status in statuses)
                {
                    int total = resultTable.AsEnumerable()
                        .Sum(r => r.Field<int?>(status) ?? 0);

                    totalRow[status] = total;
                }

                resultTable.Rows.Add(totalRow);

                // Bind to DataGridView
                dgvAttendanceStatus.DataSource = resultTable;
                dgvAttendanceStatus.ReadOnly = true;


                //dataGridView2.Columns["Designation"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvAttendanceStatus.Columns["Designation"].Width = 150;
                foreach (string status in statuses)
                {
                    dgvAttendanceStatus.Columns[status].Width = 40;
                }

                // Set header background color
                dgvAttendanceStatus.EnableHeadersVisualStyles = false; // Must disable to apply custom colors
                                                                       // Convert string to Color
                Color headerColor = ColorTranslator.FromHtml(BusinessResources.BACKGROUND_COLOUR);

                dgvAttendanceStatus.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
                dgvAttendanceStatus.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Header text
                dgvAttendanceStatus.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Optional font

                // Example: make "P" column light green and "A" column light red
                dgvAttendanceStatus.Columns["P"].DefaultCellStyle.BackColor = Color.LightGreen;
                dgvAttendanceStatus.Columns["P"].DefaultCellStyle.ForeColor = Color.Black;

                dgvAttendanceStatus.Columns["A"].DefaultCellStyle.BackColor = Color.LightSalmon;
                dgvAttendanceStatus.Columns["A"].DefaultCellStyle.ForeColor = Color.Black;

                foreach (DataGridViewRow row in dgvAttendanceStatus.Rows)
                {
                    if (row.Cells["Designation"].Value != null &&
                        row.Cells["Designation"].Value.ToString() == "Total")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.Font = new Font(dgvAttendanceStatus.Font, FontStyle.Bold);
                    }
                }

                //foreach (DataGridViewRow row in dataGridView2.Rows)
                //{
                //    if (row.Cells["ApprovalStatusId"].Value != null && Convert.ToInt32(row.Cells["ApprovalStatusId"].Value) == 1)
                //    {
                //        row.DefaultCellStyle.BackColor = Color.Yellow;
                //    }
                //}

                //int pendingCount = dt.AsEnumerable()
                //     .Count(r => r["ApprovalStatusId"] != DBNull.Value &&
                //                 r["ApprovalStatus"].ToString() == "1");

                //lblPending.Text = "Pending: " + pendingCount;


                //Transfer IN Logics
                dgvTransferIN.DataSource = null;

                // Define statuses
                string[] statusesTranser = { "P" };

                // Create result table
                System.Data.DataTable resultTableTrnasfer = new System.Data.DataTable();
                resultTableTrnasfer.Columns.Add("Tran IN Location");
                resultTableTrnasfer.Columns.Add("Tran IN Department");

                // Add dynamic status columns
                foreach (var status in statusesTranser)
                {
                    resultTableTrnasfer.Columns.Add(status, typeof(int));
                }

                // Filter + Group (SAFE VERSION)
                var groupedDataTransfer = dt.AsEnumerable()
                    .Where(r => !string.IsNullOrWhiteSpace(r.Field<string>("Location")) &&
                                !string.IsNullOrWhiteSpace(r.Field<string>("Department")) &&
                                (r.Field<int?>("ChangeDepartmentFlag") ?? 0) > 0 &&
                                (r.Field<int?>("ChangeLocationtId") ?? 0) > 0 &&
                                (r.Field<int?>("ChangeLocationtId") ?? 0) == LocationId &&
                                (r.Field<int?>("ChangeDepartmentId") ?? 0) > 0 &&
                                (r.Field<int?>("ChangeDepartmentId") ?? 0) == DepartmentId)
                    .GroupBy(r => new
                    {
                        Location = r.Field<string>("Location"),
                        Department = r.Field<string>("Department")
                    })
                    .OrderBy(g => g.Key.Location)
                    .ThenBy(g => g.Key.Department);

                // Fill result table
                foreach (var group in groupedDataTransfer)
                {
                    DataRow row = resultTableTrnasfer.NewRow();

                    row["Tran IN Location"] = group.Key.Location;
                    row["Tran IN Department"] = group.Key.Department;

                    foreach (var status in statusesTranser)
                    {
                        int count = group.Count(r => r.Field<string>("Status") == status);
                        row[status] = count;
                    }

                    //resultTableTrnasfer.Rows.Add(row);
                    resultTableTrnasfer.Rows.Add(row);  // existing loop end

                    // 👉 ADD TOTAL ROW HERE
                    DataRow totalRowIN = resultTableTrnasfer.NewRow();
                    totalRowIN["Tran IN Location"] = "Total";
                    totalRowIN["Tran IN Department"] = "";

                    foreach (var status in statusesTranser)
                    {
                        int total = resultTableTrnasfer.AsEnumerable()
                            .Sum(r => r.Field<int?>(status) ?? 0);

                        totalRowIN[status] = total;
                    }

                    resultTableTrnasfer.Rows.Add(totalRowIN);

                    // Bind
                    dgvTransferIN.DataSource = resultTableTrnasfer;
                    dgvTransferIN.ReadOnly = true;
                    dgvTransferIN.Columns[2].Width = 40;
                }

                // Bind to grid
                dgvTransferIN.DataSource = resultTableTrnasfer;
                dgvTransferIN.ReadOnly = true;

                foreach (DataGridViewRow row in dgvTransferIN.Rows)
                {
                    if (row.Cells["Tran IN Location"].Value != null &&
                        row.Cells["Tran IN Location"].Value.ToString() == "Total")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.Font = new Font(dgvTransferIN.Font, FontStyle.Bold);
                    }
                }


                //Transfer Out Logics
                dgvTransferOut.DataSource = null;

                // Define statuses
                string[] statusesTranserOut = { "P" };

                // Create result table
                System.Data.DataTable resultTableTrnasferOut = new System.Data.DataTable();
                resultTableTrnasferOut.Columns.Add("Tran OUT Location");
                resultTableTrnasferOut.Columns.Add("Tran OUT Department");

                // Add dynamic status columns
                foreach (var status in statusesTranserOut)
                {
                    resultTableTrnasferOut.Columns.Add(status, typeof(int));
                }

                // Filter + Group (SAFE VERSION)
                var groupedDataTransferOut = dt.AsEnumerable()
                    .Where(r => !string.IsNullOrWhiteSpace(r.Field<string>("Tran Location")) &&
                                !string.IsNullOrWhiteSpace(r.Field<string>("Tran Department")) &&
                                (r.Field<int?>("ChangeDepartmentFlag") ?? 0) > 0 &&
                                (r.Field<int?>("LocationId") ?? 0) > 0 &&
                                (r.Field<int?>("LocationId") ?? 0) == LocationId &&
                                (r.Field<int?>("DepartmentId") ?? 0) > 0 &&
                                (r.Field<int?>("DepartmentId") ?? 0) == DepartmentId)
                    .GroupBy(r => new
                    {
                        Location = r.Field<string>("Tran Location"),
                        Department = r.Field<string>("Tran Department")
                    })
                    .OrderBy(g => g.Key.Location)
                    .ThenBy(g => g.Key.Department);

                // Fill result table
                foreach (var group in groupedDataTransferOut)
                {
                    DataRow row = resultTableTrnasferOut.NewRow();

                    row["Tran OUT Location"] = group.Key.Location;
                    row["Tran OUT Department"] = group.Key.Department;

                    foreach (var status in statusesTranserOut)
                    {
                        int count = group.Count(r => r.Field<string>("Status") == status);
                        row[status] = count;
                    }

                    resultTableTrnasferOut.Rows.Add(row);

                    // 👉 ADD TOTAL ROW HERE
                    DataRow totalRowOut = resultTableTrnasferOut.NewRow();
                    totalRowOut["Tran OUT Location"] = "Total";
                    totalRowOut["Tran OUT Department"] = "";

                    foreach (var status in statusesTranserOut)
                    {
                        int total = resultTableTrnasferOut.AsEnumerable()
                            .Sum(r => r.Field<int?>(status) ?? 0);

                        totalRowOut[status] = total;
                    }

                    resultTableTrnasferOut.Rows.Add(totalRowOut);
                }

                // Bind to grid
                dgvTransferOut.DataSource = resultTableTrnasferOut;
                dgvTransferOut.ReadOnly = true;
                dgvTransferOut.Columns[2].Width = 40;

                foreach (DataGridViewRow row in dgvTransferOut.Rows)
                {
                    if (row.Cells["Tran OUT Location"].Value != null &&
                        row.Cells["Tran OUT Location"].Value.ToString() == "Total")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.Font = new Font(dgvTransferOut.Font, FontStyle.Bold);
                    }
                }
            }

            dataGridView1.ClearSelection();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void Fill_Data()
        {
            //objRL.Fill_Contractor_IN_Attendance(cmbRoll);
            objRL.FillLocation(cmbLocation, cmbDepartment);
            //cbAttendanceDate.Checked = true;
        }

        
        

        private void ClearAll()
        {
            dataGridView1.Rows.Clear();
            objEP.Clear();

            TableId = 0;

            dtpAttenanceDate.Value = DateTime.Now.Date;
            cbDevice.Checked = true;
            cmbDevice.SelectedIndex = -1;
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            txtSearchEmployee.Text = "";
            txtSearchEmpCode.Text = "";
            cbSelectAll.Checked = false;
            cbTransferIn.Checked = false;
            cbTransferOut.Checked = false;

            lblTotalCount.Text = "";
            lblTransferCount.Text = "";
            lblOverTime.Text = "";

            cmbApprovalStatus.SelectedIndex = -1;
            txtRemarks.Text = "";
            pSave.Visible = false;

            TOT = TimeSpan.Zero;


            SName = string.Empty;

            dtpAttenanceDate.Focus();
        }

        private void OutddorPunchApproval_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}
