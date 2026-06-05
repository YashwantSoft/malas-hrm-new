using BusinessLayerUtility;
using SPApplication.Master;
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
    public partial class EditAttendanceRecord : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        AttendanceLogics objAL = new AttendanceLogics();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0, Pending_Count = 0, HRApproved_Count = 0, InchargeApproved_Count = 0, ManagerApproved_Count = 0, Completed_Count = 0, Remarks_Count = 0, Reject_Count = 0, SelectedCount = 0, LocationId = 0;

        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;
        string MainQuery = string.Empty;
        string WhereClause = string.Empty;

        double WorkDurationCal = 0, OverTime_Cal = 0;
        int SearchId = 0;

        public EditAttendanceRecord()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_EDITATTENDANCE);

            objRL.Fill_Location_ComboBox(cmbChangeLocation);
            objRL.Fill_Shift_ComboBox(cmbShift);
            objRL.Fill_Status_ComboBox(cmbStatus);
            objRL.Fill_Approval_Status(cmbOTStatus);
            // FillLocation();
            ClearAll();

            // objQL.Fill_Master_ComboBox(cmbLeaveType, "leavetypes");

            objRL.ColumnNameCM = "Remarks";
            //objRL.Fill_ComboBox_Comman(cmbRemarks);

            Fill_ExistingData();

            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
            {
                gbAddRemarks.Enabled = true;
                cbEditAttendance.Visible = true;
            }
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
            {
                gbAddRemarks.Enabled = true;
                cbEditAttendance.Visible = false;
            }
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER)
            {
                gbAddRemarks.Enabled = true;
                cbEditAttendance.Visible = false;
            }
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_OFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_SUPERVISOR)
            {
                gbAddRemarks.Enabled = false;
                cbEditAttendance.Visible = false;
            }
            else
            {
                gbAddRemarks.Enabled = false;
                cbEditAttendance.Visible = false;
            }
        }

        private void ClearAll()
        {
            ClearAll_EditRecords();
            gbAddRemarks.Enabled = false;
            gbEditAttendance.Enabled = false;
        }

        private void ClearAll_EditRecords()
        {
            cmbStatus.SelectedIndex = -1;
            dtpInTime.Text = "00:00";
            dtpOutTime.Text = "00:00";
            txtOverTime.Text = "00:00";
            txtLateBy.Text = "";
            txtEarlyBy.Text = "";
            txtMissedInPunch.Text = "";
            txtMissedOutPunch.Text = "";
            cmbShift.SelectedIndex = -1;
            txtShiftDuration.Text = "";
            //cmbLeaveType.SelectedIndex = -1;
            cbIsTransfer.Checked = false;
            cmbChangeLocation.SelectedIndex = -1;
            cmbChangeDepartment.SelectedIndex = -1;
            //cmbRemarks.SelectedIndex = -1;
            OT = string.Empty;
            txtRemarks.Text = "";
            txtRemarksReply.Text = "";
            gbAddRemarks.Visible = false;
            cbEditAttendance.Visible = false;
        }

        DateTime dtInTime, dtOutTime;
        static string OT;

        private void Fill_ExistingData()
        {
            objPC.OverTimeManualFlag = 0;
            txtOverTime.Text = "00:00";

            if (objPC.AttendanceRecordId != 0)
            {
                DataTable ds = new DataTable();
                ds = objQL.SP_AttendanceRecord_Get_By_AttendanceRecordId();

                if (ds.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[0]["DesignationId"].ToString())))
                    {
                        objPC.DesignationId = Convert.ToInt32(ds.Rows[0]["DesignationId"].ToString());
                        objRL.Get_Designation_Details_By_DesignationId(objPC.DesignationId);
                    }

                    //txtEmployeeNameCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EmployeeName"])); //ds.Rows[i]["EmployeeName"].ToString();
                    //txtEmployeeCodeCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EmployeeCode"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    //txtLocationNameCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LocationName"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    //txtDepartmentNameCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Department"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    //txtShiftCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftFName"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    //objRL.Fill_Shift_ComboBox(cmbShift);
                    cmbShift.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftFName"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    // S.BeginTime,
                    //S.EndTime
                    dtpShiftInTime.Value = Convert.ToDateTime(ds.Rows[0]["BeginTime"].ToString());
                    dtpShiftOutTime.Value = Convert.ToDateTime(ds.Rows[0]["EndTime"].ToString());

                    //dtpShiftInTimeCR.Value = Convert.ToDateTime(ds.Rows[0]["BeginTime"].ToString());
                    //dtpShiftOutTimeCR.Value = Convert.ToDateTime(ds.Rows[0]["EndTime"].ToString());

                    //txtShiftDurationCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftDurationHours"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    txtShiftDuration.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftDurationHours"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    //txtStatusCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Status"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    cmbStatus.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Status"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    //string ConvertInTime_S = Convert.ToString(dtpAttendanceDate.Value.ToString() + Convert.ToDateTime(ds.Rows[0]["InTime"].ToString()));


                    dtInTime = Convert.ToDateTime(ds.Rows[0]["InTime"].ToString());
                    dtOutTime = Convert.ToDateTime(ds.Rows[0]["OutTime"].ToString());

                    //dtpInTimeCR.Value = Convert.ToDateTime(dtInTime.ToString("HH:mm"));
                    dtpInTime.Value = Convert.ToDateTime(dtInTime.ToString("dd/MM/yyyy HH:mm")); // Convert.ToDateTime(dtInTime.ToString("HH:mm"));

                    //dtpOutTimeCR.Value = Convert.ToDateTime(dtOutTime.ToString("HH:mm"));
                    dtpOutTime.Value = Convert.ToDateTime(dtOutTime.ToString("dd/MM/yyyy HH:mm")); // dtOutTime; // Convert.ToDateTime(dtOutTime.ToString("HH:mm"));

                    //txtDurationCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Duration"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    txtDuration.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Duration"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    //txtTotalDurationCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["TotalDuration"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    txtTotalDuration.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["TotalDuration"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    //txtOverTimeCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTime"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    DateTime OTV= Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTime"])));
                    txtOverTime.Value = Convert.ToDateTime(OTV.ToString(BusinessResources.TimeFormat_HHMM));// objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTime"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    //txtLateByCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LateBy"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    txtLateBy.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LateBy"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    //txtEarlyByCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EarlyBy"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    txtEarlyBy.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EarlyBy"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    // txtMissedInPunchCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["MissedInPunch"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    txtMissedInPunch.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["MissedInPunch"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    //txtMissedOutPunchCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["MissedOutPunch"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    txtMissedOutPunch.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["MissedOutPunch"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    objPC.LeaveType = string.Empty;
                    objAL.LeaveDetailsEmployees();

                    if (!string.IsNullOrEmpty(Convert.ToString(objPC.LeaveTypeId)))
                    {
                        //objPC.LeaveTypeId = Convert.ToInt32(ds.Rows[0]["LeaveTypeId"].ToString());

                        if (objPC.LeaveTypeId != 0)
                        {
                            //txtLeaveCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LeaveTypeId"])); //ds.Rows[i]["EmployeeCode"].ToString();
                            //txtLeaveCR.Text = objPC.LeaveType;
                            //cmbLeaveType.Text = objPC.LeaveType;
                        }
                        //txtLeave.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LeaveTypeId"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    }

                    //txtPunchRecordsCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["PunchRecords"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    //txtPunchRecords.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["PunchRecords"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    //txtRemarksCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Remarks"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    //cmbRemarks.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Remarks"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    //txtPreviousNotes.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Notes"])); //ds.Rows[i]["EmployeeCode"].ToString();

                    objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["CategoryId"])));
                    objPC.ShiftGroupId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftGroupId"])));
                    objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTimeApplicable"])));

                    objPC.Remarks = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Remarks"]));
                    objPC.RemarksReply = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Notes"]));

                    //AR.OTApprovalFlag,
                    //AR.OTApprovalStatus,
                    //AR.OTReply

                    objPC.OTApprovalFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OTApprovalFlag"])));

                    if(objPC.OTApprovalFlag ==1)
                    {
                        objPC.OTApprovalStatus = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OTApprovalStatus"]));
                        objPC.OTRemarks = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OTRemarks"]));
                        objPC.OTReply = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OTReply"]));
                        gbOTDetails.Visible = true;
                    }
                    else
                    {
                        objPC.OTApprovalStatus = "";
                        objPC.OTRemarks = "";
                        objPC.OTReply = "";
                        gbOTDetails.Visible = false;
                    }

                    txtOTRemarks.Text = objPC.OTRemarks;
                    txtOTReply.Text = objPC.OTReply;
                    cmbOTStatus.Text = objPC.OTApprovalStatus;

                    //lblData.Text = objPC.AttendanceData.ToString();
                    //SetApprovalStatusColor();
                    dtpAttendanceDate.Value = objPC.AttendanceDate;


                    objPC.OverTimeManualFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTimeManualFlag"])));
                    string OTA = string.Empty;
                    if (objPC.OverTimeApplicable == 1)
                    {
                        OTA = "Yes";
                        //cbOverTime.Checked = true;
                        cbOverTime.Enabled = true;

                        if (objPC.OverTimeManualFlag == 1)
                            cbOverTime.Checked = true;
                        else
                            cbOverTime.Checked = false;
                    }
                    else
                    {
                        OTA = "No";
                        cbOverTime.Checked = false;
                        cbOverTime.Enabled = false;
                    }
                    //Set_Attendance_Current_Records();


                    //"Total Duration:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["TotalDuration"])) + "\n" +

                    //Set_Attendance();
                    ConcatData = string.Empty;
                    //ConcatData = objPC.AttendanceData.ToString() +"\n" +

                    ConcatData = "Attendance Date:\t\t" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATDDMMMYYYY) + "\n" +
                                 "Attendance Day:\t\t" + objPC.AttendanceDate.DayOfWeek.ToString() + "\n\n" +
                                  "Location:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LocationName"])) + "\n" +
                                 "Department:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Department"])) + "\n\n" +
                                 "Employee Code:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EmployeeCode"])) + "\n" +
                                 "Employee Name:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EmployeeName"])) + "\n\n" +
                                 "Shift Begin:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["BeginTime"])) + "\n" +
                                 "Shift End:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EndTime"])) + "\n" +
                                 "Shift Name:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftFName"])) + "\n\n" +
                                 "Status:\t\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Status"])) + "\n" +
                                 "In Time:\t\t\t" + Convert.ToString(dtInTime.ToString("HH:mm")) + "\n" +
                                 "Out Time:\t\t" + Convert.ToString(dtOutTime.ToString("HH:mm")) + "\n" +
                                 "Duration:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Duration"])) + "\n\n" +
                                 "Over Time Applicable:\t" + objRL.CheckNullString(OTA) + "\n" +
                                 "Over Time:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTime"])) + "\n\n" +
                                 "Late By:\t\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LateBy"])) + "\n" +
                                 "Early By:\t\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EarlyBy"])) + "\n\n" +
                                 "Leave:\t\t\t" + objRL.CheckNullString(Convert.ToString(objPC.LeaveType)) + "\n" +
                                 "Leave Durations:\t\t" + objRL.CheckNullString(Convert.ToString(objPC.LeaveDuration)) + "\n\n" +
                                 "Punch Records:\t\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["PunchRecords"])) + "\n\n" +
                                 "Remarks:\t\t" + objRL.CheckNullString(Convert.ToString(objPC.Remarks)) + "\n\n\n\n" +
                                 "Reply:\t\t\t" + objRL.CheckNullString(Convert.ToString(objPC.RemarksReply)) + "";
                    
                    lblData.Text = ConcatData.ToString();
                    SetApprovalStatusColor();

                    if (!string.IsNullOrEmpty(Convert.ToString(objPC.Remarks)))
                    {
                        txtRemarks.Text = objRL.CheckNullString(Convert.ToString(objPC.Remarks));
                        //gbReply.Visible = true;
                    }
                    //else
                    //{
                    //    txtRemarksReply.Text = "";
                    //    txtRemarks.Text = "";
                    //    gbReply.Visible = false;
                    //}
                }
                else
                {
                    gbEditAttendance.Enabled = false;
                    //gbLeave.Enabled = false;
                    dtpInTime.Value = dtpAttendanceDate.Value;
                    dtpOutTime.Value = dtpAttendanceDate.Value;
                }
            }
        }

        string ConcatData = string.Empty;

        //private void Fill_ExistingData1()
        //{
        //    ConcatData = string.Empty;

        //    objPC.OverTimeManualFlag = 0;

        //    if (objPC.AttendanceRecordId != 0)
        //    {
        //        DataTable ds = new DataTable();
        //        ds = objQL.SP_AttendanceRecord_Get_By_AttendanceRecordId();

        //        if (ds.Rows.Count > 0)
        //        {
        //            if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[0]["DesignationId"].ToString())))
        //            {
        //                objPC.DesignationId = Convert.ToInt32(ds.Rows[0]["DesignationId"].ToString());
        //                objRL.Get_Designation_Details_By_DesignationId(objPC.DesignationId);
        //            }




        //            //txtEmployeeNameCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EmployeeName"])); //ds.Rows[i]["EmployeeName"].ToString();
        //            //txtEmployeeCodeCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EmployeeCode"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //            //txtLocationNameCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LocationName"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //            //txtDepartmentNameCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Department"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            //txtShiftCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftFName"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            //objRL.Fill_Shift_ComboBox(cmbShift);
        //            cmbShift.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftFName"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            // S.BeginTime,
        //            //S.EndTime
        //            dtpShiftInTime.Value = Convert.ToDateTime(ds.Rows[0]["BeginTime"].ToString());
        //            dtpShiftOutTime.Value = Convert.ToDateTime(ds.Rows[0]["EndTime"].ToString());

        //            //dtpShiftInTimeCR.Value = Convert.ToDateTime(ds.Rows[0]["BeginTime"].ToString());
        //            //dtpShiftOutTimeCR.Value = Convert.ToDateTime(ds.Rows[0]["EndTime"].ToString());

        //            //txtShiftDurationCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftDurationHours"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //            txtShiftDuration.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftDurationHours"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            //txtStatusCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Status"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //            cmbStatus.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Status"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            //string ConvertInTime_S = Convert.ToString(dtpAttendanceDate.Value.ToString() + Convert.ToDateTime(ds.Rows[0]["InTime"].ToString()));


        //            dtInTime = Convert.ToDateTime(ds.Rows[0]["InTime"].ToString());
        //            dtOutTime = Convert.ToDateTime(ds.Rows[0]["OutTime"].ToString());

        //            //dtpInTimeCR.Value = Convert.ToDateTime(dtInTime.ToString("HH:mm"));
        //            dtpInTime.Value = Convert.ToDateTime(dtInTime.ToString("dd/MM/yyyy HH:mm")); // Convert.ToDateTime(dtInTime.ToString("HH:mm"));

        //            //dtpOutTimeCR.Value = Convert.ToDateTime(dtOutTime.ToString("HH:mm"));
        //            dtpOutTime.Value = Convert.ToDateTime(dtOutTime.ToString("dd/MM/yyyy HH:mm")); // dtOutTime; // Convert.ToDateTime(dtOutTime.ToString("HH:mm"));

        //            //txtDurationCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Duration"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //            txtDuration.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Duration"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            //txtTotalDurationCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["TotalDuration"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //            txtTotalDuration.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["TotalDuration"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            //txtOverTimeCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTime"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //            txtOverTime.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTime"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            //txtLateByCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LateBy"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //            txtLateBy.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LateBy"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            //txtEarlyByCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EarlyBy"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //            txtEarlyBy.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EarlyBy"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            //txtMissedInPunchCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["MissedInPunch"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //            txtMissedInPunch.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["MissedInPunch"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            //txtMissedOutPunchCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["MissedOutPunch"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //            txtMissedOutPunch.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["MissedOutPunch"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            objPC.LeaveType = string.Empty;
        //            objAL.LeaveDetailsEmployees();

        //            if (!string.IsNullOrEmpty(Convert.ToString(objPC.LeaveTypeId)))
        //            {
        //                //objPC.LeaveTypeId = Convert.ToInt32(ds.Rows[0]["LeaveTypeId"].ToString());

        //                if (objPC.LeaveTypeId != 0)
        //                {
        //                    txtLeaveCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LeaveTypeId"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //                    txtLeaveCR.Text = objPC.LeaveType;
        //                    cmbLeaveType.Text = objPC.LeaveType;
        //                }
        //                //txtLeave.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LeaveTypeId"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //            }

        //            txtPunchRecordsCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["PunchRecords"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //            //txtPunchRecords.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["PunchRecords"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            txtRemarksCR.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Remarks"])); //ds.Rows[i]["EmployeeCode"].ToString();
        //            cmbRemarks.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Remarks"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            txtPreviousNotes.Text = objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Notes"])); //ds.Rows[i]["EmployeeCode"].ToString();

        //            objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["CategoryId"])));
        //            objPC.ShiftGroupId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftGroupId"])));
        //            objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTimeApplicable"])));

        //            lblData.Text = objPC.AttendanceData.ToString();
        //            SetApprovalStatusColor();
        //            dtpAttendanceDate.Value = objPC.AttendanceDate;


        //            objPC.OverTimeManualFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTimeManualFlag"])));

        //            if (objPC.OverTimeApplicable == 1)
        //            {
        //                //cbOverTime.Checked = true;
        //                cbOverTime.Enabled = true;

        //                if (objPC.OverTimeManualFlag == 1)
        //                    cbOverTime.Checked = true;
        //                else
        //                    cbOverTime.Checked = false;
        //            }
        //            else
        //            {
        //                cbOverTime.Checked = false;
        //                cbOverTime.Enabled = false;
        //            }

        //            ConcatData = "Location:\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LocationName"])) + "\n" +
        //                          "Department:\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Department"])) + "\n" +
        //                          "Employee Code:\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EmployeeCode"])) + "\n" +
        //                          "Employee Name:\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EmployeeName"])) + "\n" +

        //                          "Shift Name:\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["ShiftFName"])) + "\n" +
        //                          "Shift Begin:\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["BeginTime"])) + "\n" +
        //                          "Shift End:\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EndTime"])) + "\n\n" +
        //                          "Status:\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Status"])) + "\n" +
        //                          "In Time:\t" + Convert.ToDateTime(dtInTime.ToString("HH:mm")) + "\n" +
        //                          "Out Time:\t" + Convert.ToDateTime(dtOutTime.ToString("HH:mm")) + "\n" +
        //                          "Duration:\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["Duration"])) + "\n" +
        //                          "Total Duration:\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["TotalDuration"])) + "\n" +
        //                          "Over Time:\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["OverTime"])) + "\n" +
        //                          "Late By:\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["LateBy"])) + "\n" +
        //                          "Early By:\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["EarlyBy"])) + "\n" +
        //                          "Punch Records:\t" + objRL.CheckNullString(Convert.ToString(ds.Rows[0]["PunchRecords"])) + "";

        //            lblData.Text = ConcatData.ToString();
        //            //Set_Attendance_Current_Records();
        //            //Set_Attendance();
        //        }
        //        else
        //        {
        //            gbEditRecord.Enabled = false;
        //            gbLeave.Enabled = false;
        //            dtpInTime.Value = dtpAttendanceDate.Value;
        //            dtpOutTime.Value = dtpAttendanceDate.Value;
        //        }
        //    }
        //}

        private void SetApprovalStatusColor()
        {
            if (!string.IsNullOrEmpty(objPC.ApprovalStatus))
            {
                if (objPC.ApprovalStatus == BusinessResources.LS_Pending)
                    lblData.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                else if (objPC.ApprovalStatus == BusinessResources.LS_HRApproved)
                    lblData.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
                else if (objPC.ApprovalStatus == BusinessResources.LS_InchargeApproved)
                    lblData.BackColor = Color.FromName(BusinessResources.LS_InchargeApproved_Color);
                else if (objPC.ApprovalStatus == BusinessResources.LS_ManagerApproved)
                    lblData.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
                else if (objPC.ApprovalStatus == BusinessResources.LS_Completed)
                    lblData.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
                else if (objPC.ApprovalStatus == BusinessResources.LS_Remarks)
                    lblData.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
                else if (objPC.ApprovalStatus == BusinessResources.LS_Reject)
                    lblData.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
                else
                    lblData.BackColor = Color.White;

                //lblPending.BackColor = Color.FromName(BusinessResources.LS_Pending_Color);
                //lblHRApproved.BackColor = Color.FromName(BusinessResources.LS_HRApproved_Color);
                //lblInchargeApproved.BackColor = Color.FromName(BusinessResources.LS_InchargeApproved_Color);
                //lblManagerApproved.BackColor = Color.FromName(BusinessResources.LS_Manager_Color);
                //lblReject.BackColor = Color.FromName(BusinessResources.LS_Reject_Color);
                //lblRemark.BackColor = Color.FromName(BusinessResources.LS_Remarks_Color);
                //lblCompleted.BackColor = Color.FromName(BusinessResources.LS_Completed_Color);
                //lblError.BackColor = Color.FromName(BusinessResources.LS_Error_Color);
            }
        }

        private void FillLocation()
        {
            btnSave.Visible = false;
            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
                objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + " ";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
                objQL.WhereClause_V = " and lwd.PlantHeadId=" + SearchId + " ";
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
            {
                btnSave.Visible = true;
                objQL.WhereClause_V = "";
            }
            else
            {
                objRL.ShowMessage(38, 4);
                return;
            }

            objQL.Fill_Location_By_EmployeeId(cmbChangeLocation);

            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
            {
                cmbChangeLocation.Text = BusinessLayer.LocationName;
                FillDepartment();
                cmbChangeDepartment.Text = BusinessLayer.Department;
            }
            else
            {
                cmbChangeLocation.Enabled = true;
                cmbChangeLocation.SelectedIndex = -1;
                cmbChangeDepartment.SelectedIndex = -1;
            }
        }

        //private void FillDepartment()
        //{
        //    if (cmbLocation.SelectedIndex > -1)
        //    {
        //        LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
        //        objPC.LocationId = LocationId;
        //        objPC.InchargeId = BusinessLayer.EmployeeLoginId_Static;
        //        objQL.WhereClause_V = string.Empty;

        //        if (BusinessLayer.UserType == BusinessResources.USER_TYPE_INCHARGE)
        //            objQL.WhereClause_V = " and lwd.InchargeId=" + SearchId + "  and lwd.LocationId=" + objPC.LocationId + " ";
        //        else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER)
        //            objQL.WhereClause_V = " and lwd.PlantHeadId=" + SearchId + " and lwd.LocationId=" + objPC.LocationId + " ";
        //        else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN)
        //            objQL.WhereClause_V = " and lwd.LocationId=" + objPC.LocationId + " ";
        //        else
        //        {
        //            objRL.ShowMessage(38, 4);
        //            return;
        //        }
        //        objQL.Fill_Department_By_EmployeeId(cmbDepartment);
        //    }
        //}

        private void FillDepartment()
        {
            if (cmbChangeLocation.SelectedIndex > -1)
            {
                LocationId = Convert.ToInt32(cmbChangeLocation.SelectedValue);
                objPC.LocationId = LocationId;
                objQL.Fill_Department_By_LocationId(cmbChangeDepartment);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void EditAttendanceRecord_Load(object sender, EventArgs e)
        {
            //dtpInTime.Format = DateTimePickerFormat.Custom;
            //dtpInTime.CustomFormat = "HH:mm";
            //dtpOutTime.CustomFormat = "HH:mm";

            dtpInTime.Format = DateTimePickerFormat.Custom;
            dtpInTime.CustomFormat = "dd/MM/yyyy HH:mm";

            dtpOutTime.Format = DateTimePickerFormat.Custom;
            dtpOutTime.CustomFormat = "dd/MM/yyyy HH:mm";
           

            //dtpInTime.CustomFormat = DateTimePickerFormat.Custom.ToString("HH:mm");

            gbAddRemarks.Visible = false;
            gbEditAttendance.Visible = false;
            gbEditAttendance.Enabled = false;
            gbAddRemarks.Enabled = false;
            txtRemarks.Enabled = false;

            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER) // || BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
            {
                gbAddRemarks.Visible = true;
                gbEditAttendance.Visible = true;
                gbAddRemarks.Enabled = true;
                gbEditAttendance.Enabled = true;
                txtRemarks.Enabled = true;
            }
            else if (BusinessLayer.UserType == BusinessResources.USER_TYPE_SENIOROFFICER || BusinessLayer.UserType == BusinessResources.USER_TYPE_MANAGER || BusinessLayer.UserType == BusinessResources.USER_TYPE_PLANTHEAD)
            {
                gbAddRemarks.Visible = true;
                gbAddRemarks.Enabled = true;
                gbEditAttendance.Visible = false;
                gbEditAttendance.Enabled = false;
                txtRemarks.Enabled = true;
            }
            else
            {
                gbAddRemarks.Visible = false;
                gbAddRemarks.Enabled = false;
                gbEditAttendance.Visible = false;
                txtRemarks.Enabled = false;
            }
           
            //dtpInTime.Value = dtpAttendanceDate.Value;
            //dtpOutTime.Value = dtpAttendanceDate.Value;
        }

        private void cbIsTransfer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbIsTransfer.Checked)
            {
                gbTransferDepartment.Visible = true;
                cmbChangeLocation.Focus();
            }
            else
            {
                cmbChangeLocation.SelectedIndex = -1;
                cmbChangeDepartment.SelectedIndex = -1;
                gbTransferDepartment.Visible = false;
            }
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillDepartment();
        }

        private void btnAddRemarks_Click(object sender, EventArgs e)
        {
            CommanMaster objForm = new CommanMaster("Remarks");
            objForm.ShowDialog(this);
            //objRL.Fill_ComboBox_Comman(cmbRemarks);
        }

        private void dtpInTime_Leave(object sender, EventArgs e)
        {
            objPC.EditFlagTemp = 0;
            Set_Attendance();
        }

        private void Set_Attendance()
        {
            //objPC.ShiftGroupId = objPC.ShiftGroupId; // Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmShiftGroupId"].Value.ToString());

            objPC.InTime = dtpInTime.Value;
            objPC.OutTime = dtpOutTime.Value;

            //objRL.CalculateComman_Attendance();
            objRL.Get_CategoriesDetails_By_Id();
            objPC.LeaveTypeFlag = true;

            objPC.EditFlagTemp = 1;
            objAL.AttendanceWorking();
            //DataSet dsAutoShift = new DataSet();
            //dsAutoShift = objQL.SP_Shift_by_ShiftGroupId();
            //objRL.Get_Auto_Shift_Details(dsAutoShift);

            if (objPC.ShiftId != 0)
            {
                dtpShiftInTime.Value = objPC.BeginTime_Shift_DT;
                dtpShiftOutTime.Value = objPC.EndTime_Shift_DT;

                //objRL.OT_Calculations();
                //objRL.LateBy_And_Early_Calculation();
                //objRL.MissedPunchIn_Calculations();
                //objRL.MissedPunchOut_Calculations();
                cmbShift.Text = objPC.ShiftName;
                txtShiftDuration.Text = objPC.Duration;
                txtDuration.Text = objPC.Duration.ToString();
                txtTotalDuration.Text = objPC.TotalDuration.ToString();
                txtOverTime.Text = objPC.OverTime.ToString();
                txtLateBy.Text = objPC.LateBy.ToString();
                txtEarlyBy.Text = objPC.EarlyBy.ToString();
                txtLateBy.Text = objPC.LateBy.ToString();
                txtEarlyBy.Text = objPC.EarlyBy.ToString();

                cmbStatus.Text = objPC.StatusCode;
            }
        }

        private void Set_Attendance_Current_Records()
        {
            //objPC.ShiftGroupId = objPC.ShiftGroupId; // Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmShiftGroupId"].Value.ToString());

            //objPC.InTime = dtpInTimeCR.Value;
            //objPC.OutTime = dtpOutTimeCR.Value;

            DataSet dsAutoShift = new DataSet();
            dsAutoShift = objQL.SP_Shift_by_ShiftGroupId();

            //objRL.Get_Auto_Shift_Details(dsAutoShift);

            if (objPC.ShiftId != 0)
            {
                //dtpShiftInTimeCR.Value = objPC.BeginTime_Shift_DT;
                //dtpShiftOutTimeCR.Value = objPC.EndTime_Shift_DT;

                //objRL.OT_Calculations();
                //objRL.LateBy_And_Early_Calculation();
                //objRL.MissedPunchIn_Calculations();
                //objRL.MissedPunchOut_Calculations();

                //txtShiftCR.Text = objPC.ShiftName;
                //txtShiftCR.Text = objRL.CheckNullString(Convert.ToString(objPC.ShiftName));
                cmbShift.Text = objRL.CheckNullString(Convert.ToString(objPC.ShiftName));
                //txtShiftDurationCR.Text = objPC.ShiftDuration;
                //txtShiftDurationCR.Text = objRL.CheckNullString(Convert.ToString(objPC.ShiftDuration));
                txtShiftDuration.Text = objRL.CheckNullString(Convert.ToString(objPC.ShiftDuration));
                //txtDurationCR.Text = objPC.Duration.ToString();
                //txtDurationCR.Text = objRL.CheckNullString(Convert.ToString(objPC.Duration));
                txtDuration.Text = objRL.CheckNullString(Convert.ToString(objPC.Duration));
                //txtTotalDurationCR.Text = objPC.TotalDuration.ToString();        
                //txtTotalDurationCR.Text = objRL.CheckNullString(Convert.ToString(objPC.TotalDuration));
                txtTotalDuration.Text = objRL.CheckNullString(Convert.ToString(objPC.TotalDuration));

                //txtOverTimeCR.Text = objPC.OverTime.ToString();
                //txtOverTimeCR.Text = objRL.CheckNullString(Convert.ToString(objPC.OverTime));
                txtOverTime.Text = objRL.CheckNullString(Convert.ToString(objPC.OverTime));
                //txtLateByCR.Text = objPC.LateBy.ToString();
                //txtLateByCR.Text = objRL.CheckNullString(Convert.ToString(objPC.LateBy));
                txtLateBy.Text = objRL.CheckNullString(Convert.ToString(objPC.LateBy));
                //txtEarlyByCR.Text = objPC.EarlyBy.ToString();
                //txtEarlyByCR.Text = objRL.CheckNullString(Convert.ToString(objPC.EarlyBy));
                txtEarlyBy.Text = objRL.CheckNullString(Convert.ToString(objPC.EarlyBy));
                //               
                //txtLateByCR.Text = objPC.LateBy.ToString();
                //txtEarlyByCR.Text = objPC.EarlyBy.ToString();

                //txtLateByCR.Text = objPC.LateBy.ToString();
            }
        }

        private void dtpInTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //SetAttendance();
        }

        //private void SetAttendance()
        //{
        //    if (cmbStatus.SelectedIndex >-1)
        //    {
        //        objPC.StatusCode = cmbStatus.Text;

        //        if (objPC.StatusCode == "A" || objPC.StatusCode == "L" || objPC.StatusCode == "H" || objPC.StatusCode == "WO")
        //        {
        //           // objAL.Clear_Attendance();

        //            //objPC.EmployeeCode
        //            DateTime dt;
        //            dt = Convert.ToDateTime("1900-01-01 00:00:00");

        //            //objPC.ShiftId = 3;
        //            //objRL.Get_Shift_Details(objPC.ShiftId);

        //            objPC.Duration = "00:00";
        //            objPC.TotalDuration = "00:00";
        //            objPC.MissedInPunch = 0;
        //            objPC.MissedOutPunch = 0;
        //            objPC.LateBy = 0;
        //            objPC.EarlyBy = 0;
        //            objPC.Present = 0;
        //            objPC.Absent = 0;
        //            objPC.ChangeDepartmentFlag = 0;
        //            objPC.ChangeDepartmentId = 0;
        //            objPC.ChangeLocationtId = 0;
        //            objPC.InTime = dt; // "1900-01-01 00:00:00";
        //            objPC.OutTime = dt;

        //            dtpInTime.Value = dt; //"00:00";
        //            dtpOutTime.Value = dt; // "00:00";
        //            txtDuration.Text = "00:00";
        //            txtOverTime.Text = "00:00";
        //            txtTotalDuration.Text = "00:00";
        //            txtLateBy.Text = "0";
        //            txtEarlyBy.Text = "0";
        //            txtMissedInPunch.Text = "0";
        //            txtMissedOutPunch.Text = "0";
        //            cmbShift.Text = "NoShift";
        //            objAL.Get_Shift_Details_ByName_ById("Name","NoShift");
        //            txtShiftDuration.Text = "00:00";
        //            dtpShiftInTime.Value = dt;
        //            dtpShiftOutTime.Value = dt;
        //            //objPC.EndTime_Shift_DT= Convert.ToDateTime(ds.Tables[0].Rows[0]["BeginTime"].ToString());

        //            if (!cbLeave.Checked)
        //            {
        //                objPC.LeaveTypeFlag = false;
        //                cmbLeaveType.SelectedIndex = -1;
        //            }

        //            cbIsTransfer.Checked = false;
        //            cmbLocation.SelectedIndex = -1;
        //            cmbDepartment.SelectedIndex = -1;
        //            cmbRemarks.SelectedIndex = -1;
        //            //objPC.AttendanceDate
        //        }
        //    }
        //    else
        //    {

        //    }
        //}

        private void SetAttendance()
        {

            // objAL.Clear_Attendance();

            //objPC.EmployeeCode
            DateTime dt;
            dt = Convert.ToDateTime("1900-01-01 00:00:00");

            //objPC.ShiftId = 3;
            //objRL.Get_Shift_Details(objPC.ShiftId);

            objPC.Duration = "00:00";
            objPC.TotalDuration = "00:00";
            objPC.MissedInPunch = 0;
            objPC.MissedOutPunch = 0;
            objPC.LateBy = 0;
            objPC.EarlyBy = 0;
            objPC.Present = 0;
            objPC.Absent = 0;
            objPC.ChangeDepartmentFlag = 0;
            objPC.ChangeDepartmentId = 0;
            objPC.ChangeLocationtId = 0;
            objPC.InTime = dt; // "1900-01-01 00:00:00";
            objPC.OutTime = dt;

            dtpInTime.Value = dt; //"00:00";
            dtpOutTime.Value = dt; // "00:00";

            txtDuration.Text = "00:00";
            txtOverTime.Text = "00:00";
            txtTotalDuration.Text = "00:00";
            txtLateBy.Text = "0";
            txtEarlyBy.Text = "0";
            txtMissedInPunch.Text = "0";
            txtMissedOutPunch.Text = "0";
            cmbShift.Text = "NoShift";
            objAL.Get_Shift_Details_ByName_ById("Name", "NoShift");
            txtShiftDuration.Text = "00:00";
            dtpShiftInTime.Value = dt;
            dtpShiftOutTime.Value = dt;
            //objPC.EndTime_Shift_DT= Convert.ToDateTime(ds.Tables[0].Rows[0]["BeginTime"].ToString());

            //if (!cbLeave.Checked)
            //{
            //    objPC.LeaveTypeFlag = false;
            //    cmbLeaveType.SelectedIndex = -1;
            //    cmbStatus.Text = "A"; 
            //}
            //else
            //{
            //    if(cmbLeaveType.SelectedIndex >-1)
            //        cmbStatus.Text = "L";  
            //}
            cbIsTransfer.Checked = false;
            cmbChangeLocation.SelectedIndex = -1;
            cmbChangeDepartment.SelectedIndex = -1;
            //cmbRemarks.SelectedIndex = -1;
        }

        private bool ValidationSave()
        {
            objEP.Clear();
            bool RetrunFlag = false;

            //if (cmbRemarks.SelectedIndex == -1)
            //{
            //    cmbRemarks.Focus();
            //    objEP.SetError(cmbRemarks, "Select Remarks");
            //    RetrunFlag = true;
            //}
            //    else
            //    RetrunFlag = false;

            if (!RetrunFlag)
            {
                if (cmbShift.SelectedIndex == -1)
                {
                    cmbShift.Focus();
                    objEP.SetError(cmbShift, "Select Shift");
                    RetrunFlag = true;
                }
                if (!cbEditAttendance.Checked)
                {
                    cbEditAttendance.Focus();
                    objEP.SetError(cbEditAttendance, "Checked Edit Attendance");
                    RetrunFlag = true;
                }
                else
                    RetrunFlag = false;
            }

            //if (!RetrunFlag)
            //{
            //    if (cbLeave.Checked)
            //    {
            //        if(cmbLeaveType.SelectedIndex ==-1)
            //        {
            //            cmbLeaveType.Focus();
            //            objEP.SetError(cmbLeaveType, "Select Leave Type");
            //            RetrunFlag = true;
            //        }
            //        else
            //            RetrunFlag = false;
            //    }
            //    else
            //        RetrunFlag = false;
            //}

            if (!RetrunFlag)
            {
                if (cmbStatus.SelectedIndex == -1)
                {
                    cmbStatus.Focus();
                    objEP.SetError(cmbStatus, "Select Status");
                    RetrunFlag = true;
                }
                else
                    RetrunFlag = false;
            }

            if (!RetrunFlag)
            {
                if (cbIsTransfer.Checked)
                {
                    if (cmbChangeLocation.SelectedIndex == -1)
                    {
                        cmbChangeLocation.Focus();
                        objEP.SetError(cmbChangeLocation, "Select Location");
                        RetrunFlag = true;
                    }
                    else if (cmbChangeDepartment.SelectedIndex == -1)
                    {
                        cmbChangeDepartment.Focus();
                        objEP.SetError(cmbChangeDepartment, "Select Department");
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.Department == "TIME OFFICE")
            {
                if (!ValidationSave())
                {
                    //objPC.ShiftId = Convert.ToInt32(cmbShift.SelectedValue);

                    //objPC.AttendanceRecordId
                    objPC.Status = cmbStatus.Text;
                    objPC.StatusCode = cmbStatus.Text;
                    objPC.InTime = dtpInTime.Value; // "1900-01-01 00:00:00";
                    objPC.OutTime = dtpOutTime.Value;

                    //if (objPC.Status == "A" || objPC.Status == "A(OD)" || objPC.Status == "H" || objPC.Status == "HA" || objPC.Status == "WO" || objPC.Status == "WOA")
                    //    objPC.Absent = 1;
                    //else
                    //    objPC.Present = 1;

                    objPC.Duration = txtDuration.Text;
                    objPC.TotalDuration = txtTotalDuration.Text;
                    objPC.OverTime = txtOverTime.Text;
                    objPC.MissedInPunch = Convert.ToInt32(txtMissedInPunch.Text);
                    objPC.MissedOutPunch = Convert.ToInt32(txtMissedOutPunch.Text);
                    objPC.LateBy = Convert.ToInt32(txtLateBy.Text);
                    objPC.EarlyBy = Convert.ToInt32(txtEarlyBy.Text);
                    objPC.ShiftGroupId = objPC.ShiftGroupId;
                    objPC.EmployeeId = objPC.EmployeeId;
                    objPC.Status = cmbStatus.Text;
                    objPC.LeaveTypeFlag = false;

                    //objRL.Attendance_Working();
                    //objRL.Attendance_Working1();

                    objPC.EttendanceEditFormFlag = true;
                    objPC.LeaveTypeFlag = true;

                    objRL.Get_CategoriesDetails_By_Id();

                    objAL.AttendanceWorking();

                    if (cbIsTransfer.Checked)
                    {
                        objPC.ChangeDepartmentFlag = 1;
                        objPC.ChangeDepartmentId = Convert.ToInt32(cmbChangeDepartment.SelectedValue);
                        objPC.ChangeLocationtId = Convert.ToInt32(cmbChangeLocation.SelectedValue);
                        objPC.ChangeLocation =cmbChangeLocation.Text;
                        objPC.ChangeDepartment = cmbChangeDepartment.Text;
                    }
                    else
                    {
                        objPC.ChangeDepartmentFlag = 0;
                        objPC.ChangeDepartmentId = 0;
                        objPC.ChangeLocationtId = 0;
                        objPC.ChangeLocation = string.Empty;
                        objPC.ChangeDepartment = string.Empty;
                    }


                    objPC.Remarks = objRL.CheckNullString(Convert.ToString(txtRemarks.Text));
                    
                    //objPC. = objRL.CheckNullString(Convert.ToString(txtRemarks.Text));
                    //else
                    //    objPC.Remarks = "NA";

                    objPC.EditFlag = EditFlag;

                    //objPC.PunchRecords = txtPunchRecordsCR.Text;

                    if (cbOverTime.Checked)
                    {
                        objPC.OverTimeManualFlag = 1;
                        objPC.OverTime = txtOverTime.Text;
                    }
                    else
                        objPC.OverTimeManualFlag = 0;

                    objPC.RemarksReply = objRL.CheckNullString(Convert.ToString(txtRemarksReply.Text));

                    Result = objQL.SP_AttendanceRecord_Insert_Update();

                    if (Result > 0)
                    {
                        //if (cmbLeaveType.SelectedIndex > -1)
                        //    SaveLeaveApplication();

                        if (objPC.IsRevertLeave==1)
                        {
                            objBL.Query = "update leaveapplication set AttendanceFlag=1 where IsRevertLeave=1 and LeaveApplicationId="+ objPC.LeaveApplicationId + " and CancelTag=0 ";
                            Result = objBL.Function_ExecuteNonQuery();
                        }

                        objAL.Save_AttendanceMonthlyData();

                        //if (!string.IsNullOrEmpty(Convert.ToString(txtRemarksReply.Text)))
                        //{
                        //    objBL.Query = "update attendancerecord set Notes='" + txtRemarksReply.Text + "' where AttendanceRecordId=" + objPC.AttendanceRecordId + " and CancelTag=0";
                        //    Result = objBL.Function_ExecuteNonQuery();
                        //}

                        objRL.ShowMessage(7, 1);
                        ClearAll();
                        this.Dispose();
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtRemarks.Text))
                {
                    Result = 0;
                    objPC.Remarks = txtRemarks.Text;
                    objPC.Remarks = objPC.Remarks.Replace("'", "''");
                    objBL.Query = "update attendancerecord set Remarks='" + objPC.Remarks + "' where AttendanceRecordId=" + objPC.AttendanceRecordId + " and CancelTag=0";
                    Result= objBL.Function_ExecuteNonQuery();
                    if (Result > 0)
                    {
                        objRL.ShowMessage(47, 1);
                        this.Dispose();
                    }
                }
                else
                {
                    objEP.Clear();
                    objEP.SetError(txtRemarks, "Enter Remarks");
                    txtRemarks.Focus();
                    return;
                }
            }
            
        }

        int LeaveApplicationId = 0;
        private void SaveLeaveApplication()
        {
            LeaveApplicationId = 0;

            if (!CheckExist_Leave())
            {
                objPC.LeaveApplicationId = LeaveApplicationId;
                //objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                objPC.FromDate = dtpAttendanceDate.Value;
                objPC.ToDate = dtpAttendanceDate.Value;
                objPC.TotalDays = "1";
                //objPC.LeaveTypeId = Convert.ToInt32(cmbLeaveType.SelectedValue);
                //objPC.LeaveReason = cmbLeaveType.Text;
                //objPC.LeaveStatus = cmbLeaveType.Text;
                objPC.DeleteFlag = FlagDelete;
                //objPC.Remarks = cmbLeaveType.Text;
                objPC.EntryDate = dtpDate.Value;
                Result = objQL.SP_LeaveApplication_Insert_Update_Delete();
            }
        }

        private bool CheckExist_Leave()
        {
            if (!FlagDelete && TableId == 0)
            {
                DataSet ds = new DataSet();
                // objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                objPC.LeaveStatus = BusinessResources.STATUS_DEPARTMENT_HEAD_APPROVED;
                ds = objQL.SP_LeaveApplication_CheckExist();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0].ToString())))
                    {
                        LeaveApplicationId = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                        return true;
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

        private void dtpOutTime_Leave(object sender, EventArgs e)
        {
            Set_Attendance();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (objPC.AttendanceRecordId != 0)
            {
                DialogResult dr;
                dr = objRL.Delete_Record_Show_Message();
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    objBL.Query = "delete from attendancerecord where AttendanceRecordId=" + objPC.AttendanceRecordId + "";
                    Result = objBL.Function_ExecuteNonQuery();
                    if (Result > 0)
                    {
                        objRL.ShowMessage(9, 1);
                        this.Dispose();
                    }
                    btnDelete.Visible = false;
                }
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        int EditFlag = 0;
        private void cbEdit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEdit.Checked)
                EditFlag = 1;
            else
                EditFlag = 0;
        }

        private void dtpOutTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbLeaveType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Set_Leave();
        }

        //private void cbLeave_CheckedChanged(object sender, EventArgs e)
        //{

        //    if (cbLeave.Checked)
        //    {
        //        cmbLeaveType.Enabled = true;
        //        cmbLeaveType.SelectedIndex = -1;
        //        cmbLeaveType.Focus();
        //        gbEditAttendance.Enabled = false;
        //        SetAttendance();
        //    }
        //    else
        //    {
        //        objEP.Clear();
        //        cmbLeaveType.SelectedIndex = -1;
        //        cmbLeaveType.Enabled = false;
        //        gbEditAttendance.Enabled = true;
        //        Fill_ExistingData();
        //        cmbRemarks.SelectedIndex = -1;
        //    }
        //}

        //private void Set_Leave()
        //{
        //    if (cmbLeaveType.SelectedIndex > -1)
        //    {
        //        if (cmbLeaveType.Text == "NA")
        //        {
        //            objPC.LeaveTypeId = 0;
        //            objPC.LeaveTypeFlag = false;
        //        }
        //        else
        //        {
        //            objPC.LeaveTypeId = Convert.ToInt32(cmbLeaveType.SelectedValue);
        //            objPC.LeaveRemarks = cmbLeaveType.Text;
        //            objPC.LeaveType = cmbLeaveType.Text;
        //            objPC.LeaveTypeFlag = true;

        //            if (objPC.LeaveType == "Casual Leave" || objPC.LeaveType == "Paid Leave" || objPC.LeaveType == "Sick Leave" || objPC.LeaveType == "Marraige Leave" || objPC.LeaveType == "Maternity Leave" || objPC.LeaveType == "Medical Leave")
        //                objPC.StatusCode = "L";
        //            else if (objPC.LeaveType == "Compensation Off")
        //                objPC.StatusCode = "CO";
        //            else if (objPC.LeaveType == "Compensation Off Used")
        //                objPC.StatusCode = "COU";
        //            else if (objPC.LeaveType == "Revert Leave")
        //                objPC.StatusCode = "COU";
        //            else
        //                objPC.StatusCode = "L";

        //            cmbStatus.Text = objPC.StatusCode.ToString();
        //        }
        //    }
        //    else
        //    {
        //        objPC.LeaveTypeId = 0;
        //        objPC.LeaveTypeFlag = false;
        //    }
        //}

        //private void cmbRemarks_SelectionChangeCommitted(object sender, EventArgs e)
        //{
        //    if (cmbRemarks.SelectedIndex > -1)
        //    {
        //        //if (cmbRemarks.Text == "Check Leave")
        //        //{
        //        //    gbLeave.Enabled = true;
        //        //    cbLeave.Focus();
        //        //}
        //        //else 
        //        //{
        //        //    gbLeave.Enabled = false;
        //        //    gbEditAttendance.Enabled = true;
        //        //}
        //    }
        //    else
        //    {
        //        //gbLeave.Enabled = false;
        //        gbEditAttendance.Enabled = false;
        //    }
        //}

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void cbOverTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOverTime.Checked)
            {
                txtOverTime.Enabled = true;
            }
            else
            {
              //  txtOverTime.Text = "00:00";
                txtOverTime.Enabled = false;
            }
        }
         
        private void cbEditAttendance_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEditAttendance.Checked)
            {
                gbEditAttendance.Visible = true;
            }
            else
            {
                gbEditAttendance.Visible = false;
            }
        }
    }
}
