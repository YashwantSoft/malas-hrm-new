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
    public partial class OTApproval : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();

        PropertyClass objPC = new PropertyClass();
        AttendanceLogics objAL = new AttendanceLogics();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0, LocationId = 0;

        public OTApproval()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_OVERTIMEAPPROVAL);
            btnDelete.Text = BusinessResources.BTN_VIEW;
            
            objRL.FillLocation(cmbLocation, cmbDepartment);
            objRL.Fill_Approval_Status(cmbAttendanceStatus);
            ClearAll();
        }

        private void OTApproval_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
                objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private bool Validation()
        {
            bool RetrunFlag = false;
            objEP.Clear();

            if (!cbSelectAllLocation.Checked)
            {
                if (cmbLocation.SelectedIndex == -1)
                {
                    cmbLocation.Focus();
                    objEP.SetError(cmbLocation, "Select Location");
                    RetrunFlag = true;
                }
                else
                    RetrunFlag = false;
            }
            else
                RetrunFlag = false;

            if (!RetrunFlag)
            {
                if (!cbSelectAllDepartment.Checked)
                {
                    if (cmbDepartment.SelectedIndex == -1)
                    {
                        cmbDepartment.Focus();
                        objEP.SetError(cmbDepartment, "Select Department");
                        RetrunFlag = true;
                    }
                    else
                        RetrunFlag = false;
                }
                else
                    RetrunFlag = false;
            }

            return RetrunFlag;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                Fill_Grid_AttendanceRecord();
            }
        }

        int SrNo = 1;
        string MainQuery = string.Empty;
        string WhereClause = string.Empty;
        DateTime dtInTime, dtOutTime;
        TimeSpan TOT;

        private void SetStatusColor()
        {
            objRL.SetStatusColor(cmbAttendanceStatus, lblData);
        }

        private void Fill_Grid_AttendanceRecord()
        {
            double OTHoursTotal = 0;
            objEP.Clear();
            TOT = TimeSpan.Zero;
            lblTotalCount.Text = "";
            lblPendingCount.Text = "";
            lblOverTime.Text = "";
            lblManagerApprovedCount.Text = "";

            OTHoursTotal = 0;
            ManagerApprovedCount = 0;
            Pending_Count = 0;

            dataGridView1.Rows.Clear();
            //dataGridView1.DataSource = null;

            //if (objPC.AttendanceRecordMasterId != 0)
            //{
                //lblData.Text = objPC.AttendanceData.ToString();
                cmbAttendanceStatus.Text = objPC.ApprovalStatus;

                if (cmbAttendanceStatus.SelectedIndex > -1)
                    SetStatusColor();

                DataTable ds = new DataTable();
                WhereClause = string.Empty;
                MainQuery = string.Empty;

                //WhereClause = " and ARM.AttendanceDate='"+dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD)+ "' and E.OverTimeApplicable=1 and TIME_TO_SEC(AR.OverTime) / 3600 > 0 "; //AR.OverTime !='00:00' or AR.OverTime !='0:0'

                WhereClause = " and ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and E.OverTimeApplicable=1 and TIME_TO_SEC(AR.OverTime) / 3600 > 0 "; //AR.OverTime !='00:00' or AR.OverTime !='0:0'

            if (!cbSelectAllLocation.Checked)
                    WhereClause += " and E.LocationId=" + cmbLocation.SelectedValue + "";
                else
                    WhereClause += " and " + objQL.Get_Location_Id("Location") + " ";

                if (!cbSelectAllDepartment.Checked)
                    WhereClause += " and E.DepartmentId=" + cmbDepartment.SelectedValue + "";
                else
                    WhereClause += " and "+ objQL.Get_Location_Id("Department");

                MainQuery = "select " +
                             "AR.AttendanceRecordId," +
                             "AR.AttendanceRecordMasterId," +
                             "AR.AttendanceHistoryId," +
                             "AR.EsslAttendanceLogsId," +
                             "AR.EmployeeId," +
                             "ARM.AttendanceDate,"+
                             "E.EmployeeName," +
                             "E.EmployeeCode," +
                             "AR.ShiftId," +
                             "S.ShiftSName," +
                             "AR.ShiftGroupId," +
                             "AR.InTime," +
                             "AR.OutTime," +
                             "AR.Duration," +
                             "AR.OverTime," +
                             "AR.TotalDuration," +
                             "AR.Status," +
                             "AR.LateBy," +
                             "AR.EarlyBy," +
                             "AR.MissedInPunch," +
                             "AR.MissedOutPunch," +
                             "AR.ChangeDepartmentFlag," +
                             "AR.ChangeDepartmentId," +
                             "AR.ChangeLocationtId," +
                             "AR.LeaveTypeId," +
                             "AR.LeaveDuration," +
                             "AR.WeeklyOff," +
                             "AR.Holiday," +
                             "AR.LeaveRemarks," +
                             "AR.PunchRecords," +
                             "AR.LossOfHours," +
                             "AR.Present," +
                             "AR.Absent," +
                             "AR.Remarks," +
                             "S.ShiftDuration," +
                             "S.ShiftDurationHours," +
                             "S.BeginTime," +
                             "S.EndTime," +
                             "AR.EditFlag," +
                             "E.CategoryId," +
                             "E.ContractorId," +
                             "L.LocationName," +
                             "D.Department,"+
                             "ARM.OTApprovalFlag " +
                             " from AttendanceRecord AR inner join " +
                             " attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId inner join " +
                             " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
                             " shifts S on S.ShiftId=AR.ShiftId inner join " +
                             " locationmaster L on L.LocationId=E.LocationId inner join " +
                             " departmentmaster D on D.DepartmentId=E.DepartmentId " +
                             " where " +
                             " AR.CancelTag=0 and" +
                             " ARM.CancelTag=0 and" +
                             " E.CancelTag=0 and " +
                             " S.CancelTag=0 ";
                
                objBL.Query = MainQuery + WhereClause + "  order by ARM.AttendanceDate asc";
                ds = objBL.ReturnDataTable();

                if (ds.Rows.Count > 0)
                {
                    lblTotalCount.Text = "Total Count: " + ds.Rows.Count.ToString();

                    SrNo = 1;
                    for (int i = 0; i < ds.Rows.Count; i++)
                    {
                        //0 AR.AttendanceRecordId,
                        //1 AR.AttendanceRecordMasterId,
                        //2 AR.AttendanceHistoryId,
                        //3 AR.EsslAttendanceLogsId,
                        //4 AR.EmployeeId, 
                        //5 E.EmployeeName,
                        //6 E.EmployeeCode,
                        //7 AR.ShiftId, 
                        //8 S.ShiftSName,
                        //9 AR.ShiftGroupId,
                        //10 AR.InTime,
                        //11 AR.OutTime,
                        //12 AR.Duration,
                        //13AR.OverTime,
                        //14 AR.TotalDuration,
                        //15 AR.Status,
                        //16 AR.LateBy,
                        //17 AR.EarlyBy,
                        //18 AR.MissedInPunch,
                        //19 AR.MissedOutPunch,
                        //20 AR.ChangeDepartmentFlag,
                        //21 AR.ChangeDepartmentId,
                        //22 AR.ChangeLocationtId,
                        //23 AR.IsOnLeave,
                        //24 AR.LeaveTypeId,
                        //25 AR.LeaveDuration,
                        //26 AR.WeeklyOff,
                        //27 AR.Holiday,
                        //28 AR.LeaveRemarks,
                        //29 AR.PunchRecords,
                        //30 AR.LossOfHours,
                        //31 AR.Present,
                        //32 AR.Absent,
                        //33 AR.Remarks
                        //34  S.ShiftDuration,
                        //35 S.ShiftDurationHours,
                        //36 S.BeginTime,
                        //37 S.EndTime,
                        //38 AR.EditFlag,
                        //E.CategoryId,
                        //E.ContractorId,
                        //OTApprovalFlag

                        dataGridView1.Rows.Add();
                        int EditFlag = 0;

                        //EditFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EditFlag"])));
                        //if (EditFlag == 0)
                        //{
                        //    //objRL.Attendance_Working1();
                        //}

                        dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                        dataGridView1.Rows[i].Cells["clmOTApprovalFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OTApprovalFlag"])); //ds.Rows[i]["AttendanceRecordId"].ToString();

                        dataGridView1.Rows[i].Cells["clmAttendanceRecordId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordId"])); //ds.Rows[i]["AttendanceRecordId"].ToString();

                        DateTime dt = Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceDate"])));
                        dataGridView1.Rows[i].Cells["clmAttendanceDate"].Value = dt.ToString(BusinessResources.DATEFORMATDDMMMYYYY); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordId"])); //ds.Rows[i]["AttendanceRecordId"].ToString();

                        dataGridView1.Rows[i].Cells["clmAttendanceRecordMasterId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordMasterId"])); //ds.Rows[i]["AttendanceRecordMasterId"].ToString();
                        dataGridView1.Rows[i].Cells["clmEsslAttendanceLogsId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EsslAttendanceLogsId"])); //ds.Rows[i]["EsslAttendanceLogsId"].ToString();
                        dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeId"])); //ds.Rows[i]["EmployeeId"].ToString();
                        dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeName"])); //ds.Rows[i]["EmployeeName"].ToString();
                        dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeCode"])); //ds.Rows[i]["EmployeeCode"].ToString();

                        dataGridView1.Rows[i].Cells["clmShiftId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])); //ds.Rows[i]["ShiftId"].ToString();
                        dataGridView1.Rows[i].Cells["clmShift"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftSName"])); //ds.Rows[i]["ShiftSName"].ToString();
                        dataGridView1.Rows[i].Cells["clmShiftGroupId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftGroupId"]));

                        dataGridView1.Rows[i].Cells["clmLocation"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LocationName"]));
                        dataGridView1.Rows[i].Cells["clmDepartment"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Department"]));

                        dtInTime = Convert.ToDateTime(ds.Rows[i]["InTime"].ToString());
                        dtOutTime = Convert.ToDateTime(ds.Rows[i]["OutTime"].ToString());

                        objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["CategoryId"])));
                        objPC.ContractorId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ContractorId"])));

                        //objRL.Get_CategoriesDetails_By_Id();

                        dataGridView1.Rows[i].Cells["clmInTime"].Value = dtInTime.ToString("HH:mm");
                        dataGridView1.Rows[i].Cells["clmOutTime"].Value = dtOutTime.ToString("HH:mm");

                        //objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])));
                        dataGridView1.Rows[i].Cells["clmShiftDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDurationHours"])); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDuration"])); //ds.Rows[i]["ShiftId"].ToString();
                        dataGridView1.Rows[i].Cells["clmDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Duration"])); //Convert.ToString(ds.Rows[i]["Duration"].ToString());
                        dataGridView1.Rows[i].Cells["clmOverTime"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"]));
                        dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"]));
                        dataGridView1.Rows[i].Cells["clmStatus"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Status"]));

                        dataGridView1.Rows[i].Cells["clmLateBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"]));
                        dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"]));
                       // dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));
                        //dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));

                        //dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
                        //dataGridView1.Rows[i].Cells["clmChangeDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"]));
                        //dataGridView1.Rows[i].Cells["clmChangeLocationId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"]));

                        //objPC.LeaveType = string.Empty;
                        //objAL.LeaveDetailsEmployees();

                        //if (objPC.LeaveTypeId > 0)
                        //{
                        //    objPC.LeaveTypeId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"])));
                        //    objRL.GetLeaveDetailsEmployees_ByLeaveId();
                        //    dataGridView1.Rows[i].Cells["clmLeave"].Value = objPC.LeaveType.ToString();
                        //    dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objPC.LeaveTypeId.ToString();
                        //    dataGridView1.Rows[i].Cells["clmStatus"].Value = "L";
                        //    dataGridView1.Rows[i].Cells["clmInTime"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmOutTime"].Value = "00:00";

                        //    dataGridView1.Rows[i].Cells["clmInTime"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmOutTime"].Value = "00:00";

                        //    dataGridView1.Rows[i].Cells["clmShiftDuration"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmDuration"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmOverTime"].Value = "00:00";
                        //    dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = "00:00";

                        //    dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = "0";
                        //    dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = "0";

                        //    dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmChangeDepartmentId"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmChangeLocationId"].Value = "";

                        //    dataGridView1.Rows[i].Cells["clmPunchRecords"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmLossOfHours"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmRemarksGrid"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmChangeLocation"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmDepartmentChange"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = "0";
                        //    dataGridView1.Rows[i].Cells["clmLateBy"].Value = "0";
                        //    dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = "";
                        //}
                        //else
                        //{
                        //    dataGridView1.Rows[i].Cells["clmLeave"].Value = "";
                        //    dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = "";
                        //}

                        ////dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"]));
                        ////dataGridView1.Rows[i].Cells["clmLeaveDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveDuration"]));
                        ////dataGridView1.Rows[i].Cells["clmWeeklyOff"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["WeeklyOff"]));

                        ////dataGridView1.Rows[i].Cells["clmHoliday"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Holiday"]));
                        ////dataGridView1.Rows[i].Cells["clmLeaveRemarks"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveRemarks"]));
                        //dataGridView1.Rows[i].Cells["clmPunchRecords"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["PunchRecords"]));
                        //dataGridView1.Rows[i].Cells["clmLossOfHours"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LossOfHours"]));
                        //dataGridView1.Rows[i].Cells["clmRemarksGrid"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Remarks"]));

                        ////Leave Working
                        //objPC.EmployeeId = Convert.ToInt32(ds.Rows[i]["EmployeeId"].ToString());
                        ////objPC.CheckDate = objPC.AttendanceDate;

                        //dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
                        //objPC.ChangeDepartmentFlag = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"])));

                        //if (objPC.ChangeDepartmentFlag == 1)
                        //{
                        //    objPC.ChangeLocationtId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"])));
                        //    objPC.ChangeDepartmentId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"])));


                        //    dataGridView1.Rows[i].Cells["clmChangeLocation"].Value = objRL.Fill_Location_By_LocationId(objPC.ChangeLocationtId);
                        //    dataGridView1.Rows[i].Cells["clmDepartmentChange"].Value = objRL.Fill_Department_By_DepartmentId(objPC.ChangeDepartmentId);
                        //}

                        //dtpAttendanceDate.Value = objPC.AttendanceDate;

                        objPC.LateBy = 0;
                        objPC.LateBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"])));
                        dataGridView1.Rows[i].Cells["clmLateBy"].Value = objPC.LateBy.ToString();

                        objPC.EarlyBy = 0;
                        objPC.EarlyBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"])));
                        dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objPC.EarlyBy.ToString();

                        
                        //if (objPC.LateBy > 0)
                        //{
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.FromName(BusinessResources.LS_Error_Color));
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.FromName(BusinessResources.LS_Error_Color));
                        //}
                        //else
                        //{
                        //    dataGridView1.Rows[i].Cells["clmLateBy"].Value = "0";
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.White);
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.White);
                        //}

                        //objPC.EarlyBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"])));
                        //dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objPC.EarlyBy.ToString();
                        //if (objPC.EarlyBy > 0)
                        //{
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.FromName(BusinessResources.LS_Error_Color));
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.FromName(BusinessResources.LS_Error_Color));
                        //}
                        //else
                        //{
                        //    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = "0";
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.White);
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.White);
                        //}

                        //objPC.MissedInPunch = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"])));
                        //dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = objPC.MissedInPunch.ToString();
                        //if (objPC.MissedInPunch > 0)
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.FromName(BusinessResources.LS_Error_Color));
                        //else
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.White);

                        //objPC.MissedOutPunch = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedOutPunch"])));
                        //dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = objPC.MissedOutPunch.ToString();
                        //if (objPC.MissedOutPunch > 0)
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmMissedOutPunch", Color.FromName(BusinessResources.LS_Error_Color));
                        //else
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmMissedOutPunch", Color.White);

                        SrNo++;

                        TOT = TimeSpan.Zero;
                        TOT = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"])));
                        OTHoursTotal += TOT.Hours;

                        //TOT = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"]));
                    }
                    
                    dataGridView1.ClearSelection();

                    objPC.AttendanceDate = dtpFromDate.Value;

                    objPC.AttendanceDay = objPC.AttendanceDate.DayOfWeek.ToString();

                    objRL.Get_Incharge_Senior_OfficerId();

                    string LName = string.Empty, DName = string.Empty;

                    if (cbSelectAllLocation.Checked)
                        LName = "ALL";
                    else
                        LName = cmbLocation.Text;

                    if (cbSelectAllDepartment.Checked)
                        DName = "ALL";
                    else
                        DName = cmbDepartment.Text;

                    objPC.AttendanceData = "Attendance From Date-" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATDDMMYYYY) + "-To Date-" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATDDMMYYYY) + System.Environment.NewLine +
                                           "Location- " + LName + System.Environment.NewLine +
                                           "Department- " + DName + System.Environment.NewLine;

                    lblData.Text = objPC.AttendanceData.ToString();
                     
                    lblOverTime.Text = "Total Over Time (in Hours) - " + OTHoursTotal.ToString();
                    //TOtal OVertime


                    string AStatus = string.Empty;
                    int OTFlag = 0;
                    foreach (DataGridViewRow Myrow in dataGridView1.Rows)
                    {

                        OTFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(Myrow.Cells["clmOTApprovalFlag"].Value)));
                        if (OTFlag == 0)
                        {
                            Pending_Count++;
                            Myrow.DefaultCellStyle.BackColor = Color.Yellow;// Color.FromName(BusinessResources.LS_Pending_Color);
                        }
                        else
                        {
                            ManagerApprovedCount++;
                            Myrow.DefaultCellStyle.BackColor = Color.Lime; //Color.FromName(BusinessResources.LS_HRApproved);
                        }
                    }

                    lblPendingCount.Text = "Pending Count: " + Pending_Count.ToString();
                    lblManagerApprovedCount.Text = "Manager Approved Count: " + ManagerApprovedCount.ToString();
                }
            //}
        }

        int Pending_Count = 0, ManagerApprovedCount = 0;
        private void cbSelectAllLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAllLocation.Checked)
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

        private void cbSelectAllDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSelectAllDepartment.Checked)
            {
                cmbDepartment.SelectedIndex = -1;
                cmbDepartment.Enabled = false;
            }
            else
            {
                cmbDepartment.SelectedIndex = -1;
                cmbDepartment.Enabled = true;
            }
        }

        private void ClearAll()
        {
            TableId = 0;
            cbSelectAllLocation.Checked = true;
            cbSelectAllDepartment.Checked = true;
            cmbLocation.Enabled = false;
            cmbLocation.Enabled = false;
            lblData.Text = "";
            lblOverTime.Text = "";
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            txtNaration.Text = "";
            cmbAttendanceStatus.SelectedIndex = -1;
            TOT = TimeSpan.Zero;
            dataGridView1.Rows.Clear();
            lblPendingCount.Text = "";
            Pending_Count = 0;
            lblManagerApprovedCount.Text = "";
            ManagerApprovedCount = 0;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                if (cmbAttendanceStatus.SelectedIndex > -1)
                {
                    //OTApprovalFlag

                    if (cmbAttendanceStatus.Text == BusinessResources.LS_ManagerApproved)
                    {
                        objPC.OTApprovalFlag = 1;

                        if (dataGridView1.Rows.Count > 0)
                        {
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                objPC.AttendanceRecordMasterId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells["clmAttendanceRecordMasterId"].Value)));
                                objBL.Query = "Update attendancerecordmaster set OTApprovalFlag=" + objPC.OTApprovalFlag + " where CancelTag=0 and AttendanceRecordMasterId=" + objPC.AttendanceRecordMasterId + " ";
                                Result= objBL.Function_ExecuteNonQuery();
                            }

                            if (Result > 0)
                            {
                                objRL.ShowMessage(7, 1);
                                ClearAll();
                            }
                        }
                    }
                }
                else
                {
                    objRL.ShowMessage(17, 4);
                    return;
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void AttendanceStatus_Call()
        {
            lblNaration.Visible = false;
            txtNaration.Visible = false;

            if (cmbAttendanceStatus.SelectedIndex > -1)
            {
                if (cmbAttendanceStatus.Text == BusinessResources.LS_Remarks)
                {
                    lblNaration.Visible = true;
                    txtNaration.Visible = true;
                }
                SetStatusColor();
            }
        }

        private void cmbAttendanceStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AttendanceStatus_Call();
        }
    }
}
