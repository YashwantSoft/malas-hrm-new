using BusinessLayerUtility;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.VariantTypes;
using MySql.Data.MySqlClient;
using SPApplication.HR;
using SPApplication.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;

namespace SPApplication.Transaction
{
    public partial class AttendanceWorkingNew : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0, LocationId = 0;
        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;
        string ConcatTotal = string.Empty;
        string RollTotal = string.Empty;

        string MainQuery = string.Empty, WhereClause = string.Empty,OrderByClause=string.Empty;
        bool ApproveFlag = false;

        DateTime dtIn, dtOut;
        double Duration = 0, OverTime = 0, TotalDuration = 0, LateBy = 0, EarlyBy = 0;

        public AttendanceWorkingNew()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, "ATTENDANCE");
            //btnSave.Text = BusinessResources.BTN_VIEW;
            btnDelete.Text = BusinessResources.BTN_VIEW;
            //objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");
            objRL.FillLocation(cmbLocation, cmbDepartment);

            objRL.Fill_Status_ComboBox(cmbStatus);
            objRL.Fill_Approval_Status(cmbApprovalStatusSearch);
            objRL.Fill_Contractor_IN_Attendance(cmbContractor);

 
            ClearAll();

            objDL.Set_Approval_Colour(lblPending);
            objDL.Set_Approval_Colour(lblHRApproved);
            objDL.Set_Approval_Colour(lblManagerApproved);
            objDL.Set_Approval_Colour(lblRemark);
            objDL.Set_Approval_Colour(lblCompleted);
        }

        private void ClearAll()
        {
            dtpAttenanceDate.Value = DateTime.Now.Date;
            cbLocation.Checked = true;
            cbDepartment.Checked = true;
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cbSelectAllStatus.Checked = true;
            cmbApprovalStatusSearch.SelectedIndex = -1;
            cbContractor.Checked = true;
            cmbContractor.SelectedIndex = -1;
            cbStatus.Checked = true;
            cmbStatus.SelectedIndex = -1;
            cbDevice.Checked = true;
            cmbDevice.SelectedIndex = -1;
            txtSearchEmpCode.Text = "";
            txtSearchEmployee.Text = "";
            //dataGridView1.Rows.Clear();
            rtbStatusCount.Text = "";
            rtbContractorWiseCount.Text = "";
            txtSearchEmpCode.Text = "";
            txtSearchEmployee.Text = "";
            dataGridView1.DataSource = null;
            FillGrid();
        }

        //private void FillDepartment()
        //{
        //    if (cmbLocation.SelectedIndex > -1)
        //        objRL.FillDepartment(cmbLocation, cmbDepartment);
        //}

        private void txtSearchEmpCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtSearchEmpCode);
        }

        private void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(Convert.ToString(txtSearchEmployee.Text)))
            {
                txtSearchEmpCode.Text = "";
                FillGrid();
            }
        }

        private void dtpAttenanceDate_ValueChanged(object sender, EventArgs e)
        {
            lblAttendanceDay.Text = "Day-" + Convert.ToString(dtpAttenanceDate.Value.Date.DayOfWeek);
        }

        private void cbDevice_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDevice.Checked)
            {
                cmbDevice.SelectedIndex = -1;
                cmbDevice.Enabled = false;
            }
            else
            {
                cmbDevice.SelectedIndex = -1;
                cmbDevice.Enabled = true;
                cmbDevice.Focus();
            }
        }

        private void cbContractor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbContractor.Checked)
            {
                cmbContractor.SelectedIndex = -1;
                cmbContractor.Enabled = false;
            }
            else
            {
                cmbContractor.SelectedIndex = -1;
                cmbContractor.Enabled = true;
                cmbContractor.Focus();
            }
        }

        private void cbStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStatus.Checked)
            {
                cmbStatus.SelectedIndex = -1;
                cmbStatus.Enabled = false;
            }
            else
            {
                cmbStatus.SelectedIndex = -1;
                cmbStatus.Enabled = true;
                cmbStatus.Focus();
            }
        }

        private void txtSearchEmpCode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Convert.ToString(txtSearchEmpCode.Text)))
            {
                txtSearchEmployee.Text = "";
                FillGrid();
            }
        }

        private void cbSelectAllStatus_CheckedChanged(object sender, EventArgs e)
        {
            cmbApprovalStatusSearch.SelectedIndex = -1;
            if (cbSelectAllStatus.Checked)
            {
                cmbApprovalStatusSearch.Enabled = false;
                cmbApprovalStatusSearch.SelectedIndex = -1;
            }
            else
            {
                cmbApprovalStatusSearch.Text = BusinessResources.LS_Pending;
                cmbApprovalStatusSearch.Enabled = true;
            }
        }

        //private void FillDepartment()
        //{
        //    //Hardcode
        //    if (cmbLocation.SelectedIndex > -1)
        //    {
        //        LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
        //        objPC.LocationId = LocationId;
        //        objPC.InchargeId = BusinessLayer.EmployeeLoginId_Static;

        //        if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
        //            objPC.SearchType = BusinessResources.USER_TYPE_ADMIN;
        //        else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
        //            objPC.SearchType = BusinessResources.USER_TYPE_PLANTHEAD;
        //        else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
        //            objPC.SearchType = BusinessResources.USER_TYPE_INCHARGE;
        //        else
        //            objPC.SearchType = BusinessResources.USER_TYPE_INCHARGE;

        //        objQL.SP_ApprovalLevel_Get_Department_By_LocationId_InchargeId(cmbDepartment);
        //    }
        //}

        private void AttendanceWorking_Load(object sender, EventArgs e)
        {
            //FillGrid();
            ClearAll();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dataGridView1.Rows.Count;
                CurrentRowIndex = dataGridView1.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    objPC.LeaveTypeFlag = false;
                    if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value)))
                    {
                        objPC.AttendanceLogId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                        objPC.AttendanceDate= Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                        objPC.EmployeeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[8].Value);
                        objPC.EmployeeCode = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[9].Value);

                        if (objPC.AttendanceLogId != 0)
                        {
                            EditAttendance objForm = new EditAttendance();
                            objForm.ShowDialog(this);
                            FillGrid();
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

        TimeSpan totalOT = TimeSpan.Zero;
        TimeSpan totalDuration = TimeSpan.Zero;


        private void CallStoreProcedure_AttendanceLogs()
        {
            objBL.Connect();
            using (MySqlConnection conn = new MySqlConnection(objBL.conString))
            {
                using (MySqlCommand cmd = new MySqlCommand("SP_Update_Attendancelogs_New", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Pass DATE parameter
                    cmd.Parameters.Add("@AttendanceDate_V", MySqlDbType.Date).Value = dtpAttenanceDate.Value;

                    conn.Open();
                    int R = cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        private void FillGrid()
        {
            CallStoreProcedure_AttendanceLogs();

            //dgvAttendanceStatus.Rows.Clear();
            dgvAttendanceStatus.DataSource = null;
            LocationId = 0;
            DepartmentId = 0;
            totalOT = TimeSpan.Zero;
            totalDuration = TimeSpan.Zero;

            lblTransferCount.Text = "";
            lblTotalCount.Text = "";

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            DataTable dt = new DataTable();

            MainQuery = string.Empty;
            WhereClause = string.Empty;
            OrderByClause = string.Empty;

            //MainQuery = objPC.AttendanceLogsQuery;

            

            if (!cbLocation.Checked)
            {
                if(cmbLocation.SelectedIndex >-1)
                    LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                //WhereClause = " and AL.LocationId=" + LocationId + "";
            }
            if (!cbLocation.Checked && !cbDepartment.Checked)
            {
                if (cmbDepartment.SelectedIndex > -1)
                    DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
               // WhereClause += " and AL.DepartmentId=" + DepartmentId + "";
            }

            if (LocationId > 0 && DepartmentId > 0)
            {
                WhereClause += " AND((AL.LocationId = " + LocationId + " AND AL.DepartmentId = " + DepartmentId + ") " +
                               " OR(AL.ChangeLocationtId = " + LocationId + " AND AL.ChangeDepartmentId = " + DepartmentId + ")) ";
            }
            else
            {
                if (LocationId > 0)
                    WhereClause += " AND AL.LocationId = " + LocationId + " ";
                //if (DepartmentId > 0)
                //    WhereClause += "AND AL.DepartmentId = " + DepartmentId + "";
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

            objPC.AttendanceDate = dtpAttenanceDate.Value;

            MainQuery = objPC.Get_AttendanceLogs_Query(LocationId, DepartmentId);

            WhereClause += " and AL.AttendanceDate='" + dtpAttenanceDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            if(!cbSelectAllStatus.Checked)
                WhereClause += " and AL.ApprovalStatusId=" + cmbApprovalStatusSearch.SelectedValue + "";

            if (!cbContractor.Checked)
                WhereClause += " and AL.ContractorId=" + cmbContractor.SelectedValue + "";

            if (!cbStatus.Checked)
                WhereClause += " and AL.Status='" + cmbStatus.Text + "'";

            if (!cbSelectAllStatus.Checked)
                WhereClause += " and AL.ApprovalStatusId=" + cmbApprovalStatusSearch.SelectedValue + "";

            if (!cbDevice.Checked)
                WhereClause += " and E.DeviceId=" + cmbDevice.Text + "";

            if (!string.IsNullOrWhiteSpace(Convert.ToString(txtSearchEmpCode.Text)))
                WhereClause += " and E.EmployeeCode=" + txtSearchEmpCode.Text + "";

            if (!string.IsNullOrWhiteSpace(Convert.ToString(txtSearchEmployee.Text)))
                WhereClause += " and E.EmployeeName LIKE '%" + txtSearchEmployee.Text + "%'";
            //WhereClause += " and E.EmployeeName ='" + txtSearchEmployee.Text + "'";


            if(ApprovalStatusId > 0)
            {
                if (cbSelectAllStatus.Checked)
                    WhereClause += " and AL.ApprovalStatusId=" + ApprovalStatusId + "";
            }


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

                

                int TotalCount = objRL.AttendanceCountAll();
                lblTotalCount.Text = "Total Count- " + TotalCount;

                //objBL.Query = "select Count(*) from attendancelogs where CancelTag=0 and "+ 
                //              " AttendanceDate='" + dtpAttenanceDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' "+
                //              " AND(LocationId = "+LocationId+" OR "+ LocationId + " = 0) AND(DepartmentId = "+DepartmentId+ " OR "+DepartmentId+" = 0)";
                //DataTable dtCount = new DataTable();
                //dtCount = 

                //" AND (LocationId = "+LocationId+ " AND DepartmentId=" + DepartmentId + " ) ";

                //              " AND(DepartmentId = @DepartmentId OR @DepartmentId = 0);
                //AND (DepartmentId = @DepartmentId OR @DepartmentId = 0);
                //AND (LocationId = "+LocationId+" OR "+ LocationId + " = 0) AND (DepartmentId = "+DepartmentId+ " OR "+DepartmentId+" = 0); ";

                //lblTotalCount.Text = "Total Count- " + dt.Rows.Count;


                //// Create checkbox column
                //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                //chk.HeaderText = "Select";
                //chk.Name = "chkSelect";
                //chk.Width = 50;

                //// Add to DataGridView
                //dataGridView1.Columns.Insert(dataGridView1.Columns.Count, chk); // adds as first column

                //	0	AL.AttendanceLogId, +
                //	1	DATE_FORMAT(AL.AttendanceDate, '%d/%m/%Y') AS AttendanceDate, +
                //	2	AL.LocationId, +
                //	3	LM.LocationName as 'Location', +
                //	4	AL.DepartmentId,  +
                //	5	DM.Department, +
                //	6	L.LocationName AS 'Tran Location',  +
                //	7	D.Department AS 'Tran Department',  +
                //	8	AL.EmployeeId, +
                //	9	AL.EmployeeCode as 'Emp Code', +
                //	10	E.EmployeeName as 'Employee Name', +
                //	11	E.Gender, +
                //	12	AL.ContractorId, +
                //	13	CM.ContractorName as 'Roll Name', +
                //	14	AL.CategoryId,  +
                //	15	C.CategoryFName as 'Weekly Off', +
                //	16	AL.DesignationId,  +
                //	17	DES.Designation,  +
                //	18	AL.JobProfile,  +
                //	19	AL.ShiftGroupId,  +
                //	20	AL.OverTimeApplicable,  +
                //	21	AL.ShiftId,  +
                //	22	AL.ShiftFName as 'Shift Name', +
                //	23	TIME_FORMAT(AL.ShiftBeginTime, '%H:%i') AS 'Shift Begin', +
                //	24	TIME_FORMAT(AL.ShiftEndTime, '%H:%i') AS 'Shift End', +
                //	25	TIME_FORMAT(SEC_TO_TIME(AL.ShiftDuration * 60), '%H:%i') AS 'Shift Duration', +
                //	26	AL.InTime AS 'In Time', +
                //	27	AL.OutTime AS 'Out Time', +
                //	28	TIME_FORMAT(SEC_TO_TIME(AL.Duration * 60), '%H:%i') AS Duration, +
                //	29	TIME_FORMAT(SEC_TO_TIME(AL.OverTime * 60), '%H:%i') AS OverTime, +
                //	30	AL.Status,  +
                //	31	AL.Present,  +
                //	32	AL.HalfDay,  +
                //	33	AL.Absent,  +
                //	34	AL.MissedInPunch,  +
                //	35	AL.MissedOutPunch,  +
                //	36	AL.LateBy,  +
                //	37	AL.EarlyBy,  +
                //	38	AL.LossOfHours,  +
                //	39	AL.PunchRecords,  +
                //	40	AL.LeaveTypeId,  +
                //	41	AL.LeaveType,  +
                //	42	AL.LeaveDuration,  +
                //	43	AL.LeaveRemarks,  +
                //	44	AL.IsCompOff,  +
                //	45	AL.IsCompOffUsed,  +
                //	46	AL.CompOffRemarks,  +
                //	47	AL.CompOffUsedRemarks,  +
                //	48	AL.IsEditAttendance,  +
                //	49	AL.IsEditOverwrite,  +
                //	50	AL.IsLeaveForce,  +
                //	51	AL.HREditRemarks,  +
                //	52	AL.InchargeRemarks,  +
                //	53	AL.ManagerRemarks,  +
                //	54	AL.HRReply,  +
                //	55	AL.IsFlexibleHoursFlag,  +
                //	56	AL.FinancialYearId,  +
                //	57	AL.IsOutdoorEntry,+
                //	58	AL.IsRoll,  +
                //	59	AL.ChangeDepartmentFlag,  +
                //	60	AL.ChangeLocationtId,  +
                //	61	AL.ChangeDepartmentId,  +
                //	62	AL.TransferRemarks,  +
                //	63	AL.ApprovalStatusId,  +
                //	64	AL.IsEditOvertime,  +
                //	65	AL.OvertimePrevious  +

                // Hide multiple columns
                int[] indexesToHide = { 0,1, 2, 4, 8, 12, 14, 16, 17,18, 19,20, 21,31,32,33, 34,35, 40,41,42,43, 44, 45,46,47, 48, 49, 50,52, 55, 56, 57, 58, 59, 60, 61, 63, 64,65 };

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

                   // lblTotalCount.Text = "Total Count- " + dt.Rows.Count;
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


                RollTotal = string.Empty;

                var rollCounts = dt.AsEnumerable()
    .GroupBy(r => r["Roll Name"].ToString())   // or "ContractorName" based on your column name
    .Select(g => new
    {
        RollName = g.Key,
        Count = g.Count()
    });

                foreach (var item in rollCounts)
                {
                    Console.WriteLine(item.RollName + " - " + item.Count);
                    //RollTotal += item.RollName + "-\t\t" + item.Count + "\n";
                    //RollTotal += item.RollName.PadRight(40) + " - " + item.Count.ToString().PadLeft(5) + "\n";
                    RollTotal += item.RollName + " - " + item.Count.ToString() + "\n";

                }

                rtbContractorWiseCount.Visible = true;

                if (!string.IsNullOrWhiteSpace(RollTotal))
                    rtbContractorWiseCount.Text = RollTotal.ToString();


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

                int pendingCount = 0;

               

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //if(!string.IsNullOrWhiteSpace(Convert.ToString(row.Cells["ApprovalStatusId"].Value)))
                    //{
                    //    //Pending
                    //    if (row.Cells["ApprovalStatusId"].Value != null && Convert.ToInt32(row.Cells["ApprovalStatusId"].Value) == 1)
                    //    {
                    //        row.DefaultCellStyle.BackColor = Color.Yellow;
                    //        pendingCount++;
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

                    //lblHRApproved.Text
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

                //lblPending.Text = "Pending: " + pendingCount;

                //Datagridview Sub
                dgvAttendanceStatus.DataSource = null;

                List<string> statusList = new List<string>();
                //lblHRApproved.Text
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
                DataTable resultTable = new DataTable();
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
                DataTable resultTableTrnasfer = new DataTable();
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
                DataTable resultTableTrnasferOut = new DataTable();
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
              
                objRL.Set_Approval_Colour_DataGridView(dataGridView1, lblPending, lblHRApproved, lblManagerApproved, lblRemark, lblCompleted,"ApprovalStatusId");

                int OutdoorEntryCount = dataGridView1.Rows
    .Cast<DataGridViewRow>()
    .Where(r => !r.IsNewRow)
    .Count(row =>
        row.Cells["IsOutdoorEntry"].Value != null &&
        row.Cells["OutdoorApprovalStatusId"].Value != null &&
        row.Cells["IsOutdoorEntry"].Value.ToString() == "1" &&
        row.Cells["OutdoorApprovalStatusId"].Value.ToString() == "1");

                lblOutdoorEntryCount.Text = "Outdoor Pending-"+OutdoorEntryCount.ToString();

                //MessageBox.Show(lblHRApproved.Text);
            }

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.Black;
        }


        List<int> list = new List<int>();

        int TotalCount = 0, PendingFlag = 1, CompletedFlag = 2, RemarksFlag = 3, HRApprovedFlag = 6, ManagerApprovedFlag = 8;

        private void lblHRApproved_Click(object sender, EventArgs e)
        {
            ApprovalStatusId = 0;
            SetStatusAndFill(6);
        }

        private void lblManagerApproved_Click(object sender, EventArgs e)
        {
            ApprovalStatusId = 0;
            SetStatusAndFill(8);
        }

        private void lblRemark_Click(object sender, EventArgs e)
        {
            ApprovalStatusId = 0;
            SetStatusAndFill(3);
        }

        private void lblCompleted_Click(object sender, EventArgs e)
        {
            ApprovalStatusId = 0;
            SetStatusAndFill(2);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            objRL.Set_Approval_Colour_DataGridView(dataGridView1, lblPending, lblHRApproved, lblManagerApproved, lblRemark, lblCompleted, "ApprovalStatusId");
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void ClearCount()
        {
            TotalCount = 0; PendingFlag = 0; CompletedFlag = 0; RemarksFlag = 0; HRApprovedFlag = 0; ManagerApprovedFlag = 0;
        }
        private void lblPending_Click(object sender, EventArgs e)
        {
            ApprovalStatusId = 0;
            SetStatusAndFill(1);
        }

        private void lblTotalCount_Click(object sender, EventArgs e)
        {
            ApprovalStatusId = 0;
            SetStatusAndFill(0);
        }

        int ApprovalStatusId = 0;

        private void SetStatusAndFill(int status)
        {
            ClearCount();
            ApprovalStatusId = 0;

            if (status == 1)
                ApprovalStatusId = 1;
            else if (status == 2)
                ApprovalStatusId = 2;
            else if (status == 3)
                ApprovalStatusId = 3;
            else if (status == 6)
                ApprovalStatusId = 6;
            else if (status == 8)
                ApprovalStatusId = 8;
            else if (status == 0)
                ApprovalStatusId = 0;
            else
                ApprovalStatusId = 0;

            FillGrid();
        }

        //enum StatusType
        //{
        //    ApprovalStatusId = 1,
        //    ApprovalStatusId = 2
        //}


        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            bool FlagOpen = false; int NFlagCount = 0;
            list = null; list = new List<int>();
            if (e.Button == MouseButtons.Right)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        int RI = dataGridView1.SelectedRows[i].Index;


                        int NFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[RI].Cells[0].Value)));
                        //int index = dataGridView1.SelectedRows[i].Index;
                        int EmployeeId_Grid = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.SelectedRows[i].Cells[0].Value)));
                        list.Add(EmployeeId_Grid);

                        if (NFlag == 1)
                            NFlagCount++;

                        //    FlagOpen = true;
                    }
                }

                ContextMenu m = new ContextMenu();
                //(gridcontextMenu.Items[1] as ToolStripMenuItem).DropDownItems.Add("Tiger", new EventHandler(SubmenuItem_Click));
                //(gridcontextMenu.Items[1] as ToolStripMenuItem).DropDownItems.Add("Lion", image_source, new EventHandler(SubmenuItem_Click));
                //(gridcontextMenu.Items[1] as ToolStripMenuItem).DropDownItems.Add("Elephant", image_source, new EventHandler(SubmenuItem_Click));

                MySqlConnection conn = new MySqlConnection(objBL.conString);
                MySqlCommand cmd = new MySqlCommand("select AttendanceStatus from attendancestatusmaster where CancelTag=0 ", conn);

                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string menuText = reader["AttendanceStatus"].ToString();

                    m.MenuItems.Add(menuText, new EventHandler(SubmenuItem_Click));
                }

                reader.Close();
                conn.Close();

                //if (NFlagCount > 0)
                //    m.MenuItems.Add("Update Location and Department", new EventHandler(SubmenuItem_Click));

                //m.MenuItems.Add("Update Contractor", new EventHandler(SubmenuItem_Click));
                //m.MenuItems.Add("Update Shift Group", new EventHandler(SubmenuItem_Click));
                //m.MenuItems.Add("Update Category", new EventHandler(SubmenuItem_Click));
                //m.MenuItems.Add("Update Designation", new EventHandler(SubmenuItem_Click));
                //m.MenuItems.Add("Update Status", new EventHandler(SubmenuItem_Click));
                //m.MenuItems.Add("Update Job Profile", new EventHandler(SubmenuItem_Click));
                //m.MenuItems.Add("Update Employment Type", new EventHandler(SubmenuItem_Click));

                //m.MenuItems.Add("Update Over Time Applicable", new EventHandler(SubmenuItem_Click));
                //m.MenuItems.Add("Update Flexible Hours", new EventHandler(SubmenuItem_Click));
                //m.MenuItems.Add("Save New Employee", new EventHandler(SubmenuItem_Click));

                //m.MenuItems.Add(new MenuItem("Copy"));
                //m.MenuItems.Add(new MenuItem("Paste"));

                //int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

                //if (currentMouseOverRow >= 0)
                //{
                //    m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
                //}

                m.Show(dataGridView1, new Point(e.X, e.Y));

                //var hti = dataGridView1.HitTest(e.X, e.Y);
                ////dataGridView1.ClearSelection();
                ////dataGridView1.Rows[hti.RowIndex].Selected = true;

                //for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                //{
                //    int index = dataGridView1.SelectedRows[i].Index;

                //    //if (yourDGV.SelectedRows.Count > 0)
                //    //{

                //    //}
                //}
            }
        }

        private void SubmenuItem_Click(object sender, EventArgs e)
        {
            var clickedMenuItem = sender as MenuItem;
            var menuText = clickedMenuItem.Text;

            if (list.Count > 0)
            {
                Result = 0;
                for (int i=0; i< list.Count;i++)
                {

                    int ID = Convert.ToInt32(list[i]);
                    //objBL.Query = "update attendancelogs set "+
                    //              "ApprovalStatusId=(seletct AttendanceStatusId from attendancestatusmaster where AttendanceStatus='"+ menuText + "' and CancelTag=0) "+
                    //              "where CancelTag=0 AND AttendanceLogId="+ ID + " ";
                   

                    objBL.Query = "UPDATE attendancelogs "+
                                  "SET ApprovalStatusId = ( "+
                                  "SELECT AttendanceStatusId  "+
                                  "FROM attendancestatusmaster  "+
                                  "WHERE AttendanceStatus='"+ menuText + "'  "+
                                  "AND CancelTag = 0  "+
                                  ") " +
                                  "WHERE CancelTag = 0  "+
                                  "AND AttendanceLogId = "+ ID + " ";
                    Result += objBL.Function_ExecuteNonQuery();
                }
                if (Result > 0)
                {
                    objRL.ShowMessage(8, 1);
                    FillGrid();
                }
            }

            //CommanEdit objForm = new CommanEdit(list, menuText);
            //objForm.ShowDialog(this);
            //Set_Query();
            //switch (menuText)
            //{
            //    case "Tiger":
            //        break;

            //    case "Lion":
            //        break;
            //}
        }

        private void Set_Query()
        {
            //if (!SearchFlagCode && !SearchFlag)
            //{
            //}
        }

        private void FillGrid_OLD()
        {
            MainQuery = string.Empty;
            WhereClause = string.Empty;
            OrderByClause = string.Empty;

            DataTable dt = new DataTable();

            MainQuery = "select " +
                        "AttendanceLogId," +
                        "DATE_FORMAT(AttendanceDate, '%d/%m/%Y') AS AttendanceDate," +
                        "EmployeeCode," +
                        "EmployeeId," +
                        "ContractorId," +
                        "LocationId," +
                        "DepartmentId, " +
                        "CategoryId, " +
                        "DesignationId, " +
                        "JobProfile, " +
                        "ShiftGroupId, " +
                        "OverTimeApplicable, " +
                        "TIME_FORMAT(SEC_TO_TIME(InTime * 60), '%H:%i') AS InTime," +
                        "TIME_FORMAT(SEC_TO_TIME(OutTime * 60), '%H:%i') AS OutTime," +
                        "TIME_FORMAT(SEC_TO_TIME(Duration * 60), '%H:%i') AS Duration," +  
                        "TIME_FORMAT(SEC_TO_TIME(OverTime * 60), '%H:%i') AS OverTime," +  
                        "Status, " +
                        "Present, " +
                        "HalfDay, " +
                        "Absent, " +
                        "ShiftId, " +
                        "ShiftBeginTime, " +
                        "ShiftEndTime, " +
                        "ShiftFName, " +
                        "ShiftDuration, " +
                        "MissedInPunch, " +
                        "MissedOutPunch, " +
                        "PunchRecords, " +
                        "LateBy, " +
                        "EarlyBy, " +
                        "LossOfHours, " +
                        "LeaveTypeId, " +
                        "LeaveType, " +
                        "LeaveDuration, " +
                        "LeaveRemarks, " +
                        "IsCompOff, " +
                        "IsCompOffUsed, " +
                        "CompOffRemarks, " +
                        "CompOffUsedRemarks, " +
                        "IsEdit, " +
                        "Remarks, " +
                        "EditRemarks, " +
                        "HRRemarks, " +
                        "InchargeRemarks, " +
                        "ManagerRemarks, " +
                        "OtherRemarks, " +
                        "IsFlexibleHoursFlag, " +
                        "FinancialYearId, " +
                        "IsRoll, " +
                        "OutDoorEntryFlag, " +
                        "ChangeDepartmentFlag, " +
                        "ChangeLocationtId, " +
                        "ChangeDepartmentId " +
                        " from attendancelogs where CancelTag=0 ";

            WhereClause += " and AttendanceDate='" + dtpAttenanceDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            if (!cbLocation.Checked)
            {
                LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                WhereClause = " and LocationId=" + LocationId + "";
            }
            if (!cbDepartment.Checked)
            {
                DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                WhereClause += " and DepartmentId=" + DepartmentId + "";
            }

            OrderByClause = " order by EmployeeCode asc"; ;

            //WhereClause = BusinessResources.AttendanceRecord_Where + " and arm.ApprovedFlag=3 " + WhereClause;

            //objQL.ColumnNames_V = BusinessResources.AttendanceRecord_Column;
            //objQL.TableNames_V = BusinessResources.AttendanceRecord_Table;
            //objQL.WhereClause_V = WhereClause;
            //objQL.OrderBy_V = " order by E.EmployeeName asc";
            //objQL.GroupBy_V = "";

            //dt = objQL.SP_Attendance_Report_Query_DataTable();


            objBL.Query = MainQuery + WhereClause + OrderByClause;
            dt= objBL.ReturnDataTable();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //AR.AttendanceRecordId,
                    //AR.AttendanceRecordMasterId,
                    //AR.AttendanceId, 
                    //AR.EmployeeId, 
                    //E.EmployeeName as 'Employee Name',
                    //AR.ShiftId, 
                    //AR.InTime, 
                    //AR.OutTime, 
                    //AR.Duration, 
                    //AR.OverTime, 
                    //AR.TotalDuration, 
                    //AR.OTByChange, 
                    //AR.Status, 
                    //AR.WorkingTransfer, 
                    //AR.InchargeRemark, 
                    //AR.LeaveApplication, 
                    //AR.LateComming, 
                    //AR.Remarks, 
                    //AR.LateBy, 
                    //AR.EarlyBy,
                    //AR.UserId

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                    dataGridView1.Rows[i].Cells["clmAttendanceRecordId"].Value = dt.Rows[i]["AttendanceRecordId"].ToString();
                    dataGridView1.Rows[i].Cells["clmAttendanceRecordMasterId"].Value = dt.Rows[i]["AttendanceRecordMasterId"].ToString();
                    dataGridView1.Rows[i].Cells["clmAttendanceId"].Value = dt.Rows[i]["AttendanceId"].ToString();
                    dataGridView1.Rows[i].Cells["clmLocation"].Value = dt.Rows[i]["LocationName"].ToString();
                    dataGridView1.Rows[i].Cells["clmDepartment"].Value = dt.Rows[i]["Department"].ToString();
                    dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = dt.Rows[i]["EmployeeId"].ToString();
                    dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = dt.Rows[i]["EmployeeName"].ToString();
                    dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = dt.Rows[i]["EmployeeCode"].ToString();
                    dataGridView1.Rows[i].Cells["clmShiftId"].Value = dt.Rows[i]["ShiftId"].ToString();
                    dataGridView1.Rows[i].Cells["clmShift"].Value = dt.Rows[i]["ShiftSName"].ToString();
                    dtIn = Convert.ToDateTime(dt.Rows[i]["InTime"].ToString());
                    dtOut = Convert.ToDateTime(dt.Rows[i]["OutTime"].ToString());
                    dataGridView1.Rows[i].Cells["clmInTime"].Value = dtIn.ToString("hh:mm tt");
                    dataGridView1.Rows[i].Cells["clmOutTime"].Value = dtOut.ToString("hh:mm tt");

                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["Duration"].ToString())))
                        Duration = Math.Round(Convert.ToDouble(dt.Rows[i]["Duration"].ToString()), 2);
                    else
                        Duration = 0;

                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["OverTime"].ToString())))
                        OverTime = Math.Round(Convert.ToDouble(dt.Rows[i]["OverTime"].ToString()), 2);
                    else
                        OverTime = 0;

                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["TotalDuration"].ToString())))
                        TotalDuration = Math.Round(Convert.ToDouble(dt.Rows[i]["TotalDuration"].ToString()), 2);
                    else
                        TotalDuration = 0;

                    // if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["TotalDuration"].ToString())))
                    dataGridView1.Rows[i].Cells["clmDuration"].Value = Duration.ToString();
                    dataGridView1.Rows[i].Cells["clmOverTime"].Value = OverTime.ToString();
                    dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = TotalDuration.ToString();
                    dataGridView1.Rows[i].Cells["clmOTByChange"].Value = dt.Rows[i]["OTByChange"].ToString();
                    dataGridView1.Rows[i].Cells["clmStatus"].Value = dt.Rows[i]["Status"].ToString();
                    dataGridView1.Rows[i].Cells["clmWorkingTransfer"].Value = dt.Rows[i]["WorkingTransfer"].ToString();
                    dataGridView1.Rows[i].Cells["clmInchargeRemark"].Value = dt.Rows[i]["InchargeRemark"].ToString();
                    dataGridView1.Rows[i].Cells["clmLeaveApplication"].Value = dt.Rows[i]["LeaveApplication"].ToString();
                    dataGridView1.Rows[i].Cells["clmLateComming"].Value = dt.Rows[i]["LateComming"].ToString();
                    dataGridView1.Rows[i].Cells["clmRemarks"].Value = dt.Rows[i]["Remarks"].ToString();

                    //LateBy = Convert.ToDouble(Math.Round(Convert.ToDouble(ds.Rows[i]["LateBy"].ToString()),2)/60);
                    //EarlyBy = Convert.ToDouble(Math.Round(Convert.ToDouble(ds.Rows[i]["EarlyBy"].ToString()),2)/60);

                    LateBy = Convert.ToDouble(dt.Rows[i]["LateBy"].ToString());
                    EarlyBy = Convert.ToDouble(dt.Rows[i]["EarlyBy"].ToString());

                    dataGridView1.Rows[i].Cells["clmLateBy"].Value = Math.Round(LateBy, 2).ToString();
                    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = Math.Round(EarlyBy, 2).ToString();
                    SrNo++;
                }

                //if (!string.IsNullOrEmpty(objPC.ApprovalStatus))
                //{
                //    if (objPC.ApprovalStatus == BusinessResources.STATUS_DEPARTMENT_HEAD_APPROVED)
                //        lblData.BackColor = Color.Yellow;
                //    else if (objPC.ApprovalStatus == BusinessResources.STATUS_FINAL_APPROVED)
                //        lblData.BackColor = Color.Lime;
                //    else if (objPC.ApprovalStatus == BusinessResources.STATUS_HR_APPROVED)
                //        lblData.BackColor = Color.Aqua;
                //    else
                //        lblData.BackColor = Color.White;
                //}

                //foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                //{
                //    //Here 2 cell is target value and 1 cell is Volume

                //    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells["clmLateBy"].Value)))
                //    {
                //        if (Convert.ToDouble(Myrow.Cells["clmLateBy"].Value) > 0)// Convert.ToInt32(Myrow.Cells[1].Value))// Or your condition 
                //        {
                //            Myrow.DefaultCellStyle.BackColor = Color.Yellow;
                //        }
                //    }
                //}
            }
        }


        int DepartmentId = 0, SrNo=1;
        string SearchType = string.Empty;

        private void FillGrid1()
        {
            MainQuery = string.Empty;
            WhereClause = string.Empty;

            DataTable ds = new DataTable();

            if (!cbLocation.Checked)
            {
                LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                WhereClause = " and arm.LocationId=" + LocationId + "";
            }
            if (!cbDepartment.Checked)
            {
                DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
                WhereClause += " and arm.DepartmentId=" + DepartmentId + "";
            }

            WhereClause = BusinessResources.AttendanceRecord_Where + " and arm.ApprovedFlag=3 " + WhereClause;

            objQL.ColumnNames_V = BusinessResources.AttendanceRecord_Column;
            objQL.TableNames_V = BusinessResources.AttendanceRecord_Table;
            objQL.WhereClause_V = WhereClause;
            objQL.OrderBy_V = " order by E.EmployeeName asc";
            objQL.GroupBy_V = "";

            ds = objQL.SP_Attendance_Report_Query_DataTable();

            if (ds.Rows.Count > 0)
            {
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    //AR.AttendanceRecordId,
                    //AR.AttendanceRecordMasterId,
                    //AR.AttendanceId, 
                    //AR.EmployeeId, 
                    //E.EmployeeName as 'Employee Name',
                    //AR.ShiftId, 
                    //AR.InTime, 
                    //AR.OutTime, 
                    //AR.Duration, 
                    //AR.OverTime, 
                    //AR.TotalDuration, 
                    //AR.OTByChange, 
                    //AR.Status, 
                    //AR.WorkingTransfer, 
                    //AR.InchargeRemark, 
                    //AR.LeaveApplication, 
                    //AR.LateComming, 
                    //AR.Remarks, 
                    //AR.LateBy, 
                    //AR.EarlyBy,
                    //AR.UserId

                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                    dataGridView1.Rows[i].Cells["clmAttendanceRecordId"].Value = ds.Rows[i]["AttendanceRecordId"].ToString();
                    dataGridView1.Rows[i].Cells["clmAttendanceRecordMasterId"].Value = ds.Rows[i]["AttendanceRecordMasterId"].ToString();
                    dataGridView1.Rows[i].Cells["clmAttendanceId"].Value = ds.Rows[i]["AttendanceId"].ToString();
                    dataGridView1.Rows[i].Cells["clmLocation"].Value = ds.Rows[i]["LocationName"].ToString();
                    dataGridView1.Rows[i].Cells["clmDepartment"].Value = ds.Rows[i]["Department"].ToString();
                    dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = ds.Rows[i]["EmployeeId"].ToString();
                    dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = ds.Rows[i]["EmployeeName"].ToString();
                    dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = ds.Rows[i]["EmployeeCode"].ToString();
                    dataGridView1.Rows[i].Cells["clmShiftId"].Value = ds.Rows[i]["ShiftId"].ToString();
                    dataGridView1.Rows[i].Cells["clmShift"].Value = ds.Rows[i]["ShiftSName"].ToString();
                    dtIn = Convert.ToDateTime(ds.Rows[i]["InTime"].ToString());
                    dtOut = Convert.ToDateTime(ds.Rows[i]["OutTime"].ToString());
                    dataGridView1.Rows[i].Cells["clmInTime"].Value = dtIn.ToString("hh:mm tt");
                    dataGridView1.Rows[i].Cells["clmOutTime"].Value = dtOut.ToString("hh:mm tt");

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["Duration"].ToString())))
                        Duration = Math.Round(Convert.ToDouble(ds.Rows[i]["Duration"].ToString()), 2);
                    else
                        Duration = 0;

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["OverTime"].ToString())))
                        OverTime = Math.Round(Convert.ToDouble(ds.Rows[i]["OverTime"].ToString()), 2);
                    else
                        OverTime = 0;

                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["TotalDuration"].ToString())))
                        TotalDuration = Math.Round(Convert.ToDouble(ds.Rows[i]["TotalDuration"].ToString()), 2);
                    else
                        TotalDuration = 0;

                    // if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["TotalDuration"].ToString())))
                    dataGridView1.Rows[i].Cells["clmDuration"].Value = Duration.ToString();
                    dataGridView1.Rows[i].Cells["clmOverTime"].Value = OverTime.ToString();
                    dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = TotalDuration.ToString();
                    dataGridView1.Rows[i].Cells["clmOTByChange"].Value = ds.Rows[i]["OTByChange"].ToString();
                    dataGridView1.Rows[i].Cells["clmStatus"].Value = ds.Rows[i]["Status"].ToString();
                    dataGridView1.Rows[i].Cells["clmWorkingTransfer"].Value = ds.Rows[i]["WorkingTransfer"].ToString();
                    dataGridView1.Rows[i].Cells["clmInchargeRemark"].Value = ds.Rows[i]["InchargeRemark"].ToString();
                    dataGridView1.Rows[i].Cells["clmLeaveApplication"].Value = ds.Rows[i]["LeaveApplication"].ToString();
                    dataGridView1.Rows[i].Cells["clmLateComming"].Value = ds.Rows[i]["LateComming"].ToString();
                    dataGridView1.Rows[i].Cells["clmRemarks"].Value = ds.Rows[i]["Remarks"].ToString();

                    //LateBy = Convert.ToDouble(Math.Round(Convert.ToDouble(ds.Rows[i]["LateBy"].ToString()),2)/60);
                    //EarlyBy = Convert.ToDouble(Math.Round(Convert.ToDouble(ds.Rows[i]["EarlyBy"].ToString()),2)/60);

                    LateBy = Convert.ToDouble(ds.Rows[i]["LateBy"].ToString());
                    EarlyBy = Convert.ToDouble(ds.Rows[i]["EarlyBy"].ToString());

                    dataGridView1.Rows[i].Cells["clmLateBy"].Value = Math.Round(LateBy, 2).ToString();
                    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = Math.Round(EarlyBy, 2).ToString();
                    SrNo++;
                }

                //if (!string.IsNullOrEmpty(objPC.ApprovalStatus))
                //{
                //    if (objPC.ApprovalStatus == BusinessResources.STATUS_DEPARTMENT_HEAD_APPROVED)
                //        lblData.BackColor = Color.Yellow;
                //    else if (objPC.ApprovalStatus == BusinessResources.STATUS_FINAL_APPROVED)
                //        lblData.BackColor = Color.Lime;
                //    else if (objPC.ApprovalStatus == BusinessResources.STATUS_HR_APPROVED)
                //        lblData.BackColor = Color.Aqua;
                //    else
                //        lblData.BackColor = Color.White;
                //}

                //foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                //{
                //    //Here 2 cell is target value and 1 cell is Volume

                //    if (!string.IsNullOrEmpty(Convert.ToString(Myrow.Cells["clmLateBy"].Value)))
                //    {
                //        if (Convert.ToDouble(Myrow.Cells["clmLateBy"].Value) > 0)// Convert.ToInt32(Myrow.Cells[1].Value))// Or your condition 
                //        {
                //            Myrow.DefaultCellStyle.BackColor = Color.Yellow;
                //        }
                //    }
                //}
            }
        }

        private void cbLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLocation.Checked)
            {
                cmbLocation.SelectedIndex = -1;
                cmbLocation.Enabled = false;
            }
            else
            {
                cmbLocation.SelectedIndex = -1;
                cmbLocation.Enabled = true;
            }
        }

        private void cbDepartment_CheckedChanged(object sender, EventArgs e)
        {
            cmbDepartment.DataSource = null;
            if (cbDepartment.Checked)
            {
                cmbDepartment.SelectedIndex = -1;
                cmbDepartment.Enabled = false;
            }
            else
            {
                if (cmbLocation.SelectedIndex > -1)
                {
                    
                    cmbDepartment.SelectedIndex = -1;
                    cmbDepartment.Enabled = true;
                    objRL.FillDepartment(cmbLocation, cmbDepartment);
                }
            }
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
                objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
