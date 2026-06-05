using BusinessLayerUtility;
using DocumentFormat.OpenXml.VariantTypes;
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
    public partial class OutdoorPunch : Form
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

        public OutdoorPunch()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_OUTDOORENTRIES);
            ClearAll();
            objRL.FillLocation(cmbLocation, cmbDepartment);
            FillEmployee_Fixed();
            objRL.Fill_Shift_ComboBox(cmbShift);
            objRL.Fill_Status_ComboBox(cmbStatus);
        }

        private void FillEmployee_Fixed()
        {
            //FillEmployees_Combobox();
            ClearAll_Location_Department();

            if (cmbLocation.SelectedIndex > -1 && cmbDepartment.SelectedIndex > -1)
            {
                objQL.WhereClause_V = " and E.LocationId=" + cmbLocation.SelectedValue + "  and E.DepartmentId=" + cmbDepartment.SelectedValue + "  and DM.DesignationCategory NOT IN('" + BusinessResources.USER_TYPE_TRAINEE + "')";
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
                    //8,17,5076,23,41,19,55,100001,100002
                    if (BusinessLayer.UserName_Static == "8" || BusinessLayer.UserName_Static == "17" || BusinessLayer.UserName_Static == "19" || BusinessLayer.UserName_Static == "23" || BusinessLayer.UserName_Static == "41" || BusinessLayer.UserName_Static == "55" || BusinessLayer.UserName_Static == "5076" || BusinessLayer.UserName_Static == "100001" || BusinessLayer.UserName_Static == "100002")
                    {
                        objQL.SP_Employees_ComboBox_By_Department(cmbEmployeeName);
                        cmbEmployeeName.Text = BusinessLayer.UserName_Full_Static.ToString();
                        cmbEmployeeName.Enabled = false;
                        Fill_EmployeeDetails();
                    }
                    //BusinessLayer.Designation
                }
                else
                {
                }
                //objRL.FillEmployees();
            }
        }

        private void ClearAll_Location_Department()
        {
            cmbEmployeeName.SelectedIndex = -1;
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";

            dtpAttendanceDate.Value = DateTime.Now.Date;
            dtpInTime.Value = DateTime.Now.Date;
            dtpOutTime.Value = DateTime.Now.Date;
            gbEditAttendance.Visible = false;

            //ClearAll();
        }

        private void ClearAttendance()
        {
            cmbDepartment.SelectedIndex = -1;
            cmbEmployeeName.SelectedIndex = -1;
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";

            cmbStatus.SelectedIndex = -1;
            dtpInTime.Text = "00:00";
            dtpOutTime.Text = "00:00";
            txtOverTime.Text = "";
            txtLateBy.Text = "";
            txtEarlyBy.Text = "";
            txtMissedInPunch.Text = "";
            txtMissedOutPunch.Text = "";
            cmbShift.SelectedIndex = -1;
            txtShiftDuration.Text = "";
            cmbLocation.Focus();
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
                gbEditAttendance.Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDB();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            objEP.Clear();
            TableId = 0;
            AttendanceRecordId = 0;
            dtpAttendanceDate.Value = DateTime.Now.Date;
            dtpInTime.Value = DateTime.Now.Date;
            dtpOutTime.Value = DateTime.Now.Date;
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbEmployeeName.SelectedIndex = -1;
            txtEmployeeCode.Text = "";
            txtDesignation.Text = "";

            cmbStatus.SelectedIndex = -1;
            dtpInTime.Text = "00:00";
            dtpOutTime.Text = "00:00";
            txtOverTime.Text = "";
            txtLateBy.Text = "";
            txtEarlyBy.Text = "";
            txtMissedInPunch.Text = "";
            txtMissedOutPunch.Text = "";
            cmbShift.SelectedIndex = -1;
            txtShiftDuration.Text = "";
            txtRemarks.Text = "";

            btnDelete.Visible = false;
            cmbLocation.Focus();
        }

        private void OutdoorPunchNew_Load(object sender, EventArgs e)
        {
            dtpInTime.Format = DateTimePickerFormat.Custom;
            dtpInTime.CustomFormat = "dd/MM/yyyy HH:mm";

            dtpOutTime.Format = DateTimePickerFormat.Custom;
            dtpOutTime.CustomFormat = "dd/MM/yyyy HH:mm";

            FillGrid();
        }

        TimeSpan TOT;

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
                SearchFlag = true;
            else
                SearchFlag = false;

            FillGrid();
        }

        int AttendanceRecordId = 0;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR && BusinessLayer.UserName_Static == "50010")
            {
                try
                {
                    RowCount_Grid = dataGridView1.Rows.Count;
                    CurrentRowIndex = dataGridView1.CurrentRow.Index;
                    //cbRevertLeave.Visible = false;

                    if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                    {
                        ClearAll();
                        AttendanceRecordId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmAttendanceRecordId"].Value)));
                        objPC.AttendanceRecordMasterId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmAttendanceRecordMasterId"].Value)));
                        cmbLocation.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmLocation"].Value));
                        objRL.FillDepartment(cmbLocation, cmbDepartment);

                        cmbDepartment.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmDepartment"].Value));
                        FillEmployee_Fixed();

                        cmbEmployeeName.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmEmployeeName"].Value));
                        Fill_EmployeeDetails();

                        txtEmployeeCode.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmEmployeeCode"].Value));

                        //txtDesignation.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmDesignation"].Value));
                        txtRemarks.Text = objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmRemarksGrid"].Value));

                        dtpAttendanceDate.Value = Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmAttendanceDate"].Value)));


                        dtpInTime.Value = Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmInTime"].Value)));
                        dtpOutTime.Value = Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmOutTime"].Value)));
                        Set_Attendance();


                        if (AttendanceRecordId > 0)
                            btnDelete.Visible = true;
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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = objRL.Delete_Record_Show_Message();

            if (dr == DialogResult.Yes)
            {
                //string customDateTime = ""+ dtpAttendanceDate.Value + " 14:45"; // your custom string
                //string format = "dd-MMM-yyyy HH:mm"; // match the format of the string

                //// Parse the custom date-time string
                //DateTime parsedDate = DateTime.ParseExact(
                //    customDateTime,
                //    format,
                //    System.Globalization.CultureInfo.InvariantCulture
                //);

                //// Set to DateTimePicker
               

                //// Assuming user enters in "MM/dd/yyyy" format and time in "HH:mm"
                //string dateInput = dtpAttendanceDate.Value.ToString(); // e.g., "08/24/2025"
                //string timeInput = "00:00"; // e.g., "14:30"

                //DateTime userDateTime = DateTime.ParseExact(
                //    dateInput + " " + timeInput,
                //    "MM/dd/yyyy HH:mm",
                //    System.Globalization.CultureInfo.InvariantCulture
                //);

                //dtpInTime.Value = userDateTime;
                //dtpOutTime.Value = userDateTime;

                dtpInTime.Value = dtpAttendanceDate.Value;
                dtpOutTime.Value = dtpAttendanceDate.Value;
                Set_Attendance();
                objPC.OutDoorEntryFlag = 0;
                Result = objQL.SP_AttendanceRecord_Insert_Update();

                //objBL.Query = "update attendancerecord set OutDoorEntryFlag=0 where CancelTag=0 and AttendanceRecordId=" + AttendanceRecordId + "";
                //Result = objBL.Function_ExecuteNonQuery();
                if (Result > 0)
                {
                    objRL.ShowMessage(9, 1);
                    ClearAll();
                    FillGrid();
                }
            }
        }

        private void dtpAttendanceDate_ValueChanged(object sender, EventArgs e)
        {
            lblAttendanceDay.Text = "";
            lblAttendanceDay.Text = Convert.ToString(dtpAttendanceDate.Value.Date.DayOfWeek);
        }

        DateTime dtInTime, dtOutTime;

        double TotalDurationDuration = 0, OTHoursTotal = 0, TotalHoursCount = 0;
        private void FillGrid()
        {

            TotalDurationDuration = 0; OTHoursTotal = 0; TotalHoursCount = 0;

            objEP.Clear();

            TOT = TimeSpan.Zero;

            dataGridView1.Rows.Clear();

            //if (objPC.AttendanceRecordMasterId != 0)
            //{
            //lblData.Text = objPC.AttendanceData.ToString();
            //cmbAttendanceStatus.Text = objPC.ApprovalStatus;

            //if (cmbAttendanceStatus.SelectedIndex > -1)
            //    SetStatusColor();

            DataTable ds = new DataTable();
            WhereClause = string.Empty;
            MainQuery = string.Empty;

            //if (!string.IsNullOrEmpty(Convert.ToString(txtSearchEmpCode.Text)))
            //    WhereClause = " and E.EmployeeCode=" + txtSearchEmpCode.Text + " ";
            //else
            //{
            //    if (!cbContractor.Checked)
            //    {
            //        if (cmbContractor.SelectedIndex == -1)
            //        {
            //            cmbContractor.Focus();
            //            objEP.SetError(cmbContractor, "Select Contractor");
            //            return;
            //        }
            //        else
            //            WhereClause = " and E.ContractorId=" + cmbContractor.SelectedValue + " ";
            //    }
            //    else if (!cbStatus.Checked)
            //    {
            //        if (cmbStatus.SelectedIndex == -1)
            //        {
            //            cmbStatus.Focus();
            //            objEP.SetError(cmbStatus, "Select Status");
            //            return;
            //        }
            //        else
            //            WhereClause += " and AR.Status='" + cmbStatus.Text + "' ";
            //    }
            //    else if (cbMissedPunch.Checked)
            //    {
            //        //MissedInPunch int 
            //        //MissedOutPunch
            //        WhereClause += " and AR.MissedOutPunch=" + MissedInOutPunch + " ";
            //    }
            //    else
            //        WhereClause = string.Empty;
            //}



            if (BusinessLayer.Department != "TIME OFFICE")
            {
                WhereClause = " and E.EmployeeId=" + objPC.EmployeeId + " "; // E.EmployeeName LIKE '%" + txtSearch.Text + "%'";
            }
            else
            {
                if (SearchFlag)
                    WhereClause += " and E.EmployeeName LIKE '%" + txtSearch.Text + "%'";
            }

            MainQuery = "select " +
                                "ARM.AttendanceDate," +
                                 "AR.AttendanceRecordId," +
                                 "AR.AttendanceRecordMasterId," +
                                 "AR.AttendanceHistoryId," +
                                 "AR.EsslAttendanceLogsId," +
                                 "AR.EmployeeId," +
                                 "E.EmployeeName," +
                                 "E.EmployeeCode," +
                                 "AR.ShiftId," +
                                 "S.ShiftSName," +
                                 "E.ShiftGroupId," +
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
                                 "AR.Notes, " +
                                 "E.Gender," +
                                 "E.OverTimeApplicable," +
                                 "E.FlexibleHoursFlag," +
                                 "E.LocationId," +
                                 "LM.LocationName," +
                                 "E.DepartmentId," +
                                 "DM.Department," +
                                 "AR.OutDoorEntryFlag " +
                                 " from AttendanceRecord AR inner join " +
                                 " attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId inner join " +
                                 " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
                                 " shifts S on S.ShiftId=AR.ShiftId inner join " +
                                 " locationmaster LM on LM.LocationId=E.LocationId inner join " +
                                 " departmentmaster DM on DM.DepartmentId=E.DepartmentId " +
                                 " where " +
                                 //" AR.AttendanceRecordMasterId=" + objPC.AttendanceRecordMasterId + " and " +
                                 " AR.CancelTag=0 and" +
                                 " E.CancelTag=0 and " +
                                 " S.CancelTag=0 and AR.OutDoorEntryFlag=1 ";

            objBL.Query = MainQuery + WhereClause + " order by ARM.AttendanceDate desc";
            ds = objBL.ReturnDataTable();

            if (ds.Rows.Count > 0)
            {
                lblTotalCount.Text = "Total Count: " + ds.Rows.Count.ToString();

                //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
                //{
                //    lblContractorCount.Visible = true;
                //    rtbContractorWiseCount.Visible = true;
                //}
                //else
                //{
                //    lblContractorCount.Visible = false;
                //    rtbContractorWiseCount.Visible = false;
                //}

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
                    //E.ContractorId

                    dataGridView1.Rows.Add();
                    int EditFlag = 0;

                    //EditFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EditFlag"])));
                    //if (EditFlag == 0)
                    //{
                    //    //objRL.Attendance_Working1();
                    //}

                    dataGridView1.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                    //dtpAttendanceDate.Value = objPC.AttendanceDate;

                    DateTime dtA = Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceDate"])));
                    dataGridView1.Rows[i].Cells["clmAttendanceDate"].Value = dtA.ToString(BusinessResources.DATEFORMATDDMMMYYYY);
                    dataGridView1.Rows[i].Cells["clmAttendanceRecordId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordId"])); //ds.Rows[i]["AttendanceRecordId"].ToString();
                    dataGridView1.Rows[i].Cells["clmAttendanceRecordMasterId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["AttendanceRecordMasterId"])); //ds.Rows[i]["AttendanceRecordMasterId"].ToString();
                    dataGridView1.Rows[i].Cells["clmEsslAttendanceLogsId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EsslAttendanceLogsId"])); //ds.Rows[i]["EsslAttendanceLogsId"].ToString();
                    dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeId"])); //ds.Rows[i]["EmployeeId"].ToString();
                    dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeName"])); //ds.Rows[i]["EmployeeName"].ToString();

                    dataGridView1.Rows[i].Cells["clmLocationId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LocationId"])); //ds.Rows[i]["EmployeeId"].ToString();
                    dataGridView1.Rows[i].Cells["clmLocation"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LocationName"])); //ds.Rows[i]["EmployeeName"].ToString();



                    dataGridView1.Rows[i].Cells["clmDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["DepartmentId"])); //ds.Rows[i]["EmployeeId"].ToString();
                    dataGridView1.Rows[i].Cells["clmDepartment"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Department"])); //ds.Rows[i]["EmployeeName"].ToString();


                    dataGridView1.Rows[i].Cells["clmGender"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Gender"])); //ds.Rows[i]["EmployeeName"].ToString();
                    dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeCode"])); //ds.Rows[i]["EmployeeCode"].ToString();
                    dataGridView1.Rows[i].Cells["clmShiftId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])); //ds.Rows[i]["ShiftId"].ToString();
                    dataGridView1.Rows[i].Cells["clmShift"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftSName"])); //ds.Rows[i]["ShiftSName"].ToString();
                    dataGridView1.Rows[i].Cells["clmShiftGroupId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftGroupId"]));
                    objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["CategoryId"])));
                    objPC.ContractorId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ContractorId"])));
                    objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTimeApplicable"])));
                    objPC.FlexibleHoursFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["FlexibleHoursFlag"])));

                    //if(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeCode"])) == "600145")
                    //{

                    //}
                    dtInTime = Convert.ToDateTime(ds.Rows[i]["InTime"].ToString());
                    dtOutTime = Convert.ToDateTime(ds.Rows[i]["OutTime"].ToString());


                    //objRL.Get_CategoriesDetails_By_Id();

                    dataGridView1.Rows[i].Cells["clmInTime"].Value = dtInTime.ToString("HH:mm");
                    dataGridView1.Rows[i].Cells["clmOutTime"].Value = dtOutTime.ToString("HH:mm");

                    //objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftId"])));
                    dataGridView1.Rows[i].Cells["clmShiftDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDurationHours"])); // objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ShiftDuration"])); //ds.Rows[i]["ShiftId"].ToString();
                    dataGridView1.Rows[i].Cells["clmDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Duration"])); //Convert.ToString(ds.Rows[i]["Duration"].ToString());

                    TimeSpan OTH = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"])));
                    dataGridView1.Rows[i].Cells["clmOverTime"].Value = objAL.Get_String_TimeSpan(OTH);
                    dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"]));

                    TimeSpan TD = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"])));
                    TotalDurationDuration = Math.Round(TD.TotalHours);
                    TotalHoursCount += TotalDurationDuration;

                    if (objPC.StatusCode != "A" && objPC.StatusCode != "L" && objPC.StatusCode != "WO" && objPC.StatusCode != "H" && objPC.StatusCode != "H")
                    {
                        if (objPC.FlexibleHoursFlag == 1)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["TotalDuration"])))
                            {
                                //TotalDuration = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"])));
                                if (TotalDurationDuration < 8.30)
                                    objRL.Set_Error_Color(dataGridView1, i, "clmTotalDuration", Color.FromName(BusinessResources.LS_Error_Color));
                            }
                        }
                    }



                    //if (Convert.ToInt32(dataGridView1.Rows[i].Cells["clmEmployeeId"].Value) == 317)
                    //{

                    //}

                    //if (objPC.EmployeeCode == 5189)
                    //{

                    //}

                    //dataGridView1.Rows[i].Cells["clmTotalDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"]));
                    dataGridView1.Rows[i].Cells["clmStatus"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Status"]));

                    //dataGridView1.Rows[i].Cells["clmLateBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"]));
                    //dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"]));
                    //dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));
                    //dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));

                    //dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
                    //dataGridView1.Rows[i].Cells["clmChangeDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"]));
                    //dataGridView1.Rows[i].Cells["clmChangeLocationId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"]));
                    dataGridView1.Rows[i].Cells["clmPunchRecords"].Value = "";
                    dataGridView1.Rows[i].Cells["clmPunchRecords"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["PunchRecords"]));
                    dataGridView1.Rows[i].Cells["clmLossOfHours"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LossOfHours"]));

                    //if (objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EmployeeCode"])) == "5056")
                    //{

                    //}



                    dataGridView1.Rows[i].Cells["clmRemarksGrid"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Remarks"]));
                    dataGridView1.Rows[i].Cells["clmNotes"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Notes"]));

                    objPC.LeaveTypeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"])));
                    if (objPC.LeaveTypeId > 0)
                    {
                        //dataGridView1.Rows[i].Cells["clmLeave"].Value = objPC.LeaveType.ToString();
                        //dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objPC.LeaveTypeId.ToString();
                    }
                    else
                    {
                        //dataGridView1.Rows[i].Cells["clmLeave"].Value = "";
                        //dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = "";
                    }

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
                    //    dataGridView1.Rows[i].Cells["clmOutTime"].Value = "0:0";

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

                    //dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"]));
                    //dataGridView1.Rows[i].Cells["clmLeaveDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveDuration"]));
                    //dataGridView1.Rows[i].Cells["clmWeeklyOff"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["WeeklyOff"]));

                    //dataGridView1.Rows[i].Cells["clmHoliday"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Holiday"]));
                    //dataGridView1.Rows[i].Cells["clmLeaveRemarks"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveRemarks"]));


                    //Leave Working
                    objPC.EmployeeId = Convert.ToInt32(ds.Rows[i]["EmployeeId"].ToString());
                    //objPC.CheckDate = objPC.AttendanceDate;

                    dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
                    objPC.ChangeDepartmentFlag = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"])));

                    if (objPC.ChangeDepartmentFlag == 1)
                    {
                        objPC.ChangeLocationtId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"])));
                        objPC.ChangeDepartmentId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"])));


                        dataGridView1.Rows[i].Cells["clmChangeLocation"].Value = objRL.Fill_Location_By_LocationId(objPC.ChangeLocationtId);
                        dataGridView1.Rows[i].Cells["clmDepartmentChange"].Value = objRL.Fill_Department_By_DepartmentId(objPC.ChangeDepartmentId);
                    }

                    objPC.OutDoorEntryFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OutDoorEntryFlag"])));
                    objPC.LateBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"])));
                    dataGridView1.Rows[i].Cells["clmLateBy"].Value = objPC.LateBy.ToString();

                    if (objPC.LateBy > 0)
                    {
                        if (objPC.FlexibleHoursFlag == 0)
                        {
                            objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.FromName(BusinessResources.LS_Error_Color));
                            objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.FromName(BusinessResources.LS_Error_Color));
                        }
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["clmLateBy"].Value = "0";
                        objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.White);
                        objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.White);
                    }

                    objPC.EarlyBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"])));
                    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objPC.EarlyBy.ToString();
                    if (objPC.EarlyBy > 0)
                    {
                        if (objPC.FlexibleHoursFlag == 0)
                        {
                            objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.FromName(BusinessResources.LS_Error_Color));
                            objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.FromName(BusinessResources.LS_Error_Color));
                        }
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = "0";
                        objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.White);
                        objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.White);
                    }

                    objPC.MissedInPunch = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"])));
                    dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = objPC.MissedInPunch.ToString();
                    if (objPC.MissedInPunch > 0)
                        objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.FromName(BusinessResources.LS_Error_Color));
                    else
                        objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.White);

                    objPC.MissedOutPunch = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedOutPunch"])));
                    dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = objPC.MissedOutPunch.ToString();
                    if (objPC.MissedOutPunch > 0)
                        objRL.Set_Error_Color(dataGridView1, i, "clmMissedOutPunch", Color.FromName(BusinessResources.LS_Error_Color));
                    else
                        objRL.Set_Error_Color(dataGridView1, i, "clmMissedOutPunch", Color.White);

                    SrNo++;

                    //TOT = TimeSpan.Zero;
                    //TOT = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["OverTime"])));
                    //OTHoursTotal += TOT.Hours;
                }
                //Get_Count_All();
                //Get_Contractor_Count();

                dataGridView1.ClearSelection();
                //dataGridView1.Rows[0].Cells[0].Selected = false;
            }
            //}
        }

        int SrNo = 1;
        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ClearAttendance();
            objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FillEmployee_Fixed();
        }

        private void cmbEmployeeName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_EmployeeDetails();
        }

        private void dtpInTime_Leave(object sender, EventArgs e)
        {
            Set_Attendance();
        }

        private void dtpOutTime_Leave(object sender, EventArgs e)
        {
            Set_Attendance();
        }

        private void Set_Attendance()
        {
            //objPC.ShiftGroupId = objPC.ShiftGroupId; // Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmShiftGroupId"].Value.ToString());

            objPC.InTime = dtpInTime.Value;
            objPC.OutTime = dtpOutTime.Value;

            objPC.AttendanceDate = dtpInTime.Value;
            //objRL.CalculateComman_Attendance();
            objRL.Get_CategoriesDetails_By_Id();

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

        private bool ValidationSave()
        {
            DateTime InDateCheck = dtpInTime.Value;
            DateTime OutDateCheck = dtpOutTime.Value;

            objEP.Clear();
            bool RetrunFlag = false;

            if (cmbLocation.SelectedIndex == -1)
            {
                cmbLocation.Focus();
                objEP.SetError(cmbLocation, "Select Location");
                RetrunFlag = true;
            }
            else if (cmbDepartment.SelectedIndex == -1)
            {
                cmbDepartment.Focus();
                objEP.SetError(cmbDepartment, "Select Department");
                RetrunFlag = true;
            }
            else if (cmbEmployeeName.SelectedIndex == -1)
            {
                cmbEmployeeName.Focus();
                objEP.SetError(cmbEmployeeName, "Select Employee Name");
                RetrunFlag = true;
            }
            else if (cmbShift.SelectedIndex == -1)
            {
                cmbShift.Focus();
                objEP.SetError(cmbShift, "Select Shift");
                RetrunFlag = true;
            }
            else if (txtRemarks.Text == "")
            {
                txtRemarks.Focus();
                objEP.SetError(txtRemarks, "Enter Remarks");
                RetrunFlag = true;
            }
            else if (InDateCheck.TimeOfDay == TimeSpan.Zero)
            {
                dtpInTime.Focus();
                objEP.SetError(dtpInTime, "Enter Valid In Time");
                RetrunFlag = true;
            }
            else if (OutDateCheck.TimeOfDay == TimeSpan.Zero)
            {
                dtpOutTime.Focus();
                objEP.SetError(dtpOutTime, "Enter Valid Out Time");
                RetrunFlag = true;
            }
            else
                RetrunFlag = false;

            return RetrunFlag;

            //        DateTime selectedDate = dateTimePicker1.Value;

            //if (selectedDate.TimeOfDay == TimeSpan.Zero)
            //{
            //    MessageBox.Show("The selected time is 00:00 (midnight).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show("The selected time is not 00:00 (midnight).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private bool CheckExist_Leave()
        {
            DataSet ds = new DataSet();
            objPC.EmployeeId = TableId; // Convert.ToInt32(cmbEmployeeName.SelectedValue);
            objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
            objPC.FromDate = dtpInTime.Value;
            objPC.ToDate = dtpInTime.Value;

            //objPC.LeaveStatus = BusinessResources.STATUS_DEPARTMENT_HEAD_APPROVED;
            ds = objQL.SP_LeaveApplication_CheckExist();

            if (ds.Tables[0].Rows.Count > 0)
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0].ToString())))
                    return true;
                else
                    return false;
            else
                return false;
        }

        private bool CheckExist_Attendance()
        {
            DataSet ds = new DataSet();
            objBL.Query = "select AR.AttendanceRecordId, ARM.AttendanceRecordMasterId,AR.ShiftId,AR.ShiftGroupId from attendancerecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId where ARM.AttendanceDate='" + dtpInTime.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and AR.EmployeeId=" + objPC.EmployeeId + " and AR.CancelTag=0 and ARM.CancelTag=0 and AR.Status NOT IN('A') ";
            ds = objBL.ReturnDataSet();
            if (ds.Tables[0].Rows.Count > 0)
                if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0][0].ToString())))
                    return true;
                else
                    return false;
            else
                return false;
        }

        private bool CheckExist()
        {
            bool FlagR = false;

            //if (!CheckExist_Attendance())
            //    FlagR=false;
            //else
            //    FlagR= true;

            if (!FlagR)
            {
                if (!CheckExist_Leave())
                    FlagR = false;
                else
                    FlagR = true;
            }
            return FlagR;

        }
        private void SaveDB()
        {
            //if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMIN || BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.Department == "TIME OFFICE")
            //{
            if (!ValidationSave())
            {
                if (!CheckExist())
                {
                    //objPC.ShiftId = Convert.ToInt32(cmbShift.SelectedValue);
                    //objPC.ClearAttendanceRecords();
                    objPC.OutDoorEntryFlag = 1;
                    objPC.PunchRecords = string.Empty;
                    objPC.AttendanceRecordId = 0;
                    objPC.AttendanceRecordMasterId = 0;
                    objPC.AttendanceHistoryId = 0;
                    objPC.EsslAttendanceLogsId = 0;
                    objPC.MissedInPunch = 0;
                    objPC.MissedOutPunch = 0;
                    objPC.ChangeDepartmentFlag = 0;
                    objPC.ChangeDepartmentId = 0;
                    objPC.ChangeLocationtId = 0;
                    objPC.LeaveTypeId = 0;
                    objPC.LeaveDuration = 0;
                    objPC.WeeklyOff = 0;
                    objPC.Holiday = 0;
                    objPC.LeaveRemarks = "";
                    objPC.LossOfHours = 0;
                    objPC.Present = 0;
                    objPC.Absent = 0;
                    objPC.Remarks = "";

                    objPC.EmployeeId = Convert.ToInt32(cmbEmployeeName.SelectedValue);
                    //objPC.AttendanceRecordId
                    objPC.Status = cmbStatus.Text;
                    objPC.StatusCode = cmbStatus.Text;
                    objPC.InTime = dtpInTime.Value; // "1900-01-01 00:00:00";
                    objPC.OutTime = dtpOutTime.Value;

                    objPC.AttendanceDate = dtpInTime.Value;

                    //if (objPC.Status == "A" || objPC.Status == "A(OD)" || objPC.Status == "H" || objPC.Status == "HA" || objPC.Status == "WO" || objPC.Status == "WOA")
                    //    objPC.Absent = 1;
                    //else
                    //    objPC.Present = 1;

                    objPC.Duration = txtDuration.Text;
                    objPC.TotalDuration = txtTotalDuration.Text;
                    objPC.OverTime = txtOverTime.Text;

                    objPC.MissedInPunch = 0;
                    objPC.MissedOutPunch = 0;
                    objPC.LateBy = Convert.ToInt32(txtLateBy.Text);
                    objPC.EarlyBy = Convert.ToInt32(txtEarlyBy.Text);
                    //objPC.ShiftGroupId = objPC.ShiftGroupId;
                    //objPC.EmployeeId = objPC.EmployeeId;
                    objPC.Status = cmbStatus.Text;
                    objPC.LeaveTypeFlag = true;

                    //objRL.Attendance_Working();
                    //objRL.Attendance_Working1();

                    objAL.AttendanceWorking();
                    objPC.LeaveTypeFlag = false;

                    objPC.Remarks = txtRemarks.Text; // "Out Door Punch"; // objRL.CheckNullString(Convert.ToString(txtRemarks.Text));

                    if (cbOverTime.Checked)
                    {
                        objPC.OverTimeManualFlag = 1;
                        objPC.OverTime = txtOverTime.Text;
                    }
                    else
                        objPC.OverTimeManualFlag = 0;

                    objPC.RemarksReply = ""; // objRL.CheckNullString(Convert.ToString(txtRemarksReply.Text));

                    objAL.Check_ARM();

                    if (!objPC.CheckFlagARM)
                    {
                        objPC.ApprovalStatusId = 1;
                        objRL.Get_Incharge_Senior_OfficerId();
                        objPC.AttendanceRecordMasterId = objQL.SP_AttendanceRecordMaster_CheckExist_Insert();
                    }
                    
                    Result = objQL.SP_AttendanceRecord_Insert_Update();
                    
                    if (Result > 0)
                    {
                        objAL.Save_AttendanceMonthlyData();
                        objRL.ShowMessage(7, 1);
                        ClearAll();
                        this.Dispose();
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
                objRL.ShowMessage(17, 4);
                return;
            }
            //}
        }
    }
}
