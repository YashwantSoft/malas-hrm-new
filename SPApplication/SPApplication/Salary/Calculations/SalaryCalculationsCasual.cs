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

namespace SPApplication.Salary.Calculations
{
    public partial class SalaryCalculationsCasual : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();
        AttendanceLogics objAL = new AttendanceLogics();
        public SalaryCalculationsCasual()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnView, btnClear, btnReport, btnExit, "Salary Calculations");
            btnView.Text = BusinessResources.BTN_VIEW;
            btnReport.Text = BusinessResources.BTN_REPORT;
            Fill_Data();
            ClearAll();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
        private void FillGrid()
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

        bool DateOfJoiningFlag = false;
        string MainQuery = string.Empty, ColumnNames_BR = string.Empty, TableNames_BR = string.Empty, WhereClause_BR = string.Empty, WhereClause = string.Empty, OrderBy = string.Empty;
        string DateColumn = string.Empty, EmployeeIn = string.Empty, LeaveStatusIn = string.Empty, ContractorIn = string.Empty, StatusIn = string.Empty, DepartmentIn = string.Empty, LocationIdS = string.Empty;

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //FillGrid();
            FillGrid_StoreProcedureData();
        }

        private void FillGrid_StoreProcedureData()
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            lblTotalCount.Text = "";
            dataGridView2.Rows.Clear();
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
                WhereClause += " and e.ContractorId=" + cmbRoll.SelectedValue + "";

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


            MainQuery = " WITH SalaryData AS ( " +
                        " SELECT  " +
                        " e.EmployeeId, " +
                        " e.EmployeeCode, " +
                        " e.EmployeeName, " +
                        " e.Gender, " +
                        " e.ContractorId, " +
                        " (SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Designation' AND ee.FromDate <=e.DateOfExit ORDER BY ee.FromDate DESC LIMIT 1) AS Designation, " +
                        " (SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' AND ee.FromDate <= e.DateOfExit ORDER BY ee.FromDate DESC LIMIT 1) AS Location, " +
                        " (SELECT MasterName1 FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' AND ee.FromDate <= e.DateOfExit ORDER BY ee.FromDate DESC LIMIT 1) AS Department, " +
                        " (SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Contractor' AND ee.FromDate <= e.DateOfExit ORDER BY ee.FromDate DESC LIMIT 1) AS Roll, " +
                        " e.SkillType, " +
                        " e.JobProfile, " +
                        " e.Status, " +
                        " c.CategoryFName, " +
                        " e.CostCenter as CalculationMethod, " +
                        " (SELECT SalaryCategoryRate FROM salarycategory WHERE SalaryCategoryName=e.SkillType AND CancelTag=0) AS MinWages, " +
                        " e.SalaryMonthlyBasic as ActualWagesPerDay, " +
                        " e.SalaryMonthlyHRA as ActualWagesMonthly, " +
                        " SUM(CASE WHEN a.Status = 'P' THEN 1 ELSE 0 END) AS PresentDays, " +
                        " SUM(CASE WHEN a.Status = 'L' THEN 1 ELSE 0 END) AS LeavesDays, " +
                        " SUM(CASE WHEN a.Status = 'SL' THEN 1 ELSE 0 END) AS SpecialLeaves, " +
                        " (select Count(H.HolidayId) from HolidayMaster H inner join HolidayLocation HL on H.HolidayId=HL.HolidayId where H.CancelTag=0 and HL.CancelTag=0 and HL.LocationId=e.LocationId " + WhereClass_Date_Holiday + " and H.HolidayDate >= e.DOJ and H.HolidayDate<=e.DateOfExit and H.HolidayDay NOT IN(c.CategoryFName)) as Holiday, " +
                        " CASE WHEN e.OverTimeApplicable = 0 THEN SUM(CASE WHEN a.Status = 'HP' THEN 1 ELSE 0 END) ELSE 0  END AS HolidayPresent, " +
                        " SUM(CASE WHEN a.Status IN ('P','L','H','HP') THEN 1 ELSE 0 END) AS SalaryDays, " +
                        " SUM(CASE WHEN a.Status NOT IN ('WO','WOP') THEN a.OverTime ELSE 0 END) AS RegularOvertime, " +
                        " SUM(CASE WHEN e.OverTimeApplicable = 1 AND a.Status = 'WOP' THEN a.OverTime ELSE 0 END) AS WOOThrs, " +
                        " SUM(CASE WHEN e.OverTimeApplicable = 1 AND a.Status = 'HP' THEN a.OverTime ELSE 0 END) AS HolidayOTHours, " +
                        " SUM(a.OverTime) AS TotalOTHrs, " +
                        " SUM(CASE WHEN a.Status = 'A' THEN 1 ELSE 0 END) AS Absent, " +
                        " SUM(CASE WHEN a.Status = 'CO' THEN 1 ELSE 0 END) AS CompOffDays, " +
                        " SUM(CASE WHEN a.Status = 'COU' THEN 1 ELSE 0 END) AS CompOffUsed, " +
                        " SUM(CASE WHEN a.Status = 'WO' THEN 1 ELSE 0 END) AS WeeklyOff, " +
                        " SUM(CASE WHEN a.Status = 'WOP' THEN 1 ELSE 0 END) AS WeeklyOffPresent, " +
                        " MAX(DAY(LAST_DAY(ARM.AttendanceDate))) AS TotalDays, " +
                        " SUM(a.TotalDuration) AS TotalHours, " +
                        " (SELECT  " +
                        " (e.SalaryMonthlyBasic *  " +
                        " (SUM(CASE WHEN a.Status IN ('P','L','H','HP') THEN 1 ELSE 0 END) * (BasicPer+DAPer) / 100)) " +
                        " FROM salaryconfigurations  " +
                        " WHERE e.ContractorId = ContractorId  " +
                        " AND CancelTag = 0) AS BasicDAAll, " +
                        " (SELECT  " +
                        " (e.SalaryMonthlyBasic *  " +
                        " (SUM(CASE WHEN a.Status IN ('P','L','H','HP') THEN 1 ELSE 0 END) * HRAPer / 100)) " +
                        " FROM salaryconfigurations  " +
                        " WHERE e.ContractorId = ContractorId  " +
                        " AND CancelTag = 0) AS HRA, " +
                        " ROUND((e.SalaryMonthlyBasic/8 * 1.1) * SUM(a.OverTime)) as OTAmount, " +
                        " ROUND((e.SalaryMonthlyBasic/8 * 4) * SUM(CASE WHEN e.OverTimeApplicable = 1 AND a.Status IN('WOP','HP') THEN a.OverTime ELSE 0 END)) as WOHolidayOTAmount, " +
                        " (CASE WHEN MONTH(ARM.AttendanceDate) !=02 THEN 'All' ELSE MONTH(ARM.AttendanceDate) END) AS AMMonth " +
                        " FROM employees e " +
                        " JOIN attendancerecord a ON e.EmployeeId = a.EmployeeId " +
                        " JOIN attendancerecordmaster ARM ON a.AttendanceRecordMasterId = ARM.AttendanceRecordMasterId " +
                        " JOIN categories c ON c.CategoryId = e.CategoryId " +
                        " WHERE MONTH(ARM.AttendanceDate) = 9  " +
                        " AND YEAR(ARM.AttendanceDate) = 2025 " +
                        " AND e.EmployeeCode NOT IN" +
                        "(100001,100004,50002,50003,50004,50005,50006,50007,50008,50009,50010,50011,50013,50014,50015,50016,50017,50018,50019,50020,50012,50021,50022,50023,50024,50025,50026,50027,50028) " +
                        " and ARM.FinancialYearId = " + objPC.FinancialYearId + " " +
                        " " + WhereClause + WhereClass_Date + "" +
                        " GROUP BY e.EmployeeId, e.EmployeeCode, e.EmployeeName, e.SalaryMonthlyBasic, e.ContractorId, e.SkillType,AMMonth " +
                        " ) " +
                        " SELECT  " +
                        " EmployeeId as EID, " +
                        " EmployeeCode, " +
                        " EmployeeName, " +
                        " Gender, " +
                        " ContractorId as CID, " +
                        " Designation, " +
                        " Location, " +
                        " Department, " +
                        " Roll, " +
                        " SkillType, " +
                        " JobProfile, " +
                        " Status, " +
                        " CategoryFName, " +
                        " CalculationMethod, " +
                        " MinWages, " +
                        " ActualWagesPerDay, " +
                        " ActualWagesMonthly, " +
                        " PresentDays, " +
                        " LeavesDays, " +
                        " SpecialLeaves, " +
                        " Holiday, " +
                        " HolidayPresent, " +
                        " SalaryDays, " +
                        " RegularOvertime, " +
                        " WOOThrs, " +
                        " HolidayOTHours, " +
                        " TotalOTHrs, " +
                        " Absent, " +
                        " CompOffDays, " +
                        " CompOffUsed, " +
                        " WeeklyOff, " +
                        " WeeklyOffPresent, " +
                        " TotalDays, " +
                        " TotalHours, " +
                        " Round(TotalDays) - Round(WeeklyOff) - Round(CompOffUsed) -Round(Absent) as FoodDays, " +
                        " ROUND(BasicDAAll) AS BasicDAAll, " +
                        " ROUND(HRA) AS HRA, " +
                        " OTAmount, " +
                        " ROUND(BasicDAAll) + ROUND(HRA) + Round(OTAmount) AS Gross, " +
                        " COALESCE((SELECT SalaryMonthlyEducationAllowance FROM employees WHERE EmployeeId=EID and CancelTag=0 LIMIT 1), 0) AS OtherAllowances, " +
                        " COALESCE((SELECT SalaryMonthlyConveyanceAllowance FROM employees WHERE EmployeeId=EID and CancelTag=0 LIMIT 1), 0) AS LoanAmount, " +
                        " COALESCE((SELECT SalaryMonthlyOtherAllowance FROM employees WHERE EmployeeId=EID and CancelTag=0 LIMIT 1), 0) AS OtherAdvance, " +
                        " COALESCE((SELECT Round((ActualWagesPerDay/8)*0.4*WOOThrs+HolidayOTHours)), 0) AS TuesdayIncentive, " +
                        " (select (ROUND(BasicDAAll) + ROUND(HRA) + Round(OTAmount) + Round(TuesdayIncentive) + Round(OtherAllowances)))  as TotalEarnings, " +
                        " COALESCE((SELECT CASE WHEN Gross > PFFixAmountLimit THEN PFFixAmount ELSE ROUND(Gross * EPFPensionPFPerEmployee / 100) END AS CalculatedPF FROM salaryconfigurations WHERE ContractorId=CID and IsPF=1), 0) AS PF, " +
                        " COALESCE((SELECT ROUND(Gross*EsicEmployeeContributions/100)  from salaryconfigurations where EsicLimit >= Gross AND ContractorId=CID and IsEsic=1), 0) AS ESIC, " +
                        " COALESCE((SELECT TaxAmount FROM professionaltaxtable WHERE Gross BETWEEN MinAmount AND MaxAmount and CuttingMonth = AMMonth LIMIT 1), 0) AS PT, " +
                        " COALESCE((SELECT Round(SalaryCategoryRate*FoodDays) FROM salarycategory WHERE SalaryCategoryName='CanteenRate'), 0) AS Canteen, " +
                        " (select Round(PF) + Round(ESIC)+ Round(PT)+ Round(Canteen) +Round(LoanAmount) +Round(OtherAdvance)) AS TotalDeduction, " +
                        " (select (ROUND(TotalEarnings)  - Round(TotalDeduction)))  as NetPayable " +
                        " FROM SalaryData ";


            objBL.Query = MainQuery;
            dt = objBL.ReturnDataTable();

            if (dt.Rows.Count > 0)
            {
                dataGridView3.DataSource = dt;
                lblTotalCount.Text = "Total Count-" + dt.Rows.Count.ToString();

                dataGridView3.Columns[0].Visible = false;
                dataGridView3.Columns[4].Visible = false;
                dataGridView3.Columns[2].Width = 200;
                //dataGridView2.Columns[2].Width = 120;
                //dataGridView2.Columns[3].Width = 150;
                //dataGridView2.Columns[4].Width = 50;
                //dataGridView2.Columns[5].Width = 200;

                //for (int i = 6; i < dataGridView2.Columns.Count; i++)
                //{
                //    dataGridView2.Columns[i].Width = 50;
                //}

                // Example: Freeze the first column
                dataGridView3.Columns[0].Frozen = true;

                // Or by column name
                dataGridView3.Columns[8].Frozen = true;
            }
        }

        private void cbStatusAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStatusAll.Checked)
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

        string WhereClass_Date_Holiday = string.Empty, WhereClass_Date = string.Empty;

        string WhereClause_Effective = string.Empty;
        private void Get_New_Attendance_SalaryReport()
        {
            lblTotalCount.Text = "";
            dataGridView2.Rows.Clear();
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
                WhereClause += " and e.ContractorId=" + cmbRoll.SelectedValue + "";

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


            MainQuery = "SELECT " +
                        "e.EmployeeId," +
                        "(SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' and ee.FromDate <= e.DateOfExit ORDER BY ee.FromDate DESC LIMIT 1) AS Location," +
                        "(SELECT MasterName1 FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Location and Department' and ee.FromDate <= e.DateOfExit ORDER BY ee.FromDate DESC LIMIT 1) AS Department," +
                        "(SELECT MasterName FROM employeeseffect ee WHERE ee.EmployeeId = e.EmployeeId AND ee.CancelTag = 0 AND ee.EffectType = 'Contractor' and ee.FromDate <= e.DateOfExit ORDER BY ee.FromDate DESC LIMIT 1) AS Roll," +
                        "e.EmployeeCode as 'Employee Code'," +
                        "e.EmployeeName as 'Employee Name'," +
                        "SUM(CASE WHEN a.Status = 'P' THEN 1 ELSE 0 END) AS 'Present Days'," +
                        "SUM(CASE WHEN a.Status = 'L' THEN 1 ELSE 0 END) AS 'Leaves Days'," +
                        "SUM(CASE WHEN a.Status = 'SL' THEN 1 ELSE 0 END) AS 'Special Leaves'," +
                        "(select Count(H.HolidayId) from HolidayMaster H inner join HolidayLocation HL on H.HolidayId = HL.HolidayId where H.CancelTag = 0 and HL.CancelTag = 0 and HL.LocationId=e.LocationId " + WhereClass_Date_Holiday + " and H.HolidayDate >= e.DOJ and H.HolidayDate <= e.DateOfExit and H.HolidayDay NOT IN(c.CategoryFName)) as 'Holiday'," +
                        "CASE WHEN e.OverTimeApplicable = 0 THEN SUM(CASE WHEN a.Status = 'HP' THEN 1 ELSE 0 END) ELSE 0  END AS 'Holiday Present'," +
                        "SUM(CASE WHEN a.Status IN('P', 'L', 'H', 'HP') THEN 1 ELSE 0 END) AS 'Salary Days'," +
                        "SUM(CASE WHEN a.Status NOT IN('WO', 'WOP') THEN a.OverTime ELSE 0 END) AS 'Regular Overtime'," +
                        "SUM(CASE WHEN a.Status = 'WOP' THEN a.OverTime ELSE 0 END) AS 'WO OT hrs.'," +
                        "SUM(CASE WHEN a.Status = 'HP' THEN a.OverTime ELSE 0 END) AS 'Holiday OT Hours'," +
                        "SUM(a.OverTime) AS 'Total OT Hrs.'," +
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
                        " WHERE e.CancelTag=0 and a.CancelTag=0 and ARM.CancelTag=0 and c.CancelTag=0 " +
                        " and e.EmployeeCode NOT IN" +
                        "(100001,100004,50002,50003,50004,50005,50006,50007,50008,50009,50010,50011,50013,50014,50015,50016,50017,50018,50019,50020,50012,50021,50022,50023,50024,50025,50026,50027,50028) " +
                        " and ARM.FinancialYearId = " + objPC.FinancialYearId + " " +
                        " " + WhereClause + WhereClass_Date + "" +
                        " GROUP BY e.EmployeeId, e.EmployeeCode, e.EmployeeName ORDER BY e.EmployeeCode asc ";

            System.Data.DataTable dt = new System.Data.DataTable();
            objBL.Query = MainQuery;
            dt = objBL.ReturnDataTable();

            if (dt.Rows.Count > 0)
            {
                dataGridView2.DataSource = dt;
                lblTotalCount.Text = "Total Count-" + dt.Rows.Count.ToString();

                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Width = 60;
                dataGridView2.Columns[2].Width = 120;
                dataGridView2.Columns[3].Width = 150;
                dataGridView2.Columns[4].Width = 50;
                dataGridView2.Columns[5].Width = 200;

                for (int i = 6; i < dataGridView2.Columns.Count; i++)
                {
                    dataGridView2.Columns[i].Width = 50;
                }

                // Example: Freeze the first column
                dataGridView2.Columns[0].Frozen = true;

                // Or by column name
                dataGridView2.Columns[5].Frozen = true;
            }
        }

        private void ClearAll()
        {
            dgvSalary.Rows.Clear();
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
        private void SetMonthYear()
        {
            string MonthName = objRL.GetMonthName(DateTime.Now.Date.Month);
            int YearNo = DateTime.Now.Year;

            cmbYear.Text = YearNo.ToString();
            cmbMonth.Text = MonthName.ToString();
        }
    }
}
