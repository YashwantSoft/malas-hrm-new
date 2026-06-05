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

namespace SPApplication.Report
{
    public partial class WorkingHoursReport : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();

        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;

        int SearchId = 0, LocationId = 0;

        public WorkingHoursReport()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnReport, btnClear, btnView, btnExit, BusinessResources.LBL_HEADER_WORKINGHOURSREPORT);
            btnReport.Text = BusinessResources.BTN_VIEW;
            objRL.FillLocation(cmbLocation, cmbDepartment);
            ClearAll();
        }

        private void ClearAll()
        {
            objEP.Clear();
            cmbLocation.SelectedIndex = -1;
            cmbDepartment.SelectedIndex = -1;
            cbToday.Checked = true;
            cmbLocation.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cbToday_CheckedChanged(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Now.Date;
            dtpToDate.Value = DateTime.Now.Date;

            if (cbToday.Checked)
            {
                dtpFromDate.Enabled = false;
                dtpToDate.Enabled = false;
            }
            else
            {
                dtpFromDate.Enabled = true;
                dtpToDate.Enabled = true;
            }
        }

        private void cmbLocation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex > -1)
            {
                objPC.LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
                objRL.FillDepartment(cmbLocation, cmbDepartment);
            }
        }

        private bool Validation()
        {
            bool FlagReturn = false;
            objEP.Clear();

            if (!FlagReturn)
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
            return FlagReturn;
        }

        List<DateTime> allDates = new List<DateTime>();

        public void GetDatesBetween(DateTime startDate, DateTime endDate)
        {
            allDates = null; allDates = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
                allDates.Add(date);

            if (allDates.Count == 0)
                allDates.Add(dtpFromDate.Value);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (!Validation())
            {
                GetReport();
            }
            else
            {
                objRL.ShowMessage(17, 4);
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        string MainQuery = string.Empty, ColumnNames_BR = string.Empty, TableNames_BR = string.Empty, WhereClause_BR = string.Empty, WhereClause = string.Empty, OrderBy = string.Empty;
        string DateColumn = string.Empty, EmployeeIn = string.Empty, LeaveStatusIn = string.Empty, ContractorIn = string.Empty, StatusIn = string.Empty, DepartmentIn = string.Empty, LocationIdS = string.Empty;

        int Pending_Count = 0, ManagerApproved_Count = 0, HRApproved_Count = 0, Remarks_Count = 0, Reject_Count = 0, Completed_Count = 0;

        int EmployeeId = 0;
        string SearchColumn = string.Empty;
        bool DayFlag = false;

        private string Get_Employee_Count(string CheckWhere)
        {
            SearchColumn = string.Empty;
            WhereClause = string.Empty;
            string RValue = string.Empty;
            string DT=string.Empty;

            if (!DayFlag)
            {
                if (Convert.ToInt32(CheckWhere) < allDates.Count)
                {
                    objPC.AttendanceDate = Convert.ToDateTime(allDates[Convert.ToInt32(CheckWhere) - 1]);
                    objPC.AttendanceDay = objPC.AttendanceDate.DayOfWeek.ToString();
                }

                SearchColumn = " AR.Duration ";
                WhereClause = "and day(ARM.AttendanceDate)=" + CheckWhere + "";// and ARM.AttendanceDate between  '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";
            }
            else
            {
                if (CheckWhere == "Present Days")
                {
                    SearchColumn = " count(*) as 'Count' ";
                    WhereClause = " and AR.Status IN('P') ";
                }
                else if (CheckWhere == "Over Time")
                {
                    SearchColumn = " SUM(TIME_TO_SEC(AR.OverTime)) / 3600 as 'Count'";
                }
                else if (CheckWhere == "Total Hours")
                {
                    SearchColumn = " SUM(TIME_TO_SEC(AR.TotalDuration)) / 3600 as 'Count'";
                }
                else
                {

                }
            }

            MainQuery = "select " + SearchColumn + " from AttendanceRecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId " +
                " where AR.EmployeeId=" + EmployeeId + " and ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            DataSet ds = new DataSet();
            objBL.Query = MainQuery + WhereClause;
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                RValue = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0][0]));
                
                if(DayFlag)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(RValue)))
                    {
                        double val1= Convert.ToDouble(RValue);
                        val1 = Math.Round(val1,0);
                       // TimeSpan timeSpan = TimeSpan.Parse(RValue);
                        RValue = val1.ToString();
                    }
                }
            }
                

            if (!DayFlag)
            {
                if (!string.IsNullOrEmpty(Convert.ToString(RValue)))
                {
                    TimeSpan duration = TimeSpan.Parse(RValue);
                    double DDuration =Convert.ToDouble(duration.Hours);

                    if (objPC.FlexibleHoursFlag == 0)
                    {
                        if (DDuration < 8.29)
                        {
                            if (objPC.WeeklyOff1Value != objPC.AttendanceDay)
                                objRL.Set_Error_Color(dataGridView1, RCount, CName, Color.FromName(BusinessResources.LS_Error_Color));
                            else
                                objRL.Set_Error_Color(dataGridView1, RCount, CName, Color.White);
                        }
                        else
                        {
                            objRL.Set_Error_Color(dataGridView1, RCount, CName, Color.White);
                        }
                    }
                    else
                        objRL.Set_Error_Color(dataGridView1, RCount, CName, Color.White);

                    //if (DDuration < 8.5)
                    //{
                    //    if (objPC.WeeklyOff1Value != objPC.AttendanceDay)
                    //        objRL.Set_Error_Color(dataGridView1, RCount, CName, Color.FromName(BusinessResources.LS_Error_Color));
                    //    else
                    //        objRL.Set_Error_Color(dataGridView1, RCount, CName, Color.White);
                    //}
                    //else
                    //{
                    //    objRL.Set_Error_Color(dataGridView1, RCount, CName, Color.White);
                    //}
                }
            }

            return RValue;
        }

        int RCount = 0;
        string CName = string.Empty;

        //3000

        private void GetReport()
        {
            dataGridView1.Rows.Clear();

            MainQuery = "select " +
                        "LM.LocationName as 'Location'," +
                        "DM.Department, " +
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
                        "E.OverTimeApplicable," +
                        "E.FlexibleHoursFlag " +
                        " from " +
                        "Employees E inner join  " +
                        "DepartmentMaster DM on DM.DepartmentId=E.DepartmentId inner join " +
                        "DesignationMaster DES on DES.DesignationId=E.DesignationId inner join " +
                        "LocationMaster LM on LM.LocationId=E.LocationId " +
                        " where E.CancelTag=0 and DM.CancelTag=0 and DES.CancelTag=0 and LM.CancelTag=0 ";

            //Report Query
            DataSet ds = new DataSet();

            ColumnNames_BR = string.Empty; TableNames_BR = string.Empty; WhereClause_BR = string.Empty; WhereClause = string.Empty; OrderBy = string.Empty;
            DateColumn = string.Empty; EmployeeIn = string.Empty; ContractorIn = string.Empty; StatusIn = string.Empty; DepartmentIn = string.Empty; LocationIdS = string.Empty;

            //Where Clauses All
            //DateColumn = " LA.FromDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' ";

            if (cmbLocation.SelectedIndex > -1)
                LocationIdS = " and E.LocationId=" + cmbLocation.SelectedValue + " ";

            if (cmbLocation.SelectedIndex > -1)
                DepartmentIn = " and E.DepartmentId=" + cmbDepartment.SelectedValue + " ";

            OrderBy = " order by E.EmployeeName asc ";
            WhereClause = DateColumn + EmployeeIn + LocationIdS + DepartmentIn + ContractorIn + StatusIn + LeaveStatusIn + " ";

            objBL.Query = MainQuery + WhereClause;
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotalCount.Text = "Total Count-" + ds.Tables[0].Rows.Count.ToString();
                GetDatesBetween(dtpFromDate.Value, dtpToDate.Value);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeId"])));
                    objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["CategoryId"])));
                    objPC.OverTimeApplicable = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["OverTimeApplicable"])));
                    objPC.FlexibleHoursFlag = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["FlexibleHoursFlag"])));
                    objRL.Get_CategoriesDetails_By_Id();

                    dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = EmployeeId; // objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));
                    dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));
                    dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeName"]));

                    //for (int j = 0; j < allDates.Count; j++)
                    //{
                    //    DataSet dsA = new DataSet();
                    //    objPC.AttendanceDate = Convert.ToDateTime(allDates[j]);
                    //    objPC.AttendanceDay = objPC.AttendanceDate.DayOfWeek.ToString();

                    //    DayFlag = false;
                    //    if (objPC.AttendanceDate.Day == 1)

                    //}
                    //dataGridView1.Rows[i].Cells["clm1"].Value = Get_Employee_Count("01");

                    RCount = i;

                    for (int j = 1; j <= 31; j++)
                    {
                        DayFlag = false;
                        CName = "clm" + j;
                        Set_Row_Values(j);
                        //dataGridView1.Rows[i].Cells[CName].Value = Get_Employee_Count(j.ToString());
                    }
                    //CName = "clm1";
                    //dataGridView1.Rows[i].Cells[CName].Value = Get_Employee_Count("01");
                    //CName = "clm2";
                    //dataGridView1.Rows[i].Cells["clm2"].Value = Get_Employee_Count("02");
                    //CName = "clm3";
                    //dataGridView1.Rows[i].Cells["clm3"].Value = Get_Employee_Count("03");
                    //CName = "clm4";
                    //dataGridView1.Rows[i].Cells["clm4"].Value = Get_Employee_Count("04");
                    //CName = "clm5";
                    //dataGridView1.Rows[i].Cells["clm5"].Value = Get_Employee_Count("05");
                    //CName = "clm6";
                    //dataGridView1.Rows[i].Cells["clm6"].Value = Get_Employee_Count("06");
                    //CName = "clm7";
                    //dataGridView1.Rows[i].Cells["clm7"].Value = Get_Employee_Count("07");
                    //CName = "clm8";
                    //dataGridView1.Rows[i].Cells["clm8"].Value = Get_Employee_Count("08");
                    //CName = "clm9";
                    //dataGridView1.Rows[i].Cells["clm9"].Value = Get_Employee_Count("09");
                    //dataGridView1.Rows[i].Cells["clm10"].Value = Get_Employee_Count("10");
                    //dataGridView1.Rows[i].Cells["clm11"].Value = Get_Employee_Count("11");
                    //dataGridView1.Rows[i].Cells["clm12"].Value = Get_Employee_Count("12");
                    //dataGridView1.Rows[i].Cells["clm13"].Value = Get_Employee_Count("13");
                    //dataGridView1.Rows[i].Cells["clm14"].Value = Get_Employee_Count("14");
                    //dataGridView1.Rows[i].Cells["clm15"].Value = Get_Employee_Count("15");
                    //dataGridView1.Rows[i].Cells["clm16"].Value = Get_Employee_Count("16");
                    //dataGridView1.Rows[i].Cells["clm17"].Value = Get_Employee_Count("17");
                    //dataGridView1.Rows[i].Cells["clm18"].Value = Get_Employee_Count("18");
                    //dataGridView1.Rows[i].Cells["clm19"].Value = Get_Employee_Count("19");
                    //dataGridView1.Rows[i].Cells["clm20"].Value = Get_Employee_Count("20");
                    //dataGridView1.Rows[i].Cells["clm21"].Value = Get_Employee_Count("21");
                    //dataGridView1.Rows[i].Cells["clm22"].Value = Get_Employee_Count("22");
                    //dataGridView1.Rows[i].Cells["clm23"].Value = Get_Employee_Count("13");
                    //dataGridView1.Rows[i].Cells["clm24"].Value = Get_Employee_Count("24");
                    //dataGridView1.Rows[i].Cells["clm25"].Value = Get_Employee_Count("25");
                    //dataGridView1.Rows[i].Cells["clm26"].Value = Get_Employee_Count("26");
                    //dataGridView1.Rows[i].Cells["clm27"].Value = Get_Employee_Count("27");
                    //dataGridView1.Rows[i].Cells["clm28"].Value = Get_Employee_Count("28");
                    //dataGridView1.Rows[i].Cells["clm29"].Value = Get_Employee_Count("29");
                    //dataGridView1.Rows[i].Cells["clm30"].Value = Get_Employee_Count("30");
                    //dataGridView1.Rows[i].Cells["clm31"].Value = Get_Employee_Count("31");

                    DayFlag = true;
                    dataGridView1.Rows[i].Cells["clmTotalHours"].Value = Get_Employee_Count("Total Hours");
                    dataGridView1.Rows[i].Cells["clmTotalDays"].Value = Get_Employee_Count("Present Days");
                    dataGridView1.Rows[i].Cells["clmTotalOT"].Value = Get_Employee_Count("Over Time");
                    DayFlag = false;
                }
            }
            else
            {
                objRL.ShowMessage(35, 4);
                return;
            }
        }
        
        private void Set_Row_Values(int SearchValue)
        {
            dataGridView1.Rows[RCount].Cells[CName].Value = Get_Employee_Count(SearchValue.ToString());
        }

        private void WorkingHoursReport_Load(object sender, EventArgs e)
        {

        }
    }
}
