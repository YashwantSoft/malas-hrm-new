using BusinessLayerUtility;
using SPApplication.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SPApplication.Transaction
{
    public partial class EmployeeProfile : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        bool FlagDelete = false, FlagExist = false, SearchFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0,EmployeeId = 0;

        public EmployeeProfile()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, BusinessResources.LBL_HEADER_EMPLOYEEPROFILE);

            btnJobProfile.BackColor = objDL.GetBackgroundColor();
            btnJobProfile.ForeColor = objDL.GetForeColor();
             
            lblData.ForeColor = objDL.GetForeColor();
            lblData.BackColor = objDL.GetBackgroundColor();

            rtbLeaveRecords.ForeColor = objDL.GetForeColor();
            rtbLeaveRecords.BackColor = objDL.GetBackgroundColor();

            rtbStatusCount.ForeColor = objDL.GetForeColor();
            rtbStatusCount.BackColor = objDL.GetBackgroundColor();

            rtbTicketInfo.ForeColor = objDL.GetForeColor();
            rtbTicketInfo.BackColor = objDL.GetBackgroundColor();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void EmployeeProfile_Load(object sender, EventArgs e)
        {
            Fill_Employee_Data();
        }

        private void Fill_Employee_Data()
        {
            //EmployeeId = 0;
            objPC.EmployeeId = BusinessLayer.EmployeeLoginId_Static;
            objRL.Fill_EmployeeDetails();
            objRL.Set_Employee_Profile_Rich_Text_Box(lblData);
            objRL.Get_Leaves_Count_All();
            objRL.Fill_Leave_RichTextBox(rtbLeaveRecords);
            Fill_Grid_AttendanceRecord();
            Get_TicketCount();
            Fill_Files();
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
           
        }

        string MainQuery = string.Empty, ColumnNames_BR = string.Empty, TableNames_BR = string.Empty, WhereClause_BR = string.Empty, WhereClause = string.Empty, OrderBy = string.Empty;
        string DateColumn = string.Empty, EmployeeIn = string.Empty, LeaveStatusIn = string.Empty, ContractorIn = string.Empty, StatusIn = string.Empty, DepartmentIn = string.Empty, LocationIdS = string.Empty;

            int SrNo = 1;
        double LateBy = 0, EarlyBy=0,TotalDurationDuration =0,TotalHoursCount=0;
        DateTime dtInTime, dtOutTime;
          TimeSpan TOT = TimeSpan.Zero;
        double OTHoursTotal = 0;

        private void Fill_Grid_AttendanceRecord()
        {
            OTHoursTotal = 0; TotalDurationDuration = 0;
            TotalHoursCount = 0;
            MainQuery = string.Empty;
            WhereClause = string.Empty;
            OrderBy = string.Empty;

            if (objPC.EmployeeId != 0)
            {
                DataTable dt = new DataTable();
                MainQuery = "select " +
                            "AR.AttendanceRecordId," +
                            "AR.AttendanceRecordMasterId," +
                            "AR.AttendanceHistoryId," +
                            "AR.EsslAttendanceLogsId," +
                            "ARM.AttendanceDate," +
                            "AR.EmployeeId," +
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
                            "AR.OverTimeManualFlag," +
                            "E.OverTimeApplicable," +
                            "E.FlexibleHoursFlag " +
                            " from " +
                            " AttendanceRecord AR inner join " +
                            " attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId inner join " +
                            " Employees E on E.EmployeeId=AR.EmployeeId inner join " +
                            " shifts S on S.ShiftId=AR.ShiftId inner join " +
                            " attendancestatusmaster ASM on ARM.ApprovalStatusId=ASM.AttendanceStatusId " +
                            " where AR.CancelTag=0 and ARM.CancelTag=0 and E.CancelTag=0 and S.CancelTag=0 and ASM.CancelTag=0 ";

                int MonthDay = 0;
                if (DateTime.Now.Day < 10)
                    MonthDay = DateTime.Now.Month - 1;
                else
                    MonthDay = DateTime.Now.Month;

                WhereClause = " and Month(ARM.AttendanceDate)=" + MonthDay + " and Year(ARM.AttendanceDate)=" + DateTime.Now.Year + " and AR.EmployeeId=" + objPC.EmployeeId + " ";
                       OrderBy =" order by ARM.AttendanceDate asc";
                       objBL.Query = MainQuery + WhereClause + OrderBy;
                       dt = objBL.ReturnDataTable();
                 
                if (dt.Rows.Count > 0)
                {
                    OTHoursTotal = 0;
                   
                    objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["OverTimeApplicable"])));
                    objPC.FlexibleHoursFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["FlexibleHoursFlag"])));

                    label3.Text = "Attendance Month - " + objRL.GetMonthName(MonthDay);

                    SrNo = 1;
                    for (int i = 0; i < dt.Rows.Count; i++)
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

                        objPC.EmployeeId = Convert.ToInt32(dt.Rows[i]["EmployeeId"].ToString());

                        DateTime dtAttendanceDate = Convert.ToDateTime(dt.Rows[i]["AttendanceDate"].ToString());
                        dtInTime = Convert.ToDateTime(dt.Rows[i]["InTime"].ToString());
                        dtOutTime = Convert.ToDateTime(dt.Rows[i]["OutTime"].ToString());
 
                        TimeSpan TD = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["TotalDuration"])));
                        TotalDurationDuration = Math.Round(TD.TotalHours);
                        TotalHoursCount += TotalDurationDuration;

                        //double TotalDuration = 0;
                        //if (objPC.FlexibleHoursFlag == 1)
                        //{
                        //    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["TotalDuration"])))
                        //    {
                        //        //TimeSpan TD = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"])));
                        //        //TotalDuration = Math.Round(TD.TotalHours);
                        //        //TotalDuration = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["TotalDuration"])));

                        //        if (TotalDurationDuration < 8.30)
                        //            objRL.Set_Error_Color(dataGridView1, i, "clmTotalDuration", Color.FromName(BusinessResources.LS_Error_Color));
                        //        else
                        //            objRL.Set_Error_Color(dataGridView1, i, "clmTotalDuration", Color.White);
                        //    }
                        //}

                        //dataGridView1.Rows[i].Cells["clmStatus"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Status"]));

                        //dataGridView1.Rows[i].Cells["clmLateBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"]));
                        //dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["EarlyBy"]));
                        //dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));
                        //dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["MissedInPunch"]));

                        //dataGridView1.Rows[i].Cells["clmChangeDepartmentFlag"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentFlag"]));
                        //dataGridView1.Rows[i].Cells["clmChangeDepartmentId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeDepartmentId"]));
                        //dataGridView1.Rows[i].Cells["clmChangeLocationId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["ChangeLocationtId"]));

                        //objPC.LeaveType = string.Empty;
                        //objAL.LeaveDetailsEmployees();

                        //if (objPC.LeaveTypeId == 0)
                        //{
                        //    objPC.LeaveTypeId = Convert.ToInt32(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"])));
                        //    objRL.GetLeaveDetailsEmployees_ByLeaveId();
                        //    dataGridView1.Rows[i].Cells["clmLeave"].Value = objPC.LeaveType.ToString();
                        //    dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objPC.LeaveTypeId.ToString();
                        //}

                        //dataGridView1.Rows[i].Cells["clmLeaveTypeId"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveTypeId"]));
                        //dataGridView1.Rows[i].Cells["clmLeaveDuration"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveDuration"]));
                        ////dataGridView1.Rows[i].Cells["clmWeeklyOff"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["WeeklyOff"]));

                        ////dataGridView1.Rows[i].Cells["clmHoliday"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Holiday"]));
                        ////dataGridView1.Rows[i].Cells["clmLeaveRemarks"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LeaveRemarks"]));
                        //dataGridView1.Rows[i].Cells["clmPunchRecords"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["PunchRecords"]));
                        //dataGridView1.Rows[i].Cells["clmLossOfHours"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LossOfHours"]));
                        //dataGridView1.Rows[i].Cells["clmRemarksGrid"].Value = objRL.CheckNullString(Convert.ToString(ds.Rows[i]["Remarks"]));

                        ////Leave Working
                        
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

                        //objPC.LateBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Rows[i]["LateBy"])));
                        //dataGridView1.Rows[i].Cells["clmLateBy"].Value = objPC.LateBy.ToString();

                        //if (objPC.LateBy > 0)
                        //{
                        //    if (objPC.FlexibleHoursFlag == 0)
                        //    {
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.FromName(BusinessResources.LS_Error_Color));
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.FromName(BusinessResources.LS_Error_Color));
                        //    }
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
                        //    if (objPC.FlexibleHoursFlag == 0)
                        //    {
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.FromName(BusinessResources.LS_Error_Color));
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.FromName(BusinessResources.LS_Error_Color));
                        //    }
                        //}
                        //else
                        //{
                        //    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = "0";
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.White);
                        //    objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.White);
                        //}

                        //dtpAttendanceDate.Value = objPC.AttendanceDate;

                        //if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["LateBy"].ToString())))
                        //{
                        //    LateBy = Convert.ToDouble(ds.Rows[i]["LateBy"].ToString());
                        //    dataGridView1.Rows[i].Cells["clmLateBy"].Value = LateBy.ToString();
                        //    if (LateBy > 10)
                        //    {
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.FromName(BusinessResources.LS_Error_Color));
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.FromName(BusinessResources.LS_Error_Color));
                        //        //dataGridView1.Rows[i].Cells[""].Style.BackColor = Color.Yellow;
                        //        //dataGridView1.Rows[i].Cells[""].Style.BackColor = Color.Yellow;
                        //    }
                        //    else
                        //    {
                        //        dataGridView1.Rows[i].Cells["clmLateBy"].Value = "0";
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmInTime", Color.White);
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmLateBy", Color.White);
                        //    }
                        //}

                        //if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["EarlyBy"].ToString())))
                        //{
                        //    EarlyBy = Convert.ToDouble(ds.Rows[i]["EarlyBy"].ToString());
                        //    dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = EarlyBy.ToString();
                        //    if (EarlyBy > 10)
                        //    {
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.FromName(BusinessResources.LS_Error_Color));
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.FromName(BusinessResources.LS_Error_Color));

                        //        //dataGridView1.Rows[i].Cells["clmOutTime"].Style.BackColor = Color.Yellow;
                        //        //dataGridView1.Rows[i].Cells["clmEarlyBy"].Style.BackColor = Color.Yellow;
                        //    }
                        //    else
                        //    {
                        //        dataGridView1.Rows[i].Cells["clmEarlyBy"].Value = "0";
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmOutTime", Color.White);
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmEarlyBy", Color.White);
                        //    }
                        //}

                        //if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["LateComming"].ToString())))
                        //    dataGridView1.Rows[i].Cells["clmLateComming"].Value = Convert.ToString(ds.Rows[i]["LateComming"].ToString());

                        //if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["MissedInPunch"].ToString())))
                        //{
                        //    string MIP = ds.Rows[i]["MissedInPunch"].ToString();
                        //    dataGridView1.Rows[i].Cells["clmMissedInPunch"].Value = MIP.ToString();

                        //    if (Convert.ToInt32(MIP) != 0) // == "Yes")
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.FromName(BusinessResources.LS_Error_Color));
                        //    else
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.White);
                        //}

                        //if (!string.IsNullOrEmpty(Convert.ToString(ds.Rows[i]["MissedOutPunch"].ToString())))
                        //{
                        //    string MIP = ds.Rows[i]["MissedOutPunch"].ToString();
                        //    dataGridView1.Rows[i].Cells["clmMissedOutPunch"].Value = MIP.ToString();

                        //    if (Convert.ToInt32(MIP) != 0) //"Yes")
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmMissedOutPunch", Color.FromName(BusinessResources.LS_Error_Color));
                        //    else
                        //        objRL.Set_Error_Color(dataGridView1, i, "clmMissedInPunch", Color.White);
                        //}
                        SrNo++;


                        TOT = TimeSpan.Zero;
                        TOT = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["OverTime"])));
                        OTHoursTotal += TOT.Hours;
                    }
                    Get_Count_All(dt);
                }
            }
        }

          int TotalHalfDay = 0, TotalLeave = 0,TotalPresent = 0, TotalAbsent = 0;
        string checkStatus = string.Empty, LeaveName = string.Empty;
        string ConcatTotal = string.Empty;

        int TotalMP = 0;
        double TotalA = 0, TotalWO = 0, TotalWOP = 0, TotalH = 0, TotalP = 0, TotalHD = 0, TotalHP = 0, TotalL = 0, TotalCO = 0, TotalCOU = 0;


        private void Get_Count_All(DataTable dt)
        {
            //Casual Leave
            //Paid Leave
            //Sick Leave
            //Marraige Leave
            //Compensation Off
            //Medical Leave
            //Compensation Off Used
            //Revert Leave
            //Maternity Leave

            //1	A	Absent	
            //2	WO	Weekly off	
            //3	WOP	Weekly off Present	
            //4	H	Holiday	
            //5	P	Present	
            //6	HD	Half Day
            //7	HP	Holiday Present	
            //8	L	Leave
            //9	CO	Comp off
            //10 COU Comp off Used

            rtbStatusCount.Text = "";
            checkStatus = string.Empty; LeaveName = string.Empty; ConcatTotal = string.Empty;

            TotalMP = 0; TotalA = 0; TotalWO = 0; TotalWOP = 0; TotalH = 0; TotalP = 0; TotalHD = 0; TotalHP = 0; TotalL = 0; TotalCO = 0; TotalCOU = 0;

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TotalMP += objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["MissedOutPunch"])));

                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["Status"])))
                    {
                        checkStatus = Convert.ToString(dt.Rows[i]["Status"].ToString());

                        //1	A	Absent	
                        //2	WO	Weekly off	
                        //3	WOP	Weekly off Present	
                        //4	H	Holiday	
                        //5	P	Present	
                        //6	HD	Half Day
                        //7	HP	Holiday Present	
                        //8	L	Leave
                        //9	CO	Comp off
                        //10 COU

                        if (checkStatus == "A")
                            TotalA += 1;
                            //TotalA++;
                        else if (checkStatus == "WO")
                            TotalWO += 1;
                            //TotalWO++;
                        else if (checkStatus == "WOP")
                            TotalWOP += 1;
                            //TotalWOP++;
                        else if (checkStatus == "H")
                            TotalH += 1;
                            //TotalH++;
                        else if (checkStatus == "P")
                            TotalP += 1;
                            //TotalP++;
                        else if (checkStatus == "HD")
                        {
                            TotalHD += 1;
                            //TotalA += 0.5;
                            //TotalHD += 0.5;
                        }
                        //TotalHD++;
                        else if (checkStatus == "HP")
                        {
                            TotalHP += 1;
                            //TotalHP++;
                        }
                        else if (checkStatus == "L")
                            TotalL += 1;
                        //TotalL++;
                        else if (checkStatus == "CO")
                            TotalCO += 1;
                        //TotalCO++;
                        else if (checkStatus == "COU")
                            TotalCOU += 1;
                        //TotalCOU++;
                        else
                        {
                        }
                    }

                    //if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[i].Cells["clmLeave"].Value)))
                    //{
                    //   LeaveName= Convert.ToString(dataGridView1.Rows[i].Cells["clmLeave"].Value);
                    //   if (LeaveName != "NA")
                    //       TotalLeave++;
                    //}
                }
                ConcatTotal = "Total Count-" + dt.Rows.Count.ToString() + System.Environment.NewLine +
                               "Present-" + TotalP.ToString() + System.Environment.NewLine +
                               "Absent-" + TotalA.ToString() + System.Environment.NewLine +
                               "Half Days-" + TotalHD.ToString() + System.Environment.NewLine +
                               "Weekly off-" + TotalWO.ToString() + System.Environment.NewLine +
                               "Weekly off Present-" + TotalWOP.ToString() + System.Environment.NewLine +
                               "Holiday Present-" + TotalHP.ToString() + System.Environment.NewLine +
                               "Comp off-" + TotalCO.ToString() + System.Environment.NewLine +
                               "Comp off Used-" + TotalCOU.ToString() + System.Environment.NewLine +
                               "Leaves-" + TotalL.ToString() + System.Environment.NewLine +
                               "Total OT Hours-" + OTHoursTotal.ToString() + System.Environment.NewLine +
                               "Total Hours-" + TotalHoursCount.ToString() + System.Environment.NewLine +
                               "Holiday-" + TotalH.ToString() + System.Environment.NewLine +
                               "Missed Punch-" + TotalMP.ToString();
                //lblStatusCount.Text = ConcatTotal.ToString();
                rtbStatusCount.Text = ConcatTotal.ToString();
            }
        }

        string TicketStatus = string.Empty;
        int TicketStatusId = 0;
        public void Get_TicketCount()
        {
            MainQuery = string.Empty;
            WhereClause = string.Empty;
            OrderBy = string.Empty;
            IT_Data = string.Empty; TO_Data = string.Empty;

            if (objPC.EmployeeId != 0)
            {
                DataTable dtTicketStatus = new DataTable();
                objBL.Query = "select CommanMasterId,TicketStatus from commanmaster where TicketStatus NOT IN('','Select All','Cancel') and CancelTag=0  order by TicketStatus asc";
                dtTicketStatus = objBL.ReturnDataTable();
                if (dtTicketStatus.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTicketStatus.Rows.Count; i++)
                    {
                        TicketStatus = string.Empty;
                        TicketStatusId = 0;
                        TicketStatus = objRL.CheckNullString(Convert.ToString(dtTicketStatus.Rows[i]["TicketStatus"]));
                        //TicketStatusId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dtTicketStatus.Rows[i]["TicketStatus"])));
                        Get_Count_Ticket_By_Department("TIME OFFICE");
                        Get_Count_Ticket_By_Department("INFORMATION TECHNOLOGY");
                    }

                    string ConcatString = "Time Office Tickets\n" + TO_Data + "\nIT Tickets \n" + IT_Data;

                    rtbTicketInfo.Text = ConcatString;// "Time Office Tickets \n\n" + TO_Data + "IT Tickets \n" + IT_Data;
                }
            }
        }

        string IT_Data = string.Empty, TO_Data = string.Empty;
        private void Get_Count_Ticket_By_Department(string Department)
        {
            int Count=0;
            DataTable dtCount = new DataTable();
            objBL.Query = "select Count(T.TicketId) as Count from ticket T inner join departmentmaster DM on DM.DepartmentId=T.DepartmentId where DM.CancelTag=0 and T.CancelTag=0 and T.UserId=" + objPC.EmployeeId + " and T.Status='" + TicketStatus + "' and DM.Department='" + Department + "'";

            dtCount = objBL.ReturnDataTable();
            if (dtCount.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dtCount.Rows[0][0])))
                {
                    Count = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dtCount.Rows[0][0])));

                    if (Department == "TIME OFFICE")
                        TO_Data += TicketStatus + "-" + Count.ToString() +"\n";
                    else
                        IT_Data += TicketStatus + "-" + Count.ToString() + "\n";
                }
            }
        }

        int dgvItemRow = 0;

        private void Fill_Files()
        {
            if (BusinessLayer.EmployeeLoginId_Static != 0)
            {
                //objPC.FormNameProfile = "Profile";
                objPC.FormName = "EmployeeMaster"; // this.Name;
                objPC.FormHeader = BusinessResources.LBL_HEADER_EMPLOYEEMASTER;
                objPC.TableId = BusinessLayer.EmployeeLoginId_Static;

                dgvItemRow = 0;
                dgvFiles.Rows.Clear();
                DataSet ds = new DataSet();
                objPC.FormName = "EmployeeMaster"; // this.Name;
                objPC.TableId = BusinessLayer.EmployeeLoginId_Static;
                objPC.FormId = objQL.SP_FormMaster_Get_FormId();
                ds = objQL.SP_UploadDocuments_Select();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgvFiles.Rows.Add();
                        dgvFiles.Rows[dgvItemRow].Cells["clmId"].Value = ds.Tables[0].Rows[i]["UploadDocumentId"].ToString();
                        dgvFiles.Rows[dgvItemRow].Cells["clmDocumentName"].Value = ds.Tables[0].Rows[i]["Document Name"].ToString();
                        dgvFiles.Rows[dgvItemRow].Cells["clmDocumentPath"].Value = ds.Tables[0].Rows[i]["DocumentPath"].ToString();
                        dgvFiles.Rows[dgvItemRow].Cells["clmFileName"].Value = ds.Tables[0].Rows[i]["DocumentName"].ToString();
                        dgvFiles.Rows[dgvItemRow].Cells["clmView"].Value = "View";
                        dgvItemRow++;
                        SrNo_Add();
                    }
                }
            }
           
        }

        private void SrNo_Add()
        {
            if (dgvFiles.Rows.Count > 0)
            {
                int SrNo = 1;
                for (int i = 0; i < dgvFiles.Rows.Count; i++)
                {
                    dgvFiles.Rows[i].Cells["clmSrNo"].Value = SrNo.ToString();
                    SrNo++;
                }
            }
            lblTotalItemCount.Text = "Total Item Count: " + dgvFiles.Rows.Count.ToString();
        }

        private void btnJobProfile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(objPC.JobProfileFileName)))
            {
                //Job Profile Work PDF File
                
                string FileName = string.Empty, FilePath = string.Empty, FullPath = string.Empty;
                FileName = Convert.ToString(objPC.JobProfileFileName);
                FilePath = objRL.GetPath("JobProfilePath");
                FullPath = FilePath + FileName;
                System.Diagnostics.Process.Start(FullPath);
                //System.Diagnostics.Process(FullPath);
            }
        }

        string FileName = string.Empty, SourcePath = string.Empty, DestinationPath = string.Empty;

        private void dgvFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvFiles.CurrentCell.ColumnIndex == 5)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dgvFiles.Rows[e.RowIndex].Cells["clmFileName"].Value)))
                    {
                        DestinationPath = Convert.ToString(dgvFiles.Rows[e.RowIndex].Cells["clmDocumentPath"].Value.ToString());
                        FileName = Convert.ToString(dgvFiles.Rows[e.RowIndex].Cells["clmFileName"].Value.ToString());

                        //DestinationPath = DestinationPath  + FileName;
                        DestinationPath = objRL.GetPath_DocumentsMain(objPC.EmployeeId) + FileName;
                        System.Diagnostics.Process.Start(DestinationPath);
                    }
                }
            }
            catch (Exception ex1) { objRL.ErrorMessge(ex1.ToString()); }
            finally { GC.Collect(); }
        }
    }
}
