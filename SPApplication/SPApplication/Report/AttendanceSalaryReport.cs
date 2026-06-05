using BusinessLayerUtility;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Spreadsheet;
using SPApplication.Master;
using SPApplication.Transaction;
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

namespace SPApplication.Report
{
    public partial class AttendanceSalaryReport : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();
        AttendanceLogics objAL = new AttendanceLogics();

        public AttendanceSalaryReport()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnView, btnClear, btnReport, btnExit, BusinessResources.REPORT_NAME_ATTENDANCE_SALARY_REPORT);
            btnView.Text = BusinessResources.BTN_VIEW;
            btnReport.Text = BusinessResources.BTN_REPORT;
            Fill_Data();
            ClearAll();
        }

        private void ClearAll()
        {
            dataGridView2.DataSource = null;
            dataGridView1.Rows.Clear();
            cbSelectAllLocation.Checked = true;
            cbSelectAllDepartment.Checked = true;
            cbAttendanceDate.Checked = true;
            cbRoll.Checked = true;
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cmbMonth.SelectedIndex = -1;
            cmbYear.SelectedIndex = -1;
            cmbRoll.SelectedIndex = -1;
            cbStatusAll.Checked = true;

            SetMonthYear();
        }

        private void Fill_Data()
        {
            objRL.Fill_Contractor_IN_Attendance(cmbRoll);
            objRL.FillLocation(cmbLocation, cmbDepartment);
            cbAttendanceDate.Checked = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

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

        private void cbAttendanceDate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAttendanceDate.Checked)
            {
                MonthYear_Visible(false);
            }
            else
            {
                MonthYear_Visible(true);
            }
        }

        private void MonthYear_Visible(bool FlagF)
        {
            lblMonth.Visible = FlagF;
            lblYear.Visible = FlagF;
            cmbMonth.Visible = FlagF;
            cmbYear.Visible = FlagF;

            //lblFromDate.Visible = FlagF;
            //dtpFromDate.Visible = FlagF;
            //lblToDate.Visible = FlagF;
            //dtpToDate.Visible = FlagF;

            if (!FlagF)
            {
                cmbMonth.SelectedIndex = -1;
                cmbYear.SelectedIndex = -1;

                lblFromDate.Visible = true;
                dtpFromDate.Visible = true;
                lblToDate.Visible = true;
                dtpToDate.Visible = true;
            }
            else
            {
                SetMonthYear();
                lblFromDate.Visible = false;
                dtpFromDate.Visible = false;
                lblToDate.Visible = false;
                dtpToDate.Visible = false;
            }
        }

        private void SetMonthYear()
        {
            string MonthName = objRL.GetMonthName(DateTime.Now.Date.Month);
            int YearNo = DateTime.Now.Year;

            cmbYear.Text = YearNo.ToString();
            cmbMonth.Text = MonthName.ToString();
        }

        private void AttendanceSalaryReport_Load(object sender, EventArgs e)
        {

        }

        private void cbRoll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRoll.Checked)
            {
                cmbRoll.SelectedIndex = -1;
                cmbRoll.Enabled = false;
            }
            else
            {
                cmbRoll.SelectedIndex = -1;
                cmbRoll.Enabled = true;
                cmbRoll.Focus();
            }
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
                objRL.FillDepartment(cmbLocation, cmbDepartment);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private bool Validation()
        {
            bool FlagReturn = false;
            objEP.Clear();

            if (!cbSelectAllLocation.Checked)
            {
                if (cmbLocation.SelectedIndex == -1)
                {
                    cmbLocation.Focus();
                    objEP.SetError(cmbLocation, "Select Location");
                    FlagReturn = true;
                }
                else
                    FlagReturn = false;
            }

            if (!FlagReturn)
            {
                if (!cbSelectAllDepartment.Checked)
                {
                    if (cmbLocation.SelectedIndex == -1)
                    {
                        cmbLocation.Focus();
                        objEP.SetError(cmbLocation, "Select Location");
                        FlagReturn = true;
                    }
                    else if (cmbDepartment.SelectedIndex == -1)
                    {
                        cmbDepartment.Focus();
                        objEP.SetError(cmbDepartment, "Select Department");
                        FlagReturn = true;
                    }
                    else
                        FlagReturn = false;
                }
                else
                    FlagReturn = false;
            }
            if (!FlagReturn)
            {
                if (!cbAttendanceDate.Checked)
                {
                    if (cmbMonth.SelectedIndex == -1)
                    {
                        cmbMonth.Focus();
                        objEP.SetError(cmbMonth, "Select Month");
                        FlagReturn = true;
                    }
                    else if (cmbYear.SelectedIndex == -1)
                    {
                        cmbYear.Focus();
                        objEP.SetError(cmbYear, "Select Year");
                        FlagReturn = true;
                    }
                    else
                        FlagReturn = false;
                }
            }

            if (!FlagReturn)
            {
                if (!cbRoll.Checked)
                {
                    if (cmbRoll.SelectedIndex == -1)
                    {
                        cmbRoll.Focus();
                        objEP.SetError(cmbRoll, "Select Roll");
                        FlagReturn = true;
                    }
                    else
                        FlagReturn = false;
                }
            }
            return FlagReturn;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                Get_New_Attendance_SalaryReport();
                //GetReport();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        string MainQuery = string.Empty, ColumnNames_BR = string.Empty, TableNames_BR = string.Empty, WhereClause_BR = string.Empty, WhereClause = string.Empty, OrderBy = string.Empty;
        string DateColumn = string.Empty, EmployeeIn = string.Empty, LeaveStatusIn = string.Empty, ContractorIn = string.Empty, StatusIn = string.Empty, DepartmentIn = string.Empty, LocationIdS = string.Empty;

        private void cbStatusAll_CheckedChanged(object sender, EventArgs e)
        {
            if(cbStatusAll.Checked)
            {
                cmbStatus.SelectedIndex = -1;
                cmbStatus.Enabled = false;
            }
            else
            {
                cmbStatus.SelectedIndex = -1;
                cmbStatus.Enabled = true;
            }
        }

        int Pending_Count = 0, ManagerApproved_Count = 0, HRApproved_Count = 0, Remarks_Count = 0, Reject_Count = 0, Completed_Count = 0;

        int EmployeeId = 0;
        string SearchColumn = string.Empty;

        private string Get_Employee_Count(string CheckWhere)
        {
            SearchColumn = string.Empty;
            WhereClause = string.Empty;

            string RValue = string.Empty;

            SearchColumn = " count(*) as 'Count' ";

            if (CheckWhere == "Present Days")
            {
                SearchColumn = " sum(AR.Present) as 'Count' ";
                WhereClause = " and AR.Status IN('P','HD') ";
            }
            else if (CheckWhere == "Leaves Days")
            {
                WhereClause = " and AR.Status IN('L') ";
            }
            else if (CheckWhere == "Special Leaves")
            {
                WhereClause = " and AR.Status IN('SL') ";
            }
            else if (CheckWhere == "Holiday")
            {
                SearchColumn = " Count(AR.AttendanceRecordId) as 'Count' ";
                WhereClause = " and AR.Status IN('H') ";
            }
            else if (CheckWhere == "Regular Over Time Hours")
            {
                SearchColumn = " sum(AR.OverTime) as 'Count'";
                WhereClause = " and AR.Status NOT IN('WO','WOP') ";
            }
            else if (CheckWhere == "WO OT Hours")
            {
                SearchColumn = " sum(AR.OverTime) as 'Count'";
                WhereClause = " and AR.Status IN('WOP') ";
            }
            else if (CheckWhere == "Holiday OT Hours")
            {
                SearchColumn = " sum(AR.OverTime) as 'Count'";
                WhereClause = " and AR.Status IN('HP') ";
            }
            else if (CheckWhere == "Over Time")
            {
                SearchColumn = " sum(AR.OverTime) as 'Count'";
                //WhereClause = " and AR.Status IN('WOP') ";
            }
            else if (CheckWhere == "Absent")
            {
                SearchColumn = " sum(AR.Absent) as 'Count' ";
                //WhereClause = " and AR.Status IN('A') ";
            }
            else if (CheckWhere == "Comp Off Days")
            {
                WhereClause = " and AR.Status IN('CO') ";

                //30-09-2024
                //
                
            }
            else if (CheckWhere == "Comp Off Used Days")
            {
                WhereClause = " and AR.Status IN('COU') ";
            }
            else if (CheckWhere == "Weekly Off")
            {
                WhereClause = " and AR.Status IN('WO') ";
            }
            else if (CheckWhere == "Weekly Off Present")
            {
                WhereClause = " and AR.Status IN('WOP') ";
            }
            else if (CheckWhere == "Holiday Present")
            {
                WhereClause = " and AR.Status IN('HP') ";
            }
            else if (CheckWhere == "Total Working Hours")
            {
                SearchColumn = " sum(AR.TotalDuration) as 'Count'";
                WhereClause = " and AR.Status IN('P','HD') ";
            }
            //else if (CheckWhere == "Salary Days")
            //{
            //    objRL.Get_CategoriesDetails_By_Id();

            //    SearchColumn = " (count(AR.AttendanceRecordId) - (select count(AR.AttendanceRecordId) as 'WeekOff' from attendancerecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId where AR.EmployeeId=98 and UPPER(DAYNAME(ARM.AttendanceDate)) = '" + objPC.WeeklyOff1Value + "' and AR.CancelTag=0 and ARM.CancelTag=0 and  ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "')) as 'Count' ";
            //    //WhereClause = " and AR.Status IN('P','WOP','HP','HD') ";
            //}
            //else if (CheckWhere == "Month Days")
            //{
            //    objRL.Get_CategoriesDetails_By_Id();

            //    SearchColumn = " (count(AR.AttendanceRecordId) - (select count(AR.AttendanceRecordId) as 'WeekOff' from attendancerecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId where AR.EmployeeId=98 and UPPER(DAYNAME(ARM.AttendanceDate)) = '" + objPC.WeeklyOff1Value + "' and AR.CancelTag=0 and ARM.CancelTag=0 and  ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "')) as 'Count' ";
            //    //WhereClause = " and AR.Status IN('P','WOP','HP','HD') ";
            //}
            else
            {

            }

            MainQuery = "select " + SearchColumn + " from AttendanceRecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId where AR.EmployeeId=" + EmployeeId + " ";

            RValue = "0";
            DataSet ds = new DataSet();
            objBL.Query = MainQuery + WhereClause + WhereClass_Date;
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
                RValue = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Count"]));

            if (RValue == "")
                RValue = "0";

            return RValue;
        }

        string WhereClass_Date = string.Empty;

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //0     "e.EmployeeId," +
                //1    "(SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' " + WhereClause_Effective + " ORDER BY ee.FromDate DESC LIMIT 1) AS Location," +
                //2    "(SELECT MasterName1 FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' " + WhereClause_Effective + " ORDER BY ee.FromDate DESC LIMIT 1) AS Department," +
                //3    "(SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Contractor' " + WhereClause_Effective + " ORDER BY ee.FromDate DESC LIMIT 1) AS Roll," +
                //4    "e.EmployeeCode as 'Employee Code'," +
                //5    "e.EmployeeName as 'Employee Name'," +
                //6    "SUM(CASE WHEN a.Status = 'P' THEN 1 ELSE 0 END) AS 'Present Days'," +
                //7    "SUM(CASE WHEN a.Status = 'L' THEN 1 ELSE 0 END) AS 'Leaves Days'," +
                //8    "SUM(CASE WHEN a.Status = 'SL' THEN 1 ELSE 0 END) AS 'Special Leaves'," +
                //9    "(select Count(H.HolidayId) from HolidayMaster H inner join HolidayLocation HL on H.HolidayId = HL.HolidayId where H.CancelTag = 0 and HL.CancelTag = 0 and HL.LocationId=e.LocationId " + WhereClass_Date_Holiday + " and H.HolidayDate >= e.DOJ and H.HolidayDate <= e.DateOfExit and H.HolidayDay NOT IN(c.CategoryFName)) as 'Holiday'," +
                //10   "CASE WHEN e.OverTimeApplicable = 0 THEN SUM(CASE WHEN a.Status = 'HP' THEN 1 ELSE 0 END) ELSE 0  END AS 'Holiday Present'," +
                //11   "SUM(CASE WHEN a.Status IN('P', 'L', 'H', 'HP') THEN 1 ELSE 0 END) AS 'Salary Days'," +
                //12   "SUM(CASE WHEN a.Status NOT IN('WO', 'WOP') THEN a.OverTime ELSE 0 END) AS 'Regular Overtime'," +
                //13   "SUM(CASE WHEN a.Status = 'WOP' THEN a.OverTime ELSE 0 END) AS 'WO OT hrs.'," +
                //14   "SUM(CASE WHEN a.Status = 'HP' THEN a.OverTime ELSE 0 END) AS 'Holiday OT Hours'," +
                //15   "SUM(a.OverTime) AS 'Total OT Hrs.'," +
                //16   "SUM(CASE WHEN a.Status = 'A' THEN 1 ELSE 0 END) AS 'Absent'," +
                //17   "SUM(CASE WHEN a.Status = 'CO' THEN 1 ELSE 0 END) AS 'Comp Off Days'," +
                //18   "SUM(CASE WHEN a.Status = 'COU' THEN 1 ELSE 0 END) AS 'Comp Off Used'," +
                //19   "SUM(CASE WHEN a.Status = 'WO' THEN 1 ELSE 0 END) AS 'Weekly Off'," +
                //20   "SUM(CASE WHEN a.Status = 'WOP' THEN 1 ELSE 0 END) AS 'Weekly Off Present'," +
                //21   "MAX(DAY(LAST_DAY(ARM.AttendanceDate))) AS 'Total Days'," +
                //22   " SUM(a.TotalDuration) AS 'Total Hours'," +
                //23   " CASE WHEN e.FlexibleHoursFlag = 1 THEN SUM(CASE WHEN a.Status = 'P' THEN 1 ELSE 0 END) *8.5 ELSE SUM(CASE WHEN a.Status = 'P' THEN 1 ELSE 0 END) *8 END AS 'Total Workable Hours'," +
                //24   " ROUND((CAST(SUM(CASE WHEN a.Status IN('P', 'HP', 'H') THEN 1 ELSE 0 END) AS FLOAT) / NULLIF(MAX(DAY(LAST_DAY(ARM.AttendanceDate))), 0)) * 100, 2) AS 'Attendance Percent'" +


                RowCount_Grid = dataGridView2.Rows.Count;
                CurrentRowIndex = dataGridView2.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dataGridView2.Rows[e.RowIndex].Cells[0].Value)))
                    {
                        objPC.EmployeeId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value);
                        objPC.EmployeeCode = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[4].Value);

                        

                        if (cbAttendanceDate.Checked)
                        {
                            objPC.FromDate = dtpFromDate.Value;
                            objPC.ToDate = dtpToDate.Value;
                        }
                        else
                        {
                            int daysInMonth = DateTime.DaysInMonth(Convert.ToInt32(cmbYear.Text), objRL.GetMonthNumber(cmbMonth.Text));


                            string FromDateString = Convert.ToInt32(cmbYear.Text) + "-" + objRL.GetMonthNumber(cmbMonth.Text) + "-01";
                            string ToDateString = Convert.ToInt32(cmbYear.Text) + "-" + objRL.GetMonthNumber(cmbMonth.Text) + "-" + daysInMonth;

                            //WhereClause_Effective = " and ee.FromDate <= '" + DCalaculate + "' ";

                            objPC.FromDate = Convert.ToDateTime(FromDateString);
                            objPC.ToDate = Convert.ToDateTime(ToDateString);
                        }
                             

                        IndvisualUserAttendanceReport objForm = new IndvisualUserAttendanceReport(objPC.EmployeeId);
                        objForm.ShowDialog(this);

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

        private void btnReport_Click(object sender, EventArgs e)
        {

        }

        double SalaryDays = 0, PresentDays = 0, LeavesDays = 0, Holiday = 0, HolidayPresent = 0, AbsentDays = 0, TotalOTHrs = 0, RegularOT = 0, WOOT = 0, TotalDays = 0, CompOff = 0, CompOffUsed = 0, WeeklyOff = 0, WeeklyOffPresent = 0, TotalWorkingHours = 0, TotalWorkableHours = 0;
        TimeSpan TotalOTHrs_TS = TimeSpan.Zero, RegularOT_TS = TimeSpan.Zero, WOOT_TS = TimeSpan.Zero, HolidayOTHours_TS = TimeSpan.Zero;

        private void GetReport_Original()
        {
            dataGridView1.Rows.Clear();
            DataSet ds = new DataSet();

            ColumnNames_BR = string.Empty; TableNames_BR = string.Empty; WhereClause_BR = string.Empty; WhereClause = string.Empty; OrderBy = string.Empty;
            DateColumn = string.Empty; EmployeeIn = string.Empty; ContractorIn = string.Empty; StatusIn = string.Empty; DepartmentIn = string.Empty; LocationIdS = string.Empty;

            SalaryDays = 0; PresentDays = 0; LeavesDays = 0; Holiday = 0; HolidayPresent = 0; AbsentDays = 0; TotalOTHrs = 0; RegularOT = 0; WOOT = 0; TotalDays = 0; CompOff = 0; CompOffUsed = 0; WeeklyOff = 0; WeeklyOffPresent = 0; TotalWorkingHours = 0; TotalWorkableHours = 0;

            WhereClass_Date = string.Empty;
            TotalOTHrs_TS = TimeSpan.Zero; RegularOT_TS = TimeSpan.Zero; WOOT_TS = TimeSpan.Zero;

            MainQuery = "select " +
                        "LM.LocationName as 'Location'," +
                        "DM.Department, " +
                        "CM.ContractorName, " +
                        "E.EmployeeId," +
                        "E.EmployeeCode," +
                        "E.EmployeeName," +
                        "DES.Designation," +
                        "E.OpeningLeave as 'Opening'," +
                        "E.CurrentLeave as 'Current'," +
                        "E.TotalApplicableLeave as 'Applicable'," +
                        "E.EnjoyLeave as 'Enjoy'," +
                        "E.BalanceLeave as 'Balance'," +
                        "E.CategoryId," +
                        "E.FlexibleHoursFlag "+
                        " from " +
                        "Employees E inner join  " +
                        "DepartmentMaster DM on DM.DepartmentId=E.DepartmentId inner join " +
                        "DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
                        "LocationMaster LM on LM.LocationId=E.LocationId inner join contractormaster CM on CM.ContractorId=E.ContractorId " +
                        " where  E.CancelTag=0 and DM.CancelTag=0 and DES.CancelTag=0 and LM.CancelTag=0 and CM.CancelTag=0 ";

            //Report Query
           
            //Where Clauses All
            //DateColumn = " LA.FromDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

            if(!cbStatusAll.Checked && cmbStatus.SelectedIndex>-1)
                WhereClause += " and E.Status='" + cmbStatus.Text + "'";

            if (!cbSelectAllLocation.Checked)
                WhereClause += " and E.LocationId=" + cmbLocation.SelectedValue + "";
            else
                WhereClause += " and " + objQL.Get_Location_Id("Location") + " ";

            if (!cbSelectAllDepartment.Checked)
                WhereClause += " and E.DepartmentId=" + cmbDepartment.SelectedValue + "";
            else
                WhereClause += " and " + objQL.Get_Location_Id("Department");

            if (cbAttendanceDate.Checked)
                WhereClass_Date = " and ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
            else
                WhereClass_Date = " and Month(ARM.AttendanceDate)=" + objRL.GetMonthNumber(cmbMonth.Text) + " and Year(ARM.AttendanceDate)=" + cmbYear.Text + "";


            if (!cbRoll.Checked)
                WhereClause += " and E.ContractorId=" + cmbRoll.SelectedValue + "";

            
            //if (cmbLocation.SelectedIndex > -1)
            //    LocationIdS = " and E.LocationId=" + cmbLocation.SelectedValue + " ";

            //if (cmbLocation.SelectedIndex > -1)
            //    DepartmentIn = " and E.DepartmentId=" + cmbDepartment.SelectedValue + " ";

            OrderBy = " order by E.EmployeeName asc ";
            //WhereClause = DateColumn + EmployeeIn + LocationIdS + DepartmentIn + ContractorIn + StatusIn + LeaveStatusIn + " ";

            objBL.Query = MainQuery + WhereClause;
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total Count-" + ds.Tables[0].Rows.Count.ToString();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    PresentDays = 0;
                    LeavesDays = 0;
                    Holiday = 0;
                    HolidayPresent = 0;
                    SalaryDays = 0;
                    TotalOTHrs_TS = TimeSpan.Zero;

                    RegularOT_TS = TimeSpan.Zero;
                    WOOT_TS = TimeSpan.Zero;
                    TotalOTHrs_TS = TimeSpan.Zero;

                    AbsentDays = 0;
                    CompOff = 0;
                    CompOffUsed = 0;
                    WeeklyOff = 0;
                    WeeklyOffPresent = 0;

                    dataGridView1.Rows.Add();
                    EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeId"])));

                    //if (EmployeeId == 881)
                    //{
                    //    MessageBox.Show("Found");
                    //}

                    objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["CategoryId"])));
                    objPC.FlexibleHoursFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["FlexibleHoursFlag"])));

                    dataGridView1.Rows[i].Cells["clmLocation"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Location"]));
                    dataGridView1.Rows[i].Cells["clmDepartment"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Department"]));
                    dataGridView1.Rows[i].Cells["clmRoll"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["ContractorName"]));
                    
                    dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = EmployeeId; // objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));
                    dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));
                    dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeName"]));

                    PresentDays = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Present Days"))));
                    LeavesDays = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Leaves Days"))));
                    Holiday = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Holiday"))));
                    HolidayPresent = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Holiday Present"))));
                    SalaryDays = PresentDays + LeavesDays + Holiday + HolidayPresent;

                    dataGridView1.Rows[i].Cells["clmPresentDays"].Value = PresentDays.ToString(); // Get_Employee_Count("Present Days");
                    dataGridView1.Rows[i].Cells["clmLeavesDays"].Value = LeavesDays.ToString(); // Get_Employee_Count("Leaves Days");
                    dataGridView1.Rows[i].Cells["clmHoliday"].Value = Holiday.ToString(); // Get_Employee_Count("Holiday");
                    dataGridView1.Rows[i].Cells["clmHolidayPresent"].Value = HolidayPresent.ToString(); // Get_Employee_Count("Holiday");
                    dataGridView1.Rows[i].Cells["clmSalaryDays"].Value = SalaryDays.ToString();

                    TotalOTHrs_TS = TimeSpan.Zero; WOOT_TS = TimeSpan.Zero; RegularOT_TS = TimeSpan.Zero;

                    RegularOT_TS = TimeSpan.Parse(Convert.ToString(Get_Employee_Count("Regular Over Time Hours")));
                    WOOT_TS = TimeSpan.Parse(Convert.ToString(Get_Employee_Count("WO OT Hours")));
                    TotalOTHrs_TS = TimeSpan.Parse(Convert.ToString(Get_Employee_Count("Over Time")));

                    //RegularOT = RegularOT_TS.Hours;
                    //TotalOTHrs_TS = RegularOT_TS + WOOT_TS;

                    dataGridView1.Rows[i].Cells["clmRegularOvertime"].Value = Get_Employee_Count("Regular Over Time Hours");
                    dataGridView1.Rows[i].Cells["clmWOOTHrs"].Value = Get_Employee_Count("WO OT Hours"); // Get_Employee_Count("WO OT Hours");
                    //.ToString(); // Get_Employee_Count("Regular Over Time Hours");
                    dataGridView1.Rows[i].Cells["clmTotalOTHrs"].Value = Convert.ToString(Get_Employee_Count("Over Time")); // Get_Employee_Count("WO OT Hours");

                    AbsentDays = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Absent"))));
                    dataGridView1.Rows[i].Cells["clmAbsent"].Value = AbsentDays.ToString(); // Get_Employee_Count("Absent");

                    CompOff = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Comp Off Days"))));
                    CompOffUsed = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Comp Off Used Days"))));
                    WeeklyOff = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Weekly Off"))));
                    WeeklyOffPresent = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Weekly Off Present"))));

                    dataGridView1.Rows[i].Cells["clmCompOffDays"].Value = CompOff.ToString();// Get_Employee_Count("Comp Off Days");
                    dataGridView1.Rows[i].Cells["clmCompOffUsed"].Value = CompOffUsed.ToString();//Get_Employee_Count("Comp Off Used Days");
                    dataGridView1.Rows[i].Cells["clmWeeklyOff"].Value = WeeklyOff.ToString();// Get_Employee_Count("Weekly Off");
                    dataGridView1.Rows[i].Cells["clmWeeklyOffPresent"].Value = WeeklyOffPresent.ToString();// Get_Employee_Count("Weekly Off Present");

                    TotalDays = 0;

                    TotalDays = SalaryDays + AbsentDays + CompOff + CompOffUsed + WeeklyOff + WeeklyOffPresent;

                    dataGridView1.Rows[i].Cells["clmTotalDays"].Value = TotalDays.ToString();// Get_Employee_Count("Comp Off Used Days");

                    TotalWorkingHours = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Total Working Hours"))));

                    dataGridView1.Rows[i].Cells["clmTotalHours"].Value = TotalWorkingHours.ToString(); // Get_Employee_Count("Total Working Hours");

                    double ShiftHours = 0;
                    
                    if(objPC.FlexibleHoursFlag==1)
                        ShiftHours = 8.5;
                    else
                        ShiftHours = 8;
                    
                    TotalWorkableHours = PresentDays * ShiftHours;
                    dataGridView1.Rows[i].Cells["clmTotalWorkableHours"].Value = TotalWorkableHours.ToString(); // Get_Employee_Count("Total Hours");


                   //// double SalaryDays = 0, PresentDays = 0, LeavesDays = 0, AbsentDays = 0, CompOffDays = 0;

                   
                   // //CompOffDays = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells["clmCompOffDays"].Value)));
                   // SalaryDays = PresentDays + LeavesDays + AbsentDays;
                    
                   // dataGridView1.Rows[i].Cells["clmTotalDays"].Value = SalaryDays.ToString();
                    //dataGridView1.Rows[i].Cells["clmSalaryDays"].Value = SalaryDays.ToString(); // Get_Employee_Count("Salary Days");
                    //dataGridView1.Rows[i].Cells["clmMonthDays"].Value = Get_Employee_Count("Month Days");
                }
            }
            else
            {
                objRL.ShowMessage(35, 4);
                return;
            }
        }

        List<string> listHoliday = new List<string>();
        public void Get_Holiday()
        {
            //WhereClass_Date_Holiday = string.Empty;

            listHoliday.Clear();
            string WhereClass_Date_Holiday = string.Empty;

            //if (!cbSelectAllLocation.Checked)
            //    WhereClass_Date_Holiday = " and HL.LocationId=" + cmbLocation.SelectedValue + "";

            if (cbAttendanceDate.Checked)
                WhereClass_Date_Holiday += " and H.HolidayDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
            else
                WhereClass_Date_Holiday += " and Month(H.HolidayDate)=" + objRL.GetMonthNumber(cmbMonth.Text) + " and Year(H.HolidayDate)=" + cmbYear.Text + "";

            if (DateOfJoiningFlag)
                WhereClass_Date_Holiday += " and H.HolidayDate >= '" + objPC.DateOfJoining.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and H.HolidayDate<='" + objPC.DateOfExit.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            DataSet ds = new DataSet();
            //objBL.Query = "select HolidayId,HolidayDate,HolidayDay,Festival,NationalHolidayFlag from HolidayMaster where HolidayDate='" + objPC.AttendanceDate.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and CancelTag=0";
            objBL.Query = "select Count(H.HolidayId) from HolidayMaster H inner join HolidayLocation HL on H.HolidayId=HL.HolidayId where H.CancelTag=0 and HL.CancelTag=0 and HL.LocationId=" + objPC.LocationId + WhereClass_Date_Holiday + " and H.HolidayDay NOT IN('"+objPC.CategoryFName+"')";
            //objBL.Query = "select distinct H.HolidayDate,H.HolidayDay from HolidayMaster H inner join HolidayLocation HL on H.HolidayId=HL.HolidayId where H.CancelTag=0 and HL.CancelTag=0 " + WhereClass_Date_Holiday;
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                //Holiday = ds.Tables[0].Rows.Count;
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    listHoliday.Add(ds.Tables[0].Rows[i]["HolidayDate"].ToString());
                //}

                //objPC.HolidayDay = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["HolidayDay"]));
                Holiday = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0][0])));
                //if (objPC.CategoryFName == objPC.HolidayDay)
                //{
                //    Holiday = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0][0])));
                //}

                //HolidayFlag = true;
                //NationalHolidayFlag = objRL.CheckNullString_ReturnInt(Convert.ToString(ds.Tables[0].Rows[0]["NationalHolidayFlag"]));
                // objPC.HolidayDay = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["HolidayDay"]));
            }
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

        bool DateOfJoiningFlag = false;
        string WhereClauseSumRecord = string.Empty;
        private void GetReport()
        {
            using (new CursorWait())
            {
                WhereClauseSumRecord = string.Empty;
                WhereClause = string.Empty;

                dataGridView1.Rows.Clear();
                DataSet ds = new DataSet();

                ColumnNames_BR = string.Empty; TableNames_BR = string.Empty; WhereClause_BR = string.Empty; WhereClause = string.Empty; OrderBy = string.Empty;
                DateColumn = string.Empty; EmployeeIn = string.Empty; ContractorIn = string.Empty; StatusIn = string.Empty; DepartmentIn = string.Empty; LocationIdS = string.Empty;

                SalaryDays = 0; PresentDays = 0; LeavesDays = 0; Holiday = 0; HolidayPresent = 0; AbsentDays = 0; TotalOTHrs = 0; RegularOT = 0; WOOT = 0; TotalDays = 0; CompOff = 0; CompOffUsed = 0; WeeklyOff = 0; WeeklyOffPresent = 0; TotalWorkingHours = 0; TotalWorkableHours = 0;

                WhereClass_Date = string.Empty;
                TotalOTHrs_TS = TimeSpan.Zero; RegularOT_TS = TimeSpan.Zero; WOOT_TS = TimeSpan.Zero;


                //  select
                //    E.EmployeeId,
                //    E.EmployeeName
                //from AttendanceRecord AR inner join
                //     attendancerecordmaster ARM on ARM.AttendanceRecordMasterId = AR.AttendanceRecordMasterId inner join
                //     Employees E on E.EmployeeId = AR.EmployeeId
                //where
                //    AR.EmployeeId = 1  and
                //    AR.Status IN('P','HD')  and
                //    ARM.LocationId = 3 and
                //    ARM.DepartmentId = 25 and
                //    Month(ARM.AttendanceDate) = 7 and
                //    Year(ARM.AttendanceDate) = 2024;


                string CheckString = Return_Employee_Effect();

                //if (!string.IsNullOrEmpty(Convert.ToString(CheckString)))
                //    CheckString = " and E.EmployeeId IN(" + Return_Employee_Effect() + ")";

                //else
                //{
                //    if(cmbLocation.SelectedIndex >-1 && cmbDepartment.SelectedIndex >-1)
                //        CheckString = " and E.LocationId=" + cmbLocation.SelectedValue + " and E.DepartmentId="+cmbDepartment.SelectedValue+" ";
                //}

                CheckString = "";

                MainQuery = "select " +
                           //"LM.LocationName as 'Location'," +
                           //"DM.Department, " +
                           //"CM.ContractorName, " +
                           "distinct E.EmployeeId," +
                           "E.EmployeeCode," +
                           "E.EmployeeName," +
                           //"DES.Designation," +
                           "E.OpeningLeave as 'Opening'," +
                           "E.CurrentLeave as 'Current'," +
                           "E.TotalApplicableLeave as 'Applicable'," +
                           "E.EnjoyLeave as 'Enjoy'," +
                           "E.BalanceLeave as 'Balance'," +
                           "E.CategoryId," +
                           "E.FlexibleHoursFlag, " +
                           "E.LocationId, " +
                           "E.DepartmentId, " +
                           "CT.CategoryFName, " +
                           "E.OverTimeApplicable, " +
                           "E.DOJ, " +
                           "E.DateOfExit " +
                           " from " +
                           " AttendanceRecord AR inner join " +
                           " attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId inner join " +
                           "  Employees E on E.EmployeeId=AR.EmployeeId inner join " +
                           "  categories CT on CT.CategoryId=E.CategoryId " +
                           " where E.EmployeeCode NOT IN" +
                           "(100001,100004,50002,50003,50004,50005,50006,50007,50008,50009,50010,50011,50013,50014,50015,50016,50017,50018,50019,50020,50012,50021,50022,50023,50024,50025,50026,50027,50028)" +
                           " and E.CancelTag=0 and AR.CancelTag=0 and ARM.FinancialYearId=" + objPC.FinancialYearId + " "+
                           
                           " and ARM.CancelTag=0 " + CheckString + " ";

                //"(50002,50003,50004,50005,50006,50007,50008,50009,50010,50011,50012,50013,50014,50015,50016,50017,50018,50019,50020,100001,100002,100003,100004) and E.CancelTag=0 and AR.CancelTag=0 and ARM.FinancialYearId=" + objPC.FinancialYearId + " " +
                ////Original
                //MainQuery = "select " +
                //            "LM.LocationName as 'Location'," +
                //            "DM.Department, " +
                //            "CM.ContractorName, " +
                //            "E.EmployeeId," +
                //            "E.EmployeeCode," +
                //            "E.EmployeeName," +
                //            "DES.Designation," +
                //            "E.OpeningLeave as 'Opening'," +
                //            "E.CurrentLeave as 'Current'," +
                //            "E.TotalApplicableLeave as 'Applicable'," +
                //            "E.EnjoyLeave as 'Enjoy'," +
                //            "E.BalanceLeave as 'Balance'," +
                //            "E.CategoryId," +
                //            "E.FlexibleHoursFlag "+
                //            " from " +
                //            "Employees E inner join  " +
                //            "DepartmentMaster DM on DM.DepartmentId=E.DepartmentId inner join " +
                //            "DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
                //            "LocationMaster LM on LM.LocationId=E.LocationId inner join contractormaster CM on CM.ContractorId=E.ContractorId " +
                //            " where  E.CancelTag=0 and DM.CancelTag=0 and DES.CancelTag=0 and LM.CancelTag=0 and CM.CancelTag=0 ";

                //Report Query

                //Where Clauses All
                //DateColumn = " LA.FromDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";
                //BusinessResources.dd

                if (!cbStatusAll.Checked && cmbStatus.SelectedIndex > -1)
                    WhereClause += " and E.Status='" + cmbStatus.Text + "'";

                if (!cbSelectAllLocation.Checked)
                    WhereClause += " and ARM.LocationId=" + cmbLocation.SelectedValue + "";
                //else
                //    WhereClause += " and " + objQL.Get_Location_Id("Location") + " ";

                if (!cbSelectAllDepartment.Checked)
                    WhereClause += " and ARM.DepartmentId=" + cmbDepartment.SelectedValue + "";
                //else
                //    WhereClause += " and " + objQL.Get_Location_Id("Department");

                if (!cbRoll.Checked)
                    WhereClause += " and E.ContractorId=" + cmbRoll.SelectedValue + "";

                if (cbAttendanceDate.Checked)
                    WhereClass_Date = " and ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
                else
                    WhereClass_Date = " and Month(ARM.AttendanceDate)=" + objRL.GetMonthNumber(cmbMonth.Text) + " and Year(ARM.AttendanceDate)=" + cmbYear.Text + "";


                //if (!cbStatusAll.Checked && cmbStatus.SelectedIndex>-1)
                //    WhereClause += " and E.Status='" + cmbStatus.Text + "'";

                //if (!cbSelectAllLocation.Checked)
                //    WhereClause += " and E.LocationId=" + cmbLocation.SelectedValue + "";
                //else
                //    WhereClause += " and " + objQL.Get_Location_Id("Location") + " ";

                //if (!cbSelectAllDepartment.Checked)
                //    WhereClause += " and E.DepartmentId=" + cmbDepartment.SelectedValue + "";
                //else
                //    WhereClause += " and " + objQL.Get_Location_Id("Department");

                //if (!cbRoll.Checked)
                //    WhereClause += " and E.ContractorId=" + cmbRoll.SelectedValue + "";

                //if (cbAttendanceDate.Checked)
                //    WhereClass_Date = " and ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
                //else
                //    WhereClass_Date = " and Month(ARM.AttendanceDate)=" + objRL.GetMonthNumber(cmbMonth.Text) + " and Year(ARM.AttendanceDate)=" + cmbYear.Text + "";

                WhereClauseSumRecord = WhereClause + WhereClass_Date;

                //if (cmbLocation.SelectedIndex > -1)
                //    LocationIdS = " and E.LocationId=" + cmbLocation.SelectedValue + " ";

                //if (cmbLocation.SelectedIndex > -1)
                //    DepartmentIn = " and E.DepartmentId=" + cmbDepartment.SelectedValue + " ";

                OrderBy = " order by E.EmployeeName asc ";
                //WhereClause = DateColumn + EmployeeIn + LocationIdS + DepartmentIn + ContractorIn + StatusIn + LeaveStatusIn + " ";

                objBL.Query = MainQuery + WhereClause + WhereClass_Date;
                //objBL.Query = MainQuery + WhereClause;
                ds = objBL.ReturnDataSet();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    //Get_Holiday();

                    lblTotalCount.Text = "Total Count-" + ds.Tables[0].Rows.Count.ToString();

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        objPC.OverTimeApplicable = 0;
                        PresentDays = 0;
                        LeavesDays = 0;
                        Holiday = 0;
                        HolidayPresent = 0;
                        SalaryDays = 0;
                        TotalOTHrs_TS = TimeSpan.Zero;

                        RegularOT_TS = TimeSpan.Zero;
                        WOOT_TS = TimeSpan.Zero;
                        HolidayOTHours_TS = TimeSpan.Zero;
                        TotalOTHrs_TS = TimeSpan.Zero;

                        AbsentDays = 0;
                        CompOff = 0;
                        CompOffUsed = 0;
                        WeeklyOff = 0;
                        WeeklyOffPresent = 0;

                        dataGridView1.Rows.Add();
                        EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeId"])));
                        objPC.LocationId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["LocationId"])));

                        objPC.EmployeeCode = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));

                        //if (objPC.EmployeeCode == 881)
                        //{
                        //    MessageBox.Show("Found");
                        //}



                        //objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["CategoryId"])));
                        //objRL.Get_CategoriesDetails_By_Id();

                        objPC.CategoryFName= objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["CategoryFName"]));

                        objPC.FlexibleHoursFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["FlexibleHoursFlag"])));

                        dataGridView1.Rows[i].Cells["clmLocation"].Value = Get_Location_Department_Roll("MasterName", "Location and Department");  //objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Location"]));
                        dataGridView1.Rows[i].Cells["clmDepartment"].Value = Get_Location_Department_Roll("MasterName1", "Location and Department"); // objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["Department"]));
                        dataGridView1.Rows[i].Cells["clmRoll"].Value = Get_Location_Department_Roll("MasterName", "Contractor");  //objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["ContractorName"]));

                        dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = EmployeeId; // objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));
                        dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));
                        dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeName"]));

                        PresentDays = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Present Days"))));
                        LeavesDays = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Leaves Days"))));

                        objPC.SpecialLeave_Count = 0;
                        objPC.SpecialLeave_Count = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Special Leaves"))));
                        //Holiday = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Holiday"))));

                        if (!string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[i]["DOJ"].ToString())))
                        {
                            DateOfJoiningFlag = true;
                            objPC.DateOfJoining = Convert.ToDateTime(ds.Tables[0].Rows[i]["DOJ"].ToString());
                        }

                        objPC.DateOfExit = Convert.ToDateTime(ds.Tables[0].Rows[i]["DateOfExit"].ToString());

                        objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["OverTimeApplicable"])));

                        Get_Holiday();
                        //Changes on 20-12-2024 as prathmesh

                        if (objPC.OverTimeApplicable == 0)
                            HolidayPresent = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Holiday Present"))));
                        else
                            HolidayPresent = 0;


                        //HolidayPresent = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Holiday Present"))));


                        //SalaryDays = PresentDays + LeavesDays + Holiday;

                        //Holiday

                        //string QueryComp = string.Empty;
                        //int HolidayExtra = 0;
                        //QueryComp = "SELECT count(CompOffApplicationId) FROM compoffapplication where CancelTag=0 and EmployeeId=" + EmployeeId + " and CompOffDate IN (select HolidayDate from holidaymaster where CancelTag=0) and CompStatus='Completed'";
                        //objBL.Query = QueryComp;
                        //DataSet dsHoliday = new DataSet();
                        //dsHoliday = objBL.ReturnDataSet();

                        //if (dsHoliday.Tables[0].Rows.Count > 0)
                        //    HolidayExtra = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(dsHoliday.Tables[0].Rows[0][0])));

                        //Holiday = Holiday + HolidayExtra;

                        SalaryDays = PresentDays + LeavesDays + Holiday + HolidayPresent + objPC.SpecialLeave_Count;

                        //CompOff = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Comp Off Days"))));

                        dataGridView1.Rows[i].Cells["clmPresentDays"].Value = PresentDays.ToString(); // Get_Employee_Count("Present Days");
                        dataGridView1.Rows[i].Cells["clmLeavesDays"].Value = LeavesDays.ToString(); // Get_Employee_Count("Leaves Days");
                        dataGridView1.Rows[i].Cells["clmSpecialLeaves"].Value = objPC.SpecialLeave_Count.ToString();
                        dataGridView1.Rows[i].Cells["clmHoliday"].Value = Holiday.ToString(); // Get_Employee_Count("Holiday");
                        dataGridView1.Rows[i].Cells["clmHolidayPresent"].Value = HolidayPresent.ToString(); // Get_Employee_Count("Holiday");
                        dataGridView1.Rows[i].Cells["clmSalaryDays"].Value = SalaryDays.ToString();

                        TotalOTHrs_TS = TimeSpan.Zero; WOOT_TS = TimeSpan.Zero; RegularOT_TS = TimeSpan.Zero;

                        RegularOT_TS = TimeSpan.Parse(Convert.ToString(Get_Employee_Count("Regular Over Time Hours")));
                        WOOT_TS = TimeSpan.Parse(Convert.ToString(Get_Employee_Count("WO OT Hours")));
                        HolidayOTHours_TS = TimeSpan.Parse(Convert.ToString(Get_Employee_Count("Holiday OT Hours")));
                        TotalOTHrs_TS = TimeSpan.Parse(Convert.ToString(Get_Employee_Count("Over Time")));

                        //RegularOT = RegularOT_TS.Hours;
                        //TotalOTHrs_TS = RegularOT_TS + WOOT_TS;

                        dataGridView1.Rows[i].Cells["clmRegularOvertime"].Value = Get_Employee_Count("Regular Over Time Hours");
                        dataGridView1.Rows[i].Cells["clmWOOTHrs"].Value = Get_Employee_Count("WO OT Hours"); // Get_Employee_Count("WO OT Hours");
                        dataGridView1.Rows[i].Cells["clmHolidayOTHours"].Value = Get_Employee_Count("Holiday OT Hours"); // Get_Employee_Count("WO OT Hours");
                        
                        dataGridView1.Rows[i].Cells["clmTotalOTHrs"].Value = Convert.ToString(Get_Employee_Count("Over Time")); // Get_Employee_Count("WO OT Hours");

                        AbsentDays = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Absent"))));
                        dataGridView1.Rows[i].Cells["clmAbsent"].Value = AbsentDays.ToString(); // Get_Employee_Count("Absent");

                        CompOff = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Comp Off Days"))));
                        CompOffUsed = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Comp Off Used Days"))));
                        WeeklyOff = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Weekly Off"))));
                        WeeklyOffPresent = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Weekly Off Present"))));

                        dataGridView1.Rows[i].Cells["clmCompOffDays"].Value = CompOff.ToString();// Get_Employee_Count("Comp Off Days");
                        dataGridView1.Rows[i].Cells["clmCompOffUsed"].Value = CompOffUsed.ToString();//Get_Employee_Count("Comp Off Used Days");
                        dataGridView1.Rows[i].Cells["clmWeeklyOff"].Value = WeeklyOff.ToString();// Get_Employee_Count("Weekly Off");
                        dataGridView1.Rows[i].Cells["clmWeeklyOffPresent"].Value = WeeklyOffPresent.ToString();// Get_Employee_Count("Weekly Off Present");

                        TotalDays = 0;

                        TotalDays = SalaryDays + AbsentDays + CompOff + CompOffUsed + WeeklyOff + WeeklyOffPresent;

                        dataGridView1.Rows[i].Cells["clmTotalDays"].Value = TotalDays.ToString();// Get_Employee_Count("Comp Off Used Days");

                        TotalWorkingHours = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(Get_Employee_Count("Total Working Hours"))));

                        dataGridView1.Rows[i].Cells["clmTotalHours"].Value = TotalWorkingHours.ToString(); // Get_Employee_Count("Total Working Hours");

                        double ShiftHours = 0;

                        if (objPC.FlexibleHoursFlag == 1)
                            ShiftHours = 8.5;
                        else
                            ShiftHours = 8;

                        TotalWorkableHours = PresentDays * ShiftHours;
                        dataGridView1.Rows[i].Cells["clmTotalWorkableHours"].Value = TotalWorkableHours.ToString(); // Get_Employee_Count("Total Hours");


                        //// double SalaryDays = 0, PresentDays = 0, LeavesDays = 0, AbsentDays = 0, CompOffDays = 0;


                        // //CompOffDays = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells["clmCompOffDays"].Value)));
                        // SalaryDays = PresentDays + LeavesDays + AbsentDays;

                        // dataGridView1.Rows[i].Cells["clmTotalDays"].Value = SalaryDays.ToString();
                        //dataGridView1.Rows[i].Cells["clmSalaryDays"].Value = SalaryDays.ToString(); // Get_Employee_Count("Salary Days");
                        //dataGridView1.Rows[i].Cells["clmMonthDays"].Value = Get_Employee_Count("Month Days");
                    }
                }
                else
                {
                    objRL.ShowMessage(35, 4);
                    return;
                }
            }
        }

        string WhereClass_Date_Holiday = string.Empty;

        string WhereClause_Effective = string.Empty;
        private void Get_New_Attendance_SalaryReport()
        {
            //Get_Holiday();

            lblTotalCount.Text = "";
            dataGridView2.DataSource = null;
            WhereClause_Effective = string.Empty;
            WhereClass_Date_Holiday = string.Empty;
            MainQuery = string.Empty; 
            WhereClass_Date = string.Empty; 
            WhereClause = string.Empty; 
            OrderBy = string.Empty;

            if (!cbStatusAll.Checked && cmbStatus.SelectedIndex > -1)
                WhereClause += " and e.Status='" + cmbStatus.Text + "'";

            if (!cbSelectAllLocation.Checked)
                WhereClause += " and ARM.LocationId=" + cmbLocation.SelectedValue + "";
            //else
            //    WhereClause += " and " + objQL.Get_Location_Id("Location") + " ";

            if (!cbSelectAllDepartment.Checked)
                WhereClause += " and ARM.DepartmentId=" + cmbDepartment.SelectedValue + "";
            //else
            //    WhereClause += " and " + objQL.Get_Location_Id("Department");

            if (!cbRoll.Checked)
                WhereClause += " and E.ContractorId=" + cmbRoll.SelectedValue + "";

            if (cbAttendanceDate.Checked)
                WhereClass_Date = " and ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
            else
                WhereClass_Date = " and Month(ARM.AttendanceDate)=" + objRL.GetMonthNumber(cmbMonth.Text) + " and Year(ARM.AttendanceDate)=" + cmbYear.Text + "";

            if (!cbSelectAllLocation.Checked)
                WhereClause_Effective += " and MasterId=" + cmbLocation.SelectedValue + "";

            if (!cbSelectAllDepartment.Checked)
                WhereClause_Effective += " and MasterId1=" + cmbDepartment.SelectedValue + "";

            if (cbAttendanceDate.Checked)
                WhereClause_Effective += " and ee.FromDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
            else
            {
                int daysInMonth = DateTime.DaysInMonth(Convert.ToInt32(cmbYear.Text), objRL.GetMonthNumber(cmbMonth.Text));

                string DCalaculate = Convert.ToInt32(cmbYear.Text) + "-" + objRL.GetMonthNumber(cmbMonth.Text) + "-" + daysInMonth;

                WhereClause_Effective = " and ee.FromDate <= '" + DCalaculate + "' ";
            }

            //WhereClause_Effective += " and Month(ee.FromDate) between 04 and " + objRL.GetMonthNumber(cmbMonth.Text) + " and Year(ee.FromDate)=" + cmbYear.Text + "";
            if (cbAttendanceDate.Checked)
                WhereClass_Date_Holiday += " and H.HolidayDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
            else
                WhereClass_Date_Holiday += " and Month(H.HolidayDate)=" + objRL.GetMonthNumber(cmbMonth.Text) + " and Year(H.HolidayDate)=" + cmbYear.Text + "";

            if (DateOfJoiningFlag)
                WhereClass_Date_Holiday += " and H.HolidayDate >= '" + objPC.DateOfJoining.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and H.HolidayDate<='" + objPC.DateOfExit.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            //"(SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' " + WhereClause_Effective + " ORDER BY ee.FromDate DESC LIMIT 1) AS Location," +
            //"(SELECT MasterName1 FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' " + WhereClause_Effective + " ORDER BY ee.FromDate DESC LIMIT 1) AS Department," +
            //"(SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Contractor' " + WhereClause_Effective + " ORDER BY ee.FromDate DESC LIMIT 1) AS Roll," +


            MainQuery = "SELECT "+
                        "e.EmployeeId,"+
                        "(SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' and ee.FromDate <= e.DateOfExit ORDER BY ee.FromDate DESC LIMIT 1) AS Location," +
                        "(SELECT MasterName1 FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' and ee.FromDate <= e.DateOfExit ORDER BY ee.FromDate DESC LIMIT 1) AS Department," +
                        "(SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Contractor' and ee.FromDate <= e.DateOfExit ORDER BY ee.FromDate DESC LIMIT 1) AS Roll," +
                        "e.EmployeeCode as 'Employee Code'," +
                        "e.EmployeeName as 'Employee Name'," +
                        "SUM(CASE WHEN a.Status='P' THEN 1 WHEN a.Status='HD' THEN 0.5 ELSE 0 END) AS 'Present Days'," +
                        "SUM(CASE WHEN a.Status = 'L' THEN 1 ELSE 0 END) AS 'Leaves Days'," +
                        "SUM(CASE WHEN a.Status = 'SL' THEN 1 ELSE 0 END) AS 'Special Leaves'," +
                        "(select Count(H.HolidayId) from HolidayMaster H inner join HolidayLocation HL on H.HolidayId = HL.HolidayId where H.CancelTag = 0 and HL.CancelTag = 0 and HL.LocationId=e.LocationId "+ WhereClass_Date_Holiday + " and H.HolidayDate >= e.DOJ and H.HolidayDate <= e.DateOfExit and H.HolidayDay NOT IN(c.CategoryFName)) as 'Holiday'," +
                        "CASE WHEN e.OverTimeApplicable = 0 THEN SUM(CASE WHEN a.Status = 'HP' THEN 1 ELSE 0 END) ELSE 0  END AS 'Holiday Present'," +
                        //"(SUM(CASE WHEN a.Status IN('P', 'L', 'H') THEN 1 WHEN a.Status='HD' THEN 0.5  ELSE 0 END) + (select Count(H.HolidayId) from HolidayMaster H join HolidayLocation HL on H.HolidayId=HL.HolidayId where H.CancelTag=0 and HL.CancelTag = 0 and HL.LocationId=e.LocationId "+ WhereClass_Date_Holiday + " and H.HolidayDate >= e.DOJ and H.HolidayDate <= e.DateOfExit and H.HolidayDay NOT IN(c.CategoryFName)) ) AS 'Salary Days'," +

                        "(SUM(CASE WHEN a.Status IN('P','L','COU','SL') THEN 1 WHEN a.Status='HD' THEN 0.5  ELSE 0 END)) + (select Count(H.HolidayId) from HolidayMaster H join HolidayLocation HL on H.HolidayId=HL.HolidayId where HL.LocationId=e.LocationId " + WhereClass_Date_Holiday + " and H.CancelTag=0 and HL.CancelTag=0 and H.HolidayDate >= e.DOJ and H.HolidayDate <= e.DateOfExit and H.HolidayDay NOT IN(c.CategoryFName)) AS 'Salary Days'," +

                        "SUM(CASE WHEN a.Status NOT IN('WO', 'WOP', 'HP') THEN a.OverTime ELSE 0 END) AS 'Regular Overtime'," +
                        "SUM(CASE WHEN a.Status = 'WOP' THEN a.OverTime ELSE 0 END) AS 'WO OT hrs.'," +
                        "SUM(CASE WHEN a.Status = 'HP' THEN a.OverTime ELSE 0 END) AS 'Holiday OT Hours'," +
                        "SUM(CASE WHEN a.Status IN('P','WO', 'WOP', 'HP') THEN a.OverTime ELSE 0 END) AS 'Total OT Hrs.'," +
                        "SUM(CASE WHEN a.Status = 'A' THEN 1 ELSE 0 END) AS 'Absent'," +
                        "SUM(CASE WHEN a.Status = 'CO' THEN 1 ELSE 0 END) AS 'Comp Off Days'," +
                        "SUM(CASE WHEN a.Status = 'COU' THEN 1 ELSE 0 END) AS 'Comp Off Used'," +
                        "SUM(CASE WHEN a.Status = 'WO' THEN 1 ELSE 0 END) AS 'Weekly Off'," +
                        "SUM(CASE WHEN a.Status = 'WOP' THEN 1 ELSE 0 END) AS 'Weekly Off Present'," +
                        "MAX(DAY(LAST_DAY(ARM.AttendanceDate))) AS 'Total Days'," +
                        " SUM(a.TotalDuration) AS 'Total Hours'," +
                        " CASE WHEN e.FlexibleHoursFlag = 1 THEN SUM(CASE WHEN a.Status = 'P' THEN 1 ELSE 0 END) *8.5 ELSE SUM(CASE WHEN a.Status = 'P' THEN 1 ELSE 0 END) *8 END AS 'Total Workable Hours'," +
                        " ROUND((CAST(SUM(CASE WHEN a.Status IN('P', 'L', 'H', 'HP') THEN 1 ELSE 0 END) AS FLOAT) / NULLIF(MAX(DAY(LAST_DAY(ARM.AttendanceDate))), 0)) * 100, 2) AS 'Attendance Percent'" +
                        " FROM employees e" +
                        " JOIN attendancerecord a ON e.EmployeeId = a.EmployeeId" +
                        " JOIN attendancerecordmaster ARM ON a.AttendanceRecordMasterId = ARM.AttendanceRecordMasterId" +
                        " JOIN categories c ON c.CategoryId = e.CategoryId " +
                        " WHERE e.CancelTag=0 and a.CancelTag=0 and ARM.CancelTag=0 and c.CancelTag=0 "+
                        " and e.EmployeeCode NOT IN" +
                        "(100001,100004,50002,50003,50004,50005,50006,50007,50008,50009,50010,50011,50013,50014,50015,50016,50017,50018,50019,50020,50012,50021,50022,50023,50024,50025,50026,50027,50028) " +
                        " and ARM.FinancialYearId = " + objPC.FinancialYearId + " "+
                        " "+ WhereClause + WhereClass_Date + ""+
                        " GROUP BY e.EmployeeId, e.EmployeeCode, e.EmployeeName ORDER BY e.EmployeeCode asc " ;

            //"(50002,50003,50004,50005,50006,50007,50008,50009,50010,50011,50012,50013,50014,50015,50016,50017,50018,50019,50020,100001,100002,100003,100004) " +
            System.Data.DataTable dt=new System.Data.DataTable();
            objBL.Query = MainQuery;
            dt = objBL.ReturnDataTable();

            if (dt.Rows.Count>0)
            {
                dataGridView2.DataSource = dt;
                lblTotalCount.Text = "Total Count-"+ dt.Rows.Count.ToString();
                
                //0     "e.EmployeeId," +
                //1    "(SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' " + WhereClause_Effective + " ORDER BY ee.FromDate DESC LIMIT 1) AS Location," +
                //2    "(SELECT MasterName1 FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' " + WhereClause_Effective + " ORDER BY ee.FromDate DESC LIMIT 1) AS Department," +
                //3    "(SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Contractor' " + WhereClause_Effective + " ORDER BY ee.FromDate DESC LIMIT 1) AS Roll," +
                //4    "e.EmployeeCode as 'Employee Code'," +
                //5    "e.EmployeeName as 'Employee Name'," +
                //6    "SUM(CASE WHEN a.Status = 'P' THEN 1 ELSE 0 END) AS 'Present Days'," +
                //7    "SUM(CASE WHEN a.Status = 'L' THEN 1 ELSE 0 END) AS 'Leaves Days'," +
                //8    "SUM(CASE WHEN a.Status = 'SL' THEN 1 ELSE 0 END) AS 'Special Leaves'," +
                //9    "(select Count(H.HolidayId) from HolidayMaster H inner join HolidayLocation HL on H.HolidayId = HL.HolidayId where H.CancelTag = 0 and HL.CancelTag = 0 and HL.LocationId=e.LocationId " + WhereClass_Date_Holiday + " and H.HolidayDate >= e.DOJ and H.HolidayDate <= e.DateOfExit and H.HolidayDay NOT IN(c.CategoryFName)) as 'Holiday'," +
                //10   "CASE WHEN e.OverTimeApplicable = 0 THEN SUM(CASE WHEN a.Status = 'HP' THEN 1 ELSE 0 END) ELSE 0  END AS 'Holiday Present'," +
                //11   "SUM(CASE WHEN a.Status IN('P', 'L', 'H', 'HP') THEN 1 ELSE 0 END) AS 'Salary Days'," +
                //12   "SUM(CASE WHEN a.Status NOT IN('WO', 'WOP') THEN a.OverTime ELSE 0 END) AS 'Regular Overtime'," +
                //13   "SUM(CASE WHEN a.Status = 'WOP' THEN a.OverTime ELSE 0 END) AS 'WO OT hrs.'," +
                //14   "SUM(CASE WHEN a.Status = 'HP' THEN a.OverTime ELSE 0 END) AS 'Holiday OT Hours'," +
                //15   "SUM(a.OverTime) AS 'Total OT Hrs.'," +
                //16   "SUM(CASE WHEN a.Status = 'A' THEN 1 ELSE 0 END) AS 'Absent'," +
                //17   "SUM(CASE WHEN a.Status = 'CO' THEN 1 ELSE 0 END) AS 'Comp Off Days'," +
                //18   "SUM(CASE WHEN a.Status = 'COU' THEN 1 ELSE 0 END) AS 'Comp Off Used'," +
                //19   "SUM(CASE WHEN a.Status = 'WO' THEN 1 ELSE 0 END) AS 'Weekly Off'," +
                //20   "SUM(CASE WHEN a.Status = 'WOP' THEN 1 ELSE 0 END) AS 'Weekly Off Present'," +
                //21   "MAX(DAY(LAST_DAY(ARM.AttendanceDate))) AS 'Total Days'," +
                //22   " SUM(a.TotalDuration) AS 'Total Hours'," +
                //23   " CASE WHEN e.FlexibleHoursFlag = 1 THEN SUM(CASE WHEN a.Status = 'P' THEN 1 ELSE 0 END) *8.5 ELSE SUM(CASE WHEN a.Status = 'P' THEN 1 ELSE 0 END) *8 END AS 'Total Workable Hours'," +
                //24   " ROUND((CAST(SUM(CASE WHEN a.Status IN('P', 'HP', 'H') THEN 1 ELSE 0 END) AS FLOAT) / NULLIF(MAX(DAY(LAST_DAY(ARM.AttendanceDate))), 0)) * 100, 2) AS 'Attendance Percent'" +

                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Width = 60;
                dataGridView2.Columns[2].Width = 120;
                dataGridView2.Columns[3].Width = 150;
                dataGridView2.Columns[4].Width = 50;
                dataGridView2.Columns[5].Width = 200;

                for(int i=6;i<dataGridView2.Columns.Count;i++)
                {
                    dataGridView2.Columns[i].Width = 50;
                }

                // Example: Freeze the first column
                dataGridView2.Columns[0].Frozen = true;

                // Or by column name
                dataGridView2.Columns[5].Frozen = true;
            }
        }

  //      MONTH(ARM.AttendanceDate) = 9
  //AND YEAR(ARM.AttendanceDate) = 2025

        private string Return_Employee_Effect()
        {
            string RString = string.Empty;
            string WClasue = string.Empty;
            string EffectType = string.Empty;

            EffectType = "Location and Department";

            if (!cbSelectAllLocation.Checked)
                WClasue += " and MasterId=" + cmbLocation.SelectedValue + "";

            if (!cbSelectAllDepartment.Checked)
                WClasue += " and MasterId1=" + cmbDepartment.SelectedValue + "";

            if (cbAttendanceDate.Checked)
                WClasue += " and FromDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
            else
                WClasue += " and Month(FromDate) between 04 and " + objRL.GetMonthNumber(cmbMonth.Text) + " and Year(FromDate)=" + cmbYear.Text + "";

            //objBL.Query = "select MasterName1 from employeeseffect where EmployeeId = 1 and EffectType = 'Location and Department' and FromDate between '2024-04-01' and '2024-04-30' ";
            objBL.Query = "select EmployeeId from employeeseffect where EffectType= '" + EffectType + "' " + WClasue + " order by EmployeeEffectId desc ";

            DataSet ds = new DataSet();
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                RString = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["EmployeeId"]));
            }
            return RString;
        }

        //int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        private string Get_Location_Department_Roll(string CName, string EffectType)
        {
            string RString = string.Empty;
            string WClasue = string.Empty;

            if (cbAttendanceDate.Checked)
                WClasue = " and FromDate <= '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";
                //WClasue = " and FromDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
            else
            {
                int daysInMonth = DateTime.DaysInMonth(Convert.ToInt32(cmbYear.Text), objRL.GetMonthNumber(cmbMonth.Text));

                string DCalaculate = Convert.ToInt32(cmbYear.Text) + "-" + objRL.GetMonthNumber(cmbMonth.Text) + "-" + daysInMonth;

                WClasue = " and FromDate <= '"+DCalaculate+"' ";

            }
                //FromDate >= CURDATE() - INTERVAL 13 MONTH;
            //WClasue = " and FromDate <= CURDATE() - INTERVAL 13 MONTH ";
            //WClasue = " and Month(FromDate) between 01 and " + objRL.GetMonthNumber(cmbMonth.Text) + " and Year(FromDate) <=" + cmbYear.Text + "";

            //objBL.Query = "select MasterName1 from employeeseffect where EmployeeId = 1 and EffectType = 'Location and Department' and FromDate between '2024-04-01' and '2024-04-30' ";
            objBL.Query = "select EmployeeEffectId,MasterId,MasterId1," + CName + " from employeeseffect where CancelTag=0 and EmployeeId=" + EmployeeId + " and EffectType= '" + EffectType + "' " + WClasue + " ORDER BY FromDate DESC LIMIT 1";
            


            DataSet ds = new DataSet();
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                RString = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0][CName]));
            }
            return RString;
        }

        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0;

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RowCount_Grid = dataGridView1.Rows.Count;
                CurrentRowIndex = dataGridView1.CurrentRow.Index;

                if (RowCount_Grid >= 0 && CurrentRowIndex >= 0)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["clmEmployeeId"].Value)))
                    {
                        objPC.EmployeeId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmEmployeeId"].Value);
                        objPC.EmployeeCode = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["clmEmployeeCode"].Value);

                        objPC.FromDate = dtpFromDate.Value; objPC.ToDate = dtpToDate.Value;

                        IndvisualUserAttendanceReport objForm = new IndvisualUserAttendanceReport(objPC.EmployeeId);
                        objForm.ShowDialog(this);

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
    }
}
