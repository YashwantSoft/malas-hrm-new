using BusinessLayerUtility;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml;
using MySqlX.XDevAPI.Common;
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
    public partial class EditAttendance : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();
        AttendanceLogics objAL=new AttendanceLogics();

        string MainQuery = string.Empty, WhereClause = string.Empty, OrderByClause = string.Empty;
        public EditAttendance()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, "EDIT ATTENDANCE");
            objQL.Fill_Master_ComboBox(cmbChangeLocation, "locationmaster");
            objRL.Fill_Location_ComboBox(cmbChangeLocation);
            objRL.Fill_Shift_ComboBox(cmbShift);
            objRL.Fill_Status_ComboBox(cmbStatus);
            objRL.Fill_Approval_Status(cmbOTStatus);
            ClearAll();
            Fill_ExistingData();
        }
        private void EditAttendance_Load(object sender, EventArgs e)
        {
            dtpInTime.Format = DateTimePickerFormat.Custom;
            dtpInTime.CustomFormat = "dd/MM/yyyy HH:mm";

            dtpOutTime.Format = DateTimePickerFormat.Custom;
            dtpOutTime.CustomFormat = "dd/MM/yyyy HH:mm";
        }

        string ConcatData = string.Empty;
        private void Fill_ExistingData()
        {
            int LocationId = 0, DepartmentId=0;
            DataTable dt = new DataTable();
            MainQuery = string.Empty; WhereClause = string.Empty; OrderByClause = string.Empty;

            //MainQuery = objPC.AttendanceLogsQuery;
            MainQuery = objPC.Get_AttendanceLogs_Query(objPC.LocationId, objPC.DepartmentId);

            WhereClause += " and AL.AttendanceDate='" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            if (!string.IsNullOrWhiteSpace(Convert.ToString(objPC.EmployeeId)))
                WhereClause += " and E.EmployeeId=" + objPC.EmployeeId + "";

            objBL.Query = MainQuery + WhereClause + OrderByClause;
            dt = objBL.ReturnDataTable();

            if (dt.Rows.Count > 0)
            {
                ConcatData = string.Empty;

                objPC.IsEditAttendance = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["IsEditAttendance"])));

                if (objPC.IsEditAttendance == 1)
                    cbEditAttendance.Checked = true;
                else
                    cbEditAttendance.Checked = false;

                //dataGridView1.DataSource = dt;

                //	0	 "AL.AttendanceLogId," +
                //	1	 "DATE_FORMAT(AL.AttendanceDate, '%d/%m/%Y') AS AttendanceDate," +
                //	2	 "AL.LocationId," +
                //	3	 "LM.LocationName as 'Location'," +
                //	4	 "AL.DepartmentId, " +
                //	5	 "DM.Department," +
                //	6	 "AL.EmployeeId," +
                //	7	 "AL.EmployeeCode," +
                //	8	 "E.EmployeeName as 'Employee Name'," +
                //	9	 "E.Gender," +
                //	10	 "AL.ContractorId," +
                //	11	 "CM.ContractorName as 'Roll Name'," +
                //	12	 "AL.CategoryId, " +
                //	13	 "C.CategoryFName as 'Weekly Off'," +
                //	14	 "AL.DesignationId, " +
                //	15	 "DES.Designation, " +
                //	16	 "AL.JobProfile, " +
                //	17	 "AL.ShiftGroupId, " +
                //	18	 "AL.OverTimeApplicable, " +
                //	19	 "AL.ShiftId, " +
                //	20	 "AL.ShiftFName as 'Shift Name'," +
                //	21	 "TIME_FORMAT(AL.ShiftBeginTime, '%H:%i') AS 'Shift Begin'," +
                //	22	 "TIME_FORMAT(AL.ShiftEndTime, '%H:%i') AS 'Shif End'," +
                //	23	 "TIME_FORMAT(SEC_TO_TIME(AL.ShiftDuration * 60), '%H:%i') AS 'Shift Duration'," +
                //	24	 "TIME_FORMAT(AL.InTime, '%H:%i') AS 'In Time'," +
                //	25	 "TIME_FORMAT(AL.OutTime, '%H:%i') AS 'Out Time'," +
                //	26	 "TIME_FORMAT(SEC_TO_TIME(AL.Duration * 60), '%H:%i') AS Duration," +
                //	27	 "TIME_FORMAT(SEC_TO_TIME(AL.OverTime * 60), '%H:%i') AS OverTime," +
                //	28	 "AL.Status, " +
                //	29	 "AL.Present, " +
                //	30	 "AL.HalfDay, " +
                //	31	 "AL.Absent, " +
                //	32	 "AL.MissedInPunch, " +
                //	33	 "AL.MissedOutPunch, " +
                //	34	 "AL.PunchRecords, " +
                //	35	 "AL.LateBy, " +
                //	36	 "AL.EarlyBy, " +
                //	37	 "AL.LossOfHours, " +
                //	38	 "AL.LeaveTypeId, " +
                //	39	 "AL.LeaveType, " +
                //	40	 "AL.LeaveDuration, " +
                //	41	 "AL.LeaveRemarks, " +
                //	42	 "AL.IsCompOff, " +
                //	43	 "AL.IsCompOffUsed, " +
                //	44	 "AL.CompOffRemarks, " +
                //	45	 "AL.CompOffUsedRemarks, " +
                //	46	 "AL.IsEdit, " +
                //	47	 "AL.Remarks, " +
                //	48	 "AL.EditRemarks, " +
                //	49	 "AL.HRRemarks, " +
                //	50	 "AL.InchargeRemarks, " +
                //	51	 "AL.ManagerRemarks, " +
                //	52	 "AL.OtherRemarks, " +
                //	53	 "AL.IsFlexibleHoursFlag, " +
                //	54	 "AL.FinancialYearId, " +
                //	55	 "AL.IsRoll, " +
                //	56	 "AL.OutDoorEntryFlag, " +
                //	57	 "AL.ChangeDepartmentFlag, " +
                //	58	 "AL.ChangeLocationtId, " +
                //	59	 "AL.ChangeDepartmentId, " +
                //	60	 "AL.ApprovalStatusId " +

                dtpAttendanceDate.Value = objPC.AttendanceDate;


                objPC.Location = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Location"]));
                objPC.Department = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Department"]));

                objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["EmployeeId"])));
                objPC.EmployeeCode = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Emp Code"])));
                objPC.EmployeeName = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Employee Name"]));

                if (!string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["In Time"])))
                    objPC.InTime = Convert.ToDateTime(dt.Rows[0]["In Time"]);

                if (!string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["Out Time"])))
                    objPC.OutTime = Convert.ToDateTime(dt.Rows[0]["Out Time"]);

                //string formattedTime = objPC.InTime.ToString("dd/MM/yyyy HH:mm");

                // objPC.InTime = DateTime.ParseExact(dt.Rows[0]["In Time"].ToString(),"yyyy-MM-dd HH:MM",System.Globalization.CultureInfo.InvariantCulture);

                //string ITIME = dt.Rows[0]["In Time"].ToString();


                objPC.Duration = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Duration"]));
                objPC.OverTime = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["OT"]));
                objPC.IsEditOvertime = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["IsEditOvertime"])));
                objPC.ChangeDepartmentFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["ChangeDepartmentFlag"])));
                objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["OverTimeApplicable"])));

                if (objPC.OverTimeApplicable == 1)
                {
                    cbOverTime.Enabled = true;
                    //txtOverTime1.Text = "00:00";
                }
                else
                {
                    cbOverTime.Enabled = false;
                    txtOverTime.Text = "00:00";

                }
                    

                if (objPC.ChangeDepartmentFlag == 1)
                {
                    //gbOtherEdit.Visible = true;
                    cbIsTransfer.Checked = true;
                    //gbTransferDepartment.Visible = true;
                }
                else
                {
                    //gbOtherEdit.Visible = false;
                    //gbTransferDepartment.Visible = false;
                    cbIsTransfer.Checked = false;
                }
                    

                txtDuration.Text = objPC.Duration.ToString();
                txtOverTime.Text = objPC.OverTime.ToString();
                txtOverTime1.Text = objPC.OverTime.ToString();

                objPC.BeginTime = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Shift Begin"]));
                objPC.EndTime = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Shift End"]));
                objPC.ShiftDuration = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Shift Duration"]));
                objPC.ShiftFName = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Shift Name"]));

                objPC.Status = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Status"]));

                objPC.LateBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Late by"])));
                objPC.EarlyBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Early by"])));

                objPC.LeaveType = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["LeaveType"]));
                objPC.LeaveDuration = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["LeaveDuration"])));

                objPC.PunchRecords = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Punch Records"]));
                objPC.HREditRemarks = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["HR Edit Remarks"]));
                //objPC.InchargeRemarks = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["InchargeRemarks"]));
                objPC.ManagerRemarks = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Manager Remarks"]));
                objPC.HRReply = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["HR Reply"]));
               // objPC.TransferRemarks = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Transfer Remarks"]));

                ConcatData = "Attendance Date:\t\t" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATDDMMMYYYY) + "\n" +
                             "Attendance Day:\t\t" + objPC.AttendanceDate.DayOfWeek.ToString() + "\n\n" +
                             "Location:\t\t" + objPC.Location + "\n" +
                             "Department:\t\t" + objPC.Department + "\n\n" +
                             "Employee Code:\t\t" + objPC.EmployeeCode + "\n" +
                             "Employee Name:\t\t" + objPC.EmployeeName + "\n\n" +
                             "Shift Begin:\t\t" + objPC.BeginTime + "\n" +
                             "Shift End:\t\t" + objPC.EndTime + "\n" +
                             "Shift Duration:\t\t" + objPC.ShiftDuration + "\n" +
                             "Shift Name:\t\t" + objPC.ShiftFName + "\n\n" +
                             "Status:\t\t\t" + objPC.Status + "\n" +
                             "In Time:\t\t\t" + objRL.Date_To_String(objPC.InTime) + "\n" +
                             "Out Time:\t\t" + objRL.Date_To_String(objPC.OutTime) + "\n" +
                             "Duration:\t\t" + objPC.Duration + "\n\n" +
                             "Over Time:\t\t" + objPC.OverTime + "\n\n" +
                             "Late By:\t\t\t" + objPC.LateBy + "\n" +
                             "Early By:\t\t\t" + objPC.EarlyBy + "\n\n" +
                             "Leave:\t\t\t" + objPC.LeaveType + "\n\n" +
                             "Leave Durations:\t\t" + objPC.LeaveDuration + "\n\n" +
                             "Punch Records:\t\t" + objPC.PunchRecords + "\n\n" +
                             "HR Edit Remarks:\t\t" + objPC.HREditRemarks + "\n" +
                             "Incharge Remarks:\t\t" + objPC.InchargeRemarks + "\n" +
                             "Manager Remarks:\t\t" + objPC.ManagerRemarks + "\n" +
                             "Transfer Remarks:\t\t" + objPC.TransferRemarks + "\n" +
                             "HR Reply:\t\t" + objPC.HRReply;
                //"Reply:\t\t\t" + objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Remarks"])) + "";

                //objPC.is



                lblExistingData.Text = ConcatData.ToString();

                objPC.IsLeaveForce = 0;
                if ((objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Status"])) == "L"))
                    cbLeaveForce.Visible = true;
                else
                    cbLeaveForce.Visible = false;


                //Set edit controls

                dtpInTime.Value = objPC.InTime;
                dtpOutTime.Value = objPC.OutTime;
                txtDuration.Text = objPC.Duration.ToString();
                txtOverTime.Text = objPC.OverTime.ToString();
                txtTotalDuration.Text = objPC.Duration.ToString();

                cmbShift.Text = objPC.ShiftFName.ToString();
                cmbStatus.Text = objPC.Status.ToString();

                dtpShiftInTime.Text = objPC.BeginTime.ToString();
                dtpShiftOutTime.Text = objPC.EndTime.ToString();
                txtShiftDuration.Text = objPC.ShiftDuration.ToString();

                txtLateBy.Text = objPC.LateBy.ToString();
                txtEarlyBy.Text = objPC.EarlyBy.ToString();

                txtHREditRemarks.Text = objPC.HREditRemarks.ToString();
                //txtTransferRemarks.Text = objPC.TransferRemarks.ToString();
                txtHRReply.Text = objPC.HRReply.ToString();
            }



                //objPC.OverTimeManualFlag = 0;
                //txtOverTime.Text = "00:00";

                //if (objPC.AttendanceRecordId != 0)
                //{
                //    DataTable ds = new DataTable();
                //    ds = objQL.SP_AttendanceRecord_Get_By_AttendanceRecordId();

                //    if (ds.Rows.Count > 0)
                //    {
                //        if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[0]["DesignationId"].ToString())))
                //        {
                //            objPC.DesignationId = Convert.ToInt32(ds.Rows[0]["DesignationId"].ToString());
                //            objRL.Get_Designation_Details_By_DesignationId(objPC.DesignationId);
                //        }

                //        //txtEmployeeNameCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EmployeeName"])); //ds.Rows[i]["EmployeeName"].ToString();
                //        //txtEmployeeCodeCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EmployeeCode"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //        //txtLocationNameCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LocationName"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //        //txtDepartmentNameCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Department"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        //txtShiftCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftFName"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        //objRL.Fill_Shift_ComboBox(cmbShift);
                //        cmbShift.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftFName"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        // S.BeginTime,
                //        //S.EndTime
                //        dtpShiftInTime.Value = Convert.ToDateTime(ds.Rows[0]["BeginTime"].ToString());
                //        dtpShiftOutTime.Value = Convert.ToDateTime(ds.Rows[0]["EndTime"].ToString());

                //        //dtpShiftInTimeCR.Value = Convert.ToDateTime(ds.Rows[0]["BeginTime"].ToString());
                //        //dtpShiftOutTimeCR.Value = Convert.ToDateTime(ds.Rows[0]["EndTime"].ToString());

                //        //txtShiftDurationCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftDurationHours"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //        txtShiftDuration.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftDurationHours"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        //txtStatusCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Status"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //        cmbStatus.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Status"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        //string ConvertInTime_S = Convert.ToString(dtpAttendanceDate.Value.ToString() + Convert.ToDateTime(ds.Rows[0]["InTime"].ToString()));


                //        dtInTime = Convert.ToDateTime(ds.Rows[0]["InTime"].ToString());
                //        dtOutTime = Convert.ToDateTime(ds.Rows[0]["OutTime"].ToString());

                //        //dtpInTimeCR.Value = Convert.ToDateTime(dtInTime.ToString("HH:mm"));
                //        dtpInTime.Value = Convert.ToDateTime(dtInTime.ToString("dd/MM/yyyy HH:mm")); // Convert.ToDateTime(dtInTime.ToString("HH:mm"));

                //        //dtpOutTimeCR.Value = Convert.ToDateTime(dtOutTime.ToString("HH:mm"));
                //        dtpOutTime.Value = Convert.ToDateTime(dtOutTime.ToString("dd/MM/yyyy HH:mm")); // dtOutTime; // Convert.ToDateTime(dtOutTime.ToString("HH:mm"));

                //        //txtDurationCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Duration"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //        txtDuration.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Duration"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        //txtTotalDurationCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["TotalDuration"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //        txtTotalDuration.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["TotalDuration"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        //txtOverTimeCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTime"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //        DateTime OTV = Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTime"])));
                //        txtOverTime.Value = Convert.ToDateTime(OTV.ToString(BusinessResources.TimeFormat_HHMM));// objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTime"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        //txtLateByCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LateBy"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //        txtLateBy.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LateBy"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        //txtEarlyByCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EarlyBy"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //        txtEarlyBy.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EarlyBy"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        // txtMissedInPunchCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["MissedInPunch"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //        txtMissedInPunch.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["MissedInPunch"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        //txtMissedOutPunchCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["MissedOutPunch"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //        txtMissedOutPunch.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["MissedOutPunch"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        objPC.LeaveType = string.Empty;
                //        objAL.LeaveDetailsEmployees();

                //        if (!string.IsNullOrEmpty(Convert.ToString(objPC.LeaveTypeId)))
                //        {
                //            //objPC.LeaveTypeId = Convert.ToInt32(ds.Rows[0]["LeaveTypeId"].ToString());

                //            if (objPC.LeaveTypeId != 0)
                //            {
                //                //txtLeaveCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LeaveTypeId"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //                //txtLeaveCR.Text = objPC.LeaveType;
                //                //cmbLeaveType.Text = objPC.LeaveType;
                //            }
                //            //txtLeave.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LeaveTypeId"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //        }

                //        //txtPunchRecordsCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["PunchRecords"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //        //txtPunchRecords.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["PunchRecords"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        //txtRemarksCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Remarks"])); //ds.Rows[i]["EmployeeCode"].ToString();
                //        //cmbRemarks.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Remarks"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        //txtPreviousNotes.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Notes"])); //ds.Rows[i]["EmployeeCode"].ToString();

                //        objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["CategoryId"])));
                //        objPC.ShiftGroupId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftGroupId"])));
                //        objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTimeApplicable"])));

                //        objPC.Remarks = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Remarks"]));
                //        objPC.RemarksReply = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Notes"]));

                //        //AR.OTApprovalFlag,
                //        //AR.OTApprovalStatus,
                //        //AR.OTReply

                //        objPC.OTApprovalFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OTApprovalFlag"])));

                //        if (objPC.OTApprovalFlag == 1)
                //        {
                //            objPC.OTApprovalStatus = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OTApprovalStatus"]));
                //            objPC.OTRemarks = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OTRemarks"]));
                //            objPC.OTReply = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OTReply"]));
                //            gbOTDetails.Visible = true;
                //        }
                //        else
                //        {
                //            objPC.OTApprovalStatus = "";
                //            objPC.OTRemarks = "";
                //            objPC.OTReply = "";
                //            gbOTDetails.Visible = false;
                //        }

                //        txtOTRemarks.Text = objPC.OTRemarks;
                //        txtOTReply.Text = objPC.OTReply;
                //        cmbOTStatus.Text = objPC.OTApprovalStatus;

                //        //lblData.Text = objPC.AttendanceData.ToString();
                //        //SetApprovalStatusColor();
                //        dtpAttendanceDate.Value = objPC.AttendanceDate;


                //        objPC.OverTimeManualFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTimeManualFlag"])));
                //        string OTA = string.Empty;
                //        if (objPC.OverTimeApplicable == 1)
                //        {
                //            OTA = "Yes";
                //            //cbOverTime.Checked = true;
                //            cbOverTime.Enabled = true;

                //            if (objPC.OverTimeManualFlag == 1)
                //                cbOverTime.Checked = true;
                //            else
                //                cbOverTime.Checked = false;
                //        }
                //        else
                //        {
                //            OTA = "No";
                //            cbOverTime.Checked = false;
                //            cbOverTime.Enabled = false;
                //        }
                //        //Set_Attendance_Current_Records();


                //        //"Total Duration:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["TotalDuration"])) + "\n" +

                //        //Set_Attendance();
                //        ConcatData = string.Empty;
                //        //ConcatData = objPC.AttendanceData.ToString() +"\n" +

                //        ConcatData = "Attendance Date:\t\t" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATDDMMMYYYY) + "\n" +
                //                     "Attendance Day:\t\t" + objPC.AttendanceDate.DayOfWeek.ToString() + "\n\n" +
                //                      "Location:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LocationName"])) + "\n" +
                //                     "Department:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Department"])) + "\n\n" +
                //                     "Employee Code:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EmployeeCode"])) + "\n" +
                //                     "Employee Name:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EmployeeName"])) + "\n\n" +
                //                     "Shift Begin:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["BeginTime"])) + "\n" +
                //                     "Shift End:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EndTime"])) + "\n" +
                //                     "Shift Name:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftFName"])) + "\n\n" +
                //                     "Status:\t\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Status"])) + "\n" +
                //                     "In Time:\t\t\t" + Convert.ToString(dtInTime.ToString("HH:mm")) + "\n" +
                //                     "Out Time:\t\t" + Convert.ToString(dtOutTime.ToString("HH:mm")) + "\n" +
                //                     "Duration:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Duration"])) + "\n\n" +
                //                     "Over Time Applicable:\t" + objRL.CheckNullString(OTA) + "\n" +
                //                     "Over Time:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTime"])) + "\n\n" +
                //                     "Late By:\t\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LateBy"])) + "\n" +
                //                     "Early By:\t\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EarlyBy"])) + "\n\n" +
                //                     "Leave:\t\t\t" + objRL.CheckNullString(Convert.ToString(objPC.LeaveType)) + "\n" +
                //                     "Leave Durations:\t\t" + objRL.CheckNullString(Convert.ToString(objPC.LeaveDuration)) + "\n\n" +
                //                     "Punch Records:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["PunchRecords"])) + "\n\n" +
                //                     "Remarks:\t\t" + objRL.CheckNullString(Convert.ToString(objPC.Remarks)) + "\n\n\n\n" +
                //                     "Reply:\t\t\t" + objRL.CheckNullString(Convert.ToString(objPC.RemarksReply)) + "";

                //        lblData.Text = ConcatData.ToString();
                //        SetApprovalStatusColor();

                //        if (!string.IsNullOrEmpty(Convert.ToString(objPC.Remarks)))
                //        {
                //            txtRemarks.Text = objRL.CheckNullString(Convert.ToString(objPC.Remarks));
                //            //gbReply.Visible = true;
                //        }
                //        //else
                //        //{
                //        //    txtRemarksReply.Text = "";
                //        //    txtRemarks.Text = "";
                //        //    gbReply.Visible = false;
                //        //}
                //    }
                //    else
                //    {
                //        gbEditAttendance.Enabled = false;
                //        //gbLeave.Enabled = false;
                //        dtpInTime.Value = dtpAttendanceDate.Value;
                //        dtpOutTime.Value = dtpAttendanceDate.Value;
                //    }
                //}
            }

        private void cbOverTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOverTime.Checked)
            {
                objPC.IsEditOvertime = 1;
                txtOverTime.Enabled = true;
            }
            else
            {
                objPC.IsEditOvertime = 0;
                //  txtOverTime.Text = "00:00";
                txtOverTime.Enabled = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbEditAttendance_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEditAttendance.Checked)
            {
                objPC.IsEditAttendance = 1;
                gbEditAttendance.Visible = true;

                dtpInTime.Value = objPC.InTime;
                dtpOutTime.Value = objPC.OutTime;

                gbAttendanceAndOTRemarksReply.Visible = true;
                gbTransferDepartment.Visible = true;
                gbOtherEdit.Visible = true;
            }
            else
            {
                objPC.IsEditAttendance = 0;
                gbEditAttendance.Visible = false;
                gbAttendanceAndOTRemarksReply.Visible = false;
                //gbTransferDepartment.Visible = false;
                gbOtherEdit.Visible = false;
            }
        }

        private void dtpOutTime_Leave(object sender, EventArgs e)
        {
            Get_Shift_Details();
        }


        private void Get_Shift_Details()
        {
            MainQuery = string.Empty;   WhereClause = string.Empty;

            if(cbLeaveForce.Checked) 
                objPC.IsLeaveForce = 1;
            else
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

            if(objPC.Status == "WOP" || objPC.Status == "P" || objPC.Status == "HD" || objPC.Status == "HP" || objPC.Status == "CO")
            {
                gbOtherEdit.Visible = true;
                //gbAttendanceAndOTRemarksReply.Visible = true;
                gbOtherEdit.Enabled = true;
            }
            else
            {
                gbOtherEdit.Visible = false;
                //gbAttendanceAndOTRemarksReply.Visible = false;
                gbOtherEdit.Enabled = false;
            }
        }

        private void cbIsTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsTransfer.Checked)
            {
                objPC.ChangeDepartmentFlag = 1;
                gbTransferDepartment.Visible = true;
                cmbChangeLocation.Focus();
            }
            else
            {
                objPC.ChangeDepartmentFlag = 0;
                cmbChangeLocation.SelectedIndex = -1;
                cmbChangeDepartment.SelectedIndex = -1;
                gbTransferDepartment.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Update all 
            //insertSql.Append("(AttendanceDate,EmployeeCode,EmployeeId,LocationId,DepartmentId,ContractorId,InTime,OutTime,Duration,Status,MissedOutPunch,MissedInPunch,PunchRecords) VALUES ");

            if (!ValidationSave())
            {
                if (objPC.AttendanceLogId > 0)
                {
                    //Edit Remarks and Tranfer

                    if (!string.IsNullOrWhiteSpace(Convert.ToString(txtHREditRemarks.Text)))
                        objPC.HREditRemarks = txtHREditRemarks.Text;

                    if (!string.IsNullOrWhiteSpace(Convert.ToString(txtHRReply.Text)))
                        objPC.HRReply = txtHRReply.Text;

                    if (!string.IsNullOrWhiteSpace(Convert.ToString(txtTransferRemarks.Text)))
                        objPC.TransferRemarks = txtTransferRemarks.Text;

                    if(cmbChangeLocation.SelectedIndex >-1)
                        objPC.ChangeLocationtId = Convert.ToInt32(cmbChangeLocation.SelectedValue);

                    if (cmbChangeDepartment.SelectedIndex > -1)
                        objPC.ChangeDepartmentId = Convert.ToInt32(cmbChangeDepartment.SelectedValue);

                    if(cbOverTime.Checked)
                        objPC.IsEditOvertime = 1;
                    else
                        objPC.IsEditOvertime = 0;

                    objBL.Query = "update attendancelogs set " +
                        " IsEditAttendance=" + objPC.IsEditAttendance + ", " +
                        " IsEditOverwrite=" + objPC.IsEditOverwrite + ", " +
                        " IsLeaveForce=" + objPC.IsLeaveForce + ", " +
                        " IsEditOvertime=" + objPC.IsEditOvertime + ", " +
                        " InTime='" + dtpInTime.Value.ToString("yyyy-MM-dd HH:mm") + "', " +
                        " OutTime='" + dtpOutTime.Value.ToString("yyyy-MM-dd HH:mm") + "', " +
                        " Duration=" + objRL.ConvertToMinutes(txtDuration.Text) + ", " +
                        " OverTime=" + objRL.ConvertToMinutes(txtOverTime.Text) + ", " +
                        " HREditRemarks='" + objPC.HREditRemarks + "', " +
                        " ChangeDepartmentFlag=" + objPC.ChangeDepartmentFlag + ", " +
                        " ChangeLocationtId=" + objPC.ChangeLocationtId + ", " +
                        " ChangeDepartmentId=" + objPC.ChangeDepartmentId + " ," +
                        " TransferRemarks='" + objPC.TransferRemarks + "', " +
                        " HRReply='" + objPC.HRReply + "' " +
                        " where AttendanceLogId=" + objPC.AttendanceLogId + " and CancelTag=0 ";

                    int Result = objBL.Function_ExecuteNonQuery();
                    if(Result>0)
                    {
                        objRL.ShowMessage(8, 1);
                        return;
                    }
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private bool ValidationSave()
        {
            objEP.Clear();

            if (!cbEditAttendance.Checked)
            {
                cbEditAttendance.Focus();
                objEP.SetError(cbEditAttendance, "Select Edit Attendance");
                return true;
            }

            if (!cbEditAttendance.Checked && txtHREditRemarks.Text.Length == 0)
            {
                cbEditAttendance.Focus();
                objEP.SetError(cbEditAttendance, "Select  Edit Attendance");
                return true;
            }

            if (cmbShift.SelectedIndex == -1)
            {
                cmbShift.Focus();
                objEP.SetError(cmbShift, "Select Shift");
                return true;
            }

            if (cmbStatus.SelectedIndex == -1)
            {
                cmbStatus.Focus();
                objEP.SetError(cmbStatus, "Select Status");
                return true;
            }

            if (cbIsTransfer.Checked)
            {
                if (cmbChangeLocation.SelectedIndex == -1)
                {
                    cmbChangeLocation.Focus();
                    objEP.SetError(cmbChangeLocation, "Select Location");
                    return true;
                }

                if (cmbChangeDepartment.SelectedIndex == -1)
                {
                    cmbChangeDepartment.Focus();
                    objEP.SetError(cmbChangeDepartment, "Select Department");
                    return true;
                }
            }

            return false; // No validation errors
        }

        private void ClearAll()
        {
            cbEditAttendance.Checked = false;
            cbEditOverwrite.Checked = false;
            cbLeaveForce.Checked = false;
            cbLeaveForce.Checked = false;
            gbOtherEdit.Visible = false;
            gbAttendanceAndOTRemarksReply.Visible = false;
            objPC.IsEditAttendance = 0;
            objPC.IsEditOverwrite = 0;
            objPC.IsLeaveForce = 0;

        }
        
        private void cbLeaveForce_CheckedChanged(object sender, EventArgs e)
        {
            objPC.IsLeaveForce = 0;

            if (cbLeaveForce.Checked)
                objPC.IsLeaveForce = 1;
            else
                objPC.IsLeaveForce = 0;
        }

        private void cbEditOverwrite_CheckedChanged(object sender, EventArgs e)
        {
            objPC.IsEditOverwrite = 0;

            if (cbEditOverwrite.Checked)
                objPC.IsEditOverwrite = 1;
            else
                objPC.IsEditOverwrite = 0;
        }

        private void cmbChangeLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillDepartment();
        }
        private void FillDepartment()
        {
            if (cmbChangeLocation.SelectedIndex > -1)
                objRL.FillDepartment(cmbChangeLocation, cmbChangeDepartment);
        }
    }
}
