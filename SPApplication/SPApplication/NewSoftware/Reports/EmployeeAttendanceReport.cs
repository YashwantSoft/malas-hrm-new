using BusinessLayerUtility;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.VariantTypes;
using MySql.Data.MySqlClient;
using SPApplication.HR;
using SPApplication.Transaction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Color = System.Drawing.Color;
using Excel = Microsoft.Office.Interop.Excel;
using Font = System.Drawing.Font;
//using ClosedXML.Excel;

namespace SPApplication.NewSoftware.Reports
{
    public partial class EmployeeAttendanceReport : Form
    {
        BusinessLayer objBL = new BusinessLayer();
        RedundancyLogics objRL = new RedundancyLogics();
        DesignLayer objDL = new DesignLayer();
        ErrorProvider objEP = new ErrorProvider();
        QueryLayer objQL = new QueryLayer();
        PropertyClass objPC = new PropertyClass();
         
        int LatePunch = 0, EarlyGoing = 0;
        string EmpDesignation = string.Empty;
        string EmpDepartment = string.Empty;
        string ConcatTotal = string.Empty;
        string RollTotal = string.Empty;

        string MainQuery = string.Empty, WhereClause = string.Empty, OrderByClause = string.Empty;
        bool ApproveFlag = false;

        DateTime dtIn, dtOut;
        double Duration = 0, OverTime = 0, TotalDuration = 0, LateBy = 0, EarlyBy = 0;

        TimeSpan totalOT = TimeSpan.Zero;
        TimeSpan totalDuration = TimeSpan.Zero;
        bool FlagDelete = false, FlagExist = false, SearchFlag = false, GridFlag = false;
        int RowCount_Grid = 0, CurrentRowIndex = 0, TableId = 0, Result = 0, EmployeeId = 0, LocationId = 0, DepartmentId = 0, SearchId = 0, ApprovalStatusId = 0;

        private void cmbReportType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Date_Options();
        }

        private void Fill_Date_Options()
        {
            if (cmbReportType.SelectedIndex > -1)
            {
                DateTime fromDate;
                DateTime toDate;
                DateTime today = DateTime.Today;

                switch (cmbReportType.Text)
                {
                    //Today
                    //This Week
                    //Last Week
                    //This Month
                    //Last Month
                    //This Year
                    //Last Year

                    case "Today":
                        fromDate = today;
                        toDate = today;
                        break;

                    case "This Week":
                        int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
                        fromDate = today.AddDays(-diff);
                        toDate = fromDate.AddDays(6);
                        break;

                    case "Last Week":
                        diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
                        fromDate = today.AddDays(-diff - 7);
                        toDate = fromDate.AddDays(6);
                        break;

                    case "This Month":
                        fromDate = new DateTime(today.Year, today.Month, 1);
                        toDate = fromDate.AddMonths(1).AddDays(-1);
                        break;

                    case "Last Month":
                        DateTime lastMonth = today.AddMonths(-1);
                        fromDate = new DateTime(lastMonth.Year, lastMonth.Month, 1);
                        toDate = fromDate.AddMonths(1).AddDays(-1);
                        break;

                    case "This Year":
                        fromDate = new DateTime(today.Year, 1, 1);
                        toDate = new DateTime(today.Year, 12, 31);
                        break;

                    case "Last Year":
                        fromDate = new DateTime(today.Year - 1, 1, 1);
                        toDate = new DateTime(today.Year - 1, 12, 31);
                        break;

                    default:
                        return;
                }

                dtpFromDate.Value = fromDate;
                dtpToDate.Value = toDate;

            }
        }

        public EmployeeAttendanceReport()
        {
            InitializeComponent();
            objRL.ReportTypeOptions(cmbReportType);
            objDL.SetDesignMaster(this, lblHeader, btnSave, btnClear, btnDelete, btnExit, "INDVIDUAL ATTENDANCE REPORT");
            //btnSave.Text = BusinessResources.BTN_VIEW;
            btnDelete.Text = BusinessResources.BTN_VIEW;
            //objQL.Fill_Master_ComboBox(cmbLocation, "locationmaster");

            //ClearAll();
            objRL.Fill_Approval_Status(cmbStatus);
            objDL.Set_Approval_Colour(lblPending);
            objDL.Set_Approval_Colour(lblHRApproved);
            objDL.Set_Approval_Colour(lblManagerApproved);
            objDL.Set_Approval_Colour(lblRemark);
            objDL.Set_Approval_Colour(lblCompleted);

            Fill_Employee_ListBox();
        }
        private void txtEmployeeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtEmployeeName.Text != "" && lbEmployee.Items.Count > 0)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
                {
                    lbEmployee.SelectedIndex = 0;
                    lbEmployee.Focus();
                }
            }
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
            if (!GridFlag)
            {
                EmployeeId = 0;
                rtbEmployee.Text = "";
            }

            if (!string.IsNullOrWhiteSpace(Convert.ToString(txtEmployeeName.Text)))
                objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "Text");
            else
                objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "All");
        }

        private void txtSearchEmpCode_Leave(object sender, EventArgs e)
        {

        }

        private void txtSearchEmpCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            objRL.NumericValue(sender, e, txtSearchEmpCode);
        }

        private void lbEmployee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetEmployeeDetails();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void lbEmployee_Click(object sender, EventArgs e)
        {
            GetEmployeeDetails();
        }

       
        private void EmployeeAttendanceReport_Load(object sender, EventArgs e)
        {
            //INDVIDUAL ATTENDANCE REPORT
        }

        public void Fill_Employee_ListBox()
        {
            if (BusinessLayer.UserType == BusinessResources.USER_TYPE_ADMINISTRATOR || BusinessLayer.UserType == BusinessResources.USER_TYPE_HROFFICER)
            {
                txtEmployeeName.Enabled = true;
                txtSearchEmpCode.Enabled = true;
                txtEmployeeName.Focus();
                lbEmployee.Visible = true;
                objRL.Fill_Employee_ListBox(lbEmployee, txtEmployeeName.Text, "All");
            }
            else
            {
                txtEmployeeName.Enabled = false;
                txtSearchEmpCode.Enabled = false;
                EmployeeId = BusinessLayer.EmployeeLoginId_Static;
                GetEmployeeDetails();
            }
        }

        private void ClearAll()
        {
            objEP.Clear();
            EmployeeId = 0;
            objPC.EmployeeId = 0;
            txtEmployeeName.Text = "";
            rtbEmployee.Text = "";
            lbEmployee.Visible = true;

            Fill_Employee_ListBox();

        }

        private void GetEmployeeDetails()
        {
            rtbEmployee.Text = "";
            if (EmployeeId == 0)
            {
                if (lbEmployee.SelectedIndex > -1)
                {
                    EmployeeId = 0;
                    EmployeeId = Convert.ToInt32(lbEmployee.SelectedValue);
                    objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
                    lbEmployee.Visible = false;
                }
            }
            else if (GridFlag && EmployeeId != 0)
            {
                objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
            }
            else if (BusinessLayer.Department != "Time Office" && EmployeeId != 0)
            {
                objRL.Fill_Employee_Details_RichTextBox(rtbEmployee, EmployeeId);
                lbEmployee.Visible = false;
            }
            else
            {
                rtbEmployee.Text = "";
                rtbEmployee.Visible = true;
                lbEmployee.Visible = true;
            }
        }

        private void FillGrid()
        {
            //CallStoreProcedure_AttendanceLogs();

            //dgvAttendanceStatus.Rows.Clear();
            dgvAttendanceStatus.DataSource = null;
            LocationId = 0;
            DepartmentId = 0;
            totalOT = TimeSpan.Zero;
            totalDuration = TimeSpan.Zero;

            lblTransferCount.Text = "";
            lblTotalCount.Text = "";

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            DataTable dt = new DataTable();

            MainQuery = string.Empty;
            WhereClause = string.Empty;
            OrderByClause = string.Empty;

            //MainQuery = objPC.AttendanceLogsQuery;

            //if (!cbLocation.Checked)
            //{
            //    if (cmbLocation.SelectedIndex > -1)
            //        LocationId = Convert.ToInt32(cmbLocation.SelectedValue);
            //    //WhereClause = " and AL.LocationId=" + LocationId + "";
            //}
            //if (!cbLocation.Checked && !cbDepartment.Checked)
            //{
            //    if (cmbDepartment.SelectedIndex > -1)
            //        DepartmentId = Convert.ToInt32(cmbDepartment.SelectedValue);
            //    // WhereClause += " and AL.DepartmentId=" + DepartmentId + "";
            //}

            if (LocationId > 0 && DepartmentId > 0)
            {
                WhereClause += " AND((AL.LocationId = " + LocationId + " AND AL.DepartmentId = " + DepartmentId + ") " +
                               " OR(AL.ChangeLocationtId = " + LocationId + " AND AL.ChangeDepartmentId = " + DepartmentId + ")) ";
            }
            else
            {
                if (LocationId > 0)
                    WhereClause += " AND AL.LocationId = " + LocationId + " ";
                //if (DepartmentId > 0)
                //    WhereClause += "AND AL.DepartmentId = " + DepartmentId + "";
            }


            MainQuery = objPC.Get_AttendanceLogs_Query(LocationId, DepartmentId);

            // WhereClause += " and AL.AttendanceDate='" + dtpAttenanceDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            WhereClause += " and AL.AttendanceDate between '" + dtpFromDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' and '" + dtpToDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "'";

            //if (cbEmployeeWise.Checked)
                if (EmployeeId > 0)
                    WhereClause += " and AL.EmployeeId=" + EmployeeId + "";


            //if (!cbSelectAllStatus.Checked)
            //    WhereClause += " and AL.ApprovalStatusId=" + cmbApprovalStatusSearch.SelectedValue + "";

            //if (!cbContractor.Checked)
            //    WhereClause += " and AL.ContractorId=" + cmbContractor.SelectedValue + "";

            if (!cbStatus.Checked)
                if(cmbStatus.SelectedIndex >-1)
                    WhereClause += " and AL.Status='" + cmbStatus.Text + "'";

            //if (!cbSelectAllStatus.Checked)
            //    WhereClause += " and AL.ApprovalStatusId=" + cmbApprovalStatusSearch.SelectedValue + "";

            //if (!cbDevice.Checked)
            //    WhereClause += " and E.DeviceId=" + cmbDevice.Text + "";

            if (!string.IsNullOrWhiteSpace(Convert.ToString(txtSearchEmpCode.Text)))
                WhereClause += " and E.EmployeeCode=" + txtSearchEmpCode.Text + "";

            //if (!string.IsNullOrWhiteSpace(Convert.ToString(txtSearchEmployee.Text)))
            //    WhereClause += " and E.EmployeeName LIKE '%" + txtSearchEmployee.Text + "%'";
            ////WhereClause += " and E.EmployeeName ='" + txtSearchEmployee.Text + "'";


            //if (ApprovalStatusId > 0)
            //{
            //    if (cbSelectAllStatus.Checked)
            //        WhereClause += " and AL.ApprovalStatusId=" + ApprovalStatusId + "";
            //}

            if (cbLatePunch.Checked)
                WhereClause += " and AL.LateBy>0 ";

            if (cbEarlyGoing.Checked)
                WhereClause += " and AL.EarlyBy>0 ";

        WhereClause += " and AL.ApprovalStatusId NOT IN(1) ";

            OrderByClause = " order by AL.AttendanceDate asc";

            //WhereClause = BusinessResources.AttendanceRecord_Where + " and arm.ApprovedFlag=3 " + WhereClause;

            //objQL.ColumnNames_V = BusinessResources.AttendanceRecord_Column;
            //objQL.TableNames_V = BusinessResources.AttendanceRecord_Table;
            //objQL.WhereClause_V = WhereClause;
            //objQL.OrderBy_V = " order by E.EmployeeName asc";
            //objQL.GroupBy_V = "";

            //dt = objQL.SP_Attendance_Report_Query_DataTable();


            objBL.Query = MainQuery + WhereClause + OrderByClause;
            dt = objBL.ReturnDataTable();

            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;



                int TotalCount = objRL.AttendanceCountAll();
                lblTotalCount.Text = "Total Count- " + TotalCount;

                //objBL.Query = "select Count(*) from attendancelogs where CancelTag=0 and "+ 
                //              " AttendanceDate='" + dtpAttenanceDate.Value.ToString(BusinessResources.DATEFORMATYYYYYMMDD) + "' "+
                //              " AND(LocationId = "+LocationId+" OR "+ LocationId + " = 0) AND(DepartmentId = "+DepartmentId+ " OR "+DepartmentId+" = 0)";
                //DataTable dtCount = new DataTable();
                //dtCount = 

                //" AND (LocationId = "+LocationId+ " AND DepartmentId=" + DepartmentId + " ) ";

                //              " AND(DepartmentId = @DepartmentId OR @DepartmentId = 0);
                //AND (DepartmentId = @DepartmentId OR @DepartmentId = 0);
                //AND (LocationId = "+LocationId+" OR "+ LocationId + " = 0) AND (DepartmentId = "+DepartmentId+ " OR "+DepartmentId+" = 0); ";

                //lblTotalCount.Text = "Total Count- " + dt.Rows.Count;


                //// Create checkbox column
                //DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                //chk.HeaderText = "Select";
                //chk.Name = "chkSelect";
                //chk.Width = 50;

                //// Add to DataGridView
                //dataGridView1.Columns.Insert(dataGridView1.Columns.Count, chk); // adds as first column

                //	0	AL.AttendanceLogId, +
                //	1	DATE_FORMAT(AL.AttendanceDate, '%d/%m/%Y') AS AttendanceDate, +
                //	2	AL.LocationId, +
                //	3	LM.LocationName as 'Location', +
                //	4	AL.DepartmentId,  +
                //	5	DM.Department, +
                //	6	L.LocationName AS 'Tran Location',  +
                //	7	D.Department AS 'Tran Department',  +
                //	8	AL.EmployeeId, +
                //	9	AL.EmployeeCode as 'Emp Code', +
                //	10	E.EmployeeName as 'Employee Name', +
                //	11	E.Gender, +
                //	12	AL.ContractorId, +
                //	13	CM.ContractorName as 'Roll Name', +
                //	14	AL.CategoryId,  +
                //	15	C.CategoryFName as 'Weekly Off', +
                //	16	AL.DesignationId,  +
                //	17	DES.Designation,  +
                //	18	AL.JobProfile,  +
                //	19	AL.ShiftGroupId,  +
                //	20	AL.OverTimeApplicable,  +
                //	21	AL.ShiftId,  +
                //	22	AL.ShiftFName as 'Shift Name', +
                //	23	TIME_FORMAT(AL.ShiftBeginTime, '%H:%i') AS 'Shift Begin', +
                //	24	TIME_FORMAT(AL.ShiftEndTime, '%H:%i') AS 'Shift End', +
                //	25	TIME_FORMAT(SEC_TO_TIME(AL.ShiftDuration * 60), '%H:%i') AS 'Shift Duration', +
                //	26	AL.InTime AS 'In Time', +
                //	27	AL.OutTime AS 'Out Time', +
                //	28	TIME_FORMAT(SEC_TO_TIME(AL.Duration * 60), '%H:%i') AS Duration, +
                //	29	TIME_FORMAT(SEC_TO_TIME(AL.OverTime * 60), '%H:%i') AS OverTime, +
                //	30	AL.Status,  +
                //	31	AL.Present,  +
                //	32	AL.HalfDay,  +
                //	33	AL.Absent,  +
                //	34	AL.MissedInPunch,  +
                //	35	AL.MissedOutPunch,  +
                //	36	AL.LateBy,  +
                //	37	AL.EarlyBy,  +
                //	38	AL.LossOfHours,  +
                //	39	AL.PunchRecords,  +
                //	40	AL.LeaveTypeId,  +
                //	41	AL.LeaveType,  +
                //	42	AL.LeaveDuration,  +
                //	43	AL.LeaveRemarks,  +
                //	44	AL.IsCompOff,  +
                //	45	AL.IsCompOffUsed,  +
                //	46	AL.CompOffRemarks,  +
                //	47	AL.CompOffUsedRemarks,  +
                //	48	AL.IsEditAttendance,  +
                //	49	AL.IsEditOverwrite,  +
                //	50	AL.IsLeaveForce,  +
                //	51	AL.HREditRemarks,  +
                //	52	AL.InchargeRemarks,  +
                //	53	AL.ManagerRemarks,  +
                //	54	AL.HRReply,  +
                //	55	AL.IsFlexibleHoursFlag,  +
                //	56	AL.FinancialYearId,  +
                //	57	AL.IsOutdoorEntry,+
                //	58	AL.IsRoll,  +
                //	59	AL.ChangeDepartmentFlag,  +
                //	60	AL.ChangeLocationtId,  +
                //	61	AL.ChangeDepartmentId,  +
                //	62	AL.TransferRemarks,  +
                //	63	AL.ApprovalStatusId,  +
                //	64	AL.IsEditOvertime,  +
                //	65	AL.OvertimePrevious  +

                // Hide multiple columns
                int[] indexesToHide = { 0, 2, 4, 8, 12, 14, 16, 17, 18, 19, 20, 21, 31, 32, 33, 34, 35, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 52, 55, 56, 57, 58, 59, 60, 61, 63, 64, 65 };

                foreach (int i in indexesToHide)
                {
                    if (i < dataGridView1.Columns.Count)
                    {
                        dataGridView1.Columns[i].Visible = false;
                    }
                }

                dataGridView1.Columns[3].Width = 80;
                dataGridView1.Columns[6].Width = 80;
                dataGridView1.Columns[9].Width = 50;
                dataGridView1.Columns[11].Width = 50;
                dataGridView1.Columns[10].Width = 200;
                dataGridView1.Columns[23].Width = 50;
                dataGridView1.Columns[24].Width = 50;
                dataGridView1.Columns[25].Width = 50;
                dataGridView1.Columns[26].Width = 120;
                dataGridView1.Columns[27].Width = 120;
                dataGridView1.Columns[28].Width = 50;
                dataGridView1.Columns[29].Width = 50;
                dataGridView1.Columns[30].Width = 50;
                dataGridView1.Columns[35].Width = 40;
                dataGridView1.Columns[36].Width = 40;
                dataGridView1.Columns[37].Width = 40;
                dataGridView1.Columns[38].Width = 40;
                //dataGridView1.Columns[39].Width = 100;

                dataGridView1.Columns[29].Width = 50;

                dataGridView1.Columns[0].ReadOnly = false;
                btnSave.Visible = true;

                ////            var statusCounts = dt.AsEnumerable()
                ////            .GroupBy(r => r["Status"].ToString())
                ////            .Select(g => new
                ////            {
                ////                Status = g.Key,
                ////                Count = g.Count()
                ////            });

                ////            ConcatTotal = string.Empty;
                ////            foreach (var item in statusCounts)
                ////            {
                ////                //MessageBox.Show(item.Status + " - " + item.Count);
                ////                ConcatTotal += item.Status + "-\t" + item.Count + "\n";
                ////            }

                int TransferCount = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Duration"] != DBNull.Value)
                    {
                        TimeSpan ts;
                        if (TimeSpan.TryParse(dr["Duration"].ToString(), out ts))
                        {
                            totalDuration += ts;
                        }
                    }
                    if (dr["OT"] != DBNull.Value)
                    {
                        TimeSpan ts;
                        if (TimeSpan.TryParse(dr["OT"].ToString(), out ts))
                        {
                            totalOT += ts;
                        }
                    }

                    if (dr["ChangeDepartmentFlag"] != DBNull.Value)
                    {
                        if (Convert.ToInt32(dr["ChangeDepartmentFlag"]) > 0)
                            TransferCount++;
                    }

                    // lblTotalCount.Text = "Total Count- " + dt.Rows.Count;
                    lblTransferCount.Text = "Total Transfer Count- " + TransferCount.ToString();
                }

                ////            //ConcatTotal += "Total Duration: " + totalDuration.ToString(@"hh\:mm") + "\n";
                ////            //ConcatTotal += "Total OT: " + totalOT.ToString(@"hh\:mm") + "\n";

                ////            //double Duration_Double = totalDuration.TotalHours;
                ////            //double OT_Double = totalDuration.TotalHours;

                ////            ConcatTotal += "Total Duration: " + Math.Round(totalDuration.TotalHours,0).ToString() + "\n";
                ////            ConcatTotal += "Total OT: " + Math.Round(totalOT.TotalHours, 0).ToString() + "\n";

                ////            //lblTotalOT.Text = "Total OT: " + totalOT.ToString(@"hh\:mm");

                ////            if (!string.IsNullOrWhiteSpace(ConcatTotal))
                ////                rtbStatusCount.Text = ConcatTotal.ToString();


                ////            string TransferTotal = string.Empty;

                ////            var TransferCounts = dt.AsEnumerable()
                ////                 .Where(r =>
                ////    r["ChangeDepartmentFlag"] != DBNull.Value &&
                ////    Convert.ToInt32(r["ChangeDepartmentFlag"]) == 1 &&

                ////    r["ChangeLocationtId"] != DBNull.Value &&
                ////    Convert.ToInt32(r["ChangeLocationtId"]) > 0 &&

                ////    r["ChangeDepartmentId"] != DBNull.Value &&
                ////    Convert.ToInt32(r["ChangeDepartmentId"]) > 0
                ////)
                ////.GroupBy(r => new
                ////{
                ////    TranLocation = r["Tran Location"].ToString(),
                ////    TranDepartment = r["Tran Department"].ToString()
                ////})
                ////.Select(g => new
                ////{
                ////    Location = g.Key.TranLocation,
                ////    Department = g.Key.TranDepartment,
                ////    Count = g.Count()
                ////});

                ////            foreach (var item in TransferCounts)
                ////            {
                ////                TransferTotal += item.Location + " - " + item.Department + " - " + item.Count + "\n";
                ////            }

                ////            rtbStatusCount.Visible = true;

                ////            if (!string.IsNullOrWhiteSpace(TransferTotal))
                ////                rtbStatusCount.Text = TransferTotal;

                ////            if (!string.IsNullOrWhiteSpace(TransferTotal))
                ////                rtbStatusCount.Text = TransferTotal.ToString();


                RollTotal = string.Empty;

                var rollCounts = dt.AsEnumerable()
    .GroupBy(r => r["Roll Name"].ToString())   // or "ContractorName" based on your column name
    .Select(g => new
    {
        RollName = g.Key,
        Count = g.Count()
    });

                foreach (var item in rollCounts)
                {
                    Console.WriteLine(item.RollName + " - " + item.Count);
                    //RollTotal += item.RollName + "-\t\t" + item.Count + "\n";
                    //RollTotal += item.RollName.PadRight(40) + " - " + item.Count.ToString().PadLeft(5) + "\n";
                    RollTotal += item.RollName + " - " + item.Count.ToString() + "\n";

                }

                rtbContractorWiseCount.Visible = true;

                if (!string.IsNullOrWhiteSpace(RollTotal))
                    rtbContractorWiseCount.Text = RollTotal.ToString();


                //            string DesignationTotal = string.Empty;

                //            //            var designationCounts = dt.AsEnumerable()
                //            //.GroupBy(r => r["Designation"].ToString())   // or "ContractorName" based on your column name
                //            //.Select(g => new
                //            //{
                //            //    RollName = g.Key,
                //            //    Count = g.Count()
                //            //});

                //            var designationCounts = dt.AsEnumerable()
                //.Where(r => new[] { "P", "HD", "HP" }.Contains(r["Status"].ToString()))
                //.GroupBy(r => r["Designation"].ToString())
                //.Select(g => new
                //{
                //    RollName = g.Key,
                //    Count = g.Count()
                //});

                //            foreach (var item in designationCounts)
                //            {
                //                Console.WriteLine(item.RollName + " - " + item.Count);
                //                DesignationTotal += item.RollName + " - " + item.Count.ToString() + "\n";

                //            }

                //            rtbDesignationCount.Visible = true;

                //            if (!string.IsNullOrWhiteSpace(DesignationTotal))
                //                rtbDesignationCount.Text = DesignationTotal.ToString();

                //Approval Status

                int pendingCount = 0;



                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    //if(!string.IsNullOrWhiteSpace(Convert.ToString(row.Cells["ApprovalStatusId"].Value)))
                    //{
                    //    //Pending
                    //    if (row.Cells["ApprovalStatusId"].Value != null && Convert.ToInt32(row.Cells["ApprovalStatusId"].Value) == 1)
                    //    {
                    //        row.DefaultCellStyle.BackColor = Color.Yellow;
                    //        pendingCount++;
                    //    }
                    //}

                    // Check LateBy column (only color that cell)
                    if (row.Cells["Late by"].Value != null &&
                        !string.IsNullOrWhiteSpace(row.Cells["Late by"].Value.ToString()))
                    {
                        double lateBy = Convert.ToDouble(row.Cells["Late by"].Value);

                        if (lateBy > 0)
                        {
                            row.Cells["Late by"].Style.BackColor = Color.Red;
                            row.Cells["Late by"].Style.ForeColor = Color.White; // optional for visibility
                        }
                    }

                    //lblHRApproved.Text
                    // Check LateBy column (only color that cell)
                    if (row.Cells["Early by"].Value != null &&
                        !string.IsNullOrWhiteSpace(row.Cells["Early by"].Value.ToString()))
                    {
                        double lateBy = Convert.ToDouble(row.Cells["Early by"].Value);

                        if (lateBy > 0)
                        {
                            row.Cells["Early by"].Style.BackColor = Color.Red;
                            row.Cells["Early by"].Style.ForeColor = Color.White; // optional for visibility
                        }
                    }
                }

                //lblPending.Text = "Pending: " + pendingCount;

                //Datagridview Sub
                dgvAttendanceStatus.DataSource = null;

                List<string> statusList = new List<string>();
                //lblHRApproved.Text
                using (MySqlConnection con = new MySqlConnection(objBL.conString))
                {
                    con.Open();

                    string QueryStatus = "SELECT DISTINCT Status " +
                        " FROM statusmaster " +
                        " ORDER BY " +
                        " CASE Status " +
                            "WHEN 'P'   THEN 1 " +
                            "WHEN 'HD'  THEN 2 " +
                            "WHEN 'L'   THEN 3 " +
                            "WHEN 'WOP' THEN 4 " +
                            "WHEN 'HP'  THEN 5 " +
                            "WHEN 'SL'  THEN 6 " +
                            "WHEN 'CO'  THEN 7 " +
                            "WHEN 'COU' THEN 8 " +
                            "WHEN 'A'   THEN 9 " +
                            "WHEN 'ODP' THEN 10 " +
                            "ELSE 11 " +
                            " END; ";

                    MySqlCommand cmd = new MySqlCommand(QueryStatus, con);



                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        if (reader["Status"] != DBNull.Value)
                            statusList.Add(reader["Status"].ToString());
                    }
                }

                string[] statuses = statusList.ToArray();
                // Define statuses you want as columns
                //string[] statuses = { "P", "A", "H", "HD", "COA", "COU", "WO" };

                // Create result table
                DataTable resultTable = new DataTable();
                resultTable.Columns.Add("Designation");

                // Add dynamic status columns
                foreach (var status in statuses)
                {
                    resultTable.Columns.Add(status, typeof(int));
                }

                // Group data
                var groupedData = dt.AsEnumerable()
                    .GroupBy(r => r["Designation"].ToString())
                    .OrderBy(g => g.Key);

                // Fill rows
                foreach (var group in groupedData)
                {
                    DataRow row = resultTable.NewRow();
                    row["Designation"] = group.Key;

                    foreach (var status in statuses)
                    {
                        int count = group.Count(r => r["Status"] != DBNull.Value &&
                                                      r["Status"].ToString() == status);
                        row[status] = count;
                    }

                    resultTable.Rows.Add(row);
                }

                // ✅ ADD TOTAL ROW HERE (outside loop)
                DataRow totalRow = resultTable.NewRow();
                totalRow["Designation"] = "Total";

                foreach (var status in statuses)
                {
                    int total = resultTable.AsEnumerable()
                        .Sum(r => r.Field<int?>(status) ?? 0);

                    totalRow[status] = total;
                }

                resultTable.Rows.Add(totalRow);

                // Bind to DataGridView
                dgvAttendanceStatus.DataSource = resultTable;
                dgvAttendanceStatus.ReadOnly = true;


                //dataGridView2.Columns["Designation"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dgvAttendanceStatus.Columns["Designation"].Width = 150;
                foreach (string status in statuses)
                {
                    dgvAttendanceStatus.Columns[status].Width = 40;
                }

                // Set header background color
                dgvAttendanceStatus.EnableHeadersVisualStyles = false; // Must disable to apply custom colors
                                                                       // Convert string to Color
                Color headerColor = ColorTranslator.FromHtml(BusinessResources.BACKGROUND_COLOUR);

                dgvAttendanceStatus.ColumnHeadersDefaultCellStyle.BackColor = headerColor;
                dgvAttendanceStatus.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Header text
                dgvAttendanceStatus.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Optional font

                // Example: make "P" column light green and "A" column light red
                dgvAttendanceStatus.Columns["P"].DefaultCellStyle.BackColor = Color.LightGreen;
                dgvAttendanceStatus.Columns["P"].DefaultCellStyle.ForeColor = Color.Black;

                dgvAttendanceStatus.Columns["A"].DefaultCellStyle.BackColor = Color.LightSalmon;
                dgvAttendanceStatus.Columns["A"].DefaultCellStyle.ForeColor = Color.Black;

                foreach (DataGridViewRow row in dgvAttendanceStatus.Rows)
                {
                    if (row.Cells["Designation"].Value != null &&
                        row.Cells["Designation"].Value.ToString() == "Total")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.Font = new Font(dgvAttendanceStatus.Font, FontStyle.Bold);
                    }
                }

                //foreach (DataGridViewRow row in dataGridView2.Rows)
                //{
                //    if (row.Cells["ApprovalStatusId"].Value != null && Convert.ToInt32(row.Cells["ApprovalStatusId"].Value) == 1)
                //    {
                //        row.DefaultCellStyle.BackColor = Color.Yellow;
                //    }
                //}

                //int pendingCount = dt.AsEnumerable()
                //     .Count(r => r["ApprovalStatusId"] != DBNull.Value &&
                //                 r["ApprovalStatus"].ToString() == "1");

                //lblPending.Text = "Pending: " + pendingCount;


                //Transfer IN Logics
                dgvTransferIN.DataSource = null;

                // Define statuses
                string[] statusesTranser = { "P" };

                // Create result table
                DataTable resultTableTrnasfer = new DataTable();
                resultTableTrnasfer.Columns.Add("Tran IN Location");
                resultTableTrnasfer.Columns.Add("Tran IN Department");

                // Add dynamic status columns
                foreach (var status in statusesTranser)
                {
                    resultTableTrnasfer.Columns.Add(status, typeof(int));
                }

                // Filter + Group (SAFE VERSION)
                var groupedDataTransfer = dt.AsEnumerable()
                    .Where(r => !string.IsNullOrWhiteSpace(r.Field<string>("Location")) &&
                                !string.IsNullOrWhiteSpace(r.Field<string>("Department")) &&
                                (r.Field<int?>("ChangeDepartmentFlag") ?? 0) > 0 &&
                                (r.Field<int?>("ChangeLocationtId") ?? 0) > 0 &&
                                (r.Field<int?>("ChangeLocationtId") ?? 0) == LocationId &&
                                (r.Field<int?>("ChangeDepartmentId") ?? 0) > 0 &&
                                (r.Field<int?>("ChangeDepartmentId") ?? 0) == DepartmentId)
                    .GroupBy(r => new
                    {
                        Location = r.Field<string>("Location"),
                        Department = r.Field<string>("Department")
                    })
                    .OrderBy(g => g.Key.Location)
                    .ThenBy(g => g.Key.Department);

                // Fill result table
                foreach (var group in groupedDataTransfer)
                {
                    DataRow row = resultTableTrnasfer.NewRow();

                    row["Tran IN Location"] = group.Key.Location;
                    row["Tran IN Department"] = group.Key.Department;

                    foreach (var status in statusesTranser)
                    {
                        int count = group.Count(r => r.Field<string>("Status") == status);
                        row[status] = count;
                    }

                    //resultTableTrnasfer.Rows.Add(row);
                    resultTableTrnasfer.Rows.Add(row);  // existing loop end

                    // 👉 ADD TOTAL ROW HERE
                    DataRow totalRowIN = resultTableTrnasfer.NewRow();
                    totalRowIN["Tran IN Location"] = "Total";
                    totalRowIN["Tran IN Department"] = "";

                    foreach (var status in statusesTranser)
                    {
                        int total = resultTableTrnasfer.AsEnumerable()
                            .Sum(r => r.Field<int?>(status) ?? 0);

                        totalRowIN[status] = total;
                    }

                    resultTableTrnasfer.Rows.Add(totalRowIN);

                    // Bind
                    dgvTransferIN.DataSource = resultTableTrnasfer;
                    dgvTransferIN.ReadOnly = true;
                    dgvTransferIN.Columns[2].Width = 40;
                }

                // Bind to grid
                dgvTransferIN.DataSource = resultTableTrnasfer;
                dgvTransferIN.ReadOnly = true;

                foreach (DataGridViewRow row in dgvTransferIN.Rows)
                {
                    if (row.Cells["Tran IN Location"].Value != null &&
                        row.Cells["Tran IN Location"].Value.ToString() == "Total")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.Font = new Font(dgvTransferIN.Font, FontStyle.Bold);
                    }
                }


                //Transfer Out Logics
                dgvTransferOut.DataSource = null;

                // Define statuses
                string[] statusesTranserOut = { "P" };

                // Create result table
                DataTable resultTableTrnasferOut = new DataTable();
                resultTableTrnasferOut.Columns.Add("Tran OUT Location");
                resultTableTrnasferOut.Columns.Add("Tran OUT Department");

                // Add dynamic status columns
                foreach (var status in statusesTranserOut)
                {
                    resultTableTrnasferOut.Columns.Add(status, typeof(int));
                }

                // Filter + Group (SAFE VERSION)
                var groupedDataTransferOut = dt.AsEnumerable()
                    .Where(r => !string.IsNullOrWhiteSpace(r.Field<string>("Tran Location")) &&
                                !string.IsNullOrWhiteSpace(r.Field<string>("Tran Department")) &&
                                (r.Field<int?>("ChangeDepartmentFlag") ?? 0) > 0 &&
                                (r.Field<int?>("LocationId") ?? 0) > 0 &&
                                (r.Field<int?>("LocationId") ?? 0) == LocationId &&
                                (r.Field<int?>("DepartmentId") ?? 0) > 0 &&
                                (r.Field<int?>("DepartmentId") ?? 0) == DepartmentId)
                    .GroupBy(r => new
                    {
                        Location = r.Field<string>("Tran Location"),
                        Department = r.Field<string>("Tran Department")
                    })
                    .OrderBy(g => g.Key.Location)
                    .ThenBy(g => g.Key.Department);

                // Fill result table
                foreach (var group in groupedDataTransferOut)
                {
                    DataRow row = resultTableTrnasferOut.NewRow();

                    row["Tran OUT Location"] = group.Key.Location;
                    row["Tran OUT Department"] = group.Key.Department;

                    foreach (var status in statusesTranserOut)
                    {
                        int count = group.Count(r => r.Field<string>("Status") == status);
                        row[status] = count;
                    }

                    resultTableTrnasferOut.Rows.Add(row);

                    // 👉 ADD TOTAL ROW HERE
                    DataRow totalRowOut = resultTableTrnasferOut.NewRow();
                    totalRowOut["Tran OUT Location"] = "Total";
                    totalRowOut["Tran OUT Department"] = "";

                    foreach (var status in statusesTranserOut)
                    {
                        int total = resultTableTrnasferOut.AsEnumerable()
                            .Sum(r => r.Field<int?>(status) ?? 0);

                        totalRowOut[status] = total;
                    }

                    resultTableTrnasferOut.Rows.Add(totalRowOut);
                }

                // Bind to grid
                dgvTransferOut.DataSource = resultTableTrnasferOut;
                dgvTransferOut.ReadOnly = true;
                dgvTransferOut.Columns[2].Width = 40;

                foreach (DataGridViewRow row in dgvTransferOut.Rows)
                {
                    if (row.Cells["Tran OUT Location"].Value != null &&
                        row.Cells["Tran OUT Location"].Value.ToString() == "Total")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.Font = new Font(dgvTransferOut.Font, FontStyle.Bold);
                    }
                }

                objRL.Set_Approval_Colour_DataGridView(dataGridView1, lblPending, lblHRApproved, lblManagerApproved, lblRemark, lblCompleted, "ApprovalStatusId");

                int OutdoorEntryCount = dataGridView1.Rows
    .Cast<DataGridViewRow>()
    .Where(r => !r.IsNewRow)
    .Count(row =>
        row.Cells["IsOutdoorEntry"].Value != null &&
        row.Cells["OutdoorApprovalStatusId"].Value != null &&
        row.Cells["IsOutdoorEntry"].Value.ToString() == "1" &&
        row.Cells["OutdoorApprovalStatusId"].Value.ToString() == "1");

                lblOutdoorEntryCount.Text = "Outdoor Pending-" + OutdoorEntryCount.ToString();

                //MessageBox.Show(lblHRApproved.Text);
            }

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.RowHeadersDefaultCellStyle.BackColor = Color.LightGreen;
            dataGridView1.RowHeadersDefaultCellStyle.ForeColor = Color.Black;
        }
    }
}
