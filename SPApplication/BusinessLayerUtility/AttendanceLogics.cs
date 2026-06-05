using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayerUtility
{
    public class AttendanceLogics
    {
        BusinessLayer objBL = new BusinessLayer();
        QueryLayer objQL = new QueryLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        PropertyClass objPC = new PropertyClass();
        DateTime dt;
        
        List<DateTime> allDates = new List<DateTime>();
        
        public void GetDatesBetween(DateTime startDate, DateTime endDate)
        {
            allDates = null; allDates = new List<DateTime>();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                allDates.Add(date);

            if (allDates.Count == 0)
                allDates.Add(startDate);
            //return allDates;
        }

        public class CursorWait : IDisposable
        {
            public CursorWait(bool appStarting = false, bool applicationCursor = false)
            {
                // Wait
                Cursor.Current = appStarting ? Cursors.AppStarting : Cursors.WaitCursor;
                if (applicationCursor) System.Windows.Forms.Application.UseWaitCursor = true;
            }

            public void Dispose()
            {
                // Reset
                Cursor.Current = Cursors.Default;
                System.Windows.Forms.Application.UseWaitCursor = false;
            }
        }

        public void Save_Edit_Attendance()
        {
            if (objPC.AttendanceLogId > 0)
            {
                MainQuery = string.Empty; WhereClause = string.Empty;
                ////Update
                //objBL.Query = "update attendancelogs set" +
                //    " InTime="+objPC.InTime+" "+
                //    " OutTime=" + objPC.OutTime + " " +
                //    " Duration=" + objPC.Duration + " " +
                //    " Status=" + objPC.Status + " ";

                DataTable dt = new DataTable();
                //dt = objQL.SP_Get_Shift_Details();
                dt = objQL.SP_Update_Attendancelogs_Edit();

                dt = new DataTable();

                //DataTable dt = new DataTable();
                //MainQuery = objPC.AttendanceLogsQuery;

                MainQuery = objPC.Get_AttendanceLogs_Query(objPC.LocationId, objPC.DepartmentId);

                WhereClause += " and AL.AttendanceDate='" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and AL.EmployeeId=" + objPC.EmployeeId + " ";

                objBL.Query = MainQuery + WhereClause;
                dt = objBL.ReturnDataTable();

                //objQL.SP_Update_Attendancelogs_Edit();

                if (dt.Rows.Count > 0)
                {
                    objPC.ShiftId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["ShiftId"])));

                    objPC.ShiftFName = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Shift Name"]));
                    objPC.BeginTime = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Shift Begin"]));
                    objPC.EndTime = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Shift End"]));
                    objPC.ShiftDuration = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Shift Duration"]));

                    objPC.Duration = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Duration"]));
                    objPC.OverTime = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["OT"]));

                    objPC.LateBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Late by"])));
                    objPC.EarlyBy = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Early by"])));

                    objPC.Status = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Status"]));
                }
            }
            else

            {
                //Insert
            }//insertSql.Append("(AttendanceDate,EmployeeCode,EmployeeId,LocationId,DepartmentId,ContractorId,InTime,OutTime,Duration,Status,MissedOutPunch,MissedInPunch,PunchRecords) VALUES ");

        }

        public void Recalculate_Leave(DateTime startDate, DateTime endDate)
        {
            using (new CursorWait())
            {
                //Dont Use
                ReCalculate__Leave_Attendance_Funcation();

                DateTime dtpFromDateL, dtpToDateL;
                DataTable dt = new DataTable();
                objBL.Query = "select * from Employees where CancelTag=0 and EmployeeId IN(select distinct EmployeeId from leaveapplication where FromDate and ToDate between '" + startDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + endDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and  CancelTag=0 and LeaveStatus='" + BusinessResources.LS_Completed + "' order by EmployeeId) order by EmployeeCode asc";
                dt = objBL.ReturnDataTable();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objPC.TotalLeave_Count = 0; objPC.Balance_Count = 0; objPC.TotalApplicableLeave_Count = 0; objPC.EmployeeId = 0;

                        objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmployeeId"])));
                        objPC.TotalApplicableLeave_Count = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["TotalApplicableLeave"])));

                        //if (objPC.EmployeeId == 142)
                        //    MessageBox.Show("Found");

                        DataTable dtSum = new DataTable();
                        objBL.Query = "select sum(TotalDays) from leaveapplication where EmployeeId=" + objPC.EmployeeId + " and FromDate and ToDate between '" + startDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + endDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and  CancelTag=0 and LeaveStatus='" + BusinessResources.LS_Completed + "' and LeaveTypeId IN(2,3,5)";
                       //objBL.Query = "select sum(TotalDays) from leaveapplication where EmployeeId=" + objPC.EmployeeId + " and FromDate and ToDate between '" + startDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + endDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and  CancelTag=0 and LeaveStatus='" + BusinessResources.LS_Completed + "' "; // and LeaveTypeId IN(2,3)";
                        dtSum = objBL.ReturnDataTable();

                        if (dtSum.Rows.Count > 0)
                            objPC.TotalLeave_Count = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(dtSum.Rows[0][0])));

                        objPC.RevertLeave_Count = 0;
                        DataTable dtRevertLeave = new DataTable();
                        objBL.Query = "select sum(TotalDays) from leaveapplication where EmployeeId=" + objPC.EmployeeId + " and FromDate and ToDate between '" + startDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + endDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and  CancelTag=0 and LeaveStatus='" + BusinessResources.LS_Completed + "' and IsRevertLeave=1";
                        dtRevertLeave = objBL.ReturnDataTable();

                        if (dtRevertLeave.Rows.Count > 0)
                            objPC.RevertLeave_Count = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(dtRevertLeave.Rows[0][0])));

                        if (dtSum.Rows.Count > 0 || dtRevertLeave.Rows.Count > 0)
                        {
                            objPC.Balance_Count = (objPC.TotalApplicableLeave_Count - objPC.TotalLeave_Count) + objPC.RevertLeave_Count;

                            objBL.Query = "update Employees set EnjoyLeave='" + objPC.TotalLeave_Count + "',BalanceLeave='" + objPC.Balance_Count + "' where CancelTag=0 and EmployeeId=" + objPC.EmployeeId + "";
                            int Result = objBL.Function_ExecuteNonQuery();
                        }
                    }
                }
                Update_Present_Absent();
                objRL.ShowMessage(45, 1);
            }
        }

        public void Recalculate_CompOff(DateTime startDate, DateTime endDate)
        {
            using (new CursorWait())
            {
                //Dont Use
                //ReCalculate__Leave_Attendance_Funcation();

                DateTime dtpFromDateL, dtpToDateL;
                DataTable dt = new DataTable();
                objBL.Query = "select distinct EmployeeId from Employees where CancelTag=0 and EmployeeId IN(select distinct EmployeeId from compoffapplication) order by EmployeeId asc";
                dt = objBL.ReturnDataTable();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmployeeId"])));

                        if (objPC.EmployeeId == 442)
                            MessageBox.Show("Found");

                        objPC.SearchFlagLeaveCompOff = true;
                        objRL.Get_CompOff_Count_All();

                        //objPC.TotalLeave_Count = 0; objPC.Balance_Count = 0; objPC.TotalApplicableLeave_Count = 0; objPC.EmployeeId = 0;

                        //objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["EmployeeId"])));
                        //objPC.TotalApplicableLeave_Count = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["TotalApplicableLeave"])));

                        

                        //DataTable dtSum = new DataTable();
                        //objBL.Query = "select sum(TotalDays) from leaveapplication where EmployeeId=" + objPC.EmployeeId + " and FromDate and ToDate between '" + startDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + endDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and  CancelTag=0 and LeaveStatus='" + BusinessResources.LS_Completed + "' and LeaveTypeId IN(2,3)";
                        ////objBL.Query = "select sum(TotalDays) from leaveapplication where EmployeeId=" + objPC.EmployeeId + " and FromDate and ToDate between '" + startDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + endDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and  CancelTag=0 and LeaveStatus='" + BusinessResources.LS_Completed + "' "; // and LeaveTypeId IN(2,3)";
                        //dtSum = objBL.ReturnDataTable();

                        //if (dtSum.Rows.Count > 0)
                        //    objPC.TotalLeave_Count = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(dtSum.Rows[0][0])));

                        //objPC.RevertLeave_Count = 0;
                        //DataTable dtRevertLeave = new DataTable();
                        //objBL.Query = "select sum(TotalDays) from leaveapplication where EmployeeId=" + objPC.EmployeeId + " and FromDate and ToDate between '" + startDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + endDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and  CancelTag=0 and LeaveStatus='" + BusinessResources.LS_Completed + "' and IsRevertLeave=1";
                        //dtRevertLeave = objBL.ReturnDataTable();

                        //if (dtRevertLeave.Rows.Count > 0)
                        //    objPC.RevertLeave_Count = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(dtRevertLeave.Rows[0][0])));

                        //if (dtSum.Rows.Count > 0 || dtRevertLeave.Rows.Count > 0)
                        //{
                        //    objPC.Balance_Count = (objPC.TotalApplicableLeave_Count - objPC.TotalLeave_Count) + objPC.RevertLeave_Count;

                        //    objBL.Query = "update Employees set EnjoyLeave='" + objPC.TotalLeave_Count + "',BalanceLeave='" + objPC.Balance_Count + "' where CancelTag=0 and EmployeeId=" + objPC.EmployeeId + "";
                        //    int Result = objBL.Function_ExecuteNonQuery();
                        //}
                    }
                }
                Update_Present_Absent();
                objRL.ShowMessage(45, 1);
            }
        }

        public void ReCalculate_Funcation(DateTime startDate, DateTime endDate)
        {
            DateTime dtpFromDateL, dtpToDateL;
            DataSet ds = new DataSet();
            //objBL.Query = "select * from leaveapplication where CancelTag=0 and LeaveStatus='"+BusinessResources.LS_Completed+"' ";
            //SELECT * FROM leaveapplication where FromDate and ToDate between '2024-02-01' and '2024-02-29' and  CancelTag=0 and LeaveStatus='Completed' and EmployeeId IN(select distinct EmployeeId from attendancerecord where CancelTag=0 and Status NOT IN('L')) order by LeaveApplicationId

            //objBL.Query = "SELECT * FROM leaveapplication where FromDate and ToDate between '" + startDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + endDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and  CancelTag=0 and LeaveStatus='" + BusinessResources.LS_Completed + "' and EmployeeId IN(select distinct EmployeeId from attendancerecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId  where ARM.AttendanceDate between '" + startDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + endDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and AR.CancelTag=0 and ARM.CancelTag=0 and AR.Status NOT IN('L')) order by LeaveApplicationId";
                
            objBL.Query = "SELECT * FROM leaveapplication where FromDate and ToDate between '" + startDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + endDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and  CancelTag=0 and LeaveStatus='" + BusinessResources.LS_Completed + "' order by EmployeeId";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    objPC.ClearAttendanceRecords();

                    //LeaveApplicationId bigint AI PK 
                    //EntryDate date 
                    //EmployeeId bigint 
                    //FromDate date 
                    //ToDate date 
                    //TotalDays varchar(45) 
                    //LeaveTypeId int 
                    //LeaveReason text 
                    //LeaveStatus varchar(100) 
                    //Remarks text 
                    //IsRevertLeave in

                    objPC.TotalLeave_Count = 0;
                    objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeId"])));
                    objPC.TotalLeave_Count = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["TotalDays"])));

                    DataSet dsEMP = new DataSet();
                    dsEMP = objQL.SP_Employees_By_EmployeeId();

                    if (dsEMP.Tables[0].Rows.Count > 0)
                    {
                        objRL.Get_CategoriesDetails_By_Id();
                        objPC.ShiftGroupId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEMP.Tables[0].Rows[0]["ShiftGroupId"])));
                        objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEMP.Tables[0].Rows[0]["OverTimeApplicable"])));

                        objPC.TotalApplicableLeave_Count = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(dsEMP.Tables[0].Rows[0]["TotalApplicableLeave"])));

                        //double sum = 0;

                        //DataTable dataTable = ds.Tables[0];
                        //string columnName = "TotalDays";

                        ////foreach (DataRow row in dataTable.Rows)
                        ////{
                        ////    sum += Convert.ToDouble(row[columnName]);
                        ////}

                        //string condition = "EmployeeId="+objPC.EmployeeId+"";

                        //DataRow[] filteredRows = dataTable.Select(condition);
                        //objPC.TotalLeave_Count = 0;
                        //foreach (DataRow row in filteredRows)
                        //{
                        //    objPC.TotalLeave_Count += Convert.ToDouble(row[columnName]);
                        //}


                        dtpFromDateL = Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["FromDate"])));
                        dtpToDateL = Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["FromDate"])));

                        //if (objPC.CalculateFor == "Leave")
                        //    Calculate_Leaves_EmployeeMaster();
                        //else
                            CalculationsDate_Leave(dtpFromDateL, dtpToDateL);
                    }
                }
                objRL.ShowMessage(45, 1);
                
                //ClearAll();
            }
        }

        public void ReCalculate__Leave_Attendance_Funcation()
        {
            DateTime dtpFromDateL, dtpToDateL;

            DataSet ds = new DataSet();
            //objBL.Query = "SELECT * FROM leaveapplication where CancelTag=0 and LeaveStatus='" + BusinessResources.LS_Completed + "' order by EmployeeId";
            objBL.Query = "SELECT * FROM leaveapplication where CancelTag=0 and LeaveStatus='" + BusinessResources.LS_Completed + "' order by EmployeeId";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    objPC.ClearAttendanceRecords();

                    //LeaveApplicationId bigint AI PK 
                    //EntryDate date 
                    //EmployeeId bigint 
                    //FromDate date 
                    //ToDate date 
                    //TotalDays varchar(45) 
                    //LeaveTypeId int 
                    //LeaveReason text 
                    //LeaveStatus varchar(100) 
                    //Remarks text 
                    //IsRevertLeave in

                    objPC.TotalLeave_Count = 0;
                    objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeId"])));
                    objPC.TotalLeave_Count = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["TotalDays"])));

                    DataSet dsEMP = new DataSet();
                    dsEMP = objQL.SP_Employees_By_EmployeeId();

                    if (dsEMP.Tables[0].Rows.Count > 0)
                    {
                        objRL.Get_CategoriesDetails_By_Id();
                        objPC.ShiftGroupId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEMP.Tables[0].Rows[0]["ShiftGroupId"])));
                        objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsEMP.Tables[0].Rows[0]["OverTimeApplicable"])));
                        objPC.TotalApplicableLeave_Count = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(dsEMP.Tables[0].Rows[0]["TotalApplicableLeave"])));
                        
                        dtpFromDateL = Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["FromDate"])));
                        dtpToDateL = Convert.ToDateTime(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["ToDate"])));

                        CalculationsDate_Leave(dtpFromDateL, dtpToDateL);
                    }
                }
               // objRL.ShowMessage(45, 1);

                //ClearAll();
            }
        }
        public void Calculate_Leaves_EmployeeMaster()
        {
            objPC.Balance_Count = objPC.TotalApplicableLeave_Count - objPC.TotalLeave_Count;
            objBL.Query = "update Employees set BalanceLeave='" + objPC.Balance_Count + "' where CancelTag=0 and EmployeeId=" + objPC.EmployeeId + "";
            int Result= objBL.Function_ExecuteNonQuery();
        }

        public void Update_Present_Absent()
        {
            objBL.Query = "update attendancerecord set Present=0.5, Absent=0.5 where Status='HD'";
            objBL.Function_ExecuteNonQuery();
            objBL.Query = "update attendancerecord set Absent=1,Present=0 where Status='A'";
            objBL.Function_ExecuteNonQuery();
            objBL.Query = "update attendancerecord set Absent=0,Present=0 where Status='WO'";
            objBL.Function_ExecuteNonQuery();
            objBL.Query = "update attendancerecord set Absent=0,Present=0 where Status='WOP'";
            objBL.Function_ExecuteNonQuery();
            objBL.Query = "update attendancerecord set Present=1, Absent=0 where Status='P'";
            objBL.Function_ExecuteNonQuery();
            objBL.Query = "update attendancerecord set Present=0,Absent=0 where Status='L'";
            objBL.Function_ExecuteNonQuery();
            objBL.Query = "update attendancerecord set Present=0, Absent=0 where Status='CO'";
            objBL.Function_ExecuteNonQuery();
            objBL.Query = "update attendancerecord set Present=0, Absent=0 where Status='COU'";
            objBL.Function_ExecuteNonQuery();
        }

        public void CalculationsDate_Leave(DateTime dtpFromDateL, DateTime dtpToDateL)
        {
            GetDatesBetween(dtpFromDateL, dtpToDateL);

            if (allDates.Count > 0)
            {
                for (int j = 0; j < allDates.Count; j++)
                {
                    objPC.AttendanceDate = Convert.ToDateTime(allDates[j]);
                    objPC.AttendanceDay = objPC.AttendanceDate.DayOfWeek.ToString();

                    DataSet dsExist = new DataSet();
                    //objBL.Query = "select AR.EmployeeId from attendancerecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId  where AR.Status='L' and ARM.AttendanceDate='" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and AR.EmployeeId=" + objPC.EmployeeId + " and AR.CancelTag=0 and ARM.CancelTag=0 ";

                    objBL.Query = "select AR.EmployeeId,AR.AttendanceRecordId,AR.AttendanceRecordMasterId,AR.Status from attendancerecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId  where ARM.AttendanceDate='" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and AR.EmployeeId=" + objPC.EmployeeId + " and AR.CancelTag=0 and ARM.CancelTag=0 ";
                    dsExist = objBL.ReturnDataSet();

                    if (dsExist.Tables[0].Rows.Count > 0)
                    {
                        string SCode = string.Empty;

                        SCode = objRL.CheckNullString(Convert.ToString(dsExist.Tables[0].Rows[0]["Status"]));

                        if(SCode !="L" && SCode != "RL")
                        {
                            objPC.IsRevertLeave = 0;

                            objPC.EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsExist.Tables[0].Rows[0]["EmployeeId"])));
                            objPC.AttendanceRecordId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsExist.Tables[0].Rows[0]["AttendanceRecordId"])));
                            objPC.AttendanceRecordMasterId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsExist.Tables[0].Rows[0]["AttendanceRecordMasterId"])));

                            objPC.LeaveTypeFlag = false;
                            AttendanceWorking();

                            int Result = 0;
                            Result = objQL.SP_AttendanceRecord_Insert_Update();

                            if (Result > 0)
                            {
                                Save_AttendanceMonthlyData();
                                objPC.AttendanceRecordId = 0;
                                objPC.ClearAttendanceRecords();
                            }
                        }
                    }
                }
            }
        }

        public void Clear_Attendance()
        {
            objPC.EsslAttendanceLogsId = 0;
            objPC.ESSLEmployeeId = 0;

            dt = Convert.ToDateTime("1900-01-01 00:00:00");
            objPC.OverTime = "00:00";
            objPC.Duration = "00:00";
            objPC.TotalDuration = "00:00";
            //objPC.MissedInPunch = 0;
            //objPC.MissedOutPunch = 0;
            objPC.LateBy = 0;
            objPC.EarlyBy = 0;
            objPC.Present = 0;
            objPC.Absent = 0;
            objPC.ChangeDepartmentFlag = 0;
            objPC.ChangeDepartmentId = 0;
            objPC.ChangeLocationtId = 0;
            objPC.LeaveType = string.Empty;
            objPC.LeaveTypeId = 0;

            objPC.ShiftHours_TS = TimeSpan.Zero;
            objPC.BeginTimeShift_TS = TimeSpan.Zero;
            objPC.EndTimeShift_TS = TimeSpan.Zero;

            objPC.TotalDuration_TS = TimeSpan.Zero;
            objPC.Duration_TS = TimeSpan.Zero;

            objPC.Duration = "00:00";
            objPC.OverTime = "00:00";
            objPC.TotalDuration = "00:00";
            objPC.Remarks = "";
            //objPC.PunchRecords = "";
        }

        //Duration C
        public void Get_WorkDuration()
        {
            objPC.Duration_TS = TimeSpan.Zero;

            TimeSpan ts1 = TimeSpan.Parse(Convert.ToString(objPC.InTime.TimeOfDay)); // new TimeSpan(19, 9, 0);
            TimeSpan ts2 = TimeSpan.Parse(Convert.ToString(objPC.OutTime.TimeOfDay)); // new TimeSpan(7, 18, 0);

            //TimeSpan ts3 = TimeSpan.Parse(Convert.ToString(objPC.InTime.TimeOfDay)); // new TimeSpan(19, 9, 0);
            TimeSpan result = ts1 - ts2;

            //objPC.Duration_TS = TimeSpan.Zero;
            objPC.Duration_TS = objPC.OutTime.Subtract(objPC.InTime);
            //objPC.Duration_TS = objPC.InTime.Subtract(objPC.OutTime);

            //objPC.Duration_TS = result;
            objPC.DurationHours_Double = Convert.ToDouble(objPC.Duration_TS.Hours);
            objPC.Duration = Get_String_TimeSpan(objPC.Duration_TS);

            //if (objPC.InTime > objPC.OutTime)
            //{
            //    objPC.Duration_TS = objPC.InTime.Subtract(objPC.OutTime);
            //}
            //else
            //{
            //    objPC.Duration_TS = objPC.OutTime.Subtract(objPC.InTime);
            //}

            //objPC.Duration_TS = objPC.OutTime.Subtract(objPC.InTime);
            //objPC.DurationHours_Double = objPC.Duration_TS.Hours;
            ////objPC.Duration = Convert.ToString(objPC.Duration_TS);
            //objPC.Duration = Get_String_TimeSpan(objPC.Duration_TS);

            if (objPC.Duration_TS.Hours <= 0)
                objPC.Duration_TS = TimeSpan.Zero;
        }

        public void Get_Shift_Details_By_ShiftGroup()
        {
            //Shift Group
            if (objPC.ShiftGroupId > 0)
            {
                DateTime dtCheck = objPC.InTime;
                string dtString = string.Empty;
                dtString = objPC.InTime.ToString(BusinessResources.TimeFormat_HHMM);

                DataSet ds = new DataSet();

                if (dtString == "00:00")
                    Absent_Shift();
                else
                {
                    objBL.Query = "SELECT S.* FROM shifts S inner join shiftgroupshifts sgs on sgs.ShiftId=S.ShiftId inner join shiftgroups sg on sg.ShiftGroupId=sgs.ShiftGroupId where S.CancelTag=0 and sgs.CancelTag=0 and sg.CancelTag=0  and sg.ShiftGroupId=" + objPC.ShiftGroupId + " order by abs(time_to_sec(timediff(S.BeginTime, '" + dtString + "'))) limit 1";
                    ds = objBL.ReturnDataSet();

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        objPC.ShiftId = Convert.ToInt32(ds.Tables[0].Rows[0]["ShiftId"].ToString());
                        objPC.ShiftName = Convert.ToString(ds.Tables[0].Rows[0]["ShiftFName"].ToString());

                        objPC.BeginTime_Shift_DT = Convert.ToDateTime(ds.Tables[0].Rows[0]["BeginTime"].ToString());
                        objPC.EndTime_Shift_DT = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndTime"].ToString());

                        objPC.ShiftDuration = Convert.ToString(ds.Tables[0].Rows[0]["ShiftDuration"].ToString());
                        objPC.ShiftDurationHours = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ShiftDurationHours"].ToString()));

                        objPC.ShiftHours_TS = TimeSpan.Parse(Convert.ToString(objPC.ShiftDurationHours));

                        objPC.BeginTimeShift_TS = TimeSpan.Parse(Convert.ToString(objPC.BeginTime_Shift_DT.TimeOfDay));
                        objPC.EndTimeShift_TS = TimeSpan.Parse(Convert.ToString(objPC.EndTime_Shift_DT.TimeOfDay));  //TimeSpan.Parse(Convert.ToString(objPC.EndTime_Shift_DT));

                        objPC.ShiftDuration = Get_String_TimeSpan(objPC.ShiftHours_TS);
                    }
                    else
                    {
                        Absent_Shift();
                        //Get_Shift_Details_by_ShiftName();
                    }
                }
            }
        }

        public void Absent_Shift()
        {
            dt = Convert.ToDateTime("1900-01-01 00:00:00");
            objPC.InTime = dt;
            objPC.OutTime = dt;
            objPC.ShiftFName = "NoShift";
            Get_Shift_Details_ByName_ById("Name", "NoShift");
        }

        public void Get_Attendance_Day_WeeklyOff()
        {
            WeeklyOffFlag = false;
            objPC.AttendanceDay = objPC.AttendanceDate.DayOfWeek.ToString();
            if (objPC.AttendanceDay == objPC.WeeklyOff1Value)
                WeeklyOffFlag = true;
        }
        public void AttendanceWorking()
        {
            //if (objPC.EmployeeId == 6)
            //{
            //}

           

            if (objPC.MissedOutPunch ==0)
                Clear_Attendance();
            //objPC.LeaveTypeFlag = true;
            if (!objPC.LeaveTypeFlag)
            {
                objPC.LeaveType = string.Empty;
                objPC.LeaveApplicationId = 0;
                objPC.LeaveTypeId = 0;
                objPC.LeaveType = "";
                objPC.LeaveDuration = 0;
                objPC.LeaveRemarks = "";
                objPC.IsRevertLeave = 0;
                LeaveDetailsEmployees();
            }

            if (objPC.LeaveTypeId != 0) // && objPC.EditFlag ==0)
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
                //Clear_Attendance();

                dt = Convert.ToDateTime("1900-01-01 00:00:00");
                objPC.InTime = dt;
                objPC.OutTime = dt;
                Absent_Shift();

                //if (objPC.LeaveType == "Casual Leave" || objPC.LeaveType == "Paid Leave" || objPC.LeaveType == "Sick Leave" || objPC.LeaveType == "Maternity Leave" || objPC.LeaveType == "Medical Leave")
                
                if(objPC.IsRevertLeave ==1)
                    objPC.StatusCode = "RL";
                else if (objPC.LeaveType == "Casual Leave" || objPC.LeaveType == "Paid Leave" || objPC.LeaveType == "Sick Leave" || objPC.LeaveType == "Maternity Leave" || objPC.LeaveType == "Medical Leave")
                    objPC.StatusCode = "L";
                else if (objPC.LeaveType == "Special Leave")
                    objPC.StatusCode = "SL";
                else
                {

                }
                //else if (objPC.LeaveType == "Compensation Off")
                //    objPC.StatusCode = "CO";
                //else if (objPC.LeaveType == "Compensation Off Used")
                //    objPC.StatusCode = "COU";
                //else if (objPC.LeaveType == "Revert Leave")
                //    objPC.StatusCode = "COU";
                //else
                //    objPC.StatusCode = "L";
            }
            else
            {
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

                Get_Attendance_Day_WeeklyOff();
                Get_Holiday();
                Get_Shift_Details_By_ShiftGroup();
                Get_WorkDuration();
                LateBy_And_Early_Calculation();

                objPC.CompOffFlag = false;
                CompOff_Details_By_Date_EmployeeId_Date("CompOff");
                CompOff_Details_By_Date_EmployeeId_Date("CompOffUsed");

                if (objPC.DurationHours_Double > 0)
                {
                    OverTimeCalculations();
                    CalculateTotalDuration();
                   // OT_Working_All();
                    
                    double CategoryHours_HalfDay_Duration = 0, CategoryHours_AbsentDay_Duration = 0;

                    if (!string.IsNullOrEmpty(Convert.ToString(objPC.CalculateHalfDayifWorkDurationIsLessThanMins)))
                        CategoryHours_HalfDay_Duration = Convert.ToDouble(Convert.ToDouble(objPC.CalculateHalfDayifWorkDurationIsLessThanMins) / 60);

                    if (!string.IsNullOrEmpty(Convert.ToString(objPC.CalculationAbsentIfWorkDurationIsLessThan)))
                        CategoryHours_AbsentDay_Duration = Convert.ToDouble(Convert.ToDouble(objPC.CalculationAbsentIfWorkDurationIsLessThan) / 60);
                     
                    //Present 
                    if (objPC.DurationHours_Double > CategoryHours_HalfDay_Duration)
                    {
                         if (HolidayFlag)
                             objPC.StatusCode = "HP";
                        //if (HolidayFlag && NationalHolidayFlag == 1)
                        //    objPC.StatusCode = "HP";
                        //else if (HolidayFlag && NationalHolidayFlag == 0)
                        //    objPC.StatusCode = "HP"; // "WOP"; //HP
                        else if (WeeklyOffFlag)
                            objPC.StatusCode = "WOP";
                        else
                        {
                            if (objPC.MissedOutPunch == 0)
                                objPC.StatusCode = "P";
                            else
                            {
                                if(objPC.EditFlagTemp == 1)
                                    objPC.StatusCode = "P";
                            }
                        }
                    }
                    else if (objPC.DurationHours_Double <= CategoryHours_HalfDay_Duration)
                    {
                        if (HolidayFlag && NationalHolidayFlag == 1)
                            objPC.StatusCode =  "HP"; //"HHD";
                        else if (HolidayFlag && NationalHolidayFlag == 0)
                            objPC.StatusCode = "HP"; //"HHD";
                        else if (WeeklyOffFlag)
                            objPC.StatusCode = "WOP"; //"WOHD";
                        else
                            objPC.StatusCode = "HD";
                    }
                    else if (objPC.DurationHours_Double < CategoryHours_AbsentDay_Duration)
                    {
                        Clear_Attendance();
                        objPC.StatusCode = "A";
                        Absent_Shift();
                    }
                    else
                    {

                    }

                    OT_Working_All();
                }
                else
                {
                    if (objPC.AttendanceDay == objPC.WeeklyOff1Value)
                    {
                        objPC.StatusCode = "WO";
                    }
                    else if (HolidayFlag)
                    {
                        if (objPC.HolidayDay == objPC.WeeklyOff1Value && NationalHolidayFlag == 1)
                            objPC.StatusCode = "WO";
                        else
                            objPC.StatusCode = "H";
                    }
                    else
                    {
                        Clear_Attendance();
                        objPC.StatusCode = "A";
                    }
                    Absent_Shift();
                }

                if (objPC.CompOffFlag)
                {
                    if (objPC.CompOffUsedFlag == 0)
                        objPC.StatusCode = "CO";
                    else
                        objPC.StatusCode = "COU";
                }

                if (objPC.ShiftId == 0)
                    Absent_Shift();
            }
        }

        bool HolidayFlag = false;
        bool WeeklyOffFlag = false;
        int NationalHolidayFlag = 0;

        public void Get_Holiday()
        {
            HolidayFlag = false;
            NationalHolidayFlag = 0;
            //Get Holiday list checking
            DataSet ds = new DataSet();
            //objBL.Query = "select HolidayId,HolidayDate,HolidayDay,Festival,NationalHolidayFlag from HolidayMaster where HolidayDate='" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and CancelTag=0";
            objBL.Query = "select H.HolidayId,H.HolidayDate,H.HolidayDay,H.Festival,H.NationalHolidayFlag,H.HolidayType from HolidayMaster H inner join HolidayLocation HL on H.HolidayId=HL.HolidayId where H.HolidayDate='" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and H.CancelTag=0 and HL.CancelTag=0 and HL.LocationId=" + objPC.LocationId + "";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                HolidayFlag = true;
                NationalHolidayFlag = objRL.CheckNullString_ReturnInt(Convert.ToString(ds.Tables[0].Rows[0]["NationalHolidayFlag"]));
                objPC.HolidayDay = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["HolidayDay"]));
            }
        }
        public void LateBy_And_Early_Calculation()
        {
            objPC.LateBy = 0;
            objPC.LateBy_TS = objPC.InTime.TimeOfDay.Subtract(objPC.BeginTime_Shift_DT.TimeOfDay);
            //objPC.LateBy_TS = objPC.InTime.Subtract(objPC.InTime_Shift_Date);
            objPC.LateBy_String = string.Format("{0}:{1}", objPC.LateBy_TS.Hours, objPC.LateBy_TS.Minutes);
            objPC.LateBy = (int)objPC.LateBy_TS.Minutes;

            if (objPC.LateBy > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(objPC.GraceTimeForLateComingMins)))
                {
                    if (objPC.LateBy < Convert.ToDouble(objPC.GraceTimeForLateComingMins))
                        objPC.LateBy = 0;
                }
            }
            else
                objPC.LateBy = 0;
          
            ////if (objPC.LateBy < 0)
            ////    objPC.LateBy = 0;

            //if (!string.IsNullOrEmpty(Convert.ToString(objPC.GraceTimeForLateComingMins)))
            //{
            //    if (objPC.LateBy < Convert.ToDouble(objPC.GraceTimeForLateComingMins))
            //        objPC.LateBy = 0;
            //}
            //else
            //{
            //    if (objPC.LateBy < 0)
            //        objPC.LateBy = 0;
            //}
            
            objPC.EarlyBy = 0;
            //objPC.EarlyBy_TS = objPC.OutTime.TimeOfDay.Subtract(objPC.EndTime_Shift_DT.TimeOfDay);
            objPC.EarlyBy_TS = objPC.EndTime_Shift_DT.TimeOfDay.Subtract(objPC.OutTime.TimeOfDay);
            objPC.EarlyBy_String = string.Format("{0}:{1}", objPC.EarlyBy_TS.Hours, objPC.EarlyBy_TS.Minutes);
            objPC.EarlyBy = (int)objPC.EarlyBy_TS.Minutes;

            if (objPC.EarlyBy > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(objPC.GraceTimeForEarlyGoingMins)))
                {
                    if (objPC.EarlyBy < Convert.ToDouble(objPC.GraceTimeForEarlyGoingMins))
                        objPC.EarlyBy = 0;
                }
            }
            else
                objPC.EarlyBy = 0;
          
            //if (!string.IsNullOrEmpty(Convert.ToString(objPC.GraceTimeForEarlyGoingMins)))
            //{
            //    if (objPC.EarlyBy < Convert.ToDouble(objPC.GraceTimeForEarlyGoingMins))
            //        objPC.EarlyBy = 0;
            //}
            //else
            //{
            //    if (objPC.EarlyBy < 0)
            //        objPC.EarlyBy = 0;
            //}

            //if (objPC.EarlyBy < Convert.ToDouble(objPC.GraceTimeForEarlyGoingMins))
            //    objPC.EarlyBy = 0;

            //if (objPC.EarlyBy < 0)
            //    objPC.EarlyBy = 0;
        }

        public void MissedPunchIn_Calculations()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(objPC.MissedInPunch)))
            {
                if (objPC.MissedInPunch != 0) // || objPC.MissedInPunch == "True")
                    objPC.MissedInPunch = 1;
                else
                    objPC.MissedInPunch = 0;
            }
            else
                objPC.MissedInPunch = 0;
        }

        public void MissedPunchOut_Calculations()
        {
            if (!string.IsNullOrEmpty(Convert.ToString(objPC.MissedOutPunch)))
            {
                if (objPC.MissedOutPunch != 0) // || objPC.MissedOutPunch == "True")
                    objPC.MissedOutPunch = 1;
                else
                    objPC.MissedOutPunch = 0;
            }
            else
                objPC.MissedOutPunch = 0;
        }

        public void CompOff_Details_By_Date_EmployeeId_Date(string CompType)
        {
            //if (objPC.EmployeeCode == 663)
            //{
            //    //
            //}
            DataTable dt = new DataTable();
            WhereClause = string.Empty;
            MainQuery = string.Empty;

            if (CompType == "CompOff")
                WhereClause = " and COA.CompOffDate='" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and COA.CompStatus='"+BusinessResources.LS_Completed+"'";
            else
                WhereClause = " and COA.UsedCompOffDate='" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and COA.CompOffUsedFlag=1 and COA.CompUsedStatus='" + BusinessResources.LS_Completed + "'";
            
            MainQuery = "select " +
                         "COA.CompOffApplicationId," +
                         "COA.EntryDate," +
                         "COA.EmployeeId," +
                         "E.EmployeeName," +
                         "DES.Designation," +
                         "COA.LeaveTypeId," +
                         "L.LeaveTypeFName," +
                         "COA.CompOffDate," +
                         "COA.CompOffDay," +
                         "COA.HolidayType," +
                         "COA.Festival," +
                         "COA.CompOffReason," +
                         "COA.WorkRemarks," +
                         "COA.CompStatus," +
                         "COA.CompOffDueDate," +
                         "COA.CompOffUsedFlag, " +
                         "COA.UsedCompOffDate, "+
                         "COA.UsedCompOffDay " +
                         " from " +
                             " compoffapplication COA inner join " +
                             " leavetypes L on L.LeaveTypeId=COA.LeaveTypeId inner join " +
                             " Employees E on E.EmployeeId=COA.EmployeeId inner join " +
                             " DepartmentMaster DM on DM.DepartmentId=E.DepartmentId inner join " +
                             " DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
                             " LocationMaster LM on LM.LocationId=E.LocationId " +
                         " where " +
                             " L.CancelTag=0 and " +
                             " COA.CancelTag=0 and " +
                             " E.CancelTag=0 and " +
                             " DM.CancelTag=0 and " +
                             " DES.CancelTag=0 and " +
                             " LM.CancelTag=0 and " +
                             " COA.EmployeeId=" + objPC.EmployeeId + "";

            //objBL.Query = "select * from compoffapplication inner join leavetypes L on L.LeaveTypeId=COA.LeaveTypeId inner join where CompOffUsedFlag=0 and CancelTag=0 and CompOffDate='" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and EmployeeId=" + objPC.EmployeeId + "";
            objBL.Query = MainQuery + WhereClause;
            dt = objBL.ReturnDataTable();

            if (dt.Rows.Count > 0)
            {
                objPC.LeaveTypeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["LeaveTypeId"])));
                objPC.LeaveTypeFName = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["LeaveTypeFName"]));
                objPC.CompOffDate = Convert.ToDateTime(dt.Rows[0]["CompOffDate"]);
                objPC.HolidayType = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["HolidayType"]));
                objPC.Festival = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["Festival"]));
                objPC.WorkRemarks = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["WorkRemarks"]));
                objPC.CompStatus = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["CompStatus"]));

                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["UsedCompOffDate"])))
                {
                    objPC.UsedCompOffDate = Convert.ToDateTime(dt.Rows[0]["UsedCompOffDate"]);
                    objPC.UsedCompOffDay = objRL.CheckNullString(Convert.ToString(dt.Rows[0]["UsedCompOffDay"]));
                    objPC.CompOffDueDate = Convert.ToDateTime(dt.Rows[0]["CompOffDueDate"]);
                }
                if (CompType != "CompOff")
                    objPC.CompOffUsedFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0]["CompOffUsedFlag"])));
                else
                    objPC.CompOffUsedFlag = 0;

                objPC.CompOffFlag = true;
            }
        }

        public void LeaveDetailsEmployees()
        {
            objPC.LeaveTypeId = 0;
            objPC.LeaveType = "";
            DataSet ds = new DataSet();
            ds = objQL.SP_LeaveApplication_By_EmployeeId();

            //if (objPC.EmployeeId == 37)
            //{ }
            if (ds.Tables[0].Rows.Count > 0)
            {
                objPC.LeaveApplicationId= objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LeaveApplicationId"])));
                objPC.LeaveTypeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LeaveTypeId"])));
                objPC.LeaveType = Convert.ToString(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LeaveTypeFName"])));
                objPC.LeaveDuration = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["TotalDays"])));
                objPC.LeaveRemarks = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["LeaveReason"]));
                objPC.IsRevertLeave = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["IsRevertLeave"])));
            }
        }

        string WhereClause = string.Empty;

        public void Get_Shift_Details_ByName_ById(string SearchBy, string SearchValue)
        {
            WhereClause = string.Empty;

            DataSet ds = new DataSet();
            
            if (SearchBy == "Id")
                WhereClause = " and ShiftId=" + SearchValue + "";
            else
                WhereClause = " and ShiftFName='" + SearchValue + "'";

            objBL.Query = "select *	from Shifts where CancelTag=0 " + WhereClause + "";
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                objPC.ShiftId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ShiftId"])));
                objPC.ShiftName = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ShiftFName"]));

                objPC.BeginTime_Shift_DT = Convert.ToDateTime(ds.Tables[0].Rows[0]["BeginTime"].ToString());
                objPC.EndTime_Shift_DT = Convert.ToDateTime(ds.Tables[0].Rows[0]["EndTime"].ToString());

                objPC.ShiftDuration = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ShiftDurationHours"]));
                objPC.ShiftDurationHours = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["ShiftDurationHours"]));
            }
        }

        double OTHoursCal = 0, OTMinCal = 0;
        string ConHours = string.Empty;

        public static TimeSpan Round(TimeSpan input)
        {
            if (input < TimeSpan.Zero)
            {
                return -Round(-input);
            }
            int hours = (int)input.TotalHours;
            if (input.Minutes >= 30)
            {
                hours++;
            }
            return TimeSpan.FromHours(hours);
        }
        public void OverTimeCalculations()
        {
            try
            {
                OTHoursCal = 0; OTMinCal = 0;
                ConHours = string.Empty;

                objPC.OverTime = "00:00";

                objPC.OTHours_TS = TimeSpan.Zero;
                 
                if (objPC.OTFormula == "Total Duration - Shift Hours")
                    objPC.OTHours_TS = objPC.Duration_TS - objPC.ShiftHours_TS;
                else
                    objPC.OTHours_TS = objPC.OutTime_TS - objPC.EndTimeShift_TS;

                objPC.OTHours_TS = Round(objPC.OTHours_TS);

                //TimeSpan OTMinutes_Span = TimeSpan.FromMinutes(objPC.OTHours_TS.Minutes);
                //TimeSpan OTHours_Span = TimeSpan.FromHours(objPC.OTHours_TS.Hours);

                //OTHoursCal = Math.Round(Convert.ToDouble(objPC.OTHours_TS.Hours), 0);
                //OTMinCal = Math.Round(Convert.ToDouble(objPC.OTHours_TS.Minutes), 0);

                //if (OTHoursCal > 22)
                //{
                //    OTHoursCal = 22;
                //}

                //if (OTHoursCal > 0)
                //{
                //    if (OTMinCal > 31)
                //        OTHoursCal += 1;
                //}
                //else
                //{
                //    if (OTMinCal > 31)
                //        OTHoursCal = 1;
                //    else
                //        OTHoursCal = 0;
                //}
                
                //ConHours = OTHoursCal + ":00";
                //TimeSpan OTHoursMy = TimeSpan.Parse(ConHours);
               
                ////objPC.OverTime = ConHours.ToString();

                //if(OTHoursCal <= 0)
                //    objPC.OTHours_TS = TimeSpan.Zero;

                if(objPC.OTHours_TS.Hours <= 0)
                    objPC.OTHours_TS = TimeSpan.Zero;

                //if (objPC.OvertimeFlag == 1)
                //{
                //    if (OTHoursCal > 0)
                //        objPC.OverTime = objPC.TotalDuration;
                //    else
                //        objPC.OverTime = "00:00";
                //}
            }
            catch (Exception ex1)
            {
                //MessageBox.Show(ex1.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        public void CalculateTotalDuration()
        {
            objPC.TotalDuration_TS = TimeSpan.Zero;
            objPC.TotalDuration_TS = objPC.Duration_TS; // +objPC.OTHours_TS;
            objPC.TotalDuration = Get_String_TimeSpan(objPC.TotalDuration_TS);

            //if (objPC.OvertimeFlag == 1 && WeeklyOffFlag)
            //{
            //    if (OTHoursCal > 0)
            //    {
            //        objPC.OverTime = objPC.TotalDuration;
            //    }
            //}
            
            if(objPC.TotalDuration_TS.Hours <= 0)
                objPC.TotalDuration_TS = TimeSpan.Zero;

            //if (objPC.Duration_TS.Hours > 0)
            //{
            //    if (objPC.OverTimeApplicable == 1)
            //    {
            //        Round(objPC.Duration_TS);

            //        if (WeeklyOffFlag)
            //            objPC.OverTime = objPC.TotalDuration;
            //        else
            //            objPC.OverTime = ConHours.ToString();
            //    }
            //    else
            //        objPC.OverTime = "00:00";
            //}
            //else
            //    objPC.OverTime = "00:00";


            //if (objPC.OvertimeFlag == 1)
            //{
            //    if (OTHoursCal > 0)
            //        objPC.OverTime = objPC.TotalDuration;
            //    else
            //        objPC.OverTime = "00:00";
            //}
        }

        public void OT_Working_All()
        {
            TimeSpan OTValue = TimeSpan.Zero;
            objPC.OverTime = "00:00";

            if (objPC.OverTimeApplicable == 1)
            {
                if (objPC.Duration_TS.Hours > 0)
                {
                    //if (objPC.OTFormula == "Total Duration - Shift Hours")
                    //    objPC.OTHours_TS = objPC.Duration_TS - objPC.ShiftHours_TS;
                    //else
                    //    objPC.OTHours_TS = objPC.OutTime_TS - objPC.EndTimeShift_TS;

                    //OTValue = Round(objPC.Duration_TS);


                    if (objPC.StatusCode == "HP" || objPC.StatusCode == "WOP" || objPC.StatusCode == "HHD" || objPC.StatusCode == "WOHD") // if (WeeklyOffFlag)
                    {
                        OTValue = objPC.TotalDuration_TS;
                        //objPC.OverTime = objPC.TotalDuration;
                    }
                    else
                    {
                        OTValue = objPC.OTHours_TS;
                        //objPC.OverTime = ConHours.ToString();
                    }
                }
            }

            if (OTValue.Hours > 0)
            {
               TimeSpan OTValue1= Round(OTValue);

                if(OTValue1.Hours>0)
                    objPC.OverTime = Get_String_TimeSpan(OTValue1); //.ToString();
            }
        }
        public string Get_String_TimeSpan(TimeSpan Value1)
        {
           //return string.Format("{0}:{1}", Value1.Hours, Value1.Minutes);
            return string.Format("{0:D2}:{1:D2}", Value1.Hours, Value1.Minutes);
        }

        string InTime_I = string.Empty, OutTime_I = string.Empty;
        double TotalPresent = 0, TotalAbsent = 0, TotalOT = 0, TotalHours = 0, TotalWeeklyOff = 0, TotalHoliday = 0, TotalLateBy = 0, TotalEarlyBy = 0;

        public void Save_AttendanceMonthlyData()
        {
            DateTime AttDate = objPC.AttendanceDate;

            int MonS = AttDate.Month;
            int DayS = AttDate.Day;
            int yearS = AttDate.Year;

            string In1 = string.Empty, Out1 = string.Empty, Duration1 = string.Empty, Status1 = string.Empty, OT1 = string.Empty, LT1 = string.Empty, AtId = string.Empty, ShiftId = string.Empty;

            InTime_I = string.Empty; OutTime_I = string.Empty;

            In1 = "In" + DayS.ToString();
            Out1 = "Out" + DayS.ToString();
            Duration1 = "Duration" + DayS.ToString();
            Status1 = "Status" + DayS.ToString();
            OT1 = "OT" + DayS.ToString();
            LT1 = "LT" + DayS.ToString();

            AtId = "AtId" + DayS.ToString();
            ShiftId = "ShiftId" + DayS.ToString();

            int R = 0;

            // int EID = objPC.EmployeeId; // Convert.ToInt32(Convert.ToDouble(dataGridView1.Rows[i].Cells["clmEmployeeId"].Value));
            objPC.AMonth = MonS;
            objPC.AYear = yearS;
            //objPC.EmployeeId = EID; // objPC.EmployeeId;

            InTime_I = objPC.InTime.ToString("HH:mm");
            OutTime_I = objPC.OutTime.ToString("HH:mm");

            //Id bigint AI PK 
            //AttendanceIdD1 bigint 
            //AttendanceIdD2 int 
            //AttendanceIdD3 int

            //objBL.Query = "insert into attendancetest(" + In1 + ") values(" + objPC.AttendanceRecordId + ")";
            //R = objBL.Function_ExecuteNonQuery();

            //½P	0.5
            //A	    0
            //A(OD)	0
            //H	    1   
            //H½P	0.5
            //HA	0
            //HP	1
            //P	    1
            //P(OD)	1
            //WO	1
            //WO½P	0.5
            //WOA	0
            //WOP	1



            TotalPresent = 0; TotalAbsent = 0; TotalOT = 0; TotalHours = 0; TotalWeeklyOff = 0; TotalHoliday = 0; TotalLateBy = 0; TotalEarlyBy = 0;

            string TotalColumnName = string.Empty;

            SCode = objPC.StatusCode;

            //1	A	Absent	0
            //2	WO	Weekly off	
            //3	WOP	Weekly off Present	
            //4	H	Holiday	
            //5	P	Present	
            //6	HD	Half Day
            //7	HP	Holiday Present	
            //8	L	Leave
            //9	CO	Comp off

            if (SCode == "A")
                TotalAbsent = 1;
            else if (SCode == "WO")
                TotalWeeklyOff = 1;
            else if (SCode == "WOP")
                TotalPresent = 1;
            else if (SCode == "H")
                TotalHoliday = 1;
            else if (SCode == "P")
                TotalPresent = 1;
            else if (SCode == "HD")
                TotalPresent = 0.5;
            else if (SCode == "HP")
                TotalPresent = 1;
            else if (SCode == "L")
                TotalPresent = 1;
            else if (SCode == "CO")
                TotalPresent = 1;
            else if (SCode == "COU")
                TotalPresent = 1;
            else
            {

            }

            //if (SCode == "½P")
            //    TotalPresent = 0.5;
            //else if (SCode == "A")
            //    TotalAbsent = 1;
            //else if (SCode == "A(OD)")
            //    TotalAbsent = 1;
            //else if (SCode == "H")
            //    TotalHoliday = 1;
            //else if (SCode == "H½P")
            //    TotalPresent = 0.5;
            //else if (SCode == "HA")
            //    TotalAbsent = 1;
            //else if (SCode == "HP")
            //    TotalPresent = 1;
            //else if (SCode == "P")
            //    TotalPresent = 1;
            //else if (SCode == "P(OD)")
            //    TotalPresent = 1;
            //else if (SCode == "WO")
            //    TotalWeeklyOff = 1;
            //else if (SCode == "WO½P")
            //    TotalPresent = 0.5;
            //else if (SCode == "WOP")
            //    TotalPresent = 1;
            //else
            //{

            //}

            //TimeSpan DurationTotalInHours1 = TimeSpan.Parse("01:00");
            //TimeSpan DurationTotalInHours2 = TimeSpan.Parse("02:22");
            //TimeSpan DurationTotalInHours3 = TimeSpan.Parse("03:50");
            //TimeSpan DurationTotalInHours4 = TimeSpan.Parse("10:00");
            //TimeSpan DurationTotalInHours = DurationTotalInHours1 + DurationTotalInHours2 + DurationTotalInHours3+DurationTotalInHours4;
            //01:00
            //02:22
            //03:50
            //10:00

            TimeSpan DurationTotalInHours = TimeSpan.Zero;

            if (objPC.TotalDuration_TS.Hours > 0)
            {
                if(!string.IsNullOrEmpty(Convert.ToString(objPC.TotalDuration)))
                    DurationTotalInHours = TimeSpan.Parse(objRL.CheckNullString(Convert.ToString(objPC.TotalDuration)));
                else
                    DurationTotalInHours = TimeSpan.Zero;
                //DurationTotalInHours = TimeSpan.Parse(objPC.TotalDuration_TS.Hours.ToString());

            }

            //TimeSpan DurationTotalInHours = TimeSpan.Parse(objPC.TotalDuration.ToString());

            //TimeSpan DurationTotalInHours = TimeSpan.Parse(objPC.TotalDuration_TS.ToString());

            //var totalSpan = new TimeSpan(objPC.OverTime_Hours.ToString());
            //TotalOT = 0;

            //objBL.Query = "insert into test(TotalHours) values(,AMonth,EmpId," + In1 + "," + Out1 + "," + Duration1 + "," + Status1 + "," + OT1 + "," + LT1 + "," + AtId + "," + ShiftId + ",TotalPresent,TotalAbsent,TotalOT,TotalHours,TotalWeeklyOff,TotalHoliday,TotalLateBy,TotalEarlyBy) values(" + yearS + "," + MonS + "," + objPC.EmployeeId + ",'" + InTime_I + "','" + OutTime_I + "','" + objPC.TotalDuration + "','" + objPC.Status + "','" + objPC.OverTime_Hours + "','" + objPC.LateBy + "'," + objPC.AttendanceRecordId + "," + objPC.ShiftId + "," + TotalPresent + "," + TotalAbsent + "," + TotalOT + "," + TotalHours + "," + TotalWeeklyOff + "," + TotalHoliday + "," + TotalLateBy + "," + TotalEarlyBy + ")";
            //R = objBL.Function_ExecuteNonQuery();

            // var totalSpan = new TimeSpan(myCollection.Sum(r => r.TheDuration.Ticks));

            //    0
            //A(OD)	0
            //H	    1   
            //H½P	0.5
            //HA	0
            //HP	1
            //P	    1
            //P(OD)	1
            //WO	1
            //WO½P	0.5
            //WOA	0
            //WOP   1

            //OTTimes = OTTimes + OTTimes;
            //Check Exist

            if (objQL.SP_AttendanceMonthlyData_CheckExist())
            {
                //TotalHours='" + TotalDuration + "',
                //string OTH = Convert.ToString(objQL.OTHours);
                //                        string TotalDuration = Convert.ToString(objQL.TotalDurationHours);
                //objBL.Query = "update attendancemonthlydata set " + In1 + "='" + InTime_I + "'," + Out1 + "='" + OutTime_I + "'," + Duration1 + "='" + objPC.TotalDuration + "'," + Status1 + "='" + objPC.Status + "'," + OT1 + "='" + objPC.OverTime_Hours + "'," + LT1 + "='" + objPC.LateBy + "'," + AtId + "=" + objPC.AttendanceRecordId + "," + ShiftId + "=" + objPC.ShiftId + ",TotalPresent=TotalPresent+" + TotalPresent + ",TotalAbsent=TotalAbsent+" + TotalAbsent + ",TotalOT='" + OTH + "',TotalWeeklyOff=TotalWeeklyOff+" + TotalWeeklyOff + ",TotalHoliday=TotalHoliday+" + TotalHoliday + ",TotalLateBy=TotalLateBy+" + TotalLateBy + ",TotalEarlyBy=TotalEarlyBy+" + TotalEarlyBy + " where AYear=" + objPC.AYear + " and AMonth=" + objPC.AMonth + " and EmployeeId=" + EID + "";
                objBL.Query = "update attendancemonthlydata set LocationId=" + objPC.LocationId + ",DepartmentId=" + objPC.DepartmentId + "," + In1 + "='" + InTime_I + "'," + Out1 + "='" + OutTime_I + "'," + Duration1 + "='" + objPC.TotalDuration + "'," + Status1 + "='" + objPC.StatusCode + "'," + OT1 + "='" + objPC.OverTime + "'," + LT1 + "='" + objPC.LateBy + "'," + AtId + "=" + objPC.AttendanceRecordId + "," + ShiftId + "=" + objPC.ShiftId + " where AYear=" + objPC.AYear + " and AMonth=" + objPC.AMonth + " and EmployeeId=" + objPC.EmployeeId + "";
                R = objBL.Function_ExecuteNonQuery();
            }
            else
            {
                // int Monthdays = DateTime.DaysInMonth(objPC.AYear,objPC.AMonth);
                objBL.Query = "insert into attendancemonthlydata(AYear,AMonth,LocationId,DepartmentId,EmployeeId," + In1 + "," + Out1 + "," + Duration1 + "," + Status1 + "," + OT1 + "," + LT1 + "," + AtId + "," + ShiftId + ",AttendanceHistoryId) values(" + yearS + "," + MonS + "," + objPC.LocationId + "," + objPC.DepartmentId + "," + objPC.EmployeeId + ",'" + InTime_I + "','" + OutTime_I + "','" + objPC.TotalDuration + "','" + objPC.StatusCode + "','" + objPC.OverTime + "','" + objPC.LateBy + "'," + objPC.AttendanceRecordId + "," + objPC.ShiftId + "," + objPC.AttendanceHistoryId + ")";
                R = objBL.Function_ExecuteNonQuery();
            }

            objQL.SP_AttendanceMonthlyData_Total_Update_All_Records();
        }

        string SCode = string.Empty;

        //public void Clear_Attendance()
        //{
        //    DateTime dt;
        //    dt = Convert.ToDateTime("1900-01-01 00:00:00");

        //    objPC.OverTime = "00:00";
        //    objPC.Duration = "00:00";
        //    objPC.TotalDuration = "00:00";
        //    objPC.MissedInPunch = 0;
        //    objPC.MissedOutPunch = 0;
        //    objPC.LateBy = 0;
        //    objPC.EarlyBy = 0;
        //    objPC.Present = 0;
        //    objPC.Absent = 0;
        //    objPC.ChangeDepartmentFlag = 0;
        //    objPC.ChangeDepartmentId = 0;
        //    objPC.ChangeLocationtId = 0;
        //    objPC.LeaveType = string.Empty;
        //}

        string ColumnNameARM = string.Empty;

        public void Set_Manpower_Count(DateTime FromDateF, DateTime ToDateF)
        {
            //A
            //WO
            //WOP
            //H
            //P
            //HD
            //HP
            //L
            //CO
            //COU
            //ODP

            //ADMINISTRATOR
            //ALL
            //DEFAULT
            //HR OFFICER
            //MANAGER
            //OFFICER
            //SENIOR OFFICER
            //SUPERVISOR
            //TRAINEE
            //WORKER
            //CONTRACTWORKER 
            //TOTALPRESENT 
            //ABSENT 
            //PERCENTAGE

            //Select AttendanceRecordMaster Get Department & Id
            DataTable dt = new DataTable();
            objBL.Query = "select * from attendancerecordmaster where CancelTag=0 and AttendanceDate between '" + FromDateF.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + ToDateF.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
            dt = objBL.ReturnDataTable();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objPC.AttendanceRecordMasterId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[i]["AttendanceRecordMasterId"])));

                    for (int j = 17; j < dt.Columns.Count; j++)
                    {
                        ColumnNameARM = string.Empty;
                        ColumnNameARM = objRL.CheckNullString(Convert.ToString(dt.Columns[j]));

                        //if (ColumnNameARM == BusinessResources.USER_TYPE_ADMINISTRATOR.Trim() || ColumnNameARM == BusinessResources.USER_TYPE_HROFFICER.Trim() || ColumnNameARM == BusinessResources.USER_TYPE_MANAGER.Trim() ||  ColumnNameARM == BusinessResources.USER_TYPE_MANAGER.Trim() || 
                        Get_ManpowerCount_AttendanceRecord();
                    }
                }
            }
            //objBL.Query = "insert into tempcountreport(AttendanceDate,LocationId,DepartmentId,ADMINISTRATOR,HROFFICER,MANAGER,OFFICER,SENIOROFFICER,SUPERVISOR,TRAINEE,WORKER,CONTRACTWORKER,TOTALPRESENT,ABSENT,PERCENTAGE,UserId) values()";
        }

        string MainQuery1 = string.Empty; 
        string MainQuery = "select count(*) as 'empcount' from AttendanceRecord AR inner join Employees E on E.EmployeeId=AR.EmployeeId inner join locationmaster L on L.LocationId=E.LocationId inner join designationmaster DM on DM.DesignationId=E.DesignationId inner join departmentmaster D on D.DepartmentId=E.DepartmentId where AR.CancelTag=0 and DM.CancelTag=0 and E.CancelTag=0 and D.CancelTag=0 and L.CancelTag=0 ";
        string INCoumn = " and DM.DesignationCategory IN('";
        string INCoumn1 = "')";
        string WhereComman = " and AR.Status IN('P','WOP','HP','HD') ";
        string SearchColumn = string.Empty;
        string WhereClauseOther = string.Empty;
        //INCoumn = " and DM.DesignationCategory IN('
        //objBL.Query = "select count(*) as 'empcount' from AttendanceRecord where AttendanceRecordMasterId=" + objPC.AttendanceRecordMasterId + " and CancelTag=0 ";

        public void Get_ManpowerCount_AttendanceRecord()
        {
            bool FlagQuery = false; bool FlagQuery1 = false;
            WhereClause = string.Empty;
            SearchColumn = string.Empty;
            WhereClauseOther = string.Empty;
            MainQuery1 = string.Empty;
            MainQuery = "select count(*) as 'empcount' from AttendanceRecord AR inner join Employees E on E.EmployeeId=AR.EmployeeId inner join locationmaster L on L.LocationId=E.LocationId inner join designationmaster DM on DM.DesignationId=E.DesignationId inner join departmentmaster D on D.DepartmentId=E.DepartmentId where AR.CancelTag=0 and DM.CancelTag=0 and E.CancelTag=0 and D.CancelTag=0 and L.CancelTag=0 ";

            //MainQuery = "select count(*) as 'empcount' from AttendanceRecord AR inner join Employees E on E.EmployeeId=AR.EmployeeId inner join locationmaster L on L.LocationId=E.LocationId inner join designationmaster DM on DM.DesignationId=E.DesignationId inner join departmentmaster D on D.DepartmentId=E.DepartmentId where AR.CancelTag=0 and DM.CancelTag=0 and E.CancelTag=0 and D.CancelTag=0 and L.CancelTag=0 ";
            DataTable dt = new DataTable();
           
            if (ColumnNameARM == BusinessResources.USER_TYPE_ADMINISTRATOR)
                SearchColumn = BusinessResources.USER_TYPE_ADMINISTRATOR.Trim();
            else if (ColumnNameARM == BusinessResources.USER_TYPE_HROFFICER.Replace(" ", ""))
                SearchColumn = BusinessResources.USER_TYPE_HROFFICER;
            else if (ColumnNameARM == BusinessResources.USER_TYPE_MANAGER)
                SearchColumn = BusinessResources.USER_TYPE_MANAGER;
            else if (ColumnNameARM == BusinessResources.USER_TYPE_OFFICER.Trim())
                SearchColumn = BusinessResources.USER_TYPE_OFFICER;
            else if (ColumnNameARM == BusinessResources.USER_TYPE_SENIOROFFICER.Replace(" ", ""))
                SearchColumn = BusinessResources.USER_TYPE_SENIOROFFICER;
            else if (ColumnNameARM == BusinessResources.USER_TYPE_SUPERVISOR)
                SearchColumn = BusinessResources.USER_TYPE_SUPERVISOR;
            else if (ColumnNameARM == BusinessResources.USER_TYPE_TRAINEE)
                SearchColumn = BusinessResources.USER_TYPE_TRAINEE;
            else if (ColumnNameARM == BusinessResources.USER_TYPE_WORKER)
            {
                SearchColumn = BusinessResources.USER_TYPE_WORKER;
                FlagQuery = true;
                WhereClauseOther = " and DM.Designation NOT IN('" + BusinessResources.USER_TYPE_CONTRACTWORKER + "') and DM.DesignationCategory IN('" + BusinessResources.USER_TYPE_WORKER + "') " + WhereComman;
            }
            else if (ColumnNameARM == BusinessResources.USER_TYPE_CONTRACTWORKER.Replace(" ", ""))
            {
                SearchColumn = BusinessResources.USER_TYPE_CONTRACTWORKER;
                FlagQuery = true;
                WhereClauseOther = " and DM.Designation IN('" + BusinessResources.USER_TYPE_CONTRACTWORKER + "') and DM.DesignationCategory IN('" + BusinessResources.USER_TYPE_WORKER + "') " + WhereComman;
            }
            else if (ColumnNameARM == BusinessResources.ABSENT)
            {
                SearchColumn = BusinessResources.ABSENT;
                FlagQuery = true;
                WhereClauseOther = " and AR.Status IN('A','L') ";
            }
            else if (ColumnNameARM == BusinessResources.PRESENTMANPOWER.Replace(" ", ""))
            {
                FlagQuery = true;
                SearchColumn = BusinessResources.PRESENTMANPOWER;
                WhereClauseOther = WhereComman;
            }
            else if (ColumnNameARM == BusinessResources.TOTAL)
            {
                FlagQuery = true;
                SearchColumn = BusinessResources.TOTAL;
                WhereClauseOther = string.Empty;

                //WhereClauseOther = " SUM(ADMINISTRATOR + HROFFICER + MANAGER + OFFICER + SENIOROFFICER + SUPERVISOR + TRAINEE + WORKER) ";
                //MainQuery = "select " + WhereClauseOther + " from AttendanceRecord AR inner join Employees E on E.EmployeeId=AR.EmployeeId inner join locationmaster L on L.LocationId=E.LocationId inner join designationmaster DM on DM.DesignationId=E.DesignationId inner join departmentmaster D on D.DepartmentId=E.DepartmentId where AR.CancelTag=0 and DM.CancelTag=0 and E.CancelTag=0 and D.CancelTag=0 and L.CancelTag=0";
            }
            else if (ColumnNameARM == BusinessResources.PERCENTAGE)
            {
                FlagQuery = true; FlagQuery1 = true;
                WhereClause = string.Empty;
                SearchColumn = BusinessResources.PERCENTAGE;
                //WhereClauseOther = " ()";
                //Round(( surveys/employees * 100 ),2),'%') AS percentage
                WhereClauseOther = " round((" + BusinessResources.TOTAL + "/" + BusinessResources.PRESENTMANPOWER.Replace(" ", "") + "*100)) AS 'PERCENTAGE'";
                MainQuery1 = "select " + WhereClauseOther + " from attendancerecordmaster where AttendanceRecordMasterId=" + objPC.AttendanceRecordMasterId + " and CancelTag=0"; // AR inner join Employees E on E.EmployeeId=AR.EmployeeId inner join locationmaster L on L.LocationId=E.LocationId inner join designationmaster DM on DM.DesignationId=E.DesignationId inner join departmentmaster D on D.DepartmentId=E.DepartmentId where AR.CancelTag=0 and DM.CancelTag=0 and E.CancelTag=0 and D.CancelTag=0 and L.CancelTag=0";
            }
            else
            {
                FlagQuery = false;
                SearchColumn = string.Empty;
            }

            if (SearchColumn != "")
            {
                //if (objPC.AttendanceRecordMasterId == 98)
                //{

                //}

                if (!FlagQuery)
                    WhereClause = INCoumn + SearchColumn + INCoumn1 + WhereComman;
                else
                    WhereClause = WhereClauseOther;

                if (!FlagQuery1)
                    objBL.Query = MainQuery + WhereClause + " and AR.AttendanceRecordMasterId=" + objPC.AttendanceRecordMasterId + " ";
                else
                    objBL.Query = MainQuery1; // +WhereClause + " and AR.AttendanceRecordMasterId=" + objPC.AttendanceRecordMasterId + " ";

                dt = objBL.ReturnDataTable();
                if (dt.Rows.Count > 0)
                {
                    int RCount = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dt.Rows[0][0])));
                    objBL.Query = "update attendancerecordmaster set " + ColumnNameARM + "=" + RCount + " where AttendanceRecordMasterId=" + objPC.AttendanceRecordMasterId + "";
                    int Result = objBL.Function_ExecuteNonQuery();
                }
            }
        }

        public void Check_ARM()
        {
            DataSet dsARM = new DataSet();
            objPC.CompleteFlag = 0;
            objPC.AttendanceRecordMasterId = 0; //Convert.ToInt32(objCmd.ExecuteScalar());
            objPC.EntryDate = DateTime.Now.Date;
            dsARM = objQL.SP_AttendanceRecordMaster_CheckExist();
            objPC.CheckFlagARM = false;

            if (dsARM.Tables[0].Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(dsARM.Tables[0].Rows[0]["AttendanceRecordMasterId"].ToString())))
                {
                    objPC.AttendanceRecordMasterId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsARM.Tables[0].Rows[0]["AttendanceRecordMasterId"])));
                    objPC.ApprovalStatusId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsARM.Tables[0].Rows[0]["ApprovalStatusId"])));
                    objPC.AttendanceStatus = objRL.CheckNullString(Convert.ToString(dsARM.Tables[0].Rows[0]["AttendanceStatus"]));
                    objPC.CheckFlagARM = true;
                }
            }
        }
    }
}
