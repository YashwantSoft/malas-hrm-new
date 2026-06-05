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

namespace SPApplication
{
    public partial class DurationwiseReport : Form
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

        public DurationwiseReport()
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

        private string Get_Employee_Count(string CheckWhere)
        {
            SearchColumn = string.Empty;
            WhereClause = string.Empty;
            string RValue = string.Empty;

            SearchColumn = " count(*) as 'Count' ";

            if (CheckWhere == "Present Days")
            {
                WhereClause = " and AR.Status IN('P') ";
            }
            else if (CheckWhere == "Leaves Days")
            {
                WhereClause = " and AR.Status IN('L') ";
            }
            else if (CheckWhere == "Comp Off Days")
            {
                WhereClause = " and AR.Status IN('CO') ";
            }
            else if (CheckWhere == "Salary Days")
            {
                objRL.Get_CategoriesDetails_By_Id();

                SearchColumn = " (count(AR.AttendanceRecordId) - (select count(AR.AttendanceRecordId) as 'WeekOff' from attendancerecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId where AR.EmployeeId=98 and UPPER(DAYNAME(ARM.AttendanceDate)) = '" + objPC.WeeklyOff1Value + "' and AR.CancelTag=0 and ARM.CancelTag=0 and  ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "')) as 'Count' ";
                //WhereClause = " and AR.Status IN('P','WOP','HP','HD') ";
            }
            else if (CheckWhere == "Absent")
            {
                WhereClause = " and AR.Status IN('A') ";
            }
            else if (CheckWhere == "Over Time")
            {
                SearchColumn = " sum(AR.OverTime) as 'Count'";
            }

            MainQuery = "select " + SearchColumn + " from AttendanceRecord AR inner join attendancerecordmaster ARM on ARM.AttendanceRecordMasterId=AR.AttendanceRecordMasterId " +
                " where AR.EmployeeId=" + EmployeeId + " and ARM.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            DataSet ds = new DataSet();
            objBL.Query = MainQuery + WhereClause;
            ds = objBL.ReturnDataSet();

            if (ds.Tables[0].Rows.Count > 0)
                RValue = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[0]["Count"]));

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
                    dataGridView1.Rows[i].Cells["clmEmployeeCode"].Value = objRL.CheckNullString_ReturnInt(objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeCode"])));
                    dataGridView1.Rows[i].Cells["clmEmployeeName"].Value = objRL.CheckNullString(Convert.ToString(ds.Tables[0].Rows[i]["EmployeeName"]));
                    dataGridView1.Rows[i].Cells["clmPresentDays"].Value = Get_Employee_Count("Present Days");
                    dataGridView1.Rows[i].Cells["clmLeavesDays"].Value = Get_Employee_Count("Leaves Days");
                    dataGridView1.Rows[i].Cells["clmCompOffDays"].Value = Get_Employee_Count("Comp Off Days");
                    dataGridView1.Rows[i].Cells["clmSalaryDays"].Value = Get_Employee_Count("Salary Days");
                    dataGridView1.Rows[i].Cells["clmAbsent"].Value = Get_Employee_Count("Absent");
                    dataGridView1.Rows[i].Cells["clmOverTime"].Value = Get_Employee_Count("Over Time");
                }
            }
            else
            {
                objRL.ShowMessage(35, 4);
                return;
            }
        }

        private void DurationwiseReport_Load(object sender, EventArgs e)
        {
            CreateTable();
        }

        private void CreateTable()
        {
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            // Add rows and columns
            tlpAttendance.RowCount = 10;
            tlpAttendance.ColumnCount = (31 * 5);

            // Add some controls
            for (int i = 0; i < tlpAttendance.RowCount; i++)
            {
                int DayV = 1; 
                if (i == 0)
                {
                    for (int j = 0; j < tlpAttendance.ColumnCount; j++)
                    {
                        Label label = new Label();
                        label.Text = DayV.ToString(); // "({i}, {j})";
                        label.Dock = DockStyle.Fill;

                        tlpAttendance.Controls.Add(label, j, i);
                        tlpAttendance.SetColumnSpan(label, 5);
                        DayV++;
                    }
                }

                //for (int j = 0; j < tableLayoutPanel1.ColumnCount; j++)
                //{
                //    Label label = new Label();
                //    label.Text = DayV.ToString(); // "({i}, {j})";
                //    label.Dock = DockStyle.Fill;


                   

                //    // Merge cells (0,0) and (0,1)
                //    if (i == 0 && j == 0)
                //    {
                //        tableLayoutPanel1.Controls.Add(label, 0, 0);
                //        tableLayoutPanel1.SetColumnSpan(label, 5);
                //    }
                //    // Merge cells (1,1) and (1,2)
                //    else if (i == 1 && j == 1)
                //    {
                //        tableLayoutPanel1.Controls.Add(label, 1, 1);
                //        tableLayoutPanel1.SetColumnSpan(label, 2);
                //    }
                //    else
                //    {
                //        tableLayoutPanel1.Controls.Add(label, j, i);
                //    }

                //    DayV++;
                //}
            }

            this.Controls.Add(tableLayoutPanel1);
        }
    }
}
