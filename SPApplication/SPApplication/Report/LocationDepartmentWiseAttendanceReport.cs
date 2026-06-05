using BusinessLayerUtility;
using SPApplication.Transaction;
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
    public partial class LocationDepartmentWiseAttendanceReport : Form
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

        public LocationDepartmentWiseAttendanceReport()
        {
            InitializeComponent();
            objDL.SetDesignMaster(this, lblHeader, btnReport, btnClear, btnView, btnExit, BusinessResources.LBL_HEADER_LOCATIONDEPARTMENTWISEATTENDANCEREPORT);
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

        private void LocationDepartmentWiseAttendanceReport_Load(object sender, EventArgs e)
        {

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        string MainQuery = string.Empty, ColumnNames_BR = string.Empty, TableNames_BR = string.Empty, WhereClause_BR = string.Empty, WhereClause = string.Empty, OrderBy = string.Empty;
        string DateColumn = string.Empty, EmployeeIn = string.Empty, LeaveStatusIn = string.Empty, ContractorIn = string.Empty, StatusIn = string.Empty, DepartmentIn = string.Empty, LocationIdS = string.Empty;

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
                //WhereClause = " and AR.Status IN('P') ";
            }
            else if (CheckWhere == "Leaves Days")
            {
                WhereClause = " and AR.Status IN('L') ";
            }
            else if (CheckWhere == "Comp Off Days")
            {
                WhereClause = " and AR.Status IN('CO') ";
            }
            else if (CheckWhere == "Holiday")
            {
                SearchColumn = " Count(AR.AttendanceRecordId) as 'Count' ";
                WhereClause = " and AR.Status IN('H') ";
            }
            else if (CheckWhere == "Absent")
            {
                SearchColumn = " sum(AR.Absent) as 'Count' ";
                //WhereClause = " and AR.Status IN('A') ";
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
            else if (CheckWhere == "Over Time")
            {
                SearchColumn = " sum(AR.OverTime) as 'Count'";
                //WhereClause = " and AR.Status IN('WOP') ";
            }
            else if (CheckWhere == "Total Hours")
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

            MainQuery = "select " + SearchColumn + " from AttendanceRecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId " +
                " where AR.EmployeeId=" + EmployeeId + " and ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            RValue = "0";
            DataSet ds = new DataSet();
            objBL.Query = MainQuery + WhereClause;
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
                RValue = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Count"]));

            if(RValue=="")
                RValue = "0";

            return RValue;
        }

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
                        "E.CategoryId" +
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

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    EmployeeId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeId"])));
                    objPC.CategoryId = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["CategoryId"])));
                    dataGridView1.Rows[i].Cells["clmEmployeeId"].Value = EmployeeId; // objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));

                    //if (EmployeeId == 33)
                    //{

                    //}

                    dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));
                    dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeName"]));
                    
                    dataGridView1.Rows[i].Cells["clmPresentDays"].Value = Get_Employee_Count("Present Days");
                    dataGridView1.Rows[i].Cells["clmLeavesDays"].Value = Get_Employee_Count("Leaves Days");
                    dataGridView1.Rows[i].Cells["clmHoliday"].Value = Get_Employee_Count("Holiday");
                    dataGridView1.Rows[i].Cells["clmAbsent"].Value = Get_Employee_Count("Absent");
                    dataGridView1.Rows[i].Cells["clmRegularOverTimeHours"].Value = Get_Employee_Count("Regular Over Time Hours");
                    dataGridView1.Rows[i].Cells["clmWOOTHours"].Value = Get_Employee_Count("WO OT Hours");
                    dataGridView1.Rows[i].Cells["clmTotalOTHours"].Value = Get_Employee_Count("Over Time");
                    dataGridView1.Rows[i].Cells["clmCompOffDays"].Value = Get_Employee_Count("Comp Off Days");
                    dataGridView1.Rows[i].Cells["clmTotalHours"].Value = Get_Employee_Count("Total Hours");
                    

                    double SalaryDays = 0, PresentDays = 0, LeavesDays = 0, AbsentDays = 0, CompOffDays = 0;
                    PresentDays = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells["clmPresentDays"].Value)));
                    LeavesDays = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells["clmLeavesDays"].Value)));
                    AbsentDays = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells["clmAbsent"].Value)));
                    //CompOffDays = objRL.CheckNullString_ReturnDouble(objRL.CheckNullString(Convert.ToString(dataGridView1.Rows[i].Cells["clmCompOffDays"].Value)));
                    SalaryDays = PresentDays + LeavesDays + AbsentDays;

                   
                    dataGridView1.Rows[i].Cells["clmTotalDays"].Value = SalaryDays.ToString();
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
